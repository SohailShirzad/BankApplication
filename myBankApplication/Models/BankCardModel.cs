using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myBankApplication.Models
{
    public class BankCardModel
    {
        
        public int cardNumber { get; set; }
        [Required, MaxLength(3), MinLength(3)]
        public int CVVNumber { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        public int? ContaclessLimit { get; set; }

        [Required]
        [ForeignKey("AccountModel")]
        public int Account_Id { get; set; }
        public AccountModel AccountNumber;

        [Required]
        [ForeignKey("CustomerModel")]
        public int Customer_Id { get; set; }
        public CustomerModel Customer { get; set; }

    }
}
