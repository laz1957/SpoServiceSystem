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
        CollectionView viewGroups;
        public Group CurrentGroup { get; set; }

        NagruzkaFullData nagruzkaFullData;
        public static event EventHandler loadingDelegat;
        public DataFromRaspWindow()
        {
            InitializeComponent();
            this.SizeChanged+=DataFromRaspWindow_SizeChanged;
            this.Loaded+=DataFromRaspWindow_Loaded;
            viewGroups = (CollectionView)CollectionViewSource.GetDefaultView(groupLB.ItemsSource);
            viewGroups.Filter = GroupsFilter;
            nagruzkaFullData = new NagruzkaFullData();
            


        }

        private void DataFromRaspWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (loadingDelegat != null)
            {
                EventHandler handler = loadingDelegat;
                handler?.Invoke(this, e);
            }
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
            }
        }
    }
}
