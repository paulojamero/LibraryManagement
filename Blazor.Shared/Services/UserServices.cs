using Blazor.Shared.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Services
{
    public class UserServices : IUserServices
    {
        string ConnectionString = string.Empty;
        private readonly IConfiguration configuration;
        public UserServices(IConfiguration _configuration) 
        {
            ConnectionString = _configuration.GetConnectionString("DbConnection");
        }

        public IEnumerable<Book> GetAllStudent()
        {
            List<Book> bookList = new List<Book>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pr_GetAllBooks", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Book book = new Book();
                    book.BookId = Convert.ToInt32(rdr["BookID"]);
                    book.BookReferenceNo = rdr["BookReferenceNo"].ToString();
                    book.BookName = rdr["BookName"].ToString();
                    book.Theme = rdr["Theme"].ToString();
                    book.BookStatus = rdr["BookStatus"].ToString();
                    book.isActive = Convert.ToBoolean(rdr["IsActive"].ToString());
                    book.DateCreated = Convert.ToDateTime(rdr["DateCreated"].ToString());
                    book.DateLastUpdate = Convert.ToDateTime(rdr["DateLastUpdate"].ToString());

                    bookList.Add(book);
                }
                con.Close();
            }
            return bookList;
        }


        public void AddNewBook(Book newBook)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("pr_AddNewBook", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BookReferenceNo", newBook.BookReferenceNo);
                cmd.Parameters.AddWithValue("@BookName", newBook.BookName);
                cmd.Parameters.AddWithValue("@Theme", newBook.Theme);
                cmd.Parameters.AddWithValue("@BookStatus", newBook.BookStatus);
                //cmd.Parameters.AddWithValue("",);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
