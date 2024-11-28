using Microsoft.Office.Interop.Excel;
using Spire.Xls;
using SpoServiceSystem.Classes;
using SpoServiceSystem.DataModels;
using SpoServiceSystem.Windows;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpoServiceSystem.Controls
{
    /// <summary>
    /// Логика взаимодействия для AllPrepodsUserControl.xaml
    /// </summary>
    public partial class AllPrepodsUserControl : UserControl
    {
        
        double LeftPanelWidth { get; set; }
        double RightPanelWidth { get; set; }
         MessageWindow messageWindow {  get; set; } 

        public AllPrepodsUserControl()
        {
            InitializeComponent();
            this.Loaded+=AllPrepodsUserControl_Loaded;
            
        }

        private void AllPrepodsUserControl_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            //RaschetItogov();
            
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
           
            base.OnRenderSizeChanged(sizeInfo);
             double width = sizeInfo.NewSize.Width;
          
        }
        private void AllPrepodsUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LeftPanelWidth = Column1.ActualWidth;
            RightPanelWidth = Column2.ActualWidth;
            shiftRightPanelBtn.Visibility = Visibility.Collapsed;

            CollectionView myCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(PrepodsLB.ItemsSource);
            myCollectionView.Filter =  UserFilter;
            //    =new Predicate<object>( (g) => ((PrepodFullItog)g).Fio.ToLower().IndexOf(FioFilterTxt.Text.ToLower()) !=-1);



            // CollectionView myCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(datagrid.ItemsSource);
            //  ((INotifyCollectionChanged)myCollectionView).CollectionChanged += new NotifyCollectionChangedEventHandler(DataGrid_CollectionChanged);
            // ((INotifyCollectionChanged)myCollectionView).CollectionChanged+=AllPrepodsUserControl_CollectionChanged;
        }
        private bool UserFilter(object item)
        {
            PrepodFullItog prep = item as PrepodFullItog;
            if (prep != null)
            {
                if (allRB.IsChecked.Value)
                {
                    return prep.Fio.ToLower().IndexOf(FioFilterTxt.Text.ToLower()) !=-1;
                }
                if (yesRB.IsChecked.Value)
                {
                    return prep.FullSumma >0 &&  prep.Fio.ToLower().IndexOf(FioFilterTxt.Text.ToLower()) !=-1;
                }
                if (noRB.IsChecked.Value)
                {
                    return prep.FullSumma<=0 &&  prep.Fio.ToLower().IndexOf(FioFilterTxt.Text.ToLower()) !=-1;
                }
            }


            return true;
        }
        private void shiftLeftPanelBtn_Click(object sender, RoutedEventArgs e)
        {
            Storyboard storyboard = new Storyboard();
            storyboard.Completed+= (s, e) => {
                shiftLeftPanelBtn.Visibility = Visibility.Collapsed;
                shiftRightPanelBtn.Visibility = Visibility.Visible;
                Column2.MinWidth= AllPrepodsUC.ActualWidth;
                Column1.MaxWidth= AllPrepodsUC.ActualWidth;
              
            };
            Duration duration = new Duration(TimeSpan.FromMilliseconds(1000));
            CubicEase ease = new CubicEase { EasingMode = EasingMode.EaseOut };
            DoubleAnimation animation = new DoubleAnimation();
            animation.EasingFunction = ease;
            animation.Duration = duration;
            storyboard.Children.Add(animation);
            animation.From = LeftPanelWidth;
            animation.To = 0;
            Storyboard.SetTarget(animation, Col1);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(ColumnDefinition.MaxWidth)"));
            storyboard.Begin();
        }

        private void GridSplitter_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
           



            LeftPanelWidth = Column1.ActualWidth;
            RightPanelWidth = Column2.ActualWidth;
        }

        private void shiftRightPanelBtn_Click(object sender, RoutedEventArgs e)
        {
            Storyboard storyboard = new Storyboard();
            storyboard.Completed+= (s, e) => {
                shiftLeftPanelBtn.Visibility = Visibility.Visible;
                shiftRightPanelBtn.Visibility = Visibility.Collapsed;
                Column1.MaxWidth= AllPrepodsUC.ActualWidth;
                Column2.MaxWidth= AllPrepodsUC.ActualWidth;
                Column1.MinWidth=0;
                Column2.MinWidth=0;

            };
            Column2.MinWidth= 0;
            Duration duration = new Duration(TimeSpan.FromMilliseconds(1000));
            CubicEase ease = new CubicEase { EasingMode = EasingMode.EaseOut };
            DoubleAnimation animation = new DoubleAnimation();
            animation.EasingFunction = ease;
            animation.Duration = duration;
            storyboard.Children.Add(animation);
            animation.From = 0;
            animation.To = LeftPanelWidth;
            Storyboard.SetTarget(animation, Col1);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(ColumnDefinition.MaxWidth)"));
            storyboard.Begin();
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Column1.MaxWidth = AllPrepodsUC.ActualWidth;
            
        }

        private void PrepodsLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // MessageBox.Show(((sender as ListBox).SelectedItem as PrepodFullItog).Fio);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            messageWindow = new MessageWindow("Формирование данных по преподавателю");
            messageWindow.Show();
            PrepodFullItog prepodData = (sender as System.Windows.Controls.Button).DataContext as PrepodFullItog;
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork+=Bw_DoWork;
            bw.RunWorkerCompleted+=Bw_RunWorkerCompleted;
            bw.RunWorkerAsync(prepodData.Id);
            PrepodPredmetsData pred = new PrepodPredmetsData(prepodData.Id);
            prepodTB.Text = string.Format("{0} {1} {2}",
                                            prepodData.Fam,
                                            prepodData.Name,
                                            prepodData.Otch);
        }

        private void Bw_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            ItogiTable itogi = grid_futter.DataContext as ItogiTable;
            PrepodPredmetsData data= e.Result as PrepodPredmetsData;
            messageWindow.Close();
            datagrid.ItemsSource = data.GetPlan();
            RaschetItogov(itogi);
            saveExcelBtn.Visibility = Visibility.Visible;
            savePdfBtn.Visibility = Visibility.Visible;


        }

        private void Bw_DoWork(object? sender, DoWorkEventArgs e)
        {
             System.Threading.Thread.Sleep(500);
            int idprepod = int.Parse(e.Argument.ToString());
            PrepodPredmetsData pred = new PrepodPredmetsData(idprepod);
            e.Result = pred;
        }

        #region Таблица по преподавателю-------------------------
        private void dataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

            if ((sender as DataGrid).SelectedItem != null)
                CollectionViewSource.GetDefaultView(datagrid.ItemsSource).Refresh();

        }

        private void datagrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            if (e.EditAction==DataGridEditAction.Commit)
            {




            }
        }
        private void SomeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var item = comboBox.SelectedItem as Predmet;
            DataRowView selectedItem = this.datagrid.CurrentItem as DataRowView;
            selectedItem.Row["index_pr"]=item.Index_pr;

        }
        private void datagrid_CurrentCellChanged(object sender, EventArgs e)
        {

        }
        #endregion
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

        private void grid_futter_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void FioFilterTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
           // if((e.Source as TextBox).Text.Length>2)
               CollectionViewSource.GetDefaultView(PrepodsLB.ItemsSource).Refresh();
        }

        private void sbrosFilterBtn_Click(object sender, RoutedEventArgs e)
        {
            FioFilterTxt.Text = string.Empty;
        }

        private void saveExcelBtn_Click(object sender, RoutedEventArgs e)
        {
            // messageWindow = new MessageWindow("Данная функция находится в разработке!");
            // messageWindow.Show();
            string Filename = string.Format("Учебный план {0} от {1}", prepodTB.Text, DateTime.Now.ToShortDateString());
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = Filename; // Default file name
            dialog.DefaultExt = ".xlsx"; // Default file extension
            dialog.Filter = "Text documents (.xlsx)|*.xlsx"; // Filter files by extension

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                string filename = dialog.FileName;
               // bool yesView = ViewExcel.IsChecked.HasValue ? ViewExcel.IsChecked.Value : false;
                ExcelManager em = new ExcelManager(this, filename, true);
                em.Init();
                em.GeneratePrepodExcelDocument();
                //em.Close();
            }

        }

        private void savePdfBtn_Click(object sender, RoutedEventArgs e)
        {
            XlFixedFormatType paramExportFormat = XlFixedFormatType.xlTypePDF;
            XlFixedFormatQuality paramExportQuality
            = XlFixedFormatQuality.xlQualityStandard;

            bool paramOpenAfterPublish = false;
            bool paramIncludeDocProps = true;
            bool paramIgnorePrintAreas = true;
            object paramFromPage = Type.Missing;
            object paramToPage = Type.Missing;
            object paramMissing = Type.Missing;


            string pdffile = string.Format("Учебный план ({0}).pdf", prepodTB.Text);

            string dir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            string filename = System.IO.Path.Combine(dir, "temp.xlsx");
            string pdffilename= System.IO.Path.Combine(dir, pdffile);
            string pdffilename1 = pdffilename;
            ExcelManager em = new ExcelManager(this, filename, false);
            em.Init();
            em.GeneratePrepodExcelDocument();
       
            em.TargetSheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;


            em.TargetSheet.PageSetup.Zoom=53;
            em.TargetSheet.PageSetup.FitToPagesWide = 1;
            em.TargetSheet.PageSetup.FitToPagesTall = 1;
            // em.TargetSheet.PageSetup.PaperSize= XlPaperSize.xlPaperA3;

            // em.workbook.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, pdffilename);
            em.workbook.ExportAsFixedFormat(paramExportFormat,
                pdffilename, paramExportQuality,
                paramIncludeDocProps, paramIgnorePrintAreas,
                paramFromPage,
                paramToPage, paramOpenAfterPublish,
                paramMissing);
            em.workbook.Close();
            em.excelApp.Quit();
            if (System.IO.File.Exists(pdffilename))
            {
     
                using (Process process = new())
                {
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.FileName = pdffilename;
                    process.Start();
                }

            }


           
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if(PrepodsLB != null)
                CollectionViewSource.GetDefaultView(PrepodsLB.ItemsSource).Refresh();
        }
    }
}
