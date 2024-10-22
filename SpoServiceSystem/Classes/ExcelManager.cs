using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel=Microsoft.Office.Interop.Excel;
using Offise = Microsoft.Office.Core;
using Spire.Xls;
using System.IO;

using Spire.Xls.AI;
using SpoServiceSystem.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

using System.Windows;
using Spire.Xls.Core;
using System.Reflection;
using System.Xml.Linq;
using Microsoft.Office.Interop.Excel;
using System.Drawing;

namespace SpoServiceSystem.Classes
{
    public class ExcelManager
    {
        Excel.Application excelApp = null;
        Excel.Workbook workbook = null;
        UchPlanWindow window;
        float Koefficient;
        string excelPatch;
        string excelFileName;
        bool isVisible = false;
        public string ExcelFileName
        {
            get { return string.Format("{0}\\{1}", excelPatch, excelFileName); } 
        }
        public ExcelManager() {
            excelPatch = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            excelFileName ="test0.xls";
            Koefficient =256F/ (float)System.Windows.SystemParameters.PrimaryScreenWidth;

        }
        public ExcelManager(UchPlanWindow _window) :this() 
        {
            window= _window;
        }
        public ExcelManager(UchPlanWindow _window,string filename,bool visible) : this(_window)
        {
            excelPatch =Path.GetDirectoryName(filename);
            excelFileName =Path.GetFileName(filename);
            isVisible = visible;
        }
        public int Close()
        {
            int result = 0;
            workbook.SaveCopyAs(ExcelFileName);
            excelApp.Quit();
            return result;
        }
        
            public void InitSpireXls()
        {
           /*
            * Workbook wbToStream = new Workbook();
            Worksheet sheet = wbToStream.Worksheets[0];
            sheet.Range["C10"].Text = "The sample demonstrates how to save an Excel workbook to stream.";

            CellRange cr = sheet.Range["C10"];
            cr.Style.Rotation = 90;
            // Specify the angle of rotation of the text.

            


            FileStream file_stream = new FileStream(ExcelFileName, FileMode.Create);
            wbToStream.SaveToStream(file_stream);
            file_stream.Close();
           */
          //  System.Diagnostics.Process.Start(ExcelFileName);
        }
        public void Init()
        {
          
            excelApp = new Excel.Application()
            {
               
                Visible = isVisible,
                //Количество листов в рабочей книге
                SheetsInNewWorkbook = 1
            };
            //Добавить рабочую книгу
            workbook = excelApp.Workbooks.Add(System.Reflection.Missing.Value);
            //Отключить отображение окон с сообщениями
            excelApp.DisplayAlerts = false;
          
        }
        public void SetText()
        {
            Excel.Worksheet objSheet = (Excel.Worksheet)workbook.Sheets[1];
            objSheet.Cells[2, 2] = "Aspose Heading";
            Excel.Range _range = objSheet.get_Range("B2", "B2");
            _range.Orientation = 90;

            // objSheet.Columns[5].ColumnWidth = 30;
            // sheet.Range["A1"].Value = "Пример №2";
            //
            /*
             * //увеличиваем размер по ширине диапазон ячеек
   Excel.Range range2 = sheet.get_Range("D1", "S1");
   range2.EntireColumn.ColumnWidth = 10;
 
 //увеличиваем размер по высоте диапазон ячеек
   Excel.Range rowHeight = sheet.get_Range("A4", "S4"); 
   rowHeight.EntireRow.RowHeight = 50;range.EntireColumn.AutoFit();range.EntireColumn.AutoFit(); //автора

Excel.Range r1 = sheet.Cells[countRow, 2];
Excel.Range r2 = sheet.Cells[countRow, 19];
Excel.Range rangeColor = sheet.get_Range(r1, r2);
rangeColor.Borders.Color = ColorTranslator.ToOle(Color.Black);

Excel.Range r = sheet.get_Range("A1", "S40"); 
  //Оформления
  r.Font.Name = "Calibri";
  r.Cells.Font.Size = 10;
  r.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
  r.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

sheet.Cells[countRow, countColumn] = $"=G{countRow}-F{countRow}";
sheet.Cells[countRow, countColumn].FormulaLocal = $"=ЕСЛИ((H{countRow}*O{countRow})+(I{countRow}*P{countRow})/100<=0;J{countRow}*O{countRow}/100;((H{countRow}*O{countRow})+(I{countRow}*P{countRow}))/100)";
sheet.Cells[countRow, countColumn] = $"=K{countRow}+N{countRow}-R{countRow}"; 
 
sheet.Cells[33, 22].FormulaLocal = "=СУММ(V3:V32)";
            1
ObjWorkSheet.Cells[33, 22].Formula = "=SUM(V3:V32)";

            worksheet.Cell("A5").Formula = "SUM(A1:A3)";
worksheet.Cell("A6").Formula = "1 + 2 + 3";

//Set B2 = A1
worksheet.Cell("B2").FormulaR1C1 = "R[-1]C[-1]";
//Set B3 = A3
worksheet.Cell("B3").FormulaR1C1 = "RC[-1]";
//Set B4 = A5
worksheet.Cell("B4").FormulaR1C1 = "R[1]C[-1]";
//Set B5 = B2 + B3
worksheet.Cell("B5").FormulaR1C1 = "R[-3]C + R[-2]C";

//Calculate the formula for whole workbook
workbook.CalculateMode = CalculateMode.Auto;
workbook.CalculationOnSave = true;





             
             */
            _range.Interior.Color = System.Drawing.ColorTranslator.ToWin32(System.Drawing.Color.FromArgb(0, 51, 105));

            //Set the font color of cell text

            _range.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            workbook.SaveCopyAs(ExcelFileName);

            //Quit the Application.

            excelApp.Quit();

        }

