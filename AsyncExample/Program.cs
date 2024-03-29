﻿using DynamicPDF.Api;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            RunAsync("DP.xxx-api-key-xxx", "c:/temp/dynamicpdf-api-samples/async-example/");

            Console.WriteLine("Total time: " + sw.Elapsed.TotalSeconds);

            sw.Stop();

        }

        static void RunAsync(String apiKey, String basePath)
        {
            Task[] tasks = new Task[20];

            for (int i = 0; i < 20; i++)
            {
                String user = "user" + i;
                tasks[i] = ProcessAsync(apiKey, basePath, user).ContinueWith(x=>SaveFile(x.Result, basePath, user));
            }

            Task.WaitAll(tasks);


        }

        static Task<PdfResponse> ProcessAsync(String apiKey, String basePath, String userId)
        {

            LayoutDataResource layoutData = new LayoutDataResource(basePath + "report-with-cover-page.json");
            DlexLayout dlexEndpoint = new DlexLayout("samples/report-with-cover-page/report-with-cover-page.dlex", layoutData);
            dlexEndpoint.ApiKey = apiKey;

            Console.WriteLine("calling: " + userId);

            return dlexEndpoint.ProcessAsync();
            
        }

        static void SaveFile(PdfResponse response, string basePath, string userId)
        {
            if (response.IsSuccessful)
            {
                Console.WriteLine("saving: " + userId);
                File.WriteAllBytes(basePath + userId + "-output.pdf", response.Content);
            }
            else
            {
                Console.WriteLine("ErrorId: " + response.ErrorId);
                Console.WriteLine("ErrorMessage: " + response.ErrorMessage);
                Console.WriteLine("ErrorJson: " + response.ErrorJson);
            }
        }
    }
}
