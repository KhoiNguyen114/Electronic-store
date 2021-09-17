using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL;

namespace DoAn_PTPMUDTM
{
    static class Program
    {
        public static frmMain frmMain = null;
        public static frmDangNhap frmDangNhap = null;
        public static frmKhachHang frmKhachHang = null;
        public static string tenDangNhap = null;


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmMain = new frmMain();
            frmDangNhap = new frmDangNhap();
            Application.Run(new frmDangNhap());
        }
    }
}
