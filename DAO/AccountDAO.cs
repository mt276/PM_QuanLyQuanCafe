using PM_QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PM_QuanLyQuanCafe.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance 
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }
        private AccountDAO() { }

        public bool Login(string userName, string password) 
        {
            //byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);
            //byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(temp);

            //string hashPass = "";
            //foreach (byte item in hashPass)
            //{
            //    hashPass += item;
            //}
            //var list = hashData.ToString();
            //list.Reverse();


            string query = "USP_Login @userName , @password ";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] {userName,password /*list*/});
            
            return result.Rows.Count > 0;
        }
        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.account WHERE userName = '" + userName+" '");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        public bool UpdateAccount(string userName, string displayName, string password, string newPassword)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @username , @displayName , @password , @newPassword ", new object[] {userName, displayName,password,newPassword });

            return result > 0;

        }
        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListAccount");
        }
        public bool InsertAccount(string username, string displayName, int typeUser)
        {
            // Kiểm tra xem tên tài khoản có tồn tại trong Account hay không
            string checkQuery = string.Format("SELECT COUNT(*) FROM dbo.Account WHERE username = N'{0}' ", username);
            int count = (int)DataProvider.Instance.ExecuteScalar(checkQuery);
            if (count > 0)
            {
                // Nếu tên tài khoản đã tồn tại, không thêm tên mới và trả về false
                return false;
            }
            string query = string.Format("INSERT dbo.Account (username, displayName, typeUser) VALUES (N'{0}', N'{1}', {2})", username, displayName, typeUser);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateAccount(string username, string displayName, int typeUser)
        {
            //// Kiểm tra xem tên tài khoản có tồn tại trong Account hay không
            //string checkQuery = string.Format("SELECT COUNT(*) FROM dbo.Account WHERE username = N'{0}' AND typeuser = {1}", username,typeUser);
            //int count = (int)DataProvider.Instance.ExecuteScalar(checkQuery);
            //if (count > 0)
            //{
            //    // Nếu tên tài khoản đã tồn tại, không cập nhật và trả về false
            //    return false;
            //}
            string query = string.Format("Update dbo.Account SET displayName = N'{0}' , typeUser = {1} WHERE username = N'{2}'", displayName, typeUser, username);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteAccount(string username)
        {
            string query = string.Format("DELETE FROM dbo.Account WHERE username = N'{0}'", username);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool ResetPasswprd(string username)
        {
            string query = string.Format("UPDATE dbo.account set password = N'0' WHERE username = N'{0}'", username);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

    }
}
