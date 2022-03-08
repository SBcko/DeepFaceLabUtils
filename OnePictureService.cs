using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace DeepFakeUtils
{
    public class OnePictureService
    {
        public void Execute()
        {
            Console.WriteLine("Provide directory to check:");
            string directoryToCheck = Console.ReadLine();
            while (true)
            { 

                List<string> allFiles = FileUtils.getAllFileNamesWithUnderscore(directoryToCheck);
                List<FileNameParts> allFilesAsParts = allFiles.Select(item => FileNameParts.FromFileName(item)).ToList();
                List<string> duplicatePictures = allFilesAsParts.GroupBy(item => item.FirstPart).Where(item => item.Count() > 1).Select(item => item.Key).ToList();
                foreach (string duplicatePicture in duplicatePictures)
                {
                    Console.WriteLine(duplicatePicture + "_");
                }
                Console.WriteLine("Finished. Again?");
                string again = Console.ReadLine();
                if (again != "y" && again != "Y")
                {
                    return;
                }
            }
        }
    }
}
