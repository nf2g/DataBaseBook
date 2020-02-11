using EF.Model;
using System.ComponentModel;
using System.Data.Entity;
using System.Runtime.CompilerServices;

namespace EF.ViewModel
{
    public class ContextView : DbContext
    {
        public ContextView()
            : base("DefaultConnection")
        {
            //Books.Include(c => c.Authors).Include(c => c.Genres).Include(c => c.PublisherName).Load();
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ContextView>());
            //Database.SetInitializer<ContextView>(new ContextInitializer());
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
