using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myBankApplication.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Column (TypeName ="nvarchar(12)")]


        [Required, MaxLength(8)]
        public int Account_No { get; set; }
        public Account Account { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [Required]
        public string BeniciaryName { get; set; }
       
        [Column(TypeName = "nvarchar(80)")]
        [Required, MaxLength(100)]
        public string BankName { get; set; }

        [Column(TypeName = "nvarchar(11)")]
        [Required, MaxLength(20)]
        public int SWIFTCode { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime Date  { get; set; } = DateTime.Now;
    }
}
