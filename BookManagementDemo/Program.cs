using BookManagementDemo;

namespace BookManagementDemos
{

    public class BookManager
    {
        public delegate bool bookDelegate(List<Book> bookRef, int num);
        public delegate void bookDelegate1(List<Book> bookRef, string keyword);
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
            choice = Convert.ToInt32(Console.ReadLine());

            return choice;
            
        }
        //prints list of the books
        public static void viewBookList(List<Book> listOfBooks)
        {
            Console.WriteLine(" {0,-20}  {1,-20} {2,-10} {3,-10} {4:-30} {5,20} ", "Id", "Title", "Edition", "Price", "Date of Publishing", "  Author");
            for (int i = 0; i < listOfBooks.Count - 1; ++i)
            {
                listOfBooks[i].printList();
            }

        }
        //view Author List
        public static void viewAuthorsList(List<Author> listOfAuth)
        {
            for (int i = 0; i < listOfAuth.Count - 1; ++i)
            {
                listOfAuth[i].printDetails();
            }
        }

        //add book to the list
        public static void addBookToList(List<Book> bookref)
        {
            Console.WriteLine("Enter book id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter book Title");
            string title = Console.ReadLine();
            Console.WriteLine("Enter book Edition");
            int ed = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter book Price");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter book Publish Date");
            string date = Console.ReadLine();
            Console.WriteLine("Enter book Author");
            string author = Console.ReadLine();
            Console.WriteLine("Enter book Author ID");
            int authorId = Convert.ToInt32(Console.ReadLine());

            Book book = new Book(id, title, ed, price, date, author, authorId);
            bookref.Add(book);
        }

        //updates book information 
        public static bool updateBookInfoById(List<Book> listOfBooks, int Id)
        {
            Console.WriteLine("Enter book's new Title");
            string title = Console.ReadLine();
            Console.WriteLine("Enter book's new Edition");
            int ed = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter book's new Price");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter book's new Publish Date");
            string date = Console.ReadLine();
            Console.WriteLine("Enter book's new Author");
            string author = Console.ReadLine();
            Console.WriteLine("Enter book Author ID");
            int authorId = Convert.ToInt32(Console.ReadLine());

            //var result =.ToList();
            foreach (var iter in listOfBooks.Where(x => x.Id == Id))
            {
                iter.Title = title;
                iter.Edition = ed;
                iter.Price = price;
                iter.dateOfPublishing = date;
                iter.bookAuthor = author;
                iter.authorID = authorId;

                return true;
            }

            return false;
            
        
        }
        //Search book
        public static void searchBookByKeyword(List<Book> listOfBooks, string keyword)
        {
            var iter = listOfBooks.FindAll(x => x.Title.ToLower().Contains(keyword));

            if (iter != null)
            {
                Console.WriteLine(" {0,-20}  {1,-20} {2,-10} {3,-10} {4:-30} {5,25}", "Id", "Title", "Edition", "Price", "Date of Publishing", "  Author");
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
                if (listOfBooks[i].Id == Id)
                {
                    listOfBooks.RemoveAt(i);
                    return true;
                }
            }
            return false;

        }

        public static void removeFromListByKeyword(List<Book> listOfBooks, string keyword)
        {
            listOfBooks.RemoveAll(x => x.Title.ToLower().Contains(keyword));
        }

        //Author Details
        public static bool updateAuthorList(List<Author> listOfAuthors, int AuthID)
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

            return false;
        }

        //Main

        public static void Main()
        {
            List<Book> listOfBooks = new List<Book>() {
             new Book(1, "The Maverick Effect", 9, 450, "Date","Harish Mehta"),
             new Book(2, "The Architect's Apprentice", 5, 450, "Date", "Elif Shafak"),
             new Book(3, "The Lost Symbol", 3, 450, "Date","Dan Brown"),
             new Book(4, "The Alchemist", 7, 450, "Date", "Paulo Coelho"),
             new Book(5, "The Art of War", 4, 450, "Date", "Sun Tzu"),
             new Book(6, "Time Machine", 1, 450, "Date","H.G. Wells"),
             new Book(7, "Utopia", 9, 450, "Date","Sir Thomas Moore"),
             new Book(8, "Divine Comedy", 10, 450, "Date","Dante"),
             new Book(9, "Lost Letters", 4, 450, "Date","F.Scott Fitzgerald"),
             new Book(10, "Poems", 3, 450, "Date","Rumi"),
             new Book(11, "Honuor", 5, 450, "Date", "Elif Shafak"),
             new Book(12, "Mathnawi", 5, 450, "Date", "Rumi"),
             new Book(13, "The Letters", 5, 450, "Date", "Rumi")
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

                default:
                    Console.WriteLine("Wrong Input Choice");
                    break;

            }





        }
    }

    
    
    
    
}

