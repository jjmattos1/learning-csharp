using System;
using System.Linq;

class DES_Multiplos3
{
    static void Main(string[] args)
    {

        Console.WriteLine("Desafio - Imprimir os múltiplos de 3\n");

        int multiplo;
        multiplo = 0;

        while (multiplo <= 100)
        {
            multiplo++;

            if (multiplo % 3 == 0)
            {
                Console.WriteLine(multiplo);
            }
            
            
        }

        // closing...
        Console.WriteLine("\n\nPress any key to continue...");
        Console.ReadLine();

    }
}