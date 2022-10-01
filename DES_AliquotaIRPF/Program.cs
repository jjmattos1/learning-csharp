using System;
using System.Linq;

class DES_AliquotaIRPF
{
		static void Main(string[] args)
		{
			//a partir do proximo sourcode, efetuar os indents corretamente
		Console.WriteLine("Projeto Desafio Aliquota - Controle de fluxo com if\n");
		Console.Write("Digite o seu salario: ");
		
		double salario;
		salario = Convert.ToDouble(Console.ReadLine());
		//declarando variavel e armazenando input
		
		//Console.WriteLine("\n");
		
		if (salario < 1900.0)
			{
				Console.WriteLine("\nVoce e isento de IR,"
									+ " logo nao precisa fazer a declaracao anual.");
			}
		if (salario >= 1900.0 && salario <= 2801.0)
			{
				Console.WriteLine("\nSeu IR é de 7.5% e voce pode deduzir"
									+ " na declaracao R$ 142.");
			}
		if (salario >= 2801.01 && salario <= 3751.0)
			{
				Console.WriteLine("\nSeu IR e de 15% e voce pode deduzir"
									+ " na declaracao R$ 350.");
			}
		else if (salario >= 3751.01)
			{
				//escrever logica final aqui
				Console.WriteLine("\nSeu IR e de 22,5% e voce pode deduzir"
									+ " na declaracao R$ 636.");
			}
			
			Console.WriteLine("\nPress any key to close...");
			Console.ReadLine();
		
		}
}