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
            
            
            int countzero = 0;
            int countone = 0;
            string gammarate= string.Empty;
            string epsilonrate = string.Empty;
            int powerconsumption = 0;
                
                for(int j = 0; j < _inputData.First().Length; j++)
                {
                
                countzero = 0;
                countone = 0;

                for (int i = 0; i < _inputData.Count; i++)
                    { 
                    string s = _inputData[i];
                    char c = s[j];
                    if (c=='0')
                        countzero++;
                    else countone++;
                    }

                if (countone > countzero)
                {
                    gammarate += "1";
                    epsilonrate += "0";
                }
                else
                {
                    gammarate += "0";
                    epsilonrate += "1";
                }
                }
            int decimalgamma = Convert.ToInt32(gammarate, 2);
            int decimalepsilon = Convert.ToInt32(epsilonrate, 2);
            powerconsumption = decimalepsilon * decimalgamma;



            Console.WriteLine(gammarate + "/n" + decimalgamma);
            Console.WriteLine(epsilonrate + "/n" + decimalepsilon);    
            Console.WriteLine(powerconsumption);



            Console.WriteLine("Hit any key to close this window...");
            Console.ReadKey();
        }



        private static void readInput()
        {
            _inputData = System.IO.File.ReadAllLines("Input.txt").ToList();
        }
    }
}

