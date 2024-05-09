using Azure.AI.TextAnalytics;

namespace ObtenerDatosBlog.Domain.IRepository
{
    public interface IAzureConnections
    {
        public TextAnalyticsClient ObtenerCliente();
    }
}
