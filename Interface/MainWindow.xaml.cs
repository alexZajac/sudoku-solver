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

namespace Interface
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [STAThread]
        static void Main(string[] args)
        {
            Interface.App app = new Interface.App();
            app.InitializeComponent();
            app.Run();
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grille_BoutonSourisGauche(object sender, RoutedEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Clic(object sender, RoutedEventArgs a)
        {
            Page2 page = new Page2();
            page.Show();
            this.Close();
        }


        
    }
}
