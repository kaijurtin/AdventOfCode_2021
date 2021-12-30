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

            var crabs = _inputData[0].Split(',')
                .Select(f=>int.Parse(f))
                .ToList();

            //var middle = (crabs.Max()-crabs.Min()) / 2;
            //Console.WriteLine("Middle; " + middle);

            //var mean = crabs.Average();
            //Console.WriteLine("Mean: " + mean);


            //var median = 0;
            //var crabsCount = crabs.Count();
            //var crabsOrdered = crabs.OrderBy(f => f).ToList();
            //if ((crabsCount / 2) % 2 == 0)
            //    median = (((crabsOrdered.ElementAt(crabsCount / 2)) + crabsOrdered.ElementAt((crabsCount / 2) - 1)) / 2);
            //else median = crabsOrdered.ElementAt(crabsCount / 2);

            //Console.WriteLine("Median: " + median);

            var range = Enumerable.Range(crabs.Min(), crabs.Max()-crabs.Min()+1);
            int singleCost(int c) => (c * (c + 1)) / 2;
            int singleSteps(int a, int b) => Math.Abs(a - b);

            var sol2 = range.Min(x => crabs.Sum(n => singleCost(singleSteps(n, x))));
            Console.WriteLine(sol2);


            //int fuelCosts = 0;
            //int singleCosts = 0;
            //int singleCosts_gauss = 0;
            //int fuelCosts_2 = 0;

            //for (int i = 0; i < crabs.Count; i++)
            //{
            //    int singleStep = Math.Abs(crabs[i] - median);
            //    singleCosts = ((singleStep * singleStep) + singleStep) / 2;
            //    singleCosts_gauss = (singleStep*(singleStep + 1)) / 2;
            //    fuelCosts += singleCosts;
            //    fuelCosts_2 += singleCosts_gauss;

            //    //Console.WriteLine("Single Costs: " + singleCosts);
            //    //Console.WriteLine("Single Costs Gauss: " + singleCosts_gauss);
            //}

            //Console.WriteLine(fuelCosts);
            //Console.WriteLine(fuelCosts_2);
        

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
