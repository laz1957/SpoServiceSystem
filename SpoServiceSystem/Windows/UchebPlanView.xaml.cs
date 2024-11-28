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
    /// Логика взаимодействия для UchebPlanView.xaml
    /// </summary>
    public partial class UchebPlanView : Window
    {
        public Specialnost CurrentSpecialnost { get; set; }
        public int Kurs { get; set; }
        ItogiTable itogi;
        public UchebPlanView()
        {
            InitializeComponent();
        }
        public UchebPlanView(int idSpec,int idKurs) : this()
        {
            ListSpecialnost ls = this.Resources["listSpecialnost"] as ListSpecialnost;
            CurrentSpecialnost = ls.ToList().Where(l => l.Id == idSpec).FirstOrDefault();
            Kurs = idKurs;
            UchebPlan plan = new UchebPlan(idSpec,idKurs);
            datagrid.ItemsSource = plan.GetPlan();
            itogi = this.Resources["itogiTable"] as ItogiTable;
            RaschetItogov(itogi);

        } 

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
        void RaschetItogov(ItogiTable itogi)
        {

            itogi.ItogoItem1=0;
            itogi.ItogoItem2=0;
            itogi.ItogoItem3=0;
            itogi.ItogoItem4=0;
            itogi.ItogoItem5=0;
            itogi.ItogoItem6=0;
            itogi.ItogoItem7=0;
            itogi.ItogoItem8=0;
            itogi.ItogoItem9=0;
            itogi.ItogoItem10=0;

            itogi.ItogoItem11=0;
            itogi.ItogoItem12=0;
            itogi.ItogoItem13=0;
            itogi.ItogoItem14=0;
            itogi.ItogoItem15=0;
            itogi.ItogoItem16=0;
            itogi.ItogoItem17=0;
            itogi.ItogoItem18=0;
            itogi.ItogoItem19=0;
            itogi.ItogoItem20=0;
            itogi.ItogoItem21=0;
            foreach (DataRow r in (datagrid.ItemsSource as DataView).Table.Rows)
            {
                itogi.ItogoItem1+=int.Parse(r["Item1"].ToString());
                itogi.ItogoItem2+=int.Parse(r["Item2"].ToString());
                itogi.ItogoItem3+=int.Parse(r["Item3"].ToString());
                itogi.ItogoItem4+=int.Parse(r["Item4"].ToString());
                itogi.ItogoItem5+=int.Parse(r["Item5"].ToString());
                itogi.ItogoItem6+=int.Parse(r["Vsego1"].ToString());
                itogi.ItogoItem7+=int.Parse(r["Item6"].ToString());
                itogi.ItogoItem8+=int.Parse(r["Item7"].ToString());
                itogi.ItogoItem9+=int.Parse(r["Item8"].ToString());
                itogi.ItogoItem10+=int.Parse(r["Item9"].ToString());
                itogi.ItogoItem11+=int.Parse(r["Item10"].ToString());
                itogi.ItogoItem12+=int.Parse(r["Item11"].ToString());
                itogi.ItogoItem13+=int.Parse(r["Item12"].ToString());
                itogi.ItogoItem14+=int.Parse(r["Item13"].ToString());
                itogi.ItogoItem15+=int.Parse(r["Item14"].ToString());
                itogi.ItogoItem16+=int.Parse(r["Item15"].ToString());
                itogi.ItogoItem17+=int.Parse(r["Vsego2"].ToString());
                itogi.ItogoItem18+=int.Parse(r["Item16"].ToString());
                itogi.ItogoItem19+=int.Parse(r["Item17"].ToString());
                itogi.ItogoItem20+=int.Parse(r["Item18"].ToString());
                itogi.ItogoItem21+=int.Parse(r["Itogo"].ToString());


            }

        }

        private void datagrid_Loaded(object sender, RoutedEventArgs e)
        {
            RaschetItogov(itogi);
        }
    }
}
