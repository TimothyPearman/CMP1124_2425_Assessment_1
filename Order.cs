using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CMP1124_2425_Assessment_1
{
    internal class Order
    {
        Sort sort = new Sort();
        public Order()
        {
            //Console.WriteLine("order"); //debug
        }
        public void Output(List<int> data, int target = 1)
        {
            int index = 1;
            for (int i = target -1; i < data.Count; i += target)  // Start from index 9 (10th element)
            {
                Console.WriteLine($"{index}: {data[i]}");
                index++;
            }
        }

        public List<int> Ascending(List<int> data)
        {
            CheckSorted(data);
            return data;
        }

        public List<int> Descending(List<int> data)
        {
            CheckSorted(data);
            data.Reverse();
            return data;
        }

        public List<int> CheckSorted(List<int> data)
        {
            sort.BubbleSort(data);
            return data;
        }
    }
}
