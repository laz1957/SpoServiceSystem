using SpoServiceSystem.DataModels;
using SpoServiceSystem.Windows;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для PrepodPredmetDataGridxaml.xaml
    /// </summary>
    public partial class PrepodPredmetDataGridxaml : UserControl, INotifyPropertyChanged
    {
        private static void OnFullAdressChanded(DependencyObject d,
                                                        DependencyPropertyChangedEventArgs e)
        {
            if (d == null || e.NewValue == null)
            {
                return;
            }

        }
        public static readonly DependencyProperty uchPlanGroupProperty;
        static PrepodPredmetDataGridxaml()
        {
            // uchPlanGroupProperty = DependencyProperty.Register("uchPlanGroup", typeof(UchPlanGroup), typeof(PrepodPredmetDataGridxaml));
            uchPlanGroupProperty =
                           DependencyProperty.Register("uchPlanGroup", typeof(UchPlanGroup),
                           typeof(PrepodPredmetDataGridxaml),
                           new UIPropertyMetadata(null, OnFullAdressChanded));

        }
        public UchPlanGroup uchPlanGroup
        {
            get { return (UchPlanGroup)GetValue(uchPlanGroupProperty); }
            set { SetValue(uchPlanGroupProperty, value); OnPropertyChanged(); }
        }
        
               
        public DataRow ParentRow;
        public int idGroup;
        int idUp;
        int idSp;
        int idPr;
        int kurs;
        
        public PrepodPredmetDataGridxaml()
        {
            InitializeComponent();
            this.Loaded+=PrepodPredmetDataGridxaml_Loaded;
        }

        private void PrepodPredmetDataGridxaml_Loaded(object sender, RoutedEventArgs e)
        {
            DataRowView dgr = (DataRowView)this.DataContext;
            ParentRow = dgr.Row;
            idGroup=uchPlanGroup.Id;
            idUp = (int)ParentRow["id_up"];
            idSp = (int)ParentRow["id_sp"];
            idPr = (int)ParentRow["id_pr"];
            kurs = (int)ParentRow["kurs"];

        }

        private void datagrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void datagrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void datagrid_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void insBtn_Click(object sender, RoutedEventArgs e)
        {
            DataRow dr = (datagrid.ItemsSource as DataView).Table.NewRow();
            dr["id_group"]=idGroup;
            dr["id_up"]= idUp;
            dr["id_sp"] = idSp;
            dr["id_pr"] = (int)idPr;
            dr["kurs"] = kurs;
            RaschetItems(dr);

            /*
            dr["Item1"]=ParentRow["Item1"]; dr["Item3"]=ParentRow["Item3"];
            dr["Item2"]=ParentRow["Item2"]; dr["Item4"]=ParentRow["Item4"];
            dr["Item5"]=ParentRow["Item5"]; dr["Item6"]=ParentRow["Item6"];
            dr["Item7"]=ParentRow["Item7"]; dr["Item8"]=ParentRow["Item8"];
            dr["Item9"]=ParentRow["Item9"]; dr["Item10"]=ParentRow["Item10"];
            dr["Item11"]=ParentRow["Item11"]; dr["Item12"]=ParentRow["Item12"];
            dr["Item13"]=ParentRow["Item13"]; dr["Item14"]=ParentRow["Item14"];
            dr["Item15"]=ParentRow["Item15"]; dr["Item16"]=ParentRow["Item16"];
            dr["Item17"]=ParentRow["Item17"]; dr["Item18"]=ParentRow["Item18"];
            */

            (datagrid.ItemsSource as DataView).Table.Rows.Add(dr);
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            if(datagrid.SelectedItem != null)
            {
                DataRow row = ((DataRowView)datagrid.SelectedItem).Row;
                row.Delete();
            }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
 
            DataTable dtChlld = (datagrid.ItemsSource as DataView).Table;
            uchPlanGroup.SaveChildData(dtChlld);
        }

        void RaschetItems(DataRow newrow)
        {
            int i1=0, i2=0, i3=0, i4=0, i5=0, i6=0, i7=0, i8=0, i9=0, i10=0, i11=0, i12=0, i13=0, i14=0, i15=0, i16=0, i17=0, i18 = 0;
            DataTable dt = (datagrid.ItemsSource as DataView).Table;
            foreach(DataRow row in dt.Rows)
            {
                i1+=row.IsNull("Item1") ? 0 : int.Parse(row["Item1"].ToString());
                i2+=row.IsNull("Item2") ? 0 : int.Parse(row["Item2"].ToString());
                i3+=row.IsNull("Item3") ? 0 : int.Parse(row["Item3"].ToString());
                i4+=row.IsNull("Item4") ? 0 : int.Parse(row["Item4"].ToString());
                i5+=row.IsNull("Item5") ? 0 : int.Parse(row["Item5"].ToString());
                i6+=row.IsNull("Item16") ? 0 : int.Parse(row["Item6"].ToString());
                i7+=row.IsNull("Item7") ? 0 : int.Parse(row["Item7"].ToString());
                i8+=row.IsNull("Item8") ? 0 : int.Parse(row["Item8"].ToString());
                i9+=row.IsNull("Item9") ? 0 : int.Parse(row["Item9"].ToString());
                i10+=row.IsNull("Item10") ? 0 : int.Parse(row["Item10"].ToString());
                i11+=row.IsNull("Item11") ? 0 : int.Parse(row["Item11"].ToString());
                i12+=row.IsNull("Item12") ? 0 : int.Parse(row["Item12"].ToString());
                i13+=row.IsNull("Item13") ? 0 : int.Parse(row["Item13"].ToString());
                i14+=row.IsNull("Item14") ? 0 : int.Parse(row["Item14"].ToString());
                i15+=row.IsNull("Item15") ? 0 : int.Parse(row["Item15"].ToString());
                i16+=row.IsNull("Item16") ? 0 : int.Parse(row["Item16"].ToString());
                i17+=row.IsNull("Item17") ? 0 : int.Parse(row["Item17"].ToString());
                i18+=row.IsNull("Item18") ? 0 : int.Parse(row["Item18"].ToString());
            }
            int x = int.Parse(ParentRow["Item2"].ToString());
            newrow["Item1"]=(int.Parse(ParentRow["Item1"].ToString())-i1) <0 ? 0 : int.Parse(ParentRow["Item1"].ToString())-i1;
            newrow["Item2"]=(int.Parse(ParentRow["Item2"].ToString())-i2) <0 ? 0 : int.Parse(ParentRow["Item2"].ToString())-i2;
            newrow["Item3"]=(int.Parse(ParentRow["Item3"].ToString())-i3) <0 ? 0 : int.Parse(ParentRow["Item3"].ToString())-i3;
            newrow["Item4"]=(int.Parse(ParentRow["Item4"].ToString())-i4) <0 ? 0 : int.Parse(ParentRow["Item4"].ToString())-i4;
            newrow["Item5"]=(int.Parse(ParentRow["Item5"].ToString())-i5) <0 ? 0 : int.Parse(ParentRow["Item5"].ToString())-i5;
            newrow["Item6"]=(int.Parse(ParentRow["Item6"].ToString())-i6) <0 ? 0 : int.Parse(ParentRow["Item6"].ToString())-i6;
            newrow["Item7"]=(int.Parse(ParentRow["Item7"].ToString())-i7) <0 ? 0 : int.Parse(ParentRow["Item7"].ToString())-i7;
            newrow["Item8"]=(int.Parse(ParentRow["Item8"].ToString())-i8) <0 ? 0 : int.Parse(ParentRow["Item8"].ToString())-i8;
            newrow["Item9"]=(int.Parse(ParentRow["Item9"].ToString())-i9) <0 ? 0 : int.Parse(ParentRow["Item9"].ToString())-i9;
            newrow["Item10"]=(int.Parse(ParentRow["Item10"].ToString())-i10) <0 ? 0 : int.Parse(ParentRow["Item10"].ToString())-i10;
            newrow["Item11"]=(int.Parse(ParentRow["Item11"].ToString())-i11) <0 ? 0 : int.Parse(ParentRow["Item11"].ToString())-i11;
            newrow["Item12"]=(int.Parse(ParentRow["Item12"].ToString())-i12) <0 ? 0 : int.Parse(ParentRow["Item12"].ToString())-i12;
            newrow["Item13"]=(int.Parse(ParentRow["Item13"].ToString())-i13) <0 ? 0 : int.Parse(ParentRow["Item13"].ToString())-i13;
            newrow["Item14"]=(int.Parse(ParentRow["Item14"].ToString())-i14) <0 ? 0 : int.Parse(ParentRow["Item14"].ToString())-i14;
            newrow["Item15"]=(int.Parse(ParentRow["Item15"].ToString())-i15) <0 ? 0 : int.Parse(ParentRow["Item15"].ToString())-i15;
            newrow["Item16"]=(int.Parse(ParentRow["Item16"].ToString())-i16) <0 ? 0 : int.Parse(ParentRow["Item16"].ToString())-i16;
            newrow["Item17"]=(int.Parse(ParentRow["Item17"].ToString())-i17) <0 ? 0 : int.Parse(ParentRow["Item17"].ToString())-i17;
            newrow["Item18"]=(int.Parse(ParentRow["Item18"].ToString())-i18) <0 ? 0 : int.Parse(ParentRow["Item18"].ToString())-i18;

        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
