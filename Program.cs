using System;
using System.IO;

namespace MaximumDepthApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = ConsoleArgumentsHandler.CommandLineOptions(args);

            if (path == null) // User will be prompted to enter required --path option
            {
                Console.WriteLine("Missing required option --path");
                Console.WriteLine("Try `MaximumDepthApp --help' for more information.");
            }
            if (Directory.Exists(path) && path != null && path != "help") // If everything is ok - the program will start searching for the file in maximum depth
            {
                FileDepthFinder.FindFileAtMaximumDepth(path);
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
