using System;
using System.Linq;

class DES_Fatorial
{
    static void Main(string[] args)
    {

        Console.WriteLine("Desafio - Imprimir fatoriais de 1 a 10\n");

        int fato, fatoBase, repFato, repFato1, fatoAtual;
        fato = fatoBase = repFato = repFato1 = fatoAtual = 1;
        

        for ( repFato = 1; repFato <= 10; repFato++ )
        {
            if ( repFato = 1 )
                Console.WriteLine("O fatorial de 1 é 1.");
            else
            {
                fatoAtual++;
                
                Console.WriteLine("O fatorial de "+fatoAtual+" é: ");
                for ( repFato1 = 1 ; repFato1 <= fatoAtual ; repFato1++ )
                {
                    fato = repFato1 * fatoAtual;
                    Console.Write(fato);
                    Console.WriteLine("\n");
                }

                //fato++;
            }
        }

        // closing...
        Console.WriteLine("\n\nPress any key to continue...");
        Console.ReadLine();

    }
}