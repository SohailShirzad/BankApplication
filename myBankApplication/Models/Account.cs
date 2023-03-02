using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myBankApplication.Models
{
    public class Account
    {
        [Key]
        [MaxLength(8)]
        public int AccountNo { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(8)")]
        public string Sort_Code { get; set; }

        [Column(TypeName = "nvarchar(8)")]
        [Required]
        public string Account_Type { get; set; }

        [Column(TypeName = "decimal")]
        [Required]
        public decimal Balance { get; set; }

        [Required]
        public DateTime Date_Opened { get; set; }

        [Required]
        public  bool Is_Active { get; set; }
        [Required]
        public DateTime? Close_Date { get; set; }

        [Required, MaxLength(8)]
        public string Customer_Id { get; set; }
        public CustomerModel Customer { get; set; }



    }
}
