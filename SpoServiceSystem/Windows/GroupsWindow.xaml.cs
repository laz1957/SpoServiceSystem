using SpoServiceSystem.Classes;
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
    /// Логика взаимодействия для GroupsWindow.xaml
    /// </summary>
    public partial class GroupsWindow : Window
    {
        public GroupsWindow()
        {
            InitializeComponent();
        }


        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
          
            DataRow dr = (datagrid.ItemsSource as DataView).Table.NewRow();
            dr["name_group"]="Новая";
            dr["data"]= DateTime.Now.Date.ToShortDateString();
            if (otdCB.SelectedItem != null) dr["id_uo"]=otdCB.SelectedValue;
            if (specCB.SelectedItem != null) dr["id_sp"]=specCB.SelectedValue;
            if (tipCB.SelectedItem != null) dr["id_tip"]=tipCB.SelectedValue;
            (datagrid.ItemsSource as DataView).Table.Rows.Add(dr);
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = (datagrid.ItemsSource as DataView).Table;
            DataTable dtCange = dt.GetChanges();
            if (dtCange != null)
            {

                int n = (TopGrid.DataContext as DataModels.BazaSoft).SaveGroups(dt);
                if (n > 0)
                {
                    dt.AcceptChanges();
                    WpfServises.SetNewAutoIncrementData(dt);
                    dt.AcceptChanges();
                }
            }
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            if (datagrid.SelectedItem != null)
            {
                (datagrid.SelectedItem as DataRowView).Row.Delete();

            }
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = (datagrid.ItemsSource as DataView).Table;
            DataTable? dtCange = dt.GetChanges();
            if (dtCange != null)
            {

                if (MessageBox.Show("Данные не сохранены !!!"+Environment.NewLine+ "Выполнить выход из программы? ", "Внимание!!!", MessageBoxButton.YesNo)== MessageBoxResult.Yes)
                    this.Close();
            }
            else
                this.Close();
        }
       

        private void datagrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(datagrid.ItemsSource).Refresh();
        }

        void SetFilterFromDataGrid()
        {
            string filter = string.Empty;
            if (otdCB.SelectedItem != null) { filter =string.Format("id_uo={0}",otdCB.SelectedValue); };
            if(specCB.SelectedItem != null)
                if(string.IsNullOrEmpty(filter))
                  { filter =string.Format("id_sp={0}", specCB.SelectedValue); }
                else 
                    filter =filter + " AND " + string.Format("id_sp={0}", specCB.SelectedValue);
            if (tipCB.SelectedItem != null)
                if (string.IsNullOrEmpty(filter)) { filter =string.Format("id_tip={0}", tipCB.SelectedValue); }
                else
                filter =filter + " AND " + string.Format("id_tip={0}", tipCB.SelectedValue);

            ((datagrid.ItemsSource) as DataView).RowFilter = filter;
           
        }

        private void otdCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetFilterFromDataGrid();
        }

        private void specCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetFilterFromDataGrid();
        }

        private void tipCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetFilterFromDataGrid();
        }

        private void ClearOtdFilter_Click(object sender, RoutedEventArgs e)
        {
            otdCB.SelectedItem = null;
        }

        private void ClearSpecFilter_Click(object sender, RoutedEventArgs e)
        {
            specCB.SelectedItem = null;
        }

        private void ClearTipFilter_Click(object sender, RoutedEventArgs e)
        {
           tipCB.SelectedItem = null;
        }
    }
}
