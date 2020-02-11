using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace EF.Model
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        //[Column(TypeName = "varchar(200)")]
        public string Name { get; set; }

        //[Column(TypeName = "varchar(200)")]
        public string Description { get; set; }

        //[Column(TypeName = "varchar(4)")]
        public string Year { get; set; }

        public Publisher PublisherName { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public Book()
        {
            Authors = new List<Author>();
            Genres = new List<Genre>();
        }
    }
}
