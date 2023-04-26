using myBankApplication.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myBankApplication.ViewModels
{
    public class CardChangePinViewModel
    {
        
        [Required]
        [Range(1000,9999)]
        public int CardPin { get; set; }

        [Required(ErrorMessage = "PIN confirmation is required")]
        [Compare("CardPin", ErrorMessage = "PIN does not match, Please Try again")]
        public int ConfrimPin { get; set; }

        public string? AppUserId { get; set; }

        public ICollection<BankCardModel>? BankCards { get; set; }

        public long? CardNumber { get; set; }

        [Range(1, 100)]
        public int? ContaclessLimit { get; set; }


        public int? Account_Id { get; set; }

    }

}
