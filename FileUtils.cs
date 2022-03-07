using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DeepFakeUtils
{
    public static class FileUtils
    {
        public static List<string> getAllFileNames(String folderPath)
        {
            List<string> result = new DirectoryInfo(folderPath).GetFiles().Select(item => item.Name).Where(item => item.Contains("_")).OrderBy(item => item).ToList();
            Console.WriteLine("Files found:" + result.Count);
            return result;
        }
    }

    public class FileNameParts
    {
        public static FileNameParts FromFileName(string fileName)
        {
            FileNameParts result = new FileNameParts();
            result.FullName = fileName;
            result.FirstPart = fileName.Split("_")[0];
            result.SecondPart = fileName.Split("_")[1].Split(".")[0];
            return result;
        }

        public string FirstPart { get; set; }
        public string SecondPart { get; set; }

        public string FullName { get; set; }
    }
}
