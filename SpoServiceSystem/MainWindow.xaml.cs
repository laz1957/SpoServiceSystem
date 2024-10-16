using SpoServiceSystem.Controls;
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

            object fe = mainWindowGrid.FindName("allGroupsViewControl");
            if (fe != null)
            {
                mainWindowGrid.Children.Remove(fe as UIElement);
                mainWindowGrid.UnregisterName("allGroupsViewControl");
            }
            switch (e.Parameter.ToString())
            {
                case "KF":
                      SpoServiceSystem.Windows.KvalificationsWindow win = new SpoServiceSystem.Windows.KvalificationsWindow();
                      win.Show();
                   
                    break;
                case "UO":
                    SpoServiceSystem.Windows.UchOtdWindow winUO = new Windows.UchOtdWindow();
                    winUO.Show();
                    break;
                case "SP":
                    SpoServiceSystem.Windows.SpecEditorWindow winSP = new Windows.SpecEditorWindow();
                    winSP.Show();
                    break;
                case "PR":
                    SpoServiceSystem.Windows.PrepodsWindow winPR = new SpoServiceSystem.Windows.PrepodsWindow();
                    winPR.Show();
                    break;
                case "GR":
                    SpoServiceSystem.Windows.GroupsWindow winGR = new SpoServiceSystem.Windows.GroupsWindow();
                    winGR.Show();
                    break;
                case "PO":
                    SpoServiceSystem.Windows.PredmetsWindow winPO = new SpoServiceSystem.Windows.PredmetsWindow();
                    winPO.Show();
                    break;
                case "SHUP":
                    SpoServiceSystem.Windows.ShablonPlanWindow winSHUP = new SpoServiceSystem.Windows.ShablonPlanWindow();
                    winSHUP.Show();
                    break;
                case "NUPL":
                    SpoServiceSystem.Windows.UchPlanWindow winNUPL = new SpoServiceSystem.Windows.UchPlanWindow();
                    winNUPL.Show();
                    break;
                case "UGR":
                    SpoServiceSystem.Controls.AllGroupsUserControl aguc = new Controls.AllGroupsUserControl();
                    aguc.Name="allGroupsViewControl";
                    // =this.Content = aguc;
                    //mainWindowGrid.Background=null;
                    aguc.SetValue(Grid.RowProperty, 1);
                    mainWindowGrid.Children.Add(aguc);
                    mainWindowGrid.RegisterName("allGroupsViewControl", aguc);
                    break;
            }




            
        }
    }
}