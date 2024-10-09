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
    /// Логика взаимодействия для UchPlanWindow.xaml
    /// </summary>
    public partial class UchPlanWindow : Window
    {
        public UchPlanWindow()
        {
            InitializeComponent();
        }
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            //  (datagrid.ItemsSource as DataView).ToTable().Rows.Add(new object[] { });
            // DataRowView drw =  (datagrid.ItemsSource as DataView).AddNew();
            //   drw.Row[2] = "новая";
            DataRow dr = (datagrid.ItemsSource as DataView).Table.NewRow();
            dr["Index"]="Новая";
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


                // DataTable dt = (datagrid.ItemsSource as DataView).Table;
                // int n = datagrid.SelectedIndex;
                //dt.Rows[n].Delete();

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
                MessageBox.Show(e.EditAction.ToString());
            }
        }

    }
}
