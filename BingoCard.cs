using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeStartProject
{
	public class BingoCard
	{
		public int winningLine { get; set; }
		public int winningRow { get; set; }
		public List<int> winNumsInLine { get; set; }
		public List<int> winNumsInRow { get; set; }
		//public List<int> winIndexesLine { get; set; }

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
			//winIndexesLine=new List<int>();
			winningNumber=0;
			winIndex=0;

		}

		public void checkLines(List<int> nummern)
		{
			List <int> winIndexesLine = new List<int>();
			int counter=0;	

			for (int k = 0; k < 5; k++)
			{ 
				for (int i = 0; i < nummern.Count; i++)
				
				{
					for (int j = 0; j < 5; j++)
					{
						if (nummern[i] == card[j, k])
						{
							counter++;
						}
						if (counter == 5)
						{
							winIndexesLine.Add(i);
							counter = 0;
							//k++;
						}
					}

				}
                winIndexLine = winIndexesLine.OrderBy(x => x).First();
            }
		}
			
			
		
		public void checkRows(List<int> nummern)
		{
			List<int> winIndexesRow = new List<int>();
			int counter = 0;

			for (int k = 0; k < 5; k++)
			{
				for (int i = 0; i < nummern.Count; i++)

				{
					for (int j = 0; j < 5; j++)
					{
						if (nummern[i] == card[k, j])
						{
							counter++;
						}
						if (counter == 5)
						{
							winIndexesRow.Add(i);
							counter = 0;
							//k++;
						}
					}

				}
				winIndexRow = winIndexesRow.OrderBy(x => x).First();
			}
		}



	}
}