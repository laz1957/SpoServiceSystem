using Microsoft.Win32;
using MySql.Data.MySqlClient;
using SpoServiceSystem.Controls;
using SpoServiceSystem.DataModels;
using SpoServiceSystem.Windows;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace SpoServiceSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static RoutedCommand route_command = new RoutedCommand();
        MessageWindow messageWindow;
        string SystemVersion {  get; set; }
       
        public MainWindow()
        {
            InitializeComponent();
            
            GenerateMenuItemsUchPlanes(ListUP_MenuItem,0);
            GenerateMenuItemsUchPlanes(ListUP_MenuItem2, 1);
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
            fe = mainWindowGrid.FindName("uchPlansUserControl");
            if (fe != null)
            {
                mainWindowGrid.Children.Remove(fe as UIElement);
                mainWindowGrid.UnregisterName("uchPlansUserControl");
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
                    //  SpoServiceSystem.Windows.ShablonPlanWindow winSHUP = new SpoServiceSystem.Windows.ShablonPlanWindow();
                    //  winSHUP.Show();
                    MessageBox.Show("Операция временно заблокирована!");
                    break;
                case "MYSQL":
                   // SpoServiceSystem.Windows.UchPlanWindow winNUPL = new SpoServiceSystem.Windows.UchPlanWindow();
                   // winNUPL.Show();
                   
                    // Настройки программы

                    Windows.ServerSettingsWindow ssw = new Windows.ServerSettingsWindow();    
                    ssw.Show();



                    break;
                case "UGR":
                     messageWindow = new MessageWindow("Загрузка данных! Ждите...");
                     messageWindow.Show();

                    BackgroundWorker bgWorker = new BackgroundWorker();
                    bgWorker.DoWork+=BgWorker_DoWork;
                    bgWorker.RunWorkerCompleted+=BgWorker_RunWorkerCompleted;
                    bgWorker.RunWorkerAsync();
                  /*
                    SpoServiceSystem.Controls.AllGroupsUserControl aguc = new Controls.AllGroupsUserControl();
                    aguc.Loaded+=Aguc_Loaded;
                    aguc.Name="allGroupsViewControl";
                    aguc.SetValue(Grid.RowProperty, 1);
                    mainWindowGrid.Children.Add(aguc);
                    mainWindowGrid.RegisterName("allGroupsViewControl", aguc);
                  */

                    GroupsPrepsUPlanEditorWindow gpupeditor = new GroupsPrepsUPlanEditorWindow();
                    gpupeditor.Show();

                    break;
                case "ALLPREPODS":
                    SpoServiceSystem.Controls.AllPrepodsUserControl allprep = new Controls.AllPrepodsUserControl();
                    allprep.SetValue(Grid.RowProperty, 1);
                    mainWindowGrid.Children.Add(allprep);
                    mainWindowGrid.RegisterName(allprep.Name, allprep);
                    break;
                case "UCHPLANS":
                    Controls.UchPlansUserControl upControl = new UchPlansUserControl();
                    upControl.SetValue(Grid.RowProperty, 1);
                    mainWindowGrid.Children.Add(upControl);
                    mainWindowGrid.RegisterName(upControl.Name, upControl);
                    break;
                case "RASP":
                    MessageWindow mw = new MessageWindow("Выполняется загрузка данных! Ждите...");
                    mw.Show();
                      SpoServiceSystem.Windows.DataFromRaspWindow winSHUP = new SpoServiceSystem.Windows.DataFromRaspWindow();
                      winSHUP.Show();
                 //   MessageBox.Show("Операция временно заблокирована!");
                    break;

                case "BACKUPBD":
                    // MessageBox.Show("Раздел в стадии разработки !!!");
                    BackupBasaToFile();
                    break;
                case "RESTOREBD":
                    MessageBox.Show("Раздел в стадии разработки !!!");
                    break;
                case "WEEKCOUNT":

                    SpoServiceSystem.Windows.WeeksGroupsWindow winWeek = new SpoServiceSystem.Windows.WeeksGroupsWindow();
                    winWeek.Show();
                    
                    break;
                case "EXIT":
                    this.Close();
                    break;
            }




            
        }

        private void BgWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        private void BgWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
        
            
           
        }

        private void Aguc_Loaded(object sender, RoutedEventArgs e)
        {
              messageWindow.Close();
            messageaTB.Text="";

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


        void GenerateMenuItemsUchPlanes(MenuItem targetMenuItem,int variant)
        {
            DataModels.ListSpecialnost listSP = new DataModels.ListSpecialnost();
            DataModels.Kurses listKurses = new DataModels.Kurses();

            foreach(DataModels.Specialnost specialnost in listSP) {
                MenuItem menuItem = new MenuItem();
                menuItem.Header=specialnost.FullName;
                if (variant==0)
                    foreach (DataModels.Kurs kurs in listKurses)
                    {
                        MenuItem mItem = new MenuItem();
                        mItem.Header=kurs.Name;
                        DataModels.KursSpecialnost ks = new DataModels.KursSpecialnost();
                        ks.kurs = kurs;
                        ks.specialnost = specialnost;
                        mItem.DataContext = ks;
                        mItem.Click += MItem_Click;
                        menuItem.Items.Add(mItem);
                    }
                else
                {
                    menuItem.Click +=MenuItem_Click;
                    menuItem.DataContext=specialnost;
                }

                targetMenuItem.Items.Add(menuItem);

            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            DataModels.Specialnost spec = (sender as FrameworkElement).DataContext as DataModels.Specialnost;   
            AllKursesUchPlansWindow window = new AllKursesUchPlansWindow(spec);
            window.Show();
        }

        private void MItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            DataModels.KursSpecialnost ks = menuItem.DataContext as DataModels.KursSpecialnost; 
            int idSpec = ks.specialnost.Id;
            int kurs = ks.kurs.Id;
            UchebPlanView window = new UchebPlanView(idSpec,kurs);
            window.Show();
        }

        private void BackupBasaToFile()
        {
            SaveFileDialog sfBackup = new SaveFileDialog();
            sfBackup.Filter = "sql files (*.sql)|*.sql|All files (*.*)|*.*";
            sfBackup.RestoreDirectory = true;
            sfBackup.InitialDirectory= System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filename0 = string.Format("DataBackup от {0}.sql", DateTime.Now.ToShortDateString().Replace('.','_'));
            sfBackup.FileName = filename0;
            if (sfBackup.ShowDialog() == true)
            {
                string filename = "" + sfBackup.FileName + "";
                BazaSoft bSoft = new BazaSoft();
                using (MySqlConnection cn = new MySqlConnection(bSoft.MySqlConnectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {

                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = cn;
                            cn.Open();
                            mb.ExportToFile(filename);
                            cn.Close();

                        }

                    }
                }
                try
                {
                    bool backupResult = true;
                    if (backupResult == true)
                    {
                        MessageBox.Show("Сохранение базы данных выполнено!", "Sukses", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        MessageBox.Show("Gagal Backup Database!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                catch (SystemException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public static void importDataBase()
        {
            try
            {
                // On demande le fichier à l'utilisateur
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Rechercher un fichier";
                openFileDialog1.FileName = "backup_gestionstock.sql";
                openFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog1.Filter = "SQL files (*.sql)|*.sql|All files (*.*)|*.*";
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == true)
                {
                    try
                    {
                        // On affecte le chemin de l'utilisateur et son fichier puis on utilise le fichier pour la restauration
                        string fileimport = openFileDialog1.FileName;
                        BazaSoft bazaSoft = new BazaSoft();
                        // On définit les variables
                        MySqlCommand cmdimport = new MySqlCommand();
                        MySqlBackup mbimport = new MySqlBackup(cmdimport);

                        // On ouvre la connexion, utilise la fonction du package et on ferme la connexion
                        cmdimport.Connection = new MySqlConnection(bazaSoft.MySqlConnectionString);
                        cmdimport.Connection.Open();
                       
                        mbimport.ImportFromFile(fileimport);
                        cmdimport.Connection.Close();
                        MessageBox.Show("Base de données importée." + Environment.NewLine + "A partir du fichier situé dans le chemin : " + fileimport);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de lire le fichier à partir du disque. Erreur: " + ex.Message);
            }
        }
    }
}