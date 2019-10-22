using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MCash.Business.Domain
{
    public class BankAccount
    {
        [Key]
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string AccountHolder { get; set; }
        public string Currency { get; set; }
        public decimal OpeningBalance { get; set; }
        public decimal ClosingBalance { get; set; }
        public virtual List<TransactionDetails> TransactionDetails { get; set; }
        
    }
    public class TransactionDetails
    {
        [Key]
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Reference { get; set; }
        public decimal  Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Balance { get; set; }
        public string Description { get; set; }
       
    }
    public class TransactionViewModel
    {
        public string AccountNo { get; set; }
        public decimal TransactionAmount { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }

    }
    public class ConnectionStrings
    {
        public string MCashDemoConnectionString { get; set; }
    }
    public class UserProfile
    {
        public string Name { get; set; }
        public string SiteImageUrl { get; set; }
        public string MobileNo { get; set; }
        public string ProfileImageUrl { get; set; }
        public string FooterName { get; set; }
        public string WebSiteName { get; set; }
    }
}
