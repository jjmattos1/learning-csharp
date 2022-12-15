using System;
using System.Linq;
using System.Collections.Generic;

namespace DES_FastFood
{
    public class Order 
    {         
        public int id;
        public Client client;
        // max 4 foods per order;
        public Food food0, food1, food2, food3;
        // order status, finished/delivered
        public bool status;
    }
}