using PM_QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyQuanCafe.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }
        public static int TableWidth = 76;
        public static int TableHeigh = 76;
        private TableDAO() { }

        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }

            return tableList;
        }
        public Table GetTableByID(int idTable)
        {
            Table table = null;
            // Thực hiện truy vấn cơ sở dữ liệu để lấy thông tin của bàn dựa trên ID của nó
            // sử dụng DataProvider.Instance.ExecuteQuery:
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableByID @idTable", new object[] { idTable });

            // Kiểm tra xem có dữ liệu trả về hay không
            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];

                // Tạo một đối tượng Table từ dữ liệu trong DataRow
                table = new Table(row);
            }
            return table;
        }

        public void SwitchTable(int idOldTable, int idNewTable)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwitchTable @idOldTable , @idNewTable", new object[] { idOldTable, idNewTable });
        }
        public void CombineTable(int idOldTable, int idNewTable)
        {
            DataProvider.Instance.ExecuteQuery("USP_CombineTable @idOldTable , @idNewTable", new object[] { idOldTable, idNewTable });
        }
        public DataTable GetListTable()
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListTable");
        }
        public bool InsertTable(string nameTable, string statusTable)
        {
            // Kiểm tra xem bàn có tồn tại trong Table hay không
            string checkQuery = string.Format("SELECT COUNT(*) FROM dbo.FTable WHERE nameTable = N'{0}'", nameTable);
            int count = (int)DataProvider.Instance.ExecuteScalar(checkQuery);
            if (count > 0)
            {
                // Nếu bàn đã tồn tại, không thêm bàn mới và trả về false
                return false;
            }
            string query = string.Format("INSERT dbo.FTable (nameTable, statusTable) VALUES (N'{0}',N'{1}')", nameTable, statusTable);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateTable(int idTable, string nameTable, string statusTable)
        {
            // Kiểm tra xem bàn có tồn tại trong Table hay không
            string checkQuery = string.Format("SELECT COUNT(*) FROM dbo.FTable WHERE nameTable = N'{0}' AND idTable != {1}", nameTable, idTable);
            int count = (int)DataProvider.Instance.ExecuteScalar(checkQuery);
            if (count > 0)
            {
                // Nếu bàn đã tồn tại, không sửa bàn và trả về false
                return false;
            }
            string query = string.Format("Update dbo.FTable SET nameTable = N'{0}', statusTable = N'{1}' WHERE idTable = {2}", nameTable, statusTable, idTable);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteTable(int idTable)
        {
            //BillDAO.Instance.DeleteTableByBill(idTable);
            string query = string.Format("DELETE FROM dbo.FTable WHERE idTable ={0}", idTable);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

    }
}
