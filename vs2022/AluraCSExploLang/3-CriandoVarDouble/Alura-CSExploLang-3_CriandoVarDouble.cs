using System;

class P_3e4
{
  static void Main(string[] args)
  {
    Console.WriteLine("Projetos 3 e 4 - Criando variáveis de Ponto Flutuante\n");
    
    double salario = 7000.10;
    Console.WriteLine("Salário formato double:");
    Console.WriteLine(salario+"\n");
    //Console.WriteLine("\n");
    
    Console.WriteLine("Salário formato long:");
    long salarioLong;
    salarioLong = 200000000000;
    Console.WriteLine(salarioLong+"\n");
    //Console.WriteLine("\n");
    
    Console.WriteLine("Salário formato short:");
    short salarioShort;
    salarioShort = 16368;
    Console.Write(salarioShort);
    Console.WriteLine("\n");
    
    Console.WriteLine("Altura formato float (f letter on the variable:)");
    float altura = 1.809f;
    Console.Write(altura);
    Console.WriteLine("\n");
    // variável int comporta apenas 32 bits de dados
    Console.WriteLine("Salário formato int:");
    int idade = 27;
    Console.WriteLine(idade);
    //Console.Writeline("Salário formato long:");
    //Console.Writeline();
    Console.WriteLine("\nPress any key to continue...");
    Console.ReadLine();
  }
}