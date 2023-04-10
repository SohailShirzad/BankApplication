namespace myBankApplication.ViewModels
{
    public class IndexBankCardsViewModel
    {
        public long CardNumber { get; set; }

        public int CVVNumber { get; set; } 

        public DateTime? ValidFrom { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public int? ContaclessLimit { get; set; }

        public int CardPin { get; set; }

        public int? Account_Id { get; set; }

        public string? AppUserId { get; set; }
    }
}
