using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyQuanCafe.DTO
{
    public class Category
    {
        public Category(int idCategory, string nameCategory)
        {
            this.IDCategory = idCategory;
            this.NameCategory = nameCategory;
        }

        public Category(DataRow row)
        {
            this.IDCategory = (int)row["idCategory"];
            this.NameCategory = row["nameCategory"].ToString();
        }

        private int idCategory;
        private string nameCategory;

        public int IDCategory { get => idCategory; set => idCategory = value; }
        public string NameCategory { get => nameCategory; set => nameCategory = value; }
    }
}
