using EF.Model;
using EF.ViewModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EF.Controllers
{
    public class DbBooks
    {
        private ContextView db = new ContextView();
        public void Initializationdb() => Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ContextView>());
        public void Load(DbSet db) => db.Load();//загружает базу в кэш
        public void LoadAll()
        {
            Load(db.Books);
            Load(db.Authors);
            Load(db.Genres);
            Load(db.Publishers);
        }//загружает все базы в кэш
        public List<Book> books => db.Books
                .Include(c => c.Authors)
                .Include(c => c.Genres)
                .Include(c => c.PublisherName)
                .ToList();
        public List<Book> Script1 => db.Books
                .Include(c => c.Authors)
                .Include(c => c.Genres)
                .Where(q => q.Authors.Count == 0)
                .Select(c => new
                {
                    id = c.BookId,
                    BookName = c.Name
                })
                .AsEnumerable()
                .Select(an => new Book
                {
                    BookId = an.id,
                    Name = an.BookName
                })
                .ToList();
        public List<Book> Script2 => db.Books
                .Include(c => c.Authors)
                .Include(c => c.Genres)
                .Where(q => q.Genres.Count > 1)
                .Select(c => new
                {
                    id = c.BookId,
                    BookName = c.Name
                })
                .AsEnumerable()
                .Select(an => new Book
                {
                    BookId = an.id,
                    Name = an.BookName
                })
                .ToList();
        public List<Script> Script3
        {
            get
            {
                //List<string> scripts = new List<string>();
                var publishers = db.Publishers.Local.ToBindingList();
                var book = books;
                List<Script> scripts = new List<Script>();

                //Создаю поля издательств в новом списке
                for (int i = 0; i < publishers.Count; i++)
                {
                    scripts.Add(new Script { Издательство = publishers[i].PublisherName });
                }
                //обнуляю значения
                for (int temp = 0; temp < scripts.Count; temp++)
                {
                    scripts[temp].Роман = 0;
                    scripts[temp].ИсторическийРоман = 0;
                    scripts[temp].ПриключенческийРоман = 0;
                    scripts[temp].ПоэмаВПрозе = 0;
                    scripts[temp].Трагедия = 0;
                }

                //прохожу по названиям книг
                foreach (var i in book)
                {
                    if (i.Name != null)
                        //прохожу по названию издания
                        for (int j = 0; j < scripts.Count; j++)
                        {
                            //Если издание совпало
                            if (i.PublisherName != null)
                                if (i.PublisherName.PublisherName == scripts[j].Издательство)
                                {
                                    //Прохожусь по всем жанрам
                                    foreach (var z in i.Genres)
                                    {
                                        if (z.GenreName == "Роман") scripts[j].Роман++;
                                        if (z.GenreName == "Исторический роман") scripts[j].ИсторическийРоман++;
                                        if (z.GenreName == "Приключенческий роман") scripts[j].ПриключенческийРоман++;
                                        if (z.GenreName == "Поэма в прозе") scripts[j].ПоэмаВПрозе++;
                                        if (z.GenreName == "Трагедия") scripts[j].Трагедия++;
                                    }
                                }
                        }
                }

                return scripts;
            }
        }
        public void Save() => db.SaveChanges();
        public void Dispose() => db.Dispose();
        //Удаляет базу
        public void Delete(DbSet context)
        {
            context.RemoveRange(context);
            Save();
        }
        public void Delete(int id)
        {
            db.Books.RemoveRange(db.Books
                .Where(c => c.BookId == id));
            Save();
        }//Удаляет строку
        public void DeleteAll()
        {
            Delete(db.Authors);
            Delete(db.Books);
            Delete(db.Genres);
            Delete(db.Publishers);
            Save();
        }
        public void Add(int id)
        {
            db.Books.Add(new Book { BookId = id, Name = null, Year = null, Description = null });
            Save();
        }

        //public override void Up()
        //{
        //    CreateTable("dbo.Script", c => new
        //    {
        //        Издательство = c.String(nullable: false),
        //        Роман = c.Int(),
        //        ИсторическийРоман = c.Int(),
        //        ПриключенческийРоман = c.Int(),
        //        ПоэмаВПрозе = c.Int(),
        //        Трагедия = c.Int()
        //    })
        //    .PrimaryKey(с => с.Издательство);

        //    //DataTable script = new DataTable("Script");
        //    //DataColumn publicherName = new DataColumn("Издательство", Type.GetType("System.String"))
        //    //{
        //    //    Unique = true,
        //    //    AllowDBNull = false
        //    //};
        //    //DataColumn Роман = new DataColumn("Роман", Type.GetType("System.Int32"));
        //    //DataColumn ИсторическийРоман = new DataColumn("Исторический Роман", Type.GetType("System.Int32"));
        //    //DataColumn ПриключенческийРоман = new DataColumn("Приключенческий Роман", Type.GetType("System.Int32"));
        //    //DataColumn ПоэмаВПрозе = new DataColumn("Поэма В Прозе", Type.GetType("System.Int32"));
        //    //DataColumn Трагедия = new DataColumn("Трагедия", Type.GetType("System.Int32"));

        //    //script.Columns.Add(Роман);
        //    //script.Columns.Add(ИсторическийРоман);
        //    //script.Columns.Add(ПриключенческийРоман);
        //    //script.Columns.Add(ПоэмаВПрозе);
        //    //script.Columns.Add(Трагедия);
        //    //script.PrimaryKey = new DataColumn[] { script.Columns["Издательство"] };
        //}
    }
}
