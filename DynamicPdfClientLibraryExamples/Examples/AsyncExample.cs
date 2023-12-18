using DynamicPDF.Api;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace DynamicPdfClientLibraryExamples.Examples
{
    class AsyncExample
    {

        public static void Run(string apiKey, string basePath, string outputPath)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            RunAsync(apiKey, basePath, outputPath);

            Console.WriteLine("Total time: " + sw.Elapsed.TotalSeconds);

            sw.Stop();
        }

        private static void RunAsync(String apiKey, String basePath, string outputPath)
        {
            Task[] tasks = new Task[20];

            for (int i = 0; i < 20; i++)
            {
                String user = "user" + i;
                tasks[i] = ProcessAsync(apiKey, basePath, user).ContinueWith(x => SaveFile(x.Result, outputPath, user));
            }

            Task.WaitAll(tasks);


        }

        private static Task<PdfResponse> ProcessAsync(String apiKey, String basePath, String userId)
        {

            LayoutDataResource layoutData = new LayoutDataResource(basePath + "report-with-cover-page.json");
            DlexLayout dlexEndpoint = new DlexLayout("samples/report-with-cover-page/report-with-cover-page.dlex", layoutData);
            dlexEndpoint.ApiKey = apiKey;

            Console.WriteLine("calling: " + userId);

            return dlexEndpoint.ProcessAsync();

        }

        private static void SaveFile(PdfResponse response, string outputPath, string userId)
        {
            if (response.IsSuccessful)
            {
                Console.WriteLine("saving: " + userId);
                File.WriteAllBytes(outputPath + "/" + userId + "-output.pdf", response.Content);
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
