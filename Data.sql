CREATE DATABASE QuanLyQuanCafe
GO 

USE QuanlyQuanCafe
GO

-- Menu
-- Table
-- MenuCategory
-- Account
-- Bill
-- BillInfo

--Khởi tạo bảng
CREATE TABLE FTable
(
idTable INT IDENTITY  PRIMARY KEY,
nameTable NVARCHAR(100) NOT NULL DEFAULT  N'Bàn chưa có tên',
statusTable NVARCHAR(100) NOT NULL DEFAULT N'Trống' -- Trống || Có người
)
GO
CREATE TABLE Account
(
UserName NVARCHAR(100) PRIMARY KEY ,
DisplayName NVARCHAR(100) NOT NULL DEFAULT N'Admin',
PassWord NVARCHAR(1000) NOT NULL DEFAULT 0,
TypeUser INT NOT NULL DEFAULT 0 -- 1: admin && 0: staff
)
GO
CREATE TABLE Category
(
idCategory INT IDENTITY PRIMARY KEY,
nameCategory NVARCHAR(100) NOT NULL DEFAULT  N'Chưa đặt tên'
)
GO

CREATE TABLE Menu
(
idMenu INT IDENTITY PRIMARY KEY,
nameMenu NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
idCategory INT NOT NULL,
price FLOAT NOT NULL DEFAULT 0,
FOREIGN KEY (idCategory) REFERENCES dbo.Category(idCategory)
)
GO
CREATE TABLE  Bill
(
idBill INT IDENTITY PRIMARY KEY ,
DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
DateCheckOut DATE,
idTable INT NOT NULL,
statusBill INT NOT NULL DEFAULT 0, -- 1: đã thanh toán && 0: chưa thanh toán
discount INT DEFAULT 0,
totalPrice FLOAT DEFAULT 0
FOREIGN KEY (idTable) REFERENCES dbo.FTable(idTable)
)
GO
CREATE TABLE  BillInfo
(
idBillInfo INT IDENTITY PRIMARY KEY ,
idBill INT NOT NULL,
idMenu INT NOT NULL ,
count INT NOT NULL DEFAULT 0
FOREIGN KEY (idBill) REFERENCES dbo.Bill(idBill),
FOREIGN KEY (idMenu) REFERENCES dbo.Menu(idMenu)
)
GO

--------Thêm giá trị vào bảng------------------
--Thêm tài khoản
INSERT INTO dbo.Account
			 (	UserName,
				DisplayName,
				PassWord,
				TypeUser
			 )
VALUES		 ( N'admin', -- UserName
			   N'Minh Triều', -- DisplayName
			   N'1', -- PassWord
			   1 -- TypeUser
			  )
INSERT INTO dbo.Account
			 (	UserName,
				DisplayName,
				PassWord,
				TypeUser
			 )
VALUES		 ( N'mt276', -- UserName
			   N'Minh Triều', -- DisplayName
			   N'1', -- PassWord
			   0 -- TypeUser
			  )
INSERT INTO dbo.Account
			 (	UserName,
				DisplayName,
				PassWord,
				TypeUser
			 )
VALUES		 ( N'a', -- UserName
			   N'Minh Triều', -- DisplayName
			   N'1', -- PassWord
			   0 -- TypeUser
			  )

GO
--Thêm số bàn
declare  @i int = 1
while @i<=24
begin
    INSERT dbo.fTable(nameTable)
    VALUES (N'Bàn '+CAST(@i AS NVARCHAR(100)))
    SET @i=@i+1
end
go
--Thêm category
INSERT INTO dbo.Category
			 (	nameCategory
			 )
VALUES		 (	N'Cafe' 
			 )
INSERT INTO dbo.Category
			 (	nameCategory
			 )
VALUES		 (	N'Đá xay' 
			 )
INSERT INTO dbo.Category
			 (	nameCategory
			 )
VALUES		 (	N'Trà' 
			 )
INSERT INTO dbo.Category
			 (	nameCategory
			 )
VALUES		 (	N'Nước ép' 
			 )
