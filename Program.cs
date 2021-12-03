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
            string oxrat = string.Empty;
            string corat = string.Empty;
            int powerconsumption = 0;
            List<string> oxygen = _inputData.ToList();
            List<string> cotwo = _inputData.ToList();

            for (int j = 0; j < _inputData.First().Length; j++)
            {

                countzero = 0;
                countone = 0;

                for (int i = 0; i < _inputData.Count; i++)
                {
                    string s = _inputData[i];
                    char c = s[j];
                    if (c == '0')
                        countzero++;
                    else countone++;
                }

                //for (int i = 0; i < _inputData.Count; i++)
                //{
                if (countone >= countzero && oxygen.Count > 0)
                        oxygen = oxygen.Where(x => x[j] == '1').ToList();
                if (countone < countzero && oxygen.Count > 0)
                        oxygen = oxygen.Where(x => x[j] == '0').ToList();
                if (countone >= countzero && cotwo.Count > 0)
                    cotwo = cotwo.Where(x => x[j] == '0').ToList();
                if (countone < countzero && cotwo.Count > 0)
                    cotwo = cotwo.Where(x => x[j] == '1').ToList();

                 oxrat = oxygen.Select(x => x.Count = 1).Select(x => x);                        
                    if(cotwo.Count == 1)
                        cotwo.First().ToString();   
            


            int decimalgamma = Convert.ToInt32(gammarate, 2);
            int decimalepsilon = Convert.ToInt32(epsilonrate, 2);
            //powerconsumption = decimalepsilon * decimalgamma;




            //Console.WriteLine(gammarate + "/n" + decimalgamma);
            //Console.WriteLine(epsilonrate + "/n" + decimalepsilon);    
            //Console.WriteLine(powerconsumption);



        

            foreach (string i in oxygen)
            {
                Console.WriteLine(i);
            }
            foreach (string i in cotwo)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Hit any key to close this window...");
            Console.ReadKey();

        }




        private static void readInput()
            {
                _inputData = System.IO.File.ReadAllLines("Input.txt").ToList();
            }
        }
    }
