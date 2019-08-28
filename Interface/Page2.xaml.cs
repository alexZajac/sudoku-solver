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
    /// Logique d'interaction pour Page2.xaml
    /// </summary>
    public partial class Page2 : Window
    {
        public bool choix;
        public Page2()
        {
            InitializeComponent();
        }

        private void Button_ClickNaïve(object sender, RoutedEventArgs a)
        {
            Page3 page = new Page3();
            page.Show();
            this.Close();
            choix = true;
        }
        private void Button_ClickRecursif(object sender, RoutedEventArgs a)
        {
            Page3 page = new Page3();
            page.Show();
            this.Close();
            choix = false;
        }
        

    }
}
