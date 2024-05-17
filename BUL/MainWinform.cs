using PM_QuanLyQuanCafe.DAO;
using PM_QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PM_QuanLyQuanCafe
{
    public partial class MainWinform : BaseForm
    {
        private Account loginAccount;
        public Account LoginAccount
        {
            get => loginAccount;
            set
            {
                loginAccount = value;
                ChangeAccount(loginAccount.TypeUser);
            }
        }


        public MainWinform(Account acc)
        {
            InitializeComponent();
            this.Width = 920;
            this.Height = 550;
            
            SetUpMenuMain();
            SetUpMain();
            LoadTable();
            LoadCategory();
            LoadComboBoxTable(cbSwitchTable);
            this.LoginAccount = acc;
        }


        #region GUI

        private MenuStrip menuMain;
        private ToolStripMenuItem functionMenuItem;
        private ToolStripMenuItem addMMenuItem;
        private ToolStripMenuItem checkOutMenuItem;
        private ToolStripMenuItem swichTableMenuItem;
        private ToolStripMenuItem combineTableMenuItem;
        private ToolStripMenuItem exitMenuItem;
        private ToolStripMenuItem accountMenuItem;
        private ToolStripMenuItem accountProfileMenuItem;
        private ToolStripMenuItem signOutMenuItem;
        private ToolStripMenuItem adminMenuItem;
        void SetUpMenuMain()
        {
            menuMain = new MenuStrip();
            menuMain.Dock = DockStyle.Top;
            this.Controls.Add(menuMain);

            functionMenuItem = new ToolStripMenuItem("Chức năng");
            addMMenuItem = new ToolStripMenuItem("Thêm món");
            addMMenuItem.ShortcutKeys = Keys.Control | Keys.Q;
            addMMenuItem.Click += (sender, e) =>
            {
                BtnAddMenu_Click(this, new EventArgs());
            };
            checkOutMenuItem = new ToolStripMenuItem("Thanh toán");
            checkOutMenuItem.ShortcutKeys = Keys.Control | Keys.R;
            checkOutMenuItem.Click += (sender, e) =>
            {
                BtnCheckOut_Click(this, new EventArgs());
            };
            swichTableMenuItem = new ToolStripMenuItem("Chuyển bàn");
            swichTableMenuItem.ShortcutKeys = Keys.Control | Keys.W;
            swichTableMenuItem.Click += (sender, e) =>
            {
                BtnSwitchTable_Click(this, new EventArgs());
            };
            combineTableMenuItem = new ToolStripMenuItem("Gộp bàn");
            combineTableMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            combineTableMenuItem.Click += (sender, e) =>
            {
                BtnCombineTable_Click(this, new EventArgs());
            };
            exitMenuItem = new ToolStripMenuItem("Thoát");
            exitMenuItem.ShortcutKeys = Keys.Alt | Keys.E;
            exitMenuItem.Click += (sender, e) =>
            {
                this.Close();
            };
            functionMenuItem.DropDownItems.Add(addMMenuItem);
            functionMenuItem.DropDownItems.Add(swichTableMenuItem);
            functionMenuItem.DropDownItems.Add(combineTableMenuItem);
            functionMenuItem.DropDownItems.Add(checkOutMenuItem);
            functionMenuItem.DropDownItems.Add(exitMenuItem);


            accountMenuItem = new ToolStripMenuItem("Tài khoản");

            accountProfileMenuItem = new ToolStripMenuItem("Thông tin cá nhân");
            accountProfileMenuItem.Click += AccountProfileMenuItem_Click;

            signOutMenuItem = new ToolStripMenuItem("Đăng xuất");
            signOutMenuItem.Click += SignOutMenuItem_Click;
            accountMenuItem.DropDownItems.Add(accountProfileMenuItem);
            accountMenuItem.DropDownItems.Add(signOutMenuItem);

            adminMenuItem = new ToolStripMenuItem("Admin");
            adminMenuItem.Click += AdminMenuItem_Click;

            //Thêm các DropDowItems vào menuMain
            menuMain.Items.Add(adminMenuItem);
            menuMain.Items.Add(accountMenuItem);
            menuMain.Items.Add(functionMenuItem);
        }
        private Panel pnlMain;
        private FlowLayoutPanel flpTable;
        private Panel pnlContainer;
        private Panel pnlDetails;
        private Panel pnlAction;
        private Panel pnlBill;
        private ComboBox cbCategory;
        private ComboBox cbMenu;
        private ComboBox cbSwitchTable;
        private ListView lsvBill;
        private Label lbDiscount;
        private Label lbTotalPrice;
        private TextBox txbTotalPrice;
        private TextBox txbTotalPriceTemp;
        private Button btnAddMenu;
        private Button btnSwitchTable;
        private Button btnCombineTable;
        private Button btnCheckOut;
        private NumericUpDown nrudMenuCount;
        private NumericUpDown nrudDiscount;
        private PictureBox ptbLogo;

        void SetUpMain()
        {
            #region pnlMain
            pnlMain = new Panel();
            pnlMain.Location = new Point(15, 24);
            pnlMain.Size = new Size(875, 475);
            this.Controls.Add(pnlMain);
            #endregion

            #region flpTable
            flpTable = new FlowLayoutPanel();
            flpTable.Dock = DockStyle.Left;
            flpTable.BackColor = Color.FromArgb(255, 252, 230);
            flpTable.Size = new Size(345, 500);
            flpTable.Location = new Point(0, 0);
            flpTable.AutoScroll = true;
            pnlMain.Controls.Add(flpTable);
            #endregion

            #region pnlContainer
            pnlContainer = new Panel();
            pnlContainer.Size = new Size(400, 500);
            pnlContainer.Location = new Point(flpTable.Width, 0);
            pnlMain.Controls.Add(pnlContainer);
            #endregion

            #region pnlDetails
            pnlDetails = new Panel();
            pnlDetails.Dock = DockStyle.Top;
            pnlContainer.Controls.Add(pnlDetails);
            #endregion

            #region cbCategory
            cbCategory = new ComboBox();
            cbCategory.Width = 220;
            cbCategory.Location = new Point(5, 20);
            pnlDetails.Controls.Add(cbCategory);
            cbCategory.SelectedIndexChanged += CbCategory_SelectedIndexChanged;
            #endregion

            #region cbMenu
            cbMenu = new ComboBox();
            cbMenu.Width = 220;
            cbMenu.Location = new Point(5, cbCategory.Height + 30);
            pnlDetails.Controls.Add(cbMenu);
            #endregion

            #region btnAddMenu 
            btnAddMenu = new Button();
            btnAddMenu.Size = new Size(85, 55);
            btnAddMenu.Text = "Thêm món";
            btnAddMenu.BackColor = Color.DarkGray;
            btnAddMenu.FlatStyle = FlatStyle.Flat;
            btnAddMenu.FlatAppearance.BorderSize = 0;
            btnAddMenu.Location = new Point(cbCategory.Width + 20, 20);
            pnlDetails.Controls.Add(btnAddMenu);
            btnAddMenu.Click += BtnAddMenu_Click;
            #endregion

            #region nrudMenu 
            // Tạo control nrudMenu
            nrudMenuCount = new NumericUpDown();
            nrudMenuCount.Width = 50;
            nrudMenuCount.Location = new Point(cbCategory.Width + 120, 35);
            nrudMenuCount.Minimum = -100;
            nrudMenuCount.Maximum = 100;
            nrudMenuCount.Value = 1;
            pnlDetails.Controls.Add(nrudMenuCount);
            #endregion

            //#region txbTableName 
            //// Tạo control txbTableName
            //txbTableName = new TextBox();
            //txbTableName.Width = 55;
            //txbTableName.Location = new Point(5,70);
            //txbTableName.ReadOnly = true;
            //txbTableName.Text = "Bàn ";
            //txbTableName.BorderStyle = BorderStyle.FixedSingle;
            //pnlDetails.Controls.Add(txbTableName);
            //#endregion

            #region pnlOrder
            pnlBill = new Panel();
            pnlBill.Size = new Size(pnlContainer.ClientSize.Width - 10, pnlContainer.ClientSize.Height - pnlDetails.ClientSize.Height);
            pnlBill.Location = new Point(5, pnlDetails.Height);
            pnlContainer.Controls.Add(pnlBill);
            #endregion

            #region lsvOrder
            lsvBill = new ListView();
            lsvBill.View = View.Details;
            //lsvOrder.Location = new Point(0, 0);
            lsvBill.Size = new Size(pnlBill.ClientSize.Width, pnlBill.ClientSize.Height - 30);
            lsvBill.FullRowSelect = true;
            lsvBill.GridLines = true;
            //lsvOrder.BorderStyle = BorderStyle.None;
            lsvBill.Columns.Add("Tên món", 110, textAlign: HorizontalAlignment.Center);
            lsvBill.Columns.Add("Số lượng", 80, textAlign: HorizontalAlignment.Center);
            lsvBill.Columns.Add("Đơn giá", 90, textAlign: HorizontalAlignment.Center);
            lsvBill.Columns.Add("Thành tiền", 110, textAlign: HorizontalAlignment.Center);
            pnlBill.Controls.Add(lsvBill);
            #endregion 

            #region pnlAction
            pnlAction = new Panel();
            pnlAction.Dock = DockStyle.Right;
            pnlAction.Size = new Size(130, 500);
            pnlAction.BackColor = Color.FromArgb(255, 252, 230);
            pnlMain.Controls.Add(pnlAction);
            #endregion

            #region ptbLogo
            ptbLogo = new PictureBox();
            ptbLogo.Image = new Bitmap(Application.StartupPath + "\\image\\logo.png");
            ptbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            ptbLogo.Size = new Size(120, 120);
            ptbLogo.Location = new Point(5, 0);
            pnlAction.Controls.Add(ptbLogo);
            #endregion

            #region btnSwitchTable 
            btnSwitchTable = new Button();
            btnSwitchTable.Size = new Size(110, 35);
            btnSwitchTable.Text = "Chuyển bàn";
            btnSwitchTable.BackColor = Color.DarkGray;
            btnSwitchTable.FlatStyle = FlatStyle.Flat;
            btnSwitchTable.FlatAppearance.BorderSize = 0;
            btnSwitchTable.Location = new Point(10, 130);
            pnlAction.Controls.Add(btnSwitchTable);
            btnSwitchTable.Click += BtnSwitchTable_Click;
            #endregion
            #region btnCombineTable 
            btnCombineTable = new Button();
            btnCombineTable.Size = new Size(110, 35);
            btnCombineTable.Text = "Gộp bàn";
            btnCombineTable.BackColor = Color.DarkGray;
            btnCombineTable.FlatStyle = FlatStyle.Flat;
            btnCombineTable.FlatAppearance.BorderSize = 0;
            btnCombineTable.Location = new Point(10, 175);
            pnlAction.Controls.Add(btnCombineTable);
            btnCombineTable.Click += BtnCombineTable_Click;
            #endregion

            #region cbSwitchTable
            cbSwitchTable = new ComboBox();
            cbSwitchTable.Width = 110;
            cbSwitchTable.Location = new Point(10, 220);
            pnlAction.Controls.Add(cbSwitchTable);
            #endregion

            #region lbDiscount
            lbDiscount = new Label();
            lbDiscount.Text = "Giảm giá(%)";
            lbDiscount.Font = new Font("Roboto", 10, FontStyle.Bold);
            lbDiscount.Location = new Point(15, 270);
            pnlAction.Controls.Add(lbDiscount);
            #endregion

            #region nrudDiscount 
            // Tạo control nrudDiscount
            nrudDiscount = new NumericUpDown();
            nrudDiscount.Width = 70;
            nrudDiscount.Location = new Point(25, 300);
            nrudDiscount.Value = 0;
            pnlAction.Controls.Add(nrudDiscount);
            nrudDiscount.ValueChanged += NrudDiscount_ValueChanged;
            nrudDiscount.MouseClick += NrudDiscount_MouseClick;

            #endregion

            #region lbTotalPrice
            lbTotalPrice = new Label();
            lbTotalPrice.Text = "Tổng tiền";
            lbTotalPrice.Font = new Font("Roboto", 11, FontStyle.Bold);
            lbTotalPrice.Location = new Point(20, 335);
            pnlAction.Controls.Add(lbTotalPrice);
            #endregion

            #region txbTotalPrice
            txbTotalPrice = new TextBox();
            txbTotalPrice.Location = new Point(10, 365);
            txbTotalPrice.Size = new Size(110,35);
            txbTotalPrice.ReadOnly = true;
            txbTotalPrice.Font = new Font("Roboto", 10, FontStyle.Bold);
            txbTotalPrice.Text = "0";
            txbTotalPrice.TextAlign = HorizontalAlignment.Right;
            pnlAction.Controls.Add(txbTotalPrice);
            #endregion
            #region txbTotalPriceTemp
            txbTotalPriceTemp = new TextBox();
            txbTotalPriceTemp.Location = new Point(10, 340);
            txbTotalPriceTemp.Size = new Size(110, 35);
            txbTotalPriceTemp.ReadOnly = true;
            txbTotalPriceTemp.Font = new Font("Roboto", 10, FontStyle.Bold);
            txbTotalPriceTemp.Text = "0";
            txbTotalPriceTemp.TextAlign = HorizontalAlignment.Right;
            txbTotalPriceTemp.Visible = false;
            pnlAction.Controls.Add(txbTotalPriceTemp);
            #endregion

            #region btnCheckOut
            btnCheckOut = new Button();
            btnCheckOut.Size = new Size(110, 55);
            btnCheckOut.Text = "Thanh toán";
            btnCheckOut.BackColor = Color.DarkGray;
            btnCheckOut.FlatStyle = FlatStyle.Flat;
            btnCheckOut.FlatAppearance.BorderSize = 0;
            btnCheckOut.Location = new Point(10, 400);
            pnlAction.Controls.Add(btnCheckOut);
            btnCheckOut.Click += BtnCheckOut_Click;
            #endregion

        }



        #endregion

        #region Method

        void ChangeAccount(int typeUser)
        {
            adminMenuItem.Enabled = typeUser == 1;

            accountMenuItem.Text += " (" + LoginAccount.DisplayName + ")";
        }

        private Button btnTable;
        void LoadTable() 
        {
            flpTable.Controls.Clear();
            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach (Table item in tableList)
            {
                btnTable = new Button() {Width = TableDAO.TableWidth, Height = TableDAO.TableHeigh };
                btnTable.Text = item.NameTable + Environment.NewLine + item.StatusTable;
                btnTable.Tag = item;
                btnTable.Click += btnTable_Click;
                btnTable.Paint += BtnTable_Paint;

                switch (item.StatusTable)
                {
                    case "Trống":
                        btnTable.BackColor = Color.FromArgb(230, 250, 255);
                        break;
                    default:
                        btnTable.BackColor = Color.FromArgb(255, 187, 75);
                        break;
                }
                
                flpTable.Controls.Add(btnTable);

                
            }
            

        }

        void LoadComboBoxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "NameTable";
        }
        void ReLoadTable(int idTable)
        {
            // Tìm button tương ứng với idTable trong flpTable.Controls
            foreach (Button btn in flpTable.Controls)
            {
                Table table = btn.Tag as Table;
                if (table.IDTable == idTable)
                {
                    // Load lại chỉ bàn đã chọn
                    Table selectedTable = TableDAO.Instance.GetTableByID(idTable);
                    btn.Text = selectedTable.NameTable + Environment.NewLine + selectedTable.StatusTable;
                    // Cập nhật màu sắc của button tùy thuộc vào trạng thái của bàn
                    switch (selectedTable.StatusTable)
                    {
                        case "Trống":
                            btn.BackColor = Color.FromArgb(230, 250, 255);
                            break;
                        default:
                            btn.BackColor = Color.FromArgb(255, 187, 75);
                            break;
                    }
                    break;
                }
            }


        }


        void ShowBill(int idTable)
        {
            lsvBill.Items.Clear();
            List<TotalPriceBill> listTotalPriceBill = TotalPriceBillDAO.Instance.GetListMenuByTable(idTable);
            float totalPrice = 0;
            foreach (TotalPriceBill item in listTotalPriceBill)
            {
                ListViewItem lsvItem = new ListViewItem(item.NameMenu.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lsvBill.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            //Thread.CurrentThread.CurrentCulture = culture;
            txbTotalPrice.Text = totalPrice.ToString("c", culture);
            txbTotalPriceTemp.Text = totalPrice.ToString("c", culture);

        }

        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "nameCategory";
        }
        void LoadMenuListByCategoryID(int idCategory)
        {
            List<FMenu> listFMenu = FMenuDAO.Instance.GetMenuByCategoryID(idCategory);
            if (listFMenu.Count > 0)
            {
                cbMenu.DataSource = listFMenu;
                cbMenu.DisplayMember = "nameMenu";
            }
            else
            {
                cbMenu.DataSource = null;
            }
        }



        #endregion
        #region Events
        private void AccountProfileMenuItem_Click(object sender, EventArgs e)
        {
            AccountProfileWinform info = new AccountProfileWinform(LoginAccount);
            info.UpdateAccount += Info_UpdateAccount;
            //this.Hide();
            info.ShowDialog();
            //this.Show();
        }

        private void Info_UpdateAccount(object sender, AccountEvent e)
        {
            accountMenuItem.Text = "Tài khoản ("+e.Acc.DisplayName+")";
        }
        #region event AdminMenuItem_Click
        private void AdminMenuItem_Click(object sender, EventArgs e)
        {
            AdminWinform admin = new AdminWinform();
            admin.loginAccount = LoginAccount;
            admin.InsertMenu += Admin_InsertMenu;
            admin.UpdateMenu += Admin_UpdateMenu;
            admin.DeleteMenu += Admin_DeleteMenu;
            admin.InsertCategory += Admin_InsertCategory;
            admin.UpdateCategory += Admin_UpdateCategory;
            admin.DeleteCategory += Admin_DeleteCategory;
            admin.InsertTable += Admin_InsertTable;
            admin.UpdateTable += Admin_UpdateTable;
            admin.DeleteTable += Admin_DeleteTable;

            admin.ShowDialog();
        }

        private void Admin_InsertTable(object sender, EventArgs e)
        {
            LoadTable();
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as Table).IDTable);
                ReLoadTable((lsvBill.Tag as Table).IDTable);
            }
        }

        private void Admin_UpdateTable(object sender, EventArgs e)
        {
            LoadTable();
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as Table).IDTable);
                ReLoadTable((lsvBill.Tag as Table).IDTable);
            }
        }

        private void Admin_DeleteTable(object sender, EventArgs e)
        {
            LoadTable();
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as Table).IDTable);
                ReLoadTable((lsvBill.Tag as Table).IDTable);
            }
        }

        private void Admin_DeleteCategory(object sender, EventArgs e)
        {
            LoadCategory();
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as Table).IDTable);
                ReLoadTable((lsvBill.Tag as Table).IDTable);
            }
        }

        private void Admin_UpdateCategory(object sender, EventArgs e)
        {
            LoadCategory();
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as Table).IDTable);
                ReLoadTable((lsvBill.Tag as Table).IDTable);
            }
        }

        private void Admin_InsertCategory(object sender, EventArgs e)
        {
            LoadCategory();
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as Table).IDTable);
                ReLoadTable((lsvBill.Tag as Table).IDTable);
            }
        }

        private void Admin_DeleteMenu(object sender, EventArgs e)
        {
            LoadMenuListByCategoryID((cbCategory.SelectedItem as Category).IDCategory);
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as Table).IDTable);
                ReLoadTable((lsvBill.Tag as Table).IDTable);
            }

        }

        private void Admin_UpdateMenu(object sender, EventArgs e)
        {
            LoadMenuListByCategoryID((cbCategory.SelectedItem as Category).IDCategory);
            if(lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as Table).IDTable);
                ReLoadTable((lsvBill.Tag as Table).IDTable);
            }

        }

        private void Admin_InsertMenu(object sender, EventArgs e)
        {
            LoadMenuListByCategoryID((cbCategory.SelectedItem as Category).IDCategory);
            if (lsvBill.Tag != null)
            {
                ShowBill((lsvBill.Tag as Table).IDTable);
                ReLoadTable((lsvBill.Tag as Table).IDTable);
            }
        }
        #endregion
        private void SignOutMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private Button selectedTable;
        private void BtnTable_Paint(object sender, PaintEventArgs e)
        {
            Button button = (Button)sender;

            // Vẽ viền cho button nếu button đang được chọn
            if (button == selectedTable)
            {
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(42, 142, 219), 3), 2, 2, button.Width - 4, button.Height - 4);
            }
        }
        private void btnTable_Click(object sender, EventArgs e)
        {
            int idTable = ((sender as Button).Tag as Table).IDTable;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(idTable);

            Button clickedTable = sender as Button;

            //vẽ viền cho button
            clickedTable.FlatAppearance.BorderColor = Color.FromArgb(42, 142, 219);
            if (selectedTable != null && selectedTable != clickedTable)
            {
                // Nếu có, đặt màu của nó về màu mặc định
                selectedTable.FlatAppearance.BorderColor = SystemColors.Control;
            }
            selectedTable = clickedTable;
            //// Gán tên của button vào TextBox
            //txbTableName.Text = clickedTable.Text.Substring(0, Math.Min(clickedTable.Text.Length, 7));


        }
        private void CbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCategory = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category selected = cb.SelectedItem as Category;
            idCategory = selected.IDCategory;

            LoadMenuListByCategoryID(idCategory);

        }
        
        private void BtnAddMenu_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            if(table == null)
            {
                MessageBox.Show("Hãy chọn bàn!");
                return;
            }
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.IDTable);

            int idMenu = (cbMenu.SelectedItem as FMenu).IDMenu;
            int count = (int)nrudMenuCount.Value;

            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.IDTable);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), idMenu, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, idMenu, count);

            }


            ShowBill(table.IDTable);
            ReLoadTable(table.IDTable);
            nrudMenuCount.Value = 1;
        }
        private void BtnCheckOut_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            if(table == null)
            {
                MessageBox.Show("Hãy chọn bàn!");
                return;
            }
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.IDTable);
            int discount = (int)nrudDiscount.Value;
            float totalPrice = float.Parse(txbTotalPrice.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("vi-VN"));

            if (idBill != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có muốn thanh toán hóa đơn cho "+table.NameTable+".\nTổng tiền: "+ totalPrice+"đ"),
                    "Thông báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill, discount, totalPrice);
                    ShowBill(table.IDTable);
                    ReLoadTable(table.IDTable);

                }
            }
        }

        private float totalPrice1;
        private float totalPrice2;

        private void NrudDiscount_ValueChanged(object sender, EventArgs e)
        {
            // Áp dụng giảm giá vào tổng giá trị
            // Lấy giá trị hiện tại của giảm giá từ nrudDiscount
            int discount = (int)nrudDiscount.Value;
            // Lấy giá trị tổng của hóa đơn từ txbTotalPrice
            totalPrice1 = float.Parse(txbTotalPrice.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("vi-VN"));
            totalPrice2 = float.Parse(txbTotalPriceTemp.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("vi-VN"));
            if (totalPrice1!= totalPrice2)
            {
                txbTotalPrice.Text = totalPrice2.ToString("c", CultureInfo.GetCultureInfo("vi-VN"));
                nrudDiscount.Value = 0;
            }
            else
            {
                float finalTotalPrice = totalPrice1 - (totalPrice1 * discount / 100);

                // Hiển thị giá trị mới trong txbTotalPrice
                txbTotalPrice.Text = finalTotalPrice.ToString("c", CultureInfo.GetCultureInfo("vi-VN"));
            }

        }
        private void NrudDiscount_MouseClick(object sender, MouseEventArgs e)
        {
            nrudDiscount.Value = 0;
        }

        private void BtnSwitchTable_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn!");
                return;
            }
            int idOldTable = (lsvBill.Tag as Table).IDTable;
            int idNewTable = (cbSwitchTable.SelectedItem as Table).IDTable;

            if (MessageBox.Show(string.Format("Bạn có muốn chuyển {0} qua {1} không?", (lsvBill.Tag as Table).NameTable, (cbSwitchTable.SelectedItem as Table).NameTable),"Chuyển bàn",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                TableDAO.Instance.SwitchTable(idOldTable, idNewTable);
                LoadTable();
            }
           

        }
        private void BtnCombineTable_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn!");
                return;
            }
            int idOldTable = (lsvBill.Tag as Table).IDTable;
            int idNewTable = (cbSwitchTable.SelectedItem as Table).IDTable;
            if (MessageBox.Show(string.Format("Bạn có muốn gộp {0} qua {1} không?", (lsvBill.Tag as Table).NameTable, (cbSwitchTable.SelectedItem as Table).NameTable), "Gộp bàn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                TableDAO.Instance.CombineTable(idOldTable, idNewTable);
                LoadTable();
            }
        }


        #endregion

    }
}
