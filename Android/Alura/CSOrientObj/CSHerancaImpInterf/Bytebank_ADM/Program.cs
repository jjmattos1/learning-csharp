using System;
using System.Linq;
//using Bytebank_ADM.Employee;

namespace Bytebank_ADM
{
	public class Program
	{
		public static void Main()
		//static void Main(string[] args)
		{
			Console.WriteLine("Alura");
			Console.WriteLine("> C#: Usando herança e implementando interfaces\n");
			Console.WriteLine("1) Employee class and method overload.\n\n");
			
			Console.WriteLine("...");
			
			Employee id0 = new Employee();
			id0.Name = "Pedro";
			id0.Cpf = "0123456789";
			id0.Wage = 2500;
			Console.WriteLine("\n");
			Console.WriteLine("Bônus salarial do "+id0.Name+": "+id0.GetBonus());
			
			
			
		}
	}
}