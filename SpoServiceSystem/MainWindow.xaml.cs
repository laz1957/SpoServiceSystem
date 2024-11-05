using SpoServiceSystem.Controls;
using System.Reflection;
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
        string SystemVersion {  get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded+=MainWindow_Loaded;
            this.SizeChanged+=MainWindow_SizeChanged;
            SystemVersion = GetSystemVersion("SpoServiceSystem");
            tb01.Text = string.Format("Система контроля учебной нагрузки КАИТ № 20 (Версия {0})", SystemVersion);

        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
           /*
            Canvas.SetLeft(tb01, mainWindow.ActualWidth-400);
            Canvas.SetTop(tb01, topcomtent.ActualHeight-60);
            Canvas.SetLeft(imgKait, mainWindow.ActualWidth-130);
            Canvas.SetTop(imgKait, topcomtent.ActualHeight-200);
*/
            SetLogotip(canvas);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            
            base.OnRender(drawingContext);
            topcomtent.Height
                = mainWindow.ActualHeight-rowtop.ActualHeight-rowfutter.ActualHeight;
            rowcontext.Height = new GridLength(topcomtent.Height);
            canvas.Height = topcomtent.Height;
            canvas.Width = mainWindow.ActualWidth;

        }
      

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //  tb01.SetValue(Canvas.TopProperty, 500);
            //  tb01.SetValue(Canvas.LeftProperty, 500);
            canvas.Height=topcomtent.ActualHeight;
            SetLogotip(canvas);
            // Canvas.SetLeft(imgKait, 10);
            //  Canvas.SetTop(imgKait, 10);
        }
        void SetLogotip(Canvas canvas)
        {
            Canvas.SetLeft(tb01, canvas.ActualWidth-400);
            Canvas.SetTop(tb01, canvas.ActualHeight-60);
            Canvas.SetLeft(imgKait, canvas.ActualWidth-130);
            Canvas.SetTop(imgKait, canvas.ActualHeight-200);
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
            fe = mainWindowGrid.FindName("AllPrepodsUC");
            if (fe != null)
            {
                mainWindowGrid.Children.Remove(fe as UIElement);
                mainWindowGrid.UnregisterName("AllPrepodsUC");
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
                case "MYSQL":
                   // SpoServiceSystem.Windows.UchPlanWindow winNUPL = new SpoServiceSystem.Windows.UchPlanWindow();
                   // winNUPL.Show();
                   
                    // Настройки программы

                    Windows.ServerSettingsWindow ssw = new Windows.ServerSettingsWindow();    
                    ssw.Show();



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
                case "ALLPREPODS":
                    SpoServiceSystem.Controls.AllPrepodsUserControl allprep = new Controls.AllPrepodsUserControl();

                   
                   
                   


                    allprep.SetValue(Grid.RowProperty, 1);
                    mainWindowGrid.Children.Add(allprep);
                    mainWindowGrid.RegisterName(allprep.Name, allprep);
                    break;
                case "EXIT":
                    this.Close();
                    break;
            }




            
        }

        string GetSystemVersion(string filename)
        {
            string strversion = string.Empty;
            Assembly[] myAssemblies = Thread.GetDomain().GetAssemblies();

            foreach (Assembly assembly in myAssemblies) 
            {
                string fullname = assembly.FullName;
                if(fullname.IndexOf(filename)!=-1)
                {
                    string[] array = fullname.Split(',');
                    string[] array1 = array[1].Split('=');
                    return array1[1].Trim();
                }
            }

            return strversion;
        }

    }
}