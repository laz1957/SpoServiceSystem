using SpoServiceSystem.Classes;
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
    /// Логика взаимодействия для PredmetsWindow.xaml
    /// </summary>
    public partial class PredmetsWindow : Window
    {
        public PredmetsWindow()
        {
            this.Loaded+=PredmetsWindow_Loaded;
            InitializeComponent();
            

        }

        private void PredmetsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        bool filtergrid(object item)
        {
            //  if (specLB.SelectedItem == null) return true;
            //  return ((item as Group).Id_sp==(specLB.SelectedItem as Specialnost).Id); ;
            //if (cpecialnostCB.SelectedItem == null && kursCB==null) return true;
            //else return false;
            return false;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {

            DataRow dr = (datagrid.ItemsSource as DataView).Table.NewRow();
            dr["name_pr"]="Новая";
            if (cpecialnostCB.SelectedItem != null) dr["id_sp"]=cpecialnostCB.SelectedValue;
            if (kursCB.SelectedItem != null) dr["kurs"]=kursCB.SelectedValue;

            (datagrid.ItemsSource as DataView).Table.Rows.Add(dr);
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = (datagrid.ItemsSource as DataView).Table;
            DataTable dtCange = dt.GetChanges();
            if (dtCange != null)
            {

                int n = (TopGrid.DataContext as DataModels.BazaSoft).SavePredmets(dt);
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
            DataTable dtCange = dt.GetChanges();
            if (dtCange != null)
            {

                if (MessageBox.Show("Данные не сохранены !!!"+Environment.NewLine+ "Выполнить выход из программы? ", "Внимание!!!", MessageBoxButton.YesNo)== MessageBoxResult.Yes)
                    this.Close();
            }
            else
                this.Close();
        }
        private void datagrid_CurrentCellChanged(object sender, EventArgs e)
        {
            // CollectionViewSource.GetDefaultView(datagrid.ItemsSource).Refresh();
        }

        private void datagrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(datagrid.ItemsSource).Refresh();
        }

        private void ClearBtn1_Click(object sender, RoutedEventArgs e)
        {
            cpecialnostCB.SelectedItem = null;
        }

        private void ClearBtn2_Click(object sender, RoutedEventArgs e)
        {
            kursCB.SelectedItem = null;
        }

        private void cpecialnostCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetFilterDataGrid();
        }

        private void kursCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetFilterDataGrid();
        }
        void SetFilterDataGrid()
        {
            if (cpecialnostCB.SelectedItem == null && kursCB.SelectedItem==null)
                ((datagrid.ItemsSource) as DataView).RowFilter="";
            if (cpecialnostCB.SelectedItem != null && kursCB.SelectedItem==null)
                ((datagrid.ItemsSource) as DataView).RowFilter=string.Format("id_sp={0}", cpecialnostCB.SelectedValue);
            if (cpecialnostCB.SelectedItem == null && kursCB.SelectedItem!=null)
                ((datagrid.ItemsSource) as DataView).RowFilter=string.Format("kurs={0}", kursCB.SelectedValue);
            if (cpecialnostCB.SelectedItem != null && kursCB.SelectedItem!=null)
                ((datagrid.ItemsSource) as DataView).RowFilter=string.Format("id_sp={0} and kurs={1}", cpecialnostCB.SelectedValue, kursCB.SelectedValue);


        }
    }
}
