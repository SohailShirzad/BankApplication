using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myBankApplication.Models
{
    public class TransactionModel
    {
        [Key]
        public int Id { get; set; }
        [Column (TypeName ="nvarchar(12)")]


        [Required]
        [ForeignKey("AccountModel")]
        public int AccountNo { get; set; }
        public AccountModel Account { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [Required]
        public string BeniciaryName { get; set; }
       
        [Column(TypeName = "nvarchar(80)")]
        [Required, MaxLength(100)]
        public string BankName { get; set; }

        [Column(TypeName = "nvarchar(11)")]
        [Required]
        public int SWIFTCode { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public DateTime Date  { get; set; } = DateTime.Now;

        [Column(TypeName = "nvarchar(80)")]
        [Required, MaxLength(20)]
        public String Reference { get; set; }
    }
}
