using System;
using System.Collections.Generic;

public class BingoCard
{
	//public static int id {get;set;}
	//public static int[,] card { get; set; }
	public static int winningLine { get; set; }
	public static int winningRow { get; set; }
	public static List<int> winNumsInLine { get; set; }
	public static List<int> winNumsInRow { get; set; }
	public static int winIndexRow { get; set; }
	public static int winIndexLine { get; set; }
	public static int winningNumber { get; set; }


	public BingoCard (int id, int[,] card)
	{
		this.id = id;
		this.card = card;
		
	}

	private static void checkLines(List<int> nummern)
	{

		for (int i = 0; i < nummern.Count; i++)
		{
			for (int j = 0; j < 5; j++)
			{
				if (nummern[i] == card[j, 0])
					winNumsInLine.Add(nums[i]);
				
				if (winNumsInLine.Count == 5)

				{	
					winningNumber = nummern[i]
					winIndexLine = i;
					winNumsInLine.Clear(); 
				}



				}

		}
	}


	public override string ToString()
	{
		return id.ToString() ;

	}
}