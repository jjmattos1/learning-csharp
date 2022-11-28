using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BestPrice;

 class Visualiza
{
    static void Main(string[] args)
    {
        ProdInventory prod1 = new ProdInventory();

        prod1.cod = 1;
        prod1.name = "teste";
        prod1.manufacturer = "abielzxc";
        prod1.invQty = 12;

        // closing...
        Console.WriteLine("\n\nPress any key to continue...");
        Console.ReadLine();
    }
}
