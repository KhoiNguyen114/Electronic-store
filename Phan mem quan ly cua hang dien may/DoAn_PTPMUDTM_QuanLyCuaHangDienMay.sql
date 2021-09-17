﻿CREATE DATABASE DOANPTPMUNGDUNGTHONGMINH_QUANLYCUAHANGDIENMAY
USE DOANPTPMUNGDUNGTHONGMINH_QUANLYCUAHANGDIENMAY
drop database DOANPTPMUNGDUNGTHONGMINH_QUANLYCUAHANGDIENMAY

------------------------------- TABLE : LOẠI THIẾT BỊ  -------------------------------//
--- VÍ DỤ MÁY GIẶT, MÁY LẠNH, TỦ LẠNH, MÁY SẤY
CREATE TABLE LOAITHIETBI
(
	MATHIETBI NVARCHAR(10) PRIMARY KEY,
	TENTHIETBI NVARCHAR(500),
)

------------------------------- TABLE : NHÀ SẢN XUẤT -------------------------------//
---- VÍ DỤ TOSHIBA, DAIKIN, PANASONIC, LG
CREATE TABLE NHASANXUAT
(
	MANSX NVARCHAR(10) PRIMARY KEY,
	TENNSX NVARCHAR(500),
	DIACHI NVARCHAR(500),
	SDT NVARCHAR(12)
)


------------------------------- TABLE : SẢN PHẨM -------------------------------//
CREATE TABLE SANPHAM
(
	MASP NVARCHAR(10) PRIMARY KEY,
	TENSP NVARCHAR(500),
	DONGIABAN FLOAT,
	MOTA NVARCHAR(MAX),
	SOLUONG INT,
	HINH NVARCHAR(500),
	--DSHINH NVARCHAR(500),
	GIAMGIA FLOAT,
	MANSX NVARCHAR(10),
	MATHIETBI NVARCHAR(10),
	TINHTRANG NVARCHAR(100),	
	THOIGIANBH INT,
)

------------------------------- TABLE : LOAIKHACHHANG -------------------------------//
CREATE TABLE LOAIKHACHHANG
(
	MALOAIKH NVARCHAR(10) NOT NULL,
	TENLOAI NVARCHAR(500),
	GIAMGIA	INT,
	PRIMARY KEY(MALOAIKH)
)
GO

------------------------------- TABLE : KHÁCH HÀNG -------------------------------//
CREATE TABLE KHACHHANG
(
	MAKH INT IDENTITY(1,1) PRIMARY KEY,
	TENKH NVARCHAR(500),
	GIOITINH NVARCHAR(5),
	NGAYSINH DATE,
	SDT NVARCHAR(12),
	DIACHI NVARCHAR(500),
	TENDN NVARCHAR(50),
	MATKHAU NVARCHAR(20),
	MALOAIKH NVARCHAR(10),
)


------------------------------- TABLE : PHIẾU NHẬP -------------------------------//
CREATE TABLE PHIEUNHAP
(
	MAPN INT IDENTITY(1,1),
	MANV NVARCHAR(10) NOT NULL,
	MANSX NVARCHAR(10) NOT NULL,
	NGAYLAPPN DATE,
	TONGTIENPN FLOAT,
	TINHTRANG NVARCHAR(50),
	PRIMARY KEY(MAPN)
)
GO

------------------------------- TABLE : CHI TIẾT PHIẾU NHẬP -------------------------------//
CREATE TABLE CHITIETPHIEUNHAP
(
	MAPN INT,
	MASP NVARCHAR(10),
	SOLUONG INT,
	DONGIANHAP FLOAT,
	THANHTIEN FLOAT,
	PRIMARY KEY(MAPN, MASP)
)
GO

------------------------------- TABLE : BẢO HÀNH -------------------------------//
CREATE TABLE BAOHANH
(
	MABH INT IDENTITY(1,1),
	MAHD INT,
	MAKH INT,
	MASP NVARCHAR(10),
	NGAYBH DATE,
	GHICHU NVARCHAR(MAX),
	TINHTRANG NVARCHAR(500),
	PRIMARY KEY(MABH)
)
GO

------------------------------- TABLE : HÓA ĐƠN -------------------------------//
CREATE TABLE HOADON
(
	MAHD INT IDENTITY(1,1),
	MANV NVARCHAR(10) NOT NULL,
	MAKH INT NOT NULL,
	NGAYLAPHD DATE,
	TONGTIENHD FLOAT,
	THANHTOAN FLOAT,
	TINHTRANG NVARCHAR(50),
	PRIMARY KEY(MAHD)
)
GO

------------------------------- TABLE : CHI TIẾT HÓA ĐƠN -------------------------------//
CREATE TABLE CHITIETHOADON
(
	MAHD INT,	
	MASP NVARCHAR(10) NOT NULL,
	SOLUONG INT,
	DONGIABAN FLOAT,
	THANHTIEN FLOAT,
	PRIMARY KEY(MAHD, MASP)
)
GO

------------------------------- TABLE : NGƯỜI DÙNG -------------------------------//

CREATE TABLE NGUOIDUNG
(
	TENDN NVARCHAR(20) NOT NULL,
	MATKHAU NVARCHAR(20) NULL,
	MANV NVARCHAR(10) NOT NULL,
	PRIMARY KEY(TENDN)
)
GO


------------------------------- TABLE : NHÂN VIÊN -------------------------------//
CREATE TABLE NHANVIEN
(
	MANV NVARCHAR(10) NOT NULL,
	TENNV NVARCHAR(100),
	GIOITINH NVARCHAR(5),
	NGAYSINH DATE,
	DIENTHOAI NVARCHAR(12),
	DIACHI NVARCHAR(500),
	MACV NVARCHAR(10) NOT NULL,
	NGAYVL DATE,
	PRIMARY KEY(MANV)
)
GO

------------------------------- TABLE : MÀN HÌNH -------------------------------//
CREATE TABLE MANHINH
(
	MAMH NVARCHAR(50) NOT NULL,
	TENMH NVARCHAR(100) NOT NULL,
	PRIMARY KEY(MAMH)
)
------------------------------- TABLE : NHÓM NGƯỜI DÙNG -------------------------------//
CREATE TABLE NHOMNGUOIDUNG
(
	MANHOM VARCHAR(20) NOT NULL,
	TENNHOM NVARCHAR(50),
	GHICHU	NVARCHAR(50) NULL
	PRIMARY KEY(MANHOM)
)
------------------------------- TABLE : QUẢN LÝ NGƯỜI DÙNG NHÓM NGƯỜI DÙNG -------------------------------//
CREATE TABLE QL_NGUOIDUNGNHOMNGUOIDUNG
(
	TENDN NVARCHAR(20) NOT NULL,
	MANHOM VARCHAR(20) NOT NULL,
	GHICHU  NVARCHAR(200) NULL,
	PRIMARY KEY(MANHOM,TENDN)
)
------------------------------- TABLE : PHÂN QUYỀN -------------------------------//
CREATE TABLE PHANQUYEN
(
	MANHOM VARCHAR(20) NOT NULL,
	MAMH NVARCHAR(50) NOT NULL,
	COQUYEN BIT
	PRIMARY KEY(MANHOM,MAMH)
)
GO

------------------------------- TABLE : CHỨC VỤ -------------------------------//
CREATE TABLE CHUCVU
(
	MACV NVARCHAR(10) NOT NULL,
	TENCV NVARCHAR(100),
	LUONGCB FLOAT,
	PRIMARY KEY(MACV)
)
GO


------------------------------- TABLE : ĐIỂM DANH -------------------------------//
CREATE TABLE DIEMDANH
(
	MANV NVARCHAR(10) NOT NULL,
	NGAYDD DATE,
	PRIMARY KEY(MANV,NGAYDD)
)




ALTER TABLE BAOHANH
	ADD CONSTRAINT FK_BAOHANH2 FOREIGN KEY(MAKH) REFERENCES KHACHHANG(MAKH)
ALTER TABLE BAOHANH
	ADD CONSTRAINT FK_BAOHANH3 FOREIGN KEY(MAHD,MASP) REFERENCES CHITIETHOADON(MAHD,MASP)

ALTER TABLE SANPHAM
	ADD CONSTRAINT FK_MANSX_NSX FOREIGN KEY (MANSX) REFERENCES NHASANXUAT(MANSX)  
ALTER TABLE SANPHAM
	ADD CONSTRAINT FK_MATHIETBI_LTB FOREIGN KEY (MATHIETBI) REFERENCES LOAITHIETBI(MATHIETBI) 
	--- ON DELETE CASCADE LÀ LỆNH TỰ ĐỘNG XÓA ĐI CÁC DÒNG TRONG BẢNG CÓ KHÓA NGOẠI NÀY KHI XÓA 1 DÒNG TRONG BẢNG KHÁC MÀ KHÓA NGOẠI NÀY THAM CHIẾU TỚI
ALTER TABLE NGUOIDUNG
	ADD CONSTRAINT FK_NHANVIEN2 FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)

ALTER TABLE QL_NGUOIDUNGNHOMNGUOIDUNG
	ADD CONSTRAINT FK_qLNguoiDung1 FOREIGN KEY(TENDN) REFERENCES NGUOIDUNG(TENDN)
ALTER TABLE QL_NGUOIDUNGNHOMNGUOIDUNG
	ADD CONSTRAINT FK_qLNguoiDung2 FOREIGN KEY(MANHOM) REFERENCES NHOMNGUOIDUNG(MANHOM)

ALTER TABLE PHANQUYEN
	ADD CONSTRAINT FK_PHANQUYEN1 FOREIGN KEY(MANHOM) REFERENCES NHOMNGUOIDUNG(MANHOM)
ALTER TABLE PHANQUYEN
	ADD CONSTRAINT FK_PHANQUYEN2 FOREIGN KEY(MAMH) REFERENCES MANHINH(MAMH)


ALTER TABLE NHANVIEN
	ADD CONSTRAINT FK_NHANVIEN1 FOREIGN KEY(MACV) REFERENCES CHUCVU(MACV)

ALTER TABLE DIEMDANH
	ADD CONSTRAINT FK_DIEMDANH1 FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)

ALTER TABLE HOADON
	ADD CONSTRAINT FK_HOADON1 FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)
ALTER TABLE HOADON
	ADD CONSTRAINT FK_HOADON2 FOREIGN KEY(MAKH) REFERENCES KHACHHANG(MAKH) 

ALTER TABLE CHITIETHOADON
	ADD CONSTRAINT FK_CHITIETHOADON1 FOREIGN KEY(MAHD) REFERENCES HOADON(MAHD) ON DELETE CASCADE 
ALTER TABLE CHITIETHOADON
	ADD CONSTRAINT FK_CHITIETHOADON3 FOREIGN KEY(MASP) REFERENCES SANPHAM(MASP)

ALTER TABLE PHIEUNHAP
	ADD CONSTRAINT FK_PHIEUNHAP1 FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV) 
ALTER TABLE PHIEUNHAP
	ADD CONSTRAINT FK_PHIEUNHAP2 FOREIGN KEY(MANSX) REFERENCES NHASANXUAT(MANSX) 

ALTER TABLE CHITIETPHIEUNHAP
	ADD CONSTRAINT FK_CHITIETPHIEUNHAP1 FOREIGN KEY(MAPN) REFERENCES PHIEUNHAP(MAPN) ON DELETE CASCADE 
ALTER TABLE CHITIETPHIEUNHAP
	ADD CONSTRAINT FK_CHITIETPHIEUNHAP2 FOREIGN KEY(MASP) REFERENCES SANPHAM(MASP) 

ALTER TABLE KHACHHANG
	ADD CONSTRAINT FK_LKH1 FOREIGN KEY(MALOAIKH) REFERENCES LOAIKHACHHANG(MALOAIKH)	


-----TRIGGER----------------------


------THÊM DỮ LIỆU VÀO BẢNG LOẠI KHÁCH HÀNG
INSERT INTO LOAIKHACHHANG VALUES('LKH001',N'Vãng lai',0)
INSERT INTO LOAIKHACHHANG VALUES('LKH002',N'Thân thiết',5)
INSERT INTO LOAIKHACHHANG VALUES('LKH003',N'VIP',10)


------THÊM DỮ LIỆU VÀO BẢNG KHÁCH HÀNG
SET DATEFORMAT DMY
INSERT INTO KHACHHANG VALUES (/*'KH001',*/N'Nguyễn Huy Khôi Nguyên',N'Nam','25/10/2000','0927551446',N'140 Lê Trọng Tấn, Phường Tây Thạnh, Quận Tân Phú, TP.HCM','Nguyen123','123','LKH001')
INSERT INTO KHACHHANG VALUES (/*'KH002',*/N'Khương Tử Nha',N'Nam','04/06/1992','076854112',N'77/2 Lê Hồng Phong, Phường Phú Tân, Bà Rịa - Vũng Tàu','Nha123','123','LKH002')
INSERT INTO KHACHHANG VALUES (/*'KH003',*/N'Cô Cô',N'Nữ','17/03/1979','088756147',N'156/2/22 Đặng Thúc Kháng, Phường Thạnh Xuân, Bình Thuận','CoCo','123','LKH003')
INSERT INTO KHACHHANG VALUES (/*'KH004',*/N'Đinh Công Mạnh',N'Nam','28/05/1999','096554872',N'201 Lê Đại Hành, Phường Tinh Thế, Quận Bình Thạnh, TPHCM','Manh123','123','LKH002')
INSERT INTO KHACHHANG VALUES (/*'KH005',*/N'Lưu Bị',N'Nam','27/06/1994','0946385742',N'422 Tây Thạnh, Tân Phú, TPHCM','LuuBi123','123','LKH003')
INSERT INTO KHACHHANG VALUES (/*'KH006',*/N'Quan Vũ',N'Nam','08/10/1991','0757482345',N'249 Nguyễn Thị Minh Khai, Quận 1, TPHCM','QuanVu123','123','LKH001')
INSERT INTO KHACHHANG VALUES (/*'KH007',*/N'Đại Kiều',N'Nữ','28/02/1985','0912759230',N'792 Phạm Văn Chiêu,Gò Vấp, TPHCM','DaiKieu123','123','LKH001')
INSERT INTO KHACHHANG VALUES (/*'KH008',*/N'Mã Siêu',N'Nam','18/09/1998','0944781450',N'192 Nam Kì Khởi Nghĩa,Quận 9, TPHCM','MaSieu123','123','LKH002')
INSERT INTO KHACHHANG VALUES (/*'KH009',*/N'Điêu Thuyền',N'Nữ','12/01/1988','0955887142',N'225 Lê Đức Thọ, Gò Vấp, TPHCM','DieuThuyen123','123','LKH001')
INSERT INTO KHACHHANG VALUES (/*'KH010',*/N'Tôn Thượng Hương',N'Nữ','02/10/2000','0908124751',N'140 Lê Trọng Tấn ,Tân Phú, TP.HCM','Huong123','123','LKH003')


