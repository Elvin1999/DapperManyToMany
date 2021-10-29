using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToManyy.Entities
{
   public class Book
    {
        public Book()
        {
            Authors = new List<Author>();
        }
        public int BookId { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public List<Author> Authors { get; set; }
    }
}
