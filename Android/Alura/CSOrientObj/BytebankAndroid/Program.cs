using BytebankAndroid;
using System;
using System.Linq;
using System.Collections.Generic;

public class Program
	{
// diferentemente do VS 2022 com C# 6.0,
// essa versao do copilador do Android
// exige que se tenha declarado o bloco
// Main conforme linha abaixo. Sem isso
// o copilador nao copila.
		static void Main(string[] args)
		{
			/*
			BankingAccount AndreAccount = new BankingAccount();
			
			//conta default
			BankingAccount conta = new BankingAccount();
			Console.WriteLine("###############");
			Console.WriteLine("Conta default\n");
			Console.WriteLine($"Titular da conta: {conta.owner}");
			Console.WriteLine($"Número da conta: {conta.accNum}");
			Console.WriteLine($"Agência: {conta.agNum}");
			Console.WriteLine($"Saldo R$ {String.Format("{0:0.00}", conta.balance)}");
			Console.WriteLine("###############");
			// Console.ReadKey();
			
			AndreAccount.owner = "André Silva";
			AndreAccount.agNum = 15;
			AndreAccount.accNum = "1010-X";
			AndreAccount.balance = 100;
			
			BankingAccount MariaAccount = new BankingAccount();
			MariaAccount.owner = "Maria Joaquina";
			MariaAccount.agNum = 15;
			MariaAccount.accNum = "1011-X";
			MariaAccount.balance = 300;
			
			Console.WriteLine($"\nSaldo da conta do André: R$ {String.Format("{0:0.00}", AndreAccount.balance)}");
			
			AndreAccount.Deposit(100);
			
			Console.WriteLine("\nSaldo da conta do André pós deposito: R$ "+AndreAccount.balance);
			
			AndreAccount.Withdrawn(50);
			
			Console.WriteLine("\nSaldo da conta do André pós saque: R$ "+AndreAccount.balance);
			
			Console.WriteLine($"\nSaldo da conta da Maria é: R$ {String.Format("{0:0.00}", MariaAccount.balance)}");
			*/
			// codigo acima era de quando se acessava diretamente
			// os campos.
			
			
			Client client0 = new Client();
			
			client0.name = "André Silva";
			client0.cpf = "123456789";
			client0.profession = "Analista";
			
			BankingAccount acct0 = new BankingAccount();
			
			acct0.owner = client0;
			acct0.AgNum = 15;
			acct0.accNum = "1010-X";
			acct0.SetBalance(100);
			
			/*
			Client client01 = new Client();
			client01.name = "Texano";
			acct0.tit0 = client01;
			*/
			
			// ctrl+k+c no vs22 e a hotkey para comentar
			// varias linhas de codigo simultaneamente 
			
			Console.WriteLine("\n- Dados da conta e do titular "+acct0.owner.name+":");
			Console.WriteLine("\nAgência: "+acct0.AgNum);
			Console.WriteLine("Conta: "+acct0.accNum);
			Console.WriteLine($"Saldo: {String.Format("{0:0.00}", acct0.GetBalance())}");
			//double showBalance = acct0.GetBalance();
			//Console.WriteLine("Saldo: "+showBalance);
			Console.WriteLine("CPF: "+acct0.owner.cpf);
			Console.WriteLine("Profissão: "+acct0.owner.profession);
			
			//Console.WriteLine("\ntit0: "+acct0.tit0.name);
			
			Console.WriteLine("\n8) Exibir informações de um objeto por um método criado na classe:");
			Console.Write("\nDados da conta do Andre:");
			acct0.ShowAcc(acct0);
			
			

			
			Console.WriteLine("\n\n\nHello!");
			// closing...
			Console.WriteLine("\nPress any key to continue...");
			Console.ReadLine();
			
			/*
			Pelo princípio da responsabilidade, uma classe deve tratar especificamente
			de um tema somente, ter uma responsabilidade única.
			*/
			
			
    	}
	}
