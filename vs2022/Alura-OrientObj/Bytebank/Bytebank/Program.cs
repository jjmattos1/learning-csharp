using Bytebank;
using System;
using System.Linq;
// line
BankingAccount AndreAccount = new BankingAccount();

AndreAccount.owner = "André Silva";
AndreAccount.agNum = 15;
AndreAccount.accNum = "1010-X";
AndreAccount.balance = 100;

Console.WriteLine("Saldo da conta do André: R$ "+AndreAccount.balance);

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

Console.WriteLine("\nSaldo da conta do André pós deposito: R$ " + AndreAccount.balance);

AndreAccount.Withdrawn(50);

Console.WriteLine("\nSaldo da conta do André pós saque: R$ " + AndreAccount.balance);

Console.WriteLine($"\nSaldo da conta da Maria é: R$ {String.Format("{0:0.00}", MariaAccount.balance)}");

AndreAccount.Transfer(50, MariaAccount);

Console.WriteLine($"\nSaldo da conta da Maria, apos transf. da conta do Andre: R$ {String.Format("{0:0.00}", MariaAccount.balance)}");
Console.WriteLine($"E o saldo da conta do Andre: R$ {String.Format("{0:0.00}", AndreAccount.balance)}");
// closing...
Console.WriteLine("\n\nPress any key to continue...");
Console.ReadLine();