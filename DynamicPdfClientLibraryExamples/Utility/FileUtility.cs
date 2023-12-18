using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DynamicPdfClientLibraryExamples.Utility
{
    class FileUtility
    {
        public static string GetPath(string filePath)
        {
            var exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            return System.IO.Path.Combine(appRoot, filePath);
         }

        public static void CreatePath(string filePath)
        {
            var exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);

            DirectoryInfo dirInfo = new DirectoryInfo(exePath + filePath);

            if (!dirInfo.Exists)
            {
                Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
                var appRoot = appPathMatcher.Match(exePath).Value;
                
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(appRoot, filePath));
            }
        }

    }
}



