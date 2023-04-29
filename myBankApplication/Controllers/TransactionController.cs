using CloudinaryDotNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using myBankApplication.Data;
using myBankApplication.Data.Enum;
using myBankApplication.Interfaces;
using myBankApplication.Models;
using myBankApplication.Repository;
using myBankApplication.ViewModels;
using System.Transactions;

namespace myBankApplication.Controllers
{
    public class TransactionController : Controller
    {

        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IDepositChequeRepository _depositChequeRepository;

        public TransactionController(ITransactionRepository transactionRepository, ApplicationDbContext applicationDbContext,
            IAccountRepository accountRepository, IDepositChequeRepository depositChequeRepository)
        {
            _transactionRepository = transactionRepository;
            _applicationDbContext = applicationDbContext;
            _accountRepository = accountRepository;
            _depositChequeRepository = depositChequeRepository;
        }

        //admin
        public async Task<IActionResult> Index(string reference, int? accountNumber)
        {
            if (isUserAuthenticated())
            {
                return RedirectToAction("Login", "UserAuthentication");
            }


            var transactions = from m in _applicationDbContext.Transactions
                               select m;


            if (reference != "" && reference != null)
            {
                transactions = transactions.Where(t => t.Reference!.Contains(reference));
            }

            if (accountNumber != null)
            {
                transactions = transactions.Where(t => t.ToAccount == accountNumber
                || t.DestAccount == accountNumber);
            }

            return View(transactions);
        }



        public async Task<IActionResult> Detail(int id)
        {
            if (isUserAuthenticated())
            {
                return RedirectToAction("Login", "UserAuthentication");
            }
            var transactionDetails = await _transactionRepository.GetByIdAsync(id);
            if (transactionDetails == null)
            {
                return View("Error");

            }

            var acc = await _accountRepository.GetAll();
            var account = acc.Where(a => a.AppUserId == transactionDetails.AppUserId).SingleOrDefault();
            var indexTransactionsViewModel = new IndexTransactionsViewModel()
            {
                Id = transactionDetails.Id,
                AccountNo = transactionDetails.ToAccount,
                Amount = transactionDetails.Amount,
                DestAccount = transactionDetails.DestAccount,
                Reference = transactionDetails.Reference,
                Date = transactionDetails.Date,
                TransactionType = transactionDetails.TransactionType,
                RecipientName = transactionDetails.RecipientName,
                AppUserId = transactionDetails.AppUserId,

            };

            return View(indexTransactionsViewModel);


        }

        [HttpGet]
        public async Task<IActionResult> Deposit()
        {
            var curUserId = HttpContext.User.GetUserId();

            var account = await _accountRepository.GetAccountByUserId(curUserId);
            ViewBag.Accounts = new SelectList(account, "AccountNo");

            var createTransaction = new TransactionModel
            {
                AppUserId = curUserId,
            };

            return View(createTransaction);

        }

        [HttpPost]
        public async Task<IActionResult> Deposit(TransactionModel transactionVM)
        {
            if (isUserAuthenticated())
            {
                return RedirectToAction("Login", "UserAuthentication");
            }
            var curUserId = HttpContext.User.GetUserId();
            var acc = await _accountRepository.GetAll();
            var account = acc.Where(a => a.AppUserId == curUserId).SingleOrDefault();

            decimal intrestRate = (decimal) 0.025 * transactionVM.Amount;

            if (account.AccountType.Equals(AccountType.Savings))
            {
                account.Balance +=(intrestRate + transactionVM.Amount);

            }
            else
            {
                account.Balance += transactionVM.Amount;
            }

            if (ModelState.IsValid)
            {
                var transaction = new TransactionModel
                {
                    Id = transactionVM.Id,
                    RecipientName = transactionVM.RecipientName,
                    TransactionType = TransactionType.Deposit,
                    Amount = transactionVM.Amount,
                    Reference = transactionVM.Reference,
                    ToAccount = account.AccountNo,
                    AppUserId = transactionVM.AppUserId,

                };

                _transactionRepository.Add(transaction);
                ViewData["Success"] = "Transaction has been successful";
                return View(transactionVM);

            }

            else
            {
                ModelState.AddModelError("", "Failed to create a transaction, please try again later.");
            }

            return View(transactionVM);
        }



        [HttpGet]
        public async Task<IActionResult> DepositCheque(int id)
        {
            var curUserId = HttpContext.User.GetUserId();
            var cheque = await _depositChequeRepository.GetById(id);

            if (cheque == null)
            {
                TempData["Error"] = "Cheque with this ID does not exist in the system, please check and try again";
                return View();
            }

            var createTransaction = new TransactionModel
            {
                AppUserId = curUserId,
                DestAccount = cheque.AccountNum,
                Amount = cheque.Amount,
                Reference = cheque.Description,
                
            };

            return View(createTransaction);

        }

     


