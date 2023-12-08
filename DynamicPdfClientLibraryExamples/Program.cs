using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples
{
    class Program
    {
        private const string basePath = "c:/temp/dynamicpdf-api-samples";
        private const string usersGuideResourcePath = "c:/temp/dynamicpdf-api-samples/users-guide-resources/";
        private const string outputPath = "c:/temp/dynamicpdf-api-samples";

        private const string apiKey = "DP.xxx-api-key-xxx";

        static void Main(string[] args)
        {
            bool runAll = true;

            if(!runAll)
            {
                Console.WriteLine("Manually modify code to put example to run here.");
                Console.WriteLine("Manually create the folder and move resource to it as well.");
                Console.WriteLine("Example: " + "Examples.DynamicColumnsOne.Run(apiKey, basePath + \"/columns/\",outputPath + \"columns/\");");
                Console.WriteLine("Example: " + basePath + "/columns");
                return;
            }

            DirectoryInfo dirInfo = new DirectoryInfo(basePath);

            if (!dirInfo.Exists)
            {
                Utility.FileUtility.CopyAll(Utility.FileUtility.GetPath("Resources"), basePath);
                System.IO.Directory.CreateDirectory(outputPath);
            }

            Console.WriteLine("================================================================================");
            Console.WriteLine("THESE SAMPLE PROJECTS MUST EXIST IN DynamicPDF Cloud API Resource Manager!");
            Console.WriteLine("Need following folders in cloud storage to work.");
            Console.WriteLine("samples/report-with-cover-page");
            Console.WriteLine("samples/creating-pdf-pdf-endpoint");
            Console.WriteLine("samples/creating-a-report-template-designer");
            Console.WriteLine("samples/creating-a-page-template-designer");
            Console.WriteLine("samples/dlex-layout");
            Console.WriteLine("samples/merge-pdfs-pdf-endpoint");
            Console.WriteLine("samples/fill-acro-form-pdf-endpoint");
            Console.WriteLine("samples/creating-a-page-template-designer");
            Console.WriteLine("================================================================================");

            Examples.DynamicColumnsOne.Run(apiKey, basePath + "/columns/", outputPath + "/columns/");
            Examples.DynamicColumnsTwo.Run(apiKey, basePath + "/columns-two/", outputPath + "/columns-two/");

            Examples.InstructionsExample.DemoInstructions(apiKey, usersGuideResourcePath, outputPath + "/users-guide-output/");
            Examples.AddBookmarks.Run(apiKey, basePath + "/add-bookmarks/");
            Examples.AsyncExample.Run(apiKey, basePath + "/async-example/");
            Examples.DlexError.Run(apiKey, basePath + "/dlex-error/");
            Examples.CreatePdf.Run(apiKey, basePath + "/creating-pdf-pdf-endpoint/");
            Examples.DlexLayoutExample.Run(apiKey, basePath + "/dlex-layout/");
            Examples.DlexLayoutObjectExample.Run(apiKey, basePath + "/dlex-layout-object-example/");
            Examples.ExtractingText.Run(apiKey, basePath + "/extract-text-pdf-text-endpoint/");
            Examples.GetImageInfo.Run(apiKey, basePath + "/get-image-info-image-info-endpoint/");
            Examples.GetPdfInfo.Run(apiKey, basePath + "/get-pdf-info-pdf-info-endpoint/");
            Examples.ImageInfoExample.Run(apiKey, basePath + "/image-info/");
            Examples.PdfExample.Run(apiKey, basePath + "/pdf-example/");
            Examples.PdfInfoExample.Run(apiKey, basePath + "/pdf-info/");
            Examples.PdfHtmlExample.Run(apiKey, basePath + "/pdf-html-example/", usersGuideResourcePath);
            Examples.PdfHtmlCssWorkaroundExample.Run(apiKey, usersGuideResourcePath, outputPath + "/users-guide-output/");
            Examples.MergePdfs.Run(apiKey, basePath + "/merge-pdfs-pdf-endpoint/");
            Examples.GetXmpMetadata.Run(apiKey, basePath + "/get-xmp-metadata-pdf-xmp-endpoint/");
            Examples.PdfTextExample.Run(apiKey, basePath + "/extract-text-pdf-text-endpoint/");
            Examples.DesignerReportTemplate.Run(apiKey, basePath + "/creating-a-report-template-designer/");
            Examples.GettingStartedInFive.Run(apiKey, basePath + "/getting-started/");
            Examples.FillAcroForm.Run(apiKey, basePath + "/fill-acro-form-pdf-endpoint/");
            Examples.CallDlexLayoutUsingTemplateExample.Run(apiKey, basePath + "/creating-a-page-template-designer/");
        }

    }
}
