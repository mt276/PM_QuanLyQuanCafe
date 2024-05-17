using PM_QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyQuanCafe.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            private set => CategoryDAO.instance = value;
        }

        private CategoryDAO() { }

        public List<Category> GetCategory()
        {
            List<Category> categoryList = new List<Category>();

            string query = "Select * From dbo.Category";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                categoryList.Add(category);
            }
            return categoryList;
        }
        public DataTable GetListCategory()
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListCategory");
        }
        public Category GetCategoryByID(int idCategory)
        {
            Category category = null;

            string query = "Select * From dbo.Category where idCategory = "+idCategory;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;
            }
            return category;

        }
        public bool InsertCategory(string nameCategory)
        {
            // Kiểm tra xem danh mục có tồn tại trong Category hay không
            string checkQuery = string.Format("SELECT COUNT(*) FROM dbo.Category WHERE nameCategory = N'{0}'", nameCategory);
            int count = (int)DataProvider.Instance.ExecuteScalar(checkQuery);
            if (count > 0)
            {
                // Nếu danh mục đã tồn tại, không thêm danh mục mới và trả về false
                return false;
            }
            string query = string.Format("INSERT dbo.Category (nameCategory) VALUES (N'{0}')", nameCategory);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateCategory(int idCategory, string nameCategory)
        {
            // Kiểm tra xem danh mục có tồn tại trong Category hay không
            string checkQuery = string.Format("SELECT COUNT(*) FROM dbo.Category WHERE nameCategory = N'{0}' AND idCategory != {1}", nameCategory, idCategory);
            int count = (int)DataProvider.Instance.ExecuteScalar(checkQuery);
            if (count > 0)
            {
                // Nếu danh mục đã tồn tại, không sửa danh mục và trả về false
                return false;
            }
            string query = string.Format("Update dbo.Category SET nameCategory = N'{0}'WHERE idCategory ={1}", nameCategory, idCategory);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteCategory(int idCategory)
        {
            
            //FMenuDAO.Instance.DeleteMenuByIDCategory(idCategory);
            string query = string.Format("DELETE FROM dbo.Category WHERE idCategory ={0}", idCategory);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }


    }
}