------THÊM DỮ LIỆU VÀO BẢNG LOẠI THIẾT BỊ
INSERT INTO LOAITHIETBI VALUES('L001',N'Tủ lạnh')
INSERT INTO LOAITHIETBI VALUES('L002',N'Máy giặt')
INSERT INTO LOAITHIETBI VALUES('L003',N'Máy sấy')
INSERT INTO LOAITHIETBI VALUES('L004',N'Tủ đông')
INSERT INTO LOAITHIETBI VALUES('L005',N'Máy lạnh')
INSERT INTO LOAITHIETBI VALUES('L006',N'Loa')
INSERT INTO LOAITHIETBI VALUES('L007',N'Bếp từ')
INSERT INTO LOAITHIETBI VALUES('L008',N'Máy lọc nước')
INSERT INTO LOAITHIETBI VALUES('L009',N'Máy nước nóng')
INSERT INTO LOAITHIETBI VALUES('L010',N'Tivi')


------THÊM DỮ LIỆU VÀO BẢNG NHÀ SẢN XUẤT
INSERT INTO NHASANXUAT VALUES('NSX001',N'Toshiba',N'Số 12, Đường 15, Khu phố 4, Phường Linh Trung, Quận Thủ Đức, Tp. Hồ Chí Minh','0982177226')
INSERT INTO NHASANXUAT VALUES('NSX002',N'LG',N'Lô CN2, KCN Tràng Duệ, xã Lê Lợi, huyện An Dương, thành phố Hải Phòng','099928162')
INSERT INTO NHASANXUAT VALUES('NSX003',N'Panasonic',N'Lô J1-J2, Khu công nghiệp Thăng Long, xã Kim Chung, huyện Đông Anh, Tp. Hà Nội','02437677360')
INSERT INTO NHASANXUAT VALUES('NSX004',N'Daikin',N'201-203 Cách Mạng Tháng Tám, Phường 4, Quận 3, Thành phố Hồ Chí Minh','0785429717')
INSERT INTO NHASANXUAT VALUES('NSX005',N'Sony',N'163 Quang Trung, Phường 10, Gò Vấp, Thành phố Hồ Chí Minh','0909636798')
INSERT INTO NHASANXUAT VALUES('NSX006',N'SamSung',N'Số 2, đường Hải Triều, Phường Bến Nghé, Quận 1, TP. Hồ Chí Minh','02839157310')
INSERT INTO NHASANXUAT VALUES('NSX007',N'Sunhouse',N'Số 85, đường Phạm Ngũ Lão, Phường Bến Nghé, Quận 1, TP. Hồ Chí Minh','0932055472')
INSERT INTO NHASANXUAT VALUES('NSX008',N'Kangaroo',N'Số 108, đường Cống Quỳnh, Phường Bến Nghé, Quận 1, TP. Hồ Chí Minh','0904421875')

