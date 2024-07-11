using ObtenerDatosBlog.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObtenerDatosBlog.Infrastructure.Repositorys
{
    public class DataRepository : IDataRepository
    {
        public List<string> CompararListaBotConExtensionesConListaArchivosSinExtensiones(Dictionary<string, string> tituloAComparar_nombresBot, List<string> listaArchivosSinExtension)
        {
            List<string> elementosComunes = new List<string>();

            foreach (var file in tituloAComparar_nombresBot)
            {
                if (listaArchivosSinExtension.Contains(file.Key.ToUpper()))
                {
                    elementosComunes.Add(file.Value);
                }
            }

            return elementosComunes;
        }
    }
}
