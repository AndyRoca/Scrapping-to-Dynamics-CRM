using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObtenerDatosBlog.Domain.IRepository
{
    public interface ISystemRepository
    {
        public List<string> ObtenerPDF(string carpeta);
        public (string, string)[] ObtenerNombresyRutasPdfEnCarpetas(string rutaCarpeta);
        public string FormatearRutas(string rutas);
        public string ObtenerNombresPDF(string archivosPDF);
        public void ConvertirEnTxtContenido(string rutaRaiz, string contenido, string titulo);
    }
}