------THÊM DỮ LIỆU VÀO BẢNG SẢN PHẨM
INSERT INTO SANPHAM VALUES('SP001',N'Smart Tivi Sony 32 inch KDL-32W600D',6090000,N'Công nghệ 4K X-Reality Pro cho màu sắc rõ nét, tăng cường độ nét hình ảnh, nâng cấp chất lượng hình ảnh gần HD nhất. Công nghệ Advanced Contrast Enhancer nâng cao tương phản. Công nghệ Dolby Digital và Clear Phase cho âm thanh bùng nổ và mạnh mẽ. Giao diện tiếng Việt dễ sử dụng với nhiều ứng dụng giải trí như: Netflix, Youtube, Nhaccuatui, Zing TV, FPT Play, Clip TV, Zing MP3, Trình duyệt web. Tivi độ phân giải HD cho hình ảnh sắc nét chân thực.',15,N'KDL-32W600D.jpg',/*N'KDL-32W600D-1.jpg, KDL-32W600D-2.jpg, KDL-32W600D-3.jpg',*/5790000,'NSX005','L010',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP002',N'Smart Tivi Samsung 43 inch UA43T6500',7900000,N'Thiết kế sang trọng, trang nhã với độ mỏng tối ưu cùng độ phân giải Full HD. Dải màu sắc phong phú kiến tạo hình ảnh sống động nổi bật từ công nghệ HDR. Quét ảnh tăng cường độ sắc nét cho trải nghiệm trung thực với công nghệ Digital Clean View. Khung hình trở nên sống động và chân thực nhờ công nghệ PurColor. Nâng cấp độ tương phản qua công nghệ Contrast Enhancer. Âm thanh trong trẻo với công nghệ âm thanh Dolby Digital Plus. Hệ điều hành Tizen OS có giao diện phẳng, dễ sử dụng.',18,N'UA43T6500-1.jpg',/*N'UA43T6500.jpg, UA43T6500-2.jpg, UA43T6500-3.jpg',*/7590000,'NSX006','L010',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP003',N'Smart Tivi Samsung 4K 50 inch UA50TU8100',11500000,N'Kích thước tivi 50 inch, hiện đại, tinh tế với màn hình không viền 3 cạnh. Hình ảnh sắc nét, độ tương phản với độ phân giải Ultra HD 4K  và công nghệ HDR10+. Màu sắc sống động như thực qua công nghệ Crystal Display và công nghệ UHD Dimming. Nâng cấp hình ảnh có chất lượng thấp lên gần chuẩn 4K với bộ xử lý Crystal 4K. Hệ điều hành Tizen OS có giao diện đơn giản và kho ứng dụng đa dạng. Điều khiển tivi thông minh bằng điện thoại qua ứng dụng SmartThings. Trình chiếu màn hình điện thoại lên tivi nhanh chóng qua tính năng Tap View và Airplay 2.',25,N'UA50TU8100-3.jpg',/*N'UA50TU8100.jpg, UA50TU8100-1.jpg, UA50TU8100-2.jpg',*/10590000,'NSX006','L010',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP004',N'Android Tivi Sony 4K 49 inch KD-49X8000H',15900000,N'Thiết kế sang trọng, chân đế bằng kim loại, kích thước tivi 49 inch, độ phân giải Ultra HD 4K. Giảm nhiễu hình ảnh, màu sắc và độ tương phản được tăng cường nhờ bộ xử lí chip X1 4K HDR Processor. Dải màu rộng hơn, hình ảnh hiển thị tự nhiên và chính xác nhờ công nghệ TRILUMINOS Display. Dải tương phản động và dải sắc màu hiển thị mở rộng nhờ công nghệ Dolby Vision. Âm thanh đa chiều mạnh mẽ nhờ công nghệ âm thanh Dolby Atmos. Dễ dàng điều khiển tivi bằng điện thoại với ứng dụng Android TV. Chia sẻ nội dung trên màn hình điện thoại lên tivi nhờ Apple Homekit/Apple Airplay.',30,N'KD-49X8000H.jpg',/*N'KD-49X8000H-1.jpg, KD-49X8000H-2.jpg, KD-49X8000H-2.jpg',*/NULL,'NSX005','L010',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP005',N'Android Tivi Sony 4K 65 inch KD-65X7500H',22900000,N'Thiết kế tinh tế, chân đế hình chữ V vững chắc, kích thước tivi 65 inch, độ phân giải Ultra HD 4K. Tăng cường màu sắc, độ tương phản và độ nét cho hình ảnh nhờ bộ xử lí chip X1 4K Processor. Dải màu rộng hơn cho hình ảnh hiển thị tự nhiên và chính xác nhờ công nghệ TRILUMINOS Display. Tăng cường độ tương phản hình ảnh, màu trắng được trắng hơn, màu đen sâu hơn nhờ công nghệ HDR10. Thời gian sử dụng và trải nghiệm bền bỉ hơn nhờ X-Protection PRO. Cải thiện âm trầm rõ mạnh, âm cao được trong hơn nhờ loa Bass Reflex Speaker.Chiếu màn hình điện thoại lên tivi bằng Chromecast. Chiếu màn hình điện thoại lên tivi bằng Chromecast.',10,N'KD-65X7500H.jpg',/*N'KD-65X7500H-1.jpg, KD-65X7500H-2.jpg, KD-65X7500H-3.jpg',*/21990000,'NSX005','L010',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP006',N'Smart Tivi NanoCell LG 4K 55 inch 55NANO86TNA',20590000,N'Kích thước 55 inch cùng độ phân giải 4K giúp hình ảnh rõ ràng, sắc nét.. Góc nhìn rộng với màu sắc hình ảnh tinh khiết dưới mọi góc nhìn với tấm nền IPS và NanoCell. Tối ưu chất lượng hình ảnh với chip xử lý α7 Gen 3 và công nghệ 4K Upscaler. Tăng cường độ sáng và độ tương phản, giúp hình ảnh rực rỡ với công nghệ HDR10+ và HLG. Đắm chìm trong thế giới âm thanh với công nghệ Ultra Surround. Điều khiển tivi bằng điện thoại với ứng dụng LG TV Plus. Chiếu màn hình điện thoại Android, iPhone lên tivi qua tính năng AirPlay 2 và Screen Mirroring. ',16,N'55NANO86TNA.jpg',/*N'55NANO86TNA-1.jpg, 55NANO86TNA-2.jpg, 55NANO86TNA-3.jpg',*/19590000,'NSX002','L010',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP007',N'Smart Tivi Màn Hình Xoay The Sero QLED Samsung 4K 43 inch QA43LS05T',28900000,N'Thiết kế xoay thời thượng, di chuyển dễ dàng với bánh xe, màn hình 43 inch, độ phân giải 4K. Nâng cấp hình ảnh lên gần chuẩn 4K với bộ xử lý Quantum 4K và trí tuệ nhân tạo Al. Truyền tải trọn vẹn 100% dải màu với công nghệ màn hình chấm lượng tử Quantum Dot. Độ sáng vượt trội, hình ảnh hiển thị đẹp hơn với công nghệ Quantum HDR. Tối ưu độ chi tiết cho hình ảnh với công nghệ Supreme UHD Dimming. Hệ thống âm thanh đa chiều mạnh mẽ với công nghệ Dolby Digital Plus, công suất 60 W và 4.1 kênh. Công nghệ AVA điều chỉnh âm lượng hội thoại theo điều kiện môi trường xung quanh.',32,N'QA43LS05T.jpg',/*N'QA43LS05T-1.jpg, QA43LS05T-2.jpg, QA43LS05T-3.jpg',*/NULL,'NSX006','L010',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP008',N'Smart Tivi OLED LG 8K 88 inch 88ZXPTA',690000000,N'Trải nghiệm sức mạnh của điểm ảnh OLED tự phát sáng với tuyệt tác thiết kế độc đáo, sang trọng. Hình ảnh hiển thị siêu sắc nét đến từng chi tiết nhờ sức mạnh của độ phân giải 8K và màn hình 88 inch. Nâng cấp trải nghiệm thưởng thức tivi của bạn bằng bộ xử lý thông minh α9 AI 8K thế hệ thứ 3. Tiện lợi, tiết kiệm thời gian khi điều khiển các thiết bị bằng giọng nói với AI ThinQ ngay trên tivi. Tận hưởng các bộ phim điện ảnh một cách chân thực và đúng chất nhất với các công nghệ Dolby Vision, Dolby Atmos, Filmmaker Mode. Tiện dụng và khám phá đa dạng thể loại giải trí với hệ điều hành WebOS. Trải nghiệm chơi game với tiêu chuẩn được nâng cao nhờ tương thích G-Sync. Điều khiển tivi dễ dàng bằng điện thoại cùng ứng dụng LG TV Plus, hỗ trợ nhiều cổng kết nối quen thuộc.',5,N'88ZXPTA.jpg',/*N'88ZXPTA-1.jpg, 88ZXPTA-2.jpg, 88ZXPTA-3.jpg',*/550000000,'NSX002','L010',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP009',N'Android Tivi OLED Sony 4K 65 inch KD-65A9G',69900000,N'Màn hình OLED, 65 inch với viền cực mỏng chỉ 0.2 cm, độ dầy phần mỏng nhất tivi chỉ 0,6 cm. Độ phân giải 4K nét gấp 4 lần Full HD, đi kèm công nghệ HDR tăng độ tương phản. Tăng dải màu rộng hơn 50% so với màn hình LCD qua công nghệ màn hình chấm lượng tử TRILUMINOS. Âm thanh phát ra từ màn hình qua Acoustic Surface có hỗ trợ 2 loa subwoofer. Hệ điều hành Android 8.0 của Google kho ứng dụng phong phú, đi kèm remote thông minh hỗ trợ tìm kiếm và điều khiển bằng giọng nói bằng tiếng Việt cả 3 miền nhờ có hỗ trợ Google Assistant. Điều khiển tivi bằng điện thoại qua ứng dụng TV Sideview. Hỗ trợ chiếu màn hình điện thoại Android và iOS lên tivi qua Screen Mirroring.',5,N'KD-65A9G.jpg',/*N'KD-65A9G-1.jpg, KD-65A9G-2.jpg, KD-65A9G-3.jpg',*/6900000,'NSX005','L010',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP010',N'Smart Tivi Samsung 43 inch UA43R6000',7450000,N'Thiết kế nhỏ gọn đi cùng với màn hình 43 inch. Độ phân giải Full HD rõ nét gấp 2 lần so với độ phân giải HD. Màu sắc sống động với công nghệ PurColor. Hình ảnh có độ tương phản cao với công nghệ Micro Dimming Pro',10,N'hinh1.jpg',/*N'hinh1-1.jpg, hinh1-2.jpg, hinh1-3.jpg',*/8690000,'NSX006','L010',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP011',N'Tủ lạnh Panasonic Inverter 268 lít NR-BL300PKVN',10490000,N'Công nghệ Inverter cho khả năng vận hành êm ái, nhiệt độ ổn định. Cảm biến Econavi hiện đại, góp phần tiết kiệm đáng kể chi phí điện hàng tháng. Công nghệ làm lạnh Panorama với luồng khí lạnh vòng cung lan tỏa đồng đều đến mọi nơi trong tủ',6,N'hinh2.jpg',/*N'hinh2-1.jpg, hinh2-2.jpg, hinh2-3.jpg. hinh2-4.jpg',*/NULL,'NSX003','L001',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP012',N'Tủ lạnh Toshiba Inverter 180 lít GR-B22VU UKG',5690000,N'Tiết kiệm điện, tủ êm ái với công nghệ biến tần Inverter. Làm lạnh thực phẩm toàn diện nhờ hệ thống khí lạnh vòng cung. Diệt khuẩn và khử mùi hiệu quả nhờ công nghệ Ag+ Bio. Bảo quản thịt cá tươi ngon, ăn trong ngày không cần rã đông với ngăn đông mềm -1 độ Ultra Cooling Zone. Cửa tủ phủ sơn bóng sáng đẹp.',10,N'GR-B22VU UKG.jpg',/*N'GR-B22VU UKG-1.jpg, GR-B22VU UKG-2.jpg, GR-B22VU UKG-3.jpg',*/NULL,'NSX001','L001',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP013',N'Tủ lạnh LG Inverter 187 lít GN-L205S',4920000,N'Công nghệ biến tần Inverter giúp tiết kiệm điện, máy chạy êm, bền. Hệ thống khí lạnh đa chiều giúp thực phẩm tươi ngon. Ngăn rau quả giúp cân bằng độ ẩm.',20,N'GN-L205S.jpg',/*N'GN-L205S-1.jpg, GN-L205S-2.jpg, GN-L205S-3.jpg.',*/3920000,'NSX002','L001',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP014',N'Tủ lạnh Panasonic Inverter 152 lít NR-BA178PKV1',5890000,N'Công nghệ làm lạnh Panorama độc quyền Panasonic giúp thực phẩm luôn tươi ngon. Công nghệ kháng khuẩn khử mùi bằng tinh thể bạc tiêu diệt vi khuẩn và mùi hôi khó chịu. Tủ lạnh tiết kiệm điện năng hiệu quả với công nghệ Inverter kết hợp cảm biến Econavi. Hộc rau quả cung cấp độ ẩm cho rau quả tươi lâu trong thời gian dài.',15,N'NR-BA178PKV1.jpg',/*N'NR-BA178PKV1-1.jpg, NR-BA178PKV1-2.jpg, NR-BA178PKV1-3.jpg.',*/4710000,'NSX003','L001',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP015',N'Tủ lạnh Samsung Inverter 307 lít RB30N4170BUSV',15790000,N'Tiết kiệm điện năng tiêu thụ với công nghệ Digital Inverter. Hơi lạnh lan toả đều khắp với công nghệ làm lạnh dạng vòm. Lọc sạch không khí, ngăn ngừa mùi hôi khó chịu với bộ lọc khử mùi than hoạt tính. Bảo quản thịt cá tươi ngon, ăn trong ngày không cần rã đông với ngăn đông mềm -1 độ C Optimal Fresh Zone. Tiện lợi hơn với khay lấy nước bên ngoài và hộp đá xoay di động. Thiết kế hiện đại cùng dung tích 307 lít phù hợp với gia đình có từ 3 đến 4 thành viên.',30,N'RB30N4170BUSV.jpg',/*N'RB30N4170BUSV-1.jpg, RB30N4170BUSV-2.jpg, RB30N4170BUSV-3.jpg.',*/13390000,'NSX006','L001',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP016',N'Tủ lạnh Panasonic Inverter 290 lít NR-BV320GKVN',15590000,N'Bảo quản thịt cá không cần rã đông, diệt khuẩn 99,99% với Ngăn đông mềm kháng khuẩn Prime Fresh+ thế hệ mới. Tiết kiệm điện tối đa với bộ 3 công nghệ Inverter, Mutlti Control và cảm biến thông minh Econavi. Giữ ẩm rau quả tươi ngon với ngăn Fresh Safe. Làm lạnh đồng đều các ngăn tủ với công nghệ Panorama. Diệt khuẩn, đánh bay mùi nhờ công nghệ Ag Clean với tinh thể bạc Ag+.',30,N'NR-BV320GKVN.jpg',/*N'NR-BV320GKVN-1.jpg, NR-BV320GKVN-2.jpg, NR-BV320GKVN-3.jpg',*/NULL,'NSX003','L001',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP017',N'Tủ lạnh Toshiba Inverter 511 lít GR-RF610WE-PGV(22)-XK',25990000,N'Sử dụng tiết kiệm điện, vận hành êm ái, đồng bộ nhờ công nghệ Origin Inverter. Giữ nhiệt tối ưu, bảo quản thực phẩm tươi ngon nhờ tấm hợp kim công nghệ AlloyCooling. Kháng khuẩn, khử mùi hoàn hảo cùng công nghệ PureBio với tia Plasma cực mạnh. Thay đổi chế độ bảo quản thực phẩm linh hoạt với ngăn cấp đông Flexible Zone. Tăng cường hơi ẩm, giữ rau củ tươi lâu trong ngăn Moisture Zone.',12,N'GR-RF610WE-PGV(22)-XK.jpg',/*N'GR-RF610WE-PGV(22)-XK-1.jpg, GR-RF610WE-PGV(22)-XK-2.jpg, GR-RF610WE-PGV(22)-XK-3.jpg.',*/NULL,'NSX001','L001',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP018',N'Tủ lạnh LG Inverter 613 lít GR-B247WB',22990000,N'Tiết kiệm điện hiệu quả đến 32%, làm lạnh ổn định nhờ công nghệ mới Linear Inverter. Phân bổ đều hơi lạnh đến mọi ngách bên trong tủ bởi công nghệ làm lạnh đa chiều. Kháng khuẩn và khử mùi hôi hiệu quả cùng bộ lọc Nano Carbon. Bảo quản rau quả tươi lâu trong ngăn rau củ cân bằng độ ẩm có kích thước lớn. Tiện ích với chức năng chuẩn đoán lỗi thông minh Smart Diagnosis.',34,N'GR-B247WB.jpg',/*N'GR-B247WB-1.jpg, GR-B247WB-2.jpg, GR-B247WB-3.jpg.',*/19990000,'NSX002','L001',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP019',N'Tủ lạnh Panasonic Inverter 589 lít NR-F603GT-X2',70990000,N'Tiết kiệm điện năng, vận hành ổn định nhờ công nghệ Inverter. Tự điều chỉnh công suất hoạt động phù hợp nhờ cảm biến Econavi thông minh. Tiêu diệt và loại bỏ vi khuẩn gây mùi với công nghệ khử mùi kháng khuẩn Nanoe-X. Tiết kiệm thời gian nấu nướng với ngăn cấp đông mềm Prime Fresh - 3 độ C. Luồng khí lạnh lan tan tỏa đồng đều, hiệu quả nhờ công nghệ Panorama. Tăng cường hiệu quả kháng khuẩn, khử mùi nhờ công nghệ kháng khuẩn Ag Clean với tinh thể bạc Ag+. Giữ trọn độ tươi ngon nhờ ngăn rau củ kích thước lớn kết hợp với bộ lọc kiểm soát độ ẩm. Đá lạnh luôn sẵn sàng với hệ thống làm đá tự động.',6,N'NR-F603GT-X2.jpg',/*N'NR-F603GT-X2-1.jpg, NR-F603GT-X2-2.jpg, NR-F603GT-X2-3.jpg.',*/NULL,'NSX003','L001',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP020',N'Tủ lạnh Samsung Inverter 564 lít RF56K9041SGSV',59900000,N'Công nghệ Digital Inverter giúp tiết kiệm điện tối ưu. Thiết kế 4 cửa sang trọng, đẹp mắt tạo không gian sâu hài hòa với tổng thể nội thất. 3 dàn lạnh độc lập giữ thực phẩm tươi lâu, trọn vị và không bị lẫn mùi. Ngăn chuyển đổi nhiệt độ cho phép người dùng tùy chỉnh linh hoạt. FreshZone giúp giữ độ tươi ngay cả khi mở cửa tủ lạnh thường xuyên. Tiện lợi hơn với khả năng tự làm đá giúp bạn tiết kiệm thời gian và tiết kiệm điện.',1,N'RF56K9041SGSV.jpg',/*N'RF56K9041SGSV-1.jpg, RF56K9041SGSV-2.jpg, RF56K9041SGSV-3.jpg.',*/56900000,'NSX006','L001',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP021',N'Máy giặt LG Inverter 8.5 kg FV1408S4W',11490000,N'Vận hành êm, giảm thiểu hư tổn sợi vải nhờ công nghệ 6 chuyển động DD kết hợp trí thông minh nhân tạo AI. Tiết kiệm điện hiệu quả với công nghệ Inverter. Diệt vi khuẩn, loại bỏ các tác nhân gây dị ứng với công nghệ giặt hơi nước Steam',5,N'hinh3.jpg',/*N'hinh3-1.jpg, hinh3-2.jpg, hinh3-3.jpg',*/9490000,'NSX002','L002',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP022',N'Máy giặt sấy LG Inverter 10.5 kg FG1405H3W1',27390000,N'Máy giặt sấy 2 trong 1 tiện lợi với khối lượng sấy tới 7 kg. Tiết kiệm điện, nước với công nghệ Inverter. Diệt vi khuẩn gây dị ứng nhờ công nghệ giặt hơi nước TrueSteam. Chống nhăn tối đa và tiết kiệm điện, nước hiệu quả với chế độ sấy Eco Hybrid. Giặt sạch, bảo vệ quần áo bền đẹp với công nghệ giặt 6 chuyển động. Tương thích với máy giặt TwinWash Mini. Sử dụng Smartphone để chẩn đoán tình trạng lỗi và điều khiển từ xa.',18,N'FG1405H3W1.jpg',/*N'FG1405H3W1-1.jpg, FG1405H3W1-2.jpg, FG1405H3W1-3.jpg',*/21910000,'NSX002','L002',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP023',N'Máy giặt sấy Samsung AddWash Inverter 10.5 kg WD10N64FR2XSV',20990000,N'Máy giặt sấy 2 trong 1, khối lượng giặt 10.5 kg - khối lượng sấy 7 kg. Tối ưu hiệu quả bột giặt, giặt sạch quần áo với công nghệ giặt bong bóng Eco Bubble. Loại bỏ mùi hôi, kháng khuẩn với sấy hơi Airwash. Tiết kiệm thời gian với chế độ giặt sấy nhanh 59 phút. Diệt khuẩn, giảm nhăn quần áo với công nghệ giặt hơi nước. Vận hành êm ái, bền bỉ và tiết kiệm điện năng với động cơ Digital Inverter. Thêm đồ bất kỳ khi nào với cửa phụ Add Door. Tiện lợi với trợ lý giặt thông minh AI trên điện thoại.',15,N'WD10N64FR2XSV.jpg',/*N'WD10N64FR2XSV-1.jpg, WD10N64FR2XSV-2.jpg, WD10N64FR2XSV-3.jpg',*/19990000,'NSX006','L002',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP024',N'Máy giặt sấy LG Inverter 9 kg FV1409G4V',19990000,N'Máy giặt sấy tích hợp 2 trong 1 tiện lợi. Bảo vệ làn da, loại bỏ các tác nhân gây dị ứng với công nghệ giặt hơi nước Steam. Giảm thiểu hư tổn sợi vải nhờ công nghệ 6 chuyển động DD kết hợp trí thông minh nhân tạo AI. Tiết kiệm điện với công nghệ Inverter. Chuẩn đoán và xử lý nhanh các lỗi máy giặt nhờ tiện ích thông minh Smart ThinQ. Tiện lợi khi thêm đồ giặt và nước xả với cửa phụ Add Item.',30,N'FV1409G4V.jpg',/*N'FV1409G4V-1.jpg, FV1409G4V-2.jpg, FV1409G4V-3.jpg',*/16490000,'NSX002','L002',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP025',N'Máy giặt sấy LG Inverter 8.5 kg FV1408G4W',18990000,N'Máy giặt sấy 2 trong 1 tiện lợi cho gia đình. Giảm hư hại cho quần áo nhờ động cơ truyền động trực tiếp Intello DD hiện đại. Tiết kiệm nước và thời gian sấy khô nhờ công nghệ sấy EcoHybrid. Tiêu diệt vi khuẩn, làm mềm sợi vải khi sử dụng tính năng giặt hơi nước Steam+. Tiết kiệm điện, nước mỗi lần giặt với công nghệ Inverter. Giặt mạnh mẽ nhưng vẫn đảm bảo cho quần áo bền đẹp với công nghệ giặt 6 chuyển động. Cho phép điều khiển máy giặt từ xa qua ứng dụng SmartThinQ.',42,N'FV1408G4W.jpg',/*N'FV1408G4W-1.jpg, FV1408G4W-2.jpg, FV1408G4W-3.jpg',*/15590000,'NSX002','L002',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP026',N'Máy giặt Toshiba 7 kg AW-A800SV WB',4190000,N'Mâm giặt Hybrid Powerful tạo luồng nước mạnh nâng cao hiệu quả giặt sạch. Bộ lọc sinh học lọc sơ vải, cặn bẩn. Bảng điều khiển có tiếng Việt rất dễ sử dụng. Vắt cực khô giúp quần áo mau khô và tiết kiệm thời gian.',11,N'AW-A800SV WB.jpg',/*N'AW-A800SV WB-1.jpg, AW-A800SV WB-2.jpg, AW-A800SV WB-3.jpg',*/NULL,'NSX001','L002',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP027',N'Máy giặt Panasonic 8 kg NA-F80VS9GRV',5290000,N'Gờ mâm giặt cao ma sát nhiều hơn. Luồng nước Dancing, nhào kĩ, giặt sạch hơn 15%. Công nghệ giặt Eco Aquabeat - tăng cường hiệu quả giặt sạch. Công nghệ xả nước Aqua Spin Rinse. Chế độ sấy gió 90 phút - tiết kiệm thời gian phơi quần áo. Bảng điều khiển nút nhấn, có hỗ trợ tiếng Việt dễ dàng sử dụng. Tính năng vệ sinh lồng giặt - giúp loại bỏ các cặn bã tích tụ trong lồng giặt.',8,N'NA-F80VS9GRV.jpg',/*N'NA-F80VS9GRV-1.jpg, NA-F80VS9GRV-2.jpg, NA-F80VS9GRV-3.jpg',*/NULL,'NSX003','L002',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP028',N'Máy giặt Panasonic 10 kg NA-F100V5LRV',10090000,N'Giặt sạch nhiều vết bẩn, diệt khuẩn 99,99% với giặt nước nóng Stain Master+. Đánh bay vết bẩn cứng đầu với công nghệ Active Foam và hộp đánh tan bột giặt Turbo Mixer tạo bọt siêu mịn. Hoạt động tốt cả trong điều kiện nguồn nước yếu. Tự động cân chỉnh mực nước thông minh với cảm biến Econavi. Tạo luồng nước mạnh mẽ với mâm giặt 8 cánh Active Wave. Chế độ sấy gió 90 phút - tiết kiệm thời gian phơi quần áo. Loại bỏ các chất bẩn và cặn đóng trong lồng giặt với chế độ vệ sinh lồng giặt Tub Hygiene.',19,N'NA-F100V5LRV.jpg',/*N'NA-F100V5LRV-1.jpg, NA-F100V5LRV-2.jpg, NA-F100V5LRV-3.jpg',*/NULL,'NSX003','L002',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP029',N'Tủ chăm sóc quần áo thông minh LG Styler S3RF',50000000,N'Chăm sóc quần áo thông minh bằng hơi nước, phù hợp trang phục sang trọng: vest, đầm dạ hội.... Loại bỏ nếp nhăn và mùi khó chịu với chế độ Refresh. Diệt khuẩn, giảm tác nhân gây dị ứng công nghệ TrueSteam độc quyền. Ngăn ngừa quần áo bị co rút, hư hỏng. Giữ không gian nhà bạn luôn thoáng mát với tính năng hút ẩm. Chăm sóc ly quần với chế độ Paint Creases Care. Theo dõi quá trình giặt qua điện thoại kết nối Wifi.',5,N'S3RF.jpg',/*N'S3RF-1.jpg, S3RF-2.jpg, S3RF-3.jpg',*/40000000,'NSX002','L002',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP030',N'Tủ chăm sóc áo quần thông minh Samsung DF60R8600CGSV',42990000,N'Diệt khuẩn, khử mùi và làm mới quần áo nhờ công nghệ JetSteam. Loại bỏ mùi hôi giữ quần áo luôn thơm tho với bộ lọc khử mùi. Bảo vệ quần áo tránh bị co rút và phai màu nhờ công nghệ sấy HeatPump. Giữ quần áo phẳng phiu như được là sau mỗi lần giặt với chế độ Wrinkle care. Giữ phòng luôn khô thoáng và bảo vệ quần áo khỏi nấm mốc nhờ chế độ hút ẩm. Tự động vệ sinh giúp tiết kiệm thời gian với chế độ Self Clean. Thiết kế bản lề thông minh đóng cửa an toàn và êm ái. Gợi ý giặt thông minh với nhờ ứng dụng SmartThings.',5,N'DF60R8600CGSV.jpg',/*N'DF60R8600CGSV-1.jpg, DF60R8600CGSV-2.jpg, DF60R8600CGSV-3.jpg',*/39090000,'NSX006','L002',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP031',N'Loa Tháp Samsung MX-T70/XV',10990000,N'Thiết kế 2 mặt loa kéo độc đáo, âm thanh đa hướng sống động. Tái tạo chất âm đỉnh cao, tận hưởng dải âm trầm sống động nhờ loa trầm tích hợp. Tăng cường âm trầm cùng tổng công suất cực đại 1500 W với tính năng Bass Booster',3,N'hinh4.jpg',/*N'hinh4-1.jpg, hinh4-2.jpg, hinh4-3.jpg',*/7690000,'NSX006','L006',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP032',N'Loa thanh soundbar Sony 2.0 HT-S100F 120W',2990000,N'Cách bố trí hai loa cho bạn thưởng thức âm thanh vòm phía trước từ một thiết bị nhỏ gọn. Sản phẩm loa mang đến âm trầm mạnh mẽ mà vẫn đảm bảo từng chi tiết âm thanh thật rõ nét, lý tưởng cho bạn xem chương trình TV và nghe nhạc. HDMI ARC cho phép truyền tín hiệu âm thanh và điều khiển từ TV mà chỉ cần một cáp nối. Công nghệ S-Force Front Surround mô phỏng các trường âm thanh như ở rạp chiếu phim cho căn phòng ngập tràn những thanh âm giàu sắc thái và sống động. Nghe nhạc trực tiếp không dây với công nghệ Bluetooth®.',13,N'HT-S100F.jpg',/*N'HT-S100F-1.jpg, HT-S100F-2.jpg, HT-S100F-3.jpg',*/NULL,'NSX005','L006',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP033',N'Loa thanh Samsung HW-T420',2160000,N'Thiết kế dạng hình khối, chắc chắn. Âm thanh to, rõ hơn nhờ công suất 150 W với 2.1 kênh. Kết nối với các thiết bị dễ dàng với Bluetooth 2.0. Tối ưu âm thanh với từng nội dung hiển thị nhờ công nghệ Smart Sound. Chơi game trải nghiệm thực tế hơn với chế độ Game Mode. Kiến tạo âm thanh đa chiều không dây dạng vòm như rạp phim. Điều khiển loa từ xa với remote tiện lợi.',25,N'HW-T420.jpg',/*N'HW-T420-1.jpg, HW-T420-2.jpg, HW-T420-3.jpg',*/NULL,'NSX006','L006',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP034',N'Loa Karaoke LG RM1',3190000,N'Thiết kế hiện đại, gọn gàng.Hiệu ứng âm thanh mạnh mẽ, rõ ràng với công suất 25W. Kết nối không dây tiện lợi và nhanh chóng với Bluetooth. Thỏa sức hát Karaoke mọi lúc mọi nơi.',33,N'RM1.jpg',/*N'RM1-1.jpg, RM1-2.jpg, RM1-3.jpg',*/1590000,'NSX002','L006',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP035',N'Loa thanh soundbar Samsung 2.1 HW-K350 150W',3290000,N'Hệ thống loa Samsung 2.1 kênh, công suất loa mạnh mẽ 150W. Công nghệ âm thanh vòm Dobly và DTS hiện đại. Điều khiển loa bằng ứng dụng tiện lợi.',40,N'HW-K350.jpg',/*N'HW-K350-1.jpg, HW-K350-2.jpg, HW-K350-3.jpg',*/1640000,'NSX006','L006',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP036',N'Loa thanh Samsung HW-Q950T',33990000,N'Thiết kế màu đen sang trọng, tinh tế. Tổng công suất loa lên đến 546 W đầy mạnh mẽ, âm thanh chân thực nhờ hệ thống loa 9.1.4  kênh. Âm thanh vòm 3D lan tỏa, bao trùm không gian với bộ đôi công nghệ Dolby Atmos và DTS:X. Tối ưu âm thanh cho từng phân cảnh với công Adaptive Sound. Kích thích hơn khi chơi game với chế độ Game Mode Pro. Kết nối với các thiết bị điện thoại, máy tính bảng dễ dàng với Bluetooth 2.0. Điều chỉnh loa dễ dàng và tiện lợi với One Remote Control.',2,N'HW-Q950T.jpg',/*N'HW-Q950T-1.jpg, HW-Q950T-2.jpg, HW-Q950T-3.jpg',*/NULL,'NSX006','L006',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP037',N'Loa thanh soundbar LG 3.1.2 SN8Y 440W',14990000,N'Mang đến cho bạn âm thanh vượt trội với công nghệ Meridian. Chất lượng giải trí chuẩn rạp chiếu phim với Dolby Vision, Dolby Atmos, DTS:X. Công suất 440 W và hệ thống 3.1.2 kênh cho không gian ngập tràn âm thanh. Âm thanh chất lượng cao với độ phân giải 24bit/96kHZ. Thiết lập phòng AI cho âm thanh phù hợp với không gian. Tạo hiệu ứng âm thanh phù hợp với nội dung bạn đang xem với công nghệ AI Sound Pro. Kết nối thuận tiện với các cổng kết nối: HDMI, Optical, Bluetooth.',14,N'SN8Y.jpg',/*N'SN8Y-1.jpg, SN8Y-2.jpg, SN8Y-3.jpg',*/8990000,'NSX002','L006',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP038',N'Loa thanh soundbar Samsung 3.1.2 HW-Q70R 330W',14990000,N'Kiểu dáng sang trọng, hiện đại. Công suất 330 W mạnh mẽ cùng hiệu ứng âm thanh sống động, lan toả đến từ công nghệ Dolby Digital Plus, DTS Digital Surround. Hỗ trợ điều khiển loa thanh băng điện thoại qua ứng dụng Samsung Audio Remote.',8,N'HW-Q70R.jpg',/*N'HW-Q70R-1.jpg, HW-Q70R-2.jpg, HW-Q70R-3.jpg',*/NULL,'NSX006','L006',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP039',N'Loa thanh Sony 3.1 HT- G700',12990000,N'Âm thanh vòm sống động nhờ: DTS Virtual:X, Dolby Atmos và S-Force PRO Front Surround. Công suất mạnh mẽ, bùng nổ với hệ thống loa 3.1 kênh. Tái tạo âm trầm sâu lắng với loa subwoofer không dây. Kết nối không dây từ loa thanh đến tivi, điện thoại, máy tính bảng,... một cách nhanh chóng, dễ dàng thông qua Bluetooth.',3,N'HT- G700.jpg',/*N'HT- G700-1.jpg, HT- G700-2.jpg, HT- G700-3.jpg',*/NULL,'NSX005','L006',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP040',N'Dàn âm thanh Sony 5.1 BDV-E6100 1000W',7190000,N'Mạng giải trí Sony-Sony Entertainment Network khám phá thế giới giải trí đa dạng. Kết nối NFC, Bluetooth và Wi-Fi tiện lợi. Chế độ Football mode tái hiện sống động những trận bóng đá hấp dẫn.',26,N'BDV-E6100.jpg',/*N'BDV-E6100-1.jpg, BDV-E6100-2.jpg, BDV-E6100-3.jpg',*/7190000,'NSX005','L006',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP041',N'Máy lạnh Daikin Inverter 1.5 HP ATKA35UAVMV',12890000,N'Luồng gió dễ chịu, tránh được gió thổi trực tiếp vào người với thiết kế tạo hiệu ứng Coanda. Độ bền cao với cánh tản nhiệt phủ 2 lớp chống ăn mòn cùng bo mạch được bảo vệ điện áp cao - thấp. Bảo vệ sức khỏe loại bỏ ẩm mốc với chức năng hoạt động chống ẩm mốc',18,N'hinh5.jpg',/*N'hinh5-1.jpg, hinh5-2.jpg, hinh5-3.jpg',*/NULL,'NSX004','L005',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP042',N'Máy lạnh LG Inverter 1 HP V10ENF',5000000,N'Động cơ Dual Inverter - làm lạnh nhanh hơn 40%, tiết kiệm điện lên đến 70%, vận hành êm ái. Công nghệ Jet Cool làm lạnh cực nhanh, hạ 5 độ C trong vòng 3 phút. Chủ động điều chỉnh công suất Energy Ctrl dựa vào số người trong phòng để tiết kiệm thêm điện năng. Bảo vệ sức khỏe của gia đình bạn với tấm vi lọc 3M. Chế độ thổi gió dễ chịu Comfort Air phù hợp cho trẻ nhỏ và người lớn tuổi. Gas R32 - tốt cho sức khỏe, bảo vệ môi trường.',18,N'V10ENF.jpg',/*N'V10ENF-1.jpg, V10ENF-2.jpg, V10ENF-3.jpg',*/NULL,'NSX002','L005',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP043',N'Máy lạnh Toshiba 1 HP RAS-H10U2KSG-V',7990000,N'Công nghệ chống bám bẩn độc quyền Magic Coil giúp máy hoạt động tối ưu, nâng cao độ bền bỉ. Làm lạnh nhanh Hi Power cho căn phòng nhanh chóng được làm lạnh trong thời gian ngắn. Sự kết hợp giữa bộ lọc chống nấm mốc và bộ lọc IAQ mang đến bầu không khí trong lành, sạch khuẩn. Gas R-32 thân thiện với môi trường, an toàn cho sức khỏe người tiêu dùng. Tính năng tự khởi động lại khi có điện - Ghi nhớ các chế độ hiện có, không cần cài đặt lại.',12,N'RAS-H10U2KSG-V.jpg',/*N'RAS-H10U2KSG-V-1.jpg, RAS-H10U2KSG-V-2.jpg, RAS-H10U2KSG-V-3.jpg',*/NULL,'NSX001','L005',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP044',N'Máy lạnh Samsung Inverter 1 HP AR10RYFTAURNSV',8990000,N'Vận hành êm ái, ổn định với công nghệ Digital Inverter. Chế độ một người dùng mang đến sự thoải mái nhưng vẫn tiết kiệm điện. Bộ 3 bảo vệ tăng cường giúp dàn máy bền bỉ với thời gian, chống ăn mòn. Chức năng tự làm sạch tiện lợi, tiết kiệm thời gian và chi phí làm vệ sinh dàn lạnh. Gas R-32 bảo vệ môi trường.',27,N'AR10RYFTAURNSV.jpg',/*N'AR10RYFTAURNSV-1.jpg, AR10RYFTAURNSV-2.jpg, AR10RYFTAURNSV-3.jpg',*/NULL,'NSX006','L005',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP045',N'Máy lạnh Toshiba Inverter 1 HP RAS-H10DKCVG-V',8990000,N'Công nghệ chống bám bẩn độc quyền Magic Coil giúp máy hoạt động tối ưu, nâng cao độ bền bỉ. Tiết kiệm điện, vận hành êm, duy trì độ lạnh ổn định với công nghệ Hybrid Inverter. Làm lạnh nhanh Hi Power cho căn phòng nhanh chóng được làm lạnh trong thời gian ngắn. Sự kết hợp giữa bộ lọc chống nấm mốc và bộ lọc IAQ mang đến bầu không khí trong lành, sạch khuẩn. Loại bỏ mùi ẩm mốc với chức năng tự động làm sạch sau mỗi lần hoạt động. Gas R-32 thân thiện với môi trường, an toàn cho sức khỏe người tiêu dùng. Tính năng tự khởi động lại khi có điện - Ghi nhớ các chế độ hiện có, không cần cài đặt lại.',15,N'RAS-H10DKCVG-V.jpg',/*N'RAS-H10DKCVG-V-1.jpg, RAS-H10DKCVG-V-2.jpg, RAS-H10DKCVG-V-3.jpg',*/NULL,'NSX001','L005',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP046',N'Máy lạnh Panasonic 1 HP CU/CS-N9WKH-8M',8890000,N'Loại bỏ bụi bẩn, bụi mịn hiệu quả nhờ bộ lọc Nanoe-G. Tạo không gian thoáng đãng, khô ráo với chế độ hút ẩm. Làm lạnh nhanh tức thì cùng chế độ Powerful. Tiện lợi, kiểm soát điện năng tiêu thụ nhờ chế độ hẹn giờ bật - tắt.',30,N'CUCSN9WKH8M.jpg',/*N'CUCSN9WKH8M-1.jpg, CUCSN9WKH8M-2.jpg, CUCSN9WKH8M-3.jpg',*/NULL,'NSX003','L005',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP047',N'Máy lạnh Toshiba Inverter 1.5 HP RAS-H13PKCVG-V',14890000,N'Công nghệ chống bám bẩn độc quyền Magic Coil giúp máy hoạt động tối ưu, nâng cao độ bền bỉ. Tiết kiệm điện, vận hành êm, duy trì độ lạnh ổn định với công nghệ Hybrid Inverter. Nút Power-Sel điều chỉnh công suất hoạt động để tiết kiệm kiện tối ưu. Làm lạnh nhanh Hi Power cho căn phòng nhanh chóng được làm lạnh trong thời gian ngắn. Sự kết hợp giữa bộ lọc chống nấm mốc và bộ lọc IAQ mang đến bầu không khí trong lành, sạch khuẩn. Loại bỏ mùi ẩm mốc với chức năng tự động làm sạch sau mỗi lần hoạt động. Chế độ Comfort Sleep - mang lại giấc ngủ sâu và trọn vẹn. Gas R-32 thân thiện với môi trường, an toàn cho sức khỏe người tiêu dùng. Tính năng tự khởi động lại khi có điện - Ghi nhớ các chế độ hiện có, không cần cài đặt lại.',16,N'RAS-H13PKCVG-V.jpg',/*N'RAS-H13PKCVG-V-1.jpg, RAS-H13PKCVG-V-2.jpg, RAS-H13PKCVG-V-3.jpg',*/13890000,'NSX001','L005',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP048',N'Máy lạnh Panasonic Inverter 1.5 HP CU/CS-WPU12WKH-8M',14590000,N'Công nghệ Inverter cùng với chế độ Eco tích hợp AI giúp tiết kiệm điện và làm lạnh hiệu quả. Nanoe-G lọc sạch bụi bẩn, bụi mịn PM2.5, giúp bảo vệ hô hấp gia đình bạn. Điều khiển máy lạnh từ xa qua điện thoại với khả năng kết nối Wifi. Chức năng hút ẩm giữ cho căn phòng luôn khô thoáng. Bảo vệ sức khoẻ với chế độ ngủ (Sleep Mode) tự điều chỉnh nhiệt độ. Chế độ hẹn giờ tiện lợi. Làm lạnh nhanh tức thì Powerful làm lạnh căn phòng chỉ trong vài phút. Thiết kế sang trọng công suất lớn 1.5 HP.',31,N'CUCS-WPU12WKH-8M.jpg',/*N'CUCS-WPU12WKH-8M-1.jpg, CUCS-WPU12WKH-8M-2.jpg, CUCS-WPU12WKH-8M-3.jpg',*/13890000,'NSX003','L005',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP049',N'Máy lạnh Tủ đứng LG Inverter 5 HP APNQ48GT3E4',53790000,N'Công suất làm lạnh lớn 5 HP cùng kiểu dáng dạng tủ thanh lịch, hiện đại. Tiết kiệm điện hiệu quả nhờ công nghệ Inverter. Làm lạnh nhanh với chế độ Power Cooling Mode. Bảo vệ sức khỏe tối ưu với luồng gió thổi dễ chịu. Tiện lợi, kiểm soát thời gian máy hoạt động nhờ chế độ hẹn giờ.',3,N'APNQ48GT3E4-3.jpg',/*N'APNQ48GT3E4.jpg, APNQ48GT3E4-2.jpg, APNQ48GT3E4-1.jpg',*/NULL,'NSX002','L005',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP050',N'Máy lạnh 2 chiều Inverter Panasonic 2 HP CU/CS-YZ18UKH-8',25590000,N'Điều hòa 2 chiều có thêm chức năng sưởi ấm. Công nghệ Inverter - tiết kiệm điện, vận hành êm, làm lạnh sâu và hơi lạnh lan tỏa đều. Làm lạnh nhanh tức thì với chế độ Powerful. Công nghệ Nanoe-G - lọc không khí trong lành, sạch bụi bẩn, bụi mịn PM2.5. Gas R32 an toàn, thân thiện với môi trường.',7,N'CUCS-YZ18UKH-8.jpg',/*N'CUCS-YZ18UKH-8-1.jpg, CUCS-YZ18UKH-8-2.jpg, CUCS-YZ18UKH-8-3.jpg',*/23590000,'NSX003','L005',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP051',N'Máy lọc nước RO Toshiba TWP-N1843SV 3 lõi',6990000,N'Máy lọc nước có 3 lõi lọc, màng lọc RO của Mỹ loại bỏ đến 99.9% vi khuẩn, kim loại nặng trong nước. Công suất lọc đạt 7.8 lít/giờ, dung tích bình chứa nước 8 lít, đáp ứng tối đa nhu cầu nước dùng của mọi người. Tính năng tự động báo thay lõi, tự động ngừng hoạt động khi nước đầy bình, khi áp lực nước cấp không đủ, tự động xả nước thải',2,N'hinh6.jpg',/*N'hinh6-1.jpg, hinh6-2.jpg, hinh6-3.jpg, hinh6-4.jpg',*/6705000,'NSX001','L008',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP052',N'Máy lọc nước RO Toshiba TWP-W1643SV(W) 4 lõi',8490000,N'Màng lọc RO 80GDP cho công suất lọc lớn 7.8 lít/giờ. Bình chứa nước 4.6 lít với 1 lít nước nóng và 3.6 lít nước lạnh. Máy lọc nước nóng lạnh với 4 lõi lọc cung cấp nước sạch cho nhu cầu sử dụng. Diệt khuẩn bằng đèn UV, có đèn báo thay lõi tiện lợi cho quá trình sử dụng sản phẩm. Thương hiệu Toshiba – Nhật Bản, sản xuất tại Trung Quốc.',16,N'TWP-W1643SV(W).jpg',/*N'TWP-W1643SV(W)-1.jpg, TWP-W1643SV(W)-2.jpg, TWP-W1643SV(W)-3.jpg, TWP-W1643SV(W)-4.jpg',*/8065000,'NSX001','L008',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP053',N'Máy lọc nước RO Kangaroo VTU KG08 6 lõi',4690000,N'Lõi lọc số 4 RO - Filmtec sản xuất tại Hàn Quốc, giúp lọc sạch nước trở nên tinh khiết hơn. Máy lọc nước RO có công suất lọc từ 10 - 12 lít/giờ đáp ứng nhu cầu sử dụng. Dung tích bình chứa 8 ít đủ dùng cho nhu cầu gia đình, văn phòng. Công nghệ lõi lọc Nano Silver giúp loại bỏ vi khuẩn, mùi clo trong nước. Máy lọc nước Kangaroo - thương hiệu Việt Nam, sản xuất tại Việt Nam đảm bảo chất lượng.',28,N'VTU KG08.jpg',/*N'VTU KG08-1.jpg, VTU KG08-2.jpg, VTU KG08-3.jpg, VTU KG08-4.jpg',*/3690000,'NSX008','L008',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP054',N'Máy lọc nước R.O nước mặn, nước lợ Kangaroo KG3500AVTU 10 lõi',6990000,N'Màng lọc RO xuất xứ Hàn Quốc, hệ thống 10 lõi lọc mang lại nước tinh khiết, bổ sung khoáng chất. Công suất lọc 10 lít/giờ, dung tích bình 10 lít cung cấp đủ nước cho gia đình đông người dùng liên tục. Công nghệ Nano Silver kháng khuẩn hiệu quả. Tự động ngừng hoạt động khi nước đầy bình hoặc khi áp lực nước cấp không đủ. Ra mắt năm 2020, sản phẩm của thương hiệu Kangaroo - Việt Nam, sản xuất tại Việt Nam.',17,N'KG3500AVTU.jpg',/*N'KG3500AVTU-1.jpg, KG3500AVTU-2.jpg, KG3500AVTU-3.jpg, KG3500AVTU-4.jpg',*/6705000,'NSX008','L008',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP055',N'Máy lọc nước RO hydrogen ion kiềm Kangaroo KG100EO 7 lõi',12900000,N'Công nghệ điện phân nước RO tạo nước Hydrogen ion kiềm, cung cấp nước sạch toàn diện. Hệ thống 7 lõi lọc cung cấp nước sạch, thêm nhiều khoáng chất, độ ngọt tự nhiên. Công suất lọc 18 lít/giờ, bình chứa nước 7 lít đủ dùng cho nhu cầu nước uống tại gia đình. Hệ thống bơm - hút 2 chiều, van điện từ tăng áp lực nước đầu vào, nâng cao hiệu suất lọc, tăng tuổi thọ sản phẩm. Tấm điện cực được thiết kế dưới dạng lưới mắt cáo làm tăng diện tích tiếp xúc với nước, chống bám cặn tốt và an toàn cho sức khoẻ. Thương hiệu Kangaroo - Việt Nam, sản xuất tại Việt Nam.',5,N'KG100EO.jpg',/*N'KG100EO-1.jpg, KG100EO-2.jpg, KG100EO-3.jpg, KG100EO-4.jpg',*/NULL,'NSX008','L008',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP056',N'Máy lọc nước RO hydrogen ion kiềm Kangaroo KG100ES 7 lõi',11900000,N'Công nghệ điện phân nước RO tạo nước Hydrogen ion kiềm trung hòa axit cho cơ thể. Hệ thống 7 lõi lọc cung cấp nước sạch hoàn hảo, thêm nhiều khoáng chất có lợi cho sức khỏe. Công suất lọc 18 lít/giờ, sử dụng bình chứa nước dung tích 7 lít đủ dùng cho nhu cầu nước uống thông thường tại gia đình. Hệ thống bơm - hút 2 chiều, van điện từ tăng áp lực nước đầu vào, nâng cao hiệu suất lọc, tăng tuổi thọ sản phẩm. Tự động sục rửa màng RO tăng tuổi thọ lõi lọc, chế độ cút nối nhanh tháo lắp và thay thế thật tiện lợi. Thương hiệu Kangaroo - Việt Nam, sản xuất tại Việt Nam.',8,N'KG100ES.jpg',/*N'KG100ES-1.jpg, KG100ES-2.jpg, KG100ES-3.jpg, KG100ES-4.jpg',*/NULL,'NSX008','L008',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP057',N'Máy lọc nước RO nóng lạnh Sunhouse SHA76213CK 10 lõi',10290000,N'Thiết kế slim thon gọn phù hợp với mọi không gian nội thất. Loại bỏ 99,9% vi khuẩn nhờ màng R.O nhập khẩu Hàn Quốc và công nghệ diệt khuẩn Nanosilver. Lọc sạch nước, bổ sung khoáng chất nhờ bộ 10 lõi lọc. Lọc nước lên đến 15 lít/giờ, trong đó dung tích bình nước nóng 1 lít, bình nước lạnh 2 lít, nước thường 4 lít. Công nghệ làm lạnh bằng block gas, giữ nước lạnh hơn và giúp máy bền hơn. Ra mắt năm 2020, thương hiệu Sunhouse - sản xuất tại Việt Nam.',10,N'SHA76213CK.jpg',/*N'SHA76213CK-1.jpg, SHA76213CK-2.jpg, SHA76213CK-3.jpg, SHA76213CK-4.jpg',*/8700000,'NSX007','L008',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP058',N'Máy lọc nước RO nóng lạnh Kangaroo KG10A3 10 lõi',8690000,N'Màng lọc RO xuất xứ Hàn Quốc, hệ thống 10 cấp lọc mang lại nước tinh khiết, bổ sung khoáng chất. Công suất lọc 10 - 12 lít/giờ, dung tích bình nước nóng 1 lít, nước thường 10 lít, nước lạnh 0.8 lít. Thiết kế 2 vòi nóng lạnh riêng biệt, tiện pha chế trà, sữa, mì hay nước mát để sử dụng. Thương hiệu Kangaroo Việt Nam, sản xuất tại Việt Nam.',11,N'KG10A3.jpg',/*N'KG10A3-1.jpg, KG10A3-2.jpg, KG10A3-3.jpg, KG10A3-4.jpg',*/6800000,'NSX008','L008',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP059',N'Máy lọc nước RO nóng lạnh Sunhouse SHR76210CK 10 lõi',8490000,N'Màng lọc R.O DOW - USA loại bỏ 99,9% vi khuẩn và 10 lõi lọc giúp bổ sung khoáng chất, loại bỏ vi khuẩn mang lại nguồn nước sạch trong lành. Đáp ứng hiệu quả nhu cầu sử dụng với dung tích 10 lít, bình lạnh 0.65 lít, bình nóng 0.85 lít và công suất lọc 10-15 lít/giờ. Tích hợp 2 vòi nước: nóng (nhiệt độ 80 - 90 độ C), lạnh (nhiệt độ 10 - 15 độ C). Thiết kế sang trọng, mặt kính cường lực. Thương hiệu Sunhouse của Việt Nam - Sản xuất tại Việt Nam.',30,N'SHR76210CK.jpg',/*N'SHR76210CK-1.jpg, SHR76210CK-2.jpg, SHR76210CK-3.jpg, SHR76210CK-4.jpg',*/7640000,'NSX007','L008',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP060',N'Máy lọc nước RO Sunhouse SHA8817KP 9 lõi',7590000,N'Lọc sạch 99,9% vi khuẩn nhờ màng R.O Dow – USA. Hệ thống 9 lõi lọc với các lõi bổ sung tăng cường khoáng, tạo vị ngọt tự nhiên và chống tái nhiễm khuẩn cho nước. Công suất lọc mạnh mẽ 10 - 15 lít/h, bình chứa nước có dung tích 10 lít. Máy lọc nước hoạt động hiệu quả, cấp đủ nước đầu vào với bơm - hút 2 chiều, van từ hiện đại. Thương hiệu nổi tiếng Sunhouse - Việt Nam, sản xuất tại Việt Nam.',7,N'SHA8817KP.jpg',/*N'SHA8817KP-1.jpg, SHA8817KP-2.jpg, SHA8817KP-3.jpg, SHA8817KP-4.jpg',*/5990000,'NSX007','L008',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP061',N'Máy giặt sấy Samsung Inverter 9.5kg WD95J5410AW/SV',13630000,N'Giặt sấy tích hợp 2 trong 1 tiện lợi. Tiết kiệm điện, vận hành êm nhờ công nghệ Digital Inverter. Đánh bật vết bẩn cứng đầu hiệu quả nhờ công nghệ giặt bong bóng Eco Bubble. Khử mùi, loại bỏ vi khuẩn cùng chế độ sấy hơi Air Wash. Thấm sâu vào sợi vải, góp phần loại bỏ vết bẩn tối ưu với Bubble Soak. Tiết kiệm thời gian với chế độ giặt siêu nhanh Quick Wash. Chuẩn đoán và khắc phục nhanh chóng các sự cố nhờ ứng dụng thông minh Smart Check.',9,N'WD95J5410AWSV.jpg',/*N'WD95J5410AWSV-1.jpg, WD95J5410AWSV-2.jpg, WD95J5410AWSV-3.jpg',*/13630000,'NSX006','L003',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP062',N'Máy giặt sấy Samsung AddWash Inverter 9.5 kg WD95K5410OX/SV',14590000,N'Tích hợp tính năng sấy khô tiện lợi, không lo phơi đồ ngày mưa. Sử dụng điện hiệu quả với công nghệ Digital Inverter. Sử dụng bột giặt hiệu quả với công nghệ bong bóng Eco Bubble. Tiện lợi khi thêm đồ giặt với cửa phụ Add Door. An toàn với chức năng khóa trẻ em. Giảm hư tổn quần áo nhờ lồng giặt kim cương.',9,N'WD95K5410OXSV.jpg',/*N'WD95K5410OXSV-1.jpg, WD95K5410OXSV-2.jpg, WD95K5410OXSV-3.jpg',*/NULL,'NSX006','L003',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP063',N'Máy giặt sấy LG Inverter 8.5 kg FV1408G4W',18990000,N'Máy giặt sấy 2 trong 1 tiện lợi cho gia đình. Giảm hư hại cho quần áo nhờ động cơ truyền động trực tiếp Intello DD hiện đại. Tiết kiệm nước và thời gian sấy khô nhờ công nghệ sấy EcoHybrid. Tiêu diệt vi khuẩn, làm mềm sợi vải khi sử dụng tính năng giặt hơi nước Steam+. Tiết kiệm điện, nước mỗi lần giặt với công nghệ Inverter. Giặt mạnh mẽ nhưng vẫn đảm bảo cho quần áo bền đẹp với công nghệ giặt 6 chuyển động. Cho phép điều khiển máy giặt từ xa qua ứng dụng SmartThinQ.',14,N'FV1408G4W.jpg',/*N'FV1408G4W-1.jpg, FV1408G4W-2.jpg, FV1408G4W-3.jpg',*/15590000,'NSX002','L003',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP064',N'Máy giặt sấy Samsung AddWash Inverter 10.5 kg WD10N64FR2W/SV',19490000,N'Máy giặt sấy 2 trong 1, khối lượng giặt 10.5 kg và khối lượng sấy 7 kg. Tối ưu hiệu quả bột giặt, giặt sạch quần áo với công nghệ giặt bong bóng Eco Bubble. Loại bỏ mùi hôi, kháng khuẩn với Sấy hơi Airwash. Tiết kiệm thời gian với chế độ Giặt sấy nhanh 59 phút. Diệt khuẩn, giảm nhăn quần áo với công nghệ giặt hơi nước. Vận hành êm ái, bền bỉ và tiết kiệm điện năng với động cơ Digital Inverter. Thêm đồ bất kỳ khi nào với cửa phụ Add Door. Tiện lợi với trợ lý giặt thông minh AI trên điện thoại.',8,N'WD10N64FR2WSV.jpg',/*N'WD10N64FR2WSV-1.jpg, WD10N64FR2WSV-2.jpg, WD10N64FR2WSV-3.jpg',*/18490000,'NSX006','L003',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP065',N'Máy giặt sấy LG Inverter 9 kg FV1409G4V',19990000,N'Máy giặt sấy tích hợp 2 trong 1 tiện lợi. Bảo vệ làn da, loại bỏ các tác nhân gây dị ứng với công nghệ giặt hơi nước Steam. Giảm thiểu hư tổn sợi vải nhờ công nghệ 6 chuyển động DD kết hợp trí thông minh nhân tạo AI. Tiết kiệm điện với công nghệ Inverter. Chuẩn đoán và xử lý nhanh các lỗi máy giặt nhờ tiện ích thông minh Smart ThinQ. Tiện lợi khi thêm đồ giặt và nước xả với cửa phụ Add Item.',17,N'FV1409G4V.jpg',/*N'FV1409G4V-1.jpg, FV1409G4V-2.jpg, FV1409G4V-3.jpg',*/16490000,'NSX002','L003',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP066',N'Máy giặt sấy Samsung AddWash Inverter 10.5 kg WD10N64FR2X/SV',20990000,N'Máy giặt sấy 2 trong 1, khối lượng giặt 10.5 kg - khối lượng sấy 7 kg. Tối ưu hiệu quả bột giặt, giặt sạch quần áo với công nghệ giặt bong bóng Eco Bubble. Loại bỏ mùi hôi, kháng khuẩn với sấy hơi Airwash. Tiết kiệm thời gian với chế độ giặt sấy nhanh 59 phút. Diệt khuẩn, giảm nhăn quần áo với công nghệ giặt hơi nước. Vận hành êm ái, bền bỉ và tiết kiệm điện năng với động cơ Digital Inverter. Thêm đồ bất kỳ khi nào với cửa phụ Add Door. Tiện lợi với trợ lý giặt thông minh AI trên điện thoại.',3,N'WD10N64FR2XSV.jpg',/*N'WD10N64FR2XSV-1.jpg, WD10N64FR2XSV-2.jpg, WD10N64FR2XSV-3.jpg',*/19990000,'NSX006','L003',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP067',N'Máy giặt sấy LG Inverter 10.5 kg FV1450H2B',26490000,N'Máy giặt sấy 2 trong 1 tiện lợi cho gia đình. Giảm hư hại cho quần áo nhờ động cơ truyền động trực tiếp Intello DD hiện đại. Tiết kiệm nước và thời gian sấy khô nhờ công nghệ sấy EcoHybrid. Giặt sạch nhanh chóng chỉ trong thời gian ngắn với công nghệ giặt tiết kiệm TurboWash 360. Tiêu diệt vi khuẩn, làm mềm sợi vải khi sử dụng tính năng giặt hơi nước Steam+. Tiết kiệm điện, nước mỗi lần giặt với công nghệ Inverter. Giặt mạnh mẽ nhưng vẫn đảm bảo cho quần áo bền đẹp với công nghệ giặt 6 chuyển động. Cho phép điều khiển máy giặt từ xa qua ứng dụng SmartThinQ.',3,N'FV1450H2B.jpg',/*N'FV1450H2B-1.jpg, FV1450H2B-2.jpg, FV1450H2B-3.jpg',*/21900000,'NSX002','L003',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP068',N'Máy giặt sấy LG Inverter 10.5 kg FG1405H3W1',27390000,N'Máy giặt sấy 2 trong 1 tiện lợi với khối lượng sấy tới 7 kg. Tiết kiệm điện, nước với công nghệ Inverter. Diệt vi khuẩn gây dị ứng nhờ công nghệ giặt hơi nước TrueSteam. Chống nhăn tối đa và tiết kiệm điện, nước hiệu quả với chế độ sấy Eco Hybrid. Giặt sạch, bảo vệ quần áo bền đẹp với công nghệ giặt 6 chuyển động. Tương thích với máy giặt TwinWash Mini. Sử dụng Smartphone để chẩn đoán tình trạng lỗi và điều khiển từ xa.',21,N'FG1405H3W1.jpg',/*N'FG1405H3W1-1.jpg, FG1405H3W1-2.jpg, FG1405H3W1-3.jpg',*/21910000,'NSX002','L003',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP069',N'Máy giặt sấy Samsung Add Wash Inverter 19 kg WD19N8750KV/SV',27900000,N'Khối lượng giặt - sấy lớn, đáp ứng nhu cầu giặt giũ của cả nhà. Động cơ truyền động trực tiếp bền bỉ, êm ái. Giặt giũ dễ dàng, tiện lợi với trợ lý giặt thông minh AI. Ngăn Auto Dispense tự động điều chỉnh nước giặt, nước xả. Dánh bay vết bẩn cứng đầu với công nghệ giặt bong bóng Eco Bubble. Loại bỏ vi khuẩn và tác nhân gây dị ứng trên quần áo thông qua chế độ giặt nước nóng. Tự vệ sinh lồng giặt tiện lợi, tiết kiệm thời gian và chi phí. Tiện lợi với chế độ hẹn giờ. Loại bỏ mùi hôi trên quần áo với công nghệ sấy khử mùi. Vận hành êm ái, tiết kiệm nước, điện với công nghệ Inverter.',1,N'WD19N8750KVSV.jpg',/*N'WD19N8750KVSV-1.jpg, WD19N8750KVSV-2.jpg, WD19N8750KVSV-3.jpg',*/NULL,'NSX006','L003',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP070',N'Máy sấy Samsung 9 Kg DV90M5200QW/SV',16990000,N'Tiết kiệm điện tối ưu, sấy nhanh cùng công nghệ Heatpump. Sấy khô nhanh có thể mặc liền trong 35 phút tiện lợi. Tiết kiệm điện, vận hành êm ái với công nghệ Inverter. Phù hợp cho gia đình đông người với khối lượng sấy lên đến 9 Kg. Công nghệ sấy ngưng tụ tránh bỏng, bảo vệ an toàn cho trẻ em trong gia đình. Sấy khô quần áo hiệu quả với công nghệ Optimal Dry. Giảm nhăn quần áo cùng tính năng Wrinkle Prevent.',15,N'DV90M5200QWSV.jpg',/*N'DV90M5200QWSV-1.jpg, DV90M5200QWSV-2.jpg, DV90M5200QWSV-3.jpg',*/NULL,'NSX006','L003',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP071',N'Tủ đông LG Inverter 165 lít GN-F304PS',6490000,N'Tay cầm thời trang, tiện lợi và không lo bị gãy tay cầm. Thiết kế cửa bạch kim hoàn thiện, đẹp mắt. Làm lạnh nhanh, tiết kiệm điện với máy nén Inverter. Làm mát nhanh, đều hơn nhờ công nghệ làm mát kệ. Dung tích 165 lít, sự lựa chọn lý tưởng cho gia đình có 2 - 3 thành viên. Tiết kiệm không gian, phù hớp với căn hộ nhỏ khi bề ngang tủ hẹp (530mm). Linh hoạt, lưu trữ đa dạng thực phẩm với thiết kế 6 kệ và 1 hộc tủ.',32,N'GN-F304PS.jpg',/*N'GN-F304PS-1.jpg, GN-F304PS-2.jpg, GN-F304PS-3.jpg',*/6190000,'NSX002','L004',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP072',N'Tủ đông Kangaroo 140 lít KG 265NC1',6490000,N'Thiết kế nhỏ gọn, phù hợp với không gian hẹp. Dung tích 140 lít tiện lưu trữ cho gia đình ít người dùng. Gas R600a thân thiện môi trường, tiết kiệm điện. Lưu trữ thực phẩm an toàn với công nghệ Nano Silver. Dàn lạnh từ đồng nguyên chất giúp hoạt động bền bỉ. Giỏ đựng đồ, bánh xe linh hoạt giúp sử dụng thuận tiện.',40,N'265NC1.jpg',/*N'265NC1-1.jpg, 265NC1-2.jpg, 265NC1-3.jpg',*/5690000,'NSX008','L004',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP073',N'Tủ đông LG Inverter 165 lít GN-F304WB',6990000,N'Sang trọng, chắn chắc với tay cầm dạng âm vào trong. Kiểu dáng thon gọn, tinh tế. Vận hành êm ái, tiết kiệm điện năng với công nghệ Inverter. Làm mát thực phẩm một cách nhanh chóng với công nghệ làm mát kệ. Tiết kiệm không gian gia đình bạn với bề ngang tủ hẹp chỉ 530 mm. Sử dụng thoải mái với dung tích tủ lên tới 165 lít. Bảo quản nhiều loại thực phẩm với 6 kệ và 1 hộc tủ.',40,N'GN-F304WB.jpg',/*N'GN-F304WB-1.jpg, GN-F304WB-2.jpg, GN-F304WB-3.jpg',*/6690000,'NSX002','L004',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP074',N'Tủ đông Kangaroo 192 lít KG 266NC2',7190000,N'Màu trắng nhẹ nhàng, thiết kế nhỏ gọn phù hợp với mọi không gian. Dung tích 192 lít thoải mái lưu trữ. Tủ đông 2 cửa với 2 ngăn giúp lưu trữ đa dạng. Vận hành êm ái, thân thiện môi trường nhờ gas R600a. Thực phẩm tươi sạch, an toàn sử dụng với công nghệ Nano Silver. Làm lạnh nhanh nhờ dàn đồng nguyên chất. Khóa cửa tủ, bánh xe, giỏ đựng đồ tiện dụng.',12,N'266NC2.jpg',/*N'266NC2-1.jpg, 266NC2-2.jpg, 266NC2-3.jpg',*/6290000,'NSX008','L004',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP075',N'Tủ đông Sunhouse 225 lít SHR-F2272W2',7790000,N'Thiết kế 2 ngăn (đông, mát) với dung tích 225 lít, đủ rộng để dự trữ lượng lớn thức ăn. Độ lạnh luôn được ổn định nhờ công nghệ làm lạnh sâu đa chiều 360 độ. Giữ lạnh lâu dễ dàng lên đến 12h khi ngắt điện nhờ tấm cách nhiệt Foam. Làm lạnh nhanh, tiết kiệm điện đến 30% nhờ sử dụng dàn lạnh bằng đồng, gas R600a. Giảm bám tuyết, dễ dàng vệ sinh với vỏ tôn sơn tĩnh điện. Tiện lợi khi trang bị khóa cửa tủ, bánh xe, giỏ đựng đồ.',17,N'SHR-F2272W2.jpg',/*N'SHR-F2272W2-1.jpg, SHR-F2272W2-2.jpg, SHR-F2272W2-3.jpg',*/NULL,'NSX007','L004',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP076',N'Tủ đông Kangaroo 212 lít KG 328NC2',7390000,N'Thiết kế trẻ trung, hiện đại phù hợp với không gian lớn. Thoải mái lưu trữ với dung tích lên đến 212 lít. Lưu trữ đa dạng ở nhiều nhiệt độ với 2 ngăn. Tiết kiệm điện, vận hành êm ái, thân thiện môi trường nhờ gas R600a. Kháng khuẩn, khử mùi nhờ công nghệ Nano Silver. Làm lạnh nhanh hơn nhờ việc sử dụng dàn lạnh bằng đồng nguyên chất. Bánh xe linh động cùng giỏ đựng đồ tiện lợi.',23,N'328NC2.jpg',/*N'328NC2-1.jpg, 328NC2-2.jpg, 328NC2-3.jpg',*/NULL,'NSX008','L004',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP077',N'Tủ đông Kangaroo 490 lít KG 809C1',15190000,N'Khử mùi, diệt khuẩn tối ưu nhờ công nghệ Nano Silver. Làm đông thực phẩm nhanh với dàn lạnh bằng đồng nguyên chất. An toàn cho người dùng, thân thiện môi trường khi dùng gas R134a. Quan sát thực phẩm rõ khi trang bị đèn chiếu sáng. Tránh sự nghịch phá trẻ nhờ khóa cửa tủ.',69,N'809C1.jpg',/*N'809C1-1.jpg, 809C1-2.jpg, 809C1-3.jpg',*/13690000,'NSX008','L004',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP078',N'Tủ đông mềm Kangaroo 252 lít KG 400DM2',10990000,N'Giữ trọn hương vị và tiết kiệm thời gian chế biến khi tích hợp ngăn đông mềm -5 độ C. Thiết kế 2 ngăn (đông mềm, mát) với dung tích 252 lít có thể tích trữ lượng lớn thức ăn. An toàn cho sức khỏe với khả năng kháng khuẩn Nano Silver. Loại bỏ nỗi lo bị lẫn mùi thực phẩm nhờ công nghệ 2 dàn lạnh độc lập. Bảo quản thực phẩm tốt với dàn làm lạnh bằng đồng nguyên chất. An toàn, tiết kiệm điện và thân thiện với môi trường khi dùng gas R600a.',10,N'400DM2.jpg',/*N'400DM2-1.jpg, 400DM2-2.jpg, 400DM2-3.jpg',*/9990000,'NSX008','L004',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP079',N'Tủ đông Sunhouse 330 lít SHR-F2472W2',10390000,N'Thiết kế 2 cửa, 2 ngăn đông mát với dung tích 330 lít tiện lợi. Giữ nhiệt độ lạnh ổn định với công nghệ lạnh sâu đa chiều 360 độ. Làm lạnh nhanh, tiết kiệm điện 30% khi sử dụng gas R600a cùng dàn lạnh bằng đồng. Giảm thất thoát hơi lạnh với tấm cách nhiệt Foam. Giảm bám tuyết nhờ mặt trong làm bằng tôn sơn tĩnh điện. Khóa an toàn, bánh xe xoay đa chiều tiện lợi.',32,N'SHR-F2472W2.jpg',/*N'SHR-F2472W2-1.jpg, SHR-F2472W2-2.jpg, SHR-F2472W2-3.jpg',*/NULL,'NSX007','L004',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP080',N'Tủ đông Sunhouse 255 lít SHR-F2362W2',8690000,N'Dung tích 255 lít gồm 2 ngăn đông - mát đủ rộng cho bạn dự trữ lượng lớn thực phẩm. Nhiệt độ lạnh luôn ổn định nhờ công nghệ làm lạnh sâu đa chiều 360 độ.Giữ lạnh thực phẩm lên đến 12h khi ngắt điện nhờ tích hợp tấm cách nhiệt Foam. Làm lạnh nhanh nhưng vẫn tiết kiệm điện với dàn lạnh bằng đồng, gas R600a. Có khóa tủ an toàn, bánh xe di chuyển linh hoạt và giỏ đồ tiện ích.',11,N'SHR-F2362W2.jpg',/*N'SHR-F2362W2-1.jpg, SHR-F2362W2-2.jpg, SHR-F2362W2-3.jpg',*/8290000,'NSX007','L004',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP081',N'Bếp từ Sunhouse SHD6149',600000,N'Bếp từ đơn 1 vùng nấu nhỏ gọn, tiện dụng. Mặt bếp bằng kính chịu nhiệt siêu bền, chịu được nhiệt đến 600 độ C. 7 chế độ nấu tiện dụng như nấu, xào, soup, cháo, hâm sữa, hấp, giữ ấm. Bảng điều khiển kèm tiếng Việt, có khóa an toàn, có hẹn giờ nấu.',15,N'SHD6149.jpg',/*N'SHD6149-1.jpg, SHD6149-2.jpg, SHD6149-3.jpg',*/NULL,'NSX002','L007',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP082',N'Bếp từ Sunhouse SHD 6861',1100000,N'Bếp từ đơn 1 vùng nấu nhỏ gọn, tiện dụng. Mặt bếp bằng kính chịu nhiệt siêu bền, chịu được nhiệt đến 600 độ C. 7 chế độ nấu tiện dụng như nấu, xào, soup, cháo, hâm sữa, hấp, giữ ấm. Bảng điều khiển kèm tiếng Việt, có khóa an toàn, có hẹn giờ nấu.',18,N'SHD 6861.jpg',/*N'SHD 6861-1.jpg, SHD 6861-2.jpg, SHD 6861-3.jpg',*/NULL,'NSX007','L007',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP083',N'Bếp từ Kangaroo KG408I',1250000,N'Bếp từ đơn công suất 2100 W nấu ăn nhanh. Mặt bếp bằng kính chịu nhiệt bền tốt, ít bám bẩn, dễ lau chùi. 8 chế độ nấu tự động và chế độ nấu tiết kiệm điện. Tính năng hẹn giờ nấu hỗ trợ nấu ăn lúc bận rộn.',8,N'KG408I.jpg',/*N'KG408I-1.jpg, KG408I-2.jpg, KG408I-3.jpg',*/1190000,'NSX008','L007',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP084',N'Bếp từ hồng ngoại Sunhouse SHB9105MT',4070000,N'Bếp từ kết hợp bếp hồng ngoại nấu ăn tiện lợi, linh hoạt, thiết kế sang trọng. Mặt bếp bằng kính cường lực cao cấp chống trầy, sáng bóng, chịu nhiệt tốt. Bảng điều khiển cảm ứng cùng màn hình hiển thị sắc nét dễ sử dụng. Sử dụng an toàn với chức năng khóa bảng điều khiển, tự ngắt khi quá tải. Ra mắt năm 2019, thương hiệu Sunhouse uy tín của Việt Nam, sản xuất tại Trung Quốc.',33,N'SHB9105MT.jpg',/*N'SHB9105MT-1.jpg, SHB9105MT-2.jpg, SHB9105MT-3.jpg',*/3250000,'NSX007','L007',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP085',N'Bếp từ đôi Sunhouse SHB9101',5550000,N'Bếp từ có 2 lò đun, công suất tổng tới 4000 W, nấu ăn nhanh chóng. Mặt bếp bằng kính ceramic sáng bóng, dễ chùi rửa. Có khóa bảng điều khiển, chức năng hẹn giờ nấu tiện dụng. Thương hiệu Sunhouse - Việt Nam, sản xuất tại Việt Nam.',26,N'SHB9101.jpg',/*N'SHB9101-1.jpg, SHB9101-2.jpg, SHB9101-3.jpg',*/NULL,'NSX007','L007',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP086',N'Bếp từ hồng ngoại Sunhouse Apex APB9982',20494000,N'Mặt bếp bằng kính Schott Ceran - Châu Âu chịu nhiệt tốt, sáng bóng và dễ lau chùi. Bếp gồm 1 bếp từ và 1 bếp hồng ngoại giúp nấu ăn dễ dàng. Bảng điều khiển cảm ứng hiện đại, thao tác đơn giản. An toàn khi sử dụng với tính năng tự ngắt, khóa bảng điều khiển. Thương hiệu Việt Nam, sản xuất tại Châu Âu.',4,N'APB9982.jpg',/*N'APB9982-1.jpg, APB9982-2.jpg, APB9982-3.jpg',*/NULL,'NSX007','L007',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP087',N'Bếp từ đôi Sunhouse Apex APB9981',18490000,N'Bếp từ có 2 lò đun, công suất tổng tới 3800 W, nấu ăn nhanh chóng. Mặt bếp bằng kính Schott Ceran sáng bóng, chịu nhiệt tốt, chống trầy. Có khóa bảng điều khiển, chức năng hẹn giờ nấu tiện dụng. Có đèn báo mặt bếp còn nóng và tạm ngừng khi đang nấu hiện đại, an toàn. Thương hiệu Sunhouse - Việt Nam, sản xuất tại Châu Âu.',18,N'APB9981.jpg',/*N'APB9981-1.jpg, APB9981-2.jpg, APB9981-3.jpg',*/NULL,'NSX007','L007',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP088',N'Bếp từ đôi Sunhouse Mama MMB9208DIH',25000000,N'Kiểu dáng sang trọng, mẫu mã hiện đại, thích hợp mọi không gian bếp. Có 2 vùng nấu thuận tiện với nhiều loại nồi, chảo có đế nhiễm từ. Bảng điều khiển cảm ứng riêng biệt cho 2 vùng nấu dễ dàng sử dụng. Mặt kính schott ceran chịu lực, chịu sốc nhiệt đến 800 độ C. Công suất nấu lên đến 3600 W với bếp trái 2600W, bếp phải 2200W, nấu nhanh, tiết kiệm điện năng. An toàn với chế độ khoá điều khiển, cảnh báo khi quá nhiệt, cảnh báo nồi không phù hợp. Thương hiệu Sunhouse nổi tiếng của Việt Nam, được sản xuất tại Thái Lan.',1,N'MMB9208DIH.jpg',/*N'MMB9208DIH-1.jpg, MMB9208DIH-2.jpg, MMB9208DIH-3.jpg',*/NULL,'NSX007','L007',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP089',N'Bếp từ đôi Kangaroo KG438I',7500000,N'Mặt bếp bằng kính chịu nhiệt sáng bóng, chống trầy, tiện lau chùi. Công suất lớn 3500 W, làm chín thức ăn nhanh, ít tốn điện. Bảng điều khiển cảm ứng nhanh nhạy, có chỉ dẫn dễ hiểu, dễ thao tác. Thương hiệu Kangaroo uy tín của Việt Nam, mẫu đẹp, dùng tốt.',49,N'KG438I.jpg',/*N'KG438I-1.jpg, KG438I-2.jpg, KG438I-3.jpg',*/4990000,'NSX008','L007',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP090',N'Bếp từ hồng ngoại Sunhouse SHB9104MT',3490000,N'Mặt bếp bằng kính chịu nhiệt sáng bóng, tiện lau chùi. Bếp gồm 1 bếp từ và 1 bếp hồng ngoại giúp nấu ăn dễ dàng. Bảng điều khiển cảm ứng hiện đại, thao tác đơn giản. An toàn khi sử dụng với tính năng tự ngắt, khóa bảng điều khiển.',34,N'SHB9104MT.jpg',/*N'SHB9104MT-1.jpg, SHB9104MT-2.jpg, SHB9104MT-3.jpg',*/NULL,'NSX007','L007',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP091',N'Máy nước nóng Panasonic DH-4NP1VS 4500W',5190000,N'Thiết kế màu bạc, nhỏ gọn sang trọng. Công suất 4500 W mạnh mẽ và cơ chế làm nóng trực tiếp giúp nóng nhanh chóng. Luồng nước mạnh mẽ nhờ bơm trợ lực vận hành siêu êm. Đảm bao cung cấp nguồn nước sạch cho máy nhờ van cấp nước có chức năng lọc. Vòi sen ion Ag+ kháng khuẩn kèm theo với 3 kiểu phun. Không lo chập cháy, đảm bảo an toàn về điện nhờ cầu dao ELCB. Vận hành ổn định nhờ cảm biến lưu lượng nước. Bảo vệ hệ thống, tăng tuổi thọ nhờ vỏ chống nước IP25. An toàn về nhiệt, không gây bỏng nhờ chế độ kiểm soát nhiệt độ. Vòi sen 3 chế độ phun, tiện lợi hơn khi sử dụng.',42,N'DH-4NP1VS.jpg',/*N'DH-4NP1VS-1.jpg, DH-4NP1VS-2.jpg, DH-4NP1VS-3.jpg',*/NULL,'NSX003','L009',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP092',N'Máy nước nóng Panasonic DH-3RL2VH 3.5KW',2590000,N'Làm nóng nước cực nhanh và dễ sử dụng với cơ chế vận hành trực tiếp. Vỏ máy chống nước, bụi đạt chuẩn IP25 giúp bảo vệ các linh kiện bên trong, tăng độ bền cho máy. Tương thích điện từ EMC ngăn chặn tình trạng nhiễu sóng tivi hoặc ảnh hưởng điện đến các thiết bị khác trong nhà. Đảm bảo an toàn khi sử dụng với cầu dao chống rò điện ELCB. Cảm biến lưu lượng nước thông minh, tự ngắt khi lượng nước đầu ra ít hơn 2 lít/phút để tránh tình trạng cháy khi thanh nhiệt bị khô.',25,N'DH-3RL2VH.jpg',/*N'DH-3RL2VH-1.jpg, DH-3RL2VH-2.jpg, DH-3RL2VH-3.jpg',*/NULL,'NSX003','L009',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP093',N'Máy nước nóng Panasonic DH-4MP1VW 4500W',4790000,N'Bơm trợ lực vận hành siêu êm, giúp dòng nước ổn định ở những nơi nước yếu. Làm nóng trực tiếp, cho thời gian sử dụng nước chưa đầy 1 phút. Cầu dao chống rò điện ELCB đảm bảo an toàn tuyệt đối cho cả nhà. Vỏ máy chống bụi, chống nước tiêu chuẩn IP25 giúp bảo vệ mạch điện và các linh kiện điện tử bên trong. Trang bị bộ tương thích điện từ EMC Dễ dàng thay đổi 3 chế độ phun với 1 nút nhấn - mang lại cảm giác tắm thoải mái theo ý thích. Vòi sen có tính kháng khuẩn ion Ag+ giúp luồng nước ra sạch hơn, tốt cho da. Tự ngắt gia nhiệt khi nước vào máy quá yếu, dưới 2 lít/phút.',47,N'DH-4MP1VW.jpg',/*N'DH-4MP1VW-1.jpg, DH-4MP1VW-2.jpg, DH-4MP1VW-3.jpg',*/NULL,'NSX003','L009',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP094',N'Máy nước nóng năng lượng mặt trời Kangaroo GD1818 180 lít',12090000,N'Sử dụng năng lượng mặt trời, mang lại hiệu quả tiết kiệm điện. Dung tích bình chứa 180 lít, phù hợp gia đình 3 - 4 người. Bảo vệ sức khỏe người dùng với công nghệ Nano kháng khuẩn. Giữ nhiệt nước nóng đến 96 tiếng nhờ lớp bảo ôn Polyurethane. Thu nhiệt tốt bởi ống chân không công nghệ Nanomax 7 lớp. Chống bám cặn, an toàn với ruột bình làm bằng Inox SUS 304-2B cùng thanh Magie.',9,N'GD1818.jpg',/*N'GD1818-1.jpg, GD1818-2.jpg, GD1818-3.jpg',*/NULL,'NSX008','L009',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP095',N'Máy nước nóng năng lượng mặt trời Kangaroo GD1414 140 lít',10900000,N'Sử dụng năng lượng mặt trời, tiết kiệm điện. Dung tích 140 lít, đáp ứng nhu cầu cho gia đình có 2 - 3 người Bảo vệ sức khỏe người dùng nhờ công nghệ Nano kháng khuẩn. Giữ nhiệt nước nóng đến 96 tiếng bởi lớp bảo ôn Polyurethane. Thu nhiệt tốt với ống chân không công nghệ Nanomax 7 lớp. An toàn, chống bám cặn với ruột bình làm bằng Inox SUS 304-2B. Có thanh Magie giúp chống bám cặn cho lòng bình.',17,N'GD1414.jpg',/*N'GD1414-1.jpg, GD1414-2.jpg, GD1414-3.jpg',*/8170000,'NSX008','L009',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP096',N'Máy nước nóng năng lượng mặt trời Kangaroo GD1616 160 lít',11090000,N'Sử dụng năng lượng mặt trời, mang lại hiệu quả tiết kiệm điện. Dung tích 160 lít, dành cho 3, 4 người sử dụng. Công nghệ Nano diệt khuẩn giúp bảo vệ sức khỏe người dùng. Lớp bảo ôn Polyurethane giúp giữ nước nóng đến 96 tiếng. Thu nhiệt tốt với ống chân không Nanomax 7 lớp. An toàn, độ bền cao với ruột bình bảo ôn làm bằng vật liệu Inox SUS 304-2B.',31,N'GD1616.jpg',/*N'GD1616-1.jpg, GD1616-2.jpg, GD1616-3.jpg',*/8310000,'NSX008','L009',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP097',N'Bình nước nóng Kangaroo 22 lít KG 73R2',2890000,N'Thiết kế tinh tế, cơ chế làm nóng gián tiếp phù hợp với khí hậu miền Bắc. Dung tích 22 lít, đáp ứng nhu cầu sử dụng của 2 - 3 người. An toàn hơn với cầu dao chống rò điện ELCB. Vỏ bình có khả năng chống thấm IP24. Giữ nước nóng lâu hơn nhờ lớp cách nhiệt mật độ cao PU. Màn hình điện tử cho người dùng dễ dàng kiểm soát nhiệt độ. Thanh điện trở Steatite chống bám cặn, làm nóng nhanh và chịu được nước cứng.',26,N'KG 73R2.jpg',/*N'KG 73R2-1.jpg, KG 73R2-2.jpg, KG 73R2-3.jpg',*/2690000,'NSX008','L009',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP098',N'Máy nước nóng Kangaroo 22 lít KG 70A2',2790000,N'An toàn với hệ thống đồng bộ TSS chống giật tích hợp cầu dao ELCB. Công nghệ Nano kháng khuẩn đảm bảo sự trong lành của nước tắm, bảo vệ làn da. Chống bám cặn, rò rỉ nước với lòng bình được tráng kim cương nhân tạo. Kéo dài thời gian giữ nhiệt nước nóng nhờ lớp cách nhiệt mật độ cao PU. Thuộc kiểu máy gián tiếp, có thể dùng chung nhiều thiết bị.',24,N'KG 70A2.jpg',/*N'KG 70A2-1.jpg, KG 70A2-2.jpg, KG 70A2-3.jpg',*/2490000,'NSX007','L009',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP099',N'Máy nước nóng Kangaroo 22 lít KG 72A2',2590000,N'An toàn với các sự cố điện - hệ thống chống giật CSS, cầu dao chống rò điện ELCB. Dung tích 22 lít, đủ để đáp ứng nhu cầu cho khoảng 2 - 3 người. Nguồn nước sạch và an toàn với công nghệ Nano kháng khuẩn. Giữ nước nóng lâu hơn nhờ lớp cách nhiệt mật độ cao PU. Thuộc kiểu máy gián tiếp, có thể dùng chung nhiều thiết bị. Lòng bình tráng kim cương nhân tạo, giúp bình bền bỉ hơn. Chống bám cặn bảo vệ nước luôn sạch với thanh nhiệt mạ bạc kháng khuẩn.',25,N'KG 72A2.jpg',/*N'KG 72A2-1.jpg, KG 72A2-2.jpg, KG 72A2-3.jpg',*/NULL,'NSX007','L009',N'Còn',12)
INSERT INTO SANPHAM VALUES('SP100',N'Máy nước nóng Panasonic DH-4NTP1VM 4500W',5190000,N'Thiết kế nhã nhặn, sang trọng. Làm nóng nước nhanh chóng với công suất 4500 W và hệ thống làm nóng trực tiếp. Lắp đặt bơm trợ lực làm luồng nước mạnh mẽ nhưng vận hành lại siêu êm. Hỗ trợ lọc nước thông qua van cấp nước. Vòi sen có 3 chế độ tiện lợi, đi kèm công nghệ ion Ag+ kháng khuẩn bảo vệ sức khỏe người tiêu dùng. Không lo chập cháy, đảm bảo an toàn về điện nhờ cầu dao ELCB. Vận hành ổn định nhờ cảm biến lưu lượng nước. Bảo vệ hệ thống, tăng tuổi thọ nhờ vỏ chống nước IP25. An toàn về nhiệt, không gây bỏng nhờ chế độ kiểm soát nhiệt độ.',19,N'DH-4NTP1VM.jpg',/*N'DH-4NTP1VM-1.jpg, DH-4NTP1VM-2.jpg, DH-4NTP1VM-3.jpg',*/NULL,'NSX003','L009',N'Còn',12)


