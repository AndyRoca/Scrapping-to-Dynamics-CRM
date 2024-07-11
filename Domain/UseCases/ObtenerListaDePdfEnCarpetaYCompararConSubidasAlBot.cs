using ObtenerDatosBlog.Domain.IRepository;
using System.Collections.Generic;

namespace ObtenerDatosBlog.Domain.UseCases
{
    public class ObtenerListaDePdfEnCarpetaYCompararConSubidasAlBot
    {
        IExcelRepository _excelRepository;
        ISystemRepository _systemRepository;
        IDataRepository _dataRepository;

        public ObtenerListaDePdfEnCarpetaYCompararConSubidasAlBot(IExcelRepository excelRepository, IPdfRepository pdfRepository, ISystemRepository systemRepository, IDataRepository dataRepository)
        {
            _excelRepository = excelRepository;
            _systemRepository = systemRepository;
            _dataRepository = dataRepository;
        }

        public void Invoke(string folderPath)
        {
            var nombresArchivosBot = _excelRepository.ReadDataFromExcel("ObtenerListaDePdfEnCarpetaYCompararConSubidasAlBot_BotInfo.xlsx");
            var nombresArchivosLimpios = _excelRepository.ReadDataFromExcel("ObtenerListaDePdfEnCarpetaYCompararConSubidasAlBot_SoloTitulos.xlsx");

            Dictionary<string, string> tituloAComparar_nombresBot = new Dictionary<string, string>();

            string logFilePath = "log.txt";

            File.WriteAllText(logFilePath, "");

            for (int i = 0; i < nombresArchivosLimpios.Count; i++)
            {
                try
                {
                    tituloAComparar_nombresBot.Add(nombresArchivosLimpios[i], nombresArchivosBot[i]);
                }
                catch (ArgumentException ex)
                {
                    string logMessage = $"Error: La clave '{nombresArchivosLimpios[i]}' ya existe. Valor intentado: {nombresArchivosBot[i]}\n";
                    File.AppendAllText(logFilePath, logMessage);
                }

            }   
           
            var pdfFiles = _systemRepository.ObtenerPDF(folderPath);

            List<string> nombresArchivosSinExtension = new List<string>();
            foreach (var pdfFile in pdfFiles)
            {
                var nombreArchivoSinExtension = _systemRepository.ObtenerNombresPDF(pdfFile);

                string nombreArchivoSinCaracteresIntermedios = nombreArchivoSinExtension.Replace("_", "")
                                                                                         .Replace("-", "")
                                                                                         .Replace(")", "")
                                                                                         .Replace("(", "")
                                                                                         .Replace(" ", "");

                nombresArchivosSinExtension.Add(nombreArchivoSinCaracteresIntermedios.ToUpper());
            }

            var elementosComunes = _dataRepository.CompararListaBotConExtensionesConListaArchivosSinExtensiones(tituloAComparar_nombresBot, nombresArchivosSinExtension);

            using (StreamWriter writer = new StreamWriter("elementosComunes_Ficheros.txt"))
            {
                foreach (var elemento in elementosComunes)
                {
                    writer.WriteLine($"{elemento}");
                }
            }

            Console.WriteLine("Se han guardado los archivos PDF y sus rutas asociadas en archivos_pdf.txt");
        }
    }
}