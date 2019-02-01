using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque_Sabinas.cs
{
    class Buyout
    {
        private string quantity;        
        private string customer;
        private string price;
        private int quantityTotal;

        public string Quantity { get => quantity; set => quantity = value; }
        public string Customer { get => customer; set => customer = value; }
        public string Price { get => price; set => price = value; }
        public int QuantityTotal { get => quantityTotal; set => quantityTotal = value; }
    }
}
