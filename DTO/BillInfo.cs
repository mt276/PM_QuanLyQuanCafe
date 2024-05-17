using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyQuanCafe.DTO
{
    public class BillInfo
    {
        public BillInfo(int idBillInfo, int idBill, int idMenu, int count)
        {
            this.IDBillInfo = idBillInfo;
            this.IDBill = idBill;
            this.IDMenu = idMenu;
            this.Count = count;
        }
        public BillInfo(DataRow row)
        {
            this.IDBillInfo = (int)row["idBillInfo"];
            this.IDBill = (int)row["idBill"];
            this.IDMenu = (int)row["idMenu"];
            this.Count = (int)row["count"];
        }

        private int idBillInfo;
        private int idBill;
        private int idMenu;
        private int count;

        public int IDBillInfo { get => idBillInfo; set => idBillInfo = value; }
        public int IDBill { get => idBill; set => idBill = value; }
        public int IDMenu { get => idMenu; set => idMenu = value; }
        public int Count { get => count; set => count = value; }
    }
}
