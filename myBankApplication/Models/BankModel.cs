using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myBankApplication.Models
{
    public class BankModel
    {
        [Key]
        [Column(TypeName = "nvarchar(80)")]
        public string BankName { get; set; }

        [Column(TypeName = "nvarchar(80)")]
        public string Bank_Address { get; set; }


        public DateTime Year_Opened { get; set; }

        [ForeignKey("AppUserModel")]
        public string? AppUserId { get; set; }
        public AppUsersModel? AppUsers { get; set; }


    }

   
}
