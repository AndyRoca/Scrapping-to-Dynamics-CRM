using ObtenerDatosBlog.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObtenerDatosBlog.Infrastructure.Repositorys
{
    public class SystemRepository : ISystemRepository
    {
        public List<string> ObtenerPDF(string carpeta)
        {
            string[] archivosPDF = Directory.GetFiles(carpeta, "*.pdf", SearchOption.AllDirectories)
                                   .Concat(Directory.GetFiles(carpeta, "*.PDF", SearchOption.AllDirectories))
                                   .ToArray();
            return new List<string>(archivosPDF);
        }

        public (string, string)[] ObtenerNombresyRutasPdfEnCarpetas(string rutaCarpeta)
        {
            var archivosPDF = new List<(string, string)>();

            foreach (var filePath in Directory.GetFiles(rutaCarpeta, "*.pdf", SearchOption.AllDirectories))
            {
                var fileName = Path.GetFileName(filePath);
                archivosPDF.Add((fileName, filePath));
            }

            return archivosPDF.ToArray();
        }

        public string FormatearRutas(string ruta)
        {               
            int indexKBs = ruta.IndexOf("KBs");
            string rutaFormateada = ruta.Replace("\\", ", ");
            string keywords = rutaFormateada.Substring(indexKBs);

            return keywords;
        }
        public string ObtenerNombresPDF(string archivosPDF)
        {
            return Path.GetFileNameWithoutExtension(archivosPDF);
        }

        public void ConvertirEnTxtContenido(string contenido, string titulo, string rutaRaiz)
        {
            using (StreamWriter writer = new StreamWriter(@$"{ rutaRaiz }\{ titulo }.txt", append: true))
            {
                writer.WriteLine(contenido);
            }
        }
    }
}