using Microsoft.AspNetCore.Mvc;
using myBankApplication.Interfaces;
using myBankApplication.Models;
using myBankApplication.ViewModels;

namespace myBankApplication.Controllers
{
    public class TransactionModelController : Controller
    {

        private readonly ITransactionRepository _transactionRepository;

        public TransactionModelController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
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

        
    }
}
