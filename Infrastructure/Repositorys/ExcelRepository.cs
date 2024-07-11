using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using ObtenerDatosBlog.Domain.IRepository;

namespace ObtenerDatosBlog.Infrastructure.Repositorys
{
    public class ExcelRepository : IExcelRepository
    {        
        public void CrearExcelDeUnaColumna(List<string> datos, int i, string header, string excelResultado, string excelHoja)
        {
            if (i == 0)
            {
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add($"{excelHoja}");

                worksheet.Cell(1, 1).Value = $"{ header }";

                workbook.SaveAs(@$"C:\Proyectos\AC\{ excelResultado }");
            }

            using (var workbook = new XLWorkbook(@$"C:\Proyectos\AC\{ excelResultado }"))
            {
                var worksheet = workbook.Worksheet($"{ excelHoja }");
                int lastRow = worksheet.LastRowUsed().RowNumber();

                foreach (var dato in datos)
                {
                    if (worksheet.Cell(lastRow + 1, 1).IsEmpty())
                    {
                        worksheet.Cell(lastRow + 1, 1).Value = dato;
                    }
                    else
                    {
                        worksheet.Row(lastRow + 1).InsertRowsAbove(1);
                        worksheet.Cell(lastRow + 1, 1).Value = dato;
                    }
                    lastRow++;

                }
                workbook.Save();
            }
        }    

        public void CrearExcelKnowledgeBases(string titulo, string contenido, string keywords, int i, string excelHoja, string excelResultado)
        {
            string filePath = @$"C:\Proyectos\AC\{excelResultado}";

            if (!File.Exists(filePath))
            {
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add($"{excelHoja}");

                worksheet.Cell(1, 1).Value = "Título";
                worksheet.Cell(1, 2).Value = "Contenido";
                worksheet.Cell(1, 3).Value = "Palabras clave";
                worksheet.Cell(1, 4).Value = "stateCode";
                worksheet.Cell(1, 5).Value = "statusCode";

                worksheet.Cell(i + 2, 1).Value = titulo;
                worksheet.Cell(i + 2, 2).Value = contenido;
                worksheet.Cell(i + 2, 3).Value = keywords;
                worksheet.Cell(i + 2, 4).Value = 3;
                worksheet.Cell(i + 2, 5).Value = 7;

                workbook.SaveAs(filePath);
            }

            using (var workbook = new XLWorkbook(@$"C:\Proyectos\AC\{excelResultado}"))
            {
                var worksheet = workbook.Worksheet($"{excelHoja}");

                worksheet.Cell(i + 2, 1).Value = titulo;
                worksheet.Cell(i + 2, 2).Value = contenido;
                worksheet.Cell(i + 2, 3).Value = keywords;
                worksheet.Cell(i + 2, 4).Value = 3;
                worksheet.Cell(i + 2, 5).Value = 7;

                workbook.Save();
            }           
        }

        public void CrearExcelKnowledgeBasesSinContenido(string titulo, string keywords, string excelHoja, string excelResultado)
        {
            string filePath = @$"C:\Proyectos\AC\{excelResultado}";

            if (!File.Exists(filePath))
            {
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add($"{excelHoja}");

                worksheet.Cell(1, 1).Value = "Título";
                worksheet.Cell(1, 2).Value = "Palabras clave";
                worksheet.Cell(1, 3).Value = "stateCode";
                worksheet.Cell(1, 4).Value = "statusCode";

                int lastRow = worksheet.LastRowUsed().RowNumber();

                worksheet.Cell(lastRow + 1, 1).Value = titulo;
                worksheet.Cell(lastRow + 1, 2).Value = keywords;
                worksheet.Cell(lastRow + 1, 3).Value = 3;
                worksheet.Cell(lastRow + 1, 4).Value = 7;

                workbook.SaveAs(filePath);
            }
            else
            {
                using (var workbook = new XLWorkbook(@$"C:\Proyectos\AC\{excelResultado}"))
                {
                    var worksheet = workbook.Worksheet($"{excelHoja}");

                    int lastRow = worksheet.LastRowUsed().RowNumber();

                    worksheet.Cell(lastRow + 1, 1).Value = titulo;
                    worksheet.Cell(lastRow + 1, 2).Value = keywords;
                    worksheet.Cell(lastRow + 1, 3).Value = 3;
                    worksheet.Cell(lastRow + 1, 4).Value = 7;

                    workbook.Save();
                }
            }
        }

        public List<string> ReadUrlFromExcel(string excelFile)
        {
            string filePath = @$"C:\Proyectos\AC\{ excelFile }";
            string sheetName = "KnowledgeBases";
            var columnNumber = 1;
            var data = new List<string>();

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(sheetName);
                var rowCount = worksheet.RowsUsed().Count();

                for (int row = 1; row <= rowCount; row++)
                {
                    var cellValue = worksheet.Cell(row, columnNumber).Value.ToString();
                    if (Uri.TryCreate(cellValue, UriKind.Absolute, out Uri uriResult))
                    {
                        data.Add(uriResult.ToString());
                    }
                }
            }
            return data;
        }

        public List<string> ReadDataFromExcel(string excelFile)
        {
            string filePath = @$"C:\Proyectos\AC\{excelFile}";
            string sheetName = "KnowledgeBases";
            var columnNumber = 1;
            var data = new List<string>();

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(sheetName);
                var rowCount = worksheet.RowsUsed().Count();

                for (int row = 1; row <= rowCount; row++)
                {
                    var cellValue = worksheet.Cell(row, columnNumber).Value.ToString();
                    data.Add(cellValue);
                }
            }
            return data;
        }
    }
}