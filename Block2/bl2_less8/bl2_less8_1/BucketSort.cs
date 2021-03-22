using System.Collections.Generic;

namespace bl2_less8_1
{
    class BucketSort
    {
        public static List<int> Sort(params int[] x)
        {
            List<int> sortedArray = new List<int>();

            int numOfBuckets = 10;

            // Создаем необходимое количество корзин
            List<int>[] buckets = new List<int>[numOfBuckets];
            for (int i = 0; i < numOfBuckets; i++)
            {
                buckets[i] = new List<int>();
            }

            // Распределяем каждый элемент массива в свою корзину 
            for (int i = 0; i < x.Length; i++)
            {
                int bucket = (x[i] / numOfBuckets);
                buckets[bucket].Add(x[i]);
            }

            // Сортируем каждую корзину и формируем результирующий список
            for (int i = 0; i < numOfBuckets; i++)
            {
                List<int> temp = quickSort(buckets[i],0,buckets[i].Count-1);
                sortedArray.AddRange(temp);
            }
            return sortedArray;
        }

        // QuickSort

        public static List <int> quickSort(List<int> input, int l, int r)
        {
            if (l < r)
            {
                int q = partitions(input, l, r);
                quickSort(input, l, q);
                quickSort(input, q + 1, r);
                return input;
            }
            return input;
        }

        public static int partitions(List<int> input, int l, int r)
        {
            int v = input[(l + r) / 2];
            int i = l;
            int j = r;
            int tmp;

            while (i <= j)
            {
                while (input[i] < v)
                {
                    i++;
                }
                while (input[j] > v)
                {
                    j--;
                }
                if (i >= j)
                    break;
                tmp = input[j];
                input[j] = input[i];
                input[i] = tmp;
                i++;
                j--;
            }
            return j;
        }
    }
}
