using System;
using DynamicPDF.Api;
using DynamicPdfCloudApiClientExamples.instructions;

namespace DynamicPdfCloudApiClientExamples
{
   

    class Program
    {
        // first argument is the API Key

        static void Main(string[] args)
        {

            PdfInfoExample.PdfInfoExampleOne(args[0], args[1]);
            PrintDivider();
            ImageInfoExample.ImageInfoExampleOne(args[0], args[1]);
            PrintDivider();
            ImageInfoExample.ImageInfoExampleTwo(args[0], args[1]);
            PrintDivider();
            PdfTextExample.PdfInfoExampleOne(args[0], args[1]);
            PrintDivider();
            PdfXmpExample.PdfXmpExampleOne(args[0], args[1]);
            PdfExample.PdfExampleOne(args[0], args[1]);
            PrintDivider();
            DlexLayoutExample.DlexLayoutExampleOne(args[0], args[1]);
            InstructionsExample.DemoInstructions(args);
        }

        static void PrintDivider()
        {
            Console.WriteLine("============================================");
        }
    }
}
