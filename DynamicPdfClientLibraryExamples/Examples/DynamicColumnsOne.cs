
using DynamicPDF.Api;
using System;
using System.IO;
using System.Text;
using System.Xml;

namespace DynamicPdfClientLibraryExamples.Examples
{
    class DynamicColumnsOne
    {
        public static void Run(string apiKey, string basePath, string outputPath)
        {
            XmlDocument doc = ModifyDlexDocument(basePath + "report-with-cover-page.dlex");
            RunDlex(apiKey, basePath, basePath + "report-with-cover-page.json", doc, outputPath + "/report-with-cover-page-output.pdf");
        }

        
        public static void RunDlex(string apiKey, string basePath, string layoutDataPath, XmlDocument doc, string outputPath)
        {
            Pdf pdf = new Pdf();
            pdf.ApiKey = apiKey;

            LayoutDataResource layoutDataResource = new LayoutDataResource(layoutDataPath);

            DlexResource dlexResource = new DlexResource(Encoding.Default.GetBytes(doc.OuterXml));

            pdf.AddAdditionalResource(basePath + "NorthwindLogo.gif");
            pdf.AddDlex(dlexResource, layoutDataResource);

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
    }
}