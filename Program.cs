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
            List<string> oxygen = _inputData.ToList();
            List<string> cotwo = _inputData.ToList();

            for (int j = 0; j < _inputData.First().Length; j++)
            {

                countzero = 0;
                countone = 0;

                for (int i = 0; i < oxygen.Count; i++)
                {
                    string s = oxygen[i];
                    char c = s[j];
                    if (c == '0')
                        countzero++;
                    else countone++;
                }
                
                
                if (countone >= countzero)
                    oxygen = oxygen.Where(x => x[j] == '1').ToList();
                if (countone < countzero)
                    oxygen = oxygen.Where(x => x[j] == '0').ToList();
                if (oxygen.Count == 1)
                    oxrat = oxygen.First();


                for (int i = 0; i < cotwo.Count; i++)
                {
                    string s = cotwo[i];
                    char c = s[j];
                    if (c == '0')
                        countzero++;
                    else countone++;
                }
                if (countone >= countzero)
                    cotwo = cotwo.Where(x => x[j] == '0').ToList();
                if (countone < countzero)
                    cotwo = cotwo.Where(x => x[j] == '1').ToList();
                if (cotwo.Count == 1)
                    corat = cotwo.First();

                //oxrat = oxygen.Select(x => x.Count = 1).Select(x => x);                        
                //   if(cotwo.Count == 1)
                //       cotwo.First().ToString();   


            }
            int decimalcorat = Convert.ToInt32(corat, 2);
            int decimaloxrat = Convert.ToInt32(oxrat, 2);
            int result = decimalcorat * decimaloxrat;



            Console.WriteLine(corat);
            Console.WriteLine(oxrat);

            Console.WriteLine(decimalcorat);
                Console.WriteLine(decimaloxrat);
                Console.WriteLine(result);





            
            Console.WriteLine("Hit any key to close this window...");
            Console.ReadKey();

        }




        private static void readInput()
            {
                _inputData = System.IO.File.ReadAllLines("Input.txt").ToList();
            }
        }
    }
