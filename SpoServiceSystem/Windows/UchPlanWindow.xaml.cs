using SpoServiceSystem.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Printing.IndexedProperties;
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
    /// Логика взаимодействия для UchPlanWindow.xaml
    /// </summary>
    public partial class UchPlanWindow : Window
    {
        public static readonly DependencyProperty ItogoItem1Property;
        public static readonly DependencyProperty ItogoItem2Property;
        public static readonly DependencyProperty ItogoItem3Property;
        public static readonly DependencyProperty ItogoItem4Property;
        public static readonly DependencyProperty ItogoItem5Property;
        public static readonly DependencyProperty ItogoItem6Property;
        public static readonly DependencyProperty ItogoItem7Property;
        public static readonly DependencyProperty ItogoItem8Property;
        public static readonly DependencyProperty ItogoItem9Property;
        public static readonly DependencyProperty ItogoItem10Property;
        public static readonly DependencyProperty ItogoItem11Property;
        public static readonly DependencyProperty ItogoItem12Property;
        public static readonly DependencyProperty ItogoItem13Property;
        public static readonly DependencyProperty ItogoItem14Property;
        public static readonly DependencyProperty ItogoItem15Property;
        public static readonly DependencyProperty ItogoItem16Property;
        public static readonly DependencyProperty ItogoItem17Property;
        public static readonly DependencyProperty ItogoItem18Property;
        public static readonly DependencyProperty ItogoItem19Property;
        public static readonly DependencyProperty ItogoItem20Property;
        public static readonly DependencyProperty ItogoItem21Property;
        static UchPlanWindow()
        {
            ItogoItem1Property = DependencyProperty.Register("ItogoItem1", typeof(int), typeof(UchPlanWindow));
            ItogoItem2Property = DependencyProperty.Register("ItogoItem2", typeof(int), typeof(UchPlanWindow));
            ItogoItem3Property = DependencyProperty.Register("ItogoItem3", typeof(int), typeof(UchPlanWindow));
            ItogoItem4Property = DependencyProperty.Register("ItogoItem4", typeof(int), typeof(UchPlanWindow));
            ItogoItem5Property = DependencyProperty.Register("ItogoItem5", typeof(int), typeof(UchPlanWindow));
            ItogoItem6Property = DependencyProperty.Register("ItogoItem6", typeof(int), typeof(UchPlanWindow));
            ItogoItem7Property = DependencyProperty.Register("ItogoItem7", typeof(int), typeof(UchPlanWindow));
            ItogoItem8Property = DependencyProperty.Register("ItogoItem8", typeof(int), typeof(UchPlanWindow));
            ItogoItem9Property = DependencyProperty.Register("ItogoItem9", typeof(int), typeof(UchPlanWindow));
            ItogoItem10Property = DependencyProperty.Register("ItogoItem10", typeof(int), typeof(UchPlanWindow));
            ItogoItem11Property = DependencyProperty.Register("ItogoItem11", typeof(int), typeof(UchPlanWindow));
            ItogoItem12Property = DependencyProperty.Register("ItogoItem12", typeof(int), typeof(UchPlanWindow));
            ItogoItem13Property = DependencyProperty.Register("ItogoItem13", typeof(int), typeof(UchPlanWindow));
            ItogoItem14Property = DependencyProperty.Register("ItogoItem14", typeof(int), typeof(UchPlanWindow));
            ItogoItem15Property = DependencyProperty.Register("ItogoItem15", typeof(int), typeof(UchPlanWindow));
            ItogoItem16Property = DependencyProperty.Register("ItogoItem16", typeof(int), typeof(UchPlanWindow));
            ItogoItem17Property = DependencyProperty.Register("ItogoItem17", typeof(int), typeof(UchPlanWindow));
            ItogoItem18Property = DependencyProperty.Register("ItogoItem18", typeof(int), typeof(UchPlanWindow));
            ItogoItem19Property = DependencyProperty.Register("ItogoItem19", typeof(int), typeof(UchPlanWindow));
            ItogoItem20Property = DependencyProperty.Register("ItogoItem20", typeof(int), typeof(UchPlanWindow));
            ItogoItem21Property = DependencyProperty.Register("ItogoItem21", typeof(int), typeof(UchPlanWindow));
        }
        public int ItogoItem1
        {
            get { return (int)GetValue(ItogoItem1Property); }
            set { SetValue(ItogoItem1Property, value); }
        }
        public int ItogoItem2
        {
            get { return (int)GetValue(ItogoItem2Property); }
            set { SetValue(ItogoItem2Property, value); }
        }
        public int ItogoItem3
        {
            get { return (int)GetValue(ItogoItem3Property); }
            set { SetValue(ItogoItem3Property, value); }
        }
        public int ItogoItem4
        {
            get { return (int)GetValue(ItogoItem4Property); }
            set { SetValue(ItogoItem4Property, value); }
        }
        public int ItogoItem5
        {
            get { return (int)GetValue(ItogoItem5Property); }
            set { SetValue(ItogoItem5Property, value); }
        }
        public int ItogoItem6
        {
            get { return (int)GetValue(ItogoItem6Property); }
            set { SetValue(ItogoItem6Property, value); }
        }
        public int ItogoItem7
        {
            get { return (int)GetValue(ItogoItem7Property); }
            set { SetValue(ItogoItem7Property, value); }
        }
        public int ItogoItem8
        {
            get { return (int)GetValue(ItogoItem8Property); }
            set { SetValue(ItogoItem8Property, value); }
        }
        public int ItogoItem9
        {
            get { return (int)GetValue(ItogoItem9Property); }
            set { SetValue(ItogoItem9Property, value); }
        }
        public int ItogoItem10
        {
            get { return (int)GetValue(ItogoItem10Property); }
            set { SetValue(ItogoItem10Property, value); }
        }
        public int ItogoItem11
        {
            get { return (int)GetValue(ItogoItem11Property); }
            set { SetValue(ItogoItem11Property, value); }
        }
        public int ItogoItem12
        {
            get { return (int)GetValue(ItogoItem12Property); }
            set { SetValue(ItogoItem12Property, value); }
        }
        public int ItogoItem13
        {
            get { return (int)GetValue(ItogoItem13Property); }
            set { SetValue(ItogoItem13Property, value); }
        }
        public int ItogoItem14
        {
            get { return (int)GetValue(ItogoItem14Property); }
            set { SetValue(ItogoItem14Property, value); }
        }
        public int ItogoItem15
        {
            get { return (int)GetValue(ItogoItem15Property); }
            set { SetValue(ItogoItem15Property, value); }
        }
        public int ItogoItem16
        {
            get { return (int)GetValue(ItogoItem16Property); }
            set { SetValue(ItogoItem16Property, value); }
        }
        public int ItogoItem17
        {
            get { return (int)GetValue(ItogoItem17Property); }
            set { SetValue(ItogoItem17Property, value); }
        }
        public int ItogoItem18
        {
            get { return (int)GetValue(ItogoItem18Property); }
            set { SetValue(ItogoItem18Property, value); }
        }
        public int ItogoItem19
        {
            get { return (int)GetValue(ItogoItem19Property); }
            set { SetValue(ItogoItem19Property, value); }
        }
        public int ItogoItem20
        {
            get { return (int)GetValue(ItogoItem20Property); }
            set { SetValue(ItogoItem20Property, value); }
        }
        public int ItogoItem21
        {
            get { return (int)GetValue(ItogoItem21Property); }
            set { SetValue(ItogoItem21Property, value); }
        }
        public UchPlanWindow()
        {
            InitializeComponent();

            BazaSoft bs = new BazaSoft();
            datagrid.ItemsSource = bs.GetUchPlanDataView(1);
            datagrid.LoadingRow+=Datagrid_LoadingRow;
        }

        private void Datagrid_LoadingRow(object? sender, DataGridRowEventArgs e)
        {
            DataRowView drw = (e.Row.Item as DataRowView);
            drw.PropertyChanged+=Drw_PropertyChanged;
        }

        private void Drw_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            //  MessageBox.Show(e.PropertyName);
            RaschetItogov();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            int ncount = (datagrid.ItemsSource as DataView).Table.Rows.Count+1;
            DataRow dr = (datagrid.ItemsSource as DataView).Table.NewRow();
            dr["Number"]=ncount;
            dr["Index"]="Новая";
            dr["Item1"]=0; dr["Item3"]=0;
            dr["Item2"]=0; dr["Item4"]=0;
            dr["Item5"]=0; dr["Item6"]=0;
            dr["Item7"]=0; dr["Item8"]=0;
            dr["Item9"]=0; dr["Item10"]=0;
            dr["Item11"]=0; dr["Item12"]=0;
            dr["Item13"]=0; dr["Item14"]=0;
            dr["Item15"]=0; dr["Item16"]=0;
            dr["Item17"]=0; dr["Item18"]=0;
            (datagrid.ItemsSource as DataView).Table.Rows.Add(dr);
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = (datagrid.ItemsSource as DataView).Table;
            DataTable dtCange = dt.GetChanges();
            if (dtCange != null)
            {

                //int n = (TopGrid.DataContext as DataModels.BazaSoft).SaveSpecialnost(dt);
                // if (n > 0)
                //  {
                dt.AcceptChanges();
                // }
            }
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItem != null)
            {
                (datagrid.SelectedItem as DataRowView).Row.Delete();

                RaschetItogov();



            }
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
          


            DataTable dt = (datagrid.ItemsSource as DataView).Table;
            DataTable dtCange = dt.GetChanges();
            if (dtCange != null)
            {

                if (MessageBox.Show("Данные не сохранены !!!"+Environment.NewLine+ "Выполнить выход из программы? ", "Внимание!!!", MessageBoxButton.YesNo)== MessageBoxResult.Yes)
                    this.Close();
            }
            else
                this.Close();
        }

        private void dataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            
            if ((sender as DataGrid).SelectedItem != null)
                CollectionViewSource.GetDefaultView(datagrid.ItemsSource).Refresh();
        }

        private void datagrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
             
            if (e.EditAction==DataGridEditAction.Commit)
            {

               
                
                
            }
        }

        private void datagrid_CurrentCellChanged(object sender, EventArgs e)
        {
            
        }
        void RaschetItogov()
        {
            ItogoItem1=0;
            ItogoItem2=0;
            ItogoItem3=0;
            ItogoItem4=0;
            ItogoItem5=0;
            ItogoItem6=0;
            ItogoItem7=0;
            ItogoItem8=0;
            ItogoItem9=0;
            ItogoItem10=0;

            ItogoItem11=0;
            ItogoItem12=0;
            ItogoItem13=0;
            ItogoItem14=0;
            ItogoItem15=0;
            ItogoItem16=0;
            ItogoItem17=0;
            ItogoItem18=0;
            ItogoItem19=0;
            ItogoItem20=0;
            ItogoItem21=0;
            foreach (DataRow r in (datagrid.ItemsSource as DataView).Table.Rows)
            {
                ItogoItem1+=r.Field<int>("Item1");
                ItogoItem2+=r.Field<int>("Item2");
                ItogoItem3+=r.Field<int>("Item3");
                ItogoItem4+=r.Field<int>("Item4");
                ItogoItem5+=r.Field<int>("Item5");
                ItogoItem6+=r.Field<int>("Vsego1");
                ItogoItem7+=r.Field<int>("Item6");
                ItogoItem8+=r.Field<int>("Item7");
                ItogoItem9+=r.Field<int>("Item8");
                ItogoItem10+=r.Field<int>("Item9");
                ItogoItem11+=r.Field<int>("Item10");
                ItogoItem12+=r.Field<int>("Item11");
                ItogoItem13+=r.Field<int>("Item12");
                ItogoItem14+=r.Field<int>("Item13");
                ItogoItem15+=r.Field<int>("Item14");
                ItogoItem16+=r.Field<int>("Item15");
                ItogoItem17+=r.Field<int>("Vsego2");
                ItogoItem18+=r.Field<int>("Item16");
                ItogoItem19+=r.Field<int>("Item17");
                ItogoItem20+=r.Field<int>("Item18");
                ItogoItem21+=r.Field<int>("Itogo");



            }
        }

        
    }
}
