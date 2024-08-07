﻿using DynamicPdfClientLibraryExamples.Utility;
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
            // SET RUNAPP TO TRUE TO ONLY RUN ONE APPLICATION
            // copy and paste the Example below here, for example:
            // Examples.Solutions.MergeSolution.Run(apiKey, FileUtility.GetPath(basePath), FileUtility.GetPath(outputPath));

            bool runAll = true;

            FileUtility.CreatePath(outputPath);

            if (!runAll)
            {
                
                Examples.InstructionsExample.DemoInstructions(apiKey, FileUtility.GetPath(basePath + "/users-guide/"), FileUtility.GetPath(outputPath));
                return;
            }

            Examples.AddBookmarks.Run(apiKey, FileUtility.GetPath(basePath + "/add-bookmarks/"), FileUtility.GetPath(outputPath));
            Examples.AsyncExample.Run(apiKey, FileUtility.GetPath(basePath + "/async-example/"), FileUtility.GetPath(outputPath));
            Examples.CallDlexLayoutUsingTemplateExample.Run(apiKey, FileUtility.GetPath(basePath + "/creating-a-page-template-designer/"), FileUtility.GetPath(outputPath));
            Examples.CreatePdf.Run(apiKey, FileUtility.GetPath(basePath + "/creating-pdf-pdf-endpoint/"), FileUtility.GetPath(outputPath));
            Examples.Solutions.DeletePages.Run(apiKey, FileUtility.GetPath(basePath + "/delete-pages/"), FileUtility.GetPath(outputPath));
            Examples.DesignerReportTemplate.Run(apiKey, FileUtility.GetPath(basePath + "/creating-a-report-template-designer/"), FileUtility.GetPath(outputPath));
            Examples.DlexError.Run(apiKey, FileUtility.GetPath(basePath + "/dlex-error/"), FileUtility.GetPath(outputPath));
            Examples.DlexLayoutExample.Run(apiKey, FileUtility.GetPath(basePath + "/creating-pdf-dlex-layout-endpoint/"), FileUtility.GetPath(outputPath));
            Examples.DlexLayoutObjectExample.Run(apiKey, FileUtility.GetPath(outputPath));
            Examples.DynamicColumnsOne.Run(apiKey, FileUtility.GetPath(basePath + "/columns/"), FileUtility.GetPath(outputPath));
            Examples.DynamicColumnsTwo.Run(apiKey, FileUtility.GetPath(basePath + "/columns-two/"), FileUtility.GetPath(outputPath));
            Examples.ExcelConversion.Run(apiKey, FileUtility.GetPath(basePath + "/users-guide/"), FileUtility.GetPath(outputPath));
            Examples.ExtractingText.Run(apiKey, FileUtility.GetPath(basePath + "/extract-text-pdf-text-endpoint/"));
            Examples.FillAcroForm.Run(apiKey, FileUtility.GetPath(outputPath));
            Examples.GettingStartedInFive.Run(apiKey, FileUtility.GetPath(basePath + "/getting-started/"), FileUtility.GetPath(outputPath));
            Examples.GetImageInfo.Run(apiKey, FileUtility.GetPath(basePath + "/get-image-info-image-info-endpoint/"));
            Examples.GetPdfInfo.Run(apiKey, FileUtility.GetPath(basePath + "/get-pdf-info-pdf-info-endpoint/"));
            Examples.GetXmpMetadata.Run(apiKey, FileUtility.GetPath(basePath + "/get-xmp-metadata-pdf-xmp-endpoint/"));
            Examples.GoogleFontsExample.Run(apiKey, FileUtility.GetPath(outputPath));
            Examples.ImageInfoExample.Run(apiKey, FileUtility.GetPath(basePath + "/image-info/"));
            Examples.InstructionsExample.DemoInstructions(apiKey, FileUtility.GetPath(basePath + "/users-guide/"), FileUtility.GetPath(outputPath));
            Examples.MergePdfs.Run(apiKey, FileUtility.GetPath(basePath + "/merge-pdfs-pdf-endpoint/"), FileUtility.GetPath(outputPath));
            Examples.WordConversion.Run(apiKey, FileUtility.GetPath(basePath + "/users-guide/"), FileUtility.GetPath(outputPath));

            Examples.Solutions.FormFieldFlattenAndRemove.Run(apiKey, FileUtility.GetPath(basePath + "/form-field-flatten/"), FileUtility.GetPath(outputPath));
            Examples.Solutions.ImageConversion.Run(apiKey, FileUtility.GetPath(basePath + "/image-conversion/"), FileUtility.GetPath(outputPath));
            Examples.Solutions.MergeSolution.Run(apiKey, FileUtility.GetPath(basePath), FileUtility.GetPath(outputPath));
            Examples.Solutions.OutlinesSolution.Run(apiKey, FileUtility.GetPath(basePath + "/outlines/"), FileUtility.GetPath(outputPath));
            Examples.Solutions.PdfBarcode.Run(apiKey, FileUtility.GetPath(outputPath));
            Examples.PdfExample.Run(apiKey, FileUtility.GetPath(outputPath));
            Examples.PdfInfoExample.Run(apiKey, FileUtility.GetPath(basePath + "/pdf-info/"));
            Examples.PdfHtmlExample.Run(apiKey, FileUtility.GetPath(basePath + "/users-guide/"), FileUtility.GetPath(outputPath));
            Examples.PdfHtmlCssWorkaroundExample.Run(apiKey, FileUtility.GetPath(basePath + "/users-guide/"), FileUtility.GetPath(outputPath));
            Examples.PdfTextExample.Run(apiKey, FileUtility.GetPath(basePath + "/extract-text-pdf-text-endpoint/"));
            Examples.Solutions.SolutionImagesTextRecs.Run(apiKey, FileUtility.GetPath(basePath + "/images-text-recs/"), FileUtility.GetPath(outputPath));
            Examples.Solutions.TemplatesExample.Run(apiKey, FileUtility.GetPath(basePath + "/templates/"), FileUtility.GetPath(outputPath));
            Examples.Solutions.SplitPdfs.Run(apiKey, FileUtility.GetPath(basePath + "/split-pdf/"), FileUtility.GetPath(outputPath));
            Examples.Solutions.TemplatesExample.Run(apiKey, FileUtility.GetPath(basePath + "/templates/"), FileUtility.GetPath(outputPath));
            Examples.Solutions.Watermark.Run(apiKey, FileUtility.GetPath(basePath + "/templates/"), FileUtility.GetPath(outputPath));


            
        }
  
    }
}
