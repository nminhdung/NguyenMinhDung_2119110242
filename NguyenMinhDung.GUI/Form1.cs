using NguyenMinhDung.BLL.Customer;
using NguyenMinhDung.DTO.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NguyenMinhDung.GUI
{
    public partial class Form1 : Form
    {
        CustomerBLL cusBLL = new CustomerBLL();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<CustomerDTO> lstCus = cusBLL.ReadCustomer();
            foreach (CustomerDTO item in lstCus)
            {
                dataGvCustomer.Rows.Add(item.MaKh,item.Name,item.Phone,item.Owe);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtName.Text == "" || txtPhone.Text == "" )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else { 
                CustomerDTO cus = new CustomerDTO();
                cus.MaKh = txtId.Text.ToString();
                cus.Name = txtName.Text.ToString();
                cus.Phone = txtPhone.Text.ToString();
                cus.Owe = decimal.Parse(txtOwe.Text.ToString());

                cusBLL.AddCustomer(cus);

                dataGvCustomer.Rows.Add(cus.MaKh, cus.Name, cus.Phone, cus.Owe);
                txtId.Text = "";
                txtName.Text = "";
                txtPhone.Text = "";
                txtOwe.Text = ""; 
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            CustomerDTO cus = new CustomerDTO();
            cus.MaKh = txtId.Text.ToString();
            cus.Name = txtName.Text.ToString();
            cus.Phone = txtPhone.Text.ToString();
            cus.Owe = decimal.Parse(txtOwe.Text.ToString());
            cusBLL.DeleteCustomer(cus);
            int idx = dataGvCustomer.CurrentCell.RowIndex;
            dataGvCustomer.Rows.RemoveAt(idx);
        }
        private void dataGvCustomer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            txtId.Text = dataGvCustomer.Rows[idx].Cells[0].Value.ToString();
            txtName.Text = dataGvCustomer.Rows[idx].Cells[1].Value.ToString();
            txtPhone.Text = dataGvCustomer.Rows[idx].Cells[2].Value.ToString();
            txtOwe.Text = dataGvCustomer.Rows[idx].Cells[3].Value.ToString();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            CustomerDTO cus = new CustomerDTO();
            cus.MaKh = txtId.Text;
            cus.Name = txtName.Text.ToString();
            cus.Phone = txtPhone.Text;
            cus.Owe = decimal.Parse(txtOwe.Text.ToString());
            cusBLL.RecordCustomer(cus);
            DataGridViewRow row = dataGvCustomer.CurrentRow;
            row.Cells[0].Value = cus.MaKh;
            row.Cells[1].Value = cus.Name;
            row.Cells[2].Value = cus.Phone;
            row.Cells[3].Value = cus.Owe;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
