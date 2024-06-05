using ObtenerDatosBlog.Domain.IRepository;
using ObtenerDatosBlog.Domain.UseCases;
using ObtenerDatosBlog.Infrastructure.Repositorys;

namespace ObtenerDatosBlog
{
    public class MainObtenerRutasPdfEnCarpetas
    {
        static void Main()
        {
            ISystemRepository systemRepository = new SystemRepository();
            IPdfRepository pdfRepository = new PdfRepository();
            IExcelRepository excelRepository = new ExcelRepository();

            var RutasConPDF = new ObtenerRutasPdfEnCarpetas(excelRepository, pdfRepository, systemRepository);

            RutasConPDF.Invoke();
        }
    }
}