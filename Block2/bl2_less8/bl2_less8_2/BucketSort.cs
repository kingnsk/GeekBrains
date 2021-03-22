using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bl2_less8_2
{
    class BucketSort
    {
        public static List<int> Sort(params int[] x)
        {
            List<int> sortedArray = new List<int>();

            int numOfBuckets = 10;

            //Create buckets
            List<int>[] buckets = new List<int>[numOfBuckets];
            for (int i = 0; i < numOfBuckets; i++)
            {
                buckets[i] = new List<int>();
            }

            //Iterate through the passed array 
            //and add each integer to the appropriate bucket
            for (int i = 0; i < x.Length; i++)
            {
                int bucket = (x[i] / numOfBuckets);
                buckets[bucket].Add(x[i]);
            }

            //Sort each bucket and add it to the result List
            for (int i = 0; i < numOfBuckets; i++)
            {
                //List<int> temp = InsertionSort(buckets[i]);
                List<int> temp = quickSort(buckets[i],0,buckets[i].Count-1);
                sortedArray.AddRange(temp);
            }
            return sortedArray;
        }

        //Insertion Sort
        public static List<int> InsertionSort(List<int> input)
        {
            for (int i = 1; i < input.Count; i++)
            {
                //2. Store the current value in a variable
                int currentValue = input[i];
                int pointer = i - 1;

                //3. As long as we are pointing to a valid value in the array...
                while (pointer >= 0)
                {
                    //4. If the current value is less 
                    //   than the value we are pointing at...
                    if (currentValue < input[pointer])
                    {
                        //5. Move the pointed-at value up one space, 
                        //   and insert the current value 
                        //   at the pointed-at position.
                        input[pointer + 1] = input[pointer];
                        input[pointer] = currentValue;
                    }
                    else break;
                }
            }

            return input;
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
