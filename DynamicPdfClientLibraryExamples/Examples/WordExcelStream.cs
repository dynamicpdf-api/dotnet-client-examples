using DynamicPDF.Api;
using System;
using System.IO;

namespace DynamicPdfClientLibraryExamples.Examples
{
    public class WordExcelStream
    {
        public static void Run(string apiKey, string basePath, string outputPath)
        {
            Pdf pdfObj = new Pdf();
            pdfObj.ApiKey = apiKey;

            //Loading Word document using file path
            WordResource wordRes = new WordResource( basePath + "Doc1.docx");
            WordInput WordInputObj = new WordInput(wordRes);
            pdfObj.Inputs.Add(WordInputObj);

            //Loading Word document from a byte array
            WordResource wordRes1 = new WordResource(File.ReadAllBytes(basePath + "Doc1.docx"), "Doc1.docx");
            WordInput WordInputObj1 = new WordInput(wordRes1);
            pdfObj.Inputs.Add(WordInputObj1);

            //Loading Excel document using file path

            ExcelResource excelRes = new ExcelResource(basePath + "sample-data.xlsx");
            ExcelInput excelInputObj = new ExcelInput(excelRes);
            pdfObj.Inputs.Add(excelInputObj);

            //Loading Excel document from a byte array
            ExcelResource excelRes1 = new ExcelResource(File.ReadAllBytes(basePath + "sample-data.xlsx"), "sample-data1.xlsx");
            ExcelInput excelInputObj1 = new ExcelInput(excelRes1);
            pdfObj.Inputs.Add(excelInputObj1);

            //Loading input Excel in the form of Stream.
            FileStream stream = new FileStream(basePath + "sample-data.xlsx", FileMode.Open);
            ExcelResource excelRes2 = new ExcelResource(stream, "sample-data2.xlsx");
            ExcelInput excelInputObj2 = new ExcelInput(excelRes2);
            pdfObj.Inputs.Add(excelInputObj2);

            PdfResponse resp = pdfObj.Process();
            stream.Close();

            if (resp.IsSuccessful)
            {
                File.WriteAllBytes(outputPath + "/word-excel-pdf-example-output.pdf", resp.Content);
            }
            else
            {
                Console.WriteLine(resp.ErrorJson);
            }
        }
    }
}
