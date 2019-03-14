using System;
using System.IO;

namespace MaximumDepthApp
{
    public static class FileAtMaximumDepthFinder
    {
        public static void FindFileAtMaximumDepth(string path)
        {
            var AllFiles = Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories); // All files will be enumerated here
            string deapestFilePath = null; // Initial value is null because source folder may be empty
            int maximumDepth = 0;

            try
            {
                // If current file is "deeper" then the previous one it is the "deepest" file at the moment - when all files will be checked the deepest file and its depth be known
                // The program stores only first found the "deepest" file, because requirements do not say to find all the "deepest" files e.g. when several files exist in the "deepest" folder
                foreach (string file in AllFiles)
                {
                    if (Path.GetFullPath(file).Split(Path.DirectorySeparatorChar).Length > maximumDepth)
                    {
                        maximumDepth = Path.GetFullPath(file).Split(Path.DirectorySeparatorChar).Length; // The program works with absolute depth  
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
            catch (Exception e) // E.g. permission denied exception for system folders
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Fix the problem. Restart the program and try again.");
            }
        }
    }
}
