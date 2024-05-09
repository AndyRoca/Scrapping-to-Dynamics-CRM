using Azure;
using Azure.AI.TextAnalytics;
using ObtenerDatosBlog.Domain.IRepository;

namespace Service.AzureConnection
{
    public class AzureConnections : IAzureConnections
    {
        public TextAnalyticsClient ObtenerCliente()
        {
            AzureKeyCredential credential = new AzureKeyCredential("");
            Uri endpoint = new Uri("https://intancia1.cognitiveservices.azure.com/");
            return new TextAnalyticsClient(endpoint, credential);
        }
    }
}