using ObtenerDatosBlog.Domain.IRepository;

namespace ObtenerDatosBlog.Domain.UseCases
{
    public class ObtenerRutasPdfEnCarpetas
    {
        IExcelRepository _excelRepository;
        IPdfRepository _pdfRepository;
        ISystemRepository _systemRepository;

        public ObtenerRutasPdfEnCarpetas(IExcelRepository excelRepository, IPdfRepository pdfRepository, ISystemRepository systemRepository)
        {
            _excelRepository = excelRepository;
            _pdfRepository = pdfRepository;
            _systemRepository = systemRepository;
        }

        public void Invoke()
        {
            string folderPath = @"C:\Proyectos\AC\OneDrive_2024-06-04 (1)\Manuales de usuario";
            var pdfFiles = _systemRepository.ObtenerRutasPdfEnCarpetas(folderPath);

            using (StreamWriter writer = new StreamWriter("archivos_pdf.txt"))
            {
                foreach (var (fileName, filePath) in pdfFiles)
                {
                    writer.WriteLine($"{fileName}: {filePath}");
                }
            }

            Console.WriteLine("Se han guardado los archivos PDF y sus rutas asociadas en archivos_pdf.txt");
        }
    }
}