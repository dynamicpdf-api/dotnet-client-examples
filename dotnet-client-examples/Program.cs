using System;
using DynamicPDF.Api;

namespace dotnet_client_examples
{
   

    // NEVER INCLUDE YOUR KEY VALUE IN A GITHUB REPOSITORY.
    // Assumes the base url of api.dynamicpdf.com

    class Program
    {
        // replace with your key, only for debug use, you should always keep keys safe.
        static String key = "DP.poEtD7F5tD1Ulp3qPcolUFaCcQFxWOvuNUqm/WragUdOSaAesnu3L6XE";
        static void Main(string[] args)
        {
            PdfInfoExample.PdfInfoExampleOne(key);
        }
    }
}
