using System;
using System.IO;

namespace MaximumDepthApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = ConsoleArgumentsHandler.CommandLineOptions(args); // When program starts command line arguments go to the dedicated method

            if (path == null) // User will be prompted to enter required --path option if he missed to do it
            {
                Console.WriteLine("Missing required option --path");
                Console.WriteLine("Try `MaximumDepthApp --help' for more information.");
            }
            if (Directory.Exists(path)) // When user provides correct directory - the program starts searching for the file in maximum depth
            {
                FileAtMaximumDepthFinder.FindFileAtMaximumDepth(path);
            }
            if (!Directory.Exists(path) && path != null && path != "help") // This block will be executed when user provided incorrect source folder path
            {
                Console.WriteLine($"Unfortunately the program did not find a folder following the path \"{path}\"");
                Console.WriteLine("Please double check the path and try again. Try `MaximumDepthApp --help' for more information.");
            }

            Console.WriteLine("Press any key on your keyboard to close the program...");
            Console.ReadKey();
        }

    }
}
