using System;
using DynamicPDF.Api;

namespace PdfHtmlExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Run("DP---API-KEY----", "c:/temp/dynamicpdf-api-samples/out/");
        }

        public static void Run(string apiKey, string basePath)
        {
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;

            // add simple HTML string

            pdf.AddHtml("<html><head><meta charset= 'UTF-8'/><title>Hindi Font का उपयोग</title></head><body><h1>We Can Use Hindi Font</h1><p>इस Page में हम हिन्दी भाषा का उपयोग करेंगे </p>" +
    "<h1>We Can also use Hindi Hex Code</h1><p>&#x0907;&#x0938;&nbsp;Page&nbsp;&#x092E;&#x0947;&#x0902;&nbsp;&#x0939;&#x092E;&nbsp;&#x0939;&#x093F;&#x0928;&#x094D;&#x0926;&#x0940;&nbsp;&#x092D;&#x093E;&#x0937;&#x093E;&nbsp;&#x0909;&#x092A;&#x092F;&#x094B;&#x0917;&nbsp;&#x0915;&#x0930;&#x0947;&#x0902;&#x0917;&#x0947;</p></body></html>");

            // add html from a path on local drive

            //HtmlResource resource = new HtmlResource(System.IO.File.ReadAllText(basePath + "HtmlWithAllTags.html"));
            //pdf.AddHtml(resource);

            // use basepath in an HTML string

            pdf.AddHtml("<html><img src='./images/logo.png'></img><p style='color:red;font-family:verdana;font-size:30px'>Hello DynamicPDF Cloud API</html>", "https://www.dynamicpdf.com");

            Console.Write(PrettyPrintUtil.JsonPrettify(pdf.GetInstructionsJson()));


            PdfResponse pdfResponse = pdf.Process();
            System.IO.File.WriteAllBytes(basePath + "html-output-csharp.pdf", pdfResponse.Content);
        }
    }
}
