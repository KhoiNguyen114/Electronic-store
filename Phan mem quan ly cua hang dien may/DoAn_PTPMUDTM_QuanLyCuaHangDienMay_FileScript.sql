USE [DOANPTPMUNGDUNGTHONGMINH_QUANLYCUAHANGDIENMAY]
GO
/****** Object:  Table [dbo].[BAOHANH]    Script Date: 7/31/2021 2:41:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BAOHANH](
	[MABH] [int] IDENTITY(1,1) NOT NULL,
	[MAHD] [int] NULL,
	[MAKH] [int] NULL,
	[MASP] [nvarchar](10) NULL,
	[NGAYBH] [date] NULL,
	[GHICHU] [nvarchar](max) NULL,
	[TINHTRANG] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[MABH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CHITIETHOADON]    Script Date: 7/31/2021 2:41:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETHOADON](
	[MAHD] [int] NOT NULL,
	[MASP] [nvarchar](10) NOT NULL,
	[SOLUONG] [int] NULL,
	[DONGIABAN] [float] NULL,
	[THANHTIEN] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MAHD] ASC,
	[MASP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CHITIETPHIEUNHAP]    Script Date: 7/31/2021 2:41:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETPHIEUNHAP](
	[MAPN] [int] NOT NULL,
	[MASP] [nvarchar](10) NOT NULL,
	[SOLUONG] [int] NULL,
	[DONGIANHAP] [float] NULL,
	[THANHTIEN] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MAPN] ASC,
	[MASP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CHUCVU]    Script Date: 7/31/2021 2:41:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHUCVU](
	[MACV] [nvarchar](10) NOT NULL,
	[TENCV] [nvarchar](100) NULL,
	[LUONGCB] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MACV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DIEMDANH]    Script Date: 7/31/2021 2:41:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DIEMDANH](
	[MANV] [nvarchar](10) NOT NULL,
	[NGAYDD] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MANV] ASC,
	[NGAYDD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 7/31/2021 2:41:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADON](
	[MAHD] [int] IDENTITY(1,1) NOT NULL,
	[MANV] [nvarchar](10) NULL,
	[MAKH] [int] NOT NULL,
	[NGAYLAPHD] [date] NULL,
	[TONGTIENHD] [float] NULL,
	[THANHTOAN] [float] NULL,
	[TINHTRANG] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MAHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 7/31/2021 2:41:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MAKH] [int] IDENTITY(1,1) NOT NULL,
	[TENKH] [nvarchar](500) NULL,
	[GIOITINH] [nvarchar](5) NULL,
	[NGAYSINH] [date] NULL,
	[SDT] [nvarchar](12) NULL,
	[DIACHI] [nvarchar](500) NULL,
	[TENDN] [nvarchar](50) NULL,
	[MATKHAU] [nvarchar](20) NULL,
	[MALOAIKH] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MAKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LOAIKHACHHANG]    Script Date: 7/31/2021 2:41:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAIKHACHHANG](
	[MALOAIKH] [nvarchar](10) NOT NULL,
	[TENLOAI] [nvarchar](500) NULL,
	[GIAMGIA] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MALOAIKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LOAITHIETBI]    Script Date: 7/31/2021 2:41:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAITHIETBI](
	[MATHIETBI] [nvarchar](10) NOT NULL,
	[TENTHIETBI] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[MATHIETBI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MANHINH]    Script Date: 7/31/2021 2:41:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MANHINH](
	[MAMH] [nvarchar](50) NOT NULL,
	[TENMH] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MAMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NGUOIDUNG]    Script Date: 7/31/2021 2:41:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NGUOIDUNG](
	[TENDN] [nvarchar](20) NOT NULL,
	[MATKHAU] [nvarchar](20) NULL,
	[MANV] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[TENDN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 7/31/2021 2:41:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MANV] [nvarchar](10) NOT NULL,
	[TENNV] [nvarchar](100) NULL,
	[GIOITINH] [nvarchar](5) NULL,
	[NGAYSINH] [date] NULL,
	[DIENTHOAI] [nvarchar](12) NULL,
	[DIACHI] [nvarchar](500) NULL,
	[MACV] [nvarchar](10) NOT NULL,
	[NGAYVL] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[MANV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NHASANXUAT]    Script Date: 7/31/2021 2:41:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHASANXUAT](
	[MANSX] [nvarchar](10) NOT NULL,
	[TENNSX] [nvarchar](500) NULL,
	[DIACHI] [nvarchar](500) NULL,
	[SDT] [nvarchar](12) NULL,
PRIMARY KEY CLUSTERED 
(
	[MANSX] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NHOMNGUOIDUNG]    Script Date: 7/31/2021 2:41:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHOMNGUOIDUNG](
	[MANHOM] [varchar](20) NOT NULL,
	[TENNHOM] [nvarchar](50) NULL,
	[GHICHU] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MANHOM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PHANQUYEN]    Script Date: 7/31/2021 2:41:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PHANQUYEN](
	[MANHOM] [varchar](20) NOT NULL,
	[MAMH] [nvarchar](50) NOT NULL,
	[COQUYEN] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MANHOM] ASC,
	[MAMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PHIEUNHAP]    Script Date: 7/31/2021 2:41:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUNHAP](
	[MAPN] [int] IDENTITY(1,1) NOT NULL,
	[MANV] [nvarchar](10) NULL,
	[MANSX] [nvarchar](10) NOT NULL,
	[NGAYLAPPN] [date] NULL,
	[TONGTIENPN] [float] NULL,
	[TINHTRANG] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MAPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QL_NGUOIDUNGNHOMNGUOIDUNG]    Script Date: 7/31/2021 2:41:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QL_NGUOIDUNGNHOMNGUOIDUNG](
	[TENDN] [nvarchar](20) NOT NULL,
	[MANHOM] [varchar](20) NOT NULL,
	[GHICHU] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[MANHOM] ASC,
	[TENDN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SANPHAM]    Script Date: 7/31/2021 2:41:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SANPHAM](
	[MASP] [nvarchar](10) NOT NULL,
	[TENSP] [nvarchar](500) NULL,
	[DONGIABAN] [float] NULL,
	[MOTA] [nvarchar](max) NULL,
	[SOLUONG] [int] NULL,
	[HINH] [nvarchar](500) NULL,
	[GIAMGIA] [float] NULL,
	[MANSX] [nvarchar](10) NULL,
	[MATHIETBI] [nvarchar](10) NULL,
	[TINHTRANG] [nvarchar](100) NULL,
	[THOIGIANBH] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MASP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[CHITIETHOADON] ([MAHD], [MASP], [SOLUONG], [DONGIABAN], [THANHTIEN]) VALUES (1, N'SP002', 1, 7590000, 7590000)
INSERT [dbo].[CHITIETHOADON] ([MAHD], [MASP], [SOLUONG], [DONGIABAN], [THANHTIEN]) VALUES (1, N'SP003', 2, 10590000, 21180000)
INSERT [dbo].[CHITIETHOADON] ([MAHD], [MASP], [SOLUONG], [DONGIABAN], [THANHTIEN]) VALUES (2, N'SP001', 1, 5790000, 5790000)
INSERT [dbo].[CHITIETHOADON] ([MAHD], [MASP], [SOLUONG], [DONGIABAN], [THANHTIEN]) VALUES (2, N'SP006', 1, 19590000, 19590000)
INSERT [dbo].[CHITIETHOADON] ([MAHD], [MASP], [SOLUONG], [DONGIABAN], [THANHTIEN]) VALUES (3, N'SP002', 1, 7590000, 7590000)
INSERT [dbo].[CHITIETHOADON] ([MAHD], [MASP], [SOLUONG], [DONGIABAN], [THANHTIEN]) VALUES (3, N'SP003', 2, 10590000, 21180000)
INSERT [dbo].[CHITIETHOADON] ([MAHD], [MASP], [SOLUONG], [DONGIABAN], [THANHTIEN]) VALUES (4, N'SP002', 1, 7590000, 7590000)
INSERT [dbo].[CHITIETHOADON] ([MAHD], [MASP], [SOLUONG], [DONGIABAN], [THANHTIEN]) VALUES (4, N'SP003', 2, 10590000, 21180000)
INSERT [dbo].[CHUCVU] ([MACV], [TENCV], [LUONGCB]) VALUES (N'CV001', N'Nhân viên thu ngân', 150000)
INSERT [dbo].[CHUCVU] ([MACV], [TENCV], [LUONGCB]) VALUES (N'CV002', N'Nhân viên vệ sinh', 200000)
INSERT [dbo].[CHUCVU] ([MACV], [TENCV], [LUONGCB]) VALUES (N'CV003', N'Quản lý', 350000)
INSERT [dbo].[DIEMDANH] ([MANV], [NGAYDD]) VALUES (N'NV001', CAST(N'2020-05-10' AS Date))
INSERT [dbo].[DIEMDANH] ([MANV], [NGAYDD]) VALUES (N'NV003', CAST(N'2020-05-11' AS Date))
INSERT [dbo].[DIEMDANH] ([MANV], [NGAYDD]) VALUES (N'NV004', CAST(N'2020-05-12' AS Date))
SET IDENTITY_INSERT [dbo].[HOADON] ON 

INSERT [dbo].[HOADON] ([MAHD], [MANV], [MAKH], [NGAYLAPHD], [TONGTIENHD], [THANHTOAN], [TINHTRANG]) VALUES (1, N'NV002', 1, CAST(N'2021-07-29' AS Date), 28770000, NULL, N'Có hiệu lực')
INSERT [dbo].[HOADON] ([MAHD], [MANV], [MAKH], [NGAYLAPHD], [TONGTIENHD], [THANHTOAN], [TINHTRANG]) VALUES (2, NULL, 1, CAST(N'2021-07-29' AS Date), 25380000, NULL, N'Hủy')
INSERT [dbo].[HOADON] ([MAHD], [MANV], [MAKH], [NGAYLAPHD], [TONGTIENHD], [THANHTOAN], [TINHTRANG]) VALUES (3, NULL, 1, CAST(N'2021-07-31' AS Date), 28770000, NULL, N'Chờ xác nhận')
INSERT [dbo].[HOADON] ([MAHD], [MANV], [MAKH], [NGAYLAPHD], [TONGTIENHD], [THANHTOAN], [TINHTRANG]) VALUES (4, NULL, 1, CAST(N'2021-07-31' AS Date), 28770000, NULL, N'Chờ xác nhận')
SET IDENTITY_INSERT [dbo].[HOADON] OFF
SET IDENTITY_INSERT [dbo].[KHACHHANG] ON 

INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [GIOITINH], [NGAYSINH], [SDT], [DIACHI], [TENDN], [MATKHAU], [MALOAIKH]) VALUES (1, N'Nguyễn Huy Khôi Nguyên', N'Nam', CAST(N'2000-10-25' AS Date), N'0927551446', N'140 Lê Trọng Tấn, Phường Tây Thạnh, Quận Tân Phú, TP.HCM', N'Nguyen123', N'123', N'LKH001')
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [GIOITINH], [NGAYSINH], [SDT], [DIACHI], [TENDN], [MATKHAU], [MALOAIKH]) VALUES (2, N'Khương Tử Nha', N'Nam', CAST(N'1992-06-04' AS Date), N'076854112', N'77/2 Lê Hồng Phong, Phường Phú Tân, Bà Rịa - Vũng Tàu', N'Nha123', N'123', N'LKH002')
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [GIOITINH], [NGAYSINH], [SDT], [DIACHI], [TENDN], [MATKHAU], [MALOAIKH]) VALUES (3, N'Cô Cô', N'Nữ', CAST(N'1979-03-17' AS Date), N'088756147', N'156/2/22 Đặng Thúc Kháng, Phường Thạnh Xuân, Bình Thuận', N'CoCo', N'123', N'LKH003')
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [GIOITINH], [NGAYSINH], [SDT], [DIACHI], [TENDN], [MATKHAU], [MALOAIKH]) VALUES (4, N'Đinh Công Mạnh', N'Nam', CAST(N'1999-05-28' AS Date), N'096554872', N'201 Lê Đại Hành, Phường Tinh Thế, Quận Bình Thạnh, TPHCM', N'Manh123', N'123', N'LKH002')
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [GIOITINH], [NGAYSINH], [SDT], [DIACHI], [TENDN], [MATKHAU], [MALOAIKH]) VALUES (5, N'Lưu Bị', N'Nam', CAST(N'1994-06-27' AS Date), N'0946385742', N'422 Tây Thạnh, Tân Phú, TPHCM', N'LuuBi123', N'123', N'LKH003')
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [GIOITINH], [NGAYSINH], [SDT], [DIACHI], [TENDN], [MATKHAU], [MALOAIKH]) VALUES (6, N'Quan Vũ', N'Nam', CAST(N'1991-10-08' AS Date), N'0757482345', N'249 Nguyễn Thị Minh Khai, Quận 1, TPHCM', N'QuanVu123', N'123', N'LKH001')
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [GIOITINH], [NGAYSINH], [SDT], [DIACHI], [TENDN], [MATKHAU], [MALOAIKH]) VALUES (7, N'Đại Kiều', N'Nữ', CAST(N'1985-02-28' AS Date), N'0912759230', N'792 Phạm Văn Chiêu,Gò Vấp, TPHCM', N'DaiKieu123', N'123', N'LKH001')
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [GIOITINH], [NGAYSINH], [SDT], [DIACHI], [TENDN], [MATKHAU], [MALOAIKH]) VALUES (8, N'Mã Siêu', N'Nam', CAST(N'1998-09-18' AS Date), N'0944781450', N'192 Nam Kì Khởi Nghĩa,Quận 9, TPHCM', N'MaSieu123', N'123', N'LKH002')
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [GIOITINH], [NGAYSINH], [SDT], [DIACHI], [TENDN], [MATKHAU], [MALOAIKH]) VALUES (9, N'Điêu Thuyền', N'Nữ', CAST(N'1988-01-12' AS Date), N'0955887142', N'225 Lê Đức Thọ, Gò Vấp, TPHCM', N'DieuThuyen123', N'123', N'LKH001')
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [GIOITINH], [NGAYSINH], [SDT], [DIACHI], [TENDN], [MATKHAU], [MALOAIKH]) VALUES (10, N'Tôn Thượng Hương', N'Nữ', CAST(N'2000-10-02' AS Date), N'0908124751', N'140 Lê Trọng Tấn ,Tân Phú, TP.HCM', N'Huong123', N'123', N'LKH003')
SET IDENTITY_INSERT [dbo].[KHACHHANG] OFF
INSERT [dbo].[LOAIKHACHHANG] ([MALOAIKH], [TENLOAI], [GIAMGIA]) VALUES (N'LKH001', N'Vãng lai', 0)
INSERT [dbo].[LOAIKHACHHANG] ([MALOAIKH], [TENLOAI], [GIAMGIA]) VALUES (N'LKH002', N'Thân thiết', 5)
INSERT [dbo].[LOAIKHACHHANG] ([MALOAIKH], [TENLOAI], [GIAMGIA]) VALUES (N'LKH003', N'VIP', 10)
INSERT [dbo].[LOAITHIETBI] ([MATHIETBI], [TENTHIETBI]) VALUES (N'L001', N'Tủ lạnh')
INSERT [dbo].[LOAITHIETBI] ([MATHIETBI], [TENTHIETBI]) VALUES (N'L002', N'Máy giặt')
INSERT [dbo].[LOAITHIETBI] ([MATHIETBI], [TENTHIETBI]) VALUES (N'L003', N'Máy sấy')
INSERT [dbo].[LOAITHIETBI] ([MATHIETBI], [TENTHIETBI]) VALUES (N'L004', N'Tủ đông')
INSERT [dbo].[LOAITHIETBI] ([MATHIETBI], [TENTHIETBI]) VALUES (N'L005', N'Máy lạnh')
INSERT [dbo].[LOAITHIETBI] ([MATHIETBI], [TENTHIETBI]) VALUES (N'L006', N'Loa')
INSERT [dbo].[LOAITHIETBI] ([MATHIETBI], [TENTHIETBI]) VALUES (N'L007', N'Bếp từ')
INSERT [dbo].[LOAITHIETBI] ([MATHIETBI], [TENTHIETBI]) VALUES (N'L008', N'Máy lọc nước')
INSERT [dbo].[LOAITHIETBI] ([MATHIETBI], [TENTHIETBI]) VALUES (N'L009', N'Máy nước nóng')
INSERT [dbo].[LOAITHIETBI] ([MATHIETBI], [TENTHIETBI]) VALUES (N'L010', N'Tivi')
INSERT [dbo].[MANHINH] ([MAMH], [TENMH]) VALUES (N'MH001', N'Tạo tài khoản')
INSERT [dbo].[MANHINH] ([MAMH], [TENMH]) VALUES (N'MH002', N'Đổi mật khẩu')
INSERT [dbo].[MANHINH] ([MAMH], [TENMH]) VALUES (N'MH003', N'Điểm danh')
INSERT [dbo].[MANHINH] ([MAMH], [TENMH]) VALUES (N'MH004', N'Cấp quyền')
INSERT [dbo].[MANHINH] ([MAMH], [TENMH]) VALUES (N'MH005', N'Loại khách hàng')
INSERT [dbo].[MANHINH] ([MAMH], [TENMH]) VALUES (N'MH006', N'Khách hàng')
INSERT [dbo].[MANHINH] ([MAMH], [TENMH]) VALUES (N'MH007', N'Nhân viên')
INSERT [dbo].[MANHINH] ([MAMH], [TENMH]) VALUES (N'MH008', N'Nhà sản xuất')
INSERT [dbo].[MANHINH] ([MAMH], [TENMH]) VALUES (N'MH009', N'Loại thiết bị')
INSERT [dbo].[MANHINH] ([MAMH], [TENMH]) VALUES (N'MH010', N'Sản phẩm')
INSERT [dbo].[MANHINH] ([MAMH], [TENMH]) VALUES (N'MH011', N'Chức vụ')
INSERT [dbo].[MANHINH] ([MAMH], [TENMH]) VALUES (N'MH012', N'Nhập hàng')
INSERT [dbo].[MANHINH] ([MAMH], [TENMH]) VALUES (N'MH013', N'Thanh toán')
INSERT [dbo].[MANHINH] ([MAMH], [TENMH]) VALUES (N'MH014', N'Bảo hành')
INSERT [dbo].[MANHINH] ([MAMH], [TENMH]) VALUES (N'MH015', N'Xem hóa đơn/phiếu nhập')
INSERT [dbo].[MANHINH] ([MAMH], [TENMH]) VALUES (N'MH016', N'Tư vấn khách hàng')
INSERT [dbo].[MANHINH] ([MAMH], [TENMH]) VALUES (N'MH017', N'Phiếu nhập')
INSERT [dbo].[MANHINH] ([MAMH], [TENMH]) VALUES (N'MH018', N'Doanh thu')
INSERT [dbo].[MANHINH] ([MAMH], [TENMH]) VALUES (N'MH019', N'Lương nhân viên')
INSERT [dbo].[NGUOIDUNG] ([TENDN], [MATKHAU], [MANV]) VALUES (N'admin111', N'123', N'NV002')
INSERT [dbo].[NGUOIDUNG] ([TENDN], [MATKHAU], [MANV]) VALUES (N'nhanvien112', N'123', N'NV001')
INSERT [dbo].[NGUOIDUNG] ([TENDN], [MATKHAU], [MANV]) VALUES (N'nhanvien12', N'123', N'NV005')
INSERT [dbo].[NHANVIEN] ([MANV], [TENNV], [GIOITINH], [NGAYSINH], [DIENTHOAI], [DIACHI], [MACV], [NGAYVL]) VALUES (N'NV001', N'Minh Hưng', N'Nam', CAST(N'2000-06-09' AS Date), N'0909672332', N'38/5 Nguyễn Đình Chiểu, Phường Linh Tân, Quận Thủ Đức, TP.HCM', N'CV001', CAST(N'2021-05-12' AS Date))
INSERT [dbo].[NHANVIEN] ([MANV], [TENNV], [GIOITINH], [NGAYSINH], [DIENTHOAI], [DIACHI], [MACV], [NGAYVL]) VALUES (N'NV002', N'Khôi Nguyên', N'Nam', CAST(N'2000-02-05' AS Date), N'0912345678', N'176/2 Trần Văn Cơ, Phường Đông Thị Ngâu, Quận Bình Tân, TP.HCM', N'CV003', CAST(N'2021-05-12' AS Date))
INSERT [dbo].[NHANVIEN] ([MANV], [TENNV], [GIOITINH], [NGAYSINH], [DIENTHOAI], [DIACHI], [MACV], [NGAYVL]) VALUES (N'NV003', N'Bảo Toàn', N'Nam', CAST(N'2000-10-26' AS Date), N'0309328723', N'225 Trần Bàng, Phường 7, Huyện Tân Thành, Tiền Giang', N'CV002', CAST(N'2021-05-12' AS Date))
INSERT [dbo].[NHANVIEN] ([MANV], [TENNV], [GIOITINH], [NGAYSINH], [DIENTHOAI], [DIACHI], [MACV], [NGAYVL]) VALUES (N'NV004', N'Phương Linh', N'Nữ', CAST(N'1999-06-05' AS Date), N'0390764398', N'111/4 Lê Trọng Tấn, Phường Tây Thạnh, Quận Tân Phú, TP.HCM', N'CV002', CAST(N'2021-05-12' AS Date))
INSERT [dbo].[NHANVIEN] ([MANV], [TENNV], [GIOITINH], [NGAYSINH], [DIENTHOAI], [DIACHI], [MACV], [NGAYVL]) VALUES (N'NV005', N'Phương Hoài', N'Nữ', CAST(N'2000-06-11' AS Date), N'095639182', N'715 Phan Xích Long, Phường 11, Quận Bình Thạnh, TP.HCM', N'CV001', CAST(N'2021-05-12' AS Date))
INSERT [dbo].[NHANVIEN] ([MANV], [TENNV], [GIOITINH], [NGAYSINH], [DIENTHOAI], [DIACHI], [MACV], [NGAYVL]) VALUES (N'NV006', N'Hoài Thương', N'Nữ', CAST(N'2001-09-02' AS Date), N'0908274638', N'124 Phan Xích Long, Phường 11, Quận Bình Thạnh, TP.HCM', N'CV001', CAST(N'2021-05-12' AS Date))
INSERT [dbo].[NHANVIEN] ([MANV], [TENNV], [GIOITINH], [NGAYSINH], [DIENTHOAI], [DIACHI], [MACV], [NGAYVL]) VALUES (N'NV007', N'Phương Thảo', N'Nữ', CAST(N'1996-04-24' AS Date), N'0902472195', N'881 Sơn Kì, Tân Phú, TP.HCM', N'CV002', CAST(N'2021-05-12' AS Date))
INSERT [dbo].[NHANVIEN] ([MANV], [TENNV], [GIOITINH], [NGAYSINH], [DIENTHOAI], [DIACHI], [MACV], [NGAYVL]) VALUES (N'NV008', N'Phương Hằng', N'Nữ', CAST(N'1999-01-31' AS Date), N'0956239815', N'258 Nguyễn Xí, Quận Bình Thạnh, TP.HCM', N'CV001', CAST(N'2021-05-12' AS Date))
INSERT [dbo].[NHANVIEN] ([MANV], [TENNV], [GIOITINH], [NGAYSINH], [DIENTHOAI], [DIACHI], [MACV], [NGAYVL]) VALUES (N'NV009', N'Phương Tuấn', N'Nam', CAST(N'2000-12-04' AS Date), N'0912053961', N'625 Phan Huy Ích,Tân Bình, TP.HCM', N'CV002', CAST(N'2021-05-12' AS Date))
INSERT [dbo].[NHANVIEN] ([MANV], [TENNV], [GIOITINH], [NGAYSINH], [DIENTHOAI], [DIACHI], [MACV], [NGAYVL]) VALUES (N'NV010', N'Phương Nam', N'Nam', CAST(N'1997-09-15' AS Date), N'0919461297', N'827 Trần Quang Khải, Quận 10, TP.HCM', N'CV002', CAST(N'2021-05-12' AS Date))
INSERT [dbo].[NHASANXUAT] ([MANSX], [TENNSX], [DIACHI], [SDT]) VALUES (N'NSX001', N'Toshiba', N'Số 12, Đường 15, Khu phố 4, Phường Linh Trung, Quận Thủ Đức, Tp. Hồ Chí Minh', N'0982177226')
INSERT [dbo].[NHASANXUAT] ([MANSX], [TENNSX], [DIACHI], [SDT]) VALUES (N'NSX002', N'LG', N'Lô CN2, KCN Tràng Duệ, xã Lê Lợi, huyện An Dương, thành phố Hải Phòng', N'099928162')
INSERT [dbo].[NHASANXUAT] ([MANSX], [TENNSX], [DIACHI], [SDT]) VALUES (N'NSX003', N'Panasonic', N'Lô J1-J2, Khu công nghiệp Thăng Long, xã Kim Chung, huyện Đông Anh, Tp. Hà Nội', N'02437677360')
INSERT [dbo].[NHASANXUAT] ([MANSX], [TENNSX], [DIACHI], [SDT]) VALUES (N'NSX004', N'Daikin', N'201-203 Cách Mạng Tháng Tám, Phường 4, Quận 3, Thành phố Hồ Chí Minh', N'0785429717')
INSERT [dbo].[NHASANXUAT] ([MANSX], [TENNSX], [DIACHI], [SDT]) VALUES (N'NSX005', N'Sony', N'163 Quang Trung, Phường 10, Gò Vấp, Thành phố Hồ Chí Minh', N'0909636798')
INSERT [dbo].[NHASANXUAT] ([MANSX], [TENNSX], [DIACHI], [SDT]) VALUES (N'NSX006', N'SamSung', N'Số 2, đường Hải Triều, Phường Bến Nghé, Quận 1, TP. Hồ Chí Minh', N'02839157310')
INSERT [dbo].[NHASANXUAT] ([MANSX], [TENNSX], [DIACHI], [SDT]) VALUES (N'NSX007', N'Sunhouse', N'Số 85, đường Phạm Ngũ Lão, Phường Bến Nghé, Quận 1, TP. Hồ Chí Minh', N'0932055472')
INSERT [dbo].[NHASANXUAT] ([MANSX], [TENNSX], [DIACHI], [SDT]) VALUES (N'NSX008', N'Kangaroo', N'Số 108, đường Cống Quỳnh, Phường Bến Nghé, Quận 1, TP. Hồ Chí Minh', N'0904421875')
INSERT [dbo].[NHOMNGUOIDUNG] ([MANHOM], [TENNHOM], [GHICHU]) VALUES (N'admin', N'Quản Lý', NULL)
INSERT [dbo].[NHOMNGUOIDUNG] ([MANHOM], [TENNHOM], [GHICHU]) VALUES (N'NV', N'Nhân Viên', NULL)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAMH], [COQUYEN]) VALUES (N'NV', N'MH001', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAMH], [COQUYEN]) VALUES (N'NV', N'MH002', 1)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAMH], [COQUYEN]) VALUES (N'NV', N'MH003', 1)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAMH], [COQUYEN]) VALUES (N'NV', N'MH004', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAMH], [COQUYEN]) VALUES (N'NV', N'MH005', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAMH], [COQUYEN]) VALUES (N'NV', N'MH006', 1)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAMH], [COQUYEN]) VALUES (N'NV', N'MH007', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAMH], [COQUYEN]) VALUES (N'NV', N'MH008', 1)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAMH], [COQUYEN]) VALUES (N'NV', N'MH009', 1)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAMH], [COQUYEN]) VALUES (N'NV', N'MH010', 1)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAMH], [COQUYEN]) VALUES (N'NV', N'MH011', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAMH], [COQUYEN]) VALUES (N'NV', N'MH012', 1)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAMH], [COQUYEN]) VALUES (N'NV', N'MH013', 1)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAMH], [COQUYEN]) VALUES (N'NV', N'MH014', 1)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAMH], [COQUYEN]) VALUES (N'NV', N'MH015', 1)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAMH], [COQUYEN]) VALUES (N'NV', N'MH016', 1)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAMH], [COQUYEN]) VALUES (N'NV', N'MH017', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAMH], [COQUYEN]) VALUES (N'NV', N'MH018', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAMH], [COQUYEN]) VALUES (N'NV', N'MH019', 0)
INSERT [dbo].[QL_NGUOIDUNGNHOMNGUOIDUNG] ([TENDN], [MANHOM], [GHICHU]) VALUES (N'admin111', N'admin', NULL)
INSERT [dbo].[QL_NGUOIDUNGNHOMNGUOIDUNG] ([TENDN], [MANHOM], [GHICHU]) VALUES (N'nhanvien112', N'NV', NULL)
INSERT [dbo].[QL_NGUOIDUNGNHOMNGUOIDUNG] ([TENDN], [MANHOM], [GHICHU]) VALUES (N'nhanvien12', N'NV', NULL)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP001', N'Smart Tivi Sony 32 inch KDL-32W600D', 6090000, N'Công nghệ 4K X-Reality Pro cho màu sắc rõ nét, tăng cường độ nét hình ảnh, nâng cấp chất lượng hình ảnh gần HD nhất. Công nghệ Advanced Contrast Enhancer nâng cao tương phản. Công nghệ Dolby Digital và Clear Phase cho âm thanh bùng nổ và mạnh mẽ. Giao diện tiếng Việt dễ sử dụng với nhiều ứng dụng giải trí như: Netflix, Youtube, Nhaccuatui, Zing TV, FPT Play, Clip TV, Zing MP3, Trình duyệt web. Tivi độ phân giải HD cho hình ảnh sắc nét chân thực.', 15, N'KDL-32W600D.jpg', 5790000, N'NSX005', N'L010', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP002', N'Smart Tivi Samsung 43 inch UA43T6500', 7900000, N'Thiết kế sang trọng, trang nhã với độ mỏng tối ưu cùng độ phân giải Full HD. Dải màu sắc phong phú kiến tạo hình ảnh sống động nổi bật từ công nghệ HDR. Quét ảnh tăng cường độ sắc nét cho trải nghiệm trung thực với công nghệ Digital Clean View. Khung hình trở nên sống động và chân thực nhờ công nghệ PurColor. Nâng cấp độ tương phản qua công nghệ Contrast Enhancer. Âm thanh trong trẻo với công nghệ âm thanh Dolby Digital Plus. Hệ điều hành Tizen OS có giao diện phẳng, dễ sử dụng.', 16, N'UA43T6500-1.jpg', 7590000, N'NSX006', N'L010', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP003', N'Smart Tivi Samsung 4K 50 inch UA50TU8100', 11500000, N'Kích thước tivi 50 inch, hiện đại, tinh tế với màn hình không viền 3 cạnh. Hình ảnh sắc nét, độ tương phản với độ phân giải Ultra HD 4K  và công nghệ HDR10+. Màu sắc sống động như thực qua công nghệ Crystal Display và công nghệ UHD Dimming. Nâng cấp hình ảnh có chất lượng thấp lên gần chuẩn 4K với bộ xử lý Crystal 4K. Hệ điều hành Tizen OS có giao diện đơn giản và kho ứng dụng đa dạng. Điều khiển tivi thông minh bằng điện thoại qua ứng dụng SmartThings. Trình chiếu màn hình điện thoại lên tivi nhanh chóng qua tính năng Tap View và Airplay 2.', 21, N'UA50TU8100-3.jpg', 10590000, N'NSX006', N'L010', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP004', N'Android Tivi Sony 4K 49 inch KD-49X8000H', 15900000, N'Thiết kế sang trọng, chân đế bằng kim loại, kích thước tivi 49 inch, độ phân giải Ultra HD 4K. Giảm nhiễu hình ảnh, màu sắc và độ tương phản được tăng cường nhờ bộ xử lí chip X1 4K HDR Processor. Dải màu rộng hơn, hình ảnh hiển thị tự nhiên và chính xác nhờ công nghệ TRILUMINOS Display. Dải tương phản động và dải sắc màu hiển thị mở rộng nhờ công nghệ Dolby Vision. Âm thanh đa chiều mạnh mẽ nhờ công nghệ âm thanh Dolby Atmos. Dễ dàng điều khiển tivi bằng điện thoại với ứng dụng Android TV. Chia sẻ nội dung trên màn hình điện thoại lên tivi nhờ Apple Homekit/Apple Airplay.', 30, N'KD-49X8000H.jpg', NULL, N'NSX005', N'L010', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP005', N'Android Tivi Sony 4K 65 inch KD-65X7500H', 22900000, N'Thiết kế tinh tế, chân đế hình chữ V vững chắc, kích thước tivi 65 inch, độ phân giải Ultra HD 4K. Tăng cường màu sắc, độ tương phản và độ nét cho hình ảnh nhờ bộ xử lí chip X1 4K Processor. Dải màu rộng hơn cho hình ảnh hiển thị tự nhiên và chính xác nhờ công nghệ TRILUMINOS Display. Tăng cường độ tương phản hình ảnh, màu trắng được trắng hơn, màu đen sâu hơn nhờ công nghệ HDR10. Thời gian sử dụng và trải nghiệm bền bỉ hơn nhờ X-Protection PRO. Cải thiện âm trầm rõ mạnh, âm cao được trong hơn nhờ loa Bass Reflex Speaker.Chiếu màn hình điện thoại lên tivi bằng Chromecast. Chiếu màn hình điện thoại lên tivi bằng Chromecast.', 10, N'KD-65X7500H.jpg', 21990000, N'NSX005', N'L010', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP006', N'Smart Tivi NanoCell LG 4K 55 inch 55NANO86TNA', 20590000, N'Kích thước 55 inch cùng độ phân giải 4K giúp hình ảnh rõ ràng, sắc nét.. Góc nhìn rộng với màu sắc hình ảnh tinh khiết dưới mọi góc nhìn với tấm nền IPS và NanoCell. Tối ưu chất lượng hình ảnh với chip xử lý α7 Gen 3 và công nghệ 4K Upscaler. Tăng cường độ sáng và độ tương phản, giúp hình ảnh rực rỡ với công nghệ HDR10+ và HLG. Đắm chìm trong thế giới âm thanh với công nghệ Ultra Surround. Điều khiển tivi bằng điện thoại với ứng dụng LG TV Plus. Chiếu màn hình điện thoại Android, iPhone lên tivi qua tính năng AirPlay 2 và Screen Mirroring. ', 16, N'55NANO86TNA.jpg', 19590000, N'NSX002', N'L010', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP007', N'Smart Tivi Màn Hình Xoay The Sero QLED Samsung 4K 43 inch QA43LS05T', 28900000, N'Thiết kế xoay thời thượng, di chuyển dễ dàng với bánh xe, màn hình 43 inch, độ phân giải 4K. Nâng cấp hình ảnh lên gần chuẩn 4K với bộ xử lý Quantum 4K và trí tuệ nhân tạo Al. Truyền tải trọn vẹn 100% dải màu với công nghệ màn hình chấm lượng tử Quantum Dot. Độ sáng vượt trội, hình ảnh hiển thị đẹp hơn với công nghệ Quantum HDR. Tối ưu độ chi tiết cho hình ảnh với công nghệ Supreme UHD Dimming. Hệ thống âm thanh đa chiều mạnh mẽ với công nghệ Dolby Digital Plus, công suất 60 W và 4.1 kênh. Công nghệ AVA điều chỉnh âm lượng hội thoại theo điều kiện môi trường xung quanh.', 32, N'QA43LS05T.jpg', NULL, N'NSX006', N'L010', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP008', N'Smart Tivi OLED LG 8K 88 inch 88ZXPTA', 690000000, N'Trải nghiệm sức mạnh của điểm ảnh OLED tự phát sáng với tuyệt tác thiết kế độc đáo, sang trọng. Hình ảnh hiển thị siêu sắc nét đến từng chi tiết nhờ sức mạnh của độ phân giải 8K và màn hình 88 inch. Nâng cấp trải nghiệm thưởng thức tivi của bạn bằng bộ xử lý thông minh α9 AI 8K thế hệ thứ 3. Tiện lợi, tiết kiệm thời gian khi điều khiển các thiết bị bằng giọng nói với AI ThinQ ngay trên tivi. Tận hưởng các bộ phim điện ảnh một cách chân thực và đúng chất nhất với các công nghệ Dolby Vision, Dolby Atmos, Filmmaker Mode. Tiện dụng và khám phá đa dạng thể loại giải trí với hệ điều hành WebOS. Trải nghiệm chơi game với tiêu chuẩn được nâng cao nhờ tương thích G-Sync. Điều khiển tivi dễ dàng bằng điện thoại cùng ứng dụng LG TV Plus, hỗ trợ nhiều cổng kết nối quen thuộc.', 5, N'88ZXPTA.jpg', 550000000, N'NSX002', N'L010', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP009', N'Android Tivi OLED Sony 4K 65 inch KD-65A9G', 69900000, N'Màn hình OLED, 65 inch với viền cực mỏng chỉ 0.2 cm, độ dầy phần mỏng nhất tivi chỉ 0,6 cm. Độ phân giải 4K nét gấp 4 lần Full HD, đi kèm công nghệ HDR tăng độ tương phản. Tăng dải màu rộng hơn 50% so với màn hình LCD qua công nghệ màn hình chấm lượng tử TRILUMINOS. Âm thanh phát ra từ màn hình qua Acoustic Surface có hỗ trợ 2 loa subwoofer. Hệ điều hành Android 8.0 của Google kho ứng dụng phong phú, đi kèm remote thông minh hỗ trợ tìm kiếm và điều khiển bằng giọng nói bằng tiếng Việt cả 3 miền nhờ có hỗ trợ Google Assistant. Điều khiển tivi bằng điện thoại qua ứng dụng TV Sideview. Hỗ trợ chiếu màn hình điện thoại Android và iOS lên tivi qua Screen Mirroring.', 5, N'KD-65A9G.jpg', 6900000, N'NSX005', N'L010', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP010', N'Smart Tivi Samsung 43 inch UA43R6000', 7450000, N'Thiết kế nhỏ gọn đi cùng với màn hình 43 inch. Độ phân giải Full HD rõ nét gấp 2 lần so với độ phân giải HD. Màu sắc sống động với công nghệ PurColor. Hình ảnh có độ tương phản cao với công nghệ Micro Dimming Pro', 10, N'hinh1.jpg', 8690000, N'NSX006', N'L010', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP011', N'Tủ lạnh Panasonic Inverter 268 lít NR-BL300PKVN', 10490000, N'Công nghệ Inverter cho khả năng vận hành êm ái, nhiệt độ ổn định. Cảm biến Econavi hiện đại, góp phần tiết kiệm đáng kể chi phí điện hàng tháng. Công nghệ làm lạnh Panorama với luồng khí lạnh vòng cung lan tỏa đồng đều đến mọi nơi trong tủ', 6, N'hinh2.jpg', NULL, N'NSX003', N'L001', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP012', N'Tủ lạnh Toshiba Inverter 180 lít GR-B22VU UKG', 5690000, N'Tiết kiệm điện, tủ êm ái với công nghệ biến tần Inverter. Làm lạnh thực phẩm toàn diện nhờ hệ thống khí lạnh vòng cung. Diệt khuẩn và khử mùi hiệu quả nhờ công nghệ Ag+ Bio. Bảo quản thịt cá tươi ngon, ăn trong ngày không cần rã đông với ngăn đông mềm -1 độ Ultra Cooling Zone. Cửa tủ phủ sơn bóng sáng đẹp.', 10, N'GR-B22VU UKG.jpg', NULL, N'NSX001', N'L001', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP013', N'Tủ lạnh LG Inverter 187 lít GN-L205S', 4920000, N'Công nghệ biến tần Inverter giúp tiết kiệm điện, máy chạy êm, bền. Hệ thống khí lạnh đa chiều giúp thực phẩm tươi ngon. Ngăn rau quả giúp cân bằng độ ẩm.', 20, N'GN-L205S.jpg', 3920000, N'NSX002', N'L001', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP014', N'Tủ lạnh Panasonic Inverter 152 lít NR-BA178PKV1', 5890000, N'Công nghệ làm lạnh Panorama độc quyền Panasonic giúp thực phẩm luôn tươi ngon. Công nghệ kháng khuẩn khử mùi bằng tinh thể bạc tiêu diệt vi khuẩn và mùi hôi khó chịu. Tủ lạnh tiết kiệm điện năng hiệu quả với công nghệ Inverter kết hợp cảm biến Econavi. Hộc rau quả cung cấp độ ẩm cho rau quả tươi lâu trong thời gian dài.', 15, N'NR-BA178PKV1.jpg', 4710000, N'NSX003', N'L001', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP015', N'Tủ lạnh Samsung Inverter 307 lít RB30N4170BUSV', 15790000, N'Tiết kiệm điện năng tiêu thụ với công nghệ Digital Inverter. Hơi lạnh lan toả đều khắp với công nghệ làm lạnh dạng vòm. Lọc sạch không khí, ngăn ngừa mùi hôi khó chịu với bộ lọc khử mùi than hoạt tính. Bảo quản thịt cá tươi ngon, ăn trong ngày không cần rã đông với ngăn đông mềm -1 độ C Optimal Fresh Zone. Tiện lợi hơn với khay lấy nước bên ngoài và hộp đá xoay di động. Thiết kế hiện đại cùng dung tích 307 lít phù hợp với gia đình có từ 3 đến 4 thành viên.', 30, N'RB30N4170BUSV.jpg', 13390000, N'NSX006', N'L001', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP016', N'Tủ lạnh Panasonic Inverter 290 lít NR-BV320GKVN', 15590000, N'Bảo quản thịt cá không cần rã đông, diệt khuẩn 99,99% với Ngăn đông mềm kháng khuẩn Prime Fresh+ thế hệ mới. Tiết kiệm điện tối đa với bộ 3 công nghệ Inverter, Mutlti Control và cảm biến thông minh Econavi. Giữ ẩm rau quả tươi ngon với ngăn Fresh Safe. Làm lạnh đồng đều các ngăn tủ với công nghệ Panorama. Diệt khuẩn, đánh bay mùi nhờ công nghệ Ag Clean với tinh thể bạc Ag+.', 30, N'NR-BV320GKVN.jpg', NULL, N'NSX003', N'L001', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP017', N'Tủ lạnh Toshiba Inverter 511 lít GR-RF610WE-PGV(22)-XK', 25990000, N'Sử dụng tiết kiệm điện, vận hành êm ái, đồng bộ nhờ công nghệ Origin Inverter. Giữ nhiệt tối ưu, bảo quản thực phẩm tươi ngon nhờ tấm hợp kim công nghệ AlloyCooling. Kháng khuẩn, khử mùi hoàn hảo cùng công nghệ PureBio với tia Plasma cực mạnh. Thay đổi chế độ bảo quản thực phẩm linh hoạt với ngăn cấp đông Flexible Zone. Tăng cường hơi ẩm, giữ rau củ tươi lâu trong ngăn Moisture Zone.', 12, N'GR-RF610WE-PGV(22)-XK.jpg', NULL, N'NSX001', N'L001', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP018', N'Tủ lạnh LG Inverter 613 lít GR-B247WB', 22990000, N'Tiết kiệm điện hiệu quả đến 32%, làm lạnh ổn định nhờ công nghệ mới Linear Inverter. Phân bổ đều hơi lạnh đến mọi ngách bên trong tủ bởi công nghệ làm lạnh đa chiều. Kháng khuẩn và khử mùi hôi hiệu quả cùng bộ lọc Nano Carbon. Bảo quản rau quả tươi lâu trong ngăn rau củ cân bằng độ ẩm có kích thước lớn. Tiện ích với chức năng chuẩn đoán lỗi thông minh Smart Diagnosis.', 34, N'GR-B247WB.jpg', 19990000, N'NSX002', N'L001', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP019', N'Tủ lạnh Panasonic Inverter 589 lít NR-F603GT-X2', 70990000, N'Tiết kiệm điện năng, vận hành ổn định nhờ công nghệ Inverter. Tự điều chỉnh công suất hoạt động phù hợp nhờ cảm biến Econavi thông minh. Tiêu diệt và loại bỏ vi khuẩn gây mùi với công nghệ khử mùi kháng khuẩn Nanoe-X. Tiết kiệm thời gian nấu nướng với ngăn cấp đông mềm Prime Fresh - 3 độ C. Luồng khí lạnh lan tan tỏa đồng đều, hiệu quả nhờ công nghệ Panorama. Tăng cường hiệu quả kháng khuẩn, khử mùi nhờ công nghệ kháng khuẩn Ag Clean với tinh thể bạc Ag+. Giữ trọn độ tươi ngon nhờ ngăn rau củ kích thước lớn kết hợp với bộ lọc kiểm soát độ ẩm. Đá lạnh luôn sẵn sàng với hệ thống làm đá tự động.', 6, N'NR-F603GT-X2.jpg', NULL, N'NSX003', N'L001', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP020', N'Tủ lạnh Samsung Inverter 564 lít RF56K9041SGSV', 59900000, N'Công nghệ Digital Inverter giúp tiết kiệm điện tối ưu. Thiết kế 4 cửa sang trọng, đẹp mắt tạo không gian sâu hài hòa với tổng thể nội thất. 3 dàn lạnh độc lập giữ thực phẩm tươi lâu, trọn vị và không bị lẫn mùi. Ngăn chuyển đổi nhiệt độ cho phép người dùng tùy chỉnh linh hoạt. FreshZone giúp giữ độ tươi ngay cả khi mở cửa tủ lạnh thường xuyên. Tiện lợi hơn với khả năng tự làm đá giúp bạn tiết kiệm thời gian và tiết kiệm điện.', 1, N'RF56K9041SGSV.jpg', 56900000, N'NSX006', N'L001', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP021', N'Máy giặt LG Inverter 8.5 kg FV1408S4W', 11490000, N'Vận hành êm, giảm thiểu hư tổn sợi vải nhờ công nghệ 6 chuyển động DD kết hợp trí thông minh nhân tạo AI. Tiết kiệm điện hiệu quả với công nghệ Inverter. Diệt vi khuẩn, loại bỏ các tác nhân gây dị ứng với công nghệ giặt hơi nước Steam', 5, N'hinh3.jpg', 9490000, N'NSX002', N'L002', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP022', N'Máy giặt sấy LG Inverter 10.5 kg FG1405H3W1', 27390000, N'Máy giặt sấy 2 trong 1 tiện lợi với khối lượng sấy tới 7 kg. Tiết kiệm điện, nước với công nghệ Inverter. Diệt vi khuẩn gây dị ứng nhờ công nghệ giặt hơi nước TrueSteam. Chống nhăn tối đa và tiết kiệm điện, nước hiệu quả với chế độ sấy Eco Hybrid. Giặt sạch, bảo vệ quần áo bền đẹp với công nghệ giặt 6 chuyển động. Tương thích với máy giặt TwinWash Mini. Sử dụng Smartphone để chẩn đoán tình trạng lỗi và điều khiển từ xa.', 18, N'FG1405H3W1.jpg', 21910000, N'NSX002', N'L002', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP023', N'Máy giặt sấy Samsung AddWash Inverter 10.5 kg WD10N64FR2XSV', 20990000, N'Máy giặt sấy 2 trong 1, khối lượng giặt 10.5 kg - khối lượng sấy 7 kg. Tối ưu hiệu quả bột giặt, giặt sạch quần áo với công nghệ giặt bong bóng Eco Bubble. Loại bỏ mùi hôi, kháng khuẩn với sấy hơi Airwash. Tiết kiệm thời gian với chế độ giặt sấy nhanh 59 phút. Diệt khuẩn, giảm nhăn quần áo với công nghệ giặt hơi nước. Vận hành êm ái, bền bỉ và tiết kiệm điện năng với động cơ Digital Inverter. Thêm đồ bất kỳ khi nào với cửa phụ Add Door. Tiện lợi với trợ lý giặt thông minh AI trên điện thoại.', 15, N'WD10N64FR2XSV.jpg', 19990000, N'NSX006', N'L002', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP024', N'Máy giặt sấy LG Inverter 9 kg FV1409G4V', 19990000, N'Máy giặt sấy tích hợp 2 trong 1 tiện lợi. Bảo vệ làn da, loại bỏ các tác nhân gây dị ứng với công nghệ giặt hơi nước Steam. Giảm thiểu hư tổn sợi vải nhờ công nghệ 6 chuyển động DD kết hợp trí thông minh nhân tạo AI. Tiết kiệm điện với công nghệ Inverter. Chuẩn đoán và xử lý nhanh các lỗi máy giặt nhờ tiện ích thông minh Smart ThinQ. Tiện lợi khi thêm đồ giặt và nước xả với cửa phụ Add Item.', 30, N'FV1409G4V.jpg', 16490000, N'NSX002', N'L002', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP025', N'Máy giặt sấy LG Inverter 8.5 kg FV1408G4W', 18990000, N'Máy giặt sấy 2 trong 1 tiện lợi cho gia đình. Giảm hư hại cho quần áo nhờ động cơ truyền động trực tiếp Intello DD hiện đại. Tiết kiệm nước và thời gian sấy khô nhờ công nghệ sấy EcoHybrid. Tiêu diệt vi khuẩn, làm mềm sợi vải khi sử dụng tính năng giặt hơi nước Steam+. Tiết kiệm điện, nước mỗi lần giặt với công nghệ Inverter. Giặt mạnh mẽ nhưng vẫn đảm bảo cho quần áo bền đẹp với công nghệ giặt 6 chuyển động. Cho phép điều khiển máy giặt từ xa qua ứng dụng SmartThinQ.', 42, N'FV1408G4W.jpg', 15590000, N'NSX002', N'L002', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP026', N'Máy giặt Toshiba 7 kg AW-A800SV WB', 4190000, N'Mâm giặt Hybrid Powerful tạo luồng nước mạnh nâng cao hiệu quả giặt sạch. Bộ lọc sinh học lọc sơ vải, cặn bẩn. Bảng điều khiển có tiếng Việt rất dễ sử dụng. Vắt cực khô giúp quần áo mau khô và tiết kiệm thời gian.', 11, N'AW-A800SV WB.jpg', NULL, N'NSX001', N'L002', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP027', N'Máy giặt Panasonic 8 kg NA-F80VS9GRV', 5290000, N'Gờ mâm giặt cao ma sát nhiều hơn. Luồng nước Dancing, nhào kĩ, giặt sạch hơn 15%. Công nghệ giặt Eco Aquabeat - tăng cường hiệu quả giặt sạch. Công nghệ xả nước Aqua Spin Rinse. Chế độ sấy gió 90 phút - tiết kiệm thời gian phơi quần áo. Bảng điều khiển nút nhấn, có hỗ trợ tiếng Việt dễ dàng sử dụng. Tính năng vệ sinh lồng giặt - giúp loại bỏ các cặn bã tích tụ trong lồng giặt.', 8, N'NA-F80VS9GRV.jpg', NULL, N'NSX003', N'L002', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP028', N'Máy giặt Panasonic 10 kg NA-F100V5LRV', 10090000, N'Giặt sạch nhiều vết bẩn, diệt khuẩn 99,99% với giặt nước nóng Stain Master+. Đánh bay vết bẩn cứng đầu với công nghệ Active Foam và hộp đánh tan bột giặt Turbo Mixer tạo bọt siêu mịn. Hoạt động tốt cả trong điều kiện nguồn nước yếu. Tự động cân chỉnh mực nước thông minh với cảm biến Econavi. Tạo luồng nước mạnh mẽ với mâm giặt 8 cánh Active Wave. Chế độ sấy gió 90 phút - tiết kiệm thời gian phơi quần áo. Loại bỏ các chất bẩn và cặn đóng trong lồng giặt với chế độ vệ sinh lồng giặt Tub Hygiene.', 19, N'NA-F100V5LRV.jpg', NULL, N'NSX003', N'L002', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP029', N'Tủ chăm sóc quần áo thông minh LG Styler S3RF', 50000000, N'Chăm sóc quần áo thông minh bằng hơi nước, phù hợp trang phục sang trọng: vest, đầm dạ hội.... Loại bỏ nếp nhăn và mùi khó chịu với chế độ Refresh. Diệt khuẩn, giảm tác nhân gây dị ứng công nghệ TrueSteam độc quyền. Ngăn ngừa quần áo bị co rút, hư hỏng. Giữ không gian nhà bạn luôn thoáng mát với tính năng hút ẩm. Chăm sóc ly quần với chế độ Paint Creases Care. Theo dõi quá trình giặt qua điện thoại kết nối Wifi.', 5, N'S3RF.jpg', 40000000, N'NSX002', N'L002', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP030', N'Tủ chăm sóc áo quần thông minh Samsung DF60R8600CGSV', 42990000, N'Diệt khuẩn, khử mùi và làm mới quần áo nhờ công nghệ JetSteam. Loại bỏ mùi hôi giữ quần áo luôn thơm tho với bộ lọc khử mùi. Bảo vệ quần áo tránh bị co rút và phai màu nhờ công nghệ sấy HeatPump. Giữ quần áo phẳng phiu như được là sau mỗi lần giặt với chế độ Wrinkle care. Giữ phòng luôn khô thoáng và bảo vệ quần áo khỏi nấm mốc nhờ chế độ hút ẩm. Tự động vệ sinh giúp tiết kiệm thời gian với chế độ Self Clean. Thiết kế bản lề thông minh đóng cửa an toàn và êm ái. Gợi ý giặt thông minh với nhờ ứng dụng SmartThings.', 5, N'DF60R8600CGSV.jpg', 39090000, N'NSX006', N'L002', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP031', N'Loa Tháp Samsung MX-T70/XV', 10990000, N'Thiết kế 2 mặt loa kéo độc đáo, âm thanh đa hướng sống động. Tái tạo chất âm đỉnh cao, tận hưởng dải âm trầm sống động nhờ loa trầm tích hợp. Tăng cường âm trầm cùng tổng công suất cực đại 1500 W với tính năng Bass Booster', 3, N'hinh4.jpg', 7690000, N'NSX006', N'L006', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP032', N'Loa thanh soundbar Sony 2.0 HT-S100F 120W', 2990000, N'Cách bố trí hai loa cho bạn thưởng thức âm thanh vòm phía trước từ một thiết bị nhỏ gọn. Sản phẩm loa mang đến âm trầm mạnh mẽ mà vẫn đảm bảo từng chi tiết âm thanh thật rõ nét, lý tưởng cho bạn xem chương trình TV và nghe nhạc. HDMI ARC cho phép truyền tín hiệu âm thanh và điều khiển từ TV mà chỉ cần một cáp nối. Công nghệ S-Force Front Surround mô phỏng các trường âm thanh như ở rạp chiếu phim cho căn phòng ngập tràn những thanh âm giàu sắc thái và sống động. Nghe nhạc trực tiếp không dây với công nghệ Bluetooth®.', 13, N'HT-S100F.jpg', NULL, N'NSX005', N'L006', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP033', N'Loa thanh Samsung HW-T420', 2160000, N'Thiết kế dạng hình khối, chắc chắn. Âm thanh to, rõ hơn nhờ công suất 150 W với 2.1 kênh. Kết nối với các thiết bị dễ dàng với Bluetooth 2.0. Tối ưu âm thanh với từng nội dung hiển thị nhờ công nghệ Smart Sound. Chơi game trải nghiệm thực tế hơn với chế độ Game Mode. Kiến tạo âm thanh đa chiều không dây dạng vòm như rạp phim. Điều khiển loa từ xa với remote tiện lợi.', 25, N'HW-T420.jpg', NULL, N'NSX006', N'L006', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP034', N'Loa Karaoke LG RM1', 3190000, N'Thiết kế hiện đại, gọn gàng.Hiệu ứng âm thanh mạnh mẽ, rõ ràng với công suất 25W. Kết nối không dây tiện lợi và nhanh chóng với Bluetooth. Thỏa sức hát Karaoke mọi lúc mọi nơi.', 33, N'RM1.jpg', 1590000, N'NSX002', N'L006', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP035', N'Loa thanh soundbar Samsung 2.1 HW-K350 150W', 3290000, N'Hệ thống loa Samsung 2.1 kênh, công suất loa mạnh mẽ 150W. Công nghệ âm thanh vòm Dobly và DTS hiện đại. Điều khiển loa bằng ứng dụng tiện lợi.', 40, N'HW-K350.jpg', 1640000, N'NSX006', N'L006', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP036', N'Loa thanh Samsung HW-Q950T', 33990000, N'Thiết kế màu đen sang trọng, tinh tế. Tổng công suất loa lên đến 546 W đầy mạnh mẽ, âm thanh chân thực nhờ hệ thống loa 9.1.4  kênh. Âm thanh vòm 3D lan tỏa, bao trùm không gian với bộ đôi công nghệ Dolby Atmos và DTS:X. Tối ưu âm thanh cho từng phân cảnh với công Adaptive Sound. Kích thích hơn khi chơi game với chế độ Game Mode Pro. Kết nối với các thiết bị điện thoại, máy tính bảng dễ dàng với Bluetooth 2.0. Điều chỉnh loa dễ dàng và tiện lợi với One Remote Control.', 2, N'HW-Q950T.jpg', NULL, N'NSX006', N'L006', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP037', N'Loa thanh soundbar LG 3.1.2 SN8Y 440W', 14990000, N'Mang đến cho bạn âm thanh vượt trội với công nghệ Meridian. Chất lượng giải trí chuẩn rạp chiếu phim với Dolby Vision, Dolby Atmos, DTS:X. Công suất 440 W và hệ thống 3.1.2 kênh cho không gian ngập tràn âm thanh. Âm thanh chất lượng cao với độ phân giải 24bit/96kHZ. Thiết lập phòng AI cho âm thanh phù hợp với không gian. Tạo hiệu ứng âm thanh phù hợp với nội dung bạn đang xem với công nghệ AI Sound Pro. Kết nối thuận tiện với các cổng kết nối: HDMI, Optical, Bluetooth.', 14, N'SN8Y.jpg', 8990000, N'NSX002', N'L006', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP038', N'Loa thanh soundbar Samsung 3.1.2 HW-Q70R 330W', 14990000, N'Kiểu dáng sang trọng, hiện đại. Công suất 330 W mạnh mẽ cùng hiệu ứng âm thanh sống động, lan toả đến từ công nghệ Dolby Digital Plus, DTS Digital Surround. Hỗ trợ điều khiển loa thanh băng điện thoại qua ứng dụng Samsung Audio Remote.', 8, N'HW-Q70R.jpg', NULL, N'NSX006', N'L006', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP039', N'Loa thanh Sony 3.1 HT- G700', 12990000, N'Âm thanh vòm sống động nhờ: DTS Virtual:X, Dolby Atmos và S-Force PRO Front Surround. Công suất mạnh mẽ, bùng nổ với hệ thống loa 3.1 kênh. Tái tạo âm trầm sâu lắng với loa subwoofer không dây. Kết nối không dây từ loa thanh đến tivi, điện thoại, máy tính bảng,... một cách nhanh chóng, dễ dàng thông qua Bluetooth.', 3, N'HT- G700.jpg', NULL, N'NSX005', N'L006', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP040', N'Dàn âm thanh Sony 5.1 BDV-E6100 1000W', 7190000, N'Mạng giải trí Sony-Sony Entertainment Network khám phá thế giới giải trí đa dạng. Kết nối NFC, Bluetooth và Wi-Fi tiện lợi. Chế độ Football mode tái hiện sống động những trận bóng đá hấp dẫn.', 26, N'BDV-E6100.jpg', 7190000, N'NSX005', N'L006', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP041', N'Máy lạnh Daikin Inverter 1.5 HP ATKA35UAVMV', 12890000, N'Luồng gió dễ chịu, tránh được gió thổi trực tiếp vào người với thiết kế tạo hiệu ứng Coanda. Độ bền cao với cánh tản nhiệt phủ 2 lớp chống ăn mòn cùng bo mạch được bảo vệ điện áp cao - thấp. Bảo vệ sức khỏe loại bỏ ẩm mốc với chức năng hoạt động chống ẩm mốc', 18, N'hinh5.jpg', NULL, N'NSX004', N'L005', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP042', N'Máy lạnh LG Inverter 1 HP V10ENF', 5000000, N'Động cơ Dual Inverter - làm lạnh nhanh hơn 40%, tiết kiệm điện lên đến 70%, vận hành êm ái. Công nghệ Jet Cool làm lạnh cực nhanh, hạ 5 độ C trong vòng 3 phút. Chủ động điều chỉnh công suất Energy Ctrl dựa vào số người trong phòng để tiết kiệm thêm điện năng. Bảo vệ sức khỏe của gia đình bạn với tấm vi lọc 3M. Chế độ thổi gió dễ chịu Comfort Air phù hợp cho trẻ nhỏ và người lớn tuổi. Gas R32 - tốt cho sức khỏe, bảo vệ môi trường.', 18, N'V10ENF.jpg', NULL, N'NSX002', N'L005', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP043', N'Máy lạnh Toshiba 1 HP RAS-H10U2KSG-V', 7990000, N'Công nghệ chống bám bẩn độc quyền Magic Coil giúp máy hoạt động tối ưu, nâng cao độ bền bỉ. Làm lạnh nhanh Hi Power cho căn phòng nhanh chóng được làm lạnh trong thời gian ngắn. Sự kết hợp giữa bộ lọc chống nấm mốc và bộ lọc IAQ mang đến bầu không khí trong lành, sạch khuẩn. Gas R-32 thân thiện với môi trường, an toàn cho sức khỏe người tiêu dùng. Tính năng tự khởi động lại khi có điện - Ghi nhớ các chế độ hiện có, không cần cài đặt lại.', 12, N'RAS-H10U2KSG-V.jpg', NULL, N'NSX001', N'L005', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP044', N'Máy lạnh Samsung Inverter 1 HP AR10RYFTAURNSV', 8990000, N'Vận hành êm ái, ổn định với công nghệ Digital Inverter. Chế độ một người dùng mang đến sự thoải mái nhưng vẫn tiết kiệm điện. Bộ 3 bảo vệ tăng cường giúp dàn máy bền bỉ với thời gian, chống ăn mòn. Chức năng tự làm sạch tiện lợi, tiết kiệm thời gian và chi phí làm vệ sinh dàn lạnh. Gas R-32 bảo vệ môi trường.', 27, N'AR10RYFTAURNSV.jpg', NULL, N'NSX006', N'L005', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP045', N'Máy lạnh Toshiba Inverter 1 HP RAS-H10DKCVG-V', 8990000, N'Công nghệ chống bám bẩn độc quyền Magic Coil giúp máy hoạt động tối ưu, nâng cao độ bền bỉ. Tiết kiệm điện, vận hành êm, duy trì độ lạnh ổn định với công nghệ Hybrid Inverter. Làm lạnh nhanh Hi Power cho căn phòng nhanh chóng được làm lạnh trong thời gian ngắn. Sự kết hợp giữa bộ lọc chống nấm mốc và bộ lọc IAQ mang đến bầu không khí trong lành, sạch khuẩn. Loại bỏ mùi ẩm mốc với chức năng tự động làm sạch sau mỗi lần hoạt động. Gas R-32 thân thiện với môi trường, an toàn cho sức khỏe người tiêu dùng. Tính năng tự khởi động lại khi có điện - Ghi nhớ các chế độ hiện có, không cần cài đặt lại.', 15, N'RAS-H10DKCVG-V.jpg', NULL, N'NSX001', N'L005', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP046', N'Máy lạnh Panasonic 1 HP CU/CS-N9WKH-8M', 8890000, N'Loại bỏ bụi bẩn, bụi mịn hiệu quả nhờ bộ lọc Nanoe-G. Tạo không gian thoáng đãng, khô ráo với chế độ hút ẩm. Làm lạnh nhanh tức thì cùng chế độ Powerful. Tiện lợi, kiểm soát điện năng tiêu thụ nhờ chế độ hẹn giờ bật - tắt.', 30, N'CUCSN9WKH8M.jpg', NULL, N'NSX003', N'L005', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP047', N'Máy lạnh Toshiba Inverter 1.5 HP RAS-H13PKCVG-V', 14890000, N'Công nghệ chống bám bẩn độc quyền Magic Coil giúp máy hoạt động tối ưu, nâng cao độ bền bỉ. Tiết kiệm điện, vận hành êm, duy trì độ lạnh ổn định với công nghệ Hybrid Inverter. Nút Power-Sel điều chỉnh công suất hoạt động để tiết kiệm kiện tối ưu. Làm lạnh nhanh Hi Power cho căn phòng nhanh chóng được làm lạnh trong thời gian ngắn. Sự kết hợp giữa bộ lọc chống nấm mốc và bộ lọc IAQ mang đến bầu không khí trong lành, sạch khuẩn. Loại bỏ mùi ẩm mốc với chức năng tự động làm sạch sau mỗi lần hoạt động. Chế độ Comfort Sleep - mang lại giấc ngủ sâu và trọn vẹn. Gas R-32 thân thiện với môi trường, an toàn cho sức khỏe người tiêu dùng. Tính năng tự khởi động lại khi có điện - Ghi nhớ các chế độ hiện có, không cần cài đặt lại.', 16, N'RAS-H13PKCVG-V.jpg', 13890000, N'NSX001', N'L005', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP048', N'Máy lạnh Panasonic Inverter 1.5 HP CU/CS-WPU12WKH-8M', 14590000, N'Công nghệ Inverter cùng với chế độ Eco tích hợp AI giúp tiết kiệm điện và làm lạnh hiệu quả. Nanoe-G lọc sạch bụi bẩn, bụi mịn PM2.5, giúp bảo vệ hô hấp gia đình bạn. Điều khiển máy lạnh từ xa qua điện thoại với khả năng kết nối Wifi. Chức năng hút ẩm giữ cho căn phòng luôn khô thoáng. Bảo vệ sức khoẻ với chế độ ngủ (Sleep Mode) tự điều chỉnh nhiệt độ. Chế độ hẹn giờ tiện lợi. Làm lạnh nhanh tức thì Powerful làm lạnh căn phòng chỉ trong vài phút. Thiết kế sang trọng công suất lớn 1.5 HP.', 31, N'CUCS-WPU12WKH-8M.jpg', 13890000, N'NSX003', N'L005', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP049', N'Máy lạnh Tủ đứng LG Inverter 5 HP APNQ48GT3E4', 53790000, N'Công suất làm lạnh lớn 5 HP cùng kiểu dáng dạng tủ thanh lịch, hiện đại. Tiết kiệm điện hiệu quả nhờ công nghệ Inverter. Làm lạnh nhanh với chế độ Power Cooling Mode. Bảo vệ sức khỏe tối ưu với luồng gió thổi dễ chịu. Tiện lợi, kiểm soát thời gian máy hoạt động nhờ chế độ hẹn giờ.', 3, N'APNQ48GT3E4-3.jpg', NULL, N'NSX002', N'L005', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP050', N'Máy lạnh 2 chiều Inverter Panasonic 2 HP CU/CS-YZ18UKH-8', 25590000, N'Điều hòa 2 chiều có thêm chức năng sưởi ấm. Công nghệ Inverter - tiết kiệm điện, vận hành êm, làm lạnh sâu và hơi lạnh lan tỏa đều. Làm lạnh nhanh tức thì với chế độ Powerful. Công nghệ Nanoe-G - lọc không khí trong lành, sạch bụi bẩn, bụi mịn PM2.5. Gas R32 an toàn, thân thiện với môi trường.', 7, N'CUCS-YZ18UKH-8.jpg', 23590000, N'NSX003', N'L005', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP051', N'Máy lọc nước RO Toshiba TWP-N1843SV 3 lõi', 6990000, N'Máy lọc nước có 3 lõi lọc, màng lọc RO của Mỹ loại bỏ đến 99.9% vi khuẩn, kim loại nặng trong nước. Công suất lọc đạt 7.8 lít/giờ, dung tích bình chứa nước 8 lít, đáp ứng tối đa nhu cầu nước dùng của mọi người. Tính năng tự động báo thay lõi, tự động ngừng hoạt động khi nước đầy bình, khi áp lực nước cấp không đủ, tự động xả nước thải', 2, N'hinh6.jpg', 6705000, N'NSX001', N'L008', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP052', N'Máy lọc nước RO Toshiba TWP-W1643SV(W) 4 lõi', 8490000, N'Màng lọc RO 80GDP cho công suất lọc lớn 7.8 lít/giờ. Bình chứa nước 4.6 lít với 1 lít nước nóng và 3.6 lít nước lạnh. Máy lọc nước nóng lạnh với 4 lõi lọc cung cấp nước sạch cho nhu cầu sử dụng. Diệt khuẩn bằng đèn UV, có đèn báo thay lõi tiện lợi cho quá trình sử dụng sản phẩm. Thương hiệu Toshiba – Nhật Bản, sản xuất tại Trung Quốc.', 16, N'TWP-W1643SV(W).jpg', 8065000, N'NSX001', N'L008', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP053', N'Máy lọc nước RO Kangaroo VTU KG08 6 lõi', 4690000, N'Lõi lọc số 4 RO - Filmtec sản xuất tại Hàn Quốc, giúp lọc sạch nước trở nên tinh khiết hơn. Máy lọc nước RO có công suất lọc từ 10 - 12 lít/giờ đáp ứng nhu cầu sử dụng. Dung tích bình chứa 8 ít đủ dùng cho nhu cầu gia đình, văn phòng. Công nghệ lõi lọc Nano Silver giúp loại bỏ vi khuẩn, mùi clo trong nước. Máy lọc nước Kangaroo - thương hiệu Việt Nam, sản xuất tại Việt Nam đảm bảo chất lượng.', 28, N'VTU KG08.jpg', 3690000, N'NSX008', N'L008', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP054', N'Máy lọc nước R.O nước mặn, nước lợ Kangaroo KG3500AVTU 10 lõi', 6990000, N'Màng lọc RO xuất xứ Hàn Quốc, hệ thống 10 lõi lọc mang lại nước tinh khiết, bổ sung khoáng chất. Công suất lọc 10 lít/giờ, dung tích bình 10 lít cung cấp đủ nước cho gia đình đông người dùng liên tục. Công nghệ Nano Silver kháng khuẩn hiệu quả. Tự động ngừng hoạt động khi nước đầy bình hoặc khi áp lực nước cấp không đủ. Ra mắt năm 2020, sản phẩm của thương hiệu Kangaroo - Việt Nam, sản xuất tại Việt Nam.', 17, N'KG3500AVTU.jpg', 6705000, N'NSX008', N'L008', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP055', N'Máy lọc nước RO hydrogen ion kiềm Kangaroo KG100EO 7 lõi', 12900000, N'Công nghệ điện phân nước RO tạo nước Hydrogen ion kiềm, cung cấp nước sạch toàn diện. Hệ thống 7 lõi lọc cung cấp nước sạch, thêm nhiều khoáng chất, độ ngọt tự nhiên. Công suất lọc 18 lít/giờ, bình chứa nước 7 lít đủ dùng cho nhu cầu nước uống tại gia đình. Hệ thống bơm - hút 2 chiều, van điện từ tăng áp lực nước đầu vào, nâng cao hiệu suất lọc, tăng tuổi thọ sản phẩm. Tấm điện cực được thiết kế dưới dạng lưới mắt cáo làm tăng diện tích tiếp xúc với nước, chống bám cặn tốt và an toàn cho sức khoẻ. Thương hiệu Kangaroo - Việt Nam, sản xuất tại Việt Nam.', 5, N'KG100EO.jpg', NULL, N'NSX008', N'L008', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP056', N'Máy lọc nước RO hydrogen ion kiềm Kangaroo KG100ES 7 lõi', 11900000, N'Công nghệ điện phân nước RO tạo nước Hydrogen ion kiềm trung hòa axit cho cơ thể. Hệ thống 7 lõi lọc cung cấp nước sạch hoàn hảo, thêm nhiều khoáng chất có lợi cho sức khỏe. Công suất lọc 18 lít/giờ, sử dụng bình chứa nước dung tích 7 lít đủ dùng cho nhu cầu nước uống thông thường tại gia đình. Hệ thống bơm - hút 2 chiều, van điện từ tăng áp lực nước đầu vào, nâng cao hiệu suất lọc, tăng tuổi thọ sản phẩm. Tự động sục rửa màng RO tăng tuổi thọ lõi lọc, chế độ cút nối nhanh tháo lắp và thay thế thật tiện lợi. Thương hiệu Kangaroo - Việt Nam, sản xuất tại Việt Nam.', 8, N'KG100ES.jpg', NULL, N'NSX008', N'L008', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP057', N'Máy lọc nước RO nóng lạnh Sunhouse SHA76213CK 10 lõi', 10290000, N'Thiết kế slim thon gọn phù hợp với mọi không gian nội thất. Loại bỏ 99,9% vi khuẩn nhờ màng R.O nhập khẩu Hàn Quốc và công nghệ diệt khuẩn Nanosilver. Lọc sạch nước, bổ sung khoáng chất nhờ bộ 10 lõi lọc. Lọc nước lên đến 15 lít/giờ, trong đó dung tích bình nước nóng 1 lít, bình nước lạnh 2 lít, nước thường 4 lít. Công nghệ làm lạnh bằng block gas, giữ nước lạnh hơn và giúp máy bền hơn. Ra mắt năm 2020, thương hiệu Sunhouse - sản xuất tại Việt Nam.', 10, N'SHA76213CK.jpg', 8700000, N'NSX007', N'L008', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP058', N'Máy lọc nước RO nóng lạnh Kangaroo KG10A3 10 lõi', 8690000, N'Màng lọc RO xuất xứ Hàn Quốc, hệ thống 10 cấp lọc mang lại nước tinh khiết, bổ sung khoáng chất. Công suất lọc 10 - 12 lít/giờ, dung tích bình nước nóng 1 lít, nước thường 10 lít, nước lạnh 0.8 lít. Thiết kế 2 vòi nóng lạnh riêng biệt, tiện pha chế trà, sữa, mì hay nước mát để sử dụng. Thương hiệu Kangaroo Việt Nam, sản xuất tại Việt Nam.', 11, N'KG10A3.jpg', 6800000, N'NSX008', N'L008', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP059', N'Máy lọc nước RO nóng lạnh Sunhouse SHR76210CK 10 lõi', 8490000, N'Màng lọc R.O DOW - USA loại bỏ 99,9% vi khuẩn và 10 lõi lọc giúp bổ sung khoáng chất, loại bỏ vi khuẩn mang lại nguồn nước sạch trong lành. Đáp ứng hiệu quả nhu cầu sử dụng với dung tích 10 lít, bình lạnh 0.65 lít, bình nóng 0.85 lít và công suất lọc 10-15 lít/giờ. Tích hợp 2 vòi nước: nóng (nhiệt độ 80 - 90 độ C), lạnh (nhiệt độ 10 - 15 độ C). Thiết kế sang trọng, mặt kính cường lực. Thương hiệu Sunhouse của Việt Nam - Sản xuất tại Việt Nam.', 30, N'SHR76210CK.jpg', 7640000, N'NSX007', N'L008', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP060', N'Máy lọc nước RO Sunhouse SHA8817KP 9 lõi', 7590000, N'Lọc sạch 99,9% vi khuẩn nhờ màng R.O Dow – USA. Hệ thống 9 lõi lọc với các lõi bổ sung tăng cường khoáng, tạo vị ngọt tự nhiên và chống tái nhiễm khuẩn cho nước. Công suất lọc mạnh mẽ 10 - 15 lít/h, bình chứa nước có dung tích 10 lít. Máy lọc nước hoạt động hiệu quả, cấp đủ nước đầu vào với bơm - hút 2 chiều, van từ hiện đại. Thương hiệu nổi tiếng Sunhouse - Việt Nam, sản xuất tại Việt Nam.', 7, N'SHA8817KP.jpg', 5990000, N'NSX007', N'L008', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP061', N'Máy giặt sấy Samsung Inverter 9.5kg WD95J5410AW/SV', 13630000, N'Giặt sấy tích hợp 2 trong 1 tiện lợi. Tiết kiệm điện, vận hành êm nhờ công nghệ Digital Inverter. Đánh bật vết bẩn cứng đầu hiệu quả nhờ công nghệ giặt bong bóng Eco Bubble. Khử mùi, loại bỏ vi khuẩn cùng chế độ sấy hơi Air Wash. Thấm sâu vào sợi vải, góp phần loại bỏ vết bẩn tối ưu với Bubble Soak. Tiết kiệm thời gian với chế độ giặt siêu nhanh Quick Wash. Chuẩn đoán và khắc phục nhanh chóng các sự cố nhờ ứng dụng thông minh Smart Check.', 9, N'WD95J5410AWSV.jpg', 13630000, N'NSX006', N'L003', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP062', N'Máy giặt sấy Samsung AddWash Inverter 9.5 kg WD95K5410OX/SV', 14590000, N'Tích hợp tính năng sấy khô tiện lợi, không lo phơi đồ ngày mưa. Sử dụng điện hiệu quả với công nghệ Digital Inverter. Sử dụng bột giặt hiệu quả với công nghệ bong bóng Eco Bubble. Tiện lợi khi thêm đồ giặt với cửa phụ Add Door. An toàn với chức năng khóa trẻ em. Giảm hư tổn quần áo nhờ lồng giặt kim cương.', 9, N'WD95K5410OXSV.jpg', NULL, N'NSX006', N'L003', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP063', N'Máy giặt sấy LG Inverter 8.5 kg FV1408G4W', 18990000, N'Máy giặt sấy 2 trong 1 tiện lợi cho gia đình. Giảm hư hại cho quần áo nhờ động cơ truyền động trực tiếp Intello DD hiện đại. Tiết kiệm nước và thời gian sấy khô nhờ công nghệ sấy EcoHybrid. Tiêu diệt vi khuẩn, làm mềm sợi vải khi sử dụng tính năng giặt hơi nước Steam+. Tiết kiệm điện, nước mỗi lần giặt với công nghệ Inverter. Giặt mạnh mẽ nhưng vẫn đảm bảo cho quần áo bền đẹp với công nghệ giặt 6 chuyển động. Cho phép điều khiển máy giặt từ xa qua ứng dụng SmartThinQ.', 14, N'FV1408G4W.jpg', 15590000, N'NSX002', N'L003', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP064', N'Máy giặt sấy Samsung AddWash Inverter 10.5 kg WD10N64FR2W/SV', 19490000, N'Máy giặt sấy 2 trong 1, khối lượng giặt 10.5 kg và khối lượng sấy 7 kg. Tối ưu hiệu quả bột giặt, giặt sạch quần áo với công nghệ giặt bong bóng Eco Bubble. Loại bỏ mùi hôi, kháng khuẩn với Sấy hơi Airwash. Tiết kiệm thời gian với chế độ Giặt sấy nhanh 59 phút. Diệt khuẩn, giảm nhăn quần áo với công nghệ giặt hơi nước. Vận hành êm ái, bền bỉ và tiết kiệm điện năng với động cơ Digital Inverter. Thêm đồ bất kỳ khi nào với cửa phụ Add Door. Tiện lợi với trợ lý giặt thông minh AI trên điện thoại.', 8, N'WD10N64FR2WSV.jpg', 18490000, N'NSX006', N'L003', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP065', N'Máy giặt sấy LG Inverter 9 kg FV1409G4V', 19990000, N'Máy giặt sấy tích hợp 2 trong 1 tiện lợi. Bảo vệ làn da, loại bỏ các tác nhân gây dị ứng với công nghệ giặt hơi nước Steam. Giảm thiểu hư tổn sợi vải nhờ công nghệ 6 chuyển động DD kết hợp trí thông minh nhân tạo AI. Tiết kiệm điện với công nghệ Inverter. Chuẩn đoán và xử lý nhanh các lỗi máy giặt nhờ tiện ích thông minh Smart ThinQ. Tiện lợi khi thêm đồ giặt và nước xả với cửa phụ Add Item.', 17, N'FV1409G4V.jpg', 16490000, N'NSX002', N'L003', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP066', N'Máy giặt sấy Samsung AddWash Inverter 10.5 kg WD10N64FR2X/SV', 20990000, N'Máy giặt sấy 2 trong 1, khối lượng giặt 10.5 kg - khối lượng sấy 7 kg. Tối ưu hiệu quả bột giặt, giặt sạch quần áo với công nghệ giặt bong bóng Eco Bubble. Loại bỏ mùi hôi, kháng khuẩn với sấy hơi Airwash. Tiết kiệm thời gian với chế độ giặt sấy nhanh 59 phút. Diệt khuẩn, giảm nhăn quần áo với công nghệ giặt hơi nước. Vận hành êm ái, bền bỉ và tiết kiệm điện năng với động cơ Digital Inverter. Thêm đồ bất kỳ khi nào với cửa phụ Add Door. Tiện lợi với trợ lý giặt thông minh AI trên điện thoại.', 3, N'WD10N64FR2XSV.jpg', 19990000, N'NSX006', N'L003', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP067', N'Máy giặt sấy LG Inverter 10.5 kg FV1450H2B', 26490000, N'Máy giặt sấy 2 trong 1 tiện lợi cho gia đình. Giảm hư hại cho quần áo nhờ động cơ truyền động trực tiếp Intello DD hiện đại. Tiết kiệm nước và thời gian sấy khô nhờ công nghệ sấy EcoHybrid. Giặt sạch nhanh chóng chỉ trong thời gian ngắn với công nghệ giặt tiết kiệm TurboWash 360. Tiêu diệt vi khuẩn, làm mềm sợi vải khi sử dụng tính năng giặt hơi nước Steam+. Tiết kiệm điện, nước mỗi lần giặt với công nghệ Inverter. Giặt mạnh mẽ nhưng vẫn đảm bảo cho quần áo bền đẹp với công nghệ giặt 6 chuyển động. Cho phép điều khiển máy giặt từ xa qua ứng dụng SmartThinQ.', 3, N'FV1450H2B.jpg', 21900000, N'NSX002', N'L003', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP068', N'Máy giặt sấy LG Inverter 10.5 kg FG1405H3W1', 27390000, N'Máy giặt sấy 2 trong 1 tiện lợi với khối lượng sấy tới 7 kg. Tiết kiệm điện, nước với công nghệ Inverter. Diệt vi khuẩn gây dị ứng nhờ công nghệ giặt hơi nước TrueSteam. Chống nhăn tối đa và tiết kiệm điện, nước hiệu quả với chế độ sấy Eco Hybrid. Giặt sạch, bảo vệ quần áo bền đẹp với công nghệ giặt 6 chuyển động. Tương thích với máy giặt TwinWash Mini. Sử dụng Smartphone để chẩn đoán tình trạng lỗi và điều khiển từ xa.', 21, N'FG1405H3W1.jpg', 21910000, N'NSX002', N'L003', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP069', N'Máy giặt sấy Samsung Add Wash Inverter 19 kg WD19N8750KV/SV', 27900000, N'Khối lượng giặt - sấy lớn, đáp ứng nhu cầu giặt giũ của cả nhà. Động cơ truyền động trực tiếp bền bỉ, êm ái. Giặt giũ dễ dàng, tiện lợi với trợ lý giặt thông minh AI. Ngăn Auto Dispense tự động điều chỉnh nước giặt, nước xả. Dánh bay vết bẩn cứng đầu với công nghệ giặt bong bóng Eco Bubble. Loại bỏ vi khuẩn và tác nhân gây dị ứng trên quần áo thông qua chế độ giặt nước nóng. Tự vệ sinh lồng giặt tiện lợi, tiết kiệm thời gian và chi phí. Tiện lợi với chế độ hẹn giờ. Loại bỏ mùi hôi trên quần áo với công nghệ sấy khử mùi. Vận hành êm ái, tiết kiệm nước, điện với công nghệ Inverter.', 1, N'WD19N8750KVSV.jpg', NULL, N'NSX006', N'L003', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP070', N'Máy sấy Samsung 9 Kg DV90M5200QW/SV', 16990000, N'Tiết kiệm điện tối ưu, sấy nhanh cùng công nghệ Heatpump. Sấy khô nhanh có thể mặc liền trong 35 phút tiện lợi. Tiết kiệm điện, vận hành êm ái với công nghệ Inverter. Phù hợp cho gia đình đông người với khối lượng sấy lên đến 9 Kg. Công nghệ sấy ngưng tụ tránh bỏng, bảo vệ an toàn cho trẻ em trong gia đình. Sấy khô quần áo hiệu quả với công nghệ Optimal Dry. Giảm nhăn quần áo cùng tính năng Wrinkle Prevent.', 15, N'DV90M5200QWSV.jpg', NULL, N'NSX006', N'L003', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP071', N'Tủ đông LG Inverter 165 lít GN-F304PS', 6490000, N'Tay cầm thời trang, tiện lợi và không lo bị gãy tay cầm. Thiết kế cửa bạch kim hoàn thiện, đẹp mắt. Làm lạnh nhanh, tiết kiệm điện với máy nén Inverter. Làm mát nhanh, đều hơn nhờ công nghệ làm mát kệ. Dung tích 165 lít, sự lựa chọn lý tưởng cho gia đình có 2 - 3 thành viên. Tiết kiệm không gian, phù hớp với căn hộ nhỏ khi bề ngang tủ hẹp (530mm). Linh hoạt, lưu trữ đa dạng thực phẩm với thiết kế 6 kệ và 1 hộc tủ.', 32, N'GN-F304PS.jpg', 6190000, N'NSX002', N'L004', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP072', N'Tủ đông Kangaroo 140 lít KG 265NC1', 6490000, N'Thiết kế nhỏ gọn, phù hợp với không gian hẹp. Dung tích 140 lít tiện lưu trữ cho gia đình ít người dùng. Gas R600a thân thiện môi trường, tiết kiệm điện. Lưu trữ thực phẩm an toàn với công nghệ Nano Silver. Dàn lạnh từ đồng nguyên chất giúp hoạt động bền bỉ. Giỏ đựng đồ, bánh xe linh hoạt giúp sử dụng thuận tiện.', 40, N'265NC1.jpg', 5690000, N'NSX008', N'L004', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP073', N'Tủ đông LG Inverter 165 lít GN-F304WB', 6990000, N'Sang trọng, chắn chắc với tay cầm dạng âm vào trong. Kiểu dáng thon gọn, tinh tế. Vận hành êm ái, tiết kiệm điện năng với công nghệ Inverter. Làm mát thực phẩm một cách nhanh chóng với công nghệ làm mát kệ. Tiết kiệm không gian gia đình bạn với bề ngang tủ hẹp chỉ 530 mm. Sử dụng thoải mái với dung tích tủ lên tới 165 lít. Bảo quản nhiều loại thực phẩm với 6 kệ và 1 hộc tủ.', 40, N'GN-F304WB.jpg', 6690000, N'NSX002', N'L004', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP074', N'Tủ đông Kangaroo 192 lít KG 266NC2', 7190000, N'Màu trắng nhẹ nhàng, thiết kế nhỏ gọn phù hợp với mọi không gian. Dung tích 192 lít thoải mái lưu trữ. Tủ đông 2 cửa với 2 ngăn giúp lưu trữ đa dạng. Vận hành êm ái, thân thiện môi trường nhờ gas R600a. Thực phẩm tươi sạch, an toàn sử dụng với công nghệ Nano Silver. Làm lạnh nhanh nhờ dàn đồng nguyên chất. Khóa cửa tủ, bánh xe, giỏ đựng đồ tiện dụng.', 12, N'266NC2.jpg', 6290000, N'NSX008', N'L004', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP075', N'Tủ đông Sunhouse 225 lít SHR-F2272W2', 7790000, N'Thiết kế 2 ngăn (đông, mát) với dung tích 225 lít, đủ rộng để dự trữ lượng lớn thức ăn. Độ lạnh luôn được ổn định nhờ công nghệ làm lạnh sâu đa chiều 360 độ. Giữ lạnh lâu dễ dàng lên đến 12h khi ngắt điện nhờ tấm cách nhiệt Foam. Làm lạnh nhanh, tiết kiệm điện đến 30% nhờ sử dụng dàn lạnh bằng đồng, gas R600a. Giảm bám tuyết, dễ dàng vệ sinh với vỏ tôn sơn tĩnh điện. Tiện lợi khi trang bị khóa cửa tủ, bánh xe, giỏ đựng đồ.', 17, N'SHR-F2272W2.jpg', NULL, N'NSX007', N'L004', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP076', N'Tủ đông Kangaroo 212 lít KG 328NC2', 7390000, N'Thiết kế trẻ trung, hiện đại phù hợp với không gian lớn. Thoải mái lưu trữ với dung tích lên đến 212 lít. Lưu trữ đa dạng ở nhiều nhiệt độ với 2 ngăn. Tiết kiệm điện, vận hành êm ái, thân thiện môi trường nhờ gas R600a. Kháng khuẩn, khử mùi nhờ công nghệ Nano Silver. Làm lạnh nhanh hơn nhờ việc sử dụng dàn lạnh bằng đồng nguyên chất. Bánh xe linh động cùng giỏ đựng đồ tiện lợi.', 23, N'328NC2.jpg', NULL, N'NSX008', N'L004', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP077', N'Tủ đông Kangaroo 490 lít KG 809C1', 15190000, N'Khử mùi, diệt khuẩn tối ưu nhờ công nghệ Nano Silver. Làm đông thực phẩm nhanh với dàn lạnh bằng đồng nguyên chất. An toàn cho người dùng, thân thiện môi trường khi dùng gas R134a. Quan sát thực phẩm rõ khi trang bị đèn chiếu sáng. Tránh sự nghịch phá trẻ nhờ khóa cửa tủ.', 69, N'809C1.jpg', 13690000, N'NSX008', N'L004', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP078', N'Tủ đông mềm Kangaroo 252 lít KG 400DM2', 10990000, N'Giữ trọn hương vị và tiết kiệm thời gian chế biến khi tích hợp ngăn đông mềm -5 độ C. Thiết kế 2 ngăn (đông mềm, mát) với dung tích 252 lít có thể tích trữ lượng lớn thức ăn. An toàn cho sức khỏe với khả năng kháng khuẩn Nano Silver. Loại bỏ nỗi lo bị lẫn mùi thực phẩm nhờ công nghệ 2 dàn lạnh độc lập. Bảo quản thực phẩm tốt với dàn làm lạnh bằng đồng nguyên chất. An toàn, tiết kiệm điện và thân thiện với môi trường khi dùng gas R600a.', 10, N'400DM2.jpg', 9990000, N'NSX008', N'L004', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP079', N'Tủ đông Sunhouse 330 lít SHR-F2472W2', 10390000, N'Thiết kế 2 cửa, 2 ngăn đông mát với dung tích 330 lít tiện lợi. Giữ nhiệt độ lạnh ổn định với công nghệ lạnh sâu đa chiều 360 độ. Làm lạnh nhanh, tiết kiệm điện 30% khi sử dụng gas R600a cùng dàn lạnh bằng đồng. Giảm thất thoát hơi lạnh với tấm cách nhiệt Foam. Giảm bám tuyết nhờ mặt trong làm bằng tôn sơn tĩnh điện. Khóa an toàn, bánh xe xoay đa chiều tiện lợi.', 32, N'SHR-F2472W2.jpg', NULL, N'NSX007', N'L004', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP080', N'Tủ đông Sunhouse 255 lít SHR-F2362W2', 8690000, N'Dung tích 255 lít gồm 2 ngăn đông - mát đủ rộng cho bạn dự trữ lượng lớn thực phẩm. Nhiệt độ lạnh luôn ổn định nhờ công nghệ làm lạnh sâu đa chiều 360 độ.Giữ lạnh thực phẩm lên đến 12h khi ngắt điện nhờ tích hợp tấm cách nhiệt Foam. Làm lạnh nhanh nhưng vẫn tiết kiệm điện với dàn lạnh bằng đồng, gas R600a. Có khóa tủ an toàn, bánh xe di chuyển linh hoạt và giỏ đồ tiện ích.', 11, N'SHR-F2362W2.jpg', 8290000, N'NSX007', N'L004', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP081', N'Bếp từ Sunhouse SHD6149', 600000, N'Bếp từ đơn 1 vùng nấu nhỏ gọn, tiện dụng. Mặt bếp bằng kính chịu nhiệt siêu bền, chịu được nhiệt đến 600 độ C. 7 chế độ nấu tiện dụng như nấu, xào, soup, cháo, hâm sữa, hấp, giữ ấm. Bảng điều khiển kèm tiếng Việt, có khóa an toàn, có hẹn giờ nấu.', 15, N'SHD6149.jpg', NULL, N'NSX002', N'L007', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP082', N'Bếp từ Sunhouse SHD 6861', 1100000, N'Bếp từ đơn 1 vùng nấu nhỏ gọn, tiện dụng. Mặt bếp bằng kính chịu nhiệt siêu bền, chịu được nhiệt đến 600 độ C. 7 chế độ nấu tiện dụng như nấu, xào, soup, cháo, hâm sữa, hấp, giữ ấm. Bảng điều khiển kèm tiếng Việt, có khóa an toàn, có hẹn giờ nấu.', 18, N'SHD 6861.jpg', NULL, N'NSX007', N'L007', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP083', N'Bếp từ Kangaroo KG408I', 1250000, N'Bếp từ đơn công suất 2100 W nấu ăn nhanh. Mặt bếp bằng kính chịu nhiệt bền tốt, ít bám bẩn, dễ lau chùi. 8 chế độ nấu tự động và chế độ nấu tiết kiệm điện. Tính năng hẹn giờ nấu hỗ trợ nấu ăn lúc bận rộn.', 8, N'KG408I.jpg', 1190000, N'NSX008', N'L007', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP084', N'Bếp từ hồng ngoại Sunhouse SHB9105MT', 4070000, N'Bếp từ kết hợp bếp hồng ngoại nấu ăn tiện lợi, linh hoạt, thiết kế sang trọng. Mặt bếp bằng kính cường lực cao cấp chống trầy, sáng bóng, chịu nhiệt tốt. Bảng điều khiển cảm ứng cùng màn hình hiển thị sắc nét dễ sử dụng. Sử dụng an toàn với chức năng khóa bảng điều khiển, tự ngắt khi quá tải. Ra mắt năm 2019, thương hiệu Sunhouse uy tín của Việt Nam, sản xuất tại Trung Quốc.', 33, N'SHB9105MT.jpg', 3250000, N'NSX007', N'L007', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP085', N'Bếp từ đôi Sunhouse SHB9101', 5550000, N'Bếp từ có 2 lò đun, công suất tổng tới 4000 W, nấu ăn nhanh chóng. Mặt bếp bằng kính ceramic sáng bóng, dễ chùi rửa. Có khóa bảng điều khiển, chức năng hẹn giờ nấu tiện dụng. Thương hiệu Sunhouse - Việt Nam, sản xuất tại Việt Nam.', 26, N'SHB9101.jpg', NULL, N'NSX007', N'L007', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP086', N'Bếp từ hồng ngoại Sunhouse Apex APB9982', 20494000, N'Mặt bếp bằng kính Schott Ceran - Châu Âu chịu nhiệt tốt, sáng bóng và dễ lau chùi. Bếp gồm 1 bếp từ và 1 bếp hồng ngoại giúp nấu ăn dễ dàng. Bảng điều khiển cảm ứng hiện đại, thao tác đơn giản. An toàn khi sử dụng với tính năng tự ngắt, khóa bảng điều khiển. Thương hiệu Việt Nam, sản xuất tại Châu Âu.', 4, N'APB9982.jpg', NULL, N'NSX007', N'L007', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP087', N'Bếp từ đôi Sunhouse Apex APB9981', 18490000, N'Bếp từ có 2 lò đun, công suất tổng tới 3800 W, nấu ăn nhanh chóng. Mặt bếp bằng kính Schott Ceran sáng bóng, chịu nhiệt tốt, chống trầy. Có khóa bảng điều khiển, chức năng hẹn giờ nấu tiện dụng. Có đèn báo mặt bếp còn nóng và tạm ngừng khi đang nấu hiện đại, an toàn. Thương hiệu Sunhouse - Việt Nam, sản xuất tại Châu Âu.', 18, N'APB9981.jpg', NULL, N'NSX007', N'L007', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP088', N'Bếp từ đôi Sunhouse Mama MMB9208DIH', 25000000, N'Kiểu dáng sang trọng, mẫu mã hiện đại, thích hợp mọi không gian bếp. Có 2 vùng nấu thuận tiện với nhiều loại nồi, chảo có đế nhiễm từ. Bảng điều khiển cảm ứng riêng biệt cho 2 vùng nấu dễ dàng sử dụng. Mặt kính schott ceran chịu lực, chịu sốc nhiệt đến 800 độ C. Công suất nấu lên đến 3600 W với bếp trái 2600W, bếp phải 2200W, nấu nhanh, tiết kiệm điện năng. An toàn với chế độ khoá điều khiển, cảnh báo khi quá nhiệt, cảnh báo nồi không phù hợp. Thương hiệu Sunhouse nổi tiếng của Việt Nam, được sản xuất tại Thái Lan.', 1, N'MMB9208DIH.jpg', NULL, N'NSX007', N'L007', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP089', N'Bếp từ đôi Kangaroo KG438I', 7500000, N'Mặt bếp bằng kính chịu nhiệt sáng bóng, chống trầy, tiện lau chùi. Công suất lớn 3500 W, làm chín thức ăn nhanh, ít tốn điện. Bảng điều khiển cảm ứng nhanh nhạy, có chỉ dẫn dễ hiểu, dễ thao tác. Thương hiệu Kangaroo uy tín của Việt Nam, mẫu đẹp, dùng tốt.', 49, N'KG438I.jpg', 4990000, N'NSX008', N'L007', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP090', N'Bếp từ hồng ngoại Sunhouse SHB9104MT', 3490000, N'Mặt bếp bằng kính chịu nhiệt sáng bóng, tiện lau chùi. Bếp gồm 1 bếp từ và 1 bếp hồng ngoại giúp nấu ăn dễ dàng. Bảng điều khiển cảm ứng hiện đại, thao tác đơn giản. An toàn khi sử dụng với tính năng tự ngắt, khóa bảng điều khiển.', 34, N'SHB9104MT.jpg', NULL, N'NSX007', N'L007', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP091', N'Máy nước nóng Panasonic DH-4NP1VS 4500W', 5190000, N'Thiết kế màu bạc, nhỏ gọn sang trọng. Công suất 4500 W mạnh mẽ và cơ chế làm nóng trực tiếp giúp nóng nhanh chóng. Luồng nước mạnh mẽ nhờ bơm trợ lực vận hành siêu êm. Đảm bao cung cấp nguồn nước sạch cho máy nhờ van cấp nước có chức năng lọc. Vòi sen ion Ag+ kháng khuẩn kèm theo với 3 kiểu phun. Không lo chập cháy, đảm bảo an toàn về điện nhờ cầu dao ELCB. Vận hành ổn định nhờ cảm biến lưu lượng nước. Bảo vệ hệ thống, tăng tuổi thọ nhờ vỏ chống nước IP25. An toàn về nhiệt, không gây bỏng nhờ chế độ kiểm soát nhiệt độ. Vòi sen 3 chế độ phun, tiện lợi hơn khi sử dụng.', 42, N'DH-4NP1VS.jpg', NULL, N'NSX003', N'L009', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP092', N'Máy nước nóng Panasonic DH-3RL2VH 3.5KW', 2590000, N'Làm nóng nước cực nhanh và dễ sử dụng với cơ chế vận hành trực tiếp. Vỏ máy chống nước, bụi đạt chuẩn IP25 giúp bảo vệ các linh kiện bên trong, tăng độ bền cho máy. Tương thích điện từ EMC ngăn chặn tình trạng nhiễu sóng tivi hoặc ảnh hưởng điện đến các thiết bị khác trong nhà. Đảm bảo an toàn khi sử dụng với cầu dao chống rò điện ELCB. Cảm biến lưu lượng nước thông minh, tự ngắt khi lượng nước đầu ra ít hơn 2 lít/phút để tránh tình trạng cháy khi thanh nhiệt bị khô.', 25, N'DH-3RL2VH.jpg', NULL, N'NSX003', N'L009', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP093', N'Máy nước nóng Panasonic DH-4MP1VW 4500W', 4790000, N'Bơm trợ lực vận hành siêu êm, giúp dòng nước ổn định ở những nơi nước yếu. Làm nóng trực tiếp, cho thời gian sử dụng nước chưa đầy 1 phút. Cầu dao chống rò điện ELCB đảm bảo an toàn tuyệt đối cho cả nhà. Vỏ máy chống bụi, chống nước tiêu chuẩn IP25 giúp bảo vệ mạch điện và các linh kiện điện tử bên trong. Trang bị bộ tương thích điện từ EMC Dễ dàng thay đổi 3 chế độ phun với 1 nút nhấn - mang lại cảm giác tắm thoải mái theo ý thích. Vòi sen có tính kháng khuẩn ion Ag+ giúp luồng nước ra sạch hơn, tốt cho da. Tự ngắt gia nhiệt khi nước vào máy quá yếu, dưới 2 lít/phút.', 47, N'DH-4MP1VW.jpg', NULL, N'NSX003', N'L009', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP094', N'Máy nước nóng năng lượng mặt trời Kangaroo GD1818 180 lít', 12090000, N'Sử dụng năng lượng mặt trời, mang lại hiệu quả tiết kiệm điện. Dung tích bình chứa 180 lít, phù hợp gia đình 3 - 4 người. Bảo vệ sức khỏe người dùng với công nghệ Nano kháng khuẩn. Giữ nhiệt nước nóng đến 96 tiếng nhờ lớp bảo ôn Polyurethane. Thu nhiệt tốt bởi ống chân không công nghệ Nanomax 7 lớp. Chống bám cặn, an toàn với ruột bình làm bằng Inox SUS 304-2B cùng thanh Magie.', 9, N'GD1818.jpg', NULL, N'NSX008', N'L009', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP095', N'Máy nước nóng năng lượng mặt trời Kangaroo GD1414 140 lít', 10900000, N'Sử dụng năng lượng mặt trời, tiết kiệm điện. Dung tích 140 lít, đáp ứng nhu cầu cho gia đình có 2 - 3 người Bảo vệ sức khỏe người dùng nhờ công nghệ Nano kháng khuẩn. Giữ nhiệt nước nóng đến 96 tiếng bởi lớp bảo ôn Polyurethane. Thu nhiệt tốt với ống chân không công nghệ Nanomax 7 lớp. An toàn, chống bám cặn với ruột bình làm bằng Inox SUS 304-2B. Có thanh Magie giúp chống bám cặn cho lòng bình.', 17, N'GD1414.jpg', 8170000, N'NSX008', N'L009', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP096', N'Máy nước nóng năng lượng mặt trời Kangaroo GD1616 160 lít', 11090000, N'Sử dụng năng lượng mặt trời, mang lại hiệu quả tiết kiệm điện. Dung tích 160 lít, dành cho 3, 4 người sử dụng. Công nghệ Nano diệt khuẩn giúp bảo vệ sức khỏe người dùng. Lớp bảo ôn Polyurethane giúp giữ nước nóng đến 96 tiếng. Thu nhiệt tốt với ống chân không Nanomax 7 lớp. An toàn, độ bền cao với ruột bình bảo ôn làm bằng vật liệu Inox SUS 304-2B.', 31, N'GD1616.jpg', 8310000, N'NSX008', N'L009', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP097', N'Bình nước nóng Kangaroo 22 lít KG 73R2', 2890000, N'Thiết kế tinh tế, cơ chế làm nóng gián tiếp phù hợp với khí hậu miền Bắc. Dung tích 22 lít, đáp ứng nhu cầu sử dụng của 2 - 3 người. An toàn hơn với cầu dao chống rò điện ELCB. Vỏ bình có khả năng chống thấm IP24. Giữ nước nóng lâu hơn nhờ lớp cách nhiệt mật độ cao PU. Màn hình điện tử cho người dùng dễ dàng kiểm soát nhiệt độ. Thanh điện trở Steatite chống bám cặn, làm nóng nhanh và chịu được nước cứng.', 26, N'KG 73R2.jpg', 2690000, N'NSX008', N'L009', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP098', N'Máy nước nóng Kangaroo 22 lít KG 70A2', 2790000, N'An toàn với hệ thống đồng bộ TSS chống giật tích hợp cầu dao ELCB. Công nghệ Nano kháng khuẩn đảm bảo sự trong lành của nước tắm, bảo vệ làn da. Chống bám cặn, rò rỉ nước với lòng bình được tráng kim cương nhân tạo. Kéo dài thời gian giữ nhiệt nước nóng nhờ lớp cách nhiệt mật độ cao PU. Thuộc kiểu máy gián tiếp, có thể dùng chung nhiều thiết bị.', 24, N'KG 70A2.jpg', 2490000, N'NSX007', N'L009', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP099', N'Máy nước nóng Kangaroo 22 lít KG 72A2', 2590000, N'An toàn với các sự cố điện - hệ thống chống giật CSS, cầu dao chống rò điện ELCB. Dung tích 22 lít, đủ để đáp ứng nhu cầu cho khoảng 2 - 3 người. Nguồn nước sạch và an toàn với công nghệ Nano kháng khuẩn. Giữ nước nóng lâu hơn nhờ lớp cách nhiệt mật độ cao PU. Thuộc kiểu máy gián tiếp, có thể dùng chung nhiều thiết bị. Lòng bình tráng kim cương nhân tạo, giúp bình bền bỉ hơn. Chống bám cặn bảo vệ nước luôn sạch với thanh nhiệt mạ bạc kháng khuẩn.', 25, N'KG 72A2.jpg', NULL, N'NSX007', N'L009', N'Còn', 12)
INSERT [dbo].[SANPHAM] ([MASP], [TENSP], [DONGIABAN], [MOTA], [SOLUONG], [HINH], [GIAMGIA], [MANSX], [MATHIETBI], [TINHTRANG], [THOIGIANBH]) VALUES (N'SP100', N'Máy nước nóng Panasonic DH-4NTP1VM 4500W', 5190000, N'Thiết kế nhã nhặn, sang trọng. Làm nóng nước nhanh chóng với công suất 4500 W và hệ thống làm nóng trực tiếp. Lắp đặt bơm trợ lực làm luồng nước mạnh mẽ nhưng vận hành lại siêu êm. Hỗ trợ lọc nước thông qua van cấp nước. Vòi sen có 3 chế độ tiện lợi, đi kèm công nghệ ion Ag+ kháng khuẩn bảo vệ sức khỏe người tiêu dùng. Không lo chập cháy, đảm bảo an toàn về điện nhờ cầu dao ELCB. Vận hành ổn định nhờ cảm biến lưu lượng nước. Bảo vệ hệ thống, tăng tuổi thọ nhờ vỏ chống nước IP25. An toàn về nhiệt, không gây bỏng nhờ chế độ kiểm soát nhiệt độ.', 19, N'DH-4NTP1VM.jpg', NULL, N'NSX003', N'L009', N'Còn', 12)
GO
ALTER TABLE [dbo].[BAOHANH]  WITH CHECK ADD  CONSTRAINT [FK_BAOHANH2] FOREIGN KEY([MAKH])
REFERENCES [dbo].[KHACHHANG] ([MAKH])
GO
ALTER TABLE [dbo].[BAOHANH] CHECK CONSTRAINT [FK_BAOHANH2]
GO
ALTER TABLE [dbo].[BAOHANH]  WITH CHECK ADD  CONSTRAINT [FK_BAOHANH3] FOREIGN KEY([MAHD], [MASP])
REFERENCES [dbo].[CHITIETHOADON] ([MAHD], [MASP])
GO
ALTER TABLE [dbo].[BAOHANH] CHECK CONSTRAINT [FK_BAOHANH3]
GO
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETHOADON1] FOREIGN KEY([MAHD])
REFERENCES [dbo].[HOADON] ([MAHD])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CHITIETHOADON] CHECK CONSTRAINT [FK_CHITIETHOADON1]
GO
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETHOADON3] FOREIGN KEY([MASP])
REFERENCES [dbo].[SANPHAM] ([MASP])
GO
ALTER TABLE [dbo].[CHITIETHOADON] CHECK CONSTRAINT [FK_CHITIETHOADON3]
GO
ALTER TABLE [dbo].[CHITIETPHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETPHIEUNHAP1] FOREIGN KEY([MAPN])
REFERENCES [dbo].[PHIEUNHAP] ([MAPN])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CHITIETPHIEUNHAP] CHECK CONSTRAINT [FK_CHITIETPHIEUNHAP1]
GO
ALTER TABLE [dbo].[CHITIETPHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETPHIEUNHAP2] FOREIGN KEY([MASP])
REFERENCES [dbo].[SANPHAM] ([MASP])
GO
ALTER TABLE [dbo].[CHITIETPHIEUNHAP] CHECK CONSTRAINT [FK_CHITIETPHIEUNHAP2]
GO
ALTER TABLE [dbo].[DIEMDANH]  WITH CHECK ADD  CONSTRAINT [FK_DIEMDANH1] FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[DIEMDANH] CHECK CONSTRAINT [FK_DIEMDANH1]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON1] FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HOADON1]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON2] FOREIGN KEY([MAKH])
REFERENCES [dbo].[KHACHHANG] ([MAKH])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HOADON2]
GO
ALTER TABLE [dbo].[KHACHHANG]  WITH CHECK ADD  CONSTRAINT [FK_LKH1] FOREIGN KEY([MALOAIKH])
REFERENCES [dbo].[LOAIKHACHHANG] ([MALOAIKH])
GO
ALTER TABLE [dbo].[KHACHHANG] CHECK CONSTRAINT [FK_LKH1]
GO
ALTER TABLE [dbo].[NGUOIDUNG]  WITH CHECK ADD  CONSTRAINT [FK_NHANVIEN2] FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[NGUOIDUNG] CHECK CONSTRAINT [FK_NHANVIEN2]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [FK_NHANVIEN1] FOREIGN KEY([MACV])
REFERENCES [dbo].[CHUCVU] ([MACV])
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [FK_NHANVIEN1]
GO
ALTER TABLE [dbo].[PHANQUYEN]  WITH CHECK ADD  CONSTRAINT [FK_PHANQUYEN1] FOREIGN KEY([MANHOM])
REFERENCES [dbo].[NHOMNGUOIDUNG] ([MANHOM])
GO
ALTER TABLE [dbo].[PHANQUYEN] CHECK CONSTRAINT [FK_PHANQUYEN1]
GO
ALTER TABLE [dbo].[PHANQUYEN]  WITH CHECK ADD  CONSTRAINT [FK_PHANQUYEN2] FOREIGN KEY([MAMH])
REFERENCES [dbo].[MANHINH] ([MAMH])
GO
ALTER TABLE [dbo].[PHANQUYEN] CHECK CONSTRAINT [FK_PHANQUYEN2]
GO
ALTER TABLE [dbo].[PHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUNHAP1] FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[PHIEUNHAP] CHECK CONSTRAINT [FK_PHIEUNHAP1]
GO
ALTER TABLE [dbo].[PHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUNHAP2] FOREIGN KEY([MANSX])
REFERENCES [dbo].[NHASANXUAT] ([MANSX])
GO
ALTER TABLE [dbo].[PHIEUNHAP] CHECK CONSTRAINT [FK_PHIEUNHAP2]
GO
ALTER TABLE [dbo].[QL_NGUOIDUNGNHOMNGUOIDUNG]  WITH CHECK ADD  CONSTRAINT [FK_qLNguoiDung1] FOREIGN KEY([TENDN])
REFERENCES [dbo].[NGUOIDUNG] ([TENDN])
GO
ALTER TABLE [dbo].[QL_NGUOIDUNGNHOMNGUOIDUNG] CHECK CONSTRAINT [FK_qLNguoiDung1]
GO
ALTER TABLE [dbo].[QL_NGUOIDUNGNHOMNGUOIDUNG]  WITH CHECK ADD  CONSTRAINT [FK_qLNguoiDung2] FOREIGN KEY([MANHOM])
REFERENCES [dbo].[NHOMNGUOIDUNG] ([MANHOM])
GO
ALTER TABLE [dbo].[QL_NGUOIDUNGNHOMNGUOIDUNG] CHECK CONSTRAINT [FK_qLNguoiDung2]
GO
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD  CONSTRAINT [FK_MANSX_NSX] FOREIGN KEY([MANSX])
REFERENCES [dbo].[NHASANXUAT] ([MANSX])
GO
ALTER TABLE [dbo].[SANPHAM] CHECK CONSTRAINT [FK_MANSX_NSX]
GO
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD  CONSTRAINT [FK_MATHIETBI_LTB] FOREIGN KEY([MATHIETBI])
REFERENCES [dbo].[LOAITHIETBI] ([MATHIETBI])
GO
ALTER TABLE [dbo].[SANPHAM] CHECK CONSTRAINT [FK_MATHIETBI_LTB]
GO
