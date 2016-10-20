// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExcelChartCreator.cs" company="-">
//   Tim Schlagenhaufer
// </copyright>
// <summary>
//   Defines the ExcelChartCreator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataExtractor
{
    using System;
    using System.Collections.Generic;

    using Excel = Microsoft.Office.Interop.Excel;

    /// <summary>
    /// The excel chart creator.
    /// </summary>
    internal class ExcelChartCreator
    {
        /// <summary>
        /// The current path.
        /// </summary>
        private readonly string currentPath = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// The create table.
        /// </summary>
        /// <param name="clientDataList">
        /// The client data list with all the Wi-Fi information separated by the clientNames / clientIds.
        /// </param>
        public void CreateTable(List<ClientData> clientDataList)
        {
            var excel = new Excel.Application();
            object misValue = System.Reflection.Missing.Value;

            // todo: remove later
            excel.Visible = true;

            Excel.Workbook workbook = excel.Workbooks.Add(misValue);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets.Item[1];

            worksheet.Cells[1, 1] = string.Empty;
            worksheet.Cells[1, 2] = "Student1";
            worksheet.Cells[1, 3] = "Student2";
            worksheet.Cells[1, 4] = "Student3";

            worksheet.Cells[2, 1] = "Term1";
            worksheet.Cells[2, 2] = "80";
            worksheet.Cells[2, 3] = "65";
            worksheet.Cells[2, 4] = "45";

            worksheet.Cells[3, 1] = "Term2";
            worksheet.Cells[3, 2] = "78";
            worksheet.Cells[3, 3] = "72";
            worksheet.Cells[3, 4] = "60";

            worksheet.Cells[4, 1] = "Term3";
            worksheet.Cells[4, 2] = "82";
            worksheet.Cells[4, 3] = "80";
            worksheet.Cells[4, 4] = "65";

            worksheet.Cells[5, 1] = "Term4";
            worksheet.Cells[5, 2] = "75";
            worksheet.Cells[5, 3] = "82";
            worksheet.Cells[5, 4] = "68";

            Excel.ChartObjects excelCharts = (Excel.ChartObjects)worksheet.ChartObjects(Type.Missing);
            Excel.ChartObject chart = excelCharts.Add(10, 80, 300, 250);
            Excel.Chart chartPage = chart.Chart;

            var chartRange = worksheet.Range["A1", "d5"];

            chartPage.SetSourceData(chartRange, misValue);
            chartPage.ChartType = Excel.XlChartType.xlColumnClustered;

            workbook.SaveAs(this.currentPath + "export.xlsx", Excel.XlFileFormat.xlWorkbookDefault);

            workbook.Close(0);
            excel.Quit();

            ReleaseObject(worksheet);
            ReleaseObject(workbook);
            ReleaseObject(excel);
        }

        /// <summary>
        /// The release object.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        private static void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occured while releasing object " + ex);
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
