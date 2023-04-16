using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myBankApplication.Models
{
    
    public class BankCardModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CardNumber { get; set; }

        [Required]
        public int CVVNumber { get; set; } = new Random().Next(100, 999);

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ValidFrom { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ExpiryDate { get; set; }

        public int? ContaclessLimit { get; set; }

        [Required]
        public int CardPin { get; set; } = new Random().Next(1000,9999);

      
        [ForeignKey("AccountModel")]
        public int Account_Id { get; set; }
        public AccountModel? AccountNumber;

 
        [ForeignKey("AppUsersModel")]
        public string? AppUserId { get; set; }
        public AppUsersModel? AppUsers { get; set; }

    }
}
