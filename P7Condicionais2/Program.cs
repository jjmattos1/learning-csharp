using System;
using System.Linq;

class P7_9Condicionais2_Escopo
{	
	static void Main(String[] args)
	{
		Console.WriteLine("Projeto 7 - Condicionais 2\n");

		int idade = 17;
		int quantidadePessoas = 3;
		bool acompanhado = quantidadePessoas >= 2;
		//if (idade >= 18 && quantidadePessoas >= 2)
		//condicional usando bool
		if (idade >= 18 || acompanhado)
			{
			Console.WriteLine("Parabens, voce pode entrar! \n");
			}
		else
			{
			Console.WriteLine("Infelizmente voce nao pode entrar! \n");	
			}
		/*
		Lembrando de que se deve respeitar o escopo das variaveis.
		Se tiver que usar alguma dentro de condicionais, ela tera que ser
		declarada fora desse escopo/condicional para poder existir.
		*/
		
	}
	
}