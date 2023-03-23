using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myBankApplication.Models
{
    public class BankModel
    {
        [Key]
        [Column(TypeName = "nvarchar(80)")]
        public string BankName { get; set; } = "Serena";

        [Column(TypeName = "nvarchar(80)")]
        public string Bank_Address { get; set; } = "London";


        public DateTime? Year_Opened { get; set; } = DateTime.Now;

        [ForeignKey("AppUserModel")]
        public string? AppUserId { get; set; }
        public AppUsersModel? AppUsers { get; set; }

        public ICollection<AccountModel> Accounts { get; set; }

        public ICollection<AppUsersModel> Users { get; set; }


    }

   
}
