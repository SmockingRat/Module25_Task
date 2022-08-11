using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25_Task
{
    public class UserRepository
    {

        public List<User> GetAllUsers()
        {
            var users = new List<User>();

            using (var bd = new AppContext())
            {
                users = bd.Users.ToList();
            }
            return users;
        }

        public User GetUserById(int Id)
        {
            var user = new User();

            using (var bd = new AppContext())
            {
                try
                {
                    user = bd.Users.FirstOrDefault(x => x.Id == Id);
                }
                catch(ArgumentNullException)
                {

                }
            }

            return user;
        }

        public void AddUser()
        {
            using (var bd = new AppContext())
            {
                var user = new User();

                Console.WriteLine("Введите имя новой книги:");

                user.Name = CheckStringOnNull.Check();

                Console.WriteLine("Введите год выпуска книги");

                user.Email = CheckStringOnNull.Check();

                bd.Add(user);
                bd.SaveChanges();
            }

        }

        public void DeleteUserByName()
        {
            Console.WriteLine("Введите имя книги");

            var Name = CheckStringOnNull.Check();

            using (var bd = new AppContext())
            {
                try
                {
                    var user = bd.Users.FirstOrDefault(x => x.Name == Name);
                    bd.Users.Remove(user);
                    bd.SaveChanges();
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Такого пользователя в базе нет!");
                }

            }
        }

        public void UpdateUserNameById()
        {
            var user = new User();
            Console.WriteLine("Введите идентификатор пользователя");
            

            using (var bd = new AppContext())
            {
                try
                {
                    int Id = Convert.ToInt32(CheckStringOnNull.Check());
                    user = bd.Users.FirstOrDefault(x => x.Id == Id);
                    Console.Write("Введите новое имя пользователя: ");
                    string NewName = CheckStringOnNull.Check();
                    user.Name = NewName;
                    bd.SaveChanges();
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Такого пользователя нет в базе");
                }
            }
        }

        public bool HasUserBookByName()
        {
            Console.WriteLine("Введите название книги");
            var name = CheckStringOnNull.Check();

            using (var db = new AppContext())
            {
                var book = db.Users.Any(a => a.BookId.Any(f => f.Name == name));
                return book;
            }

        }

        public int CountOfBooksOfUser()
        {
            using (var db = new AppContext())
            {
                Console.WriteLine("Введите имя пользователя");
                var name = CheckStringOnNull.Check();

                var user = db.Users.FirstOrDefault(a => a.Name == name);

                var count = db.Books.Count(a => a.UserId == user.Id);

                return count;
            }
        }

    }
}
