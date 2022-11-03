using System;
using System.Linq;

class P12_LacoRepFor
{
	static void Main(string[] args)
	{
		// begin

		/*
		int mes, ano, anos;
		mes = ano = anos = 1;
		// teste para relembrar dec e init multiple vars no c#
		*/

		int countCols, countLs;
		countCols = countLs = 0;

		Console.WriteLine("Projeto 13 - Encadeando For\n\n");

		
		for ( countLs = 0 ; countLs < 10 ; countLs++ )
		{
			for ( countCols = 0 ; countCols < 10 ; countCols++ )
			{
				Console.Write("*");
				if ( countLs <= countCols )
					break;
			}
			Console.WriteLine("");
		}

				// closing...
		Console.WriteLine("\n\nPress any key to continue...");
		Console.ReadLine();

	}
}