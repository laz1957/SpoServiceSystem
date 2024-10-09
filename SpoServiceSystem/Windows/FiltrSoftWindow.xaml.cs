using SpoServiceSystem.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для FiltrSoftWindow.xaml
    /// </summary>
    public partial class FiltrSoftWindow : Window
    {
       // ICollectionView cvTasks = CollectionViewSource.GetDefaultView(dataGrid1.ItemsSource);
           
        public FiltrSoftWindow()
        {
            InitializeComponent();
            BazaSoft bs = new BazaSoft();
            DataTable dt = bs.getDataTable("specialnost");




        }

        private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            // e.Accepted = false;
            // 
            DataModels.TipUch t = e.Item as DataModels.TipUch;
            if (t != null)
            {
                if (!string.IsNullOrEmpty(cb_001.Text))
                {
                    string filter = txt001.Text.Trim().ToLower();
                    if (t.Name.ToLower().StartsWith(filter))
                    {
                        e.Accepted = true;
                    }
                    else {
                        e.Accepted = false;
                    }
                }
            }
        }

        private void cb_001_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            
          CollectionViewSource.GetDefaultView(cb_001.ItemsSource).Refresh();
        }

        private void cb_001_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txt001_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(cb_001 != null)
               cb_001.IsDropDownOpen = true;
        }
    }
}
