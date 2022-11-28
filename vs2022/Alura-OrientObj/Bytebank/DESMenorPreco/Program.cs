using System;
using System.Linq;
using System.Transactions;

namespace BestPrice
{
    public class ProdInventory
    {
        public int cod;
        public string name;
        public string manufacturer;
        public int barCode;
        public double unitValue;
        public double buyValue;
        public int invQty;
    }
}