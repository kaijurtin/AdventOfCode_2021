using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Windows.Shapes;

namespace AdventOfCodeStartProject
{
    static class AdventOfCode
    {
        //this field contains whats written in your input.txt
        //each line in the list of strings represents one line in the txt file
        //copy the data you get on the adventofcode website into the txt file and start coding!
        private static List<string> _inputData;
        //public static List<int> fish = new List<int>();

        static void Main(string[] args)
        {
            //EXAMPLE CODE
            //hit F5 to run it

            //read data from input.txt and write it into inputdata field
            readInput();
            //var input = _inputData.Select(i => int.Parse(i)).ToList();
            //lets write the contents of the input.txt into the console

            Console.WriteLine("Content of input.txt:");
            _inputData.ForEach(i => Console.WriteLine(i));
            Console.WriteLine($"--END OF FILE--{Environment.NewLine}");

            int counter = 0;
            List<string> showItems = new List<string>();


            foreach (string line in _inputData)
            {
                var digits = line.Split('|', (char)StringSplitOptions.RemoveEmptyEntries)
                    .Select(f => f.ToString()
                        .Split(' ', (char)StringSplitOptions.RemoveEmptyEntries))
                    .ToList();

                var one = digits[1].Count(x => x.Length == 2); counter += one;
                var four = digits[1].Count(x => x.Length == 4); counter += four;
                var seven = digits[1].Count(x => x.Length == 3); counter += seven;
                var eight = digits[1].Count(x => x.Length == 7); counter += eight;
            }



            Console.WriteLine(counter);

            //keep console open
            Console.WriteLine("Hit any key to close this window...");
            Console.ReadKey();



            //var wachstumsfaktor = 1 / 7;
            //var wachstumsfaktor_neu = 1 / 9;

            //var start_tag = 3;
            //var anzahl_fische = 1 * Math.Pow(1 / 7, numberOfDays - start_tag);
            //var anzahl_fische_neu   = Math.Pow(1 / 9, 9)

        }
    
        



        private static void readInput()
        {
            _inputData = System.IO.File.ReadAllLines("Input.txt").ToList();
        }
    }
}