        //Used by admin 
        [HttpPost]
        public async Task<IActionResult> DepositCheque(TransactionModel transactionVM)
        {
            if (isUserAuthenticated()) { return RedirectToAction("Login", "UserAuthentication"); }
            var curUserId = HttpContext.User.GetUserId();
            var acc = await _accountRepository.GetAll();
            var accountTo = acc.Where(a => a.AccountNo == transactionVM.DestAccount).SingleOrDefault();
            var cheque = await _depositChequeRepository.GetAll();
            var chequeTo = cheque.Where(a => a.AccountNum == transactionVM.DestAccount && a.Status == Status.Active).FirstOrDefault();

            if (chequeTo == null)
            {
                TempData["Error"] = "The user does not have any pending cheque, please check and try again";
                return View(transactionVM);
            }

            chequeTo.Status = Status.Inactive;
            decimal intrestRate = (decimal)0.025 * transactionVM.Amount;

            if (accountTo.AccountType.Equals(AccountType.Savings))
            {
                accountTo.Balance +=(intrestRate + transactionVM.Amount);

            }

            else { accountTo.Balance += transactionVM.Amount; }

            if (ModelState.IsValid)
            {
                var transaction = new TransactionModel
                {
                    TransactionType = TransactionType.DepositCheque,
                    Amount = transactionVM.Amount,
                    Reference = transactionVM.Reference,
                    DestAccount = transactionVM.DestAccount,
                    AppUserId = transactionVM.AppUserId,
                };
                _transactionRepository.Add(transaction);
                ViewData["Success"] = "Transaction has been successful";
                return View();
            }

            else { ModelState.AddModelError("", "Failed to create a transaction, please try again later."); }
            return View(transactionVM);

            }


            [HttpGet]
            public async Task<IActionResult> Transfer()
            {
                var curUserId = HttpContext.User.GetUserId();

                var account = await _accountRepository.GetAccountByUserId(curUserId);
                ViewBag.Accounts = new SelectList(account, "AccountNo", "Tag");
                var createTransaction = new TransactionModel
                {
                    AppUserId = curUserId,

                };
                createTransaction.AppUserId = curUserId;
                return View(createTransaction);

            }

        [HttpPost]
        public async Task<IActionResult> Transfer(TransactionModel transactionVM)
        {
            if (isUserAuthenticated())
            {
                return RedirectToAction("Login", "UserAuthentication");
            }
            var curUserId = HttpContext.User.GetUserId();
            var acc = await _accountRepository.GetAll();
            var accountFrom = acc.Where(a => a.AppUserId == curUserId).SingleOrDefault();
            var accountTo = acc.Where(a => a.AccountNo == transactionVM.DestAccount).SingleOrDefault();


            decimal chargeRate = (decimal)0.05 * transactionVM.Amount;
            decimal interestRate = (decimal)0.025 * transactionVM.Amount;

            if (accountFrom == accountTo)
            {
                TempData["Error"] = "Account from and account to must not much, please try again";
                return View(transactionVM);
            }

            if (accountTo == null) {
                TempData["Error"] = "Could not find any distination account matching this account number. please check recipient account number and try again.";
                return View(transactionVM);
            }

            if (accountFrom.Balance < transactionVM.Amount)
            {
                TempData["Error"] = "You don't have sufficient balance to complete this transaction. Please check your balance and try again later.";
                return View(transactionVM);
            }

            else
            {
                if (accountFrom.AccountType.Equals(AccountType.Savings))
                {
                    if (accountFrom.Balance >= transactionVM.Amount)
                    {
                        accountFrom.Balance -= (chargeRate + transactionVM.Amount);

                    }

                }

                if (accountTo.AccountType.Equals(AccountType.Savings))
                {
                    if (accountFrom.Balance >= transactionVM.Amount)
                    {
                        accountTo.Balance += (interestRate + transactionVM.Amount);
                    }
                }


                if (accountFrom.AccountType != AccountType.Savings)
                {
                    if (accountFrom.Balance >= transactionVM.Amount)
                    {
                        accountFrom.Balance -= transactionVM.Amount;

                    }

                }

                if (accountTo.AccountType != AccountType.Savings)
                {
                    if (accountFrom.Balance >= transactionVM.Amount)
                    {
                        accountTo.Balance += transactionVM.Amount;

                    }
                }

                if(ModelState.IsValid)
                {
                    var transaction = new TransactionModel
                    {
                        Id = transactionVM.Id,
                        RecipientName = transactionVM.RecipientName,
                        TransactionType = TransactionType.Transfer,
                        Amount = transactionVM.Amount,
                        Reference = transactionVM.Reference,
                        ToAccount = accountFrom.AccountNo,
                        DestAccount = transactionVM.DestAccount,
                        AppUserId = transactionVM.AppUserId,


                    };

                    _transactionRepository.Add(transaction);
                    ViewData["Success"] = "Transaction has been successful";
                    return View();  
                }

                else
                {
                    ModelState.AddModelError("", "Failed to create a transaction, please try again later.");
                }

                return View(transactionVM);


            }

        }

        public Boolean isUserAuthenticated()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return true;
            }
            return false;
        }
    }
}