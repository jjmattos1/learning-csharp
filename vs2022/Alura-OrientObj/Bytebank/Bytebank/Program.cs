using Bytebank;
using System;
using System.Linq;
// line
// github rep deste curso https://github.com/alura-cursos/curso_OrientacaoObjetosC01R/tree/main

BankingAccount AndreAccount = new BankingAccount();

AndreAccount.owner = "André Silva";
AndreAccount.agNum = 15;
AndreAccount.accNum = "1010-X";
AndreAccount.balance = 100;

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

Console.WriteLine($"\nSaldo da conta da Maria, apos transf. da conta do Andre: R$ {String.Format("{0:0.00}", MariaAccount.balance)}...");
Console.WriteLine($"...e o saldo da conta do Andre: R$ {String.Format("{0:0.00}", AndreAccount.balance)}");

Console.WriteLine("\nTipo por valor x Tipo por referencia:");

double valuet1 = 300;
double valuet2 = valuet1;
Console.WriteLine("\nTipo por valor, atribuindo a variavel: ");
Console.WriteLine(valuet1==valuet2);
BankingAccount AndreAccount2 = new BankingAccount();
AndreAccount2.owner = "André Silva";
AndreAccount2.agNum = 15;
AndreAccount2.accNum = "1010-X";
AndreAccount2.balance = 100;
Console.Write("\n");
Console.WriteLine("Tipo por referencia, comparando a variavel, retornando se está na mesma posição da memória:");
Console.WriteLine(AndreAccount == AndreAccount2);

Console.WriteLine("\n8) Exibir informações de um objeto por um método criado na classe:");
Console.Write("\nDados da conta do Andre:");
AndreAccount.ShowAcc(AndreAccount);

/*
Pelo princípio da responsabilidade, uma classe deve tratar especificamente
de um tema somente, ter uma responsabilidade única.
*/



Console.Write("\n");
// closing...
//Console.WriteLine("\n\nPress any key to continue...");
//Console.ReadLine();