using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookReferenceNo { get; set; }
        public string BookName { get; set; }
        public string Theme { get; set; }
        public string BookStatus { get; set; }
        public bool isActive { get;set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastUpdate { get; set; }



    }
}
