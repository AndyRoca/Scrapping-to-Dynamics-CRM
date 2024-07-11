using ObtenerDatosBlog.Domain.IRepository;
using ObtenerDatosBlog.Domain.UseCases;
using ObtenerDatosBlog.Infrastructure.Repositorys;

namespace ObtenerDatosBlog
{
    public class MainObtenerListaDePdfEnCarpetaYCompararConSubidasAlBot
    {
        static void Main()
        {
            ISystemRepository systemRepository = new SystemRepository();
            IPdfRepository pdfRepository = new PdfRepository();
            IExcelRepository excelRepository = new ExcelRepository();
            IDataRepository dataRepository = new DataRepository();

            var ObtenerListaDePdfEnCarpetaYCompararConSubidasAlBot = new ObtenerListaDePdfEnCarpetaYCompararConSubidasAlBot(excelRepository, pdfRepository, systemRepository, dataRepository);

            ObtenerListaDePdfEnCarpetaYCompararConSubidasAlBot.Invoke("C:\\Proyectos\\AC\\KBs\\Knowledge Base\\Fichas Técnicas");
        }
    }
}