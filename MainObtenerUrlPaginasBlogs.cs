//using ObtenerDatosBlog.Domain.IRepository;
//using ObtenerDatosBlog.Domain.UseCases;
//using ObtenerDatosBlog.Infrastructure.Repositorys;


//namespace InvokeMainObtenerUrlPaginasBlogs
//{
//    public class MainObtenerUrlPaginasBlogs
//    {
//        static void Main()
//        {
//            IScrapingRepository scrapingRepository = new ScrapingRepository();
//            IExcelRepository excelRepository = new ExcelRepository();

//            var obtenerUrls = new ObtenerUrlPaginasBlogs(scrapingRepository, excelRepository);

//            obtenerUrls.Invoke();
//        }
//    }
//}