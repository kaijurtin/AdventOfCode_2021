using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

            var fish = _inputData[0].Split(',')
                .Select(f=>int.Parse(f))
                .ToList();

            int countNew = 0;
            int numberOfDays = 256;

            for (int i = 0; i <numberOfDays+1; i++)
            {
                for (int j = 0; j < countNew; j++)
                {
                    fish.Add(8);
                }
                countNew = 0;
                //foreach (var f in fish)
                //{
                //    Console.Write(f + ", ");
                //}
                //Console.Write(Environment.NewLine);

                for (int f = 0; f < fish.Count; f++)
                {
                    if (fish[f] != 0 )
                        fish[f] = fish[f] - 1;
                    else
                    {
                        fish[f] = 6;
                        
                        countNew ++; 
                    }
                }
                
            }
            //for (int k = 0; k < fish.Count; k++)
            //{
            //    Console.Write(fish[k] + ", ");
            //}

            Console.WriteLine(fish.Count   );




            //keep console open
            Console.WriteLine("Hit any key to close this window...");
            Console.ReadKey();

        }




        private static void readInput()
        {
            _inputData = System.IO.File.ReadAllLines("Input.txt").ToList();
        }
    }
}
