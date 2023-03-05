using Microsoft.AspNetCore.Mvc;
using myBankApplication.Data;
using myBankApplication.Interfaces;
using myBankApplication.Models;

namespace myBankApplication.Controllers
{
    public class AccountModelController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountModelController(IAccountRepository BankAccountRepositoy)
        {
            _accountRepository = BankAccountRepositoy;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<AccountModel> accounts = await _accountRepository.GetAll();
            return View(accounts);
        }

        public async Task<IActionResult> Detail(int id)
        {
            AccountModel accountModel = await _accountRepository.getByIdAsync(id);
            return View(accountModel);
        }
    }
}