INSERT INTO CHUCVU VALUES('CV001',N'Nhân viên thu ngân',150000)
INSERT INTO CHUCVU VALUES('CV002',N'Nhân viên vệ sinh',200000)
INSERT INTO CHUCVU VALUES('CV003',N'Quản lý',350000)

SET DATEFORMAT DMY
INSERT INTO NHANVIEN VALUES ('NV001', N'Minh Hưng', N'Nam', '09/06/2000', '0909672332', N'38/5 Nguyễn Đình Chiểu, Phường Linh Tân, Quận Thủ Đức, TP.HCM','CV001', '12/05/2021')
INSERT INTO NHANVIEN VALUES ('NV002', N'Khôi Nguyên', N'Nam', '05/02/2000', '0912345678', N'176/2 Trần Văn Cơ, Phường Đông Thị Ngâu, Quận Bình Tân, TP.HCM','CV003', '12/05/2021')
INSERT INTO NHANVIEN VALUES ('NV003', N'Bảo Toàn', N'Nam', '26/10/2000', '0309328723', N'225 Trần Bàng, Phường 7, Huyện Tân Thành, Tiền Giang','CV002', '12/05/2021')
INSERT INTO NHANVIEN VALUES ('NV004', N'Phương Linh', N'Nữ', '05/06/1999', '0390764398', N'111/4 Lê Trọng Tấn, Phường Tây Thạnh, Quận Tân Phú, TP.HCM','CV002', '12/05/2021')
INSERT INTO NHANVIEN VALUES ('NV005', N'Phương Hoài', N'Nữ', '11/06/2000', '095639182', N'715 Phan Xích Long, Phường 11, Quận Bình Thạnh, TP.HCM','CV001', '12/05/2021')
INSERT INTO NHANVIEN VALUES ('NV006', N'Hoài Thương', N'Nữ', '02/09/2001', '0908274638', N'124 Phan Xích Long, Phường 11, Quận Bình Thạnh, TP.HCM','CV001', '12/05/2021')
INSERT INTO NHANVIEN VALUES ('NV007', N'Phương Thảo', N'Nữ', '24/04/1996', '0902472195', N'881 Sơn Kì, Tân Phú, TP.HCM','CV002', '12/05/2021')
INSERT INTO NHANVIEN VALUES ('NV008', N'Phương Hằng', N'Nữ', '31/01/1999', '0956239815', N'258 Nguyễn Xí, Quận Bình Thạnh, TP.HCM','CV001', '12/05/2021')
INSERT INTO NHANVIEN VALUES ('NV009', N'Phương Tuấn', N'Nam', '04/12/2000', '0912053961', N'625 Phan Huy Ích,Tân Bình, TP.HCM','CV002', '12/05/2021')
INSERT INTO NHANVIEN VALUES ('NV010', N'Phương Nam', N'Nam', '15/09/1997', '0919461297', N'827 Trần Quang Khải, Quận 10, TP.HCM','CV002', '12/05/2021')


