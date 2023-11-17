using System;

namespace UsersGuidePdfInstructions
{
    class Program
    {
        static void Main(string[] args)
        {
            InstructionsExample.DemoInstructions("DP.xxx-api-key-xxx", "c:/temp/users-guide-resources/", "c:/temp/dynamicpdf-api-usersguide-examples/csharp-output/");
        }
    }
}
