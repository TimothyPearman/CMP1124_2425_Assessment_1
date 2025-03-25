using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CMP1124_2425_Assessment_1
{
    internal class Search
    {
        Order order = new Order();

        public Search()
        {
            //Console.WriteLine("Search");  //debug
        }

        public List<int> LinearSearch(List<int> data, int target)
        {
            List<int> index = new List<int>();

            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] == target)
                {
                    index.Add(i);
                }
            }

            return index;
        }

        public List<int> BinarySearch(List<int> data, int target)
        {
            data = order.CheckSorted(data);

            List<int> index = new List<int>();

            int low = 0;
            int high = data.Count - 1;

            while (low <= high) 
            {
                int mid = (low + high) / 2;

                if (data[mid] == target)
                {
                    index.Add(mid);

                    // check neighbours for duplicates
                    int i = 1;
                    int j = 1;

                    bool searching = true;
                    while (searching) 
                    {
                         // check elements below the found targer
                        if (mid - i >= 0 && data[mid - i] == target)
                        {
                            index.Add(mid - i);
                            i++;
                        }
                         // check elements above the found targer
                        else if (mid - i <= data.Count && mid - i >= 0 && data[mid + j] == target)
                        {
                            index.Add(mid + j);
                            j++;
                        }
                         // no more duplicates
                        else
                        {
                            searching = false;
                        }
                    }

                    return index;
                }

                if (target < data[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return index;
        }
    }
}
