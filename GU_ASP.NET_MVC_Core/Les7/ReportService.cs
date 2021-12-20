using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TemplateEngine.Docx;



namespace Les7
{
    public sealed class ReportService
    {
        public void GenerateReport(WorkPlaceTable workPlaceTable, string output = "")
        {
            if (workPlaceTable is null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(output))
            {
                output = Path.Combine(Directory.GetCurrentDirectory(), "WorkPlaceTable.docx");
            }

            if (File.Exists(output))
            {
                File.Delete(output);
            }

            var projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            var fullPath = $"{projectDirectory}\\TemplateEngine.docx";

            File.Copy(fullPath, output);

            var rows = new List<TableRowContent>();
            foreach (EmployeeLoading item in workPlaceTable.ListEmployeeLoading)
            {
                rows.Add(new TableRowContent(new List<FieldContent>()
                {
                    new FieldContent("Name", item.Name),
                    new FieldContent("CountTechnicalTask", item.CountTechnicalTask.ToString()),
                    new FieldContent("CountOrderPassport", item.CountOrderPassport.ToString()),
                    new FieldContent("CountAllTask", item.CountAllTask.ToString()),
                    new FieldContent("TotalTimeRanTechnicalTask", item.TotalTimeRanTechnicalTask.ToString()),
                    new FieldContent("TotalTimeRanOrderPassport", item.TotalTimeRanOrderPassport.ToString()),
                    new FieldContent("TotalTimeRanAllTask", item.TotalTimeRanAllTask.ToString()),
                    new FieldContent("AverageAgeTechnicalTask", item.AverageAgeTechnicalTask.ToString()),
                    new FieldContent("AverageAgeOrderPassport", item.AverageAgeOrderPassport.ToString()),
                    new FieldContent("AverageAgeAllTask", item.AverageAgeAllTask.ToString())
                })); 
            }

            var valuesToFill = new Content(
                new FieldContent("CountAllOrderPassport", workPlaceTable.CountAllOrderPassport.ToString()),
                new FieldContent("CountAllTechnicalTask", workPlaceTable.CountAllTechnicalTask.ToString()),
                new FieldContent("TotalTimeRanOrderPassportAllEmployees", workPlaceTable.TotalTimeRanOrderPassportAllEmployees.ToString()),
                new FieldContent("TotalTimeRanTechnicalTaskAllEmployees", workPlaceTable.TotalTimeRanTechnicalTaskAllEmployees.ToString()),
                    TableContent.Create("EmployeeLoading", rows)
            );

            using (var outputDocument =
                new TemplateProcessor(output)
                .SetRemoveContentControls(true))
            {
                outputDocument.FillContent(valuesToFill);
                outputDocument.SaveChanges();
            }
        }
    }

    

}
