using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class P6Condiconais
{
	static void Main(string[] args)
		{
		Console.WriteLine("Projeto 6 - Condicionais\n");
		
		int idade = 17;
		int quantidadePessoas = 3;
		if (idade >= 18)
			{
			Console.WriteLine("Parabens, voce pode entrar! \n");
			}
		else
			if (quantidadePessoas >= 3)
				{
				Console.WriteLine("Voce nao tem 18 mas, "
				+ "esta acompanhado e por isso pode entrar!");
				}
				else
				{
				Console.WriteLine("Infelizmente voce nao pode entrar!");	
				}
		
		}
}