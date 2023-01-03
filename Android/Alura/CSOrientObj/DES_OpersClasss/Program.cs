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
			double num1, num2;
			num1 = num2 = 0;
			
			while (op != 0)
			{
				Console.Clear();
				Console.WriteLine("\n.: Calculadora :.");
				Console.WriteLine("\n Escolha a opção desejada:\n");
				Console.WriteLine("1 - Somar dois números");
				Console.WriteLine("2 - Subtrair dois números");
				Console.WriteLine("3 - Multiplicar dois números");
				Console.WriteLine("4 - Dividir dois números");
				Console.WriteLine("\nDigite 0 para sair.");
				Console.Write("\nEscolha uma opção: ");
				op = Convert.ToInt32(Console.ReadLine());
				
				if ( op == 1)
				{
					
					// ToDo: 1) Show results directly from the specific class method, instead of the actual way of displaying it.

					//
					//double a,b;
					//a = b = 0;
					/*
					Console.WriteLine("\nDigite o 1o número e pressione enter: ");
					num1 = Convert.ToDouble(Console.ReadLine());

					Console.WriteLine("Digite o 2o número e pressione enter: ");
					num2 = Convert.ToDouble(Console.ReadLine());
					*/
					Sum Sum = new Sum();
					Console.WriteLine("\nDigite o 1o num pressione enter, depois o 2o e aperte enter novamente: \n");
					//Console.WriteLine("\n");
					Console.Write("\n"+ (num1 = Convert.ToDouble(Console.ReadLine())) + " + " + (num2 = Convert.ToDouble(Console.ReadLine())) + " = " + (Sum.Do(num1,num2)));
					//Console.Write("\n"+ (num1 = Convert.ToDouble(Console.ReadLine())) + " + " + (num2 = Convert.ToDouble(Console.ReadLine())) + " = " + (Operations.xSum.Do(num1,num2)));
					
					
					//Console.Write("Resultado da soma: "+sum.sum(num1,num2));
					
					//Console.WriteLine("Resultado da soma: "+sum.sum(num1,num2));
					// ao inves de usar o Console.ReadKey(), se usa esta função
					// para pausar o console por 5 segundos!
					Console.WriteLine("\n\nVoltaremos ao menu principal em 5 segundos...");
					System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
					//Console.ReadKey();
					// op 1 end
				}
				
				if ( op == 2 )
				{
					Subtraction Subtraction = new Subtraction();

					Console.WriteLine("\nDigite o 1o num pressione enter, depois o 2o e aperte enter novamente: \n");
					
					Console.Write("\n"+ (num1 = Convert.ToDouble(Console.ReadLine())) + " - " + (num2 = Convert.ToDouble(Console.ReadLine())) + " = " + (Subtraction.Do(num1,num2)));
					
					Console.WriteLine("\n\nVoltaremos ao menu principal em 5 segundos...");
					System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
					// op 2 end
				}
				
				if ( op == 3 )
				{
					Multiplication Multiplication = new Multiplication();

					Console.WriteLine("\nDigite o 1o num pressione enter, depois o 2o e aperte enter novamente: \n");
					
					Console.Write("\n"+ (num1 = Convert.ToDouble(Console.ReadLine())) + " x " + (num2 = Convert.ToDouble(Console.ReadLine())) + " = " + (Multiplication.Do(num1,num2)));
					
					Console.WriteLine("\n\nVoltaremos ao menu principal em 5 segundos...");
					System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
					// op 3 end
				}
				
				if ( op == 4 )
				{
					Division Division = new Division();

					Console.WriteLine("\nDigite o 1o num pressione enter, depois o 2o e aperte enter novamente: \n");
					
					Console.Write("\n"+ (num1 = Convert.ToDouble(Console.ReadLine())) + " ÷ " + (num2 = Convert.ToDouble(Console.ReadLine())) + " = " + (Division.Do(num1,num2)));
					
					Console.WriteLine("\n\nVoltaremos ao menu principal em 5 segundos...");
					System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
					// ToDo: 2) format the Division result with a max of 2 decimals.
					// op 4 end
				}
			// while menu end	
			}
			// Main class end
		}
	}
}