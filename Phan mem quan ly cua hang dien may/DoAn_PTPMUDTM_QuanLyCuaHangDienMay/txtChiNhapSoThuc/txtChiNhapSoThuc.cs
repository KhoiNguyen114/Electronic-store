using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace txtChiNhapSoThuc
{
    public class txtChiNhapSoThuc : TextBox
    {
        public txtChiNhapSoThuc()
        {
            this.KeyPress += txtChiNhapSoThuc_KeyPress;
        }

        private void txtChiNhapSoThuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.' ||
                (e.KeyChar == '.' && (this.Text.Length == 0 || this.Text.IndexOf('.') != -1))))
            {
                e.Handled = true;
            }
        }
    }
}
