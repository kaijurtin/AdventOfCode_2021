using System;
using System.Collections.Generic;

namespace AdventOfCodeStartProject
{
	public class BingoCard
	{
		//public static int id {get;set;}
		//public static int[,] card { get; set; }
		public int winningLine { get; set; }
		public int winningRow { get; set; }
		public List<int> winNumsInLine { get; set; }
		public List<int> winNumsInRow { get; set; }
		public int winIndexRow { get; set; }
		public int winIndexLine { get; set; }
		public int winningNumber { get; set; }
		public int id { get; set; }
		public int[,] card { get; set; }

		public BingoCard(int id, int[,] card)
		{
			this.id = id;
			this.card = card;
			winNumsInLine=new List<int>();
			winNumsInRow=new List<int>();	
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
						winningNumber = nummern[i];
						winIndexLine = i;
						winningLine = j;
						winNumsInLine.Clear();
                        Console.WriteLine("number: " + winningNumber);
                        Console.WriteLine("number Index: " + winIndexLine);
                        Console.WriteLine("line: " + winningLine);
					}
				}

			}
		}


		public override string ToString()
		{
			return id.ToString();

		}
	}
}