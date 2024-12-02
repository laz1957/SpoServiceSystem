using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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
    /// Логика взаимодействия для WeeksGroupsWindow.xaml
    /// </summary>
    public partial class WeeksGroupsWindow : Window
    {
        DataModels.BazaSoft basaSoft;
        DataView ViewModel;
        DataTable dataTable;
        public WeeksGroupsWindow()
        {
            InitializeComponent();
            basaSoft= new DataModels.BazaSoft();
            InitData();
            datagrid.ItemsSource =dataTable.DefaultView;
        }
        void SetFilterFromDataGrid()
        {
            string filter = string.Empty;
            if (kursCB.SelectedItem != null) { filter =string.Format("kurs={0}", kursCB.SelectedValue); };
            if (otdCB.SelectedItem != null)
                if (string.IsNullOrEmpty(filter)) 
                   { filter =string.Format("id_uo={0}", otdCB.SelectedValue); }
                 else
                    filter =filter + " AND " + string.Format("id_uo={0}", otdCB.SelectedValue);
            if (specCB.SelectedItem != null)
                if (string.IsNullOrEmpty(filter))
                { filter =string.Format("id_sp={0}", specCB.SelectedValue); }
                else
                    filter =filter + " AND " + string.Format("id_sp={0}", specCB.SelectedValue);
            if (tipCB.SelectedItem != null)
                if (string.IsNullOrEmpty(filter)) { filter =string.Format("id_tip={0}", tipCB.SelectedValue); }
                else
                    filter =filter + " AND " + string.Format("id_tip={0}", tipCB.SelectedValue);

            ((datagrid.ItemsSource) as DataView).RowFilter = filter;

        }
        private void kursCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetFilterFromDataGrid();
        }

        private void ClearkursFilter_Click(object sender, RoutedEventArgs e)
        {
            kursCB.SelectedItem = null;
        }

        private void ClearOtdFilter_Click(object sender, RoutedEventArgs e)
        {
            otdCB.SelectedItem = null;
        }

        private void specCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetFilterFromDataGrid();
        }

        private void ClearSpecFilter_Click(object sender, RoutedEventArgs e)
        {
            specCB.SelectedItem = null;
        }

        private void tipCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetFilterFromDataGrid();
        }

        private void ClearTipFilter_Click(object sender, RoutedEventArgs e)
        {
            tipCB.SelectedItem = null;
        }

        private void otdCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetFilterFromDataGrid();
        }

        //----------------------------------------------------------------------
        void InitData()
        {
            string sql = "select * from group_weeks_view";
            dataTable = basaSoft.getTable(sql);

        }
        private void datagrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(datagrid.ItemsSource).Refresh();
        }
        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            string UpdateString = "UPDATE  count_weeks_groups SET " +
                                 "semestr1=@semestr1,semestr2=@semestr2" +
                                 " WHERE id_group=@id_group";
            int n = -1;
            try
            {
                DataTable? dt = dataTable.GetChanges();
                if (dt != null)
                {
                    using (MySqlConnection conn = new MySqlConnection(basaSoft.MySqlConnectionString))
                    {
                        conn.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter();
                        MySqlCommand com = new MySqlCommand(UpdateString, conn);
                        com.Parameters.Add("@id_group", MySqlDbType.Int32, 32, "id_group");
                        com.Parameters.Add("@semestr1", MySqlDbType.Int32, 32, "semestr1");
                        com.Parameters.Add("@semestr2", MySqlDbType.Int32, 32, "semestr2");
                        adapter.UpdateCommand = com;
                        n = adapter.Update(dt);
                        conn.Close();
                        dataTable.AcceptChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }

        }

     
    }
}
