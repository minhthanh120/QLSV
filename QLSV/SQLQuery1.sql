CREATE DATABASE QLSV
GO

USE QLSV
GO
CREATE TABLE LOP
(
    MALOP INT PRIMARY KEY IDENTITY(1,1),
    TENLOP NVARCHAR(50)
)
GO
CREATE TABLE KHOA
(
    MAKHOA INT PRIMARY KEY IDENTITY(1,1),
    TENKHOA NVARCHAR(10)
)
GO
CREATE TABLE SINHVIEN
(
    MASV INT PRIMARY KEY IDENTITY(1, 1),
    TENSV NVARCHAR(50),
    MALOP INT FOREIGN KEY REFERENCES LOP(MALOP),
    MAKHOA INT FOREIGN KEY REFERENCES KHOA(MAKHOA),
    NGAYSINH DATE,
    GIOITINH NVARCHAR(3),
    CONSTRAINT kt_gioitinh CHECK(GIOITINH=N'Nam' OR GIOITINH=N'Nữ')
)
GO

CREATE TABLE MONHOC
(
    MAMON INT PRIMARY KEY IDENTITY(1,1),
    TENMH NVARCHAR(50),
    SOTIET INT,
    CONSTRAINT kt_sotiet CHECK(SOTIET <5)
)
GO

CREATE TABLE SV_MH
(
    MASV INT FOREIGN KEY REFERENCES SINHVIEN(MASV),
    MAMON INT FOREIGN KEY REFERENCES MONHOC(MAMON),
    PRIMARY KEY(MASV, MAMON),
    DIEMTP FLOAT,
    DIEMQT FLOAT,
    DIEMTK FLOAT,
    DANHGIA NVARCHAR(10),
    CONSTRAINT kt_diemtp CHECK(DIEMTP<10 AND DIEMTP>0),
    CONSTRAINT kt_diemqt CHECK(DIEMQT<10 AND DIEMQT>0)
)
GO

-- Insert rows into table 'LOP'
INSERT INTO LOP
    ( -- columns to insert data into
    [TENLOP]
    )
VALUES
    ( -- first row: values for the columns in the list above
        N'Công nghệ thông tin'
),
    ( -- second row: values for the columns in the list above
        N'Tự động hóa'
),
    (
        N'Cơ điện tử'
),
    (
        N'Xây dựng'
),
    (
        N'Khoa học máy tính'
)
-- add more rows here
GO

select *
FROM KHOA

-- Insert rows into table 'KHOA'
INSERT INTO KHOA
    ( -- columns to insert data into
    [TENKHOA]
    )
VALUES
    ( -- first row: values for the columns in the list above
        N'1920'
),
    ( -- second row: values for the columns in the list above
        N'2021'
),
    (N'2122')
-- add more rows here
GO

-- Insert rows into table 'MONHOC'
INSERT INTO MONHOC
    ( -- columns to insert data into
    [TENMH], [SOTIET]
    )
VALUES
    ( -- first row: values for the columns in the list above
        N'Giải tích', 4
),
    ( -- second row: values for the columns in the list above
        N'Hình họa', 2
),
    (
        N'Vật lý đại cương', 4
),
    (
        N'Xử lý ngôn ngữ tự nhiên', 3
        ),
    (
        N'Xử lý hình ảnh', 3
        )
-- add more rows here
GO

-- Insert rows into table 'SINHVIEN'
INSERT INTO SINHVIEN
( -- columns to insert data into
 [TENSV], [GIOITINH], [NGAYSINH], [MALOP], [MAKHOA]
)
VALUES
( -- first row: values for the columns in the list above
 N'Nguyễn Văn A', N'Nam', '1999-01-01',1,1
),
( -- second row: values for the columns in the list above
 N'Do Văn B', N'Nam', '1999-01-01',2,2
),
( -- second row: values for the columns in the list above
 N'Ly Văn C', N'Nam', '1999-01-01',3,3
),
( -- second row: values for the columns in the list above
 N'Hà Thị D', N'Nữ', '1999-01-01',4,3
),
( -- second row: values for the columns in the list above
 N'Tăng Văn E', N'Nam', '1999-01-01',5,2
),
( -- second row: values for the columns in the list above
 N'Nguyễn Văn F', N'Nam', '1999-01-01',1,1
),
( -- second row: values for the columns in the list above
 N'Hồ Văn G', N'Nam', '1999-01-01',2,2
),
( -- second row: values for the columns in the list above
 N'Nguyễn Văn H', N'Nam', '1999-01-01',3,3
),
( -- second row: values for the columns in the list above
 N'Cao Văn I', N'Nam', '1999-01-01',4,3
),
( -- second row: values for the columns in the list above
 N'Lê Văn J', N'Nam', '1999-01-01',5,2
)
-- add more rows here
GO

SELECT * from SINHVIEN