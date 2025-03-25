/* 
Program Name: Stock Exchange Volume Analyzer 
Author: Timothy Pearman (28856139)
Date: 25/3/25
  
Description: 
- This program is a console-based application that reads, sorts, and 
searches stock exchange volume data from multiple text files. The 
program allows users to analyze stock trading activity by implementing 
different sorting and searching algorithms.  
  
Main Functionality: 
- Reads stock exchange volume data from multiple text files. 
- Sorts the data in ascending and descending order. 
- Displays every 10th (for smaller datasets) or 50th (for larger datasets) value after sorting. 
- Searches for a user-defined value and returns its position(s). 
- If the value is not found, provides the nearest value(s) and their position(s). 
- Merges and processes datasets for advanced analysis. 
- Compares different sorting and searching algorithms by counting their execution steps. 
  
Input Parameters: 
- Input file(s) or path 
- Sorting and searching algorithm selection and related parameters (if applicable). 

Expected Output: 
- Sorted data with selected interval values displayed. 
- Search results including value locations or nearest available values. 

Implemented Algorithms: 
- Searching: 
    Linear Search [LinearSearch()], 
    Binary Search [BinarySearch()]. 
- Sorting: 
    Bubble Sort [BubbleSort()], 
    Merge Sort [MergeSort(), MergeSortRecursive(), Merge()], 
    Quick Sort [QuickSort(), Quick_Sort()], 
    Insertion Sort [InsertionSort()].
- Ordering: 
    Ascending [Ascending()], 
    Descending [Descending()].
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;

namespace CMP1124_2425_Assessment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // two dimensional list to hold lists of data held in the shares
            List<List<int>> Shares = new List<List<int>>();

            Order order = new Order();
            Sort sort = new Sort();
            Search search = new Search();

            // uncomment the task you want to run, task 1 should never be commented
            Task1(ref Shares);
            //Task2(Shares, order, sort);
            //Task3(Shares, order, search);
            //Task4(Shares, order, search);
            //Task5(Shares, order, sort, search);
            //Task6(Shares, order, sort, search);
            Task7(Shares, order, sort, search);

            Console.ReadKey();
        }

        static public List<int> ReadFile(string filename)
        {
            // create a list to hold each line of the file
            List<int> list = new List<int>();

            // Read all lines from the file
            // Shares files must be in [\CMP1124_2425_Assessment_1\bin\Debug\]
            var lines = File.ReadAllLines(filename);


            // Iterate over each line and add it to the list 
            foreach (var line in lines)
            {
                list.Add(Convert.ToInt32(line));
            }

            return list;
        }

        static public List<List<int>> Task1(ref List<List<int>> Shares)
        {
            // Task 1
            // Read the files into arrays
            /***********************************************************************************/
            Shares.Add(ReadFile("Share_1_256.txt"));
            Shares.Add(ReadFile("Share_2_256.txt"));
            Shares.Add(ReadFile("Share_3_256.txt"));

            Shares.Add(ReadFile("Share_1_2048.txt"));
            Shares.Add(ReadFile("Share_2_2048.txt"));
            Shares.Add(ReadFile("Share_3_2048.txt"));

            return Shares;
        }

        static public void Task2(List<List<int>> Shares, Order order, Sort sort, int version = 0)
        {
            // Task 2:
            // -Sort in ascending and descending order
            // -Display every 10th value of the selected Arrays
            /***********************************************************************************/
            Console.WriteLine("\nShare_1_256 Ascending order, 10th values\n");
            order.Output(order.Ascending(sort.MergeSort(Shares[0])), 10);
            Console.WriteLine("\nShare_2_256 Ascending order, 10th values\n");
            order.Output(order.Ascending(sort.QuickSort(Shares[1])), 10);
            Console.WriteLine("\nShare_3_256 Ascending order, 10th values\n");
            order.Output(order.Ascending(sort.InsertionSort(Shares[2])), 10);

            Console.WriteLine("\nShare_1_256 Descending order, 10th values\n");
            order.Output(order.Descending(sort.MergeSort(Shares[0])), 10);
            Console.WriteLine("\nShare_2_256 Descending order, 10th values\n");
            order.Output(order.Descending(sort.QuickSort(Shares[1])), 10);
            Console.WriteLine("\nShare_3_256 Descending order, 10th values\n");
            order.Output(order.Descending(sort.InsertionSort(Shares[2])), 10);

            //task 5,6,7 version
            if (version > 0)
            {
                Console.WriteLine("\nShare_1_2048 Ascending order, 50th values\n");
                order.Output(order.Ascending(sort.MergeSort(Shares[3])), 50);
                Console.WriteLine("\nShare_2_2048 Ascending order, 50th values\n");
                order.Output(order.Ascending(sort.QuickSort(Shares[4])), 50);
                Console.WriteLine("\nShare_3_2048 Ascending order, 50th values\n");
                order.Output(order.Ascending(sort.InsertionSort(Shares[5])), 50);

                Console.WriteLine("\nShare_1_2048 Descending order, 50th values\n");
                order.Output(order.Descending(sort.MergeSort(Shares[3])), 50);
                Console.WriteLine("\nShare_2_2048 Descending order, 50th values\n");
                order.Output(order.Descending(sort.QuickSort(Shares[4])), 50);
                Console.WriteLine("\nShare_3_2048 Descending order, 50th values\n");
                order.Output(order.Descending(sort.InsertionSort(Shares[5])), 50);
            }

            //task 6,7 version
            if (version > 1)
            {
                Console.WriteLine("\nShare_1_256 merged with Share_3_256 Ascending order, 10th values\n");
                order.Output(order.Ascending(sort.MergeSort(Shares[6])), 10);

                Console.WriteLine("\nShare_1_256 merged with Share_3_256 Descending order, 10th values\n");
                order.Output(order.Descending(sort.MergeSort(Shares[6])), 10);
            }

            //task 7 version
            if (version > 2)
            {
                Console.WriteLine("\nShare_1_2048 merged with Share_3_2048 Ascending order, 50th values\n");
                order.Output(order.Ascending(sort.MergeSort(Shares[7])), 50);

                Console.WriteLine("\nShare_1_2048 merged with Share_3_2048 Descending order, 50th values\n");
                order.Output(order.Descending(sort.MergeSort(Shares[7])), 50);
            }
        }

        static public (bool, int, int) Task3(List<List<int>> Shares, Order order, Search search, int version = 0)
        {
            // Task 3:
            // -Search the selected Array for a user-defined value
            // -Display all locations of the value
            // -Otherwise provide an error message
            /***********************************************************************************/
            List<int> data = new List<int>();
            int userInputArray;
            int userInputTarget;

            // get array choice from user
            Console.WriteLine("\nWhich array would you like to search?");
            Console.WriteLine("Share_1_256.txt: 1");
            Console.WriteLine("Share_2_256.txt: 2");
            Console.WriteLine("Share_3_256.txt: 3");
            //task 5,6,7 version
            if (version > 0)
            {
                Console.WriteLine("Share_1_2048.txt: 4");
                Console.WriteLine("Share_2_2048.txt: 5");
                Console.WriteLine("Share_3_2048.txt: 6");
            }
            //task 6,7 version
            if (version > 1)
            {
                Console.WriteLine("Share_1_256 merged with Share_3_256: 7");
            }
            //task 7 version
            if (version > 2)
            {
                Console.WriteLine("Share_1_2048 merged with Share_3_2048: 8");
            }
            userInputArray = Convert.ToInt32(Console.ReadLine());

            // get target choice from user
            Console.WriteLine("Which value would you like to search for?");
            userInputTarget = Convert.ToInt32(Console.ReadLine());

            // search for target in array
            data = search.BinarySearch(Shares[userInputArray - 1], userInputTarget);
            if (data.Count == 0)
            {
                Console.WriteLine("target element does not exist in array");
                return (false, userInputArray, userInputTarget);
            }
            else
            {
                Console.WriteLine("target element found at indexes:");
                order.Output(data);
                return (true, userInputArray, userInputTarget);
            }
        }

        static public void Task4(List<List<int>> Shares, Order order, Search search, int version = 0)
        {
            List<int> data = new List<int>();

            var results = Task3(Shares, order, search, version);

            // false = target not found during task 3 search
            if (results.Item1 == false)
            {
                Console.WriteLine("Searching for nearest values");

                List<int> nearest = new List<int>();
                List<int> dataLow = new List<int>();
                List<int> dataHigh = new List<int>();

                int targetLow = results.Item3 - 1;
                int targetHigh = results.Item3 + 1;

                bool searching = true;
                while (searching)
                {
                    //search for nearest values above and below target
                    dataLow = search.LinearSearch(Shares[results.Item2 - 1], targetLow);
                    dataHigh = search.LinearSearch(Shares[results.Item2 - 1], targetHigh);

                    if (dataLow.Count() == 0)
                    {
                        targetLow--;
                    }
                    else
                    {
                        searching = false;
                        nearest.Add(targetLow);
                    }

                    if (dataHigh.Count() == 0)
                    {
                        targetHigh++;
                    }
                    else
                    {
                        searching = false;
                        nearest.Add(targetHigh);
                    }
                }

                if (nearest.Count() == 0)
                {
                    Console.WriteLine("No nearest values found");
                }
                else if (nearest.Count() == 1)
                {
                    Console.WriteLine($"nearest element {nearest[0]} found at indexes:");
                    order.Output(dataLow);
                    order.Output(dataHigh);
                }
                else
                {
                    Console.WriteLine($"nearest elements {nearest[0]} and {nearest[1]} found at indexes:");
                    order.Output(dataLow);
                    Console.WriteLine("and");
                    order.Output(dataHigh);
                }
            }
        }

        static public void Task5(List<List<int>> Shares, Order order, Sort sort, Search search)
        {
            Task2(Shares, order, sort, 1);
            //Task3(Shares, order, search, 1); // task 3 is run by task 4, just for debugging
            Task4(Shares, order, search, 1);
        }

        static public void Task6(List<List<int>> Shares, Order order, Sort sort, Search search)
        {
            Shares.Add(Shares[0]);

            foreach (var item in Shares[2])
            {
                Shares[6].Add(item);
            }

            //Task2(Shares, order, sort, 2);
            //Task3(Shares, order, search, 2); // task 3 is run by task 4, just for debugging
            //Task4(Shares, order, search, 2);
        }

        static public void Task7(List<List<int>> Shares, Order order, Sort sort, Search search)
        {
            Task6(Shares, order, sort, search);

            Shares.Add(Shares[3]);

            foreach (var item in Shares[5])
            {
                Shares[7].Add(item);
            }

            Task2(Shares, order, sort, 3);
            //Task3(Shares, order, search, 3); // task 3 is run by task 4, just for debugging
            Task4(Shares, order, search, 3);
        }
    }
}
