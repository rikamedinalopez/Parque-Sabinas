using MySql.Data.MySqlClient;
using Parque_Sabinas.database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque_Sabinas.cs
{
    public class Section
    {
        private static string id_section;
        private static string nameSection;

        private static string id_caja;
        private static string nameCaja;

        public string Id_section { get => id_section; set => id_section = value; }
        public string NameSection { get => nameSection; set => nameSection = value; }
        public string Id_caja { get => id_caja; set => id_caja = value; }
        public string NameCaja { get => nameCaja; set => nameCaja = value; }

        Connection connection = new Connection();

        public DataSet LoadSections()
        {
            MySqlCommand cmd = new MySqlCommand(String.Format("select id_section, name_section from sections where status = 'A'"), connection.Conectando());
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "LoadSections");
            return ds;
        }

        public DataSet LoadCajas()
        {
            MySqlCommand cmd = new MySqlCommand(String.Format($"select id_cashBox, nameCashBox from cashBox where id_section = {id_section} and status = 'A'"), connection.Conectando());
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "LoadSections");
            return ds;
        }

        public int addSection()
        {
            MySqlCommand cmd = new MySqlCommand(String.Format($"insert into sections(name_section) values ('{ nameSection }')"), connection.Conectando());
            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int deletSection()
        {
            MySqlCommand cmd = new MySqlCommand(String.Format($"update sections set status = 'I' where id_section = {id_section}"), connection.Conectando());
            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int addCaja()
        {
            MySqlCommand cmd = new MySqlCommand(String.Format($"insert into cashBox(nameCashBox, id_section) value ('{ nameCaja }', { id_section});"), connection.Conectando());
            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int deletCaja()
        {
            MySqlCommand cmd = new MySqlCommand(String.Format($"update cashBox set status = 'I' where id_cashBox = { id_caja }"), connection.Conectando());
            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
