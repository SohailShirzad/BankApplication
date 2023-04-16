using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        public TransactionController(ITransactionRepository transactionRepository, ApplicationDbContext applicationDbContext, IAccountRepository accountRepository)
        {
            _transactionRepository = transactionRepository;
            _applicationDbContext = applicationDbContext;
            _accountRepository = accountRepository;
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

            if (transactions.Any())
            {
                transactions = transactions.Where( t => t.AccountNo == accountNumber
                || t.DestAccount == accountNumber );
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

            var acc = await _applicationDbContext.Accounts.ToListAsync();
            var account = acc.Where(a => a.AppUserId == transactionDetails.AppUserId).SingleOrDefault();
            var indexTransactionsViewModel = new IndexTransactionsViewModel()
            {
                Id = transactionDetails.Id,
                AccountNo = transactionDetails.AccountNo,
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

            //var cust = await _applicationDbContext.Users.ToListAsync();
            //var cuurentCust = cust.Where(c => c.Id == curUserId).SingleOrDefault();
            var account = await _applicationDbContext.Accounts.Where(a => a.AppUserId == curUserId).ToListAsync();
            ViewBag.Accounts = new SelectList(account, "AccountNo");

            var createTransaction = new TransactionModel
            {
                AppUserId = curUserId
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
            var acc = await _applicationDbContext.Accounts.ToListAsync();
            var account = acc.Where(a => a.AppUserId == curUserId).SingleOrDefault();

            if (account.AccountType.Equals(AccountType.Savings))
            {
                account.Balance = +(transactionVM.Amount + account.Balance) * 2.5;

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
                    AccountNo = account.AccountNo,
                    AppUserId = transactionVM.AppUserId,

                };

                _transactionRepository.Add(transaction);
                return RedirectToAction("Detail", "AppUsers");


            }

            else
            {
                ModelState.AddModelError("", "Failed to create a transaction, please try again later.");
            }

            return View(transactionVM);
        }



        [HttpGet]
        public async Task<IActionResult> DepositCheque()
        {
            var curUserId = HttpContext.User.GetUserId();

            //var cust = await _applicationDbContext.Users.ToListAsync();
            //var cuurentCust = cust.Where(c => c.Id == curUserId).SingleOrDefault();

            //var account = await _applicationDbContext.Accounts.Where(a => a.AppUserId == curUserId).ToListAsync();
            //ViewBag.Accounts = new SelectList(account, "AccountNo", "Tag");


            var createTransaction = new TransactionModel
            {
                AppUserId = curUserId,

            };
            createTransaction.AppUserId = curUserId;


            return View(createTransaction);

        }


        //Used by admin 
        [HttpPost]
        public async Task<IActionResult> DepositCheque(TransactionModel transactionVM)
        {
            if (isUserAuthenticated())
            {
                return RedirectToAction("Login", "UserAuthentication");
            }
            TransactionModel TransactionFrom = new TransactionModel();

            TransactionModel TransactionTo = new TransactionModel();

            var curUserId = HttpContext.User.GetUserId();


            TransactionFrom.TransactionType = TransactionType.Transfer;
            TransactionTo.TransactionType = TransactionType.Deposit;

            TransactionTo.AccountNo = transactionVM.DestAccount;
            TransactionTo.Amount = transactionVM.Amount;

            var acc = await _applicationDbContext.Accounts.ToListAsync();
            var accountTo = acc.Where(a => a.AccountNo == TransactionTo.AccountNo).SingleOrDefault();

            


            TransactionFrom.AppUserId = curUserId;
            TransactionTo.AppUserId = accountTo.AppUserId;

            var cheque = await _applicationDbContext.DepositCheque.ToListAsync();
            var chequeTo = cheque.Where(a => a.AppUserId == TransactionTo.AppUserId && a.Status == Status.Active).FirstOrDefault();

            if (chequeTo == null)
            {
                TempData["Message"] = "The user does not have any pending cheque, please check and try again";
                return View(transactionVM);
            }

            chequeTo.Status = Status.Inactive;

         
            accountTo.Balance += transactionVM.Amount;
                if (ModelState.IsValid)
                {
                    var transaction = new TransactionModel
                    {
                        Id = transactionVM.Id,
                        TransactionType = TransactionType.Deposit,
                        Amount = transactionVM.Amount,
                        Reference = transactionVM.Reference,
                        //AccountNo = accountFrom.AccountNo,
                        DestAccount = transactionVM.DestAccount,
                        AppUserId = transactionVM.AppUserId,


                    };

                    _transactionRepository.Add(transaction);
                    return RedirectToAction("Index", "DepositChequeController");

                }

                else
                {
                    ModelState.AddModelError("", "Failed to create a transaction, please try again later.");
                }

                return View(transactionVM);


            }


            [HttpGet]
            public async Task<IActionResult> Transfer()
            {
                var curUserId = HttpContext.User.GetUserId();

                //var cust = await _applicationDbContext.Users.ToListAsync();
                //var cuurentCust = cust.Where(c => c.Id == curUserId).SingleOrDefault();

                var account = await _applicationDbContext.Accounts.Where(a => a.AppUserId == curUserId).ToListAsync();
                ViewBag.Accounts = new SelectList(account, "AccountNo", "Tag");


                var createTransaction = new TransactionModel
                {
                    AppUserId = curUserId,
                    AccountNo = account[0].AccountNo,

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
            TransactionModel TransactionFrom = new TransactionModel();

            TransactionModel TransactionTo = new TransactionModel();

            var curUserId = HttpContext.User.GetUserId();


            TransactionFrom.TransactionType = TransactionType.Transfer;
            TransactionTo.TransactionType = TransactionType.Transfer;

            TransactionFrom.AccountNo = transactionVM.AccountNo;
            TransactionTo.AccountNo = transactionVM.DestAccount;

            TransactionFrom.Amount = transactionVM.Amount;
            TransactionTo.Amount = transactionVM.Amount;

            var acc = await _applicationDbContext.Accounts.ToListAsync();
            var accountFrom = acc.Where(a => a.AppUserId == curUserId).SingleOrDefault();
            var accountTo = acc.Where(a => a.AccountNo == TransactionTo.AccountNo).SingleOrDefault();

            //var accountNumber = accountFrom.AccountNo;

            TransactionFrom.AppUserId = curUserId;
            TransactionTo.AppUserId = accountTo.AppUserId;

         
            if (accountFrom == accountTo)
            {
                TempData["Message"] = "Account from and account to must not much, please try again";
                return View(transactionVM);
            }
            else
            {
                if (accountFrom.AccountType.Equals(AccountType.Savings))
                {
                    if (accountFrom.Balance >= transactionVM.Amount)
                    {
                        accountFrom.Balance = -(transactionVM.Amount - accountFrom.Balance) * 0.5;
                    }

                    accountTo.Balance += transactionVM.Amount;

                }

                else
                {
                    accountFrom.Balance -= transactionVM.Amount;
                    accountTo.Balance += transactionVM.Amount;
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
                        AccountNo = accountFrom.AccountNo,
                        DestAccount = transactionVM.DestAccount,
                        AppUserId = transactionVM.AppUserId,


                    };

                    _transactionRepository.Add(transaction);
                    return RedirectToAction("Balance","AppUsers");
                    
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