CREATE TABLE USERS(
[id] BIGINT NOT NULL IDENTITY,
  [Name] VARCHAR(50) NULL DEFAULT NULL,
  [mobile] VARCHAR(15) NULL,
  [email] VARCHAR(50) NULL,
  [password] VARCHAR(32) NOT NULL,
  [registeredAt] DATETIME NOT NULL,
  [lastLogin] DATETIME NULL DEFAULT NULL,
  PRIMARY KEY ([id]),
  CONSTRAINT [uq_mobile] UNIQUE  ([mobile] ASC),
  CONSTRAINT [uq_email] UNIQUE  ([email] ASC) );
--
CREATE TABLE product (
  [id] BIGINT NOT NULL,
  [name] VARCHAR(75) NOT NULL,
  [summary] VARCHAR(255) NULL DEFAULT NULL,
  [price] FLOAT NOT NULL DEFAULT 0,
  [discount] FLOAT NOT NULL DEFAULT 0,
  [quantity] INT NOT NULL DEFAULT 0,
  CONSTRAINT [uq_id] UNIQUE  ([id] ASC),
  CONSTRAINT [uq_name] UNIQUE  ([name] ASC),
  PRIMARY KEY ([id]))
---
CREATE TABLE cart (
  [id] BIGINT NOT NULL IDENTITY,
  [UserName] VARCHAR(50) NULL DEFAULT NULL,
  [ProductId] BIGINT NULL DEFAULT NULL,  
  [ProductName] VARCHAR(50) NULL DEFAULT NULL,
  [quantity] INT NOT NULL DEFAULT 0,
  [price] FLOAT NOT NULL DEFAULT 0,
  [TotalPrice] FLOAT NOT NULL DEFAULT 0  
  PRIMARY KEY ([id]),
	CONSTRAINT [fk_cart_product]
    FOREIGN KEY ([productId])
    REFERENCES product ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
----
Create Table Orders(
  [id] BIGINT NOT NULL IDENTITY,
  [ProductId] BIGINT NULL DEFAULT NULL,
  [UserName] VARCHAR(50) NULL DEFAULT NULL,
  [ProductName] VARCHAR(50) NULL DEFAULT NULL,
  [Productprice] FLOAT NOT NULL DEFAULT 0,
  [UserRequiredQuantity] INT NOT NULL DEFAULT 0,
  [ProductTotalPrice] FLOAT NOT NULL DEFAULT 0,
  [TotalBillPrice] FLOAT NOT NULL DEFAULT 0
)
------
Insert into orders([ProductId],[ProductName],[Productprice],[UserName],[UserRequiredQuantity],[ProductTotalPrice],[TotalBillPrice])values(@ProductId,@ProductName,@Productprice,@UserName,@UserRequiredQuantity,@ProductTotalPrice,@TotalBillPrice)
delete from cart where ProductId=@ProductId and UserName=@UserName
update product SET quantity=@quantity where ProductId=@ProductId

Create PROC usp_Orders(@ProductId bigint,@ProductName varchar(50),@Productprice float,@userrequiredquantity int,@UserName varchar(50),@ProductTotalPrice float,@TotalBillPrice float,@updatequantity int)
AS
BEGIN
	BEGIN TRY
	    BEGIN
		Insert into orders([ProductId],[ProductName],[Productprice],[UserName],[UserRequiredQuantity],[ProductTotalPrice],[TotalBillPrice])values(@ProductId,@ProductName,@Productprice,'',@UserRequiredQuantity,@ProductTotalPrice,@TotalBillPrice)
		BEGIN
			delete from cart where ProductId=@ProductId and UserName=''
			BEGIN
				update product SET quantity=@updatequantity where Id=@ProductId
						RETURN 1
					END
					RETURN -3

		END
			RETURN -2
			END
			RETURN -1
	END TRY
	     
	BEGIN CATCH
		RETURN -99
	END CATCH
END



