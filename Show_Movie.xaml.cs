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
using System.Windows.Shapes;

namespace WPF_Zad_5
{
    /// <summary>
    /// Logika interakcji dla klasy Show_Movie.xaml
    /// </summary>
    public partial class Show_Movie : Window
    {
        public bool isClosed = false;
        public Show_Movie()
        {
            InitializeComponent();
        }

        private void Kill_Windows(object sender, EventArgs e)
        {
            isClosed = true;
        }
    }
}
