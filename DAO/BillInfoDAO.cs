using PM_QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyQuanCafe.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set => BillInfoDAO.instance = value;
        }

        private BillInfoDAO() { }

        public List<BillInfo> GetListBillInfo(int idBill)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.BillInfo WHERE idBill =" + idBill);

            foreach (DataRow item in data.Rows)
            {
                BillInfo billInfo = new BillInfo(item);
                listBillInfo.Add(billInfo);
            }

            return listBillInfo;
        }
        public void InsertBillInfo(int idBill, int idMenu, int count)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBillInfo @idBill , @idMenu , @count ", new object[] { idBill, idMenu, count });
        }
        public void DeleteBillInfoByIDMenu(int idMenu)
        {
            DataProvider.Instance.ExecuteQuery("DELETE dbo.BillInfo WHERE idMenu = " + idMenu);
        }
    }
}
    