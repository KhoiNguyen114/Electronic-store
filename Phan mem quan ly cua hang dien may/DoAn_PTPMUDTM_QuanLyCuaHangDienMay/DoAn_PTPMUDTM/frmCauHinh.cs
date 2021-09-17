using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL;

namespace DoAn_PTPMUDTM
{
    public partial class frmCauHinh : Form
    {
        BLLDALPhanQuyen daPQ = new BLLDALPhanQuyen();
        public frmCauHinh()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtUser.Text.Trim()) || String.IsNullOrEmpty(txtPass.Text.Trim()))
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            daPQ.SaveConfig(cbbServerName.Text, txtUser.Text, txtPass.Text, cbbDBName.Text);
            this.Close();
        }

        private void cbbServerName_DropDown(object sender, EventArgs e)
        {
            //cbbServerName.DataSource = daPQ.GetServerName();
            //cbbServerName.DisplayMember = "ServerName";
            cbbServerName.Items.Clear();
            cbbServerName.Items.Add(@".\SQLEXPRESS");
            cbbServerName.Items.Add(string.Format("{0: 0\\SQLEXPRESS}", Environment.MachineName));
        }

        private void cbbDBName_DropDown(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUser.Text.Trim()) || String.IsNullOrEmpty(txtPass.Text.Trim()))
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cbbDBName.DataSource = daPQ.GetDBName(cbbServerName.Text, txtUser.Text, txtPass.Text);
            cbbDBName.DisplayMember = "name";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmCauHinh_Load(object sender, EventArgs e)
        {

        }

        private void cbbServerName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
