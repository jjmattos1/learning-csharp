using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CsharpRegex
{
	public class Program
	{
		public static void Main()
		{
			// https://www.alura.com.br/artigos/regex-c-sharp-utilizar-expressoes-regulares
			Console.WriteLine("/| Alura /|\n"
								+"\nRegex C#\n");
			
			/*
			Additional info about var variable: https://cursos.alura.com.br/forum/topico-variavel-tipo-var-137637
			
			Marco Colsato:
			Usando var sua variável continuando estando fortemente tipada, mas seu
			tipo está implícito, ou seja, o compilador infere o tipo dela.
			
			Quando seu código é compilado, var name = "Marco"; e string name = "Marco"; viram a mesma coisa.
			*/
								
			Console.Write("\nDigite um valor para validar se é numérico: ");
			string toValidate = Console.ReadLine();
			
			bool validation = Regex.IsMatch(toValidate,"^[0-9]+$");
			if (!validation)
			{
				Console.WriteLine("\nO valor informado não é numérico!");
			}
			else
			{
				Console.WriteLine("\nO valor informado é numérico!");
			}
			
			
		}
	}
}