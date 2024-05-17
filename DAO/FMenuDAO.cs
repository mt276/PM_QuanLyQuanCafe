using PM_QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyQuanCafe.DAO
{
    public class FMenuDAO
    {
        private static FMenuDAO instance;

        public static FMenuDAO Instance
        {
            get { if (instance == null) instance = new FMenuDAO(); return FMenuDAO.instance; }
            private set => FMenuDAO.instance = value;
        }

        private FMenuDAO() { }

        public List<FMenu> GetMenuByCategoryID(int idCategory)
        {
            List<FMenu> fMenuList = new List<FMenu>();

            string query = "Select * From dbo.Menu where idCategory = "+idCategory;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                FMenu fMenu = new FMenu(item);
                fMenuList.Add(fMenu);
            }
            return fMenuList;
        }

        public List<FMenu> SearchMenuByname(string name)
        {
            List<FMenu> list = new List<FMenu>();

            string query = string.Format("SELECT * FROM dbo.Menu WHERE dbo.fuConvertToUnsign1(nameMenu) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                FMenu fMenu = new FMenu(item);
                list.Add(fMenu);
            }
            return list;
        }

        public DataTable GetListMenu()
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListMenuByCategory");
        }


        public bool InsertMenu(string nameMenu, int idCategory, float price)
        {
            // Kiểm tra xem món có tồn tại trong Menu hay không
            string checkQuery = string.Format("SELECT COUNT(*) FROM dbo.Menu WHERE nameMenu = N'{0}'", nameMenu);
            int count = (int)DataProvider.Instance.ExecuteScalar(checkQuery);
            if (count > 0)
            {
                // Nếu món đã tồn tại, không thêm món mới và trả về false
                return false;
            }
            string query = string.Format("INSERT dbo.Menu (nameMenu, idCategory, price) VALUES (N'{0}', {1}, {2})", nameMenu, idCategory, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateMenu(int idMenu, string nameMenu, int idCategory, float price)
        {
            // Kiểm tra xem món có tồn tại trong Menu hay không
            string checkQuery = string.Format("SELECT COUNT(*) FROM dbo.Menu WHERE nameMenu = N'{0}' AND idMenu != {1}", nameMenu, idMenu);
            int count = (int)DataProvider.Instance.ExecuteScalar(checkQuery);
            if (count > 0)
            {
                // Nếu món đã tồn tại, không thêm món mới và trả về false
                return false;
            }
            string query = string.Format("Update dbo.Menu SET nameMenu = N'{0}', idCategory = {1}, price = {2} WHERE idMenu ={3}", nameMenu, idCategory, price, idMenu);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteMenu(int idMenu)
        {
            BillInfoDAO.Instance.DeleteBillInfoByIDMenu(idMenu);
            string query = string.Format("DELETE FROM dbo.Menu WHERE idMenu ={0}", idMenu);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public void DeleteMenuByIDCategory(int idCategory)
        {
            DataProvider.Instance.ExecuteQuery("DELETE dbo.Menu WHERE idCategory = " + idCategory);
        }


    }
}
