-- Tạo cơ sở dữ liệu và sử dụng
CREATE DATABASE NHT_2310900105;
GO

USE NHT_2310900105;
GO

-- Tạo bảng NhtEmployee
CREATE TABLE NhtEmployee (
    NhtEmpId INT PRIMARY KEY,
    NhtEmpName NVARCHAR(100),
    NhtEmpLevel NVARCHAR(50),
    NhtEmpStartDate DATE,
    NhtEmpStatus BIT
);
GO

-- Thêm dữ liệu mẫu (bao gồm thông tin của Nguyễn Hữu Tuyên)
INSERT INTO NhtEmployee (NhtEmpId, NhtEmpName, NhtEmpLevel, NhtEmpStartDate, NhtEmpStatus)
VALUES
(1, N'Nguyễn Hữu Tuyên', N'Senior Developer', '2022-09-01', 1), -- Thông tin cá nhân
(2, N'Lê Văn Nam', N'Junior Tester', '2023-04-10', 0),
(3, N'Trần Thị Mai', N'Mid DevOps', '2021-12-05', 1);
GO
