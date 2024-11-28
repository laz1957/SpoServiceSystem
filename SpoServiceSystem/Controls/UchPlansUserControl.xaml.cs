using Microsoft.Office.Interop.Excel;
using Org.BouncyCastle.Crypto;
using SpoServiceSystem.Classes;
using SpoServiceSystem.DataModels;
using SpoServiceSystem.Windows;
using System;
using System.Collections.Generic;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpoServiceSystem.Controls
{
    /// <summary>
    /// Логика взаимодействия для UchPlansUserControl.xaml
    /// </summary>
    public partial class UchPlansUserControl : UserControl
    {
        MessageWindow messageWindow { get; set; }
        UchebPlan uchebPlan {  get; set; }

        string NameCurrentUchPlan { get; set; }
        public UchPlansUserControl()
        {
            InitializeComponent();

            datagrid.LoadingRow+=Datagrid_LoadingRow;

        }

        private void Datagrid_LoadingRow(object? sender, DataGridRowEventArgs e)
        {
           

            DataRowView drw = (e.Row.Item as DataRowView);
            drw.PropertyChanged+=Drw_PropertyChanged;
        }

        private void Drw_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            ItogiTable itogi = grid_futter.DataContext as ItogiTable;
            RaschetItogov(itogi);
            uchebPlan.StringStatus="MODIFICATE";
            statusTB.Text = uchebPlan.StringStatus;
        }

        private void uchPlansUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CollectionView myCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(specialnostLB.ItemsSource);
            myCollectionView.Filter
                =new Predicate<object>((g) => ((Specialnost)g).FullName.ToLower().IndexOf(filterTB.Text.ToLower()) !=-1);
        }
        private void kursesCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void specialnostLB_Loaded(object sender, RoutedEventArgs e)
        {

        }

        BackgroundWorker bWorker;
        private void specialnostLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (kursesCB.SelectedItem != null) 
            {
                if (specialnostLB.SelectedItem != null)
                {
                    messageWindow = new MessageWindow("Формирование данных");
                    messageWindow.Show();
                    NameCurrentUchPlan = (specialnostLB.SelectedValue as Specialnost).Name+" - "+(kursesCB.SelectedItem as Kurs).Name;
                    int[] arguments = { (specialnostLB.SelectedValue as Specialnost).Id, (int)kursesCB.SelectedValue };
                    bWorker = new BackgroundWorker();
                    bWorker.DoWork+=BWorker_DoWork;
                    bWorker.RunWorkerCompleted+=BWorker_RunWorkerCompleted;
                    bWorker.RunWorkerAsync(arguments);
                }

            }
            else
                MessageBox.Show("Необходимо выбрать номер курса!!!");
        }

        private void BWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            ItogiTable itogi = grid_futter.DataContext as ItogiTable;
            uchebPlan = e.Result as UchebPlan;
            messageWindow.Close();
            datagrid.ItemsSource = uchebPlan.GetPlan();
            RaschetItogov(itogi);
            statusTB.Text= uchebPlan.StringStatus;
           // saveExcelBtn.Visibility = Visibility.Visible;
           // savePdfBtn.Visibility = Visibility.Visible;
            if (uchebPlan.StringStatus == "NEW")
            {
                newUchPlan.Visibility = Visibility.Visible;
                saveUchPlan.Visibility = Visibility.Hidden;
                deleteUchPlan.Visibility = Visibility.Hidden;
                saveExcelBtn.Visibility= Visibility.Hidden;
                savePdfBtn.Visibility= Visibility.Hidden;


            }
            else
            {
                saveUchPlan.Visibility = Visibility.Visible;
                deleteUchPlan.Visibility = Visibility.Visible;
                saveExcelBtn.Visibility= Visibility.Visible;
                savePdfBtn.Visibility= Visibility.Visible;
                newUchPlan.Visibility = Visibility.Hidden;
            }


        }

        private void BWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            int idSpec = ((int[])e.Argument)[0];
            int kurs = ((int[])e.Argument)[1];
            UchebPlan uplan = new UchebPlan(idSpec, kurs);
            e.Result = uplan;
        }

        private void dataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

            if ((sender as DataGrid).SelectedItem != null)
                CollectionViewSource.GetDefaultView(datagrid.ItemsSource).Refresh();

        }
        private void datagrid_CurrentCellChanged(object sender, EventArgs e)
        {
         //   ItogiTable itogi = grid_futter.DataContext as ItogiTable;
         //   RaschetItogov(itogi);
        }
        private void datagrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            if (e.EditAction==DataGridEditAction.Commit)
            {
                
              //  ItogiTable itogi = grid_futter.DataContext as ItogiTable;
              //  RaschetItogov(itogi);
            }
        }
        private void saveExcelBtn_Click(object sender, RoutedEventArgs e)
        {
           
            // messageWindow = new MessageWindow("Данная функция находится в разработке!");
            // messageWindow.Show();
            string Filename = string.Format("Учебный план {0} от {1}", NameCurrentUchPlan, DateTime.Now.ToShortDateString());
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
                em.GenerateUchPlanDocument();
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


            string pdffile = string.Format("Учебный план ({0}).pdf", NameCurrentUchPlan);

            string dir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            string filename = System.IO.Path.Combine(dir, "temp.xlsx");
            string pdffilename = System.IO.Path.Combine(dir, pdffile);
            string pdffilename1 = pdffilename;
            ExcelManager em = new ExcelManager(this, filename, false);
            em.Init();
            em.GenerateUchPlanDocument();

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

        private void saveUchPlan_Click(object sender, RoutedEventArgs e)
        {
            if (uchebPlan != null)
            {
                uchebPlan.UpdateUchPlan();
                statusTB.Text= uchebPlan.StringStatus;
            }
        }

        private void filterTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(specialnostLB.ItemsSource).Refresh();
        }

        private void deleteUchPlan_Click(object sender, RoutedEventArgs e)
        {

            if (uchebPlan != null)
            {
                uchebPlan.DeleteUchPlan();
                statusTB.Text= uchebPlan.StringStatus;

            }
        }
        private void newUchPlan_Click(object sender, RoutedEventArgs e)
        {

            if (uchebPlan != null)
            {
                uchebPlan.AppendNewUchPlan();
                statusTB.Text= uchebPlan.StringStatus;
            }
        }
    }
}
