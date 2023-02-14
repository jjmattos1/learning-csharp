using System;
using System.Linq;
using System.IO;
namespace Csharp_exception
//using Csharp_exception.Titular;
//using Csharp_exception.Contas;

{
	public class Program
	{
		public static void Main()
		{
			// https://learn.microsoft.com/pt-br/dotnet/csharp/fundamentals/exceptions/
			// https://learn.microsoft.com/pt-br/dotnet/csharp/fundamentals/exceptions/compiler-generated-exceptions
			
			Console.WriteLine("\n");
			Console.WriteLine(@"/-\ Alura /-\");
			Console.WriteLine("\nExceções C#\n");
			
			//Console.WriteLine("Taxa de operação: "+ContaCorrente.TaxaOperacao);
			
			/*
			
			Assim como várias outras linguagens, o C# utiliza essa pilha
			de execução, que é importante para entendermos o "rastro" da exceção.
			Aqui, o nosso principal objetivo é entender que quando acontece a exceção
			ela se lembra por quais métodos passou.
			
			No Visual Studio conseguimos exibir a pilha de chamadas e usar a janela
			Pilha de Chamadas no depurador. Para isso, durante a depuração, no menu Depurar,
			selecione Pilha de Chamadas (CallStack)...
			
			*/
			
            // comentando intervalo devido a atividade "Leitor de Arquivo" em diante
            /*
			try
			{
				ContaCorrente conta1 = new ContaCorrente (1, "1234-X");
				///*
				Console.WriteLine("\nSacando 50 $ ...");
				conta1.Sacar(50);
				Console.WriteLine("Saldo atual: $"+conta1.GetSaldo());
				
				Console.WriteLine("\nSacando 150 $ ...");
				conta1.Sacar(150);
				Console.WriteLine("Saldo atual: $"+conta1.GetSaldo());
				//
                //fim bloco comment
				ContaCorrente conta2 = new ContaCorrente(7891, "456794");
    			// conta1.Transferir(10000, conta2);
    			conta1.Sacar(10000);
				
				
			}
			catch(ArgumentException ex)
			{
				Console.WriteLine("\nParâmetro com erro: "+ ex.ParamName);
				Console.WriteLine("Não é possível criar uma conta com o número de agência menor ou igual a zero!");
				Console.WriteLine(ex.StackTrace);
				Console.WriteLine(ex.Message);
				
			}
			/*
			catch(SaldoInsuficienteException ex)
			{
				Console.WriteLine("Operação negada, saldo insuficiente!");
				Console.WriteLine(ex.Message);
				
			}
			//
            // fim bloco comment2
			catch (OperacaoFinanceiraException e)
			{
    		Console.WriteLine(e.Message);
    		Console.WriteLine(e.StackTrace);

    		Console.WriteLine("Informações da INNER EXCEPTION (exceção interna):");

    		Console.WriteLine(e.InnerException.Message);
    		Console.WriteLine(e.InnerException.StackTrace);
			}
			
			// https://www.alura.com.br/artigos/o-que-e-clean-code
			// https://www.alura.com.br/artigos/design-patterns-introducao-padroes-projeto
			
			// Boa pratica, SOLID: 
			// “S” Single Responsibility Principle (Princípio de responsabilidade única): uma classe deve ter uma e apenas uma razão para mudar.
			// “O” Open-Closed Principle (Princípio aberto/fechado): objetos devem estar disponíveis para extensão, mas fechados para modificação.
			// “L” Liskov Substitution Principle (Princípio de substituição de Liskov): uma subclasse deve ser substituível por sua superclasse.
			// “I” Interface Segregation Principle (Princípio de segregação de interface): uma classe não deve ser obrigada a implementar métodos e interfaces que não serão utilizadas.
			// “D” Dependency Inversion Principle (Princípio de inversão de dependência): dependa de abstrações e não de implementações.
			
			// to study api rest with dot net core 5
			
            */
            // comentando intervalo devido a atividade "Leitor de Arquivo" em diante
            
            // comentando bloco try-catch-finally para usar a logica using
            /*
            LeitorDeArquivo leitor = new LeitorDeArquivo("contas.txt");
            
            try
            {
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
            }
            catch (IOException)
            {
                Console.WriteLine("Leitura interrompida!");
            }
            finally
            {
                leitor.Fechar();
            }
            */
            
            using(LeitorDeArquivo leitor = new LeitorDeArquivo("contas.txt"))
            {
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
            }
            
            
			// 
		}
	}
}