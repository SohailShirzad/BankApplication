using myBankApplication.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myBankApplication.Models
{
    public class DepositChequeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        public double Amount { get; set; }

        [Required, MaxLength(20)]
        public string Description { get; set; }

        public Status Status { get; set; } = Status.Active;


        [ForeignKey("AppUserModel")]
        public string? AppUserId { get; set; }
        public AppUsersModel? AppUsers { get; set; }

     

        [Required]
        
        public string FrontChequeImage { get; set; }

        [Required]
        public string BackChequeImage { get; set; }

    }
}
