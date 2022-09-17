using System;

class sw_CriandoVariaveis
{
  static void Main(string[] args)
  {
    Console.WriteLine("Projeto 2 - Criando variáveis");
    
    int idade;
    idade = 27;
    Console.WriteLine("Minha idade é "+ idade);
    idade = 27*11;
    Console.WriteLine("Minha idade é "+ idade);
    idade = idade/2;
    Console.WriteLine("Minha idade é "+ idade);
    idade = idade - (54+78) * 2;
    Console.WriteLine("Minha idade é "+ idade);

    Console.WriteLine("Press any key to continue...");
    Console.ReadLine();
  }
}