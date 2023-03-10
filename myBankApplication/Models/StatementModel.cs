using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myBankApplication.Models
{
    public class StatementModel
    {
        [Key]

        [Required]
        public int StatementID { get; set; }


        [ForeignKey("AccountModel")]
        public int? AccountNo { get; set; }
        public AccountModel Account { get; set; }

        public DateTime? StatementDate { get; set; }


    }
}
