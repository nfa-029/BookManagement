using BookManagementDemo;
using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Security.Cryptography;
using System.Transactions;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookManagementDemo
{

    public class BookManager
    {
        public delegate bool bookDelegate(List<Book> bookRef, int num);
        public delegate void bookDelegate1(List<Book> bookRef, string keyword);
        public delegate List<Book> sortDelegate(List<Book> listOfBooks);
        public static int Menu()
        {
            int choice = 0;
            Console.WriteLine("***     Welcome to Book Management System       ***");
            Console.WriteLine("     1. View Books List ");
            Console.WriteLine("     2. Add Book ");
            Console.WriteLine("     3. Update Book Information by Id");
            Console.WriteLine("     4. Search Book");
            Console.WriteLine("     5. Delete Book");
            Console.WriteLine("     6. Update Book Author Information");
            Console.WriteLine("     7. Insert Book Author Information");
            Console.WriteLine("     8. View Ordered Books List");
            Console.WriteLine("     0. To Exit");
            choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }
        //prints list of the books
        public static void viewBookList(List<Book> listOfBooks)
        {
            Console.WriteLine(" {0,-20}  {1,-20} {2,-10} {3,-10} {4, -30} ", "Id", "Title", "Edition", "Price", "Date of Publishing");
            for (int i = 0; i < listOfBooks.Count; ++i)
            {
                listOfBooks[i].printList();
            }

        }
        //view Author List
        public static void viewAuthorsList(List<Author> listOfAuth)
        {
            for (int i = 0; i < listOfAuth.Count; ++i)
            {
                listOfAuth[i].printDetails();
            }

        }
        //add book to the list
        public static void addBookToList(List<Book> listOfBooks)
        {
            try
            {
                Console.WriteLine("Enter book id");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(id);
                bool dup = listOfBooks.Any(x => x.ID == id);
                if (!dup)
                {
                    Console.WriteLine("Enter book Title");
                    string title = Console.ReadLine();
                    Console.WriteLine("Enter book Edition");
                    int ed = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter book Price");
                    int price = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter book Publish Date");
                    Console.WriteLine("Enter year: ");
                    int year = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter month: ");
                    int month = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter day: ");
                    int day = int.Parse(Console.ReadLine());
                    DateTime date = new DateTime(year, month, day);
                    Console.WriteLine("Enter book Author ID");
                    int authorId = Convert.ToInt32(Console.ReadLine());

                }
                else Console.WriteLine("Book Id already exists");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Invalid Input Type or Null");
            }

        }
        //updates book information 
        public static bool updateBookInfoById(List<Book> listOfBooks, int Id)
        {
            try
            {

                Console.WriteLine("Enter book's new Title");
                string title = Console.ReadLine();
                Console.WriteLine("Enter book's new Edition");
                int ed = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter book's new Price");
                int price = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter book's new Publish Date");
                Console.WriteLine("Enter year: ");
                int year = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter month: ");
                int month = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter day: ");
                int day = int.Parse(Console.ReadLine());
                DateTime date = new DateTime(year, month, day);
                Console.WriteLine("Enter book Author ID");
                int authorId = Convert.ToInt32(Console.ReadLine());
                foreach (var iter in listOfBooks.Where(x => x.ID == Id))
                {
                    iter.getTitle = title;
                    iter.getEdition = ed;
                    iter.getPrice = price;
                    iter.getDateOfPublishing = date;
                    iter.getAuthorID = authorId;

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Invalid Input Type or Null");
            }

            return false;

        }
        //Search book
        public static void searchBookByKeyword(List<Book> listOfBooks, string keyword)
        {

            var iter = listOfBooks.FindAll(x => x.getTitle.ToLower().Contains(keyword));

            if (iter != null)
            {
                Console.WriteLine(" {0,-20}  {1,-20} {2,-10} {3,-10} {4,-30}", "Id", "Title", "Edition", "Price", "Date of Publishing");
                foreach (Book book in iter)
                {
                    book.printList();
                }
            }
            else
            {
                Console.WriteLine("No item found in the list");

            }
        }
        //remove book from the list
        public static bool removeFromListById(List<Book> listOfBooks, int Id)
        {
            for (int i = 0; i < listOfBooks.Count - 1; i++)
            {
                if (listOfBooks[i].ID == Id)
                {
                    listOfBooks.RemoveAt(i);
                    return true;
                }
            }
            return false;

        }
        public static void removeFromListByKeyword(List<Book> listOfBooks, string keyword)
        {
            listOfBooks.RemoveAll(x => x.getTitle.ToLower().Contains(keyword));

        }

        //Author Details
        public static bool updateAuthorList(List<Author> listOfAuthors, int AuthID)
        {
            try
            {

                Console.WriteLine("Enter Author's Name");
                string author = Console.ReadLine();
                Console.WriteLine("Enter book Author ID");
                int authorId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter book Author Gender");
                char gender = Convert.ToChar(Console.ReadLine());

                foreach (var iter in listOfAuthors.Where(x => x.getID == AuthID))
                {
                    iter.getID = authorId;
                    iter.getName = author;
                    iter.getGender = gender;

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Invalid Input Type");

            }
            return false;

        }

        // Author details input
        public static void inputAuthorDetails(List<Author> listOfAuthors, int id)
        {
            try
            {
                Console.WriteLine("Enter Name of Author");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Gender of the Author");
                char gender = Convert.ToChar(Console.ReadLine());
                string checkGender = gender.ToString().ToLower();
                if (checkGender != "m" || checkGender != "f")
                {
                    throw new Exception();
                }

                Author author = new Author(id, name, gender);
                listOfAuthors.Add(author);
            }

            catch (Exception ex)
            {
                string str = ex switch
                {
                    FormatException => "Invalid Format... Exception!",
                    ArgumentNullException => "ArgumentNullException!",
                    _ => "Invalid Input"
                };
                Console.WriteLine(str);
                Console.WriteLine();

            }

        }
        //Sorting Books List by Name
        public static List<Book> sortByName(List<Book> listOfBooks)
        {
            var result = listOfBooks.OrderBy(x => x.getTitle).ToList();
            return result;
        }
        //Sorting Books List by ID
        public static List<Book> sortById(List<Book> listOfBooks)
        {
            var result = listOfBooks.OrderBy(x => x.ID).ToList();
            return result;
        }
        //Sorting Books List by Price
        public static List<Book> sortByPrice(List<Book> listOfBooks)
        {
            var result = listOfBooks.OrderBy(x => x.getPrice).ThenBy(x => x.ID).ToList();
            return result;
        }
        /// Main
        public static void Main()
        {
            List<Book> listOfBooks = new List<Book>() {
             new Book(1, "The Maverick Effect", 9, 2000, new DateTime(2020,09,23),10),
             new Book(2, "The Architect's Apprentice", 5, 450, new DateTime(2013,08,23),12),
             new Book(3, "The Lost Symbol", 3, 950, new DateTime(2015,10,2),11),
             new Book(4, "The Alchemist", 7, 450, new DateTime(1998,12,13),15),
             new Book(5, "The Art of War", 4, 100, new DateTime(2020,09,23), 16),
             new Book(6, "Time Machine", 1, 1000, new DateTime(2021,03,04), 17),
             new Book(7, "Utopia", 9, 520, new DateTime(2019,10,04), 18),
             new Book(8, "Divine Comedy", 10, 450, new DateTime(2020,09,23), 13),
             new Book(9, "Lost Letters", 4, 250, new DateTime(2004,11,11), 19),
             new Book(10, "Poems", 3, 600, new DateTime(1999,11,04), 14),
             new Book(11, "Honuor", 5, 750, new DateTime(2020,09,23), 12),
             new Book(12, "Mathnawi", 5, 650, new DateTime(2000,02,15), 14),
             new Book(13, "The Letters", 5, 850, new DateTime(2005,05,23), 14)
            };
            List<Author> listOfAuthors = new List<Author>()
            {
                new Author(10,"Harish Mehta",'M'),
                new Author(11,"Dan Brown",'M'),
                new Author(12,"Elif Shafak",'F'),
                new Author(13,"Dante",'M'),
                new Author(14,"Rumi",'M'),
                new Author(15,"Paulo Coelho",'M'),
                new Author(16,"Sun Tzu",'M'),
                new Author(17,"H.G. Wells",'M'),
                new Author(18,"Sir Thomas Moore",'M'),
                new Author(19,"F.Scott Fitzgerald",'M')
             };
            int choice = Menu();
            Console.WriteLine($"    You chose option {choice}");


            //switch statement for operations
            switch (choice)
            {
                //View Booklist
                case 1:

                    viewBookList(listOfBooks);
                    break;

                //Add to book list
                case 2:
                    addBookToList(listOfBooks);
                    Console.WriteLine();
                    viewBookList(listOfBooks);
                    Console.ReadLine();
                    break;

                //Update Book Info by Id
                case 3:
                    viewBookList(listOfBooks);
                    bool res = false;
                    Console.WriteLine("Input ID of book to update");
                    int Id = Convert.ToInt32(Console.ReadLine());
                    bookDelegate obj = new bookDelegate(updateBookInfoById);
                    res = obj(listOfBooks, Id);
                    if (res)
                    {
                        Console.WriteLine("Updated Successfully");
                        viewBookList(listOfBooks);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Id");
                    }
                    break;

                //Search book by keyword
                case 4:

                    Console.WriteLine("Enter keyword");
                    var input = Console.ReadLine();
                    if (input.GetType() == typeof(string))
                    {
                        bookDelegate1 delegate1 = new bookDelegate1(searchBookByKeyword);
                        delegate1(listOfBooks, input);

                    }
                    else Console.WriteLine("Invalid Keyword Search ");

                    break;

                //Remove from List by Id or Keyword
                case 5:
                    int option = 0;
                    viewBookList(listOfBooks);
                    Console.WriteLine("Choose to remove by Id or Keyword. \n 1. By Id \n 2. By Keyword");
                    option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {

                        case 1:
                            Console.WriteLine("Write Id of the Book to be Removed");
                            int bookId = Convert.ToInt32(Console.ReadLine());
                            bool res1 = false;
                            bookDelegate obj1 = new bookDelegate(removeFromListById);
                            res1 = obj1(listOfBooks, bookId + 1);
                            if (res1) viewBookList(listOfBooks);
                            else Console.WriteLine("No such book exists");
                            break;
                        case 2:
                            Console.WriteLine("Write keyword to Remove the Book(s)");
                            var inKeyword = Console.ReadLine();
                            bookDelegate1 delegate1 = new bookDelegate1(removeFromListByKeyword);
                            delegate1(listOfBooks, inKeyword);
                            viewBookList(listOfBooks);
                            break;
                        default:
                            Console.WriteLine("You chose the wrong option");
                            break;

                    }
                    break;

                //Update Author List
                case 6:
                    viewAuthorsList(listOfAuthors);
                    Console.WriteLine("Enter author's id to be updated");
                    int e = Convert.ToInt32(Console.ReadLine());
                    bool result = updateAuthorList(listOfAuthors, e);
                    if (result)
                    {

                        Console.WriteLine("---Update Successful--- ");
                        viewAuthorsList(listOfAuthors);
                    }
                    else Console.WriteLine("Invalid Author Name");
                    break;

                //insert author information
                case 7:
                    Console.WriteLine("Enter Author's id");
                    try
                    {
                        int id = int.Parse(Console.ReadLine());
                        bool has = listOfAuthors.Any(x => x.getID == id);
                        if (!has)
                        {
                            inputAuthorDetails(listOfAuthors, id);
                            viewAuthorsList(listOfAuthors);

                        }
                        else Console.WriteLine("The id already exists");
                    }
                    catch (Exception ex)
                    {
                        string str = ex switch
                        {
                            FormatException => "Invalid Format.... Exception!",
                            ArgumentNullException => "ArgumentNullException!",
                            _ => "Invalid Input"
                        };
                        Console.WriteLine(str);
                        Console.WriteLine();
                    }
                    break;

                //order book list
                case 8:
                    Console.WriteLine("Choose Option\n 1.By Name \n 2. By Price \n 3.By Id");
                    int inputChoice = int.Parse(Console.ReadLine());

                    switch (inputChoice)
                    {

                        case 1:
                            sortDelegate @delegate = new sortDelegate(sortByName);
                            listOfBooks = @delegate(listOfBooks);
                            viewBookList(listOfBooks);
                            break;
                        case 2:
                            @delegate = new sortDelegate(sortByPrice);
                            listOfBooks = @delegate(listOfBooks);
                            viewBookList(listOfBooks);
                            break;
                        case 3:
                            @delegate = new sortDelegate(sortById);
                            listOfBooks = @delegate(listOfBooks);
                            viewBookList(listOfBooks);
                            break;

                    }
                    break;

                default:
                    Console.WriteLine("Wrong Input Choice");
                    break;

            }

        }

    }

}