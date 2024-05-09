using System;
namespace ObtenerDatosBlog.Domain.IRepository
{
    public interface IExcelRepository
    {
        public void CrearExcelDeUnaColumna(List<string> Urls, int i, string header, string excelResultado, string excelHoja);
        public void CrearExcelKnowledgeBases(string titulo, string contenido, string keywords, int i, string excelHoja, string excelResultado);
        public void CrearExcelKnowledgeBasesSinContenido(string titulo, string keywords, string excelHoja, string excelResultado);
        public List<string> ReadUrlFromExcel(string excelFile);
        public List<string> ReadDataFromExcel(string excelFile);
    }
}
