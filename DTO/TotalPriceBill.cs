using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyQuanCafe.DTO
{
    public class TotalPriceBill
    {
        public TotalPriceBill(string nameMenu, int count, float price, float totalPrice = 0)
        {
            this.NameMenu = nameMenu;
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalPrice;
        }
        public TotalPriceBill(DataRow row)
        {
            this.NameMenu = row["nameMenu"].ToString();
            this.Count = (int)row["count"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            this.TotalPrice = (float)Convert.ToDouble(row["totalPrice"].ToString());
        }

        private string nameMenu;
        private int count;
        private float price;
        private float totalPrice;

        public string NameMenu { get => nameMenu; set => nameMenu = value; }
        public int Count { get => count; set => count = value; }
        public float Price { get => price; set => price = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
