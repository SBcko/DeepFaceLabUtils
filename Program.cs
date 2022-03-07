using System;

namespace DeepFakeUtils
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select mode:");
            Console.WriteLine("Only one picture search, press: 1");
            Console.WriteLine("Gaps pictures check, press: 2");
            ConsoleKeyInfo option = Console.ReadKey();
            Console.WriteLine();
            switch (option.KeyChar)
            {
                case '1':
                    new OnePictureService().Execute();
                    break;
                case '2':
                    new GapService().Execute();
                    break;
            }
            Console.WriteLine("Finished");
            Console.ReadLine();

        }

        
    }
}
