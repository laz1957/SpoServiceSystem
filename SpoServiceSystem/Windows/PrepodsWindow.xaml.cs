using SpoServiceSystem.Classes;
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
    /// Логика взаимодействия для PrepodsWindow.xaml
    /// </summary>
    public partial class PrepodsWindow : Window
    {
        public PrepodsWindow()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            DataRow dr = (datagrid.ItemsSource as DataView).Table.NewRow();
            dr["fam"]="Новая";
            if (otdelenieCB.SelectedItem != null)
                dr["id_uo"]= otdelenieCB.SelectedValue;
           (datagrid.ItemsSource as DataView).Table.Rows.Add(dr);
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = (datagrid.ItemsSource as DataView).Table;
            DataTable dtCange = dt.GetChanges();
            if (dtCange != null)
            {

                int n = (TopGrid.DataContext as DataModels.BazaSoft).SavePrepods(dt);
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

        private void otdelenieCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetFilterDataGrid();
        }

        void SetFilterDataGrid()
        {
            if (otdelenieCB.SelectedItem == null)
                ((datagrid.ItemsSource) as DataView).RowFilter="";
            if (otdelenieCB.SelectedItem != null)
                ((datagrid.ItemsSource) as DataView).RowFilter=string.Format("id_uo={0}", otdelenieCB.SelectedValue); 



        }

        private void ClearBtn1_Click(object sender, RoutedEventArgs e)
        {
            otdelenieCB.SelectedItem = null;
        }
    }
}
