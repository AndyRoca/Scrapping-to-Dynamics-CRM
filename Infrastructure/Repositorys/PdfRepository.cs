using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf;
using ObtenerDatosBlog.Domain.IRepository;
using System.Text;


namespace ObtenerDatosBlog.Infrastructure.Repositorys
{
    public class PdfRepository : IPdfRepository
    {
        public string ObtenerContenidoPdf(string ruta)
        {
            PdfDocument pdfDocument = new PdfDocument(new PdfReader(ruta));
            StringBuilder extractedText = new StringBuilder();

            for (int pageNum = 1; pageNum <= pdfDocument.GetNumberOfPages(); pageNum++)
            {
                PdfPage page = pdfDocument.GetPage(pageNum);
                ITextExtractionStrategy strategy = new LocationTextExtractionStrategy();
                string pageText = PdfTextExtractor.GetTextFromPage(page, strategy);

                extractedText.Append(pageText);
            }

            string contenido = extractedText.ToString();

            return contenido;
        }
    }
}
