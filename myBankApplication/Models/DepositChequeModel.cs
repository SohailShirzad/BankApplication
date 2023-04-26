using myBankApplication.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myBankApplication.Models
{
    public class DepositChequeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [Required (ErrorMessage ="Must be less than 20 characters")]
        [StringLength (20)]
        public string Description { get; set; }

        public Status Status { get; set; } = Status.Active;


        [ForeignKey("AccountModel")]
        public int? AccountNum { get; set; }
        public AccountModel? AccountModel { get; set; }



        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; } = DateTime.Now;



        [Required]
        
        public string FrontChequeImage { get; set; }

        [Required]
        public string BackChequeImage { get; set; }

    }
}
