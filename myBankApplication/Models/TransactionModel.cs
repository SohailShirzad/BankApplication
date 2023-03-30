using Microsoft.Identity.Client;
using myBankApplication.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myBankApplication.Models
{
    public class TransactionModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string? BeniciaryName { get; set; }

        [Required]
        public TransactionType TransactionType { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public DateTime Date  { get; set; } = DateTime.Now;


        [Required, MaxLength(20)]
        public string? Reference { get; set; }

        [ForeignKey("AccountModel")]
        public int? AccountNo { get; set; }
        public AccountModel? Account { get; set; }

        [ForeignKey("AppUserModel")]
        public string? AppUserId { get; set; }
        public AppUsersModel? AppUsers { get; set; }
    }
}
