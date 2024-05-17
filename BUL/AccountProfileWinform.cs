using PM_QuanLyQuanCafe.DAO;
using PM_QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM_QuanLyQuanCafe
{
    public partial class AccountProfileWinform : BaseForm
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get => loginAccount;
            set
            {
                loginAccount = value;
                ChangeAccount(loginAccount);
            }
        }
        public AccountProfileWinform(Account acc)
        {
            InitializeComponent();
            this.Size = new Size(410, 320);
            this.BackColor = Color.FromArgb(215, 229, 242);

            SetUpAccount();
 

            this.LoginAccount = acc;
        }
        #region GUI
        private FlowLayoutPanel flpAccount;
        private Panel pnlUserName;
        private Label lbUserName;
        private TextBox txbUserName;
        private Panel pnlDisplayName;
        private Label lbDisplayName;
        private TextBox txbDisplayName;
        private Panel pnlPassWord;
        private Label lbPassWord;
        private TextBox txbPassWord;
        private Panel pnlNewPassWord;
        private Label lbNewPassWord;
        private TextBox txbNewPassWord;
        private Panel pnlConfirmPassWord;
        private Label lbConfirmPassWord;
        private TextBox txbConfirmPassWord;
        private Panel pnlButton;
        private Button btnExit;
        private Button btnUpdate;
        void SetUpAccount()
        {
            #region 
            flpAccount = new FlowLayoutPanel();
            flpAccount.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);
            flpAccount.Location = new Point(10, 10);
            flpAccount.FlowDirection = FlowDirection.TopDown;
            this.Controls.Add(flpAccount);
            #endregion
            #region pnlUserName
            pnlUserName = new Panel();
            pnlUserName.Size = new Size(this.ClientSize.Width - 25, 40);
            flpAccount.Controls.Add(pnlUserName);
            #endregion

            #region pnlUserName
            lbUserName = new Label();
            lbUserName.Text = "Tên đăng nhập: ";
            lbUserName.Location = new Point(5, 10);
            lbUserName.AutoSize = true;
            pnlUserName.Controls.Add(lbUserName);
            #endregion

            #region txbUserName
            txbUserName = new TextBox();
            txbUserName.Location = new Point(120, 10);
            txbUserName.Size = new Size(250, 50);
            txbUserName.ReadOnly = true;
            txbUserName.BorderStyle = BorderStyle.FixedSingle;
            pnlUserName.Controls.Add(txbUserName);
            #endregion

            #region pnlDisplayName
            pnlDisplayName = new Panel();
            pnlDisplayName.Size = new Size(this.ClientSize.Width - 25, 40);
            flpAccount.Controls.Add(pnlDisplayName);
            #endregion

            #region lbDisplayName
            lbDisplayName = new Label();
            lbDisplayName.Text = "Tên hiển thị: ";
            lbDisplayName.Location = new Point(5, 10);
            pnlDisplayName.Controls.Add(lbDisplayName);
            #endregion

            #region txbDisplayName
            txbDisplayName = new TextBox();
            txbDisplayName.Location = new Point(120, 10);
            txbDisplayName.Size = new Size(250, 50);
            txbDisplayName.BorderStyle = BorderStyle.FixedSingle;
            pnlDisplayName.Controls.Add(txbDisplayName);
            #endregion

            #region pnlPassWord
            pnlPassWord = new Panel();
            pnlPassWord.Size = new Size(this.ClientSize.Width - 25, 40);
            flpAccount.Controls.Add(pnlPassWord);
            #endregion

            #region lbPassWord
            lbPassWord = new Label();
            lbPassWord.Text = "Mật khẩu: ";
            lbPassWord.Location = new Point(5, 10);
            pnlPassWord.Controls.Add(lbPassWord);
            #endregion

            #region txbPassWord
            txbPassWord = new TextBox();
            txbPassWord.Location = new Point(120, 10);
            txbPassWord.Size = new Size(250, 50);
            txbPassWord.UseSystemPasswordChar = true;
            txbPassWord.BorderStyle = BorderStyle.FixedSingle;
            pnlPassWord.Controls.Add(txbPassWord);
            #endregion

            #region pnlNewPassWord
            pnlNewPassWord = new Panel();
            pnlNewPassWord.Size = new Size(this.ClientSize.Width - 25, 40);
            flpAccount.Controls.Add(pnlNewPassWord);
            #endregion

            #region lbNewPassWord
            lbNewPassWord = new Label();
            lbNewPassWord.Text = "Mật khẩu mới: ";
            lbNewPassWord.Location = new Point(5, 10);
            pnlNewPassWord.Controls.Add(lbNewPassWord);
            #endregion

            #region txbNewPassWord
            txbNewPassWord = new TextBox();
            txbNewPassWord.Location = new Point(120, 10);
            txbNewPassWord.Size = new Size(250, 50);
            txbNewPassWord.UseSystemPasswordChar = true;
            txbNewPassWord.BorderStyle = BorderStyle.FixedSingle;
            pnlNewPassWord.Controls.Add(txbNewPassWord);
            #endregion

            #region pnlConfirmPassWord
            pnlConfirmPassWord = new Panel();
            pnlConfirmPassWord.Size = new Size(this.ClientSize.Width - 25, 40);
            flpAccount.Controls.Add(pnlConfirmPassWord);
            #endregion

            #region lbConfirmPassWord
            lbConfirmPassWord = new Label();
            lbConfirmPassWord.Text = "Nhập lại: ";
            lbConfirmPassWord.Location = new Point(5, 10);
            pnlConfirmPassWord.Controls.Add(lbConfirmPassWord);
            #endregion

            #region txbConfirmPassWord
            txbConfirmPassWord = new TextBox();
            txbConfirmPassWord.Location = new Point(120, 10);
            txbConfirmPassWord.Size = new Size(250, 50);
            txbConfirmPassWord.UseSystemPasswordChar = true;
            txbConfirmPassWord.BorderStyle = BorderStyle.FixedSingle;
            pnlConfirmPassWord.Controls.Add(txbConfirmPassWord);
            #endregion

            #region pnlButton
            pnlButton = new Panel();
            pnlButton.Size = new Size(this.ClientSize.Width - 25, 40);
            flpAccount.Controls.Add(pnlButton);
            #endregion

            #region btnExit
            btnExit = new Button();
            btnExit.Text = "Thoát";
            btnExit.Size = new Size(70, 30);
            btnExit.Location = new Point(300, 0);
            btnExit.BackColor = Color.White;
            pnlButton.Controls.Add(btnExit);
            btnExit.Click += (sender, e) => 
            {
                this.Close();
            };
            this.CancelButton = btnExit;
            #endregion

            #region btnUpdate
            btnUpdate = new Button();
            btnUpdate.Text = "Cập nhật";
            btnUpdate.Size = new Size(70, 30);
            btnUpdate.Location = new Point(210, 0);
            btnUpdate.BackColor = Color.White;
            pnlButton.Controls.Add(btnUpdate);
            this.AcceptButton = btnUpdate;
            btnUpdate.Click += BtnUpdate_Click;
            #endregion
        }

   

        #endregion
        void ChangeAccount(Account acc)
        {
            txbUserName.Text = LoginAccount.UserName;
            txbDisplayName.Text = LoginAccount.DisplayName;
        }

        void UpdateAccoutInfo()
        {
            string displayName = txbDisplayName.Text;
            string password = txbPassWord.Text;
            string newpass = txbNewPassWord.Text;
            string confirmPass = txbConfirmPassWord.Text;
            string userName = txbUserName.Text;

            if (!newpass.Equals(confirmPass))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới!");
            }
            else
            {
                if(AccountDAO.Instance.UpdateAccount(userName, displayName, password, newpass))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    if (updateAccount != null)
                        updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName)));
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khẩu!");
                }
            }
        }

        #region Events
        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccoutInfo();
        }

        #endregion
    }
    public class AccountEvent : EventArgs
    {
        private Account acc;

        public Account Acc { get => acc; set => acc = value; }

        public AccountEvent(Account acc)
        {
            this.Acc = acc;
        }
    }
}
