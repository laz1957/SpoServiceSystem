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
    }
}
