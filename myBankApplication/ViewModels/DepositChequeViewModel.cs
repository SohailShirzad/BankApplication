using myBankApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace myBankApplication.ViewModels
{
    public class DepositChequeViewModel
    {
        [Range(1, double.MaxValue, ErrorMessage ="The amount should not be negative or zero.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Must be less than 20 characters")]
        [StringLength(20)]
        public string Description { get; set; }

        public int AccountNum { get; set; }

        public string? AppUserId { get; set; }

        public DateTime? date { get; set; } = DateTime.Now;

        public decimal totalAmount { get; set; }

        public IFormFile FrontChequeImage { get; set; }

        public IFormFile BackChequeImage { get; set; }
    }
}
