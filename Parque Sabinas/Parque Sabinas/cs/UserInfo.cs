using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parque_Sabinas.cs
{
    class UserInfo
    {
        private static int _id;
        private static string _name_User;
        private static string _user_Name;
        private static string _section;
        private static string type_User;
        

        public int Id { get => _id; set => _id = value; }
        public string Name_User { get => _name_User; set => _name_User = value; }
        public string User_Name { get => _user_Name; set => _user_Name = value; }
        public string Section { get => _section; set => _section = value; }
        public string Type_User { get => type_User; set => type_User = value; }
        
    }
}
