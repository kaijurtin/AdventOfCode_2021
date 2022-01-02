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
            List<string> signalPatterns = new List<string>();
            List<string> outputValue = new List<string>();
            string [] foundPatterns = new string [9];

            foreach (string line in _inputData)
            {
                var digits = line.Split('|', (char)StringSplitOptions.RemoveEmptyEntries)
                    .Select(f => f.ToString()
                        .Split(' ', (char)StringSplitOptions.RemoveEmptyEntries))
                    .ToList();

                signalPatterns = digits[0].ToList();
                outputValue = digits[1].ToList();


                //var one = digits[1].Count(x => x.Length == 2); counter += one;
                //var four = digits[1].Count(x => x.Length == 4); counter += four;
                //var seven = digits[1].Count(x => x.Length == 3); counter += seven;
                //var eight = digits[1].Count(x => x.Length == 7); counter += eight;

                signalPatterns = signalPatterns.OrderBy(x => x.Length).ToList();

                while (signalPatterns.Count>0)
                {
                    for(int i=0; i>signalPatterns.Count; i++)
                    {
                        string pattern = signalPatterns[i];
                        switch (pattern.Length)
                        {
                            case 0:
                                signalPatterns.Remove(pattern);
                                break;

                            case 2:
                                foundPatterns[1] = pattern;
                                signalPatterns.Remove(pattern);
                                break;

                            case 3:
                                foundPatterns[7] = pattern;
                                signalPatterns.Remove(pattern);
                                break;

                            case 4:
                                foundPatterns[4] = pattern;
                                signalPatterns.Remove(pattern);
                                break;

                            case 5: //2 or 3 or 5
                                if (foundPatterns[6].Contains(pattern))
                                    foundPatterns[5] = pattern;
                                if (foundPatterns[8].Contains(pattern) && foundPatterns[9].Contains(pattern))
                                    foundPatterns[3] = pattern;
                                else foundPatterns[2] = pattern;
                                signalPatterns.Remove(pattern);
                                break;
                            case 6: //6 or 9 or 0
                                if (pattern.Contains(foundPatterns[3]))
                                    foundPatterns[9] = pattern;
                                if (foundPatterns[8].Contains(pattern))
                                    foundPatterns[0] = pattern;
                                else foundPatterns[6] = pattern;
                                signalPatterns.Remove(pattern);
                                break;

                            case 7:
                                foundPatterns[8] = pattern;
                                signalPatterns.Remove(pattern);
                                break;





                            default:
                                signalPatterns.Remove(pattern);
                                break;

                        }
                    }
                }
                foreach (var item in foundPatterns)
                {
                    Console.WriteLine(item);
                }

            }
            //Console.WriteLine(counter);

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
