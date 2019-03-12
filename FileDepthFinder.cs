using System;
using System.IO;

namespace MaximumDepthApp
{
    public static class FileDepthFinder
    {
        public static void FindFileAtMaximumDepth(string path)
        {
            var AllFiles = Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories);
            string deapestFilePath = null;
            int maximumDepth = 0;

            try
            {
                foreach (string file in AllFiles)
                {
                    if (Path.GetFullPath(file).Split(Path.DirectorySeparatorChar).Length > maximumDepth)
                    {
                        maximumDepth = Path.GetFullPath(file).Split(Path.DirectorySeparatorChar).Length;
                        deapestFilePath = file;
                    }
                }
                if (deapestFilePath != null)
                {
                    Console.WriteLine($"Following file located at maximum depth in the provided directory \"{deapestFilePath}\"\nThe depth is {maximumDepth}.");
                }
                else
                {
                    Console.WriteLine("Unfortunately the folder provided is empty.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Fix the problem. Restart the program and try again.");
            }
        }
    }
}
