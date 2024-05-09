using ObtenerDatosBlog.Application;

namespace ObtenerDatosBlog.Domain.IRepository
{
    public interface IScrapingRepository
    {
        Task<ScrapingObject> ObtenerTituloyContenido(string url);
        Task<List<string>> ObtenerUrlsPaginasBlog(string url);

    }
}