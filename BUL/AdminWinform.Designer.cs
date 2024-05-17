
using PM_QuanLyQuanCafe.Report;

namespace PM_QuanLyQuanCafe
{
    partial class AdminWinform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.USP_GetListBillByDateForReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QuanLyQuanCafeDataSet = new PM_QuanLyQuanCafe.Report.QuanLyQuanCafeDataSet();
            this.USP_GetListBillByDateForReportTableAdapter = new PM_QuanLyQuanCafe.Report.QuanLyQuanCafeDataSetTableAdapters.USP_GetListBillByDateForReportTableAdapter();
            this.tcAdmin = new System.Windows.Forms.TabControl();
            this.tpBill = new System.Windows.Forms.TabPage();
            this.tpMenu = new System.Windows.Forms.TabPage();
            this.tpTable = new System.Windows.Forms.TabPage();
            this.tpCategory = new System.Windows.Forms.TabPage();
            this.tpAccount = new System.Windows.Forms.TabPage();
            this.tpReport = new System.Windows.Forms.TabPage();
            this.pnlReport = new System.Windows.Forms.Panel();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetListBillByDateForReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyQuanCafeDataSet)).BeginInit();
            this.tcAdmin.SuspendLayout();
            this.tpReport.SuspendLayout();
            this.pnlReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // USP_GetListBillByDateForReportBindingSource
            // 
            this.USP_GetListBillByDateForReportBindingSource.DataMember = "USP_GetListBillByDateForReport";
            this.USP_GetListBillByDateForReportBindingSource.DataSource = this.QuanLyQuanCafeDataSet;
            // 
            // QuanLyQuanCafeDataSet
            // 
            this.QuanLyQuanCafeDataSet.DataSetName = "QuanLyQuanCafeDataSet";
            this.QuanLyQuanCafeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // USP_GetListBillByDateForReportTableAdapter
            // 
            this.USP_GetListBillByDateForReportTableAdapter.ClearBeforeFill = true;
            // 
            // tcAdmin
            // 
            this.tcAdmin.Controls.Add(this.tpBill);
            this.tcAdmin.Controls.Add(this.tpMenu);
            this.tcAdmin.Controls.Add(this.tpTable);
            this.tcAdmin.Controls.Add(this.tpCategory);
            this.tcAdmin.Controls.Add(this.tpAccount);
            this.tcAdmin.Controls.Add(this.tpReport);
            this.tcAdmin.Location = new System.Drawing.Point(3, 3);
            this.tcAdmin.Name = "tcAdmin";
            this.tcAdmin.SelectedIndex = 0;
            this.tcAdmin.Size = new System.Drawing.Size(1164, 619);
            this.tcAdmin.TabIndex = 0;
            // 
            // tpBill
            // 
            this.tpBill.Location = new System.Drawing.Point(4, 31);
            this.tpBill.Name = "tpBill";
            this.tpBill.Padding = new System.Windows.Forms.Padding(3);
            this.tpBill.Size = new System.Drawing.Size(1156, 584);
            this.tpBill.TabIndex = 0;
            this.tpBill.Text = "Doanh thu";
            this.tpBill.UseVisualStyleBackColor = true;
            // 
            // tpMenu
            // 
            this.tpMenu.Location = new System.Drawing.Point(4, 31);
            this.tpMenu.Name = "tpMenu";
            this.tpMenu.Padding = new System.Windows.Forms.Padding(3);
            this.tpMenu.Size = new System.Drawing.Size(1156, 584);
            this.tpMenu.TabIndex = 1;
            this.tpMenu.Text = "Món ăn";
            this.tpMenu.UseVisualStyleBackColor = true;
            // 
            // tpTable
            // 
            this.tpTable.Location = new System.Drawing.Point(4, 31);
            this.tpTable.Name = "tpTable";
            this.tpTable.Padding = new System.Windows.Forms.Padding(3);
            this.tpTable.Size = new System.Drawing.Size(1156, 584);
            this.tpTable.TabIndex = 2;
            this.tpTable.Text = "Bàn";
            this.tpTable.UseVisualStyleBackColor = true;
            // 
            // tpCategory
            // 
            this.tpCategory.Location = new System.Drawing.Point(4, 31);
            this.tpCategory.Name = "tpCategory";
            this.tpCategory.Padding = new System.Windows.Forms.Padding(3);
            this.tpCategory.Size = new System.Drawing.Size(1156, 584);
            this.tpCategory.TabIndex = 3;
            this.tpCategory.Text = "Doanh mục";
            this.tpCategory.UseVisualStyleBackColor = true;
            // 
            // tpAccount
            // 
            this.tpAccount.Location = new System.Drawing.Point(4, 31);
            this.tpAccount.Name = "tpAccount";
            this.tpAccount.Padding = new System.Windows.Forms.Padding(3);
            this.tpAccount.Size = new System.Drawing.Size(1156, 584);
            this.tpAccount.TabIndex = 4;
            this.tpAccount.Text = "Tài khoản";
            this.tpAccount.UseVisualStyleBackColor = true;
            // 
            // tpReport
            // 
            this.tpReport.Controls.Add(this.pnlReport);
            this.tpReport.Location = new System.Drawing.Point(4, 31);
            this.tpReport.Name = "tpReport";
            this.tpReport.Padding = new System.Windows.Forms.Padding(3);
            this.tpReport.Size = new System.Drawing.Size(1156, 584);
            this.tpReport.TabIndex = 5;
            this.tpReport.Text = "Report";
            this.tpReport.UseVisualStyleBackColor = true;
            // 
            // pnlReport
            // 
            this.pnlReport.Controls.Add(this.reportViewer);
            this.pnlReport.Location = new System.Drawing.Point(3, 6);
            this.pnlReport.Name = "pnlReport";
            this.pnlReport.Size = new System.Drawing.Size(1157, 582);
            this.pnlReport.TabIndex = 0;
            // 
            // reportViewer
            // 
            this.reportViewer.AutoSize = true;
            this.reportViewer.DocumentMapWidth = 82;
            reportDataSource1.Name = "ReportBill";
            reportDataSource1.Value = this.USP_GetListBillByDateForReportBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "PM_QuanLyQuanCafe.Report.rptBill.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(3, 3);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(1147, 569);
            this.reportViewer.TabIndex = 0;
            // 
            // AdminWinform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 631);
            this.Controls.Add(this.tcAdmin);
            this.Name = "AdminWinform";
            this.Text = "AdminWinform";
            this.Load += new System.EventHandler(this.AdminWinform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetListBillByDateForReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyQuanCafeDataSet)).EndInit();
            this.tcAdmin.ResumeLayout(false);
            this.tpReport.ResumeLayout(false);
            this.pnlReport.ResumeLayout(false);
            this.pnlReport.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion
        private System.Windows.Forms.BindingSource USP_GetListBillByDateForReportBindingSource;
        private Report.QuanLyQuanCafeDataSet QuanLyQuanCafeDataSet;
        private Report.QuanLyQuanCafeDataSetTableAdapters.USP_GetListBillByDateForReportTableAdapter USP_GetListBillByDateForReportTableAdapter;
        private System.Windows.Forms.TabControl tcAdmin;
        private System.Windows.Forms.TabPage tpBill;
        private System.Windows.Forms.TabPage tpMenu;
        private System.Windows.Forms.TabPage tpTable;
        private System.Windows.Forms.TabPage tpCategory;
        private System.Windows.Forms.TabPage tpAccount;
        private System.Windows.Forms.TabPage tpReport;
        private System.Windows.Forms.Panel pnlReport;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
    }
}