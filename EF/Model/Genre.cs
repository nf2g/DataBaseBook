using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace EF.Model
{
    public class Genre
    {
        [Key]
        public string GenreName { get; set; }

        //[Column(TypeName = "nvarchar(500)")]
        public string Description { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public Genre()
        {
            Books = new List<Book>();
        }
    }
}
