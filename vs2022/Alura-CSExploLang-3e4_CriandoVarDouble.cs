using System;

class Projetos3e4
{
  static void Main(string[] args)
  {
    Console.WriteLine("Projetos 3 e 4 - Criando variáveis de Ponto Flutuante\n");
    
    double salario;
    salario = 7000.10;
    Console.WriteLine("Salário formato double:");
    Console.WriteLine(salario+"\n");
    //Console.WriteLine("\n");
    
    Console.WriteLine("Salário formato inteiro:");
    int salarioInt = (int)salario;
    Console.WriteLine(salarioInt+"\n");
    
    Console.WriteLine("Salário formato long:");
    long salarioLong = 200000000000;
    Console.WriteLine(salarioLong+"\n");
    //Console.WriteLine("\n");
    
    Console.WriteLine("Salário formato short:");
    short salarioShort = 16368;
    Console.Write(salarioShort);
    Console.WriteLine("\n");
    
    Console.WriteLine("Altura formato float (f letter on the variable):");
    float altura = 1.809f;
    Console.Write(altura);
    Console.WriteLine("\n");
    
    // variável int comporta apenas 32 bits de dados
    Console.WriteLine("Salário formato int:");
    int idade = 27;
    Console.WriteLine(idade);
    
    
    //Console.Writeline("Salário formato long:");
    //Console.Writeline();
  }
}