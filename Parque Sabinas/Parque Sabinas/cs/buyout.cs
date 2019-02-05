using MySql.Data.MySqlClient;
using Parque_Sabinas.database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Parque_Sabinas.cs
{
    class Buyout : Connection
    {
        private string quantity;        
        private string customer;
        private int price;
        private int quantityTotal;
        private int subTotal;

        public string Quantity { get => quantity; set => quantity = value; }
        public string Customer { get => customer; set => customer = value; }
        public int Price { get => price; set => price = value; }
        public int QuantityTotal { get => quantityTotal; set => quantityTotal = value; }
        public int SubTotal { get => subTotal; set => subTotal = value; }

        public DataSet Customers()
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter(String.Format("SELECT type_customer FROM type_customer;"), Conectando());            
            adapter.Fill(ds, "type_customer");
            return ds;
            
        }

        public int CheckPrice()
        {
            MySqlConnection conn = Conectando();
            string query = "SELECT price_customer FROM type_customer where type_customer='" + customer + "'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            int unit_price = Convert.ToInt16(cmd.ExecuteScalar());
            conn.Close();
            return unit_price;
        }

        public int SubTotalPrice()
        {
            char[] caracteres = {'x'};
            int quantityInt = Convert.ToInt32(quantity.Trim(caracteres));                        
            int subtotal = (quantityInt * price);
            return subtotal;
        }
    }
}
