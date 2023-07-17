using BookManagementDemo;

namespace BookManagementDemos
{

    public class BookManager
    {

        public static int Menu()
        {
            return 0;
        }
        //prints list of the books
        public static void viewBookList(List<Book> books)
        {


        }
        //view Author List
        public static void viewAuthorsList(List<Author> listOfAuth)
        {

        }

        //add book to the list
        public static void addBookToList(List<Book> bookref)
        {

        }

        //updates book information 
        public static bool updateBookInfoById(List<Book> listOfBooks, int Id)
        { 
            return false;
        
        }
        //Search book
        public static void searchBookByKeyword(List<Book> listOfBooks, string keyword)
        {
        
        }

        //remove book from the list
        public static bool removeFromListById(List<Book> listOfBooks, int Id)
        { 
            return true;    
        
        }

        public static void removeFromListByKeyword(List<Book> listOfBooks, string keyword)
        {
            
        }

        //Author Details
        public static bool updateAuthorList(List<Author> listOfAuthors, int AuthID)
        {
            return true;
        }

        //Main

        public static void Main()
        { 
        
        }

        }



}