        public void GreateExcelDocument()
        {
            Excel.Worksheet TargetSheet = (Excel.Worksheet)workbook.Sheets[1];
            TargetSheet.Columns.AutoFit();
            int TopRowNumber = 2;
            int TopColumnNumber = 1;
            int ColumnItogo1 = 9;
            int ColumnItogo2 = 20;
            int ColumnItogo3 = 24;
            int MaxColumnNumber = 25;

            Excel.Range TableTopRange = (Excel.Range)TargetSheet.Cells[TopRowNumber, TopColumnNumber];
            int r = TopRowNumber;
            int c = TopColumnNumber;
            List<DataGridColumnHeader> columnHeaders =WpfServises.GetVisualChildCollection<DataGridColumnHeader>(window.datagrid);
            foreach (DataGridColumn column in window.datagrid.Columns)
            {
               // TargetSheet.Columns[c].ColumnWidth = 25;
                string str = string.Empty;
                Excel.Range CurrentRange = (Excel.Range)TableTopRange.Cells[r, c];
                CurrentRange.EntireColumn.ColumnWidth = (column.ActualWidth*Koefficient);
                if (column.Header != null)
                {
                    str = column.Header.ToString();
                    CurrentRange.Value = str;
                    CurrentRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    CurrentRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                }
                else
                {
                    DataGridColumnHeader headerObj = WpfServises.GetColumnHeaderFromColumn(column, window.datagrid);
                    foreach (TextBlock tb in WpfServises.FindVisualChildren<TextBlock>(headerObj))
                    {
                        str+=tb.Text+System.Environment.NewLine;
                    }
                    CurrentRange.Value = str;
                    CurrentRange.Orientation = 90;
                    CurrentRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    if(c==ColumnItogo1 || c==ColumnItogo2 || c==ColumnItogo3)
                    {
                        CurrentRange.Font.Bold = true;
                    }
                }

                c++;

            }
           
            r=TopRowNumber+1;
            var rows = WpfServises.GetDataGridRows(window.datagrid);
            foreach (DataGridRow row in rows)
            {
                string str = string.Empty;
                c=1;
                foreach (DataGridColumn column in window.datagrid.Columns)
                {
                    Excel.Range CurrentRange = (Excel.Range)TableTopRange.Cells[r, c];

                    if (c==ColumnItogo1)
                    {
                        CurrentRange.FormulaR1C1="=RC[-4]+RC[-2]";
                        CurrentRange.Font.Bold = true;
                        c++;
                        continue;
                    }
                    if (c==ColumnItogo2)
                    {
                        CurrentRange.FormulaR1C1="=SUM(RC[-10]:RC[-1])";
                        CurrentRange.Font.Bold = true;
                        c++;
                        continue;
                    }
                    if (c==ColumnItogo3)
                    {
                        CurrentRange.FormulaR1C1="=SUM(RC[-4]:RC[-1])";
                        CurrentRange.Font.Bold = true;
                        c++;
                        continue;
                    }
                    if (column.GetCellContent(row) is TextBlock)
                    {
                        TextBlock cellContent = column.GetCellContent(row) as TextBlock;
                        CurrentRange.Value = cellContent.Text;
                    }
                    else
                    if(column.GetCellContent(row) is ComboBox)
                    {
                     
                        FrameworkElement element = column.GetCellContent(row);
                        System.Type tup = element.GetType();
                        PropertyInfo? fieldInfo = tup.GetProperty("Text", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
                        var value = fieldInfo?.GetValue(element);
                        CurrentRange.Value = value?.ToString();
                    }
                    c++;
                }

                r++;
            }
            //----------- итоги --------------
            c=1;
            int CountRows = r-TopRowNumber-1;
            foreach (DataGridColumn column in window.datagrid.Columns)
            {
                Excel.Range CurrentRange = (Excel.Range)TableTopRange.Cells[r, c];
                if (c==3) {

                    CurrentRange.Value = "ИТОГО:";
                    CurrentRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    CurrentRange.Font.Bold = true;
                }
                if(c>=4)
                {
                    string str = string.Format("=SUM(R[-{0}]C:R[-1]C)", CountRows);
                    CurrentRange.FormulaR1C1 = str;
                    CurrentRange.Font.Bold = true;
                }
                c++;
                if (c==MaxColumnNumber) break;
            }

            Excel.Range range0 = (Excel.Range)TableTopRange.Cells[r-1, 1];
            Excel.Range range1 = (Excel.Range)TableTopRange.Cells[r-1, c];
            Excel.Range rangeColor = (Excel.Range)TableTopRange.get_Range(range0, range1);
            rangeColor.Borders.Color = ColorTranslator.ToOle(Color.Black);
            rangeColor.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(220, 220, 220));

            Excel.Range range90 = (Excel.Range)TableTopRange.Cells[TopRowNumber-1, 9];
            Excel.Range range91 = (Excel.Range)TableTopRange.Cells[r-1, 9];
            Excel.Range range9 = (Excel.Range)TableTopRange.get_Range(range90, range91);
            // range9.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(229, 228, 226));
            range9.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(220, 220, 220));
            range9.Borders.Color = ColorTranslator.ToOle(Color.Black);

