using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace DeepFakeUtils
{
    public class CopyPreviewHistory
    {
        public void Execute()
        {
            Console.WriteLine("Provide directory to copy from:");
            string directoryCopyFrom = Console.ReadLine();
            if (Directory.GetFiles(directoryCopyFrom).Length == 0)
            {
                Console.WriteLine("Directory to copy from can't be empty.");
                return;
            }
            Console.WriteLine("Provide directory to copy to:");
            string directoryCopyTo = Console.ReadLine();
            if (Directory.GetFiles(directoryCopyTo).Length > 0)
            {
                Console.WriteLine("Directory to copy to must be empty. Delete content first");
                return;
            }
            
            Console.WriteLine("Count of previews to copy:");
            int countToCopy = int.Parse(Console.ReadLine());
            List<string> allFiles = FileUtils.getAllFileNames(directoryCopyFrom);
            int copyEachFile = allFiles.Count / countToCopy;
            for (int counter= 0; counter < allFiles.Count; counter+= copyEachFile)
            {
                File.Copy(Path.Combine(directoryCopyFrom, allFiles[counter]), Path.Combine(directoryCopyTo, allFiles[counter]), false);
            }
            File.Copy(Path.Combine(directoryCopyFrom, allFiles[allFiles.Count() - 1]), Path.Combine(directoryCopyTo, allFiles[allFiles.Count() - 1]), true);
        }
    }
}
