﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
namespace WarehouseManagementSystem
{
    public partial class frmStockRecord1 : Form
    {
        SqlDataReader rdr = null;
        SqlConnection con = null;
        SqlCommand cmd = null;
        ConnectionString cs = new ConnectionString();
        public frmStockRecord1()
        {
            InitializeComponent();
        }
        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String sql = "SELECT RTRIM(StockID),RTRIM(StockDate),RTRIM(Product.ProductID),RTRIM(ProductName),RTRIM(Features),RTRIM(Supplier.SupplierID),RTRIM(SupplierName),RTRIM(Quantity),RTRIM(ExpiryDate) from Stock,Product,Supplier where Stock.ProductID=Product.ProductID and Stock.SupplierID=Supplier.SupplierID order by ProductName";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5],rdr[6],rdr[7],rdr[8]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmStockRecord_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void txtProductname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String sql = "SELECT RTRIM(StockID),RTRIM(StockDate),RTRIM(Product.ProductID),RTRIM(ProductName),RTRIM(Features),RTRIM(Supplier.SupplierID),RTRIM(SupplierName),RTRIM(Quantity),RTRIM(ExpiryDate) from Stock,Product,Supplier where Stock.ProductID=Product.ProductID and Stock.SupplierID=Supplier.SupplierID and productname like '" + txtProductname.Text + "%' order by ProductName";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6],rdr[7],rdr[8]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
     
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dataGridView1.SelectedRows[0];
                this.Hide();
                frmStock frm = new frmStock();
                frm.Show();
                frm.txtStockID.Text = dr.Cells[0].Value.ToString();
                frm.dtpStockDate.Text = dr.Cells[1].Value.ToString();
                frm.txtProductID.Text = dr.Cells[2].Value.ToString();
                frm.txtProductName.Text = dr.Cells[3].Value.ToString();
                frm.txtFeatures.Text = dr.Cells[4].Value.ToString();

                frm.txtSupplierID.Text = dr.Cells[5].Value.ToString();
                frm.cmbSupplierName.Text = dr.Cells[6].Value.ToString();
                frm.txtQty.Text = dr.Cells[7].Value.ToString();
                frm.txtQty1.Text = dr.Cells[7].Value.ToString();
                frm.dtpExpiryDate.Text = dr.Cells[8].Value.ToString();
                frm.btnUpdate.Enabled = true;
                frm.btnDelete.Enabled = true;
                frm.btnSave.Enabled = false;
                frm.lblUser.Text = lblUser.Text;
                frm.lblUserType.Text = lblUserType.Text;
           }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmStockRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frmStock frm = new frmStock();
            frm.lblUser.Text = lblUser.Text;
            frm.lblUserType.Text = lblUserType.Text;
            frm.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            int rowsTotal = 0;
            int colsTotal = 0;
            int I = 0;
            int j = 0;
            int iC = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = dataGridView1.RowCount;
                colsTotal = dataGridView1.Columns.Count - 1;
                var _with1 = excelWorksheet;
                _with1.Cells.Select();
                _with1.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    _with1.Cells[1, iC + 1].Value = dataGridView1.Columns[iC].HeaderText;
                }
                for (I = 0; I <= rowsTotal - 1; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        _with1.Cells[I + 2, j + 1].value = dataGridView1.Rows[I].Cells[j].Value;
                    }
                }
                _with1.Rows["1:1"].Font.FontStyle = "Bold";
                _with1.Rows["1:1"].Font.Size = 12;

                _with1.Cells.Columns.AutoFit();
                _with1.Cells.Select();
                _with1.Cells.EntireColumn.AutoFit();
                _with1.Cells[1, 1].Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //RELEASE ALLOACTED RESOURCES
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                xlApp = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtProductname.Text = "";
            dtpStockDateFrom.Text = System.DateTime.Today.ToString();
            dtpStockDateTo.Text = System.DateTime.Today.ToString();
            GetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBConn);
                con.Open();
                String sql = "SELECT RTRIM(StockID),RTRIM(StockDate),RTRIM(Product.ProductID),RTRIM(ProductName),RTRIM(Features),RTRIM(Supplier.SupplierID),RTRIM(SupplierName),RTRIM(Quantity),RTRIM(ExpiryDate) from Stock,Product,Supplier where Stock.ProductID=Product.ProductID and Stock.SupplierID=Supplier.SupplierID and StockDate between @d1 and @d2 order by ProductName";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "StockDate").Value = dtpStockDateFrom.Value.Date;
                cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "StockDate").Value = dtpStockDateTo.Value.Date;
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7],rdr[8]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
