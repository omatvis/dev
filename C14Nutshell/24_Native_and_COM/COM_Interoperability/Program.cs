using Excel = Microsoft.Office.Interop.Excel;

namespace COM_Interoperability
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var excel = new Excel.Application();
            excel.Visible = true;
            excel.WindowState = Excel.XlWindowState.xlMaximized;
            Excel.Workbook workBook = excel.Workbooks.Add();
            ((Excel.Range)excel.Cells[1, 1]).Font.FontStyle = "Bold";
            ((Excel.Range)excel.Cells[1, 1]).Value2 = "Hello World";
            workBook.SaveAs(@"c:\temp\temp.xlsx");
            workBook.Close();
            excel.Quit();
        }
    }
}
