using PM_QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyQuanCafe.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance 
        {
            get { if (instance == null) instance = new BillDAO();return BillDAO.instance; }  
            private set => BillDAO.instance = value; 
        }

        private BillDAO() { }

        /// <summary>
        /// Thành công: IDBill
        /// Thất bại: -1
        /// </summary>
        /// <param name="idTable"></param>
        /// <returns></returns>
        public int GetUncheckBillIDByTableID(int idTable)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Bill WHERE idTable=" + idTable + " AND statusBill = 0");

            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.IDBill;
            }
            return -1;

        }
        public List<Bill> GetUnpaidBillsByTableID(int idTable)
        {
            List<Bill> billList = new List<Bill>();

            string query = string.Format("Select * From dbo.Bill WHERE idTable = {0} AND statusBill = 0", idTable);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Bill bill = new Bill(item);
                billList.Add(bill);
            }
            return billList;
        }
        public void InsertBill(int idTable)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBill @idTable ", new object[] { idTable });
        }

        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("Select Max(idBill) From dbo.Bill");
            }
            catch 
            {

                return 1;
            }
          
        }

        public void CheckOut(int idBill, int discount,float totalPrice)
        {
            string query = "UPDATE dbo.Bill SET statusBill = 1, DateCheckOut = GETDATE(), discount = "+discount+" , totalPrice = "+totalPrice+ " WHERE idBill = "+idBill;
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public DataTable GetBillListByDate(DateTime checkInt, DateTime checkOut)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListBillByDate @checkIn , @checkOut ",new object[] {checkInt,checkOut });

        }

        public void DeleteTableByBill(int idTable)
        {
            DataProvider.Instance.ExecuteQuery("DELETE dbo.Bill WHERE idTable = " + idTable);
        }
    }
}
