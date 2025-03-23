/* 
Program Name: Stock Exchange Volume Analyzer 
Author: Timothy Pearman (28856139)
Date: [Submission Date] 

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
- Sorting: Bubble Sort, Quick Sort. 
- Searching: Linear Search, Binary Search. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CMP1124_2425_Assessment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filename = "Share_1_256.txt";
            //string filename = "Share_1_2048.txt"
            //string filename = "Share_2_256.txt"
            //string filename = "Share_2_2048.txt"
            //string filename = "Share_3_256.txt"
            //string filename = "Share_3_2048.txt"

            Code Data = new Code();
            Data.ReadFile(filename);
        }
    }
}