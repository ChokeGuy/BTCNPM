CREATE DATABASE QLSinhVien
USE QLSinhVien
GO
CREATE TABLE ACCOUNT(
	taikhoan nchar(50) NOT NULL,
	matkhau char(50) NOT NULL,
	quyen int
)
CREATE TABLE SINHVIEN(
  hoten nvarchar(60),
  lop char(20),
  khoa nvarchar(60),
  email nvarchar(60),
  mssv char(20),
  namsinh date,
  PRIMARY KEY (mssv)
)
GO
Insert into ACCOUNT Values('admin','123456',0)
GO
Insert into SINHVIEN Values(N'Nguyễn Ngọc Thắng','201101B',N'Công Nghệ Thông Tin','20110727@student.hcmute.edu.vn','20110727','2/11/2002')
Insert into SINHVIEN Values(N'Nguyễn Hữu Linh','191102A',N'Công Nghệ Thông Tin','19110246@student.hcmute.edu.vn','19110246','3/8/2001')
Insert into SINHVIEN Values(N'Cao Thanh Tâm','20101A',N'Thời Trang','20110323@student.hcmute.edu.vn','20110323','4/6/2002')
Insert into SINHVIEN Values(N'Trần Minh Anh','181102A',N'Xây Dựng','18120244@student.hcmute.edu.vn','18120244','2/10/2000')
Insert into SINHVIEN Values(N'Nguyễn Hữu Thắng','201101B',N'Công Nghệ Thông Tin','20110725@student.hcmute.edu.vn','20110725','12/11/2002')
Insert into SINHVIEN Values(N'Vũ Nguyễn Minh An','191102A',N'Kinh Tế','19112003@student.hcmute.edu.vn','19112002','2/4/2001')
Insert into SINHVIEN Values(N'Vũ Cao Minh','201001A',N'Điện/Điện Tử','20110231@student.hcmute.edu.vn','20110231','5/7/2002')
Insert into SINHVIEN Values(N'Trần Trọng Nam','181101C',N'Xây Dựng','18092010@student.hcmute.edu.vn','18092010','3/4/2000')
Insert into SINHVIEN Values(N'Chung Minh Thành','191102C',N'Công Nghệ Thông Tin','19110565@student.hcmute.edu.vn','19110565','3/6/2001')
Insert into SINHVIEN Values(N'Lê Minh Quân','201102A',N'Công Nghệ Thông Tin','20110277@student.hcmute.edu.vn','2011277','12/7/2002')