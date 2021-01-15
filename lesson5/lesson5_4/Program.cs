using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lesson5_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string workDir, filename_not_recursion = "dir_not_recursion.txt", filename_recursion = "dir_recursion.txt";
            string fullpath;

            Console.WriteLine("Введите путь начальной директории (enter - путь по умолчанию):");
            workDir = Console.ReadLine();
            if(workDir=="") workDir=@"C:\!Work\GeekBrains\lesson5\lesson5_4\";
            
            // Обработка дерева каталогов без рекурсии
            fullpath = Path.Combine(workDir,filename_not_recursion);

            if (File.Exists(fullpath)) File.Delete(fullpath);

            string[] entries = Directory.GetFileSystemEntries(workDir, "*", SearchOption.AllDirectories);

            for (int i = 0; i < entries.Length; i++)
            {
                File.AppendAllText(fullpath, entries[i]+Environment.NewLine);
            }

            //Обработка дерева каталогов с рекурсией
            
            DirectoryInfo rootDir = new DirectoryInfo(workDir);
            fullpath = Path.Combine(workDir, filename_recursion);
            if (File.Exists(fullpath)) File.Delete(fullpath);
            dirRecursion(rootDir,fullpath);
            
        }

        static void dirRecursion(DirectoryInfo path,string fullpath)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;

            files = path.GetFiles("*.*");

            if (files != null) 
            {
                foreach(FileInfo fi in files)
                {
                    File.AppendAllText(fullpath, fi.FullName + Environment.NewLine);
                }

                subDirs = path.GetDirectories();
                foreach(DirectoryInfo dirInfo in subDirs)
                {
                    dirRecursion(dirInfo,fullpath);
                    File.AppendAllText(fullpath, dirInfo.FullName + Environment.NewLine);
                }
            }
        }

    }
}
