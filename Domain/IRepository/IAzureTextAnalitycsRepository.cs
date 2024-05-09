using Azure.AI.TextAnalytics;

namespace ObtenerDatosBlog.Domain.IRepository
{
    public interface IAzureTextAnalitycsRepository
    {
        public string ObtenerPalabrasClave(TextAnalyticsClient cliente, string contenido);
    }
}
