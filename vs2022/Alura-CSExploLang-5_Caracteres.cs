using System;

class Projeto5
{
  static void Main(string[] args)
  {
    Console.WriteLine("Projeto 5 - Caracteres:\n");
    //a variável do tipo char é sempre interpretada internamente como um numero.
    //E também é obrigatório de que seja usado aspas simples, para delimitar a apenas um caracter na variável.
    char letra = 'a';
    char letraa = letra;
    Console.WriteLine(letra+"\n");
    
    letra = (char)65;
    Console.WriteLine(letra+" variavel em ASCii pos 65\n");
    
    letraa = (char)(65+1);
    Console.WriteLine(letra+" variavel em acima ASCii adicionado + 1\n");
    
    
    Console.WriteLine("Press any key continue...");
    Console.ReadLine();
  }
}