SET DATEFORMAT DMY
INSERT INTO DIEMDANH VALUES('NV001','10/05/2020')
INSERT INTO DIEMDANH VALUES('NV003','11/05/2020')
INSERT INTO DIEMDANH VALUES('NV004','12/05/2020')


INSERT INTO NGUOIDUNG VALUES('admin111','123','NV002')
INSERT INTO NGUOIDUNG VALUES('nhanvien112','123','NV001')
INSERT INTO NGUOIDUNG VALUES('nhanvien12','123','NV005')

INSERT INTO NHOMNGUOIDUNG VALUES('admin',N'Quản Lý',null)
INSERT INTO NHOMNGUOIDUNG VALUES('NV',N'Nhân Viên',null)

INSERT INTO QL_NGUOIDUNGNHOMNGUOIDUNG VALUES('admin111','admin',null)
INSERT INTO QL_NGUOIDUNGNHOMNGUOIDUNG VALUES('nhanvien112','NV',null)
INSERT INTO QL_NGUOIDUNGNHOMNGUOIDUNG VALUES('nhanvien12','NV',null)


INSERT INTO MANHINH VALUES('MH001',N'Tạo tài khoản')
INSERT INTO MANHINH VALUES('MH002',N'Đổi mật khẩu')
INSERT INTO MANHINH VALUES('MH003',N'Điểm danh')
INSERT INTO MANHINH VALUES('MH004',N'Cấp quyền')
INSERT INTO MANHINH VALUES('MH005',N'Loại khách hàng')
INSERT INTO MANHINH VALUES('MH006',N'Khách hàng')
INSERT INTO MANHINH VALUES('MH007',N'Nhân viên')
INSERT INTO MANHINH VALUES('MH008',N'Nhà sản xuất')
INSERT INTO MANHINH VALUES('MH009',N'Loại thiết bị')
INSERT INTO MANHINH VALUES('MH010',N'Sản phẩm')
INSERT INTO MANHINH VALUES('MH011',N'Chức vụ')
INSERT INTO MANHINH VALUES('MH012',N'Nhập hàng')
INSERT INTO MANHINH VALUES('MH013',N'Thanh toán')
INSERT INTO MANHINH VALUES('MH014',N'Bảo hành')
INSERT INTO MANHINH VALUES('MH015',N'Xem hóa đơn/phiếu nhập')
INSERT INTO MANHINH VALUES('MH016',N'Tư vấn khách hàng')
INSERT INTO MANHINH VALUES('MH017',N'Phiếu nhập')
INSERT INTO MANHINH VALUES('MH018',N'Doanh thu')
INSERT INTO MANHINH VALUES('MH019',N'Lương nhân viên')

