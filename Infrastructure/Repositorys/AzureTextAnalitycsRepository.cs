using Azure.AI.TextAnalytics;
using ObtenerDatosBlog.Domain.IRepository;

namespace ObtenerDatosBlog.Infrastructure.Repositorys
{
    public class AzureTextAnalitycsRepository : IAzureTextAnalitycsRepository
    {
        public string ObtenerPalabrasClave(TextAnalyticsClient client, string contentString)
        {
            if(!String.IsNullOrEmpty(contentString))
            {
                List<string> keyWords = new List<string>();

                var response = client.ExtractKeyPhrases(contentString);
                int maxKeywords = response.Value.Count() > 10 ? 10 : response.Value.Count();

                for (int i = 0; i < maxKeywords; i++)
                {
                    keyWords.Add(response.Value[i]);
                }
                return string.Join(", ", keyWords);
            }
            return $"FALLO---";
        }
    }
}