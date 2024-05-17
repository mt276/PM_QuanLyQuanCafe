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
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; //Đặt form nằm giữa màn hình
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Đặt kiểu border của form thành FixedSingle để không cho phép điều chỉnh kích thước
            this.MaximizeBox = false;
            this.Font = new Font("Roboto", 9);
            this.AutoSize = true;
        }
    }
}
