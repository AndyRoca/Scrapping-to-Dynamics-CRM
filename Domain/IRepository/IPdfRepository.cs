using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObtenerDatosBlog.Domain.IRepository
{
    public interface IPdfRepository
    {
        public string ObtenerContenidoPdf(string ruta);
    }
}
