using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25_Task
{
    public class BookRepositopy
    {

        public List<Book> GetAllBooks()
        {
            var books = new List<Book>();

            using (var bd = new AppContext())
            {
                books = bd.Books.ToList();
            }
            return books;
        }

        public Book GetBookById(int Id)
        {
            var book = new Book();

            using (var bd = new AppContext())
            {
                book = bd.Books.FirstOrDefault(x => x.Id == Id);
            }

            return book;
        }

        public void AddBook()
        {
            using (var bd = new AppContext())
            {
                var book = new Book();

                Console.WriteLine("Введите имя новой книги:");

                book.Name = CheckStringOnNull.Check();

                Console.WriteLine("Введите год выпуска книги");

                book.Release_Year = Convert.ToInt32(CheckStringOnNull.Check());

                bd.Add(book);
                bd.SaveChanges();
            }

        }

        public void DeleteBookByTitle()
        {
            Console.WriteLine("Введите имя книги");

            var Name = CheckStringOnNull.Check();

            using (var bd = new AppContext())
            {
                try
                {
                    var book = bd.Books.FirstOrDefault(x => x.Name == Name);
                    bd.Books.Remove(book);
                    bd.SaveChanges();
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Книги с таким названием нет в базе!");
                }
            }
        }

        public void UpdateBookTitleById()
        {
            var book = new Book();
            Console.WriteLine("Введите идентификатор книги");


            using (var bd = new AppContext())
            {
                try
                {
                    int Id = Convert.ToInt32(CheckStringOnNull.Check());
                    book = bd.Books.FirstOrDefault(x => x.Id == Id);
                    Console.Write("Введите новое имя пользователя: ");
                    string NewName = CheckStringOnNull.Check();
                    book.Name = NewName;
                    bd.SaveChanges();
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Такой книги нет в базе");
                }
            }
        }

        public void GetBookByGenreAndDate()
        {
            using (var db = new AppContext())
            {
                Console.WriteLine("\nВведите жанр книги");
                string genre = CheckStringOnNull.Check();

                int date1 = 0;
                int date2 = 0;

                try
                {
                    Console.WriteLine("Введите временные рамки выхода книги\nДата 1 ");
                    date1 = Convert.ToInt32(CheckStringOnNull.Check());

                    Console.WriteLine("Дата 2");
                    date2 = Convert.ToInt32(CheckStringOnNull.Check());
                }
                catch
                {
                    Console.WriteLine("Неправиьные данные времени");
                }

                var books = db.Books.Where(a => a.Genre.Name == genre).Where(a => a.Release_Year >= date1 & a.Release_Year <= date2).ToList();

                foreach (var book in books)
                    Console.WriteLine(book.Name);
            }
              
        }

        public void GetCountOfBooksByAuthor()
        {
            Console.WriteLine("Введите автора книги");
            string name = CheckStringOnNull.Check();

            using (var db = new AppContext())
            {
                var books = db.Books.Where(a => a.Author.Name == name).Count();
                Console.WriteLine(books);   
            }
        }

        public void GetCountOfBooksByGenre()
        {
            Console.WriteLine("Введите автора книги");
            string genre = CheckStringOnNull.Check();

            using (var db = new AppContext())
            {
                var books = db.Books.Where(a => a.Genre.Name == genre).Count();
                Console.WriteLine(books);
            }
        }


        public bool IsThereBookByAuthorAndName()
        {
            Console.WriteLine("Введите автора книги");
            string name = CheckStringOnNull.Check();

            Console.WriteLine("Введите название книги");
            string title = CheckStringOnNull.Check();

            using (var db = new AppContext())
            {
                var books = db.Books.Any(a => a.Name == title & a.Author.Name == name);
                return books;
            }
        }


    }
}