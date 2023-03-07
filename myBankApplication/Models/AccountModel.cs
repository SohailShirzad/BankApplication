using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using myBankApplication.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myBankApplication.Models
{
    public class AccountModel
    {
        [Key]
        [MaxLength(8)]
        public int AccountNo { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(8)")]
        public string Sort_Code { get; set; }

        [Column(TypeName = "nvarchar(8)")]
        [Required]
        public AccountType AccountType { get; set; } 

        [Required]
        public double Balance { get; set; }

        [Required]
        public DateTime Date_Opened { get; set; }

        [Required]
        public AccountStatus Status { get; set; }
        
        public DateTime? Close_Date { get; set; }

        [ForeignKey("AppUserModel")]
        public string? AppUserId { get; set; }
        public AppUsersModel? AppUsers { get; set; }

        [Required]
        [ForeignKey("BankModel")]
        public string BankName { get; set; }
        public BankModel Bank { get; set; }



    }
}
