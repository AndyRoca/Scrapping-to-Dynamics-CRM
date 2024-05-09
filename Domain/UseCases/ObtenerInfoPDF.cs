using ObtenerDatosBlog.Domain.IRepository;

namespace ObtenerDatosBlog.Domain.UseCases
{
    public class ObtenerInfoPDF
    {
        IExcelRepository _excelRepository;
        IPdfRepository _pdfRepository;
        ISystemRepository _systemRepository;

        public ObtenerInfoPDF(IExcelRepository excelRepository, IPdfRepository pdfRepository, ISystemRepository systemRepository)
        {
            _excelRepository = excelRepository;
            _pdfRepository = pdfRepository;
            _systemRepository = systemRepository;
        }

        public void Invoke()
        {
            var archivoExcel = "RutasCarpetas.xlsx";
            var excelResultado = "DatosPdfs.xlsx";
            var excelHoja = "KnowledgeBases";

            var RutasCarpetas = _excelRepository.ReadDataFromExcel(archivoExcel);

            for (int i = 0; i < RutasCarpetas.Count; i++)
            {
                var rutasPdf = _systemRepository.ObtenerRutasPDF(RutasCarpetas[i]);

                if(rutasPdf.Count != 0)
                {
                    for(int j = 0; j < rutasPdf.Count; j++) 
                    {
                        string titulo = _systemRepository.ObtenerNombresPDF(rutasPdf[j]);
                        string contenido = _pdfRepository.ObtenerContenidoPdf(rutasPdf[j]);
                        string keywords = _systemRepository.FormatearRutas(rutasPdf[j]);

                        _systemRepository.ConvertirEnTxtContenido(contenido, titulo);
                        _excelRepository.CrearExcelKnowledgeBasesSinContenido(titulo, keywords, excelHoja, excelResultado);
                    }
                    Console.WriteLine(i);
                }

            }
        }
    }
}