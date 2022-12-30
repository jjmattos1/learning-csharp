using System;
using System.Linq;

namespace DES_OpersClasss
{
	public static class Program
	{
		public static void Main()
		{
			Console.WriteLine("Alura");
			Console.WriteLine("\n> C#: Usando herança e implementando interfaces");
			Console.WriteLine("\nDesafio: classes de operações");
			//
			int op = -1;
			
			while (op != 0)
			{
				Console.Clear();
				Console.WriteLine("\n.: Calculadora :.");
				Console.WriteLine("\n Escolha a opção desejada:");
				Console.WriteLine("1 - Somar");
				Console.WriteLine("2 - Subtrair");
				Console.WriteLine("3 - Multiplicar");
				Console.WriteLine("4 - Dividir");
				Console.WriteLine("\n\nDigite 0 para sair. ");
				Console.WriteLine("Escolha uma opção: ");
				op = Convert.ToInt32(Console.ReadLine());
			}
			
			
			
			//
		}
	}
}