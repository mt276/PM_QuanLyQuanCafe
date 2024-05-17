USE [master]
GO
/****** Object:  Database [QuanLyQuanCafe]    Script Date: 4/16/2024 12:48:10 PM ******/
CREATE DATABASE [QuanLyQuanCafe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyQuanCafe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MINHTRIEU\MSSQL\DATA\QuanLyQuanCafe.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyQuanCafe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MINHTRIEU\MSSQL\DATA\QuanLyQuanCafe_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QuanLyQuanCafe] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyQuanCafe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyQuanCafe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyQuanCafe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyQuanCafe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyQuanCafe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyQuanCafe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET RECOVERY FULL 
GO
ALTER DATABASE [QuanLyQuanCafe] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyQuanCafe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyQuanCafe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyQuanCafe] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyQuanCafe] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanLyQuanCafe', N'ON'
GO
ALTER DATABASE [QuanLyQuanCafe] SET QUERY_STORE = OFF
GO
USE [QuanLyQuanCafe]
GO
/****** Object:  UserDefinedFunction [dbo].[fuConvertToUnsign1]    Script Date: 4/16/2024 12:48:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--SELECT t.name, b.totalPrice, DateCheckIn, DateCheckOut, discount
--FROM  dbo.Bill b, dbo.FTable t, dbo.BillInfo bi, dbo.Menu m
--WHERE DateCheckIn >= '20240412' AND DateCheckOut <= '20240412' AND b.statusBill = 1
--AND t.idTable = b.idTable AND bi.idBill = b.idBill AND bi.idMenu = m.idMenu
--DBCC CHECKIDENT('dbo.BillInfo', RESEED, 0) -- reset IDENTITY về 0
--DBCC CHECKIDENT('dbo.Bill', RESEED, 0) -- reset IDENTITY về 0
--DBCC CHECKIDENT('dbo.FTable', RESEED, 24) -- reset IDENTITY về 0
--DBCC CHECKIDENT('dbo.Category', RESEED, 7) -- reset IDENTITY về 0
--DBCC CHECKIDENT('dbo.Menu', RESEED, 16) -- reset IDENTITY về 0
--DELETE dbo.BillInfo
--DELETE dbo.Bill
--select * from Bill
--select * from FTable
--select * from BillInfo

CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END

--select * from FTable
--select * from Bill
--select * from BillInfo


GO
/****** Object:  Table [dbo].[Account]    Script Date: 4/16/2024 12:48:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[UserName] [nvarchar](100) NOT NULL,
	[DisplayName] [nvarchar](100) NOT NULL,
	[PassWord] [nvarchar](1000) NOT NULL,
	[TypeUser] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 4/16/2024 12:48:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[idBill] [int] IDENTITY(1,1) NOT NULL,
	[DateCheckIn] [date] NOT NULL,
	[DateCheckOut] [date] NULL,
	[idTable] [int] NOT NULL,
	[statusBill] [int] NOT NULL,
	[discount] [int] NULL,
	[totalPrice] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[idBill] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillInfo]    Script Date: 4/16/2024 12:48:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillInfo](
	[idBillInfo] [int] IDENTITY(1,1) NOT NULL,
	[idBill] [int] NOT NULL,
	[idMenu] [int] NOT NULL,
	[count] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idBillInfo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 4/16/2024 12:48:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[idCategory] [int] IDENTITY(1,1) NOT NULL,
	[nameCategory] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FTable]    Script Date: 4/16/2024 12:48:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FTable](
	[idTable] [int] IDENTITY(1,1) NOT NULL,
	[nameTable] [nvarchar](100) NOT NULL,
	[statusTable] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idTable] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 4/16/2024 12:48:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[idMenu] [int] IDENTITY(1,1) NOT NULL,
	[nameMenu] [nvarchar](100) NOT NULL,
	[idCategory] [int] NOT NULL,
	[price] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idMenu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT (N'Admin') FOR [DisplayName]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [PassWord]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [TypeUser]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT (getdate()) FOR [DateCheckIn]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [statusBill]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [discount]
GO
ALTER TABLE [dbo].[Bill] ADD  DEFAULT ((0)) FOR [totalPrice]
GO
ALTER TABLE [dbo].[BillInfo] ADD  DEFAULT ((0)) FOR [count]
GO
ALTER TABLE [dbo].[Category] ADD  DEFAULT (N'Chưa đặt tên') FOR [nameCategory]
GO
ALTER TABLE [dbo].[FTable] ADD  DEFAULT (N'Bàn chưa có tên') FOR [nameTable]
GO
ALTER TABLE [dbo].[FTable] ADD  DEFAULT (N'Trống') FOR [statusTable]
GO
ALTER TABLE [dbo].[Menu] ADD  DEFAULT (N'Chưa đặt tên') FOR [nameMenu]
GO
ALTER TABLE [dbo].[Menu] ADD  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD FOREIGN KEY([idTable])
REFERENCES [dbo].[FTable] ([idTable])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([idBill])
REFERENCES [dbo].[Bill] ([idBill])
GO
ALTER TABLE [dbo].[BillInfo]  WITH CHECK ADD FOREIGN KEY([idMenu])
REFERENCES [dbo].[Menu] ([idMenu])
GO
ALTER TABLE [dbo].[Menu]  WITH CHECK ADD FOREIGN KEY([idCategory])
REFERENCES [dbo].[Category] ([idCategory])
GO
/****** Object:  StoredProcedure [dbo].[USP_CombineTable]    Script Date: 4/16/2024 12:48:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select * from Bill
--select * from BillInfo
--EXEC USP_SwitchTable
--@idOldTable= 2, @idNewTable =1
CREATE PROCEDURE [dbo].[USP_CombineTable]
    @idOldTable INT,
    @idNewTable INT
AS
BEGIN
    -- Khai báo các biến
    DECLARE @idOldBill INT
    DECLARE @idNewBill INT
	DECLARE @OldCount INT
    DECLARE @NewCount INT
    DECLARE @idOldTableEmpty INT
    DECLARE @idNewTableEmpty INT

    -- Tìm hóa đơn của bàn cũ và mới
    SELECT @idOldBill = idBill FROM dbo.Bill WHERE idTable = @idOldTable AND statusBill = 0
    SELECT @idNewBill = idBill FROM dbo.Bill WHERE idTable = @idNewTable AND statusBill = 0

    -- Nếu không tìm thấy hóa đơn của bàn cũ, tạo một hóa đơn mới
    IF @idOldBill IS NULL
    BEGIN
        INSERT INTO dbo.Bill (DateCheckIn, DateCheckOut, idTable, statusBill,totalPrice)
        VALUES (GETDATE(), NULL, @idOldTable, 0,0)

        SELECT @idOldBill = SCOPE_IDENTITY() -- Lấy ID của hóa đơn mới tạo
    END

    -- Nếu không tìm thấy hóa đơn của bàn mới, tạo một hóa đơn mới
    IF @idNewBill IS NULL
    BEGIN
        INSERT INTO dbo.Bill (DateCheckIn, DateCheckOut, idTable, statusBill,totalPrice)
        VALUES (GETDATE(), NULL, @idNewTable, 0,0)

        SELECT @idNewBill = SCOPE_IDENTITY() -- Lấy ID của hóa đơn mới tạo
    END
	-- Cập nhật số lượng cho các mục có cùng idMenu trong bàn mới và bàn cũ
	UPDATE bi 
	SET bi.count = bi.count + b.count
	FROM dbo.BillInfo bi
	INNER JOIN dbo.BillInfo b ON bi.idBill = @idNewBill AND b.idBill = @idOldBill AND bi.idMenu = b.idMenu
	-- Thêm các mục mới từ bàn cũ vào bàn mới
	INSERT INTO dbo.BillInfo (idBill, idMenu, count)
	SELECT @idNewBill, idMenu, count
	FROM dbo.BillInfo
	WHERE idBill = @idOldBill
    AND idMenu NOT IN (SELECT idMenu FROM dbo.BillInfo WHERE idBill = @idNewBill)


		-- Xóa thông tin hóa đơn từ bàn cũ ra khỏi hệ thống
	DELETE FROM dbo.BillInfo WHERE idBill = @idOldBill
	    -- Xóa hóa đơn từ bàn cũ khỏi hệ thống
    DELETE FROM dbo.Bill WHERE idBill = @idOldBill
    -- Kiểm tra xem bàn cũ có trống không
    SELECT @idOldTableEmpty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idOldBill

    -- Kiểm tra xem bàn mới có trống không
    SELECT @idNewTableEmpty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idNewBill

    -- Nếu bàn cũ trống, cập nhật trạng thái của bàn cũ
    IF @idOldTableEmpty = 0
        UPDATE dbo.FTable SET statusTable = N'Trống' WHERE idTable = @idOldTable

    -- Nếu bàn mới trống, cập nhật trạng thái của bàn mới
    IF @idNewTableEmpty = 0
        UPDATE dbo.FTable SET statusTable = N'Trống' WHERE idTable = @idNewTable


END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetAccountByUserName]    Script Date: 4/16/2024 12:48:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Thêm stored procedure
CREATE PROC [dbo].[USP_GetAccountByUserName]
@userName NVARCHAR(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListAccount]    Script Date: 4/16/2024 12:48:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListAccount]
AS
BEGIN
	SELECT UserName  , DisplayName , TypeUser  FROM dbo.Account
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListBillByDate]    Script Date: 4/16/2024 12:48:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[USP_GetListBillByDate]
@checkIn date, @checkOut date
AS
BEGIN
	SELECT nameTable AS [Tên bàn], b.totalPrice AS [Tổng tiền], FORMAT(DateCheckIn,'dddd,d MMMM, yyyy') AS [Ngày vào], FORMAT(DateCheckOut,'dddd,d MMMM, yyyy') AS [Ngày ra], discount [Giảm giá(%)]
	FROM dbo.FTable t, dbo.Bill b 
	WHERE DateCheckIn >= @checkIn AND DateCheckOut<=@checkOut AND statusBill=1 AND t.idTable = b.idTable
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListBillByDateForReport]    Script Date: 4/16/2024 12:48:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListBillByDateForReport]
@checkIn date, @checkOut date
AS
BEGIN
	SELECT nameTable, b.totalPrice, DateCheckIn,DateCheckOut, discount
	FROM dbo.FTable t, dbo.Bill b 
	WHERE DateCheckIn >= @checkIn AND DateCheckOut<=@checkOut AND statusBill=1 AND t.idTable = b.idTable
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListCategory]    Script Date: 4/16/2024 12:48:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListCategory]
AS
BEGIN
	SELECT idCategory, nameCategory FROM dbo.Category
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListMenuByCategory]    Script Date: 4/16/2024 12:48:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListMenuByCategory]
AS
BEGIN
	SELECT idMenu, nameMenu, c.idCategory, nameCategory, price FROM dbo.Menu m, dbo.Category c WHERE m.idCategory = c.idCategory 
	--SELECT idMenu, nameMenu, idCategory, price FROM dbo.Menu 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListTable]    Script Date: 4/16/2024 12:48:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetListTable]
AS
BEGIN
	SELECT idTable, nameTable, statusTable FROM dbo.FTable 
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetTableByID]    Script Date: 4/16/2024 12:48:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetTableByID]
    @idTable INT
AS
BEGIN
    SELECT idTable, nameTable, statusTable
    FROM dbo.FTable
    WHERE idTable = @idTable;
END
GO
/****** Object:  StoredProcedure [dbo].[USP_GetTableList]    Script Date: 4/16/2024 12:48:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetTableList]
AS SELECT * FROM dbo.FTable
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBill]    Script Date: 4/16/2024 12:48:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertBill]
@idTable INT
AS
BEGIN
	INSERT   dbo.Bill
			 (	DateCheckIn, DateCheckOut,idTable, statusBill ,discount
			 )
	VALUES	 (	GETDATE(),null, @idTable, 0 ,0
			 )
END
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBillInfo]    Script Date: 4/16/2024 12:48:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_InsertBillInfo]
@idBill INT, @idMenu INT, @count INT
AS
BEGIN

	DECLARE @isExitBillInfo INT
	DECLARE @menuCount INT = 1

	SELECT @isExitBillInfo = idBillInfo, @menuCount = count 
	FROM dbo.BillInfo
	WHERE idBill = @idBill AND idMenu = @idMenu

	IF(@isExitBillInfo > 0)
	BEGIN
		DECLARE	@newCount INT = @menuCount + @count
		IF(@newCount > 0)		
			UPDATE dbo.BillInfo SET count = @menuCount + @count WHERE idMenu = @idMenu
		ELSE
			DELETE FROM dbo.BillInfo WHERE idBill = @idBill AND idMenu = @idMenu
			--DELETE FROM dbo.Bill WHERE idBill=@idBill AND EXISTS(SELECT * FROM dbo.Bill as b, dbo.BillInfo bi WHERE b.idBill=bi.idBill)
	END
	ELSE
	BEGIN
		IF(@count>0)
		INSERT INTO dbo.BillInfo
					 (	idBill, idMenu,count
					 )
		VALUES		 (	@idBill,@idMenu,@count
					 )
	END
END
GO
/****** Object:  StoredProcedure [dbo].[USP_Login]    Script Date: 4/16/2024 12:48:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_Login]
@userName NVARCHAR(100),
@password NVARCHAR(1000)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName AND PassWord = @password
END
GO
/****** Object:  StoredProcedure [dbo].[USP_SwitchTable]    Script Date: 4/16/2024 12:48:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_SwitchTable]
@idOldTable INT, @idNewTable INT
AS 
BEGIN

	DECLARE @idOldBill INT 
	DECLARE @idNewBill INT
	DECLARE @idOldTableEmty INT
	DECLARE @idNewTableEmty INT
	
	SELECT  @idOldBill = idBill FROM dbo.Bill WHERE idTable = @idOldTable AND statusBill =0
	SELECT  @idNewBill = idBill FROM dbo.Bill WHERE idTable = @idNewTable AND statusBill =0

	
	IF(@idOldBill IS null)
	BEGIN
		INSERT INTO dbo.Bill 
					( DateCheckIn, DateCheckOut, idTable, statusBill, totalPrice
					)
		VALUES		( GETDATE(), null, @idOldTable, 0,0
					)
		SELECT @idOldBill = MAX(idBill) FROM dbo.Bill WHERE idTable = @idOldTable AND statusBill = 0
	END

	SELECT @idOldTableEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idOldBill

	IF(@idNewBill IS null )
	BEGIN
		INSERT INTO dbo.Bill 
					( DateCheckIn, DateCheckOut, idTable, statusBill, totalPrice
					)
		VALUES		( GETDATE(), null, @idNewTable, 0,0
					)
		SELECT @idNewBill = MAX(idBill) FROM dbo.Bill WHERE idTable = @idNewTable AND statusBill = 0
	END

	SELECT @idNewTableEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idNewBill


	SELECT idBillInfo INTO IDBillInfoTable FROM dbo.BillInfo WHERE idBill = @idNewBill


	UPDATE dbo.BillInfo SET idBill = @idNewBill WHERE idBill = @idOldBill


	UPDATE dbo.BillInfo SET idBill = @idOldBill WHERE idBillInfo IN (SELECT * FROM IDBillInfoTable)

	DROP TABLE IDBillInfoTable
	IF(@idOldTableEmty=0)
		UPDATE dbo.FTable SET statusTable = N'Trống' WHERE idTable = @idNewTable
	IF(@idNewTableEmty=0)
	UPDATE dbo.FTable SET statusTable = N'Trống' WHERE idTable = @idOldTable
END
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateAccount]    Script Date: 4/16/2024 12:48:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[USP_UpdateAccount]
@userName NVARCHAR(100), @displayName NVARCHAR(100), @password NVARCHAR(1000), @newPassword NVARCHAR(1000)
AS
BEGIN
	DECLARE @isRightPass INT = 0
	SELECT @isRightPass = COUNT(*) FROM dbo.Account WHERE UserName = @userName AND PassWord = @password

	IF(@isRightPass = 1)
	BEGIN
		IF(@newPassword = NULL OR @newPassword ='')
		BEGIN
			UPDATE dbo.Account SET DisplayName = @displayName WHERE UserName = @userName
		END
		ELSE
			UPDATE dbo.Account SET DisplayName = @displayName, PassWord = @newPassword WHERE UserName = @userName
	END
END
GO
USE [master]
GO
ALTER DATABASE [QuanLyQuanCafe] SET  READ_WRITE 
GO
