using System;
using Mono.Options;

namespace MaximumDepthApp
{
    public static class ConsoleArgumentsHandler
    {
        public static string CommandLineOptions(string[] args)
        {
            // These variables will be set when the command line is parsed
            string path = null;
            bool showHelp = false;

            // These are the available options
            var options = new OptionSet();
            options.Add("path=", "This path used as search root.",
              v => path = v);
            options.Add("h|help", "Show this message and exit.",
              v => showHelp = v != null);

            // In case of options can not be parsed exeption message will be shown
            try
            {
                options.Parse(args);

                if (path == "help") // In some rare cases user may input "--path help"
                {
                    Console.WriteLine("Try `MaximumDepthApp --help' for more information.");
                }

            }
            catch (OptionException e)
            {
                path = "help"; // "help" value assigned to the path for proper help displaying for different cases
                Console.Write("MaximumDepthApp: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `MaximumDepthApp --help' for more information.");
            }
            // If user wants to see the help - it will be shown for him
            if (showHelp)
            {
                ShowHelp(options);
                path = "help";
            }

            return path;
        }


        // Method which displays command line options help
        static void ShowHelp(OptionSet options)
        {
            Console.WriteLine("Usage: The program finds the file at maximum depth in the filesystem. The path to use as search root should be provided as command line argument. E.g.:");
            Console.WriteLine(@">C:\AppFolder\MaximumDepthApp.exe --path C:\Test\Documents");
            Console.WriteLine("If the path contains spaces in folder names please use double quotes to specify it. E.g. --path \"C:\\Test\\My folder\"");
            Console.WriteLine("As a result of the program execution you will see the file path printed in console which was found at maximum depth in the provided sourse and its absolute depth.");
            Console.WriteLine();
            Console.WriteLine("Options:");
            options.WriteOptionDescriptions(Console.Out);
        }
    }
}
