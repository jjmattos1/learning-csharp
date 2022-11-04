using System;
using System.Linq;

class P14_LacoRepWhile_For
{
    static void Main(string[] args)
    {

        Console.WriteLine("Projeto 14 e 15 - Laço de repetição While e For\n");
        Console.WriteLine();

        int countWhile, countFor;
        countWhile = countFor = 0;

        Console.WriteLine("While:\n");

        while ( countWhile < 10 )
        {
            Console.WriteLine(countWhile);
            countWhile++;
        }
        Console.WriteLine();

        Console.WriteLine("For:\n");

        for ( countFor = 0; countFor < 10; countFor++ )
        {
            Console.WriteLine(countFor);
        }

        // closing...
        Console.WriteLine("\n\nPress any key to continue...");
        Console.ReadLine();

    }
}