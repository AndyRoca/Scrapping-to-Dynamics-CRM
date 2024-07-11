using ObtenerDatosBlog.Domain.IRepository;

namespace ObtenerDatosBlog.Domain.UseCases
{
    public class ObtenerRutasPdfEnCarpetas
    {
        ISystemRepository _systemRepository;

        public ObtenerRutasPdfEnCarpetas(ISystemRepository systemRepository)
        {
            _systemRepository = systemRepository;
        }

        public void Invoke()
        {
            string folderPath = @"C:\Proyectos\AC\OneDrive_2024-06-04 (1)\Manuales de usuario";
            var pdfFiles = _systemRepository.ObtenerNombresyRutasPdfEnCarpetas(folderPath);

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