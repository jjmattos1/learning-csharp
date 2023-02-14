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
			
			/*
			Usando o .IsMatch()
			Com o IsMatch podemos validar se um valor informado combina com a expressão
			regular definida. O retorno do método é um booleano e recebe como parâmetro uma string.
			*/
			bool validation = Regex.IsMatch(toValidate,"^[0-9]+$");
			if (!validation)
			{
				Console.WriteLine("\nO valor informado não é numérico!");
			}
			else
			{
				Console.WriteLine("\nO valor informado é numérico!");
			}
			
			Console.Write("\nDigite um CPF: ");
			var cpf = Console.ReadLine();
			
			/*
			Usando o .Match()
			Este método pode ser usado para buscar uma string ou
			expressão regex definida na classe.
			*/
			
			Regex regexCpfMask = new Regex(@"([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})", RegexOptions.IgnoreCase);
			var cpfFormatValid = regexCpfMask.Match(cpf);
			if (cpfFormatValid.Success)
			{
				Console.WriteLine("\nO formato do CPF esta válido!");
			}
			else
			{
				Console.WriteLine("\nO formato do CPF esta inválido!");
			}
			
			// https://www.alura.com.br/artigos/javascript-replace-manipulando-strings-e-regex
			// https://www.alura.com.br/conteudo/expressoes-regulares
			// https://docs.microsoft.com/pt-br/dotnet/api/system.text.regularexpressions.regex?view=net-6.0
			
			/*
			
			https://www.alura.com.br/artigos/c-sharp-entendendo-classes-e-structs
			
			*/
			
			
		}
	}
}