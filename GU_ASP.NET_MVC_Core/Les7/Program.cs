using System;

namespace Les7
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowTable = new Generator(35).RowTable;
            var workPlaceTable = new WorkPlaceTable(rowTable);
            ReportService reportService = new ReportService();
            reportService.GenerateReport(workPlaceTable);
        }
    }
}
