using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CMP1124_2425_Assessment_1
{
    internal class Code
    {
        public List<string> Data = new List<string>();

        public void ReadFile(string filename) 
        {
             // Read all lines from the file
            var lines = File.ReadAllLines(filename);


             // Iterate over each line and add it to the list 
            foreach (var line in lines)
            {
                Data.Add(line);
            }
            int i = 0;

             // print out each element in the list
            foreach (var element in Data)
            {
                i++;
                Console.WriteLine($"element {i}:{element}");
            }
            Console.ReadLine();
        }
    }
}
