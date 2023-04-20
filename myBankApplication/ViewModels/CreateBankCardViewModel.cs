using myBankApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace myBankApplication.ViewModels
{
    public class CreateBankCardViewModel
    {

        public long CardNumber { get; set; }

        public int CVVNumber { get; set; } = new Random().Next(100, 999);

        public DateTime ValidFrom { get; set; } = DateTime.Now;

        public DateTime ExpiryDate { get; set; }

        public int ContaclessLimit { get; set; }

        public int CardPin { get; set; } = new Random().Next(1000, 9999);

        public int Account_Id { get; set; }

        //public string AppUserId { get; set; }


    }
}
