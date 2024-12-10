using MySql.Data.MySqlClient;
using SpoServiceSystem.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace SpoServiceSystem.Windows
{
    /// <summary>
    /// Логика взаимодействия для DataFromRaspWindow.xaml
    /// </summary>
    
    public partial class DataFromRaspWindow : Window
    {
        private static void OnValueChanded1(DependencyObject d,
                                                      DependencyPropertyChangedEventArgs e)
        {
            if (d == null || e.NewValue == null)
            {
                return;
            }

           
        }
        private static void OnValueChanded(DependencyObject d,
                                                       DependencyPropertyChangedEventArgs e)
        {
            if (d == null || e.NewValue == null)
            {
                return;
            }

            DataGrid dg = (d as DataFromRaspWindow).BG.FindName("datagrid") as DataGrid;
            DataTable dt = (dg.ItemsSource as DataView).Table;
            Group group = (d as DataFromRaspWindow).CurrentGroup;
            if (e.Property.Name =="Weeks1")
            {
                foreach (DataRow r in dt.Rows.OfType<DataRow>().Where(dr => dr.Field<int>("id_group")==group.Id))
                {
                       r["semestr1"] = e.NewValue;
                }
            }
            if (e.Property.Name =="Weeks2")
            {
                foreach (DataRow r in dt.Rows.OfType<DataRow>().Where(dr => dr.Field<int>("id_group")==group.Id))
                {
                    r["semestr2"] = e.NewValue;
                }
            }
            (d as DataFromRaspWindow).RaschetItogov();
            dt.AcceptChanges();
            (d as DataFromRaspWindow).messagesTB.Text="Данные изменены!";
        }




        public static readonly DependencyProperty Summa1Property;
        public static readonly DependencyProperty Summa2Property;
        public static readonly DependencyProperty Weeks1Property;
        public static readonly DependencyProperty Weeks2Property;
        public static readonly DependencyProperty MaxHoursWeekProperty;
        static DataFromRaspWindow()
        {
            Summa1Property = DependencyProperty.Register("Summa1", typeof(float), typeof(DataFromRaspWindow));
            Summa2Property = DependencyProperty.Register("Summa2", typeof(float), typeof(DataFromRaspWindow));
            Weeks1Property = DependencyProperty.Register("Weeks1", typeof(int), typeof(DataFromRaspWindow), new UIPropertyMetadata(0, OnValueChanded));
            Weeks2Property = DependencyProperty.Register("Weeks2", typeof(int), typeof(DataFromRaspWindow), new UIPropertyMetadata(0, OnValueChanded));
            MaxHoursWeekProperty = DependencyProperty.Register("MaxHoursWeek", typeof(int), typeof(DataFromRaspWindow), new UIPropertyMetadata(36, OnValueChanded1));
        }

        CollectionView viewGroups;
        public Group CurrentGroup { get; set; }

        NagruzkaFullData nagruzkaFullData;
        public static event EventHandler loadingDelegat;
        DataModels.BazaSoft basaSoft;
        DataView ViewModel;
        DataTable dataTable;

        public float Summa1
        {
            get { return (float)GetValue(Summa1Property); }
            set { SetValue(Summa1Property, value); }
        }
        public float Summa2
        {
            get { return (float)GetValue(Summa2Property); }
            set { SetValue(Summa2Property, value); }
        }
        public int Weeks1
        {
            get { return (int)GetValue(Weeks1Property); }
            set { SetValue(Weeks1Property, value);  }
        }
        public int Weeks2
        {
            get { return (int)GetValue(Weeks2Property); }
            set { SetValue(Weeks2Property, value); }
        }
        public int MaxHoursWeek
        {
            get { return (int)GetValue(MaxHoursWeekProperty); }
            set { SetValue(MaxHoursWeekProperty, value); }
        }
        public DataFromRaspWindow()
        {
            InitializeComponent();
            this.SizeChanged+=DataFromRaspWindow_SizeChanged;
            this.Loaded+=DataFromRaspWindow_Loaded;
            viewGroups = (CollectionView)CollectionViewSource.GetDefaultView(groupLB.ItemsSource);
            viewGroups.Filter = GroupsFilter;
            nagruzkaFullData = new NagruzkaFullData();
            basaSoft = new BazaSoft();


        }

        private void DataFromRaspWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (loadingDelegat != null)
            {
                EventHandler handler = loadingDelegat;
                handler?.Invoke(this, e);
            }
            RaschetItogov();
        }

        bool GroupsFilter(object item)
        {
            Predicate<Group> isnull = (Group p) => { return true; };
            Predicate<Group> spec = (Group p) => { return true; };
            Predicate<Group> kurs = (Group p) => { return true; };
            Predicate<Group> otdelenie = (Group p) => { return true; };
            Predicate<Group> yesPlab = (Group p) => { return true; };
            Predicate<Group>? fullfilter = (Group p) => { return true; }; ;
            Group gr = item as Group;

         //   if (yesRB.IsChecked.Value) yesPlab =new Predicate<Group>((g) => ((Group)g).groupPlanInfo.Count >0);
         //   if (noRB.IsChecked.Value) yesPlab =new Predicate<Group>((g) => ((Group)g).groupPlanInfo.Count <=0);

            if ((specCB.SelectedItem != null)) spec = new Predicate<Group>((g) => ((Group)g).Id_sp ==(specCB.SelectedItem as Specialnost).Id);
         
            if (kursesCB.SelectedItem != null) kurs +=new Predicate<Group>((g) => ((Group)g).Kurs ==(kursesCB.SelectedItem as Kurs).Id);
            return spec(gr) && kurs(gr) ;





        }

        private void DataFromRaspWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            scrollView01.Height = nav_pnl.ActualHeight-60;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void dockpanel001_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void nav_pnl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void groupLB_Loaded(object sender, RoutedEventArgs e)
        {
            scrollView01.Height = nav_pnl.ActualHeight-60;
        }

        private void kursesCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(groupLB.ItemsSource).Refresh();
        }

        private void specCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(groupLB.ItemsSource).Refresh();
        }

        private void sbrosSpec_Click(object sender, RoutedEventArgs e)
        {
            specCB.SelectedItem= null;
        }

        private void sbposKurs_Click(object sender, RoutedEventArgs e)
        {
            kursesCB.SelectedItem = null;
        }

       
        private void groupLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Group group = (sender as ListBox).SelectedItem as Group;
            if (group != null)
            {
                datagrid.ItemsSource = nagruzkaFullData.GetData();
                CurrentGroup = group;
                groupnameTB.Text = CurrentGroup.NameGroup;
                (datagrid.ItemsSource as DataView).RowFilter ="id_group="+group.Id.ToString();
                RaschetItogov();
            }
        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RaschetItogov();
            CollectionViewSource.GetDefaultView(datagrid.ItemsSource).Refresh();

        }


        public void RaschetItogov()
        {

            Summa1=0;
            Summa2=0;
           if(datagrid.ItemsSource != null)
            foreach (DataRow r in (datagrid.ItemsSource as DataView).Table.Rows.OfType<DataRow>().Where(dr => dr.Field<int>("id_group")==CurrentGroup.Id))
            {


                    if ((bool)r["YesSumma"])
                    {
                        Summa1+=float.Parse(r["weeksem1"].ToString());
                        Summa2+=float.Parse(r["weeksem2"].ToString());
                    }
               
            }
          
        }

        private void datagrid_SourceUpdated(object sender, DataTransferEventArgs e)
        {
           // RaschetItogov();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            string SqlString = "UPDATE  count_weeks_groups SET " +
                               "semestr1={0},semestr2={1}" +
                               " WHERE id_group={2}";
            if(Weeks1 <=0 || Weeks2 <=0 || CurrentGroup == null)
            {
                MessageBox.Show("Данные для сохранения не достоверны !!!");
                return;
            }
            string UpdateString = string.Format(SqlString, Weeks1, Weeks2,CurrentGroup.Id);

            int n = -1;
            try
            {
               
                
                    using (MySqlConnection conn = new MySqlConnection(basaSoft.MySqlConnectionString))
                    {
                        conn.Open();
                        MySqlCommand com = new MySqlCommand(UpdateString, conn);
                        com.ExecuteScalar();
                        conn.Close();
                        this.messagesTB.Text = "[...]";
                    }
                
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }

        }

        private void datagrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if(e.EditAction == DataGridEditAction.Commit)
            {
               
            }
        }

        private void calckBtn_Click(object sender, RoutedEventArgs e)
        {
            RaschetItogov();
        }

        private void initDatakBtn_Click(object sender, RoutedEventArgs e)
        {
            
            
            float S1=0;
            float S2=0;
            if (datagrid.ItemsSource != null)
                foreach (DataRow r in (datagrid.ItemsSource as DataView).Table.Rows.OfType<DataRow>().Where(dr => dr.Field<int>("id_group")==CurrentGroup.Id))
                {


                    if ((bool)r["YesSumma"])
                    {
                        S1+=float.Parse(r["Item2"].ToString());
                        S2+=float.Parse(r["Item4"].ToString());
                    }

                }
            Weeks1 = (int)(S1/MaxHoursWeek);
            Weeks2 = (int)(S2/MaxHoursWeek);



        }
    }
}
