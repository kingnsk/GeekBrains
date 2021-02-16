using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;


namespace bl2_less8_2
{
    class Program
    {
        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }

        static void Main(string[] args)
        {

            string inputFile = "input.txt";
            string tempFilePart = "temp";
            string sortFilePart = "sort";
            string outFile = "output.txt";
            const int Number_of_lines = 107;
            const int BLOCK_SIZE = 10;
            int count=0, fileCount;
            int[] array = new int[BLOCK_SIZE];

            if (File.Exists(inputFile))
            {
                using (StreamReader sr = new StreamReader(inputFile, System.Text.Encoding.Default))
                {
                    string currentNumber;
                    fileCount = 0;
                    currentNumber = sr.ReadLine();
                    while (currentNumber != null)
                    {
                        //..while ((currentNumber = sr.ReadLine()) != null && count < BLOCK_SIZE)
                            while (count < BLOCK_SIZE)
                            {
                            //count = 0;
                            //fileCount = 0;
                            array[count] = Convert.ToInt16(currentNumber);
                            currentNumber = sr.ReadLine();
                            count++;
                            if (currentNumber == null)
                                //count++;
                                break;
                            //count++;
                        }

                        // Запись временного файла
                        string tempFile = tempFilePart + fileCount.ToString() + ".tmp";
                        Console.WriteLine($"Записываем временный файл {tempFile}");
                        using (StreamWriter sw = new StreamWriter(tempFile, false, System.Text.Encoding.Default))
                        {
                            for (int i = 0; i < count; i++)
                            {
                                sw.WriteLine(array[i].ToString());
                            }
                            sw.Close();
                        }

                        // Запись отсортированного временного файла
                        string tempSortFile = sortFilePart +fileCount.ToString() + ".tmp";
                        Console.WriteLine($"Записываем отсортированный временный файл {tempSortFile}");
                        List<int> sorted = BucketSort.Sort(array);
                        using (StreamWriter sw = new StreamWriter(tempSortFile, false, System.Text.Encoding.Default))
                        {

                            for (int i = 0; i < count; i++)
                            {
                                sw.WriteLine(sorted[i].ToString());
                            }
                            sw.Close();
                        }

                        fileCount++;
                        count = 0;
                    }
                    sr.Close();
                }
            }
            else
                using (StreamWriter sw = new StreamWriter(inputFile, false, System.Text.Encoding.Default))
                {
                    for (int i = 0; i < Number_of_lines; i++)
                    {
                        int number = GetRandomNumber(0, 100);

                        //Console.WriteLine($"{number}");
                        sw.WriteLine($"{number}");
                    }
                    sw.Close();
                }

        }
    }


}


