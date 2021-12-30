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
            int numberOfDays = 256;
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


            BigInteger[] fishdata = new BigInteger[9];
            

            foreach (int i in fish)
            {
                fishdata[i] ++ ;
            }

            for (int n = 0; n < numberOfDays; n++)
            {
                BigInteger newfish = fishdata[0];
                fishdata[0] = fishdata[1];
                fishdata[1] = fishdata[2];
                fishdata[2] = fishdata[3];
                fishdata[3] = fishdata[4];
                fishdata[4] = fishdata[5];
                fishdata[5] = fishdata[6];
                fishdata[6] = fishdata[7];
                fishdata[7] = fishdata[8];
                fishdata[8] = newfish;
                fishdata[6] += newfish;
            }

            BigInteger total = 0;

            foreach (BigInteger n in fishdata)
                total += n;

            Console.WriteLine(total);
        


        

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
