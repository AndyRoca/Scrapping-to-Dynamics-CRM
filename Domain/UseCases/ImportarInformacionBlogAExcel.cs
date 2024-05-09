using ObtenerDatosBlog.Domain.IRepository;


namespace ObtenerDatosBlog.Domain.UseCases
{
    public class ImportarInformacionBlogAExcel
    {
        IAzureTextAnalitycsRepository _azureTextAnalitycsRepository;
        IScrapingRepository _scrapingRepository;
        IAzureConnections _azureConnections;
        IExcelRepository _excelRepository;

        public ImportarInformacionBlogAExcel(IAzureTextAnalitycsRepository azureTextAnalitycsRepository, IScrapingRepository scrapingRepository, IAzureConnections azureConnections, IExcelRepository excelRepository) 
        { 
            _azureTextAnalitycsRepository = azureTextAnalitycsRepository;
            _scrapingRepository = scrapingRepository;
            _azureConnections = azureConnections;
            _excelRepository = excelRepository;
        }  

        public void Invoke()
        {
            var archivoExcel = "Excelurls.xlsx";
            var excelResultado = "DatosBlog.xlsx";
            var excelHoja = "KnowledgeBases";
            var urls = _excelRepository.ReadUrlFromExcel(archivoExcel);

            for (int i = 0; i < urls.Count; i++)
            {
                var cliente = _azureConnections.ObtenerCliente();

                var datos = _scrapingRepository.ObtenerTituloyContenido(urls[i]).Result;
                string titulo = datos.Titulo;
                string contenido = datos.Contenido;
                string contenidoRecortado = datos.ContenidoRecortado;

                string keywords = _azureTextAnalitycsRepository.ObtenerPalabrasClave(cliente, contenidoRecortado);
                _excelRepository.CrearExcelKnowledgeBases(titulo, contenido, keywords, i, excelHoja, excelResultado);

                Console.WriteLine(i);
            }

        }
    }
}
