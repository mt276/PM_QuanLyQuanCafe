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
    public partial class LoginWinform : BaseForm
    {
        private Panel pnlUser;
        private Label lbUserName;
        private Label lbPassword;
        private TextBox txbUsername;
        private TextBox txbPassword;
        private Button btnLogin;
        private Button btnExit;
        private PictureBox ptbLogin;
        public LoginWinform()
        {
            InitializeComponent();
            this.Width = 450;
            this.Height = 280;
            this.BackColor = Color.FromArgb(157, 177, 201);
            LoginForm();
        }
        #region GUI
        void LoginForm()
        {
            #region Panel
            // Khởi tạo và cấu hình Panel
            pnlUser = new Panel();
            pnlUser.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);
            pnlUser.BackColor = Color.FromArgb(218, 234, 250); // Màu nền

            // Tính toán vị trí để đặt Panel vào giữa form
            pnlUser.Location = new Point((this.ClientSize.Width - pnlUser.Width) / 2,
                                                               (this.ClientSize.Height - pnlUser.Height) / 2);

            // Thêm Panel vào Form
            this.Controls.Add(pnlUser);
            #endregion
            ptbLogin = new PictureBox();
            ptbLogin.Image = new Bitmap(Application.StartupPath + "\\image\\login.png");
            ptbLogin.SizeMode = PictureBoxSizeMode.Zoom;
            ptbLogin.Size = new Size(150, 150);
            ptbLogin.Location = new Point(0, 15);
            //ptbLogin.Dock = DockStyle.Fill;
            pnlUser.Controls.Add(ptbLogin);
            #region lbUsername
            // Thêm txbUsername vào Panel
            lbUserName = new Label();
            lbUserName.Text = "Tên đăng nhập:";
            lbUserName.AutoSize = true;
            lbUserName.Location = new Point(150, 52); // Vị trí lbUsername
            pnlUser.Controls.Add(lbUserName);
            #endregion
            #region txbUsername
            // Thêm txbUsername vào Panel
            txbUsername = new TextBox();
            txbUsername.Size = new Size(150, 30); // Kích thước txbUsername
            //txbUsername.Text = "Tên đăng nhập";
            txbUsername.Location = new Point(250, 50); // Vị trí txbUsername
            txbUsername.BorderStyle = BorderStyle.FixedSingle;
            pnlUser.Controls.Add(txbUsername);
            #endregion
            #region lbPassword
            // Thêm txbUsername vào Panel
            lbPassword = new Label();
            lbPassword.Text = "Mật khẩu:";
            lbPassword.AutoSize = true;
            lbPassword.Location = new Point(150, 102); // Vị trí lbPassword
            pnlUser.Controls.Add(lbPassword);
            #endregion
            # region txbPassword
            // Thêm txbPassword vào Panel
            txbPassword = new TextBox();
            txbPassword.Size = new Size(150, 30); // Kích thước txbPassword 
            //txbPassword.Text = "Mật khẩu";
            txbPassword.Location = new Point(250, 100); // Vị trí txbPassword
            txbPassword.PasswordChar = '*';
            txbPassword.BorderStyle = BorderStyle.FixedSingle;
            pnlUser.Controls.Add(txbPassword);

            // Vẽ đường viền dưới 
            Label underline = new Label();
            underline.BackColor = Color.DarkGray;
            underline.Location = new Point(10, 165);
            underline.Size = new Size(this.ClientSize.Width - 20, 1);
            pnlUser.Controls.Add(underline);

            #endregion

            #region btnLogin
            // Tạo Button để đăng nhập
            btnLogin = new Button();
            btnLogin.Text = "Đăng nhập";
            btnLogin.Location = new Point(50, 185);
            btnLogin.Size = new Size(150, 40);
            btnLogin.BackColor = Color.FromArgb(0, 122, 217);
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Popup;
            btnLogin.Font = new Font("Roboto", 8, FontStyle.Bold);
            //btnLogin.FlatAppearance.BorderSize = 2; //loại bỏ đường viền
            pnlUser.Controls.Add(btnLogin);
            // Gắn sự kiện Click chp btnLogin
            btnLogin.Click += BtnLogin_Click;
            this.AcceptButton = btnLogin;
            #endregion

            #region btnExit
            // Tạo Button để hủy bỏ
            btnExit = new Button();
            btnExit.Text = "Thoát";
            btnExit.Location = new Point(btnLogin.ClientSize.Width + 90, 185);
            btnExit.Size = new Size(150, 40);
            btnExit.BackColor = Color.FromArgb(0, 122, 217);
            btnExit.ForeColor = Color.White;
            btnExit.Font = new Font("Roboto", 8, FontStyle.Bold);
            btnExit.FlatStyle = FlatStyle.Popup;
            //btnCancel.FlatAppearance.BorderSize = 0; //loại bỏ đường viền
            pnlUser.Controls.Add(btnExit);
            // Gắn sự kiện Click chp btnCancel
            btnExit.Click += BtnExit_Click; 

            this.CancelButton = btnExit;
            #endregion
        }
        #endregion

        #region Method
        #endregion
        #region Events
        private void LoginWinform_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            //{
            //    e.Cancel = true;
            //};
        }
        bool Login(string userName, string password)
        {
            return AccountDAO.Instance.Login(userName, password);
        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUsername.Text;
            string password = txbPassword.Text;

            if (Login(userName, password))
            {
                Account loginAcount = AccountDAO.Instance.GetAccountByUserName(userName);
                this.Hide();
                MainWinform main = new MainWinform(loginAcount);
                main.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
            }

        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            // Thực hiện xử lý hủy bỏ ở đây, ví dụ:
            if(MessageBox.Show("Bạn có muốn thoát chương trình?","Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }

        }
        #endregion


    }

}
