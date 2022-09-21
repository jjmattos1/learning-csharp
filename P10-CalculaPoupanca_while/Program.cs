using System;
using System.Linq;

class P10_CalculaPoupanca_while

{
	static void Main(string[] args)
	{
		Console.WriteLine("Projeto 10 - Calcula Poupança, laço de repetição while\n");
		
		// dec/init variaveis
		int mes = 1; 
		Console.Write("Digite o valor a ser investido (ex 1000.00) por 1 ano: ");
		double investimento = 0;
		investimento = Convert.ToDouble(Console.ReadLine());
		// input capture ^
		
		// investment calculation
		while (mes <= 12)
			{
				investimento *= 1.0005;
				mes ++;
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