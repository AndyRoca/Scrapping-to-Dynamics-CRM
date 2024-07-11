using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObtenerDatosBlog.Domain.IRepository
{
    public interface IDataRepository
    {
        List<string> CompararListaBotConExtensionesConListaArchivosSinExtensiones(Dictionary<string, string> tituloAComparar_nombresBot, List<string> listaArchivosSinExtension);
    }
}
