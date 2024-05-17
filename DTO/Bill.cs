using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyQuanCafe.DTO
{
    public class Bill
    {
        public Bill(int idBill, DateTime? dateCheckIn, DateTime? dateCheckOut, int statusBill, int discount = 0, float totalPrice = 0)
        {
            this.IDBill = idBill;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.StatusBill = statusBill;
            this.Discount = discount;
            this.TotalPrice = totalPrice;
        }
        public Bill(DataRow row)
        {
            this.IDBill = (int)row["idBill"];
            this.DateCheckIn = (DateTime?)row["dateCheckIn"];
            if(row["dateCheckOut"].ToString() != "")
            {
                this.DateCheckOut = (DateTime?)row["dateCheckOut"];
            }
            
            this.StatusBill = (int)row["statusBill"];
            if (row["discount"].ToString() != "")
            {
                this.Discount = (int)row["discount"];
            }
            if (row["totalPrice"].ToString() != "")
            {
                this.TotalPrice = (float)Convert.ToDouble(row["totalPrice"].ToString());
            }
 

        }

        private int idBill;

        private DateTime? dateCheckIn;

        private DateTime? dateCheckOut;

        private int statusBill;

        private int discount;

        private float totalPrice;
        public int IDBill { get => idBill; set => idBill = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int StatusBill { get => statusBill; set => statusBill = value; }
        public int Discount { get => discount; set => discount = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
