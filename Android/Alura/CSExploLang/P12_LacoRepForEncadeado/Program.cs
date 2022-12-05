using System;
using System.Linq;

class P12_LacoRepFor
{
	static void Main(string[] args)
	{
		Console.WriteLine("Projeto 12 - Investimento a longo prazo, laço de repetição for encadeado\n");
		
		double investimento = 0;
		double fatorRendimento = 1.005;
		int mes, ano, anos = 1;
		
		Console.Write("Digite a quantidade de anos que o valor ficará investido: ");
		anos = Convert.ToInt16(Console.ReadLine());
		
		Console.Write("\nDigite o valor a ser investido (ex 1000.00) por "+ anos +" ano(s): ");
		investimento = Convert.ToDouble(Console.ReadLine());
		
		// input capture ^
		
		// investment calculation, using for
		
		for (ano = 1; ano <= anos; ano++)
		{
			for (mes = 1; mes <= 12; mes++)
			{
				investimento *= fatorRendimento;
			}
			
			fatorRendimento += 0.001;
		}
		// applying the correct number format and showing the result
		string investFinal = investimento.ToString("#.##");
		Console.WriteLine("\nApos "+ anos +" ano(s), o valor investido atualizado ficará em:\n"+
							"\nR$ "+ investFinal);
		
		
		// closing...
		Console.WriteLine("\n\nPress any key to continue...");
		Console.ReadLine();
	}
}