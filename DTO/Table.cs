using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyQuanCafe.DTO
{
    public class Table
    {
        public Table(int idTable, string nameTable, string status)
        {
            this.IDTable = idTable;
            this.NameTable = nameTable;
            this.StatusTable = status;
        }

        public Table(DataRow row)
        {
            this.IDTable = (int)row["idTable"];
            this.NameTable = (string)row["nameTable"].ToString();
            this.StatusTable = (string)row["statusTable"].ToString();
        }

        private int idTable;

        private string nameTable;

        private string statusTable;
        public int IDTable { get => idTable; set => idTable = value; }
        public string NameTable { get => nameTable; set => nameTable = value; }
        public string StatusTable { get => statusTable; set => statusTable = value; }
    }
}
