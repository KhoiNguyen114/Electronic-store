using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace BLL_DAL
{
    public class BLLDALPhanQuyen
    {
        QuanLyCuaHangDienMayDataContext quanLy = new QuanLyCuaHangDienMayDataContext();
        public BLLDALPhanQuyen()
        {

        }

        public int Check_Config()
        {
            if (Properties.Settings.Default.QNConnection == string.Empty)
                return 1; //Chuoi cau hinh khong ton tai
            SqlConnection sqlConn = new SqlConnection(Properties.Settings.Default.QNConnection);
            try
            {
                if (sqlConn.State == System.Data.ConnectionState.Closed)
                    sqlConn.Open();
                return 0; //ket noi thanh cong chuoi cau hinh hop le
            }
            catch
            {
                return 2; //chuoi cau hinh khong phu hop
            }
        }

        public int Check_user(string user, string pass)
        {
            SqlDataAdapter da_User = new SqlDataAdapter("Select * from NguoiDung where TenDN='" + user + "' and MatKhau ='" + pass + "'", Properties.Settings.Default.QNConnection);
            DataTable dt = new DataTable();
            da_User.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                return 1;   //User không tồn tại
            }
            else if (dt.Rows[0][2] == null || dt.Rows[0][2].ToString() == "False")
            {
                return 2;   //Không hoạt động
            }
            return 0; //Đăng nhập thành công
        }

        public DataTable GetServerName()
        {
            DataTable dt = new DataTable();
            dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            return dt;
        }

        public DataTable GetDBName(string serverName, string user, string pass)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select name from sys.Databases",
                "Data Source=" + serverName + ";Initial Catalog=master;User ID=" + user + ";pwd = " +
                pass + "");
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public void SaveConfig(string server, string user, string pass, string databaseName)
        {
            BLL_DAL.Properties.Settings.Default.QNConnection = "Data source = " + server + ";Initial Catalog = " + databaseName + "; User ID = " + user + ";pwd = " + pass + "";
            BLL_DAL.Properties.Settings.Default.Save();
        }

        public List<MaNhomNguoiDung> getMaNhomNguoiDung(string pTenDangNhap)
        {
            List<MaNhomNguoiDung> ds = quanLy.QL_NGUOIDUNGNHOMNGUOIDUNGs.Select(t => new MaNhomNguoiDung { MaNhom = t.MANHOM, TenDangNhap = t.TENDN }).Where(t => t.TenDangNhap == pTenDangNhap).ToList();
            return ds;
        }

        public List<DanhSachManHinh> getMaManHinh(string pMaNhomND)
        {
            List<DanhSachManHinh> ds = quanLy.PHANQUYENs.Select(t => new DanhSachManHinh { MaNhom = t.MANHOM, MaManHinh = t.MAMH, CoQuyen = t.COQUYEN }).Where(t => t.MaNhom == pMaNhomND).ToList();
            return ds;
        }
    }

    public class MaNhomNguoiDung
    {
        string maNhom;
        string tenDangNhap;

        public string TenDangNhap
        {
            get { return tenDangNhap; }
            set { tenDangNhap = value; }
        }
        public string MaNhom
        {
            get { return maNhom; }
            set { maNhom = value; }
        }
    }

    public class DanhSachManHinh
    {
        string maNhom, maManHinh;
        bool? coQuyen;

        public bool? CoQuyen
        {
            get { return coQuyen; }
            set { coQuyen = value; }
        }

        public string MaManHinh
        {
            get { return maManHinh; }
            set { maManHinh = value; }
        }

        public string MaNhom
        {
            get { return maNhom; }
            set { maNhom = value; }
        }

    }
}

