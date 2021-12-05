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


        static void Main(string[] args)
        {
            //EXAMPLE CODE
            //hit F5 to run it

            //read data from input.txt and write it into inputdata field
            readInput();
            //List<int> _inputDataINT = _inputData.ConvertAll(item => int.Parse(item));


            List<string> numbers = _inputData.First().Split(',').ToList();
            //List<string> blocksonly = _inputData[3].Split().Where(x => x != "").ToList();
            List<string> blocksonly = new List<string>();
            int arraylength = 5;
            Array  [,] boxes = new Array[arraylength, arraylength];

            for (int i = 2; i < _inputData.Count - 2; i++)
            {

                blocksonly = _inputData[i].Split().Where(x => x != "").ToList();

                boxes[0, 0] = blocksonly[1].ToArray();
                Console.WriteLine(blocksonly[1]);

                for (int j=0; j < blocksonly.Count; j++)
                {
                    boxes[i, j] = blocksonly[j].ToArray();
                    Console.WriteLine(boxes[i, j]);
                }

            }



            //List <string> box = _inputData.Select(x => x.Split(" ").ToList();







            Console.WriteLine("Hit any key to close this window...");
            Console.ReadKey();

        }




        private static void readInput()
            {
                _inputData = System.IO.File.ReadAllLines("Input.txt").ToList();
            }
        }
    }
