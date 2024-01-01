using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Required(ErrorMessage ="Book Reference number is required.")]
        public string? BookReferenceNo { get; set; }
        [Required (ErrorMessage ="Book title is required.")]
        public string? BookName { get; set; }
        [Required (ErrorMessage ="Book theme is required.")]
        public string? Theme { get; set; }
        [Required (ErrorMessage ="Book status is required.")]
        public string? BookStatus { get; set; } = string.Empty;
        public bool isActive { get;set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastUpdate { get; set; }



    }
}
