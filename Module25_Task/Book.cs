using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25_Task
{
    public class Book
    {
        public int Id { get; set; }
        public string Name {get; set;}
        public int Release_Year {get; set;}
        public int UserId {get; set;}
        public User User {get; set;}

        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

    }
}
