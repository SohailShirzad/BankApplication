using myBankApplication.Data.Enum;
using myBankApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace myBankApplication.ViewModels
{
    public class IndexChequeViewModel
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public string? AppUserId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }
        public string FrontChequeImage { get; set; }
        public string BackChequeImage { get; set; }
        public int? accountNumbber {get; set; }
    }
}
