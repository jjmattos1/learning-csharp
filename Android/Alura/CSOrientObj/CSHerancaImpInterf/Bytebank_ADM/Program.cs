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
			
			#region
			/*
			Console.WriteLine("\n> C#: Usando herança e implementando interfaces");
			Console.WriteLine("\n1) Employee class and method overload.");
			
			//Console.WriteLine("\n...");
			//
			Employees emp0 = new Employees("0123456789", 2000);
			emp0.Name = "Pedro Malazartes";
			// cpf, wage propertie being forced to be sent via default constructor method
			//emp0.Cpf = "0123456789";
			//emp0.Wage = 2500;
			//Console.WriteLine("\n");
			Console.WriteLine("\nBônus salarial do "+emp0.Name+": "+emp0.getBonus());
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
			}
			
			BonusCalc();
			UseSystem();
			
			//
		}
	}
}