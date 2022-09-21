using System;
using System.Linq;

class P9plus_SwitchCase

{
	static void Main(string[] args)
		{
			Console.WriteLine("Projeto 9 plus - Switch case test\n");
			
			Console.WriteLine("Digite o mes do ano desejado,"
								+" (exemplo: 1).\n");
	
			// declarando variavel a ser testada e 
			// na sequencia o uso logico da funcao Switch
			int mes = 1;
			mes = Convert.ToInt32(Console.ReadLine());
			
			switch (mes)
				{
					// tentei utilizar valicao de
					// condicao dentro de um switch e nao funcionou:
					//case (mes == 1 || mes == 01):
					case 1:
					Console.WriteLine("Janeiro.\n");
					break;
					case 2:
					Console.WriteLine("Fevereiro.\n");
					break;
					case 3:
					Console.WriteLine("Março.\n");
					break;
					case 4:
					Console.WriteLine("Abril.\n");
					break;
					case 5:
					Console.WriteLine("Maio.\n");
					break;
					case 6:
					Console.WriteLine("Junho.\n");
					break;
					case 7:
					Console.WriteLine("Julho. \n");
					break;
					case 8:
					Console.WriteLine("Agosto.\n");
					break;
					case 9:
					Console.WriteLine("Setembro.\n");
					break;
					case 10:
					Console.WriteLine("Outubro.\n");
					break;
					case 11:
					Console.WriteLine("Novembro.\n");
					break;
					case 12:
					Console.WriteLine("Dezembro.\n");
					break;
					//codigo...
					default:
					Console.WriteLine("Mes invalido.\n");
					break;
				}
			//closing...
			Console.WriteLine("Press any key to continue...\n\n");
			Console.ReadLine();
		}
}