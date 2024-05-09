using ObtenerDatosBlog.Domain.IRepository;

namespace ObtenerDatosBlog.Domain.UseCases
{
    public class ObtenerUrlPaginasBlogs
    {
        IScrapingRepository _scrapingRepository;
        IExcelRepository _excelRepository;

        public ObtenerUrlPaginasBlogs(IScrapingRepository scrapingRepository, IExcelRepository excelRepository)
        {
            _scrapingRepository = scrapingRepository;
            _excelRepository = excelRepository;
        }

        public void Invoke()
        {
            var archivoExcel = "ExcelPagesUrls.xlsx";
            var header = "Urls";
            var excelResultado = "UrlsDatosBlog.xlsx";
            var excelHoja = "KnowledgeBases";

            var urls = _excelRepository.ReadDataFromExcel(archivoExcel);

            for (int i = 0; i < urls.Count; i++)
            {
                var datos = _scrapingRepository.ObtenerUrlsPaginasBlog(urls[i]).Result;

                _excelRepository.CrearExcelDeUnaColumna(datos, i, header, excelResultado, excelHoja);
            }
        }
    }
}
