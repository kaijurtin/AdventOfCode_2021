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
            List<string> bingoLine = new List<string>();
            //int arraylength = 5;
            //Array  [,] boxes = new Array[arraylength, arraylength];
            int winningNumber = 0;
            List<int> lineHits = new List<int>();
            List<WinLine> winningLines= new List<WinLine>();

            for (int i = 2; i < _inputData.Count - 2; i++)
            {

                bingoLine = _inputData[i].Split().Where(x => x != "").ToList();
                //int counterLine = 0;
                //int countercolumn = 0;

                int winningLine = 0;
                int winningNumberIndex=0;
                bool winnerLine = false;

                for (int j=0; j < numbers.Count; j++)
                {
                    //bingoLine = bingoLine.Where(x=>x.Equals(numbers[j])).ToList();
                    if (bingoLine.Contains(numbers[j]))
                        lineHits.Add(Int32.Parse(numbers[j]));


                    if (lineHits.Count == 5)
                    {
                        winnerLine = true;
                        //winningNumber = Int32.Parse(numbers[j]);
                        //winningNumberIndex = j;
                        //winningLine = i;
                        winningLines.Add(new WinLine(i, Int32.Parse(numbers[j]), j));
                        break;
                    }
                    
                }
                lineHits.Clear();

                if (winnerLine = true)
                {
                    //Console.WriteLine("Number: " + winningNumber);
                    //Console.WriteLine("Number Index: " + winningNumberIndex);
                    //Console.WriteLine("Line: " + winningLine);
                foreach(object WinLine in winningLines)
                    { Console.WriteLine(WinLine.ToString()); }
                            
                            //Console.ReadKey();
                }
                winnerLine = false;


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
class WinLine 
{
    public int LineIndex { get; set; }
    public int Number { get; set; }
    public int NumberIndex { get; set; }

    public WinLine (int line, int number, int index)
    {
        LineIndex = line;
        Number = number;
        NumberIndex = index;
    }
    public override string ToString()
    {
        return LineIndex + " " + Number + " " + NumberIndex + " ";
    }
}


