using EF.Controllers;
using EF.Model;
using EF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    class Program
    {
        static void Main(string[] args)
        {
            DbBooks books = new DbBooks();
            books.Initializationdb();
            books.LoadAll();
            Console.WriteLine("Таблицы созданы");
            Console.ReadKey();

            //List<Book> books = temp.books;
            //List<Script> books = temp.Script3;

            //Console.WriteLine("Id\t\tКнига\t\tЖанр");
            //foreach (var i in books)
            //{
            //    Console.WriteLine("{0}\t{1}\t{2}", i.BookId, i.Name, i.GenreBooks[0].GenreName);
            //}

            //Console.ReadKey();
        }

        //Связал данные
        /*List<Author> books = db.Authors
            .Select(c => new
            {
                AuthorName = c.Name,
                Books = c.BookAuthors.Select(o => new 
                {
                    id = o.BookId,
                    BookName = o.Name
                })
            })

            .AsEnumerable()

            .Select(an => new Author
            {
                // Инициализируем экземпляр Customer из анонимного объекта
                Name = an.AuthorName,
                BookAuthors = an.Books.Select(o => new Model.Book
                {
                    BookId = o.id,
                    Name = o.BookName
                }).ToList()
            }).Where(c => c.Name == "")
            .ToList();*/

        /*List<Model.Book> books = db.Books
           .Select(c => new
           {
               id = c.BookId,
               authors = c.BookAuthors
                //.Where(q => q.Name == null)
                .Select(o => new  // вложенный анонимный объект
                {
                    AuthorName = o.Name,
                }),
                BookName = c.Name
           })
            //.Where(q => q.authors == null)
            .AsEnumerable()
            .Select(an => new Model.Book
            {
                // Инициализируем экземпляр Customer из анонимного объекта
                BookId = an.id,
                Name = an.BookName,
                BookAuthors = an.authors.Select(o => new Author
                {
                    Name = o.AuthorName,
                }).ToList()
            }).Where(q => q.BookAuthors == null)
            .ToList();*/

    }
}
