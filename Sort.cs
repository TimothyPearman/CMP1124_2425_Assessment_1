using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CMP1124_2425_Assessment_1
{
    internal class Sort
    {
        public Sort()
        {
            //Console.WriteLine("Sort");  //debug
        }

        public List<int> BubbleSort(List<int> data)
        {
            int n = data.Count();
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (data[j + 1] < data[j])
                    {
                        int temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                    }
                }
            }

            return data;
        }

        public List<int> MergeSort(List<int> data)
        // pre: 0 <= n <= data.length
        // post: values in data[0 … n-1] are in ascending order
        {
            int n = data.Count();
            List<int> temp = new List<int>(new int[n]);
            // temp = new int[n];
            MergeSortRecursive(data, temp, 0, n - 1);

            return data;
        }
        public void MergeSortRecursive(List<int> data, List<int> temp, int low, int
        high)
        // pre: 0 <= low <= high < data.length
        // post: values in data[low … high] are in ascending order
        {
            int n = high - low + 1;
            int middle = low + n / 2;
            int i;
            if (n < 2) return;
            // move lower half of data into temporary storage
            for (i = low; i < middle; i++)
            {
                temp[i] = data[i];
            }
            // sort lower half array
            MergeSortRecursive(temp, data, low, middle - 1);
            // sort upper half array
            MergeSortRecursive(data, temp, middle, high);
            // merge halves together
            Merge(data, temp, low, middle, high);
        }
        public void Merge(List<int> data, List<int> temp, int low, int middle, int high)
        // pre: data[middle … high] are ascending
        // temp[low … middle-1] are ascending
        // post: data[low … high] contains all the values
        // in ascending order
        {
            int ri = low; // result index
            int ti = low; // temp index
            int di = middle; // destination index
                             // while two lists are not empty merge smaller //value
            while (ti < middle && di <= high)
            {
                if (data[di] < temp[ti])
                {
                    data[ri++] = data[di++];
                    // smaller is in high data
                }
                else
                {
                    data[ri++] = temp[ti++];// smaller is in temp
                }
            }
            //possibly some values left in temp array
            while (ti < middle)
            {
                data[ri++] = temp[ti++];
            }
            //… or some values left (in correct place) in data array
        }
        
        public List<int> QuickSort(List<int> data)
        {
            return Quick_Sort(data, 0, data.Count() - 1);
        }
        public List<int> Quick_Sort(List<int> data, int left, int right)
        {
            int i, j;
            int pivot, temp;
            i = left;
            j = right;
            pivot = data[(left + right) / 2];
            do
            {
                while ((data[i] < pivot) && (i < right)) i++;
                while ((pivot < data[j]) && (j > left)) j--;
                if (i <= j)
                {
                    temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);
            if (left < j) Quick_Sort(data, left, j);
            if (i < right) Quick_Sort(data, i, right);

            return data;
        }

        public List<int> InsertionSort(List<int> data)
        {
            int numSorted = 1; // number of values in place
            int index; // general index
            while (numSorted < data.Count())
            {
                // take the first unsorted value
                int temp = data[numSorted];
                // … and insert it among the sorted
                for (index = numSorted; index > 0; index--)
                {
                    if (temp < data[index - 1])
                    {
                        data[index] = data[index - 1];
                    }
                    else
                    {
                        break;
                    }
                }
                // reinsert value
                data[index] = temp;
                numSorted++;
            }

            return data;
        }
    }
}
