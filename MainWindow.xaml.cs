using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using System.Windows.Forms;

namespace WPF_Zad_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Film> Films = new List<Film>();
        Show_Movie show;
        public MainWindow()
        {
            InitializeComponent();
            updataList();
        }

        private void Add_Movie(object sender, RoutedEventArgs e)
        {
            Add add = new Add();
            // if(
            if(add.ShowDialog()==true)
            {
                Films.Add(new Film(add.Title.Text, (DateTime)add.Time.SelectedDate, add.Desc.Text));
            }
            updataList();
        }

        private void Edit_Movie(object sender, RoutedEventArgs e)
        {
            if(Lista.SelectedIndex>=0)
            {
                Add edit = new Add();
                Film film = Films[Lista.SelectedIndex];
                edit.Title.Text = film.Title;
                edit.Time.SelectedDate = film.Date;
                edit.Desc.Text = film.Desc;
                if(edit.ShowDialog()==true)
                {
                    film.Title = edit.Title.Text; film.Date = (DateTime)edit.Time.SelectedDate; film.Desc = edit.Desc.Text;
                }
                updataList();
            }
        }

        private void Delete_Movie(object sender, RoutedEventArgs e)
        {
            if(Lista.SelectedIndex>=0)
            {
                if (MessageBox.Show("Czy na pewno chcesz usunąć wskazany element?", "Usuń Element", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
                    return;
                Films.RemoveAt(Lista.SelectedIndex);

                updataList();
            }
            
        }
        private void updataList()
        {
            Lista.Items.Clear();
            foreach(Film film in Films)
            {
                Lista.Items.Add(film.ToString());
            }
            if(Lista.Items.Count<=0)
            {
                b1.IsEnabled = false;
                b2.IsEnabled = false;
                b3.IsEnabled = false;
            }
            else
            {
                b1.IsEnabled = true;
                b2.IsEnabled = true;
                b3.IsEnabled = true;
                Check_Lagalyty_of_Buttons();
            }
        }

        private void Show_Movie(object sender, RoutedEventArgs e)
        {
            if(show!=null && show.isClosed)
            {
                show = null;
            }
            if(show==null)
            {
                show = new Show_Movie();
                show.Show();
                Change_In_Show();
            }

            
        }
        private void Change_In_Show()
        {
            if(show!=null)
            {
                if(Lista.SelectedIndex >= 0)
                {
                    show.Title.Content = Films[Lista.SelectedIndex].Title;
                    show.Time.Content = Films[Lista.SelectedIndex].Date.ToString();
                    show.Desc.Content = Films[Lista.SelectedIndex].Desc.ToString();

                }
            }
        }
        private void Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Change_In_Show();
            Check_Lagalyty_of_Buttons();
        }

        private void Check_Lagalyty_of_Buttons()
        {
            if (!(Lista.SelectedIndex >= 0))
            {
                b1.IsEnabled = false;
                b2.IsEnabled = false;
                b3.IsEnabled = false;
            }
            else
            {
                b1.IsEnabled = true;
                b2.IsEnabled = true;
                b3.IsEnabled = true;
            }
        }
    }
}
