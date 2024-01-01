using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }   
        public string BorrowerName { get; set; }
        public DateTime DateBorrowed { get; set; } 
        public DateTime DateReturned { get; set; }
        public string TranStatus { get; set; }
        public bool IsCompleted { get; set; }
    }
}
