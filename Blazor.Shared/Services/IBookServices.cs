using Blazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Services
{
    public interface IBookServices
    {
        public IEnumerable<Book> GetAllStudent();
        public void AddNewBook(Book newBook);
        public void DeleteBookById(int? bookId);
        public void UpdateBookById(Book book);
    }
}