INSERT INTO PHANQUYEN VALUES('NV','MH001',0)
INSERT INTO PHANQUYEN VALUES('NV','MH002',1)
INSERT INTO PHANQUYEN VALUES('NV','MH003',1)
INSERT INTO PHANQUYEN VALUES('NV','MH004',0)
INSERT INTO PHANQUYEN VALUES('NV','MH005',0)
INSERT INTO PHANQUYEN VALUES('NV','MH006',1)
INSERT INTO PHANQUYEN VALUES('NV','MH007',0)
INSERT INTO PHANQUYEN VALUES('NV','MH008',1)
INSERT INTO PHANQUYEN VALUES('NV','MH009',1)
INSERT INTO PHANQUYEN VALUES('NV','MH010',1)
INSERT INTO PHANQUYEN VALUES('NV','MH011',0)
INSERT INTO PHANQUYEN VALUES('NV','MH012',1)
INSERT INTO PHANQUYEN VALUES('NV','MH013',1)
INSERT INTO PHANQUYEN VALUES('NV','MH014',1)
INSERT INTO PHANQUYEN VALUES('NV','MH015',1)
INSERT INTO PHANQUYEN VALUES('NV','MH016',1)
INSERT INTO PHANQUYEN VALUES('NV','MH017',0)
INSERT INTO PHANQUYEN VALUES('NV','MH018',0)
INSERT INTO PHANQUYEN VALUES('NV','MH019',0)


select * from SANPHAM where MATHIETBI = 'L001'
select * from SANPHAM where MATHIETBI = 'L002'
select * from SANPHAM where MATHIETBI = 'L003'
select * from SANPHAM where MATHIETBI = 'L004'
select * from SANPHAM where MATHIETBI = 'L005'
select * from SANPHAM where MATHIETBI = 'L006'
select * from SANPHAM where MATHIETBI = 'L007'
select * from SANPHAM where MATHIETBI = 'L008'
select * from SANPHAM where MATHIETBI = 'L009'
select * from SANPHAM where MATHIETBI = 'L010'


