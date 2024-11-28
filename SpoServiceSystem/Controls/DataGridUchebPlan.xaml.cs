using SpoServiceSystem.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpoServiceSystem.Controls
{
    /// <summary>
    /// Логика взаимодействия для DataGridUchebPlan.xaml
    /// </summary>
    public partial class DataGridUchebPlan : UserControl, INotifyPropertyChanged
    {

        private static void OnFullAdressChanded(DependencyObject d,
                                                       DependencyPropertyChangedEventArgs e)
        {
            if (d == null || e.NewValue == null)
            {
                return;
            }

        }
        public static readonly DependencyProperty TableViewProperty;
        static DataGridUchebPlan()
        {
            
            TableViewProperty =
                           DependencyProperty.Register("TableView", typeof(DataView),
                           typeof(DataGridUchebPlan),
                           new UIPropertyMetadata(null, OnFullAdressChanded));

        }
        public DataView TableView
        {
            get { return (DataView)GetValue(TableViewProperty); }
            set { SetValue(TableViewProperty, value); OnPropertyChanged(); }
        }

       
        public DataGridUchebPlan()
        {
            InitializeComponent();
        }

        private void dataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

         

        }
        private void datagrid_CurrentCellChanged(object sender, EventArgs e)
        {
            
        }
        private void datagrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            if (e.EditAction==DataGridEditAction.Commit)
            {

              
            }
        }




        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

       
    }
}
