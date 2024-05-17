using Microsoft.Reporting.WinForms;
using PM_QuanLyQuanCafe.DAO;
using PM_QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace PM_QuanLyQuanCafe
{
    public partial class AdminWinform : BaseForm
    {

        //private TabControl tcAdmin;
        //private TabPage tpBill;
        //private TabPage tpMenu;
        //private TabPage tpTable;
        //private TabPage tpAccount;
        //private TabPage tpCategory;
        //private TabPage tpReport;
        public Account loginAccount;
        public AdminWinform()
        {
            dtpkCheckIn.Value = dtpkCheckOut.Value = DateTime.MinValue;

            InitializeComponent();
            this.Size = new Size(820, 500);
            this.BackColor = Color.FromArgb(215, 229, 242);
            tcAdmin.Size = new Size(this.ClientSize.Width - 20, this.ClientSize.Height - 20);
            tcAdmin.Location = new Point(10, 10);
            //this.Controls.Add(tcAdmin);

            // Tạo và thêm các TabPage vào TabControl
            //tpBill = new TabPage("Doanh thu");
            //tpMenu = new TabPage("Món ăn");
            //tpTable = new TabPage("Bàn");
            //tpCategory = new TabPage("Danh mục");
            //tpAccount = new TabPage("Tài khoản");
            //tpReport = new TabPage("Report");


            //tcAdmin.TabPages.Add(tpBill);
            //tcAdmin.TabPages.Add(tpMenu);
            //tcAdmin.TabPages.Add(tpTable);
            //tcAdmin.TabPages.Add(tpCategory);
            //tcAdmin.TabPages.Add(tpAccount);
            //tcAdmin.TabPages.Add(tpReport);


            //Tạo các controls
            SetUpBill();
            SetUpMenu();
            SetUpTable();
            SetUpAccount();
            SetUpCategory();
            SetUpReport();

            //Load danh sách
            LoadData();

        }

        #region GUI
        #region GUI Bill
        private Panel pnlBill;
        private Panel pnlFilterBill;
        private Panel pnlDataBill;
        private DateTimePicker dtpkCheckIn;
        private DateTimePicker dtpkCheckOut;
        private Label lbToDate;
        private Button btnViewBill;
        private DataGridView dtgvBill;
        void SetUpBill()
        {
            // Thêm các controls vào TabPage "Doanh thu"
            pnlBill = new Panel();
            pnlBill.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);
            pnlBill.BackColor = Color.FromArgb(215, 229, 242);
            tpBill.Controls.Add(pnlBill);

            pnlFilterBill = new Panel();
            pnlFilterBill.Location = new Point(5, 5);
            pnlFilterBill.Size = new Size(pnlBill.ClientSize.Width, 60);
            pnlBill.Controls.Add(pnlFilterBill);

            pnlDataBill = new Panel();
            pnlDataBill.Location = new Point(5, 65);
            pnlDataBill.Size = new Size(pnlBill.ClientSize.Width, pnlBill.ClientSize.Height - 60);
            pnlBill.Controls.Add(pnlDataBill);

            // Thêm các controls vào pnlFilter

            dtpkCheckIn = new DateTimePicker();
            dtpkCheckIn.Location = new Point(20, 20);
            dtpkCheckIn.Width = 220;
            pnlFilterBill.Controls.Add(dtpkCheckIn);

            lbToDate = new Label();
            lbToDate.Text = "đến ngày";
            lbToDate.Location = new Point(270, 20);
            lbToDate.Font = new Font("Roboto", 11, FontStyle.Bold);
            pnlFilterBill.Controls.Add(lbToDate);

            dtpkCheckOut = new DateTimePicker();
            dtpkCheckOut.Location = new Point(380, 20);
            dtpkCheckOut.Width = 220;
            pnlFilterBill.Controls.Add(dtpkCheckOut);

            btnViewBill = new Button();
            btnViewBill.Text = "Thống kê";
            btnViewBill.Location = new Point(650, 17);
            btnViewBill.Size = new Size(80, 25);
            btnViewBill.BackColor = Color.White;
            btnViewBill.Click += BtnViewBill_Click;
            pnlFilterBill.Controls.Add(btnViewBill);

            //Thêm các controls vào pnlData;
            dtgvBill = new DataGridView();
            dtgvBill.Location = new Point(5, 0);
            dtgvBill.Size = new Size(pnlDataBill.ClientSize.Width - 50, pnlDataBill.ClientSize.Height - 65);
            dtgvBill.BorderStyle = BorderStyle.FixedSingle;
            dtgvBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            pnlDataBill.Controls.Add(dtgvBill);

        }
        #endregion
        #region GUI Menu
        private Panel pnlMenu;
        private Panel pnlButtonMenu;
        private Panel pnlDataMenu;
        private Panel pnlTextBoxMenu;
        private Button btnViewMenu;
        private Button btnAddMenu;
        private Button btnEditMenu;
        private Button btnDeleteMenu;
        private DataGridView dtgvMenu;
        private TextBox txbSearchMenu;
        private Button btnSearchMenu;
        private Label lbIDMenu;
        private Label lbNameMenu;
        private Label lbCategoryMenu;
        private Label lbPriceMenu;
        private TextBox txbIDMenu;
        private TextBox txbNameMenu;
        private ComboBox cbCategoryMenu;
        private NumericUpDown nrudPriceMenu;

        void SetUpMenu()
        {
            pnlMenu = new Panel();
            pnlMenu.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);
            pnlMenu.BackColor = Color.FromArgb(215, 229, 242);
            pnlMenu.AutoSize = true;
            tpMenu.Controls.Add(pnlMenu);

            // Panel cho các nút Menu
            pnlButtonMenu = new Panel();
            pnlButtonMenu.Location = new Point(0, 0);
            pnlButtonMenu.Size = new Size(this.ClientSize.Width, 60);
            pnlMenu.Controls.Add(pnlButtonMenu);

            // Panel cho dữ liệu Menu
            pnlDataMenu = new Panel();
            pnlDataMenu.Location = new Point(0, 60);
            pnlDataMenu.Size = new Size(500, 350);
            pnlMenu.Controls.Add(pnlDataMenu);

            // Panel cho các TextBox Menu
            pnlTextBoxMenu = new Panel();
            pnlTextBoxMenu.Location = new Point(500, 60);
            pnlTextBoxMenu.Size = new Size(280, 350);
            pnlMenu.Controls.Add(pnlTextBoxMenu);

            //Thêm các button vào pnlButtonMenu
            // Button "Xem"
            btnViewMenu = new Button();
            btnViewMenu.Text = "Xem";
            btnViewMenu.Size = new Size(80, 40);
            btnViewMenu.Location = new Point(10, 10);
            btnViewMenu.BackColor = Color.White;
            btnViewMenu.Click += BtnViewMenu_Click;
            pnlButtonMenu.Controls.Add(btnViewMenu);

            // Button "Thêm"
            btnAddMenu = new Button();
            btnAddMenu.Text = "Thêm";
            btnAddMenu.Size = new Size(80, 40);
            btnAddMenu.Location = new Point(100, 10);
            btnAddMenu.BackColor = Color.White;
            btnAddMenu.Click += BtnAddMenu_Click; 
            pnlButtonMenu.Controls.Add(btnAddMenu);

            // Button "Sửa"
            btnEditMenu = new Button();
            btnEditMenu.Text = "Sửa";
            btnEditMenu.Size = new Size(80, 40);
            btnEditMenu.Location = new Point(190, 10);
            btnEditMenu.BackColor = Color.White;
            btnEditMenu.Click += BtnEditMenu_Click;
            pnlButtonMenu.Controls.Add(btnEditMenu);

            // Button "Xóa"
            btnDeleteMenu = new Button();
            btnDeleteMenu.Text = "Xóa";
            btnDeleteMenu.Size = new Size(80, 40);
            btnDeleteMenu.Location = new Point(280, 10);
            btnDeleteMenu.BackColor = Color.White;
            btnDeleteMenu.Click += BtnDeleteMenu_Click;
            pnlButtonMenu.Controls.Add(btnDeleteMenu);

            //Thêm các controls vào pnlDataMenu;
            //DataGridView dtgvMenu
            dtgvMenu = new DataGridView();
            dtgvMenu.Location = new Point(5, 0);
            dtgvMenu.Size = new Size(pnlDataMenu.ClientSize.Width - 5, pnlDataMenu.ClientSize.Height - 5);
            dtgvMenu.BorderStyle = BorderStyle.FixedSingle;
            dtgvMenu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvMenu.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtgvMenu.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            pnlDataMenu.Controls.Add(dtgvMenu);


            //Thêm các controls vào pnlTextBoxMenu;
            // TextBox txbSearchMenu
            txbSearchMenu = new TextBox();
            txbSearchMenu.Size = new Size(160, 20);
            txbSearchMenu.Location = new Point(10, 1);
            txbSearchMenu.BorderStyle = BorderStyle.FixedSingle;
            pnlTextBoxMenu.Controls.Add(txbSearchMenu);

            // Button btnSearchMenu
            btnSearchMenu = new Button();
            btnSearchMenu.Text = "Tìm";
            btnSearchMenu.Size = new Size(80, 25);
            btnSearchMenu.Location = new Point(180, -1);
            btnSearchMenu.BackColor = Color.White;
            btnSearchMenu.Click += BtnSearchMenu_Click;
            pnlTextBoxMenu.Controls.Add(btnSearchMenu);

            // Label lbIDMenu
            lbIDMenu = new Label();
            lbIDMenu.Text = "ID:";
            lbIDMenu.AutoSize = true;
            lbIDMenu.Location = new Point(15, 80);
            pnlTextBoxMenu.Controls.Add(lbIDMenu);

            // TextBox txbIDMenu
            txbIDMenu = new TextBox();
            txbIDMenu.Size = new Size(150, 20);
            txbIDMenu.Location = new Point(110, 80);
            txbIDMenu.BorderStyle = BorderStyle.FixedSingle;
            txbIDMenu.ReadOnly = true;
            txbIDMenu.TextChanged += TxbIDMenu_TextChanged;
            pnlTextBoxMenu.Controls.Add(txbIDMenu);

            // Label lbNameMenu
            lbNameMenu = new Label();
            lbNameMenu.Text = "Tên:";
            lbNameMenu.AutoSize = true;
            lbNameMenu.Location = new Point(15, 130);
            pnlTextBoxMenu.Controls.Add(lbNameMenu);

            // TextBox txbNameMenu
            txbNameMenu = new TextBox();
            txbNameMenu.Size = new Size(150, 20);
            txbNameMenu.Location = new Point(110, 130);
            txbNameMenu.BorderStyle = BorderStyle.FixedSingle;
            pnlTextBoxMenu.Controls.Add(txbNameMenu);

            // Label lbCategoryMenu
            lbCategoryMenu = new Label();
            lbCategoryMenu.Text = "Danh mục:";
            lbCategoryMenu.AutoSize = true;
            lbCategoryMenu.Location = new Point(15, 180);
            pnlTextBoxMenu.Controls.Add(lbCategoryMenu);

            // TextBox txbCategoryMenu
            cbCategoryMenu = new ComboBox();
            cbCategoryMenu.Size = new Size(150, 20);
            cbCategoryMenu.Location = new Point(110, 180);
            pnlTextBoxMenu.Controls.Add(cbCategoryMenu);

            // Label lbPriceMenu
            lbPriceMenu = new Label();
            lbPriceMenu.Text = "Giá:";
            lbPriceMenu.AutoSize = true;
            lbPriceMenu.Location = new Point(15, 230);
            pnlTextBoxMenu.Controls.Add(lbPriceMenu);

            // TextBox txbPriceMenu
            nrudPriceMenu = new NumericUpDown();
            nrudPriceMenu.Size = new Size(150, 20);
            nrudPriceMenu.Location = new Point(110, 230);
            nrudPriceMenu.Maximum = 100000000000;
            nrudPriceMenu.Minimum = 0;
            nrudPriceMenu.Value = 0;
            pnlTextBoxMenu.Controls.Add(nrudPriceMenu);
        }

        #endregion
        #region GUI Table
        private Panel pnlTable;
        private Panel pnlButtonTable;
        private Panel pnlDataTable;
        private Panel pnlTextBoxTable;
        private Button btnViewTable;
        private Button btnAddTable;
        private Button btnEditTable;
        private Button btnDeleteTable;
        private DataGridView dtgvTable;
        private Label lbIDTable;
        private Label lbNameTable;
        private Label lbStatusTable;
        private TextBox txbIDTable;
        private TextBox txbNameTable;
        private TextBox txbStatusTable;
        void SetUpTable()
        {
            pnlTable = new Panel();
            pnlTable.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);
            pnlTable.BackColor = Color.FromArgb(215, 229, 242);
            tpTable.Controls.Add(pnlTable);
            // Panel cho các nút Table
            pnlButtonTable = new Panel();
            pnlButtonTable.Location = new Point(0, 0);
            pnlButtonTable.Size = new Size(this.ClientSize.Width, 60);
            pnlTable.Controls.Add(pnlButtonTable);

            // Panel cho dữ liệu Table
            pnlDataTable = new Panel();
            pnlDataTable.Location = new Point(0, 60);
            pnlDataTable.Size = new Size(500, 350);
            pnlTable.Controls.Add(pnlDataTable);

            // Panel cho các TextBox Table
            pnlTextBoxTable = new Panel();
            pnlTextBoxTable.Location = new Point(500, 60);
            pnlTextBoxTable.Size = new Size(280, 350);
            pnlTable.Controls.Add(pnlTextBoxTable);

            //Thêm các button vào pnlButtonTable
            // Button "Xem"
            btnViewTable = new Button();
            btnViewTable.Text = "Xem";
            btnViewTable.Size = new Size(80, 40);
            btnViewTable.Location = new Point(10, 10);
            btnViewTable.BackColor = Color.White;
            btnViewTable.Click += BtnViewTable_Click;
            pnlButtonTable.Controls.Add(btnViewTable);

            // Button "Thêm"
            btnAddTable = new Button();
            btnAddTable.Text = "Thêm";
            btnAddTable.Size = new Size(80, 40);
            btnAddTable.Location = new Point(100, 10);
            btnAddTable.BackColor = Color.White;
            btnAddTable.Click += BtnAddTable_Click;
            pnlButtonTable.Controls.Add(btnAddTable);

            // Button "Sửa"
            btnEditTable = new Button();
            btnEditTable.Text = "Sửa";
            btnEditTable.Size = new Size(80, 40);
            btnEditTable.Location = new Point(190, 10);
            btnEditTable.BackColor = Color.White;
            btnEditTable.Click += BtnEditTable_Click;
            pnlButtonTable.Controls.Add(btnEditTable);

            // Button "Xóa"
            btnDeleteTable = new Button();
            btnDeleteTable.Text = "Xóa";
            btnDeleteTable.Size = new Size(80, 40);
            btnDeleteTable.Location = new Point(280, 10);
            btnDeleteTable.BackColor = Color.White;
            btnDeleteTable.Click += BtnDeleteTable_Click;
            pnlButtonTable.Controls.Add(btnDeleteTable);

            //Thêm các controls vào pnlDataTable;
            //DataGridView dtgvTable
            dtgvTable = new DataGridView();
            dtgvTable.Location = new Point(5, 0);
            dtgvTable.Size = new Size(pnlDataTable.ClientSize.Width - 5, pnlDataTable.ClientSize.Height - 5);
            dtgvTable.BorderStyle = BorderStyle.FixedSingle;
            dtgvTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            pnlDataTable.Controls.Add(dtgvTable);


            //Thêm các controls vào pnlTextBoxTable;

            // Label lbIDTable
            lbIDTable = new Label();
            lbIDTable.Text = "ID:";
            lbIDTable.AutoSize = true;
            lbIDTable.Location = new Point(15, 5);
            pnlTextBoxTable.Controls.Add(lbIDTable);

            // TextBox txbIDTable
            txbIDTable = new TextBox();
            txbIDTable.Size = new Size(150, 20);
            txbIDTable.Location = new Point(110, 5);
            txbIDTable.ReadOnly = true;
            txbIDTable.BorderStyle = BorderStyle.FixedSingle;
            txbIDTable.ReadOnly = true;
            pnlTextBoxTable.Controls.Add(txbIDTable);

            // Label lbNameTable
            lbNameTable = new Label();
            lbNameTable.Text = "Tên bàn:";
            lbNameTable.AutoSize = true;
            lbNameTable.Location = new Point(15, 55);
            pnlTextBoxTable.Controls.Add(lbNameTable);

            // TextBox txbNameTable
            txbNameTable = new TextBox();
            txbNameTable.Size = new Size(150, 20);
            txbNameTable.Location = new Point(110, 55);
            txbNameTable.BorderStyle = BorderStyle.FixedSingle;
            pnlTextBoxTable.Controls.Add(txbNameTable);

            // Label lbCategoryTable
            lbStatusTable = new Label();
            lbStatusTable.Text = "Trạng thái: ";
            lbStatusTable.AutoSize = true;
            lbStatusTable.Location = new Point(15, 105);
            pnlTextBoxTable.Controls.Add(lbStatusTable);

            // TextBox txbCategoryTable
            txbStatusTable = new TextBox();
            txbStatusTable.Size = new Size(150, 20);
            txbStatusTable.Location = new Point(110, 105);
            txbStatusTable.BorderStyle = BorderStyle.FixedSingle;
            pnlTextBoxTable.Controls.Add(txbStatusTable);


        }
        #endregion
        #region GUI Category
        private Panel pnlCategory;
        private Panel pnlButtonCategory;
        private Panel pnlDataCategory;
        private Panel pnlTextBoxCategory;
        private Button btnViewCategory;
        private Button btnAddCategory;
        private Button btnEditCategory;
        private Button btnDeleteCategory;
        private DataGridView dtgvCategory;
        private Label lbIDCategory;
        private Label lbNameCategory;
        private TextBox txbIDCategory;
        private TextBox txbNameCategory;
        void SetUpCategory()
        {
            pnlCategory = new Panel();
            pnlCategory.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);
            pnlCategory.BackColor = Color.FromArgb(215, 229, 242);
            tpCategory.Controls.Add(pnlCategory);
            // Panel cho các nút Category
            pnlButtonCategory = new Panel();
            pnlButtonCategory.Location = new Point(0, 0);
            pnlButtonCategory.Size = new Size(this.ClientSize.Width, 60);
            pnlCategory.Controls.Add(pnlButtonCategory);

            // Panel cho dữ liệu Category
            pnlDataCategory = new Panel();
            pnlDataCategory.Location = new Point(0, 60);
            pnlDataCategory.Size = new Size(500, 350);
            pnlCategory.Controls.Add(pnlDataCategory);

            // Panel cho các TextBox Category
            pnlTextBoxCategory = new Panel();
            pnlTextBoxCategory.Location = new Point(500, 60);
            pnlTextBoxCategory.Size = new Size(280, 350);
            pnlCategory.Controls.Add(pnlTextBoxCategory);

            //Thêm các button vào pnlButtonCategory
            // Button "Xem"
            btnViewCategory = new Button();
            btnViewCategory.Text = "Xem";
            btnViewCategory.Size = new Size(80, 40);
            btnViewCategory.Location = new Point(10, 10);
            btnViewCategory.BackColor = Color.White;
            btnViewCategory.Click += BtnViewCategory_Click;
            pnlButtonCategory.Controls.Add(btnViewCategory);

            // Button "Thêm"
            btnAddCategory = new Button();
            btnAddCategory.Text = "Thêm";
            btnAddCategory.Size = new Size(80, 40);
            btnAddCategory.Location = new Point(100, 10);
            btnAddCategory.BackColor = Color.White;
            btnAddCategory.Click += BtnAddCategory_Click;
            pnlButtonCategory.Controls.Add(btnAddCategory);

            // Button "Sửa"
            btnEditCategory = new Button();
            btnEditCategory.Text = "Sửa";
            btnEditCategory.Size = new Size(80, 40);
            btnEditCategory.Location = new Point(190, 10);
            btnEditCategory.BackColor = Color.White;
            btnEditCategory.Click += BtnEditCategory_Click;
            pnlButtonCategory.Controls.Add(btnEditCategory);

            // Button "Xóa"
            btnDeleteCategory = new Button();
            btnDeleteCategory.Text = "Xóa";
            btnDeleteCategory.Size = new Size(80, 40);
            btnDeleteCategory.Location = new Point(280, 10);
            btnDeleteCategory.BackColor = Color.White;
            btnDeleteCategory.Click += BtnDeleteCategory_Click;
            pnlButtonCategory.Controls.Add(btnDeleteCategory);

            //Thêm các controls vào pnlDataCategory;
            //DataGridView dtgvCategory
            dtgvCategory = new DataGridView();
            dtgvCategory.Location = new Point(5, 0);
            dtgvCategory.Size = new Size(pnlDataCategory.ClientSize.Width - 5, pnlDataCategory.ClientSize.Height - 5);
            dtgvCategory.BorderStyle = BorderStyle.FixedSingle;
            dtgvCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            pnlDataCategory.Controls.Add(dtgvCategory);

            //Thêm các controls vào pnlTextBoxMenu;
            // TextBox txbFilterMenu

            // Label lbIDCategory
            lbIDCategory = new Label();
            lbIDCategory.Text = "ID:";
            lbIDCategory.AutoSize = true;
            lbIDCategory.Location = new Point(15, 5);
            pnlTextBoxCategory.Controls.Add(lbIDCategory);

            // TextBox txbIDCategory
            txbIDCategory = new TextBox();
            txbIDCategory.Size = new Size(150, 20);
            txbIDCategory.Location = new Point(110, 5);
            txbIDCategory.BorderStyle = BorderStyle.FixedSingle;
            txbIDCategory.ReadOnly = true;
            pnlTextBoxCategory.Controls.Add(txbIDCategory);

            // Label lbNameCategory
            lbNameCategory = new Label();
            lbNameCategory.Text = "Tên:";
            lbNameCategory.AutoSize = true;
            lbNameCategory.Location = new Point(15, 55);
            pnlTextBoxCategory.Controls.Add(lbNameCategory);

            // TextBox txbNameCategory
            txbNameCategory = new TextBox();
            txbNameCategory.Size = new Size(150, 20);
            txbNameCategory.Location = new Point(110, 55);
            txbNameCategory.BorderStyle = BorderStyle.FixedSingle;
            pnlTextBoxCategory.Controls.Add(txbNameCategory);


        }
        #endregion
        #region GUI Account
        private Panel pnlAccount;
        private Panel pnlButtonAccount;
        private Panel pnlDataAccount;
        private Panel pnlTextBoxAccount;
        private Button btnViewAccount;
        private Button btnAddAccount;
        private Button btnEditAccount;
        private Button btnDeleteAccount;
        private DataGridView dtgvAccount;
        private Label lbUserNameAccount;
        private Label lbDisplayNameAccount;
        private Label lbTypeAccount;
        private TextBox txbUserNameAccount;
        private TextBox txbDisplayNameAccount;
        private NumericUpDown nrudTypeAccount;
        private Button btnResetPassword;
        void SetUpAccount()
        {
            pnlAccount = new Panel();
            pnlAccount.Size = new Size(this.ClientSize.Width, this.ClientSize.Height);
            pnlAccount.BackColor = Color.FromArgb(215, 229, 242);
            tpAccount.Controls.Add(pnlAccount);
            // Panel cho các nút Account
            pnlButtonAccount = new Panel();
            pnlButtonAccount.Location = new Point(0, 0);
            pnlButtonAccount.Size = new Size(this.ClientSize.Width, 60);
            pnlAccount.Controls.Add(pnlButtonAccount);

            // Panel cho dữ liệu Account
            pnlDataAccount = new Panel();
            pnlDataAccount.Location = new Point(0, 60);
            pnlDataAccount.Size = new Size(500, 350);
            pnlAccount.Controls.Add(pnlDataAccount);

            // Panel cho các TextBox Account
            pnlTextBoxAccount = new Panel();
            pnlTextBoxAccount.Location = new Point(500, 60);
            pnlTextBoxAccount.Size = new Size(280, 350);
            pnlAccount.Controls.Add(pnlTextBoxAccount);

            //Thêm các button vào pnlButtonAccount
            // Button "Xem"
            btnViewAccount = new Button();
            btnViewAccount.Text = "Xem";
            btnViewAccount.Size = new Size(80, 40);
            btnViewAccount.Location = new Point(10, 10);
            btnViewAccount.BackColor = Color.White;
            btnViewAccount.Click += BtnViewAccount_Click;
            pnlButtonAccount.Controls.Add(btnViewAccount);

            // Button "Thêm"
            btnAddAccount = new Button();
            btnAddAccount.Text = "Thêm";
            btnAddAccount.Size = new Size(80, 40);
            btnAddAccount.Location = new Point(100, 10);
            btnAddAccount.BackColor = Color.White;
            btnAddAccount.Click += BtnAddAccount_Click;

            pnlButtonAccount.Controls.Add(btnAddAccount);

            // Button "Sửa"
            btnEditAccount = new Button();
            btnEditAccount.Text = "Sửa";
            btnEditAccount.Size = new Size(80, 40);
            btnEditAccount.Location = new Point(190, 10);
            btnEditAccount.BackColor = Color.White;
            btnEditAccount.Click += BtnEditAccount_Click;
            pnlButtonAccount.Controls.Add(btnEditAccount);

            // Button "Xóa"
            btnDeleteAccount = new Button();
            btnDeleteAccount.Text = "Xóa";
            btnDeleteAccount.Size = new Size(80, 40);
            btnDeleteAccount.Location = new Point(280, 10);
            btnDeleteAccount.BackColor = Color.White;
            btnDeleteAccount.Click += BtnDeleteAccount_Click;
            pnlButtonAccount.Controls.Add(btnDeleteAccount);

            //Thêm các controls vào pnlDataAccount;
            //DataGridView dtgvAccount
            dtgvAccount = new DataGridView();
            dtgvAccount.Location = new Point(5, 0);
            dtgvAccount.Size = new Size(pnlDataAccount.ClientSize.Width - 5, pnlDataAccount.ClientSize.Height - 5);
            dtgvAccount.BorderStyle = BorderStyle.FixedSingle;
            dtgvAccount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            pnlDataAccount.Controls.Add(dtgvAccount);


            //Thêm các controls vào pnlTextBoxAccount
            // Label lbIDAccount
            lbUserNameAccount = new Label();
            lbUserNameAccount.Text = "ID:";
            lbUserNameAccount.AutoSize = true;
            lbUserNameAccount.Location = new Point(15, 5);
            pnlTextBoxAccount.Controls.Add(lbUserNameAccount);

            // TextBox txbIDAccount
            txbUserNameAccount = new TextBox();
            txbUserNameAccount.Size = new Size(150, 20);
            txbUserNameAccount.Location = new Point(110, 5);
            txbUserNameAccount.BorderStyle = BorderStyle.FixedSingle;
            pnlTextBoxAccount.Controls.Add(txbUserNameAccount);

            // Label lbDisplayNameAccount
            lbDisplayNameAccount = new Label();
            lbDisplayNameAccount.Text = "Tên hiển thị:";
            lbDisplayNameAccount.AutoSize = true;
            lbDisplayNameAccount.Location = new Point(15, 55);
            pnlTextBoxAccount.Controls.Add(lbDisplayNameAccount);

            // TextBox txbDisplayNameAccount
            txbDisplayNameAccount = new TextBox();
            txbDisplayNameAccount.Size = new Size(150, 20);
            txbDisplayNameAccount.Location = new Point(110, 55);
            txbDisplayNameAccount.BorderStyle = BorderStyle.FixedSingle;
            pnlTextBoxAccount.Controls.Add(txbDisplayNameAccount);

            // Label lbTypeAccount
            lbTypeAccount = new Label();
            lbTypeAccount.Text = "Loại tài khoản:";
            lbTypeAccount.AutoSize = true;
            lbTypeAccount.Location = new Point(15, 105);
            pnlTextBoxAccount.Controls.Add(lbTypeAccount);

            // TextBox cbTypeAccount
            nrudTypeAccount = new NumericUpDown();
            nrudTypeAccount.Width = 150;
            nrudTypeAccount.Location = new Point(110, 105);
            nrudTypeAccount.BorderStyle = BorderStyle.FixedSingle;
            nrudTypeAccount.Maximum = 1;
            nrudTypeAccount.Minimum = 0;
            nrudTypeAccount.Value = 0;
            pnlTextBoxAccount.Controls.Add(nrudTypeAccount);

            // Button btnConfirmPassword
            btnResetPassword = new Button();
            btnResetPassword.Text = "Đặt lại mật khẩu";
            btnResetPassword.Size = new Size(110, 60);
            btnResetPassword.Location = new Point(150, 160);
            btnResetPassword.BackColor = Color.White;
            btnResetPassword.Click += BtnResetPassword_Click;
            pnlTextBoxAccount.Controls.Add(btnResetPassword);


        }



        #endregion
        #region GUI Account

   
        void SetUpReport()
        {
            pnlReport.BackColor = Color.FromArgb(215, 229, 242);
            pnlReport.AutoSize = true;
            reportViewer.Dock = DockStyle.Fill;
        }



        #endregion

        #endregion
        #region Method
        #region Methods Account
        void AddAccountBinding()
        {
            txbUserNameAccount.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "username", true, DataSourceUpdateMode.Never));
            txbDisplayNameAccount.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "displayname", true, DataSourceUpdateMode.Never));
            nrudTypeAccount.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "typeUser", true, DataSourceUpdateMode.Never));
            dtgvAccount.Columns["username"].HeaderText = "Tên tài khoản";
            dtgvAccount.Columns["displayname"].HeaderText = "Tên hiển thị";
            dtgvAccount.Columns["typeUser"].HeaderText = "Loại tài khoản";

        }
        void LoadListAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
        #endregion
        #region Methods Category
        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetCategory();
            cb.DisplayMember = "NameCategory";
        }

        void AddCategoryBinding()
        {
            txbIDCategory.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "IDCategory", true, DataSourceUpdateMode.Never));
            txbNameCategory.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "nameCategory", true, DataSourceUpdateMode.Never));
            dtgvCategory.Columns["nameCategory"].HeaderText = "Tên danh mục";

        }
        void LoadListCategory()
        {
            categoryList.DataSource = CategoryDAO.Instance.GetListCategory();
        }


        #endregion
        #region Methods Table
        void AddTableBinding()
        {
            txbIDTable.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "IDtable", true, DataSourceUpdateMode.Never));
            txbNameTable.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "nameTable", true, DataSourceUpdateMode.Never));
            txbStatusTable.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "statusTable", true, DataSourceUpdateMode.Never));
            dtgvTable.Columns["nameTable"].HeaderText = "Tên bàn";
            dtgvTable.Columns["statusTable"].HeaderText = "Trạng thái";
        }

        void LoadListTable()
        {
            tableList.DataSource = TableDAO.Instance.GetListTable();
        }
        #endregion
        #region Methods Menu
        List<FMenu> SearchMenuByName(string nameMenu)
        {
            List<FMenu> listMenu = FMenuDAO.Instance.SearchMenuByname(nameMenu);

            return listMenu;
        }
        void AddMenuBinding()
        {
            txbIDMenu.DataBindings.Add(new Binding("Text", dtgvMenu.DataSource, "idMenu", true, DataSourceUpdateMode.Never));
            txbNameMenu.DataBindings.Add(new Binding("Text", dtgvMenu.DataSource, "nameMenu", true, DataSourceUpdateMode.Never));
            nrudPriceMenu.DataBindings.Add(new Binding("Value", dtgvMenu.DataSource, "price", true, DataSourceUpdateMode.Never));
            dtgvMenu.Columns["nameMenu"].HeaderText = "Tên món";
            dtgvMenu.Columns["nameCategory"].HeaderText = "Tên danh mục";
            dtgvMenu.Columns["price"].HeaderText = "Giá";

        }
        void LoadListMenu()
        {
            menuList.DataSource = FMenuDAO.Instance.GetListMenu();
        }

        bool CheckMenuExistInCategory(int idCategory)
        {
            // Kiểm tra xem có menu nào thuộc danh mục này không
            List<FMenu> listFMenu = FMenuDAO.Instance.GetMenuByCategoryID(idCategory);
            return listFMenu.Count > 0;
        }
        #endregion

        #region Methods Bill
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkCheckIn.Value = new DateTime(today.Year, today.Month, 1);
            dtpkCheckOut.Value = dtpkCheckIn.Value.AddMonths(1).AddDays(-1);
            // Định dạng ngày trong chuỗi "MM/dd/yyyy" và sử dụng ngôn ngữ "en-US"
            dtpkCheckIn.CustomFormat = "dddd, d MMMM, yyyy";
            dtpkCheckOut.CustomFormat = "dddd, d MMMM, yyyy";
            CultureInfo enUS = new CultureInfo("en-US");
            dtpkCheckIn.Format = DateTimePickerFormat.Custom;
            dtpkCheckOut.Format = DateTimePickerFormat.Custom;
            dtpkCheckIn.Value = DateTime.Parse(dtpkCheckIn.Value.ToString("dddd, d MMMM, yyyy"), enUS);
            dtpkCheckOut.Value = DateTime.Parse(dtpkCheckOut.Value.ToString("dddd, d MMMM, yyyy"), enUS);

        }

        private bool CheckBillExistOnTable(int idTable)
        {
            // Kiểm tra xem có hóa đơn (bill) nào đang tồn tại trên bàn với idTable đã cho
            List<Bill> bills = BillDAO.Instance.GetUnpaidBillsByTableID(idTable);
            return bills.Count > 0;
        }
        #endregion
        BindingSource menuList = new BindingSource();
        BindingSource accountList = new BindingSource();
        BindingSource categoryList = new BindingSource();
        BindingSource tableList = new BindingSource();

        void LoadData()
        {
            dtgvMenu.DataSource = menuList;
            dtgvTable.DataSource = tableList;
            dtgvCategory.DataSource = categoryList;
            dtgvAccount.DataSource = accountList;

            LoadDateTimePickerBill();
            LoadListBillByDate(dtpkCheckIn.Value, dtpkCheckOut.Value);
            LoadListMenu();
            LoadListTable();
            LoadListCategory();
            LoadListAccount();

            //Add Binding
            AddMenuBinding();
            AddTableBinding();
            AddCategoryBinding();
            AddAccountBinding();

            //
            LoadCategoryIntoCombobox(cbCategoryMenu);

        }
        #endregion
        #region Events
        #region EventHandler
        private event EventHandler insertMenu;
        public event EventHandler InsertMenu
        {
            add { insertMenu += value; }
            remove { insertMenu -= value; }
        }
        private event EventHandler updateMenu;
        public event EventHandler UpdateMenu
        {
            add { updateMenu += value; }
            remove { updateMenu -= value; }
        }
        private event EventHandler deleteMenu;
        public event EventHandler DeleteMenu
        {
            add { deleteMenu += value; }
            remove { deleteMenu -= value; }
        }
        private event EventHandler insertTable;
        public event EventHandler InsertTable
        {
            add { insertTable += value; }
            remove { insertTable -= value; }
        }
        private event EventHandler updateTable;
        public event EventHandler UpdateTable
        {
            add { updateTable += value; }
            remove { updateTable -= value; }
        }
        private event EventHandler deleteTable;
        public event EventHandler DeleteTable
        {
            add { deleteTable += value; }
            remove { deleteTable -= value; }
        }
        private event EventHandler insertCategory;
        public event EventHandler InsertCategory
        {
            add { insertCategory += value; }
            remove { insertCategory -= value; }
        }
        private event EventHandler updateCategory;
        public event EventHandler UpdateCategory
        {
            add { updateCategory += value; }
            remove { updateCategory -= value; }
        }
        private event EventHandler deleteCategory;
        public event EventHandler DeleteCategory
        {
            add { deleteCategory += value; }
            remove { deleteCategory -= value; }
        }
        private event EventHandler insertAccount;
        public event EventHandler InsertAccount
        {
            add { insertAccount += value; }
            remove { insertAccount -= value; }
        }
        private event EventHandler updateAccount;
        public event EventHandler UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }
        private event EventHandler deleteAccount;
        public event EventHandler DEleteAccount
        {
            add { deleteAccount += value; }
            remove { deleteAccount -= value; }
        }
        private event EventHandler resetAccount;
        public event EventHandler ResetAccount
        {
            add { resetAccount += value; }
            remove { resetAccount -= value; }
        }
        #endregion
        #region Events Category
        private void BtnDeleteCategory_Click(object sender, EventArgs e)
        {
            int idCategory = Convert.ToInt32(txbIDCategory.Text);
            if (CheckMenuExistInCategory(idCategory))
            {
                MessageBox.Show("Vui lòng xóa món trước!");
                return;
            }
            if (CategoryDAO.Instance.DeleteCategory(idCategory))
            {
                MessageBox.Show("Xóa danh mục thành công");
                LoadListCategory();
                LoadCategoryIntoCombobox(cbCategoryMenu);
                if (deleteCategory != null)
                {
                    deleteCategory(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Xóa danh mục thất bại");
            }

        }


        private void BtnEditCategory_Click(object sender, EventArgs e)
        {
            int idCategory = Convert.ToInt32(txbIDCategory.Text);
            string nameCategory = txbNameCategory.Text;

            if (CategoryDAO.Instance.UpdateCategory(idCategory ,nameCategory))
            {
                MessageBox.Show("Cập nhật danh mục thành công");
                LoadListCategory();
                LoadCategoryIntoCombobox(cbCategoryMenu);

                if (updateCategory != null)
                {
                    updateCategory(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Cập nhật danh mục thất bại");
            }

        }

        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            string nameCategory = txbNameCategory.Text;
           

            if (CategoryDAO.Instance.InsertCategory(nameCategory))
            {
                MessageBox.Show("Thêm danh mục thành công");
                LoadListCategory();
                LoadCategoryIntoCombobox(cbCategoryMenu);
                if (insertCategory != null)
                {
                    insertCategory(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Thêm danh mục thất bại");
            }

        }

        private void BtnViewCategory_Click(object sender, EventArgs e)
        {
            LoadListCategory();
        }
        #endregion

        #region Events Account
        private void BtnResetPassword_Click(object sender, EventArgs e)
        {
            string username = txbUserNameAccount.Text;

            if (AccountDAO.Instance.ResetPasswprd(username))
            {
                MessageBox.Show("Đặt lại tài khoản thành công");
                if (resetAccount != null)
                {
                    resetAccount(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Đặt lại tài khoản thất bại");
            }
        }
        private void BtnDeleteAccount_Click(object sender, EventArgs e)
        {
            string username = txbUserNameAccount.Text;
            if (loginAccount.UserName.Equals(username))
            {
                MessageBox.Show("Tài khoản đang được sử dụng!");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(username))
            {
                MessageBox.Show("Xóa tài khoản thành công");
                LoadListAccount();
                if (deleteAccount != null)
                {
                    deleteAccount(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }
        }
        private void BtnEditAccount_Click(object sender, EventArgs e)
        {
            string username = txbUserNameAccount.Text;
            string displayname = txbDisplayNameAccount.Text;
            int typeUser = (int)nrudTypeAccount.Value;

            if (AccountDAO.Instance.UpdateAccount(username, displayname, typeUser))
            {
                MessageBox.Show("Cập nhật tài khoản thành công");
                LoadListAccount();
                if (updateAccount != null)
                {
                    updateAccount(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại");
            }
        }
        private void BtnAddAccount_Click(object sender, EventArgs e)
        {
            string username = txbUserNameAccount.Text;
            string displayname = txbDisplayNameAccount.Text;
            int typeUser = (int)nrudTypeAccount.Value;

            if (AccountDAO.Instance.InsertAccount(username, displayname, typeUser))
            {
                MessageBox.Show("Thêm tài khoản thành công");
                LoadListAccount();
                if (insertAccount != null)
                {
                    insertAccount(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }
            
        }
        private void BtnViewAccount_Click(object sender, EventArgs e)
        {
            LoadListAccount();
        }
        #endregion

        #region Events Table
        private void BtnDeleteTable_Click(object sender, EventArgs e)
        {
            int idTable = Convert.ToInt32(txbIDTable.Text);
            try
            {
                if (CheckBillExistOnTable(idTable))
                {
                    MessageBox.Show("Bàn có người!");
                    return;
                }
                if (TableDAO.Instance.DeleteTable(idTable))
                {
                    MessageBox.Show("Xóa bàn thành công");
                    LoadListTable();
                    if (deleteTable != null)
                    {
                        deleteTable(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show("Xóa bàn thất bại");
                }
            }
            catch
            {
                MessageBox.Show("Bàn còn hóa đơn đã thanh toán!");
            }
        }

        private void BtnEditTable_Click(object sender, EventArgs e)
        {
            int idTable = Convert.ToInt32(txbIDTable.Text);
            string nameTable = txbNameTable.Text;
            string statusTable = txbStatusTable.Text;

            if (TableDAO.Instance.UpdateTable(idTable, nameTable, statusTable))
            {
                MessageBox.Show("Cập nhật bàn thành công");
                LoadListTable();
                if (updateTable != null)
                {
                    updateTable(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Cập nhật bàn thất bại");
            }
        }

        private void BtnAddTable_Click(object sender, EventArgs e)
        {
            string nameTable = txbNameTable.Text;
            string statusTable = txbStatusTable.Text;

            if (TableDAO.Instance.InsertTable(nameTable, statusTable))
            {
                MessageBox.Show("Thêm bàn thành công");
                LoadListTable();
                if (insertTable != null)
                {
                    insertTable(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Thêm bàn thất bại");
            }
        }

        private void BtnViewTable_Click(object sender, EventArgs e)
        {
            LoadListTable();
        }

        #endregion

        #region Events Menu
        private void BtnSearchMenu_Click(object sender, EventArgs e)
        {
            menuList.DataSource = SearchMenuByName(txbSearchMenu.Text);
        }

        private void BtnViewMenu_Click(object sender, EventArgs e)
        {
            LoadListMenu();
        }

        private void BtnDeleteMenu_Click(object sender, EventArgs e)
        {
            int idMenu = Convert.ToInt32(txbIDMenu.Text);

            if (FMenuDAO.Instance.DeleteMenu(idMenu))
            {
                MessageBox.Show("Xóa món thành công");
                LoadListMenu();
                if (deleteMenu != null)
                {
                    deleteMenu(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Xóa món thất bại");
            }
        }

        private void BtnEditMenu_Click(object sender, EventArgs e)
        {
            string nameMenu = txbNameMenu.Text;
            int idCategory = (cbCategoryMenu.SelectedItem as Category).IDCategory;
            float price = (float)nrudPriceMenu.Value;
            int idMenu = Convert.ToInt32(txbIDMenu.Text);

            if (FMenuDAO.Instance.UpdateMenu(idMenu, nameMenu, idCategory, price))
            {
                MessageBox.Show("Sửa món thành công");
                LoadListMenu();
                if (updateMenu != null)
                {
                    updateMenu(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Sửa món thất bại");
            }
        }

        private void BtnAddMenu_Click(object sender, EventArgs e)
        {
            string nameMenu = txbNameMenu.Text;
            int idCategory = (cbCategoryMenu.SelectedItem as Category).IDCategory;
            float price = (float)nrudPriceMenu.Value;

            if (FMenuDAO.Instance.InsertMenu(nameMenu, idCategory, price))
            {
                MessageBox.Show("Thêm món thành công");
                LoadListMenu();
                if (insertMenu != null)
                {
                    insertMenu(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Thêm món thất bại");
            }
        }
        private void TxbIDMenu_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvMenu.SelectedCells.Count > 0)
                {
                    DataGridViewCell selectedCell = dtgvMenu.SelectedCells[0];
                    if (selectedCell != null && selectedCell.OwningRow != null && selectedCell.OwningRow.Cells["idCategory"].Value != null)
                    {
                        int idCategory = (int)selectedCell.OwningRow.Cells["idCategory"].Value;
                        Category category = CategoryDAO.Instance.GetCategoryByID(idCategory);

                        if (category != null)
                        {
                            cbCategoryMenu.SelectedItem = category;

                            int index = -1;
                            for (int i = 0; i < cbCategoryMenu.Items.Count; i++)
                            {
                                Category item = (Category)cbCategoryMenu.Items[i];
                                if (item.IDCategory == category.IDCategory)
                                {
                                    index = i;
                                    break;
                                }
                            }
                            cbCategoryMenu.SelectedIndex = index;
                        }
                    }

                }
            }
            catch { }
        }

        #endregion
        private void BtnViewBill_Click (object sender, EventArgs e)
        {
           LoadListBillByDate(dtpkCheckIn.Value, dtpkCheckOut.Value);
        }
        private void AdminWinform_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'QuanLyQuanCafeDataSet.USP_GetListBillByDateForReport' table. You can move, or remove it, as needed.
            this.USP_GetListBillByDateForReportTableAdapter.Fill(this.QuanLyQuanCafeDataSet.USP_GetListBillByDateForReport,dtpkCheckIn.Value,dtpkCheckOut.Value);
            this.reportViewer.RefreshReport();
        }
        #endregion


    }
}