            Excel.Range range20 = (Excel.Range)TableTopRange.Cells[TopRowNumber-1, 20];
            Excel.Range range21 = (Excel.Range)TableTopRange.Cells[r-1, 20];
            Excel.Range range2 = (Excel.Range)TableTopRange.get_Range(range20, range21);
            range2.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(220, 220, 220));
            range2.Borders.Color = ColorTranslator.ToOle(Color.Black);

            Excel.Range range30 = (Excel.Range)TableTopRange.Cells[TopRowNumber-1, 24];
            Excel.Range range31 = (Excel.Range)TableTopRange.Cells[r-1, 24];
            Excel.Range range3 = (Excel.Range)TableTopRange.get_Range(range30, range31);
            range3.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(220, 220, 220));
            range3.Borders.Color = ColorTranslator.ToOle(Color.Black);

            TableTopRange.Calculate();

            //--------- Формирование верхней шапки документа
            Excel.Range cellRange = (Excel.Range)TargetSheet.Cells[1, 1];
            Excel.Range rowRange = cellRange.EntireRow;
            rowRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown, false);
            rowRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown, false);
            rowRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown, false);

            SpoServiceSystem.DataModels.Group gr = window.CurrentGroup;
            string spec = string.Format("{0} {1}",gr.Cod_sp,gr.Name_sp);
            int Row = 2;
            int Column = 1;
            SetTitulRangeItem(TargetSheet,Row,2,Column,1,"Профессия"+Environment.NewLine+"Специальность");
            Column =3;
            SetTitulRangeItem(TargetSheet, Row,2, Column, 0, spec);
            Column =4;
            SetTitulRangeItem(TargetSheet, Row,2, Column, 0,"УО");
            Column =5;
            SetTitulRangeItem(TargetSheet, Row,2, Column, 2, gr.Name_uo);
            Column =12;
            Column =8;
            SetTitulRangeItem(TargetSheet, Row,2, Column, 1, "Группа" );
            Column =10;
            SetTitulRangeItem(TargetSheet, Row,2, Column, 1, gr.NameGroup);
            Column =12;
            SetTitulRangeItem(TargetSheet, Row,2, Column, 0, "База" );
            Column =13;
            SetTitulRangeItem(TargetSheet, Row,2, Column, 0, gr.Baza_sp.ToString() );
            Column =14;
            SetTitulRangeItem(TargetSheet, Row,2, Column, 2, "Финансирование");
            Column =17;
            SetTitulRangeItem(TargetSheet, Row,2, Column, 2, gr.Name_tip);
            Column =20;
            SetTitulRangeItem(TargetSheet, Row, 0, Column, 4, "Количество обучающихся");
            SetTitulRangeItem(TargetSheet, Row+1, 0, Column, 4, "1 подгруппа");
            SetTitulRangeItem(TargetSheet, Row+2, 0, Column, 4, "2 подгруппа");
            Column =25;
            SetTitulRangeItem(TargetSheet, Row, 0, Column, 0,gr.Count.ToString());
            SetTitulRangeItem(TargetSheet, Row+1, 0, Column, 0, gr.Count_1.ToString());
            SetTitulRangeItem(TargetSheet, Row+2, 0, Column, 0,gr.Count_1.ToString());
        }

        void SetTitulRangeItem(Excel.Worksheet Sheet,int Row,int count_row, 
            int Column,int count_column,string text)
        {
            Excel.Range Range0 = (Excel.Range)Sheet.Cells[Row, Column];
            Excel.Range Range1 = (Excel.Range)Sheet.Cells[Row+count_row, Column+count_column];
            Excel.Range range10 = Sheet.get_Range(Range1, Range0);
            range10.Merge();
            range10.Borders.Color = ColorTranslator.ToOle(Color.Black);
            range10.Value = text;
            range10.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range10.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter; ;
        }
      

    }
}
