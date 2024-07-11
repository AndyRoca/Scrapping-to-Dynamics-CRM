using ObtenerDatosBlog.Domain.IRepository;

namespace ObtenerDatosBlog.Domain.UseCases
{
    public class ObtenerPdfEnCarpetaYConvertirlosEnTxt
    {
        IExcelRepository _excelRepository;
        IPdfRepository _pdfRepository;
        ISystemRepository _systemRepository;

        public ObtenerPdfEnCarpetaYConvertirlosEnTxt(IExcelRepository excelRepository, IPdfRepository pdfRepository, ISystemRepository systemRepository)
        {
            _excelRepository = excelRepository;
            _pdfRepository = pdfRepository;
            _systemRepository = systemRepository;
        }

        public void Invoke(string folderPath)
        {
            var rutaRaiz = "C:\\Proyectos\\AC\\FichasTecnicas";
            var pdfFiles = _systemRepository.ObtenerPDF(folderPath);

            using (StreamWriter writer = new StreamWriter("archivos_pdf.txt"))
            {
                foreach (var filePath in pdfFiles)
                {
                    string titulo = _systemRepository.ObtenerNombresPDF(filePath);
                    string contenido = _pdfRepository.ObtenerContenidoPdf(filePath);

                    _systemRepository.ConvertirEnTxtContenido(rutaRaiz, contenido, titulo);
                }
            }

            Console.WriteLine("Se han guardado los archivos PDF y sus rutas asociadas en archivos_pdf.txt");
        }
    }
}