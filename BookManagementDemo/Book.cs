using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementDemo
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Edition { get; set; }
        public int Price { get; set; }

        public string? dateOfPublishing { get; set; }

        public string bookAuthor { get; set; }

        public int authorID { get; set; }

        public Book()
        {
            Id = 0;
            Title = "Some Title";
            // bookAuthor = new List<Author>();
        }
        public Book(int id, string title, int edition, int price, string dateOfPublishing, string bookAuthor, int authorID)
        {
            Id = id;
            Title = title;
            Edition = edition;
            Price = price;
            this.dateOfPublishing = dateOfPublishing;
            this.bookAuthor = bookAuthor;
            this.authorID = authorID;
        }
        public Book(int id, string title, int edition, int price, string dateOfPublishing, string bookAuthor)
        {
            Id = id;
            Title = title;
            Edition = edition;
            Price = price;
            this.dateOfPublishing = dateOfPublishing;
            this.bookAuthor = bookAuthor;

        }
        public void printList()
        {
           
        }


        /*public Author getAuthor(int id)
        {
            return bookAuthor[id];

        }*/
    }
  }
