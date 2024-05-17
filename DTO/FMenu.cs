using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyQuanCafe.DTO
{
    public class FMenu
    {
        public FMenu(int idMenu, string nameMenu, int idCategory, float price)
        {
            this.IDMenu = idMenu;
            this.NameMenu = nameMenu;
            this.IDCategory = idCategory;
            this.Price = price;
        }
        public FMenu(DataRow row)
        {
            this.IDMenu = (int)row["idMenu"];
            this.NameMenu = row["nameMenu"].ToString();
            this.IDCategory = (int)row["idCategory"];
            this.Price = (float)Convert.ToDouble(row["Price"].ToString());
        }

        private int idMenu;
        private string nameMenu;
        private int idCategory;
        private float price;

        public int IDMenu { get => idMenu; set => idMenu = value; }
        public string NameMenu { get => nameMenu; set => nameMenu = value; }
        public int IDCategory { get => idCategory; set => idCategory = value; }
        public float Price { get => price; set => price = value; }
    }
}
