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
        public async Task <IActionResult> Deposit()
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

            account.Balance += transactionVM.Amount;

            if (ModelState.IsValid)
            {
                var transaction = new TransactionModel
                {
                    Id = transactionVM.Id,
                    BeniciaryName = transactionVM.BeniciaryName,
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



    }
}





//[HttpGet]

//public ActionResult Deposit(int AccountNo)
//{
//    return View();
//}

//[HttpPost]
//public ActionResult Deposit(TransactionModel transactionModel)
//{
//    if (ModelState.IsValid)
//    {
//        _applicationDbContext.Transactions.Add(transactionModel);
//        _applicationDbContext.SaveChanges();

//        var checking = _applicationDbContext.Accounts.Where(c => c.AccountNo == transactionModel.AccountNo).First();
//        checking.Balance = _applicationDbContext.Transactions.Where(c => c.AccountNo == transactionModel.AccountNo)
//            .Sum(c => c.Amount);
//        _applicationDbContext.SaveChanges();

//        return RedirectToAction("Balance", "AppUsers");

//    }


//    return View();




//}
