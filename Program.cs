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
            List<string> showItems = new List<string>();
            var digits = _inputData[0].Split('|', (char)StringSplitOptions.RemoveEmptyEntries)
                .Select(f => f.ToString()
                    .Split(' ', (char)StringSplitOptions.RemoveEmptyEntries))
                .ToList();

            var one = digits[0].Where(i => i.Length == 2);
            var seven = digits.Where(i => i.Length == 3);
            var four = digits.Where(i => i.Length == 4);

            //showItems.Add(code);

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
