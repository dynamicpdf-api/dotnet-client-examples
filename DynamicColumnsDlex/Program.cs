using DynamicPDF.Api;
using System;
using System.IO;
using System.Text;
using System.Xml;

namespace DynamicColumnsDlex
{
    class Program
    {
        static string BASEPATH = "c:/temp/dynamicpdf-api-samples/columns/";
        static string APIKEY = "DP.xxx-api-key-xxx";

        static void Main(string[] args)
        {
            RunOriginal(APIKEY, BASEPATH + "report-with-cover-page.json", "samples/blog-dynamic-columns/report-with-cover-page.dlex", BASEPATH + "report-with-cover-page-original-output.pdf");
            XmlDocument doc = ModifyDlexDocument(BASEPATH + "report-with-cover-page.dlex");
            RunDlex(APIKEY, BASEPATH + "report-with-cover-page.json", doc, BASEPATH + "report-with-cover-page-output.pdf");
        }

        public static void RunDlex(string apiKey, string layoutDataPath, XmlDocument doc, string outputPath)
        {
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;

            LayoutDataResource layoutDataResource = new LayoutDataResource(layoutDataPath);

            DlexResource dlexResource = new DlexResource(Encoding.Default.GetBytes(doc.OuterXml));

            pdf.AddAdditionalResource(BASEPATH + "NorthwindLogo.gif");
            pdf.AddDlex(dlexResource, layoutDataResource);

            Console.WriteLine(pdf.GetInstructionsJson());
            PdfResponse pdfResponse = pdf.Process();

            if (pdfResponse.IsSuccessful)
            {
                File.WriteAllBytes(outputPath, pdfResponse.Content);
            }
            else
            {
                Console.WriteLine(pdfResponse.ErrorJson);
            }
        }


        public static XmlDocument ModifyDlexDocument(string dlexFile)
        {
            XmlDocument doc = new XmlDocument();
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("dpdf", "https://www.dynamicpdf.com");

            doc.Load(dlexFile);


            string xpathExpression = "//dpdf:label[@id='qtyperunitlabel']";
            XmlNode nodeToRemove = doc.DocumentElement.SelectSingleNode(xpathExpression, nsmgr);
            string xValue = nodeToRemove.Attributes["x"].Value;
            nodeToRemove.ParentNode.RemoveChild(nodeToRemove);

            xpathExpression = "//dpdf:recordBox[@id='qtyperunitbox']";
            nodeToRemove = doc.DocumentElement.SelectSingleNode(xpathExpression, nsmgr);
            nodeToRemove.ParentNode.RemoveChild(nodeToRemove);

            xpathExpression = "//dpdf:label[@id='unitpricelabel']";
            XmlNode nodeToReplace = doc.DocumentElement.SelectSingleNode(xpathExpression, nsmgr);
            string x = nodeToReplace.Attributes["x"].Value;
            nodeToReplace.Attributes["x"].Value = xValue;

            xpathExpression = "//dpdf:recordBox[@id='unitpricebox']";
            nodeToReplace = doc.DocumentElement.SelectSingleNode(xpathExpression, nsmgr);
            nodeToReplace.Attributes["x"].Value = xValue;

            xpathExpression = "//dpdf:label[@id='discontinuedlabel']";
            nodeToReplace = doc.DocumentElement.SelectSingleNode(xpathExpression, nsmgr);
            nodeToReplace.Attributes["x"].Value = x;

            xpathExpression = "//dpdf:symbol[@id='discontinuedsymbol']";
            nodeToReplace = doc.DocumentElement.SelectSingleNode(xpathExpression, nsmgr);
            nodeToReplace.Attributes["x"].Value = x;

            return doc;
        }

        public static void RunOriginal(string apiKey, string layoutDataPath, string dlexPath, string outputPath)
        {
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;

            LayoutDataResource layoutDataResource = new LayoutDataResource(layoutDataPath);
            pdf.AddDlex(dlexPath, layoutDataResource);
            PdfResponse pdfResponse = pdf.Process();

            if (pdfResponse.IsSuccessful)
            {
                File.WriteAllBytes(outputPath, pdfResponse.Content);
            }
            else
            {
                Console.WriteLine(pdfResponse.ErrorJson);
            }

        }

    }
}
