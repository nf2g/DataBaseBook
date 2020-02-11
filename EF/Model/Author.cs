using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace EF.Model
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        //[Column(TypeName = "varchar(200)")]
        public string SurName { get; set; }

        //[Column(TypeName = "varchar(200)")]
        public string Name { get; set; }

        //[Column(TypeName = "varchar(200)")]
        public string MiddleName { get; set; }

        //Вопрос указывает что поле может быть Null
        [Column(TypeName = "Date")]
        public DateTime? Birthday { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public Author()
        {
            Books = new List<Book>();
        }
    }
}
