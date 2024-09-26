using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpoServiceSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
          
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            
            switch (e.Parameter.ToString())
            {
                case "BO":
                      SpoServiceSystem.Windows.WindowTipUch win = new SpoServiceSystem.Windows.WindowTipUch();
                      win.Show();
                    break;
                case "UO":
                    
                    break;

            }




            
        }
    }
}