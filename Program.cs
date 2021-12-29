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

            var fish = _inputData[0].Split(',')
                .Select(f=>int.Parse(f))
                .ToList();

            BigInteger countNew = 0;
            int numberOfDays = 80;
            #region solution day 1
          
             //for (int i = 0; i <numberOfDays+1; i++)
             //{
             //    for (int j = 0; j < countNew; j++)
             //    {
             //        fish.Add(8);
             //    }
             //    countNew = 0;
             //    //foreach (var f in fish)
             //    //{
             //    //    Console.Write(f + ", ");
             //    //}
             //    //Console.Write(Environment.NewLine);

             //    for (int f = 0; f < fish.Count; f++)
             //    {
             //        if (fish[f] != 0 )
             //            fish[f] = fish[f] - 1;
             //        else
             //        {
             //            fish[f] = 6;

             //            countNew ++; 
             //        }
             //    }

             //}
             //for (int k = 0; k < fish.Count; k++)
             //{
             //    Console.Write(fish[k] + ", ");
             //}

             //Console.WriteLine(fish.Count   );
            
            #endregion


            Dictionary<int, BigInteger> fishTable = new Dictionary<int, BigInteger>();
            fishTable.Add(0, 0);
            fishTable.Add(1, 0); 
            fishTable.Add(2, 0);
            fishTable.Add(3, 0);
            fishTable.Add(4, 0);
            fishTable.Add(5, 0);
            fishTable.Add(6, 0);
            fishTable.Add(7, 0);
            fishTable.Add(8, 0);

            for (int i = 0; i < fish.Count; i++)
            {
                if (fishTable.ContainsKey(fish[i]))
                    fishTable[fish[i]] += 1 ;
            }
            foreach(KeyValuePair<int, BigInteger> kvp in fishTable)
                Console.WriteLine("days old: {0}, number: {1}", kvp.Key, kvp.Value);

            for (int i = 0; i < numberOfDays; i++)
            {
                for (int f = 0; f < fishTable.Count; f++)
                {
                    if (f==0)
                    {
                        fishTable[8] = fishTable[0];
                        fishTable[6] += fishTable[0];
                    }
                    if (fishTable[f]!=0)
                    {
                        fishTable[f-1] = fishTable[f];

                        //fishTable[7] = fishTable[8];
                        //fishTable[6] = fishTable[7];
                        //fishTable[5] = fishTable[6];
                        //fishTable[4] = fishTable[5];
                        //fishTable[3] = fishTable[4];
                        //fishTable[2] = fishTable[3];
                        //fishTable[1] = fishTable[2];
                        //fishTable[0] = fishTable[6];

                    }
                }   

            }
            foreach (KeyValuePair<int, BigInteger> kvp in fishTable)
                Console.WriteLine("days old: {0}, number: {1}", kvp.Key, kvp.Value);


            BigInteger sum = 
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
