using System;
using System.Collections.Generic;
using System.Linq;


namespace AdventOfCodeStartProject
{
    static class AdventOfCode
    {
        //this field contains whats written in your input.txt
        //each line in the list of strings represents one line in the txt file
        //copy the data you get on the adventofcode website into the txt file and start coding!
        private static List<string> _inputData;
        //private static int aim = 0;

        static void Main(string[] args)
        {
            //EXAMPLE CODE
            //hit F5 to run it

            //read data from input.txt and write it into inputdata field
            readInput();
            //var intlist = _inputData.Select(i => int.Parse(i)).ToList();
            //lets write the contents of the input.txt into the console

            //Console.WriteLine("Content of input.txt:");
            //_inputData.ForEach(i => Console.WriteLine(i));
            //Console.WriteLine($"--END OF FILE--{Environment.NewLine}");
            //List<int> _inputDataINT = _inputData.ConvertAll(item => int.Parse(item));

            int horizontal = 0;
            int depth = 0;
            int aim = 0;

            for (int i = 0; i < _inputData.Count; i++)
            {
                var s= _inputData[i];
                int value = int.Parse(s.Substring(s.Length - 1));
                ;

                if (s.Contains("forward"))
                {
                    horizontal += value;
                    depth +=  value * aim;
                }
                if (s.Contains("down"))
                    aim += value;
                    //depth+=value;
                if (s.Contains("up"))
                    aim -= value;
                    //depth -= value;


                //Console.ReadKey();

            }
            Console.WriteLine("Horizontal: " + horizontal);
            Console.WriteLine("Depth: " + depth);
            Console.WriteLine("Result: " + depth*horizontal);

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
