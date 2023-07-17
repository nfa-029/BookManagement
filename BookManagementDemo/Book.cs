using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementDemo
{
    public class Book
    {
        private int Id;
        public int ID
        {
            get { return Id; }
            set { Id = value; }
        }

        private string Title;
        public string getTitle
        {
            get
            { return Title; }
            set
            { Title = value; }
        }
        private int Edition;
        public int getEdition
        {
            get { return Edition; }
            set { Edition = value; }
        }
        private int Price;
        public int getPrice
        {
            get { return Price; }
            set { Price = value; }
        }
        private DateTime dateOfPublishing;
        public DateTime getDateOfPublishing
        {
            get { return dateOfPublishing; }
            set { dateOfPublishing = value; }
        }

        private int authorID;
        public int getAuthorID
        {
            get { return authorID; }
            set { authorID = value; }
        }


        public Book(int id, string title, int edition, int price, DateTime dateOfPublishing, int authorID)
        {
            Id = id;
            Title = title;
            Edition = edition;
            Price = price;
            this.dateOfPublishing = dateOfPublishing;
            this.authorID = authorID;
        }
        public Book(int id, string title, int edition, int price, DateTime dateOfPublishing)
        {
            Id = id;
            Title = title;
            Edition = edition;
            Price = price;
            this.dateOfPublishing = dateOfPublishing;


        }
        public void printList()
        {
            Console.WriteLine(" {0,-20}  {1,-25} {2,-10} {3,-10} {4,-30} ", this.Id, this.Title, this.Edition, this.Price, this.dateOfPublishing.ToString("d"), this.authorID);
        }

    }
}
