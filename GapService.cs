using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace DeepFakeUtils
{
    public class GapService
    {
        public void Execute()
        {
            Console.WriteLine("Provide directory to check:");
            string directoryToCheck = Console.ReadLine();
            Console.WriteLine("Provide gap size to check:");
            int gapSize = int.Parse(Console.ReadLine());
            List<string> allFiles = FileUtils.getAllFileNames(directoryToCheck);
            
            List<FileNameParts> allFilesAsParts = allFiles.Select(item => FileNameParts.FromFileName(item)).ToList();

            int previousFileNumber = 0;
            FileNameParts previousFileNameParts = null;
            foreach (FileNameParts file in allFilesAsParts)
            {
                int currentFileNumber = int.Parse(file.FirstPart);
                if ((currentFileNumber - previousFileNumber) == gapSize + 1)
                { 
                    if (previousFileNameParts != null)
                    {
                        Console.WriteLine(previousFileNameParts.FullName + " -> " + file.FullName);
                    }
                }
                previousFileNumber = currentFileNumber;
                previousFileNameParts = file;
            }          
        }
    }
}