INSERT INTO dbo.Category
			 (	nameCategory
			 )
VALUES		 (	N'Sinh tố' 
			 )
INSERT INTO dbo.Category
			 (	nameCategory
			 )
VALUES		 (	N'Giải khát' 
			 )
INSERT INTO dbo.Category
			 (	nameCategory
			 )
VALUES		 (	N'Thức ăn nhanh' 
			 )

--Thêm Menu
--Select * from Menu
INSERT INTO dbo.Menu
			 (	nameMenu, idCategory, price
			 )
VALUES		 (	N'Cafe đá', 1,10000
			 )
INSERT INTO dbo.Menu
			 (	nameMenu, idCategory, price
			 )
VALUES		 (	N'Cafe sữa', 1,12000
			 )
INSERT INTO dbo.Menu
			 (	nameMenu, idCategory, price
			 )
VALUES		 (	N'Cafe đá xay', 2,28000
			 )
INSERT INTO dbo.Menu
			 (	nameMenu, idCategory, price
			 )
VALUES		 (	N'Trà đào', 3,20000
			 )
INSERT INTO dbo.Menu
			 (	nameMenu, idCategory, price
			 )
VALUES		 (	N'Trà Vải', 3,20000
			 )
INSERT INTO dbo.Menu
			 (	nameMenu, idCategory, price
			 )
VALUES		 (	N'Trà Việt Quất', 3,20000
			 )
INSERT INTO dbo.Menu
			 (	nameMenu, idCategory, price
			 )
VALUES		 (	N'Cam', 4,25000
			 )
INSERT INTO dbo.Menu
			 (	nameMenu, idCategory, price
			 )
VALUES		 (	N'Nước ép Thơm', 4,22000
			 )
INSERT INTO dbo.Menu
			 (	nameMenu, idCategory, price
			 )
VALUES		 (	N'Nước ép Bưởi', 4,25000
			 )
INSERT INTO dbo.Menu
			 (	nameMenu, idCategory, price
			 )
VALUES		 (	N'Sinh tố Bơ', 5,28000
			 )
INSERT INTO dbo.Menu
			 (	nameMenu, idCategory, price
			 )
VALUES		 (	N'Sinh tố Dâu', 5,28000
			 )
INSERT INTO dbo.Menu
			 (	nameMenu, idCategory, price
			 )
VALUES		 (	N'Sting', 6,10000
			 )
INSERT INTO dbo.Menu
			 (	nameMenu, idCategory, price
			 )
VALUES		 (	N'Trà xanh không độ', 6,10000
			 )
INSERT INTO dbo.Menu
			 (	nameMenu, idCategory, price
			 )
VALUES		 (	N'RedBull', 6,12000
			 )
INSERT INTO dbo.Menu
			 (	nameMenu, idCategory, price
			 )
VALUES		 (	N'Hạt hướng dương', 7,10000
			 )
INSERT INTO dbo.Menu
			 (	nameMenu, idCategory, price
			 )
VALUES		 (	N'Bò khô', 7,20000
			 )
