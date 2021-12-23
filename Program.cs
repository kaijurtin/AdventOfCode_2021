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
                if (allBingoCards[i].winIndexLine < allBingoCards[i].winIndexRow)
                    allBingoCards[i].winIndex = allBingoCards[i].winIndexLine;
                else
                    allBingoCards[i].winIndex = allBingoCards[i].winIndexRow;
                allBingoCards[i].winningNumber = nums[allBingoCards[i].winIndex];
            }
            //var winningCardLine = allBingoCards.OrderBy(x => x.winIndexLine).FirstOrDefault();
            //var winningCardRow = allBingoCards.OrderBy(x => x.winIndexRow).FirstOrDefault();
            //BingoCard winningCard = null;

            //if (winningCardLine.winIndexLine < winningCardRow.winIndexRow)
            //{
            //    winningCard = winningCardLine;
            //    winningCard.winIndex = winningCardLine.winIndexLine;
            //    winningCard.winningNumber = nums[winningCard.winIndex];
            //}
            //else
            //{
            //    winningCard = winningCardRow;
            //    winningCard.winIndex = winningCardRow.winIndexRow;
            //    winningCard.winningNumber = nums[winningCard.winIndex];
            //}




            //calculate score
            List<int> drawnNumbers = new List<int>();
            List<int> sumNumbers = new List<int>();
            
            
            var lastWinningCard = allBingoCards.OrderByDescending(x => x.winIndex).First();

            drawnNumbers = nums.Where(x => nums.IndexOf(x) <= lastWinningCard.winIndex).ToList();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!drawnNumbers.Contains(lastWinningCard.card[i, j]))
                        sumNumbers.Add(lastWinningCard.card[i, j]);
                }
            }

            
            
            int sum = sumNumbers.Sum(x => x);

            var score = sum * lastWinningCard.winningNumber;


            Console.WriteLine("Number of Bingo Cards: " + allBingoCards.Count);
            Console.WriteLine("Number of the winning card: " + loosingCard.id);
            Console.WriteLine("Last Number for the win: " + loosingCard.winningNumber);
            Console.WriteLine("Last Number Index: " + loosingCard.winIndex);
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


