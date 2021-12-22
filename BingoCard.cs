using System;
using System.Collections.Generic;

namespace AdventOfCodeStartProject
{
	public class BingoCard
	{
		public int winningLine { get; set; }
		public int winningRow { get; set; }
		public List<int> winNumsInLine { get; set; }
		public List<int> winNumsInRow { get; set; }
		public int winIndexRow { get; set; }
		public int winIndexLine { get; set; }
		public int winIndex { get; set; }
		public int winningNumber { get; set; }
		public int winningNumberLine { get; set; }
		public int winningNumberRow { get; set; }
		public bool isBingo { get; set; } = false;

		public int id { get; set; }
		public int[,] card { get; set; }

		public BingoCard(int id, int[,] card)
		{
			this.id = id;
			this.card = card;
			winNumsInLine=new List<int>();
			winNumsInRow=new List<int>();
			winningNumber=0;
			winIndex=0;

		}

		public void checkLines(List<int> nummern)
		{
			for (int i = 0; i < nummern.Count; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					if (nummern[i] == card[j, 0])
						winNumsInLine.Add(nummern[i]);

					if (winNumsInLine.Count == 5)
					{
						isBingo = true;
						winningNumberLine = nummern[i];
						winIndexLine = i;
						winningLine = j;
						winNumsInLine.Clear();
						//Console.WriteLine("number: " + winningNumberLine);
						//Console.WriteLine("number Index: " + winIndexLine);
						//Console.WriteLine("line: " + winningLine);
					}
				}
			}
		}
		public void checkRows(List<int> nummern)
		{
			for (int i = 0; i < nummern.Count; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					if (nummern[i] == card[0,j])
						winNumsInRow.Add(nummern[i]);

					if (winNumsInRow.Count == 5)
					{
						isBingo=true;
						winningNumberRow = nummern[i];
						winIndexRow = i;
						winningRow = j;
						winNumsInRow.Clear();
						//Console.WriteLine("number: " + winningNumberRow);
						//Console.WriteLine("number Index: " + winIndexRow);
						//Console.WriteLine("line: " + winningRow);
					}
				}
			}
		}



	}
}