GO
--Thêm stored procedure
CREATE PROC USP_GetAccountByUserName
@userName NVARCHAR(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName
END
GO
CREATE PROC USP_Login
@userName NVARCHAR(100),
@password NVARCHAR(1000)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName AND PassWord = @password
END
GO
CREATE PROC USP_GetTableList
AS SELECT * FROM dbo.FTable
GO
CREATE PROC USP_GetTableByID
    @idTable INT
AS
BEGIN
    SELECT idTable, nameTable, statusTable
    FROM dbo.FTable
    WHERE idTable = @idTable;
END
GO
CREATE PROC USP_InsertBill
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
CREATE PROC USP_InsertBillInfo
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
CREATE PROC USP_SwitchTable
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
CREATE PROCEDURE USP_CombineTable
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


CREATE PROC USP_UpdateAccount
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

CREATE PROC USP_GetListBillByDate
@checkIn date, @checkOut date
AS
BEGIN
	SELECT nameTable AS [Tên bàn], b.totalPrice AS [Tổng tiền], FORMAT(DateCheckIn,'dddd,d MMMM, yyyy') AS [Ngày vào], FORMAT(DateCheckOut,'dddd,d MMMM, yyyy') AS [Ngày ra], discount [Giảm giá(%)]
	FROM dbo.FTable t, dbo.Bill b 
	WHERE DateCheckIn >= @checkIn AND DateCheckOut<=@checkOut AND statusBill=1 AND t.idTable = b.idTable
END
GO
CREATE PROC USP_GetListBillByDateForReport
@checkIn date, @checkOut date
AS
BEGIN
	SELECT nameTable, b.totalPrice, DateCheckIn,DateCheckOut, discount
	FROM dbo.FTable t, dbo.Bill b 
	WHERE DateCheckIn >= @checkIn AND DateCheckOut<=@checkOut AND statusBill=1 AND t.idTable = b.idTable
END
GO
CREATE PROC USP_GetListMenuByCategory
AS
BEGIN
	SELECT idMenu, nameMenu, c.idCategory, nameCategory, price FROM dbo.Menu m, dbo.Category c WHERE m.idCategory = c.idCategory 
	--SELECT idMenu, nameMenu, idCategory, price FROM dbo.Menu 
END
GO
CREATE PROC USP_GetListTable
AS
BEGIN
	SELECT idTable, nameTable, statusTable FROM dbo.FTable 
END
GO
CREATE PROC USP_GetListCategory
AS
BEGIN
	SELECT idCategory, nameCategory FROM dbo.Category
END
GO
CREATE PROC USP_GetListAccount
AS
BEGIN
	SELECT UserName  , DisplayName , TypeUser  FROM dbo.Account
END
GO
------------------------------------------------------Thêm Trigger-------------------------------------
-------------------------------------------------------------------------------------------------------
CREATE TRIGGER UTG_UpdateBillInfo
ON dbo.BillInfo FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill INT
	DECLARE @idTable INT
	DECLARE @countBillInfo INT

	SELECT @idBill = idBill FROM inserted
	SELECT @idTable = idTable FROM dbo.Bill WHERE idBill = @idBill AND statusBill = 0	
	SELECT @countBillInfo = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idBill
    IF (@countBillInfo > 0)
        UPDATE dbo.FTable
        SET statusTable = N'Có người'
        WHERE idTable = @idTable
    ELSE
    BEGIN
        UPDATE dbo.FTable
        SET statusTable = N'Trống'
        WHERE idTable = @idTable
    END

END
GO
CREATE TRIGGER UTG_UpdateBill
ON dbo.Bill FOR UPDATE
AS
BEGIN

	DECLARE @idBill INT

	SELECT @idBill = idBill FROM inserted

	DECLARE @idTable INT

	SELECT @idTable = idTable FROM dbo.Bill WHERE idBill = @idBill

	DECLARE @count INT=0

	SELECT @count = COUNT(*) FROM dbo.Bill WHERE idTable = @idTable AND statusBill = 0
	
	IF(@count = 0)
		UPDATE dbo.FTable  SET statusTable =N'Trống' From dbo.FTable f, dbo.Bill b WHERE f.idTable = @idTable AND b.statusBill =1

END
GO

CREATE TRIGGER UTG_DeleteBillInfo
ON dbo.BillInfo FOR DELETE
AS
BEGIN
	DECLARE @idBillInfo INT
	DECLARE @idBill INT
	SELECT @idBillInfo = idBillInfo, @idBill = Deleted.idBill FROM deleted

	DECLARE @idTable INT
	SELECT @idTable = idTable FROM dbo.Bill WHERE idBill = @idBill

	DECLARE @count INT = 0

	SELECT @count = COUNT(*) FROM dbo.BillInfo bi, dbo.Bill b WHERE  bi.idBill = b.idBill AND b.idBill = @idBill AND b.statusBill = 0

	IF(@count = 0)
		UPDATE dbo.FTable  SET statusTable =N'Trống' WHERE idTable = @idTable
		DELETE FROM dbo.Bill WHERE idBill = @idBill
END
GO
CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END



