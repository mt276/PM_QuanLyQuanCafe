using PM_QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM_QuanLyQuanCafe.DAO
{
    public class TotalPriceBillDAO
    {
        private static TotalPriceBillDAO instance;

        public static TotalPriceBillDAO Instance 
        {
            get { if (instance == null) instance = new TotalPriceBillDAO(); return TotalPriceBillDAO.instance; } 
            private set => TotalPriceBillDAO.instance = value; 
        }

        private TotalPriceBillDAO() { }

        
        public List<TotalPriceBill> GetListMenuByTable (int idTable)
        {
            List<TotalPriceBill> listMenu = new List<TotalPriceBill>();

            string query = "SELECT nameMenu,bf.count,m.price,m.price*bf.count as totalPrice " +
                "FROM dbo.BillInfo as bf, dbo.Bill as b, dbo.Menu as m " +
                "WHERE bf.idBill = b.idBill AND bf.idMenu = m.idMenu AND b.statusBill = 0 AND b.idTable="+ idTable;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            
            foreach (DataRow item in data.Rows)
            {
                TotalPriceBill menus = new TotalPriceBill(item);
                listMenu.Add(menus);
            }



            return listMenu;
        }
    }
}
