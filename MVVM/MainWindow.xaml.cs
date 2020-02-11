using EF.Controllers;
using EF.ViewModel;
using MVVM.ViewModel;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace MVVM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += MainWindow_Closing;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new BookViewModel();
            BooksGrid.Visibility = Visibility.Hidden;
            AuthorGrid.Visibility = Visibility.Hidden;

            UpdateButton.Visibility = Visibility.Collapsed;
            AddButton.Visibility = Visibility.Collapsed;
            RemoveButton.Visibility = Visibility.Collapsed;
            ClearButton.Visibility = Visibility.Collapsed;

            Script1Button.Visibility = Visibility.Hidden;
            Script2Button.Visibility = Visibility.Hidden;
            Script3Button.Visibility = Visibility.Hidden;
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            new BookViewModel().Dispose();
        }
        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new BookViewModel();

            UpdateButton.Visibility = Visibility.Visible;
            AddButton.Visibility = Visibility.Visible;
            RemoveButton.Visibility = Visibility.Visible;
            ClearButton.Visibility = Visibility.Visible;

            Script1Button.Visibility = Visibility.Visible;
            Script2Button.Visibility = Visibility.Visible;
            Script3Button.Visibility = Visibility.Visible;

            BooksGrid.Visibility = Visibility.Hidden;
            AuthorGrid.Visibility = Visibility.Visible;
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = null;

            BooksGrid.Visibility = Visibility.Hidden;
            AuthorGrid.Visibility = Visibility.Hidden;

            UpdateButton.Visibility = Visibility.Collapsed;
            AddButton.Visibility = Visibility.Collapsed;
            RemoveButton.Visibility = Visibility.Collapsed;
            ClearButton.Visibility = Visibility.Collapsed;

            Script1Button.Visibility = Visibility.Hidden;
            Script2Button.Visibility = Visibility.Hidden;
            Script3Button.Visibility = Visibility.Hidden;
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateButton.Visibility = Visibility.Collapsed;
            AddButton.Visibility = Visibility.Collapsed;
            RemoveButton.Visibility = Visibility.Collapsed;

            BooksGrid.Visibility = Visibility.Hidden;

        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            UpdateButton.Visibility = Visibility.Collapsed;
            AddButton.Visibility = Visibility.Collapsed;
            RemoveButton.Visibility = Visibility.Collapsed;

            BooksGrid.Visibility = Visibility.Visible;
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        { 
        }
    }
    /*public class ItemsToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var items = value as IEnumerable;
            if (items != null)
            {
                // note: items may contain the InsertRow item, which is of different type than the existing items.
                // so the items collection needs to be filtered for existing items before casting and reading the property
                var items2 = items.Cast<object>();
                //var items3 = items2.Where(x => x is MyItemType).Cast<MyItemType>();
                return string.Empty;
                //return string.Join(Environment.NewLine, items3.Select(x => x.UNIQUEPART_ID));
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException();
        }
    }*/
}
