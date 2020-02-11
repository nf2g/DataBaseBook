using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace EF.Model
{
    public class Publisher
    {
        [Key]
        public string PublisherName { get; set; }

        //[Column(TypeName = "nvarchar(200)")]
        public string Adress { get; set; }

        //[Column(TypeName = "nvarchar(200)")]
        public string Email { get; set; }

        //[Column(TypeName = "nvarcharr(50)")]
        public string Phone { get; set; }

        public ICollection<Book> Books { get; set; }
        public Publisher()
        {
            Books = new List<Book>();
        }
    }
}
