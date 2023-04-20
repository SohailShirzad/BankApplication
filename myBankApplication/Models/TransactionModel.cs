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
        [DisplayFormat(NullDisplayText = "No recipient")]
        public string? RecipientName { get; set; }

        [Required]
        public TransactionType TransactionType { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime Date  { get; set; } = DateTime.Now;


        [Required, MaxLength(20)]
        public string? Reference { get; set; }

        [ForeignKey("AccountModel")]
        public int? ToAccount { get; set; }
        public AccountModel? Account { get; set; }

        [DisplayFormat(NullDisplayText = "N/A")]
        [Display(Name = "Distination Account")]
        public int? DestAccount { get; set; }

        [ForeignKey("AppUserModel")]
        public string? AppUserId { get; set; }
        public AppUsersModel? AppUsers { get; set; }
    }
}
