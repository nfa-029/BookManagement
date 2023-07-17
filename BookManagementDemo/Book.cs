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
            Console.WriteLine(" {0,-20}  {1,-25} {2,-10} {3,-10} {4:-30} {5} ", this.Id, this.Title, this.Edition, this.Price, this.dateOfPublishing.PadLeft(10, ' '), this.bookAuthor.PadLeft(25, ' '), this.authorID);
        }


        /*public Author getAuthor(int id)
        {
            return bookAuthor[id];

        }*/
    }
  }
