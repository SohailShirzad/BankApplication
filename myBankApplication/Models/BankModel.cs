using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myBankApplication.Models
{
    public class BankModel
    {
        [Key]
        [Column(TypeName = "nvarchar(80)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(80)")]
        public string Bank_Address { get; set; }


        public DateTime Year_Opened { get; set; }


        public int Customer_Id { get; set; }
        public CustomerModel Manager { get; set; }
    
        
    }

   
}
