using myBankApplication.Data.Enum;
using myBankApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace myBankApplication.ViewModels
{
    public class IndexChequeViewModel
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }


        [Required(ErrorMessage = "Must be less than 20 characters")]
        [StringLength(20)]
        public string Description { get; set; }


        public Status Status { get; set; }
        public string? AppUserId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }
        public int? accountNumbber {get; set; }

     

        [Required]
        public string FrontChequeImage { get; set; }
        [Required]
        public string BackChequeImage { get; set; }
    }
}
