using BookManagementDemo;
using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Security.Cryptography;
using System.Transactions;
using System.Xml.Serialization;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookManagementDemo
{
    public class BookManager
    {
        public delegate bool bookDelegate(ref List<Book> bookRef, int num);
        public delegate void bookDelegate1(List<Book> bookRef, string keyword, List<Author> listOfAuthors);
        public delegate List<Book> sortDelegate(List<Book> listOfBooks);
        public static void generateSeedListBook(ref List<Book> listOfBooks)
        {
            listOfBooks.Add(new Book(1, "The Maverick Effect", 9, 2000, new DateTime(2020, 09, 23), 10));
            listOfBooks.Add(new Book(2, "The Architect's Apprentice", 5, 450, new DateTime(2013, 08, 23), 12));
            listOfBooks.Add(new Book(3, "The Lost Symbol", 3, 950, new DateTime(2015, 10, 2), 11));
            listOfBooks.Add(new Book(4, "The Alchemist", 7, 450, new DateTime(1998, 12, 13), 15));
            listOfBooks.Add(new Book(5, "The Art of War", 4, 100, new DateTime(2020, 09, 23), 16));
            listOfBooks.Add(new Book(6, "Time Machine", 1, 1000, new DateTime(2021, 03, 04), 17));
            listOfBooks.Add(new Book(7, "Utopia", 9, 520, new DateTime(2019, 10, 04), 18));
            listOfBooks.Add(new Book(8, "Divine Comedy", 10, 450, new DateTime(2020, 09, 23), 13));
            listOfBooks.Add(new Book(9, "Lost Letters", 4, 250, new DateTime(2004, 11, 11), 19));
            listOfBooks.Add(new Book(10, "Poems", 3, 600, new DateTime(1999, 11, 04), 14));
            listOfBooks.Add(new Book(11, "Honuor", 5, 750, new DateTime(2020, 09, 23), 12));
            listOfBooks.Add(new Book(12, "Mathnawi", 5, 650, new DateTime(2000, 02, 15), 14));
            listOfBooks.Add(new Book(13, "The Letters", 5, 850, new DateTime(2005, 05, 23), 14));

        }
        //seed list of Authors
        public static void generateAuthorsSeedList(ref List<Author> listOfAuthors)
        {
            listOfAuthors.Add(new Author(10, "Harish Mehta", 'M'));
            listOfAuthors.Add(new Author(11, "Dan Brown", 'M'));
            listOfAuthors.Add(new Author(12, "Elif Shafak", 'F'));
            listOfAuthors.Add(new Author(13, "Dante", 'M'));
            listOfAuthors.Add(new Author(14, "Rumi", 'M'));
            listOfAuthors.Add(new Author(15, "Paulo Coelho", 'M'));
            listOfAuthors.Add(new Author(16, "Sun Tzu", 'M'));
            listOfAuthors.Add(new Author(17, "H.G. Wells", 'M'));
            listOfAuthors.Add(new Author(18, "Sir Thomas Moore", 'M'));
            listOfAuthors.Add(new Author(19, "F.Scott Fitzgerald", 'M'));
        }

        public static int Menu()
        {
            int choice = 0;
            Console.WriteLine("     Choose Option: ");
            Console.WriteLine("       1. View Books List \n       2. Add Book\n       3. Update Book Information by Id\n" +
                "       4. Search Book\n       5. Delete Book\n       6. Update Book Author Information\n       7. Insert Book Author Information\n" +
                "       8. View Ordered Books List\n       0. To Exit");
            choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }
        //prints list of the books
        public static void viewBookList(List<Book> listOfBooks, List<Author> listOfAuthors)
        {
            Console.WriteLine(" {0,-20}  {1,-22} {2,-10} {3,-10} {4, -25} {5} ", "[Id]", "[Title]", "[Edition]", "[Price]", "[Date of Publishing]", "[Author Name]");

            var combineList = listOfBooks.Join(listOfAuthors,
                x => x.getAuthorID,
                y => y.getID,
                (books, authors) => new
                {
                    books.ID,
                    books.getTitle,
                    books.getEdition,
                    books.getPrice,
                    books.getDateOfPublishing,
                    authors.getName
                }).ToList();
            foreach (var book in combineList)
            {
                Console.WriteLine(" {0,-20}  {1,-26} {2,-10} {3,-10} {4,-20} {5} ", book.ID, book.getTitle, book.getEdition, book.getPrice, book.getDateOfPublishing.ToString("d"), book.getName);
            }
            Console.WriteLine();
        }
        //view Author List
        public static void viewAuthorsList(List<Author> listOfAuth)
        {
            for (int i = 0; i < listOfAuth.Count; ++i)
            {
                listOfAuth[i].printDetails();
            }
            Console.WriteLine();
        }
        //add book to the list
        public static void addBookToList(ref List<Book> listOfBooks, ref List<Author> listOfAuthors)
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
                    Console.WriteLine("Enter book Publish Date\n Enter year:");
                    int year = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter month: ");
                    int month = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter day: ");
                    int day = int.Parse(Console.ReadLine());
                    DateTime date = new DateTime(year, month, day);
                    Console.WriteLine("Enter book Author ID");
                    int authorId = Convert.ToInt32(Console.ReadLine());

                    bool authorExists = listOfAuthors.Any(x => x.getID == authorId);
                    if (authorExists)
                    {
                        Book book = new Book(id, title, ed, price, date, authorId);
                        listOfBooks.Add(book);
                        Console.WriteLine("Book Added Successfully");
                    }
                    else
                    {
                        Console.WriteLine("The author does not exist. Consider adding author first...");
                        addNewAuthor(ref listOfAuthors, authorId);
                    }

                }
                else Console.WriteLine("---Book Id already exists!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "Invalid Input Type or Null");
            }

        }
        //updates book information 
        public static bool updateBookInfoById(ref List<Book> listOfBooks, int Id)
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
        public static void searchBookByKeyword(List<Book> listOfBooks, string keyword, List<Author> listOfAuthors)
        {

            var iter = listOfBooks.FindAll(x => x.getTitle.ToLower().Contains(keyword.ToLower()));

            if (iter != null)
            {
                viewBookList(iter, listOfAuthors);

            }
            else
            {
                Console.WriteLine("No item found in the list");

            }
        }
        //remove book from the list
        public static bool removeFromListById(ref List<Book> listOfBooks, int Id)
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

        //Author Details
        public static bool updateAuthorList(ref List<Author> listOfAuthors, int AuthID)
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
        public static void addNewAuthor(ref List<Author> listOfAuthors, int id)
        {
            try
            {
                Console.WriteLine("Enter Name of Author");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Gender of the Author (M or F)");
                char gender = Convert.ToChar(Console.ReadLine());
                if (gender == 'm' || gender == 'f' || gender == 'M' || gender == 'F')
                {
                    Author author = new Author(id, name, gender);
                    listOfAuthors.Add(author);
                }
                else
                {
                    throw new Exception();
                }

            }

            catch (Exception ex)
            {
                string str = ex switch
                {
                    FormatException => "Invalid Format... Exception!",
                    ArgumentNullException => "ArgumentNullException!",
                    _ => "Invalid Inputs"
                };
                Console.WriteLine(str);
                Console.WriteLine("Unsuccessful");
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
            List<Book> listOfBooks = new List<Book>();
            generateSeedListBook(ref listOfBooks);
            List<Author> listOfAuthors = new List<Author>();
            generateAuthorsSeedList(ref listOfAuthors);
            int choice = -1;
            Console.WriteLine("***     Welcome to Book Management System       ***");
            do
            {
                choice = Menu();
                Console.WriteLine($"    You chose option {choice}");


                //switch statement for operations
                switch (choice)
                {
                    //View Booklist
                    case 1:

                        viewBookList(listOfBooks, listOfAuthors);
                        break;

                    //Add to book list
                    case 2:
                        addBookToList(ref listOfBooks, ref listOfAuthors);
                        Console.WriteLine();
                        viewBookList(listOfBooks, listOfAuthors);
                        break;

                    //Update Book Info by Id
                    case 3:
                        viewBookList(listOfBooks, listOfAuthors);
                        bool res = false;
                        Console.WriteLine("Input ID of book to update");
                        int Id = Convert.ToInt32(Console.ReadLine());
                        bookDelegate obj = new bookDelegate(ref updateBookInfoById);
                        res = obj(ref listOfBooks, Id);
                        if (res)
                        {
                            Console.WriteLine("Updated Successfully");
                            viewBookList(listOfBooks, listOfAuthors);
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
                            delegate1(listOfBooks, input, listOfAuthors);

                        }
                        else Console.WriteLine("Invalid Keyword Search ");

                        break;

                    //Remove from List by Id or Keyword
                    case 5:
                        int option = 0;
                        viewBookList(listOfBooks, listOfAuthors);

                        option = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Write Id of the Book to be Removed");
                        int bookId = Convert.ToInt32(Console.ReadLine());
                        bool res1 = false;
                        bookDelegate obj1 = new bookDelegate(removeFromListById);
                        res1 = obj1(ref listOfBooks, bookId + 1);
                        if (res1) viewBookList(listOfBooks, listOfAuthors);
                        else Console.WriteLine("No such book exists");

                        break;

                    //Update Author List
                    case 6:
                        viewAuthorsList(listOfAuthors);
                        Console.WriteLine("Enter author's id to be updated");
                        int e = Convert.ToInt32(Console.ReadLine());
                        bool result = updateAuthorList(ref listOfAuthors, e);
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
                                addNewAuthor(ref listOfAuthors, id);
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
                                viewBookList(listOfBooks, listOfAuthors);
                                break;
                            case 2:
                                @delegate = new sortDelegate(sortByPrice);
                                listOfBooks = @delegate(listOfBooks);
                                viewBookList(listOfBooks, listOfAuthors);
                                break;
                            case 3:
                                @delegate = new sortDelegate(sortById);
                                listOfBooks = @delegate(listOfBooks);
                                viewBookList(listOfBooks, listOfAuthors);
                                break;

                        }
                        break;
                    case 0:
                        Console.WriteLine("Program Exiting...");
                        break;
                    default:
                        Console.WriteLine("Wrong Input Choice\n Make another Choice or Enter 0 to Exit\n");
                        // choice = 0;
                        break;
                }

            } while (choice != 0);

        }

    }

}