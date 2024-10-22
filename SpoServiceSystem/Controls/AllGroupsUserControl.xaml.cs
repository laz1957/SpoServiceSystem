using Google.Protobuf.Compiler;
using SpoServiceSystem.DataModels;
using SpoServiceSystem.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Diagnostics;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpoServiceSystem.Controls
{
    /// <summary>
    /// Логика взаимодействия для AllGroupsUserControl.xaml
    /// </summary>
    public partial class AllGroupsUserControl : UserControl
    {
        CollectionView viewGroups;
        public AllGroupsUserControl()
        {
            InitializeComponent();

            OpenPlanBtn.Visibility = Visibility.Hidden;
            NewPlanBtn.Visibility= Visibility.Hidden;

            Kvalification kv = new Kvalification(0, "Все категории", "...");
            (KvalificationCB.ItemsSource as ListKvalification).Insert(0, kv);
            Kurs kurs = new Kurs();
            kurs.Id =0;
            kurs.Name = "Все курсы...";
            (kursLB.ItemsSource as Kurses).Insert(0, kurs);

            Otdelenie otd = new Otdelenie();
            otd.Id=0;
            otd.Name="Все отделения...";
            (otdelenieLB.ItemsSource as ListOtdelenie).Insert(0, otd);



            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(specLB.ItemsSource);
            view.Filter = UserFilter;

            viewGroups = (CollectionView)CollectionViewSource.GetDefaultView(groupLB.ItemsSource);
            viewGroups.Filter = GroupsFilter;
           // view.Filter = new Predicate<object>((o) => ((Student)o).StudentName.StartsWith(SearchPattern));

        }
        bool GroupsFilter(object item)
        {
            Predicate<Group> isnull = (Group p) => { return true; };
              Predicate<Group> spec = (Group p) => { return true; };
              Predicate<Group> kurs = (Group p) => { return true; };
              Predicate<Group> otdelenie = (Group p) => { return true; };
            Predicate<Group>? fullfilter = (Group p) => { return true; }; ;
            Group gr = item as Group;
            
            if ((specLB.SelectedItem != null)) spec = new Predicate<Group>((g) => ((Group)g).Id_sp ==(specLB.SelectedItem as Specialnost).Id);
            if(otdelenieLB.SelectedItem != null) otdelenie +=new Predicate<Group>((g) => ((Group)g).Id_uo ==(otdelenieLB.SelectedItem as Otdelenie).Id);
            if(kursLB.SelectedItem != null) kurs +=new Predicate<Group>((g) => ((Group)g).Kurs ==(kursLB.SelectedItem as Kurs).Id);
            return spec(gr) && kurs(gr) && otdelenie(gr);





        }
        bool GroupsFilter1(object item)
        {
            if ((specLB.SelectedItem == null) && (kursLB.SelectedItem==null) &&(otdelenieLB.SelectedItem == null)) return true;

            if ((specLB.SelectedItem != null) && (kursLB.SelectedItem!=null))
            {
                return ((item as Group).Id_sp==(specLB.SelectedItem as Specialnost).Id)
                        && (item as Group).Kurs==(kursLB.SelectedItem as Kurs).Id;
            }
            if ((otdelenieLB.SelectedItem != null))
            {
                return ((item as Group).Id_sp==(otdelenieLB.SelectedItem as Otdelenie).Id);
            }
            if ((kursLB.SelectedItem != null))
            {
                return (item as Group).Kurs==(kursLB.SelectedItem as Kurs).Id; ;
            }
            return true;

        }
        private bool UserFilter(object item)
        {
            if (KvalificationCB.SelectedItem == null)
                return true;
            else
                if ((KvalificationCB.SelectedItem as Kvalification).Id==0) return true;
                else
                  return ((item as Specialnost).Id_kf==(KvalificationCB.SelectedItem as Kvalification).Id);
        }
        private void KvalificationCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(specLB.ItemsSource).Refresh();
        }
        private void otdelenieLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Otdelenie otd = (sender as ListBox).SelectedItem as Otdelenie;
            if (otd != null)
                if (otd.Id==0) otdelenieLB.SelectedItem=null;
            CollectionViewSource.GetDefaultView(groupLB.ItemsSource).Refresh();
            OpenPlanBtn.Visibility = Visibility.Hidden;
            NewPlanBtn.Visibility= Visibility.Hidden;

        }
        private void groupLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (groupLB.SelectedItem != null)
            {
                Group grpup = groupLB.SelectedItem as Group;
                if (grpup != null)
                    {
                        if (grpup.groupPlanInfo.Count==0)
                        {
                            OpenPlanBtn.Visibility = Visibility.Hidden;
                            NewPlanBtn.Visibility= Visibility.Visible;
                        }
                        else
                        {
                            OpenPlanBtn.Visibility = Visibility.Visible;
                            NewPlanBtn.Visibility= Visibility.Hidden;
                        }
                    }
            }
         
        }

        private void specLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(groupLB.ItemsSource).Refresh();
           
            {
                OpenPlanBtn.Visibility = Visibility.Hidden;
                NewPlanBtn.Visibility= Visibility.Hidden;
            }
        }
        private void kursLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Kurs kurs = (sender as ListBox).SelectedItem as Kurs;
            if (kurs != null)
                if (kurs.Id==0) kursLB.SelectedItem=null;
           
            CollectionViewSource.GetDefaultView(groupLB.ItemsSource).Refresh();
            if (viewGroups.Count==0)
            {
                OpenPlanBtn.Visibility = Visibility.Hidden;
                NewPlanBtn.Visibility= Visibility.Hidden;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sbrosBtn_Click(object sender, RoutedEventArgs e)
        {
              specLB.SelectedItem = null;
            KvalificationCB.SelectedIndex = 0;
            kursLB.SelectedItem = null;
            otdelenieLB.SelectedItem = null;

        }

        private void OpenPlanBtn_Click(object sender, RoutedEventArgs e)
        {
            if((sender as FrameworkElement).DataContext != null)
            {
                Group gr = (sender as FrameworkElement).DataContext as Group;
                if(gr != null)
                {
                    UchPlanWindow upw = new UchPlanWindow(gr,1);
                    upw.Show();

                }
            }
        }

        private void NewPlanBtn_Click(object sender, RoutedEventArgs e)
        {
            
                Group gr = (sender as FrameworkElement).DataContext as Group;
            if (gr != null)
            {
                UchPlanGroup upg = new UchPlanGroup(gr);
                upg.GetNewUchPlan();
                UchPlanWindow upw = new UchPlanWindow(gr);
                upw.Show();

            }
        }

      
    }
}
