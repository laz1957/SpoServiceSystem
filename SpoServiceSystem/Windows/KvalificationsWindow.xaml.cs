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
    /// Логика взаимодействия для KvalificationsWindow.xaml
    /// </summary>
    public partial class KvalificationsWindow : Window
    {
        public KvalificationsWindow()
        {
            InitializeComponent();
            datagrid.MouseDoubleClick+=Datagrid_MouseDoubleClick;
        }

        private void Datagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void datagrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if(!e.Cancel)
            {
                DataRowView row = e.Row.Item as DataRowView;
                //  datagrid.UpdateLayout();
               // datagrid.CancelEdit();
            }
        }
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            //  (datagrid.ItemsSource as DataView).ToTable().Rows.Add(new object[] { });
            // DataRowView drw =  (datagrid.ItemsSource as DataView).AddNew();
            //   drw.Row[2] = "новая";
            DataRow dr = (datagrid.ItemsSource as DataView).Table.NewRow();
            dr[2]="Новая";
            (datagrid.ItemsSource as DataView).Table.Rows.Add(dr);
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = (datagrid.ItemsSource as DataView).Table;
            DataTable dtCange = dt.GetChanges();
            if (dtCange != null)
            {

              int ncount=  (TopGrid.DataContext as DataModels.BazaSoft).SaveKvalifications(dt);
              if(ncount > 0)
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

        private void datagrid_CurrentCellChanged(object sender, EventArgs e)
        {
            //CollectionViewSource.GetDefaultView(datagrid.ItemsSource).Refresh(); 
        }

        private void datagrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(datagrid.ItemsSource).Refresh();
        }
    }
}
