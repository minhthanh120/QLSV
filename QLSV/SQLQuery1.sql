CREATE DATABASE QLSV
GO

USE QLSV
GO

CREATE TABLE SINHVIEN
(
    MASV INT PRIMARY KEY IDENTITY(1, 1),
    TENSV NVARCHAR(50),
    LOP NVARCHAR(10),
    KHOA NVARCHAR(10),
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
    CONSTRAINT kt_diemtp CHECK(DIEMTP<=10 AND DIEMTP>0),
    CONSTRAINT kt_diemqt CHECK(DIEMQT<=10 AND DIEMQT>0)
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
    [TENSV], [GIOITINH], [NGAYSINH], [LOP], [KHOA]
    )
VALUES
    ( -- first row: values for the columns in the list above
        N'Nguyễn Văn A', N'Nam', '1999-01-01', N'K17', N'2021'
),
    ( -- second row: values for the columns in the list above
        N'Do Văn B', N'Nam', '1999-01-01', N'K17', N'2021'
),
    ( -- second row: values for the columns in the list above
        N'Ly Văn C', N'Nam', '1999-01-01', N'K17', N'2021'
),
    ( -- second row: values for the columns in the list above
        N'Hà Thị D', N'Nữ', '1999-01-01', N'K17', N'2021'
),
    ( -- second row: values for the columns in the list above
        N'Tăng Văn E', N'Nam', '1999-01-01', N'K17', N'2021'
),
    ( -- second row: values for the columns in the list above
        N'Nguyễn Văn F', N'Nam', '1999-01-01', N'K17', N'2021'
),
    ( -- second row: values for the columns in the list above
        N'Hồ Văn G', N'Nam', '1999-01-01', N'K17', N'2021'
),
    ( -- second row: values for the columns in the list above
        N'Nguyễn Văn H', N'Nam', '1999-01-01', N'K17', N'2021'
),
    ( -- second row: values for the columns in the list above
        N'Cao Văn I', N'Nam', '1999-01-01', N'K17', N'2021'
),
    ( -- second row: values for the columns in the list above
        N'Lê Văn J', N'Nam', '1999-01-01', N'K17', N'2021'
)
-- add more rows here
GO


-- Insert rows into table 'TableName'
INSERT INTO SV_MH
    ( -- columns to insert data into
    [MAMON], [MASV]
    )
VALUES
    ( -- first row: values for the columns in the list above
        1, 1
),
    ( -- second row: values for the columns in the list above
        1, 2
),
    (
        1, 3
),
    (1, 4),
    (2, 1),
    (2, 3),
    (3, 3),
    (3, 4),
    (4, 4),
    (4, 5),
    (5, 5)
-- add more rows here
GO


-- THỦ TỤC CHỨC NĂNG


-- Proc lấy thông tin các môn học mà sinh viên đã đăng ký
CREATE OR ALTER PROCEDURE DANHSACHDIEM
    @param1 int
AS
BEGIN
    -- body of the stored procedure
    SELECT sm.MAMON, mh.TENMH, mh.SOTIET, sm.DIEMTK, sm.DIEMQT, sm.DIEMTP, sm.DANHGIA
    FROM SV_MH as sm JOIN MONHOC as mh on sm.MAMON = mh.MAMON
    WHERE sm.MASV= @param1
END
GO


-- example to execute the stored procedure we just created
EXECUTE DANHSACHDIEM @param1 = 1
GO

-- Proc danh sách sinh viên và số môn học sinh viên đã đăng ký
CREATE OR ALTER PROCEDURE DANHSACHSINHVIEN
AS
BEGIN
    SELECT sv.MASV, sv.TENSV, sv.NGAYSINH, sv.GIOITINH, sv.LOP, sv.KHOA, COUNT(sm.MASV) as N'Số môn học'
    FROM SINHVIEN as sv FULL JOIN SV_MH as sm on sm.MASV=sv.MASV
    GROUP BY sv.TENSV,sv.MASV, sv.NGAYSINH, sv.GIOITINH, sv.LOP, sv.KHOA
END
GO
-- example to execute the stored procedure we just created
EXECUTE DANHSACHSINHVIEN
GO

--Proc nhập điểm
CREATE or ALTER PROCEDURE NHAPDIEM
    @DIEMQT FLOAT,
    @DIEMTP FLOAT,
    @MAMON INT,
    @MASV INT
AS
DECLARE @DIEMTK FLOAT
BEGIN
    --Tính điểm tổng kết và làm tròn
    set @DIEMTK = ROUND((@DIEMQT  +@DIEMTP)/2, 2)
    --UPDATE điểm tp, điểm qt
    UPDATE SV_MH SET DIEMQT=@DIEMQT, DIEMTP=@DIEMTP WHERE MASV=@MASV AND MAMON=@MAMON
    -- Đánh giá và UPDATE điểm tổng kết
    IF (@DIEMTK<4)
        UPDATE SV_MH SET DIEMTK=@DIEMTK, DANHGIA=N'Chưa đạt' WHERE MASV=@MASV AND MAMON=@MAMON
    ELSE
        UPDATE SV_MH SET DIEMTK=@DIEMTK, DANHGIA=N'Đạt' WHERE MASV=@MASV AND MAMON=@MAMON
END
GO


--TRIGGER xóa điểm khi xóa sinh viên
CREATE OR ALTER TRIGGER XOADIEM ON SINHVIEN INSTEAD OF DELETE
AS
DECLARE @MA INT
BEGIN
    SELECT @MA=MASV
    FROM deleted
    DELETE SV_MH WHERE MASV=@MA
END
GO

--Xóa điểm của môn học khi xóa môn học
CREATE OR ALTER TRIGGER XOAMON ON MONHOC INSTEAD OF DELETE
AS
DECLARE @MA INT
BEGIN
    SELECT @MA=MAMON
    FROM deleted
    DELETE SV_MH WHERE MAMON=@MA
END

SELECT *
FROM SINHVIEN

execute NHAPDIEM 3,3,1,2

select *
from SV_MH
-- use master
-- drop DATABASE QLSV

SELECT *
FROM SV_MH