using myBankApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace myBankApplication.ViewModels
{
    public class DepositChequeViewModel
    {
  
        public double Amount { get; set; }


        public string Description { get; set; }

        public string AppUserId { get; set; }

        public IFormFile FrontChequeImage { get; set; }

        public IFormFile BackChequeImage { get; set; }
    }
}
