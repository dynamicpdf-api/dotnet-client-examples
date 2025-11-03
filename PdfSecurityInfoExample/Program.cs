using DynamicPdfClientLibraryExamples.Examples;
using DynamicPdfClientLibraryExamples.Utility;

namespace PdfSecurityInfoProject
{
    class Program
    {
        private const string basePath = "../DynamicPdfClientLibraryExamples/Resources/security-info/";
        private const string apiKey = ""DP--api-key--";

        static void Main(string[] args)
        {
            PdfSecurityInfoExample.Run(apiKey, FileUtility.GetPath(basePath));
        }
    }
}
