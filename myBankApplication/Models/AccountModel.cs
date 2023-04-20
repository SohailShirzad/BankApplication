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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountNo{ get; set; }


        
        [Column(TypeName = "nvarchar(8)")]
        public string? Sort_Code { get; set; }

        [Column(TypeName = "nvarchar(8)")]
        [Required(ErrorMessage = "Please select Account Type")]
        public AccountType AccountType { get; set; }


        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal? Balance { get; set; } 


        public DateTime? Date_Opened { get; set; } = DateTime.Now;

        
        public Status Status { get; set; } = Status.Active;
        
        public DateTime? Close_Date { get; set; }

        [ForeignKey("AppUserModel")]
        public string? AppUserId { get; set; }
        public AppUsersModel? AppUsers { get; set; }




    }
}
