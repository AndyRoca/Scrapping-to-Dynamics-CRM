using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObtenerDatosBlog.Domain.IRepository
{
    public interface ISystemRepository
    {
        public List<string> ObtenerRutasPDF(string carpeta);
        public (string, string)[] ObtenerRutasPdfEnCarpetas(string rutaCarpeta);
        public string FormatearRutas(string rutas);
        public string ObtenerNombresPDF(string archivosPDF);
        public void ConvertirEnTxtContenido(string contenido, string titulo);
    }
}
