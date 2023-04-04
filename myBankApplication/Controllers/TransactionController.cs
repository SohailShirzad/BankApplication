using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myBankApplication.Data;
using myBankApplication.Data.Enum;
using myBankApplication.Interfaces;
using myBankApplication.Models;
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

        public async Task<IActionResult> Index()
        {
            IEnumerable<TransactionModel> transactions = await _transactionRepository.GetAll();
            return View(transactions);
        }


        public async Task<IActionResult> Detail(int id)
        {
            TransactionModel transactionModel = await _transactionRepository.GetByIdAsync(id);
            return View(transactionModel);
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
                return RedirectToAction("Balance", "AppUsers");


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
                return RedirectToAction("TransactionFail");
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
    }
}