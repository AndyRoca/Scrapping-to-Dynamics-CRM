//using ObtenerDatosBlog.Domain.IRepository;
//using ObtenerDatosBlog.Domain.UseCases;
//using ObtenerDatosBlog.Infrastructure.Repositorys;

//namespace ObtenerDatosBlog
//{
//    public class MainObtenerInfoPDF
//    {
//        static void Main()
//        {
//            ISystemRepository systemRepository = new SystemRepository();
//            IPdfRepository pdfRepository = new PdfRepository();
//            IExcelRepository excelRepository = new ExcelRepository();

//            var GetKnowledgeArticle = new ObtenerInfoPDF(excelRepository, pdfRepository, systemRepository);

//            GetKnowledgeArticle.Invoke();
//        }
//    }
//}