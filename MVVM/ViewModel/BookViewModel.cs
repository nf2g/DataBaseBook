using EF.Controllers;
using EF.Model;
using EF.ViewModel;
using MVVM.Command;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MVVM.ViewModel
{
    class BookViewModel : INotifyPropertyChanged
    {
        #region Value
        private List<Book> viewBook;
        public List<Book> ViewBook
        {
            get => viewBook;
            set
            {
                viewBook = value;
                OnPropertyChanged();
            }
        }
        public List<Script> viewScript;
        public List<Script> ViewScript
        {
            get => viewScript;
            set
            {
                viewScript = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region function
        public BookViewModel()
        {
            using (ContextView db = new ContextView())
            {
                db.Authors.Load();
                db.Books.Load();
                db.Genres.Load();
                db.Publishers.Load();
                ViewBook = db.Books.Include(c => c.Authors).Include(c => c.Genres).Include(c => c.PublisherName).ToList();
            }
        }
        public void Dispose() { using (ContextView db = new ContextView()) db.Dispose(); }
        #endregion

        #region Commands
        //Команда сохранения
        private RelayCommand updateCommand;
        public RelayCommand UpdateCommand
        {
            get => updateCommand ??
                  (updateCommand = new RelayCommand(obj =>
                  {
                      //
                      using (var db = new ContextView())
                      {
                          //db.Configuration.AutoDetectChangesEnabled = false;
                          //db.Configuration.ValidateOnSaveEnabled = false;
                          foreach (var item in ViewBook)
                          {
                              db.Entry(item).State = EntityState.Modified;
                          }
                          //db.Configuration.AutoDetectChangesEnabled = true;
                          //db.Configuration.ValidateOnSaveEnabled = true;
                          foreach (var item in db.Authors)
                          { 
                              db.Entry(item).State = EntityState.Modified;
                          }

                          foreach (var item in db.Genres)
                          { 
                              db.Entry(item).State = EntityState.Modified;
                          }

                          foreach (var item in db.Publishers)
                          {
                              db.Entry(item).State = EntityState.Modified;
                          }

                          db.SaveChanges();
                      }
                  }));
        }
        // команда добавления нового объекта
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get => addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      //db.Configuration.AutoDetectChangesEnabled = false;
                      //db.Configuration.ValidateOnSaveEnabled = false;
                      using (ContextView db = new ContextView())
                      {
                          db.Books.Add(new Book());
                          db.SaveChanges();

                          ViewBook = db.Books.Include(c => c.Authors).Include(c => c.Genres).Include(c => c.PublisherName).ToList();
                      }

                      //db.Configuration.AutoDetectChangesEnabled = true;
                      //db.Configuration.ValidateOnSaveEnabled = true;
                  }));
        }
        // команда удаления
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get => removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      //db.Configuration.AutoDetectChangesEnabled = false;
                      //db.Configuration.ValidateOnSaveEnabled = false;
                      using (ContextView db = new ContextView())
                      {
                          int index = ViewBook[ViewBook.Count - 1].BookId;
                          db.Books.RemoveRange(db.Books.Where(c => c.BookId == index));
                          db.SaveChanges();

                          ViewBook = db.Books.Include(c => c.Authors).Include(c => c.Genres).Include(c => c.PublisherName).ToList();
                      }
                      //db.Configuration.AutoDetectChangesEnabled = true;
                      //db.Configuration.ValidateOnSaveEnabled = true;
                  },
                 (obj) => ViewBook.Count > 0));
        }

        #endregion

        #region Scripts
        private RelayCommand script1Command;
        public RelayCommand Script1Command
        {
            get => script1Command ??
                  (script1Command = new RelayCommand(obj =>
                  {
                      ViewBook = new DbBooks().Script1;
                  }));
        }

        private RelayCommand script2Command;
        public RelayCommand Script2Command
        {
            get => script2Command ??
                   (script2Command = new RelayCommand(obj =>
                   {
                       ViewBook = new DbBooks().Script2;
                   }));
        }

        private RelayCommand script3Command;
        public RelayCommand Script3Command
        {
            get => script3Command ??
                  (script3Command = new RelayCommand(obj =>
                  {
                      ViewScript = new DbBooks().Script3;
                  }));
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
