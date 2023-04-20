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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Year_Opened { get; set; } = DateTime.Now;


        public ICollection<AccountModel> Accounts { get; set; }


    }

   
}
