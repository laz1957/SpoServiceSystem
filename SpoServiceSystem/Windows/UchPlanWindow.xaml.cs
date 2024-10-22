using MySqlX.XDevAPI.Common;
using SpoServiceSystem.Classes;
using SpoServiceSystem.DataModels;
using System;
using System.Collections;
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
using System.Windows.Controls.Primitives;
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
        #region Свойства зависимости
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
        public static readonly DependencyProperty uchPlanGroupProperty;
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
            uchPlanGroupProperty = DependencyProperty.Register("uchPlanGroup", typeof(UchPlanGroup), typeof(UchPlanWindow));
        }
        public UchPlanGroup uchPlanGroup
        {
            get { return (UchPlanGroup)GetValue(uchPlanGroupProperty); }
            set { SetValue(uchPlanGroupProperty, value); }
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
        #endregion
        public Group CurrentGroup { get; set; }
        //public UchPlanGroup uchPlanGroup { get; set; }
        BazaSoft bs;
        MessageWindow message_window;
        public UchPlanWindow()
        {
            InitializeComponent();
            bs = new BazaSoft();
            
        }
        public UchPlanWindow(Group group) :this()
        {
            // Конструктор для новаго плана
            CurrentGroup = group;
            uchPlanGroup = new UchPlanGroup(group);
            uchPlanGroup.status = UchPlanStatus.New;
            uchPlanGroup.StringStatus = "Новый";
            // datagrid.ItemsSource = bs.GenerateUchPlanDataView(group.Id);
            datagrid.ItemsSource = uchPlanGroup.GetNewUchPlan();
            datagrid.LoadingRow+=Datagrid_LoadingRow;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(Col3.ItemsSource);
            view.Filter = SpecialnosrFilter;
            settingUpBtn.Visibility = Visibility.Visible;
            deleteUpBtn.Visibility= Visibility.Collapsed;

        }
        public UchPlanWindow(Group group,int var) : this()
        {
            // Конструктор для существующего учебного плана
            CurrentGroup = group;
            uchPlanGroup = new UchPlanGroup(group);
            uchPlanGroup.status = UchPlanStatus.Norma;
            uchPlanGroup.StringStatus = "Норма";
            // datagrid.ItemsSource = bs.GenerateUchPlanDataView(group.Id);
            datagrid.ItemsSource = uchPlanGroup.GetUchPlan();
            datagrid.LoadingRow+=Datagrid_LoadingRow;
            datagrid.Loaded+=Datagrid_Loaded;

             CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(Col3.ItemsSource);
            view.Filter = SpecialnosrFilter;
            settingUpBtn.Visibility = Visibility.Collapsed;
        }

        private void Datagrid_Loaded(object sender, RoutedEventArgs e)
        {
            RaschetItogov();
        }

        bool SpecialnosrFilter(object item)
        {
            if(CurrentGroup==null) return true;
            Predmet pr = item as Predmet;
            if (pr==null) return true;
            else
                return (pr.Id_sp==CurrentGroup.Id_sp) && (pr.Kurs==CurrentGroup.Kurs);
        }
        private void Datagrid_LoadingRow(object? sender, DataGridRowEventArgs e)
        {
            DataRowView drw = (e.Row.Item as DataRowView);
            drw.PropertyChanged+=Drw_PropertyChanged;
        }

        private void Drw_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            
            RaschetItogov();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            int ncount = (datagrid.ItemsSource as DataView).Table.Rows.Count+1;
            DataRow dr = (datagrid.ItemsSource as DataView).Table.NewRow();
            dr["Number"]=ncount;
            dr["index_pr"]="Новая";
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
            uchPlanGroup.StringStatus = "Добавлены новые данные";
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            message_window = new MessageWindow();
            message_window.MessageText = "Выполняется сохранение информации!";
            message_window.Show();
           
            DataTable dt = (datagrid.ItemsSource as DataView).Table;
           
            BackgroundWorker bw002 = new BackgroundWorker();
            bw002.DoWork+=Bw002_DoWork;
            bw002.RunWorkerCompleted+=Bw002_RunWorkerCompleted;
            bw002.RunWorkerAsync(dt);



            
        }

        private void Bw002_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            message_window.MessageText = "Операция выполнена!!!";
            message_window.OkBtn.Visibility = Visibility.Visible;
            uchPlanGroup.StringStatus = "Норма";
            (datagrid.ItemsSource as DataView).Table.AcceptChanges();
        }

        private void Bw002_DoWork(object? sender, DoWorkEventArgs e)
        {
            DataTable dt = e.Argument as DataTable;
            if (dt != null)
            {
                int n = bs.SaveUchPlan(dt);
                if (n > 0)
                {
                  //  dt.AcceptChanges();
                   
                }
            }

            System.Threading.Thread.Sleep(1000);
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
        private void SomeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var item = comboBox.SelectedItem as Predmet;
            DataRowView selectedItem = this.datagrid.CurrentItem as DataRowView;
            selectedItem.Row["index_pr"]=item.Index_pr;

        }
        private void datagrid_CurrentCellChanged(object sender, EventArgs e)
        {

        }
        void RaschetItogov()
        {
            //uchPlanGroup.StringStatus = "Изменен";
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
                ItogoItem1+=int.Parse(r["Item1"].ToString());
                ItogoItem2+=int.Parse(r["Item2"].ToString());
                ItogoItem3+=int.Parse(r["Item3"].ToString());
                ItogoItem4+=int.Parse(r["Item4"].ToString());
                ItogoItem5+=int.Parse(r["Item5"].ToString());
                ItogoItem6+=int.Parse(r["Vsego1"].ToString());
                ItogoItem7+=int.Parse(r["Item6"].ToString());
                ItogoItem8+=int.Parse(r["Item7"].ToString());
                ItogoItem9+=int.Parse(r["Item8"].ToString());
                ItogoItem10+=int.Parse(r["Item10"].ToString());
                ItogoItem11+=int.Parse(r["Item11"].ToString());
                ItogoItem12+=int.Parse(r["Item12"].ToString());
                ItogoItem13+=int.Parse(r["Item13"].ToString());
                ItogoItem14+=int.Parse(r["Item14"].ToString());
                ItogoItem15+=int.Parse(r["Item15"].ToString());
                ItogoItem16+=int.Parse(r["Item16"].ToString());
                ItogoItem17+=int.Parse(r["Vsego2"].ToString());
                ItogoItem18+=int.Parse(r["Item16"].ToString());
                ItogoItem19+=int.Parse(r["Item17"].ToString());
                ItogoItem20+=int.Parse(r["Item18"].ToString());
                ItogoItem21+=int.Parse(r["Itogo"].ToString());
                
 
            }
            if((datagrid.ItemsSource as DataView).Table.GetChanges()!= null)
                uchPlanGroup.StringStatus = "Изменен";
            else
                uchPlanGroup.StringStatus = "Норма";

        }

      
        private void ImportExcelBtn_Click(object sender, RoutedEventArgs e)
        {
            string Filename = string.Format("Учебный план {0} от {1}", CurrentGroup.NameGroup,DateTime.Now.ToShortDateString());
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = Filename; // Default file name
            dialog.DefaultExt = ".xlsx"; // Default file extension
            dialog.Filter = "Text documents (.xlsx)|*.xlsx"; // Filter files by extension
           
            bool? result = dialog.ShowDialog();
          
            if (result == true)
            {
                string filename = dialog.FileName;
                bool yesView = ViewExcel.IsChecked.HasValue ? ViewExcel.IsChecked.Value : false;
                ExcelManager em = new ExcelManager(this, filename, yesView);
                em.Init();
                em.GreateExcelDocument();
                if(!yesView) em.Close();
            }




        }

        private void Worker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
           
           if(message_window != null) 
            {
                message_window.MessageText ="Опрерация выполнена !";
                message_window.OkBtn.Visibility = Visibility.Visible;
            }   

        }

        private void Worker_DoWork(object? sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
           
            DataTable dt = e.Argument  as DataTable;
            bs.SaveUchPlan(dt); 

        }

        private void settingUpBtn_Click(object sender, RoutedEventArgs e)
        {
            message_window = new MessageWindow("Выполняется регистрация учебного плана! Подождите");
            message_window.MessageText="Выполняется регистрация учебного плана! Подождите";
            message_window.Show();
            uchPlanGroup.DeleteUchPlan();
            DataTable dt = (datagrid.ItemsSource as DataView).Table;
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork+=Worker_DoWork;
            worker.RunWorkerCompleted+=Worker_RunWorkerCompleted;
            worker.RunWorkerAsync(dt);


            
            
        }

        private void deleteUpBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Данный учебный план будет безвозвратно удален !"+Environment.NewLine+ "Вы уверены? ", "Внимание!!!", MessageBoxButton.YesNo)== MessageBoxResult.Yes)
            {
                uchPlanGroup.DeleteUchPlan();
                this.Close();
            }
               
        }
    }
}

