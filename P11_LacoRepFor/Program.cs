using System;
using System.Linq;

class P11_LacoRepFor
{
	static void Main(string[] args)
	{
		Console.WriteLine("Projeto 11 - Calcula ''Poupança'', laço de repetição for\n");
		
		double investimento = 0;
		Console.Write("Digite o valor a ser investido (ex 1000.00) por 1 ano: ");
		investimento = Convert.ToDouble(Console.ReadLine());
		// input capture ^
		
		// investment calculation, using for
		int mes = 1;
		for (mes = 1; mes <= 12; mes++)
			{
				investimento *= 1.0005;
			}
		// applying the correct number format and showing the result
		string investFinal = investimento.ToString("#.##");
		Console.WriteLine("\nApos 1 ano, o valor investido atualizado ficará em:\n"+
							"\nR$ "+ investFinal);
		
		
		// closing...
		Console.WriteLine("\nPress any key to continue...");
		Console.ReadLine();
	}
}