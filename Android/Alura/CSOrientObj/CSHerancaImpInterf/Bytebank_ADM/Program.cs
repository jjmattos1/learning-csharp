using System;
using System.Linq;
//using Bytebank_ADM.Employee;

//https://github.com/alura-cursos/curso_OrientacaoObjetosC02R

namespace Bytebank_ADM
{
	public class Program
	{
		public static void Main()
		//static void Main(string[] args)
		{
			Console.WriteLine("/| Alura /|\n");
			Console.WriteLine("\n> CSharp: Usando herança e implementando interfaces");
			Console.WriteLine("\nEmployee emp0 is the object to test the scenarios/cases.");
			
			//Console.WriteLine("\n...");
			//
			Auxiliary emp0 = new Auxiliary("0123456789");
			emp0.Name = "Pedro Malazartes";
			// cpf, wage propertie being forced to be sent via default constructor method
			//emp0.Cpf = "0123456789";
			//emp0.Wage = 2500;
			//Console.WriteLine("\n");
			Console.WriteLine("\nBônus salarial do "+emp0.Name+": "+emp0.getBonus()+".");
			
			
			#region
			
			/*
			//
			Directors dir0 = new Directors("0123456788", 5000);
			dir0.Name = "Roberta Silva";
			// cpf, wage propertie being forced to be sent via default constructor method
			//dir0.Cpf = "0123456788";
			//dir0.Wage = 5000;
			Console.WriteLine("Bônus salarial do(a) "+dir0.Name+": "+dir0.getBonus());
			
			//Employees emp1 = new Employees();
			//emp0.Name = "Pedro1 Malazartes";
			//emp0.Cpf = "0123456787";
			//emp0.Wage = 2700;
			//Console.WriteLine("\n");
			Console.WriteLine("\nBônus salarial do "+emp1.Name+": "+emp1.GetBonus());
			
			//Employees emp2 = new Employees();
			//emp0.Name = "Pedro2 Malazartes";
			//emp0.Cpf = "0123456785";
			//emp0.Wage = 2900;
			//Console.WriteLine("\n");
			Console.WriteLine("\nBônus salarial do "+emp2.Name+": "+emp2.GetBonus());
			
			// 
			//
			Directors dir1 = new Directors();

			//dir1.DirName = "Roberta1 Silva";
			//dir1.DirCpf = "0123456786";
			//dir1.DirWage = 7000;
			//Console.WriteLine("\nBônus salarial do(a) "+dir1.DirName+": "+dir1.DirGetBonus());
			
			// video 9min, criar utilitario Gerenciador de Bonificação.
			//BonusMGMT bonusMgmt = new BonusMGMT();
			//bonusMgmt.Register(emp0);
			//bonusMgmt.Register(dir0);
			
			//bonusMgmt.Register(emp1);
			//bonusMgmt.Register(dir1);
			//bonusMgmt.Register(emp2);
			
			Console.WriteLine("\nO total de bonificações do Bytebank é de: R$ "+ bonusMgmt.BonusTotal);
			
			Console.WriteLine("\nBonus semestral do "+emp0.Name+" é de R$ "+emp0.get1HBonus());
			Console.WriteLine("Bonus semestral do "+dir0.Name+" é de R$ "+dir0.get1HBonus());

			Console.WriteLine("\nTotal de funcionários do Bytebank:  "+Employees.EmployeesTotal);
			//
			emp0.raiseWage();
			Console.WriteLine("\nNovo salário do "+emp0.Name+" é de R$ "+emp0.Wage);
			
			dir0.raiseWage();
			Console.WriteLine("Novo salário do "+dir0.Name+" é de R$ "+dir0.Wage);
			*/
			#endregion
			
			
			void BonusCalc()
			{
				BonusMGMT bonusManager = new BonusMGMT();
				
				Designer emp0 = new Designer("123456");
				emp0.Name = "Ulisses Souza";
				
				Auxiliary emp2 = new Auxiliary("123458");
				emp2.Name = "Igor Dias";
				
				Directors emp1 = new Directors("123457");
				emp1.Name = "Paula Souza";
				emp1.Password = "123";
				
				AccountManager emp3 = new AccountManager("123459");
				emp3.Name = "Camila Oliveira";
				emp3.Password = "321";
				
				
				bonusManager.Register(emp0);
				bonusManager.Register(emp1);
				bonusManager.Register(emp2);
				bonusManager.Register(emp3);
				
				Console.WriteLine("\nO total de bonus pago é de R$ "+bonusManager.BonusTotal);
				Console.WriteLine("\n");
				
				
				//
			}
			
			void UseSystem()
			{
				Directors emp1 = new Directors("123457");
				emp1.Name = "Paula Souza";
				emp1.Password = "123";
				
				AccountManager emp3 = new AccountManager("123459");
				emp3.Name = "Camila Oliveira";
				emp3.Password = "321";
				
				
				InternalSystem internalSystem = new InternalSystem();
				
				internalSystem.LogIn(emp1, "123");
				internalSystem.LogIn(emp1, "321");
				
				internalSystem.LogIn(emp3, "123");
				internalSystem.LogIn(emp3, "321");
				Console.WriteLine("\n");
				internalSystem.LogIn("admin","masterkey");
				Console.WriteLine("");
				internalSystem.LogIn("admin","password");
				
				CommercialPartner caio = new CommercialPartner();
				caio.Password = "999";
				internalSystem.LogIn(caio,"999");
				
				
			}
			
			void Tests1()
			{

				Console.WriteLine("\n> CSharp: Alura+ Classe Object C#");
				
				Console.WriteLine("\n# Remember that is possible to rewrite"+
									" methods from Object and other"+
									" main base C# Classes.");
				
				Console.WriteLine("\n"+emp0.ToString());
				
				Console.WriteLine("\n> CSharp: Concatenando/Interpolando Strings");
				//https://www.alura.com.br/artigos/strings-com-c-sharp-para-manipular-textos
				
				
				// to capture data and input it on a variable:
				// string newVar = Console.ReadLine();
				
				Console.WriteLine("\nDigite a seguir duas palavras.");
				Console.Write("\nDigite a 1a palavra: ");
				string word1 = Console.ReadLine();
				Console.Write("Digite a 2a palavra: ");
				string word2 = Console.ReadLine();
				string defaultTxt = $"\nPrezado colaborador(a) {emp0.Name}, " +
									$"temos o prazer de lhe informar que " +
									$"as palavras digitadas foram {word1} e {word2}!";
				
				// defaultTxt end
				Console.WriteLine("\nO func. teste é "+emp0.Name+". "
									+"O texto padrão"
									+" com as palavras digitadas é: ");
				Console.WriteLine(defaultTxt);
				
				var wordsConc = word1 +"-"+ word2;
				var formattedMsg = string.Format("{0}", wordsConc);
				Console.WriteLine("\nPalavras concatenadas com '-': "+formattedMsg);
				
				Console.WriteLine("\n> CSharp: Verbatim Strings");
				
				string dirTxt = "\nVariável armazenada desta forma:\n";
				
				string dirVarExample1 = " ''string dirExample = ";
				//string dirVarExample2 = "@";
				//string dirVarExample3 = @"''";
				string dirVarExampleX = @"@''C:\temp\codigo'';";
				//dirTxt += dirVarExample;
				Console.WriteLine(dirTxt+dirVarExample1+dirVarExampleX);
				// to store a verbatim string correctly, you must use the @ char before the start of ""
				string dirExample = @"C:\temp\codigo";
				Console.Write("\nResulta em: "+dirExample+"\n");
				// show obs that '' is ".
				
				Console.WriteLine("\nO tamanho total das palavras concatenadas é: "+ wordsConc.Length);
				
				wordsConc = String.Join("", new String[] {word1,word2});
				Console.WriteLine("\nPalavras concatenadas com String.Join são: "+ wordsConc);
				
				// a better example than the one below need to be done (.Split)
				Console.WriteLine("\nPalavras digitadas ant. divididas, sem o '-' (.Split): ");
				string[] _split = wordsConc.Split("-");
				for (int i = 0; i < _split.Length ; i++)
				{
					Console.WriteLine($"{_split[i]}");
				}
				
				Console.WriteLine("\nLembrando que para fins de atualizar uma string (concatenar e interpolar), se poderia usar "
									+"a classe StringBuilder, mais precisamente utilizando o método "
									+" '.Append(''valor'')', pois com ele se atualiza a string atual, "
									+"entregando mais desempenho e facilitando futuras manutenções.");
				
				string wordsConcNew = String.Concat(_split);
				Console.WriteLine("\nPrimeira ocorrência do char {a}, num. index: "+wordsConcNew.IndexOf("a"));
				Console.WriteLine("\nÚltima ocorrência do char {a}, num. index: "+wordsConcNew.LastIndexOf("a"));
				
				// ("Primeira ocorrência do caractere {e} = " + mensagem.IndexOf("e",StringComparison.CurrentCulture));
				// https://stackoverflow.com/questions/417954/c-sharp-string-comparisons-difference-between-currentcultureignorecase-and-inva
				
				string txtReplace = "Substituir o biscoito por YYY!";
				Console.WriteLine("\n"+txtReplace);
				// Console.Write("\nDigite a palavra para substituir o YYY acima: ");
				// string txtReplaceWord = Console.ReadLine();
				txtReplace = txtReplace.Replace("YYY", formattedMsg);
				Console.WriteLine("\nNovo texto: "+txtReplace);
				
				// Substring method is used to extract a string from another string.
				// In the ex. below will be used a way (struct guid) to generate a
				// random UUID/Unique ID number to usr ad an example.
				string randomGuidKey = Guid.NewGuid().ToString();
				// the parameters of .Substring are about the beginning and end of
				// the variable index in question. This way the Substring will
				// extract only the chars between those indexes.
				Console.WriteLine("\nIdentificador gerado: "+ randomGuidKey.Substring(0,8));
				
				Console.WriteLine("\nTestes usando o método '.Equals()'. "
									+"Se uma palavra ou frase são iguais e "
									+"se a 1a palavra é palíndromas.");
				Console.Write("\nDigite a 1a palavra/frase: ");
				word1 = Console.ReadLine();
				Console.Write("Digite a 2a palavra/frase: ");
				word2 = Console.ReadLine();
				if (word1.Equals(word2))
				{
					Console.WriteLine("\nAs palavras/frases digitadas acima são iguais!");
				}
				else
				{
					Console.WriteLine("\nAs palavras/frases digitadas acima são diferentes!");
				}
				
				var reversedWord = new string (word1.Reverse().ToArray());
				if (word1.Equals(reversedWord))
				{
					Console.WriteLine("\nA 1a palavra/frase é palíndroma!");
				}
				else
				{
					Console.WriteLine("\nA 1a palavra/frase não é palíndroma!");
				}
				
				Console.WriteLine("\n\nFalta criar exemplos usando os método '.Insert()' "
									+"(inserir string em outra respeitando indice (ex: example.Insert(2,''TextHere'') "
									+"e tambem com o '.Trim()' que remove espaços de uma string (tem as variações"
									+"'.TrimStart()' e '.TrimEnd() também, indicadas para se usar em formulários).'");
				
				Console.WriteLine("\nMétodos '.toUpper()' e '.toLower()' que colocam toda uma string em maiúscula ou minúscula.");
				
				
				
				Console.WriteLine("\n\n\n\n");
				//Console.WriteLine("");
				
				
				/*
				
				Useful links:
				
				https://docs.microsoft.com/pt-br/dotnet/api/system.string?view=net-6.0
				https://docs.microsoft.com/pt-br/dotnet/standard/base-types/stringbuilder
				https://www.alura.com.br/artigos/strings-com-javascript-o-que-sao-e-como-manipular
				
				*/
			}
			
			
			//BonusCalc();
			
			//UseSystem();
			
			Tests1();
			
			
			// 
			
			
		}
	}
}