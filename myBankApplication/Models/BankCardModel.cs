using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myBankApplication.Models
{
    
    public class BankCardModel
    {
        
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength (16)]
        [MinLength(16)]
        public string CardNumber { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required, MaxLength(3), MinLength(3)]
        public int CVVNumber { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        public int? ContaclessLimit { get; set; }

        public int CardPin { get; set; } = new Random().Next(1000,9999);

      
        [ForeignKey("AccountModel")]
        public int Account_Id { get; set; }
        public AccountModel? AccountNumber;

 
        [ForeignKey("AppUserModel")]
        public string? AppUserId { get; set; }
        public AppUsersModel? AppUsers { get; set; }

    }
}
