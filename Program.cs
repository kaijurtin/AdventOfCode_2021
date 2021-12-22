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
            readInput();
            List<string> bingoLine = new List<string>();
            int[,] boxes = new int[5, 5];
            List<BingoCard> allBingoCards = new List<BingoCard>();
            int boxID = 0;
            int counterLine = 0;

            //fill box arrays
            for (int i = 2; i < _inputData.Count; i++)
            {
                if (_inputData[i] == "")
                {
                    i++;
                }

                bingoLine = _inputData[i].Split().Where(x => x != "").ToList();


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
                    BingoCard card = new BingoCard(boxID, boxes);
                    allBingoCards.Add(card);
                    boxes = new int[5, 5];
                }
            }

            //mark all numbers and find winners
            for(int i = 0; i < allBingoCards.Count; i++)
            {
                allBingoCards[i].checkLines(nums);
                allBingoCards[i].checkRows(nums);
            }
            var winningCardLine = allBingoCards.Where(x=>x.isBingo).OrderBy(x => x.winIndexLine).FirstOrDefault();
            var winningCardRow = allBingoCards.Where(x => x.isBingo).OrderBy(x => x.winIndexRow).FirstOrDefault();
            BingoCard winningCard = null;
            Console.WriteLine(allBingoCards.Where(x => x.isBingo).Count());
            if (winningCardLine.winIndexLine < winningCardRow.winIndexRow)
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

            //calculate score
            List<int> drawnNumbers = new List<int>();
            List<int> sumNumbers = new List<int>();

            drawnNumbers = nums.Where(x => nums.IndexOf(x) <= winningCard.winIndex).ToList();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!drawnNumbers.Contains(winningCard.card[i, j]))
                        sumNumbers.Add(winningCard.card[i, j]);
                }
            }

            int sum = sumNumbers.Sum(x => x);

            var score = sum * winningCard.winningNumber;


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


