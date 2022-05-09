CREATE DATABASE MVCQLSV
GO
/*
drop DATABASE MVCQLSV

use master
*/
USE MVCQLSV
GO

CREATE TABLE SINHVIEN
(
    MASV INT PRIMARY KEY IDENTITY(1, 1),
    TENSV NVARCHAR(50),
    LOP NVARCHAR(10),
    KHOA NVARCHAR(10),
    NGAYSINH DATE,
    GIOITINH BIT,
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
        N'Nguyễn Văn A', 1, '1998-09-01', N'K17', N'2021'
),
    ( -- second row: values for the columns in the list above
        N'Do Thị B', 0, '1999-08-02', N'K17', N'2021'
),
    ( -- second row: values for the columns in the list above
        N'Ly Văn C', 1, '2000-07-03', N'K17', N'2021'
),
    ( -- second row: values for the columns in the list above
        N'Hà Thị D', 0, '2001-06-04', N'K17', N'2021'
),
    ( -- second row: values for the columns in the list above
        N'Tăng Văn E', 1, '2000-05-05', N'K17', N'2021'
),
    ( -- second row: values for the columns in the list above
        N'Nguyễn Thị F', 0, '1999-04-06', N'K17', N'2021'
),
    ( -- second row: values for the columns in the list above
        N'Hồ Văn G', 1, '1998-03-07', N'K17', N'2021'
),
    ( -- second row: values for the columns in the list above
        N'Nguyễn Thị H', 0, '1997-02-08', N'K17', N'2021'
),
    ( -- second row: values for the columns in the list above
        N'Cao Văn I', 1, '1996-01-09', N'K17', N'2021'
),
    ( -- second row: values for the columns in the list above
        N'Lê Thị J', 0, '1995-01-10', N'K17', N'2021'
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
    SELECT sm.MAMON as MaMH, mh.TENMH as TenMH, mh.SOTIET as SoTiet, sm.DIEMTK as DiemTK, sm.DIEMQT as DiemQT, sm.DIEMTP as DiemTP, sm.DANHGIA as DanhGia
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
    SELECT sv.MASV as MaSV, sv.TENSV as TenSV, sv.NGAYSINH as DOB, sv.GIOITINH As GioiTinh, sv.LOP as Lop, sv.KHOA as Khoa, COUNT(sm.MASV) as N'SoMon'
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
execute NHAPDIEM 10,10,1,1

EXECUTE NHAPDIEM @DIEMQT = diemqt, @DIEMTP = diemtp, @MAMON = mamon, @MASV = masv

select *
from SV_MH
-- use master
-- drop DATABASE QLSV

SELECT * FROM SINHVIEN WHERE TENSV = '' OR '1' = '1' and LOP = '' OR '1' = '1'