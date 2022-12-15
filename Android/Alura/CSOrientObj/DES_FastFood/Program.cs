using System;
using System.Linq;

namespace DES_FastFood
{
	public static class Program
	{
		public static void Main()
		{
			//Console.WriteLine($"...e o saldo da conta do Andre: R$ {String.Format("{0:0.00}", AndreAccount.balance)}");
			
			// class client on DES_FastFood namespace = Client
			// class food on DES_FastFood namespace = Food
			// class order on DES_FastFood namespace = Order
			
			Console.WriteLine("########################################");
			Console.WriteLine("\nJJ's FastFood, orders list:\n");
			
			// inital foods
			Food fries1 = new Food();
			fries1.foodId = 0;
			fries1.desc = "Standard fried french fries";
			fries1.eta = 15;
			
			Food hamb1 = new Food();
			hamb1.foodId = 1;
			hamb1.desc = "Standard base burguer";
			hamb1.eta = 7;
			
			// client 0
			Client client0 = new Client();
			client0.name = "Jonas";
			client0.cpf = 12345678900;
			client0.cellpNum = 21988887777;
			client0.addr ="Rua Sobe e Desce, 111.";
			
			Order order0 = new Order();
			order0.id = 0;
			order0.client = client0; 
			order0.food0 = fries1;
			order0.food1 = hamb1;
			order0.status = false;
			
			Console.WriteLine("\nPending orders, from first to the last one.");
			Console.WriteLine($"\n{order0.id} order, deliver to:");
			
			Console.WriteLine($"\nAdress: {order0.client.addr}");
			Console.WriteLine($"Contact number: {order0.client.cellpNum}");
			Console.WriteLine($"Contact name: {order0.client.name}");
			Console.WriteLine("ETA till ready to sent: "+(order0.food0.eta+order0.food1.eta)+" minutes.");
			
			/*
			Console.WriteLine($"Titular da conta: {obj.}");
			Console.WriteLine($"\nTitular da conta: {obj.}");
			Console.WriteLine($"\nTitular da conta: {obj.}");
			Console.WriteLine($"\nTitular da conta: {obj.}");
			Console.WriteLine($"\nTitular da conta: {obj.}");
			Console.WriteLine($"\nTitular da conta: {obj.}");
			Console.WriteLine($"\nTitular da conta: {obj.}");
			*/
			
			// closing...
			Console.WriteLine("\n\nPress any key to continue...");
			Console.ReadLine();
		}
	}
}