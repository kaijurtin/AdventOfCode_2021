using System;

public class BingoCard
{
		public int id = 0;
		public int[,] card = new int[5,5];
		public int winningLine = 0;
		public int winningRow = 0;
	
	
	
	public BingoCard (int id, int[,] card)
	{
		this.id = id;
		this.card = card;
		
	}



	public override string ToString()
	{
		return id.ToString() ;

	}
}