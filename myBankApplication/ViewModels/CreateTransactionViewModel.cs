using Microsoft.EntityFrameworkCore.Metadata.Internal;
using myBankApplication.Data.Enum;
using myBankApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace myBankApplication.ViewModels
{
    public class CreateTransactionViewModel
    { 

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string? RecipientName { get; set; }

        [Required]
        public TransactionType TransactionType { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.Now;


        [Required, MaxLength(20)]
        public string? Reference { get; set; }

        [ForeignKey("AccountModel")]
        public int? AccountNo { get; set; }
        public AccountModel? Account { get; set; }

        [Display(Name = "Distination Account")]
        public int? DestAccount { get; set; }

        [ForeignKey("AppUserModel")]
        public string? AppUserId { get; set; }
        public AppUsersModel? AppUsers { get; set; }
    }
}

