using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementDemo
{
    public class Author
    {
        private int Id;

        public int getID
        {
            get { return Id; }
            set { Id = value; }
        }
        private string Name;
        public string getName
        {
            get { return Name; }
            set { Name = value; }
        }
        private char Gender;

        public char getGender { get { return Gender; } set { Gender = value; } }
        public Author(int id, string name, char gender)
        {
            Id = id;
            Name = name;
            Gender = gender;

        }

        public void printDetails()
        {
           

        }
    }
}
