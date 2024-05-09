//using ObtenerDatosBlog.Domain.IRepository;
//using ObtenerDatosBlog.Domain.UseCases;
//using ObtenerDatosBlog.Infrastructure.Repositorys;
//using Service.AzureConnection;

//namespace InvokeMainImportarInformacionBlogAExcel
//{
//    public class MainImportarInformacionBlogAExcel
//    {
//        static void Main()
//        {
//            IAzureTextAnalitycsRepository azureTextAnalitycsRepository = new AzureTextAnalitycsRepository();
//            IScrapingRepository scrapingRepository = new ScrapingRepository();
//            IAzureConnections azureConnections = new AzureConnections();
//            IExcelRepository excelRepository = new ExcelRepository();

//            var GetKnowledgeArticle = new ImportarInformacionBlogAExcel(azureTextAnalitycsRepository, scrapingRepository, azureConnections, excelRepository);

//            GetKnowledgeArticle.Invoke();
//        }
//    }
//}
