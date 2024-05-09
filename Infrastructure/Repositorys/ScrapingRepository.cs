using ObtenerDatosBlog.Domain.IRepository;
using PuppeteerSharp;
using ObtenerDatosBlog.Application;


namespace ObtenerDatosBlog.Infrastructure.Repositorys
{
    public class ScrapingRepository : IScrapingRepository

    {
        public async Task<ScrapingObject> ObtenerTituloyContenido(string url) 
        {
            var scrapingObject = new ScrapingObject();
            string chrome = @"C:\Program Files\Google\Chrome\Application\chrome.exe";

            using var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync();

            await using var browser = await Puppeteer.LaunchAsync(
                new LaunchOptions
                {
                    Headless = true,
                    ExecutablePath = chrome,
                }
            );

            await using var page = await browser.NewPageAsync();
            await page.GoToAsync(url);

            List<string> title = new List<string>();

            var titleResult = await page.EvaluateFunctionAsync("() => {" +
                "const a = document.querySelectorAll('.post__title');" +
                "const res = [];" +
                "for (let i = 0; i < a.length; i++)" +
                "   res.push(a[i].innerText);" +
                "return res;" +
                "}");


            if (!titleResult.HasValues)
            {
                scrapingObject.Titulo = $"FALLO---{url}";
                scrapingObject.Contenido = $"FALLO---{url}";

                return scrapingObject;
            } 
            else 
            {
                foreach (var e in titleResult)
                {
                    title.Add(e.ToString());
                }
                scrapingObject.Titulo = title.FirstOrDefault().ToString();
            }
            
            List<string> content = new List<string>();

            var contentResult = await page.EvaluateFunctionAsync("() => {" +
                "const a = document.querySelectorAll('.post__container p, h2');" +
                "const res = [];" +
                "for (let i = 0; i < a.length; i++)" +
                "   res.push(a[i].innerText);" +
                "return res;" +
                "}");

            if (!contentResult.HasValues)
            {
                scrapingObject.Contenido = $"FALLO---{url}";
                return scrapingObject;
            }
            else
            {
                foreach (var e in contentResult)
                {
                    string value = e.ToString();
                    if (value != "Tabla de contenidos")
                        content.Add(value);
                }
                content.Add($"Artículo del blog: {url}");

                scrapingObject.Contenido = string.Join("\n", content);
                scrapingObject.ContenidoRecortado = scrapingObject.Contenido.Substring(0, Math.Min(5120, scrapingObject.Contenido.Length));
            }
                
            return scrapingObject;
        }

        public async Task<List<string>> ObtenerUrlsPaginasBlog(string url)
        {
            var scrapingObject = new ScrapingObject();
            string chrome = @"C:\Program Files\Google\Chrome\Application\chrome.exe";

            using var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync();

            await using var browser = await Puppeteer.LaunchAsync(
                new LaunchOptions
                {
                    Headless = true,
                    ExecutablePath = chrome,
                }
            );

            await using var page = await browser.NewPageAsync();
            await page.GoToAsync(url);

            List<string> Urls = new List<string>();

            var titleResult = await page.EvaluateFunctionAsync("() => {" +
                "const a = document.querySelectorAll('.card-post__container__details__link');" +
                "const res = [];" +
                "for (let i = 0; i < a.length; i++)" +
                "   res.push(a[i].href);" +
                "return res;" +
                "}");

            foreach (var e in titleResult)
            {
                Urls.Add(e.ToString());
            }     

            return Urls;
        }

    }
}
