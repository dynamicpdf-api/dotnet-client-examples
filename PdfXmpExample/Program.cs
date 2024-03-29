﻿using DynamicPDF.Api;
using System;

namespace PdfXmpExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Run("DP.xxx-api-key-xxx", "c:/temp/dynamicpdf-api-usersguide-examples/");
        }

        public static void Run(String apiKey, String basePath)
        {
            PdfResource resource = new PdfResource(basePath + "/fw4.pdf");
            PdfXmp pdfXmp = new PdfXmp(resource);
            pdfXmp.ApiKey = apiKey;
            XmlResponse response = pdfXmp.Process();
            Console.WriteLine(response.Content);
        }
    }
}
