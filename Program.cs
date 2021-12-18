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
        private static List<string> numbers => _inputData?.First().Split(',').ToList();
        private static List<int> nums => numbers?.ConvertAll(item => int.Parse(item));

        static void Main(string[] args)
        {
            //EXAMPLE CODE
            //hit F5 to run it

            //read data from input.txt and write it into inputdata field
            readInput();
            //List<int> _inputDataINT = _inputData.ConvertAll(item => int.Parse(item));


            //List<string> blocksonly = _inputData[3].Split().Where(x => x != "").ToList();
            List<string> bingoLine = new List<string>();

            int arraylength = 5;
            int[,] boxes = new int[arraylength, arraylength];
            //List<int[,]> listofboxes = new List<int[,]>();

            //int winningNumber = 0;
            //List<int> lineHits = new List<int>();
            List<BingoCard> allBingoCards = new List<BingoCard>();
            int boxID = 0;

            int counterLine = 0;
            for (int i = 2; i < _inputData.Count; i++)
            {
                if (_inputData[i] == "")
                {
                    i++;
                }

                bingoLine = _inputData[i].Split().Where(x => x != "").ToList();


                //print all numbers of the line with index
                /*foreach(string item in bingoLine)
                {
                    Console.WriteLine("number " + item + "\t index " + bingoLine.IndexOf(item));
                }
                */
                for (int j = 0; j < bingoLine.Count; j++)
                {

                    int value = int.Parse(bingoLine[j]);
                    boxes[j, counterLine] = value;
                }

                counterLine++;

                if (counterLine == 5)
                {
                    boxID++;
                    counterLine = 0;
                    //listofboxes.Add(boxes);
                    BingoCard card = new BingoCard(boxID, boxes);
                    allBingoCards.Add(card);
                    boxes = new int[arraylength, arraylength];
                }
            }
            for(int i = 0; i < allBingoCards.Count; i++)
            {
                allBingoCards[i].checkLines(nums);
                allBingoCards[i].checkRows(nums);
            }
            var winningCardLine = allBingoCards.OrderBy(x=>x.winIndexLine).First();
            var winningCardRow = allBingoCards.OrderBy(x=>x.winIndexRow).First();
            BingoCard winningCard = null;

            if(winningCardLine.winIndexLine < winningCardRow.winIndexRow)
            {
                winningCard = winningCardLine;
                winningCard.winIndex = winningCardLine.winIndexLine;
                winningCard.winningNumber = winningCardLine.winningNumberLine;
            }
            else
            {
                
                winningCard = winningCardRow;
                winningCard.winIndex = winningCardRow.winIndexRow;
                winningCard.winningNumber = winningCardRow.winningNumberRow;
            }


            List<int> drawnNumbers = new List<int>();
            List<int> sumNumbers = new List<int>();
            int sum = 0;
            int cardSum = 0;
            int checkSum = 0;

            drawnNumbers = nums.Where(x => nums.IndexOf(x) <= winningCard.winIndex ).ToList();
            
            for(int i = 0; i < 5; i++)
            {
               for(int j=0; j<5;j++)
                {
                    if (!drawnNumbers.Contains(winningCard.card[i, j]))
                        sumNumbers.Add(winningCard.card[i, j]);
                }
                
            }

            sum = sumNumbers.Sum(x=>x);


            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    cardSum += winningCard.card[i,j];
                }
            }
            
                var score = sum*winningCard.winningNumber;
                

            Console.WriteLine("Number of Bingo Cards: " + allBingoCards.Count);
            Console.WriteLine("Number of the winning card: " + winningCard.id);
            Console.WriteLine("Last Number for the win: " + winningCard.winningNumber);
             Console.WriteLine("Last Number Index: " + winningCard.winIndex);
            Console.WriteLine("Summe: " + sum);
            Console.WriteLine("score: " + score);
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


