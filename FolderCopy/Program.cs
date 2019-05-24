using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderCopy
{
    class Program
    {
        private static string sourceFolder;
        private static string destinationFolder;

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("FolderCopy Usage");
                Console.WriteLine("");
                Console.Write("FolderCopy");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(" {source folder} {destination folder}");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("{source folder}");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\t\tThe complete path to the folder containing the files and folders to be copied.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("{destination folder}");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\tThe complete path to the folder where the source files and folders will be copied.");
                Console.WriteLine("");
                Console.WriteLine("Additional configuration information can be specified by placing a .foldercopy file in the root of the source folder.");
                Console.WriteLine("For more information on creating a .foldercopy file please refer to the documentation.");
            }
            else if (args.Length == 2)
            {
                if (folderPathValid(args[0]))
                {
                    sourceFolder = args[0];
                }

                if (folderPathValid(args[1]))
                {
                    destinationFolder = args[1];
                }

                if (string.IsNullOrEmpty(sourceFolder))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The source folder is invalid.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                if (string.IsNullOrEmpty(destinationFolder))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The destination folder is invalid.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            else
            {
                Console.WriteLine("");
            }

            Console.ReadLine();
        }

        private static bool folderPathValid(string path)
        {
            FileInfo fileInfo = new FileInfo(path);

            if (fileInfo.Exists)
            {
                if (File.GetAttributes(path).HasFlag(FileAttributes.Directory))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
