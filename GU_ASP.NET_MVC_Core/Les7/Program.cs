using System;

namespace Les7
{
    class Program
    {
        //Геннадий, добрый день.
        //Структура взята с рабочего проекта, этот анализатор загруженности инженеров.
        //Рабочее место состоит из списка инженеров.
        //У каждого инженера есть список задач(Exercise) разделяющихся на ТЗ и ПЗ
        //По данной структуре я подготовил отчетную форму в ворд


        static void Main(string[] args)
        {
            var rowTable = new Generator(35).RowTable;
            var workPlaceTable = new WorkPlaceTable(rowTable);
            ReportService reportService = new ReportService();
            reportService.GenerateReport(workPlaceTable);
        }
    }
}
