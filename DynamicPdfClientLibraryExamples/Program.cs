using DynamicPdfClientLibraryExamples.Utility;
using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples
{
    class Program
    {
        private const string basePath = "Resources";
        private const string outputPath = "Output";

        private const string apiKey = "DP--api-key--";

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


            FileUtility.CreatePath(outputPath);

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
/*
            Examples.Solutions.FormFieldFlattenAndRemove.Run(apiKey, FileUtility.GetPath(basePath + "/form-field-flatten/"), FileUtility.GetPath(outputPath));

            Examples.Solutions.SplitPdfs.Run(apiKey, FileUtility.GetPath(basePath + "/split-pdf/"), FileUtility.GetPath(outputPath));

            Examples.Solutions.DeletePages.Run(apiKey, FileUtility.GetPath(basePath + "/delete-pages/"), FileUtility.GetPath(outputPath));

            Examples.Solutions.OutlinesSolution.Run(apiKey, FileUtility.GetPath(basePath + "/outlines/"), FileUtility.GetPath(outputPath));

            Examples.Solutions.PdfBarcode.Run(apiKey, FileUtility.GetPath(outputPath));
            Examples.AddBookmarks.Run(apiKey, FileUtility.GetPath(basePath + "/add-bookmarks/"), FileUtility.GetPath(outputPath));
            Examples.AsyncExample.Run(apiKey, FileUtility.GetPath(basePath + "/async-example/"), FileUtility.GetPath(outputPath));
            Examples.DlexError.Run(apiKey, FileUtility.GetPath(basePath + "/dlex-error/"), FileUtility.GetPath(outputPath));
            Examples.CreatePdf.Run(apiKey, FileUtility.GetPath(basePath + "/creating-pdf-pdf-endpoint/"), FileUtility.GetPath(outputPath));
            Examples.DlexLayoutExample.Run(apiKey, FileUtility.GetPath(basePath + "/dlex-layout/"), FileUtility.GetPath(outputPath));
            Examples.DlexLayoutObjectExample.Run(apiKey, FileUtility.GetPath(outputPath));
            Examples.ExtractingText.Run(apiKey, FileUtility.GetPath(basePath + "/extract-text-pdf-text-endpoint/"));
            Examples.GetImageInfo.Run(apiKey, FileUtility.GetPath(basePath + "/get-image-info-image-info-endpoint/"));
            Examples.GetPdfInfo.Run(apiKey, FileUtility.GetPath(basePath + "/get-pdf-info-pdf-info-endpoint/"));
            Examples.ImageInfoExample.Run(apiKey, FileUtility.GetPath(basePath + "/image-info/"));
            Examples.PdfExample.Run(apiKey, FileUtility.GetPath(outputPath));
            Examples.PdfInfoExample.Run(apiKey, FileUtility.GetPath(basePath + "/pdf-info/"));
            Examples.PdfHtmlExample.Run(apiKey, FileUtility.GetPath(basePath + "/users-guide/"), FileUtility.GetPath(outputPath));
            Examples.PdfHtmlCssWorkaroundExample.Run(apiKey, FileUtility.GetPath(basePath + "/users-guide/"), FileUtility.GetPath(outputPath));
            Examples.MergePdfs.Run(apiKey, FileUtility.GetPath(basePath + "/merge-pdfs-pdf-endpoint/"), FileUtility.GetPath(outputPath));
            Examples.GoogleFontsExample.Run(apiKey, FileUtility.GetPath(outputPath));
            Examples.GetXmpMetadata.Run(apiKey, FileUtility.GetPath(basePath + "/get-xmp-metadata-pdf-xmp-endpoint/"));
            Examples.PdfTextExample.Run(apiKey, FileUtility.GetPath(basePath + "/extract-text-pdf-text-endpoint/"));
            Examples.DesignerReportTemplate.Run(apiKey, FileUtility.GetPath(basePath + "/creating-a-report-template-designer/"), FileUtility.GetPath(outputPath));
            Examples.GettingStartedInFive.Run(apiKey, FileUtility.GetPath(basePath + "/getting-started/"), FileUtility.GetPath(outputPath));
            Examples.FillAcroForm.Run(apiKey, FileUtility.GetPath(outputPath));
            Examples.CallDlexLayoutUsingTemplateExample.Run(apiKey, FileUtility.GetPath(basePath + "/creating-a-page-template-designer/"), FileUtility.GetPath(outputPath));
            Examples.DynamicColumnsOne.Run(apiKey, FileUtility.GetPath(basePath + "/columns/"), FileUtility.GetPath(outputPath));
            Examples.DynamicColumnsTwo.Run(apiKey, FileUtility.GetPath(basePath + "/columns-two/"), FileUtility.GetPath(outputPath));
            Examples.InstructionsExample.DemoInstructions(apiKey, FileUtility.GetPath(basePath + "/users-guide/"), FileUtility.GetPath(outputPath));
            Examples.Solutions.SolutionImagesTextRecs.Run(apiKey, FileUtility.GetPath(basePath + "/images-text-recs/"), FileUtility.GetPath(outputPath));
            Examples.Solutions.TemplatesExample.Run(apiKey, FileUtility.GetPath(basePath + "/templates/"), FileUtility.GetPath(outputPath));
            Examples.Solutions.ImageConversion.Run(apiKey, FileUtility.GetPath(basePath + "/image-conversion/"), FileUtility.GetPath(outputPath));
*/
            Examples.ExcelConversion.Run(apiKey, FileUtility.GetPath(basePath + "/users-guide/"), FileUtility.GetPath(outputPath));
        }

    }
}
