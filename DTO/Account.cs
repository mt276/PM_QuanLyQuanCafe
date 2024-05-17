using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyQuanCafe.DTO
{
    public class Account
    {
        public Account(string userName, string displayName, int typeUser,string password = null)
        {
            this.UserName = userName;
            this.DisplayName = displayName;
            this.TypeUser = typeUser;
            this.Password = password;
        }
        public Account(DataRow row)
        {
            this.UserName = row["userName"].ToString();
            this.DisplayName = row["displayName"].ToString();
            this.TypeUser = (int)row["TypeUser"];
            this.Password = row["password"].ToString();
        }

        private string userName;
        private string displayName;
        private string password;
        private int typeUser;

        public string UserName { get => userName; set => userName = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string Password { get => password; set => password = value; }
        public int TypeUser { get => typeUser; set => typeUser = value; }

    }
}
