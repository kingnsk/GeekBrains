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
        public static string inputFile = "input.txt";
        public static string outFile = "output.txt";
        public const int BLOCK_SIZE = 10;
        public const int Number_of_lines = 110;

        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }

        public static void WriteSortedTempFile(int []array,int count, int fileCount)
        {
            string sortFilePart = "sort";

            // Запись отсортированного временного файла
            string tempSortFile = sortFilePart + fileCount.ToString() + ".tmp";
            Console.WriteLine($"Записываем отсортированный временный файл {tempSortFile}");

            List <int> sorted = BucketSort.Sort(array);
            
            using (StreamWriter sw = new StreamWriter(tempSortFile, false, System.Text.Encoding.Default))
            {
                for (int i = 0; i < count; i++)
                {
                    sw.WriteLine(sorted[i].ToString());
                }
                sw.Close();
            }
        }

        public static void WriteTempFile(int []array,int count, int fileCount)
        {
            string tempFilePart = "temp";


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

        }

        public static void CreateRandomFile()
        {
            Console.WriteLine("Файл input.txt не обнаружен, создадим его заполнив случайными значениями...");
            using (StreamWriter sw = new StreamWriter(inputFile, false, System.Text.Encoding.Default))
            {
                for (int i = 0; i < Number_of_lines; i++)
                {
                    int number = GetRandomNumber(0, 100);
                    sw.WriteLine($"{number}");
                }
                sw.Close();
            }

        }

        public static void PrepareSortedFiles()
        {
            int count = 0, fileCount;
            int[] array = new int[BLOCK_SIZE];

            using (StreamReader sr = new StreamReader(inputFile, System.Text.Encoding.Default))
            {
                string currentNumber;
                fileCount = 0;
                currentNumber = sr.ReadLine();
                while (currentNumber != null)
                {
                    while (count < BLOCK_SIZE)
                    {
                        array[count] = Convert.ToInt16(currentNumber);
                        currentNumber = sr.ReadLine();
                        count++;
                        if (currentNumber == null)
                            break;
                    }

                    WriteTempFile(array, count, fileCount);
                    WriteSortedTempFile(array, count, fileCount);

                    fileCount++;
                    count = 0;
                }
                sr.Close();
                array = null;    
            }
            
        }

        public static void MergeTmpFiles()
        {
            string[] paths = Directory.GetFiles(Directory.GetCurrentDirectory(),"sort*.tmp");
            string[] tmp_files = Directory.GetFiles(Directory.GetCurrentDirectory(), "temp*.tmp");
            int pieces = paths.Length;

            StreamReader[] readers = new StreamReader[pieces];
            for (int i = 0; i < pieces; i++)
                readers[i] = new StreamReader(paths[i]);

            // Создаем очереди 
            Queue<int>[] queues = new Queue<int>[pieces];
            for (int i = 0; i < pieces; i++)
                queues[i] = new Queue<int>();

            // Заполняем очереди
            for (int i = 0; i < pieces; i++) 
            LoadQueue(queues[i], readers[i]);

            // финальная стадия merge
            StreamWriter sw = new StreamWriter(outFile);
            bool done = false;
            int lowest_index, j;
            int lowest_value;
            while (!done)
            {
                lowest_index = -1;
                lowest_value = 0;
                for (j = 0; j < pieces; j++)
                {
                    if (queues[j] != null)
                    {
                        if (lowest_index < 0 || queues[j].Peek()<lowest_value)
                        {
                            lowest_index = j;
                            lowest_value = queues[j].Peek();
                        }
                    }
                }

                if (lowest_index == -1) { done = true; break; }

                sw.WriteLine(lowest_value);

                // Убираем элемент из очереди
                queues[lowest_index].Dequeue();

                if (queues[lowest_index].Count == 0)
                {
                    LoadQueue(queues[lowest_index],
                      readers[lowest_index]);
                    if (queues[lowest_index].Count == 0)
                    {
                        queues[lowest_index] = null;
                    }
                }
            }
            sw.Close();

            // Закрываем открытые файлы и удаляем отработанные
            for (int i = 0; i < pieces; i++)
            {
                readers[i].Close();
                File.Delete(paths[i]);
                File.Delete(tmp_files[i]);
            }
        }

        public static void LoadQueue(Queue<int> queue, StreamReader file)
        {
            string currentNumber = file.ReadLine();
            while (currentNumber != null)
            {
                queue.Enqueue(Convert.ToInt16(currentNumber));
                currentNumber = file.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            if (File.Exists(inputFile))
            {
                PrepareSortedFiles();
            }
            else
            {
                CreateRandomFile();
            }

            MergeTmpFiles();
        }
    }


}


