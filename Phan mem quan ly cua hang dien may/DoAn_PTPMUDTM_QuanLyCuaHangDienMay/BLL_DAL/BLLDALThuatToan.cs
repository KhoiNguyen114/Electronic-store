using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace BLL_DAL
{
    public class BLLDALThuatToan
    {
        QuanLyCuaHangDienMayDataContext quanLy = new QuanLyCuaHangDienMayDataContext();

        public BLLDALThuatToan()
        {

        }

        public string[][] MatrixString(int rows, int cols)
        {
            string[][] result = new string[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new string[cols];
            return result;
        }

        public int[][] MatrixInt(int rows, int cols)
        {
            int[][] result = new int[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new int[cols];
            return result;
        }

        public int ArgMax(double[] vector)
        {
            int result = 0;
            double maxV = vector[0];
            for (int i = 0; i < vector.Length; ++i)
            {
                if (vector[i] > maxV)
                {
                    maxV = vector[i];
                    result = i;
                }
            }
            return result;
        }

        

        public void thucThiBayesTuLam(string pDacDiem1, string pDacDiem2, string pDacDiem3, string pDacDiem4,
            List<string> lstDD1, List<string> lstDD2, List<string> lstDD3, List<string> lstDD4,
            List<string> lstMaSP, List<string> lstPhanLop, int numClass, int numData)
        {
            int N = numData; //Số dòng dữ liệu
            int nc = numClass; //Số phân lớp
            int nx = 4; //Số thuộc tính

            int[][] jointCts = MatrixInt(nx, nc);   //Khởi tạo mảng 2 chiều chứa số trường dựa trên số lớp
            int[] yCts = new int[nc]; //Khởi tạo mảng 1 chièu chưa số lớp
            string[] X = new string[4];   //Khởi tạo mảng chứa thuộc tính cần phân lớp
            X[0] = pDacDiem1;
            X[1] = pDacDiem2;
            X[2] = pDacDiem3;
            X[3] = pDacDiem4;

            //Ta tạo 5 cột để thực hiện việc thêm tất cả dữ liệu từ 5 cột này vào mảng 2 chiều
            var col1 = lstDD1;
            var col2 = lstDD2;
            var col3 = lstDD3;
            var col4 = lstDD4;
            var col5 = lstMaSP;

            string[][] mang = MatrixString(N, nx + 1);
            for (int i = 0; i < N; i++)
            {
                mang[i][0] = col1[i];
                mang[i][1] = col2[i];
                mang[i][2] = col3[i];
                mang[i][3] = col4[i];
                mang[i][4] = col5[i];
            }

            //Tính xác suất cho mỗi phân lớp
            for(int i=0; i<N; i++)
            {
                string a = mang[i][nx].ToString();
                int y = int.Parse(a.Substring(4, 1));
                yCts[y]++; //Số lần xuất hiện của mỗi lớp trên N dòng dữ liệu
                for (int j = 0; j < nx; j++)
                {
                    if (mang[i][j].ToString() == X[j])
                        jointCts[j][y]++;   //Số lần xuất hiện của mỗi thuộc tính trong mỗi phân lớp
                }
            }

            //Làm trơn cho các thuộc tính. Cụ thể là tử số +1,
            //mẫu số + số lượng trường hợp của 1 thuộc tính (VD: Độ phân giải: 2K,4K,8K => mẫu +3)
            for (int i = 0; i < nx; i++)
                for (int j = 0; j < nc; j++)
                    jointCts[i][j]++;   //Làm trơn tử số

            
            
            //Làm trơn mẫu số và tính theo công thức bayes P(Ci|X) = P(X|Ci).P(Ci)
            double[] eTerms = new double[nc];
            for (int i = 0; i < nc; i++)
            {
                double v = 1.0;
                for (int j = 0; j < nx; j++)
                {
                    v *= (double)(jointCts[j][i]) / (yCts[i] + nx);
                }
                v *= (double)(yCts[i]) / N;
                eTerms[i] = v;                
            }

            string[] mangSP = lstPhanLop.ToArray();
            for(int i=0; i<mangSP.Length-1; i++)
            {
                for(int j=i+1; j<mangSP.Length; j++)
                {
                    int a = int.Parse(mangSP[i].ToString().Substring(4, 1));
                    int b = int.Parse(mangSP[j].ToString().Substring(4, 1));
                    if(a > b)
                    {
                        string temp = mangSP[i];
                        mangSP[i] = mangSP[j];
                        mangSP[j] = temp;
                    }
                }
            }

            //Tính lại xác suất, tổng các xác suất trên class = 1
            StreamWriter sw = new StreamWriter("Output.txt");            
            double evidence = 0.0;
            for (int k = 0; k < nc; k++)
                evidence += eTerms[k];
            double[] probs = new double[nc];
            for (int k = 0; k < nc; k++)
            {
                probs[k] = eTerms[k] / evidence;
                sw.WriteLine(pDacDiem1 + ", " + pDacDiem2 + ", " + pDacDiem3 + ", " + pDacDiem4 + ", " + probs[k]);
                ghiFileTiepTuc(pDacDiem1 + ", " + pDacDiem2 + ", " + pDacDiem3 + ", " + pDacDiem4 + ", " + probs[k] + ", " + mangSP[k] +"\n");
            }
            sw.Close();


            //Tìm vị trí của max trong mảng chứa xác suất từng lớp
            int viTri = ArgMax(probs);
            
        }

        public List<DuLieu> docFile()
        {
            StreamReader sr = new StreamReader("TuLanh.txt");
            string line;
            List<DuLieu> ds = new List<DuLieu>();
            while((line = sr.ReadLine()) != null)
            {
                string[] a = line.Split(',');
                DuLieu duLieu = new DuLieu();
                duLieu.TenThietBi = a[0];
                duLieu.DacDiem1 = a[1];
                duLieu.DacDiem2 = a[2];
                duLieu.DacDiem3 = a[3];
                duLieu.DacDiem4 = a[4];
                duLieu.MaSP = a[5];
                ds.Add(duLieu);
            }
            sr.Close();
            return ds;
        }

        public List<TieuChi> docFileTieuChi()
        {
            StreamReader sr = new StreamReader("FileTieuChi.txt");
            string line;
            List<TieuChi> ds = new List<TieuChi>();
            while ((line = sr.ReadLine()) != null)
            {
                string[] a = line.Split(',');
                TieuChi tieuChi = new TieuChi();
                tieuChi.TenThietBi = a[0];
                tieuChi.TieuChi1 = a[1];
                tieuChi.TieuChi2 = a[2];
                tieuChi.TieuChi3 = a[3];
                tieuChi.TieuChi4 = a[4];
                ds.Add(tieuChi);
            }
            sr.Close();
            return ds;
        }

        public List<DuLieuTrain> docFileTrain()
        {
            StreamReader sr = new StreamReader("Output1.txt");
            string line;
            List<DuLieuTrain> ds = new List<DuLieuTrain>();
            while((line = sr.ReadLine())!= null)
            {
                string[] a = line.Split(',');
                DuLieuTrain dlt = new DuLieuTrain();
                dlt.DacDiem1 = a[0];
                dlt.DacDiem2 = a[1];
                dlt.DacDiem3 = a[2];
                dlt.DacDiem4 = a[3];
                dlt.XacSuat = double.Parse(a[4]);
                dlt.MaSP = a[5];
                ds.Add(dlt);
            }
            sr.Close();
            return ds;
        }


        public void ghiFile(string pValue)
        {
            StreamWriter sw = new StreamWriter("Output.txt");
            sw.WriteLine(pValue);
            sw.Close();
        }

        public void ghiFileTiepTuc(string pValue)
        {
            string fileName = "Output1.txt";
            string fullpath = @"E:\Phat trien phan mem va ung dung thong minh\DoAn_PTPMUDTM\DoAn_PTPMUDTM\DoAn_PTPMUDTM\DoAn_PTPMUDTM\bin\Debug\" + fileName;
            if (File.Exists(fullpath))
            {
                File.AppendAllText(fullpath, pValue);
            }
            else
            {
                File.WriteAllText(fullpath, pValue);
            }
        }

        public List<DuLieu> getDuLieu(string pName, List<DuLieu> dsDuLieu)
        {
            List<DuLieu> ds = new List<DuLieu>();
            for(int i=0; i<dsDuLieu.Count; i++)
            {
                if(dsDuLieu[i].TenThietBi == pName)
                {
                    ds.Add(dsDuLieu[i]);
                }
            }
            return ds;
        }

        public List<string> getDacDiem1(string pName, List<DuLieu> dsDuLieu, int pDD)
        {
            List<string> ds = new List<string>();
            for(int i=0; i<dsDuLieu.Count; i++)
            {
                switch(pDD)
                {
                    case 1:
                        if (!ds.Any())
                        {
                            ds.Add(dsDuLieu[i].DacDiem1.Trim());
                        }
                        if (kiemTraListDacDiem1(ds, dsDuLieu[i].DacDiem1.Trim()))
                        {
                            ds.Add(dsDuLieu[i].DacDiem1.Trim());
                        }
                        break;
                    case 2:
                        if (!ds.Any())
                        {
                            ds.Add(dsDuLieu[i].DacDiem2.Trim());
                        }
                        if (kiemTraListDacDiem1(ds, dsDuLieu[i].DacDiem2.Trim()))
                        {
                            ds.Add(dsDuLieu[i].DacDiem2.Trim());
                        }
                        break;
                    case 3:
                        if (!ds.Any())
                        {
                            ds.Add(dsDuLieu[i].DacDiem3.Trim());
                        }
                        if (kiemTraListDacDiem1(ds, dsDuLieu[i].DacDiem3.Trim()))
                        {
                            ds.Add(dsDuLieu[i].DacDiem3.Trim());
                        }
                        break;
                    case 4:
                        if (!ds.Any())
                        {
                            ds.Add(dsDuLieu[i].DacDiem4.Trim());
                        }
                        if (kiemTraListDacDiem1(ds, dsDuLieu[i].DacDiem4.Trim()))
                        {
                            ds.Add(dsDuLieu[i].DacDiem4.Trim());
                        }
                        break;
                    case 5:
                        if (!ds.Any())
                        {
                            ds.Add(dsDuLieu[i].MaSP.Trim());
                        }
                        if (kiemTraListDacDiem1(ds, dsDuLieu[i].MaSP.Trim()))
                        {
                            ds.Add(dsDuLieu[i].MaSP.Trim());
                        }
                        break;
                }
                
            }

            return ds;
        }

        public bool kiemTraListDacDiem1(List<string> ds, string pTenDacDiem)
        {
            for (int i = 0; i < ds.Count; i++)
            {
                if(ds[i].Trim() == pTenDacDiem.Trim())
                {
                    return false;
                }
            }
            return true;
        }

        public List<string> layToanBoDong1DD(string pName, List<DuLieu> dsDuLieu, int pDD)
        {
            List<string> ds = new List<string>();
            for (int i = 0; i < dsDuLieu.Count; i++)
            {
                switch (pDD)
                {
                    case 1:
                        ds.Add(dsDuLieu[i].DacDiem1);
                        break;
                    case 2:
                        ds.Add(dsDuLieu[i].DacDiem2);
                        break;
                    case 3:
                        ds.Add(dsDuLieu[i].DacDiem3);
                        break;
                    case 4:
                        ds.Add(dsDuLieu[i].DacDiem4);
                        break;
                    case 5:
                        ds.Add(dsDuLieu[i].MaSP);
                        break;
                }

            }
            return ds;
        }

        
    }

    public class DuLieu
    {
        string tenThietBi, dacDiem1, dacDiem2, dacDiem3, dacDiem4, maSP;

        public string TenThietBi { get => tenThietBi; set => tenThietBi = value; }
        public string DacDiem1 { get => dacDiem1; set => dacDiem1 = value; }
        public string DacDiem2 { get => dacDiem2; set => dacDiem2 = value; }
        public string DacDiem3 { get => dacDiem3; set => dacDiem3 = value; }
        public string DacDiem4 { get => dacDiem4; set => dacDiem4 = value; }
        public string MaSP { get => maSP; set => maSP = value; }
    }

    public class TieuChi
    {
        string tenThietBi, tieuChi1, tieuChi2, tieuChi3, tieuChi4;

        public string TenThietBi { get => tenThietBi; set => tenThietBi = value; }
        public string TieuChi1 { get => tieuChi1; set => tieuChi1 = value; }
        public string TieuChi2 { get => tieuChi2; set => tieuChi2 = value; }
        public string TieuChi3 { get => tieuChi3; set => tieuChi3 = value; }
        public string TieuChi4 { get => tieuChi4; set => tieuChi4 = value; }
    }

    public class DuLieuTrain
    {
        string dacDiem1, dacDiem2, dacDiem3, dacDiem4, maSP;
        double xacSuat;

        public string DacDiem1 { get => dacDiem1; set => dacDiem1 = value; }
        public string DacDiem2 { get => dacDiem2; set => dacDiem2 = value; }
        public string DacDiem3 { get => dacDiem3; set => dacDiem3 = value; }
        public string DacDiem4 { get => dacDiem4; set => dacDiem4 = value; }
        public double XacSuat { get => xacSuat; set => xacSuat = value; }
        public string MaSP { get => maSP; set => maSP = value; }
    }
}
