using SpoServiceSystem.DataModels;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AllKursesUchPlansWindow.xaml
    /// </summary>
    public partial class AllKursesUchPlansWindow : Window
    {
        public Specialnost CurrentSpecialnost { get; set; }
        UchebPlan[] uchebPlans { get; set; }
        public AllKursesUchPlansWindow()
        { 
            InitializeComponent();
        }
        public AllKursesUchPlansWindow(Specialnost spec) : this()
        {
            CurrentSpecialnost = spec;
            uchebPlans = new UchebPlan[4];
            InitData();
        }
        void InitData()
        {
            for(int i=0; i !=uchebPlans.Length;i++)
            {
                uchebPlans[i] = new UchebPlan(CurrentSpecialnost.Id, i+1);
            }
            datagrid1.TableView=uchebPlans[0].GetPlan();
            datagrid2.TableView=uchebPlans[1].GetPlan();
            datagrid3.TableView=uchebPlans[2].GetPlan();
            datagrid4.TableView=uchebPlans[3].GetPlan();
        }
    }
}
