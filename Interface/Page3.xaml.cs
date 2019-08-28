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

namespace Interface
{
    /// <summary>
    /// Logique d'interaction pour Page3.xaml
    /// </summary>
    public partial class Page3 : Window
    {
        public Page3()
        {
            InitializeComponent();
        }
        private void Button_ClickEnDur(object sender, RoutedEventArgs a)
        {
            Page4 page = new Page4();
            page.Show();
            this.Close();
            
        }
        private void Button_ClickFichier(object sender, RoutedEventArgs a)
        {
            Page5 page = new Page5();
            page.Show();
            this.Close();
        }

    }
}
