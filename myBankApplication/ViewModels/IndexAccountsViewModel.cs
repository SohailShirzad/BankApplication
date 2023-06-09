﻿using myBankApplication.Data.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace myBankApplication.ViewModels
{
    public class IndexAccountsViewModel
    {
        public int AccountNo { get; set; }

        public string? Sort_Code { get; set; }

        public AccountType AccountType { get; set; }

        public decimal Balance { get; set; }


        public DateTime Date_Opened { get; set; }

        public Status Status { get; set; }

        public DateTime Close_Date { get; set; }

        public string AppUserId { get; set; }
    }
}
