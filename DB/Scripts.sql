------------------------------------------------------------
------------------------------------------------------------
------------------------------------------------------------

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF (EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Customer'))
BEGIN
    
	DROP TABLE [dbo].[Customer]
	
END

CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[Gender] [bit] NULL,
	[CCCD] [nvarchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[DoB] [datetime] NULL,
	[YoB] [smallint] NULL,
	[Email] [nvarchar](50) NULL,
	[Facebook] [nvarchar](50) NULL,
	[Hobbies] [nvarchar](50) NULL,
	[Note] [nvarchar](max) NULL
	)

GO

------------------------------------------------------------
------------------------------------------------------------
------------------------------------------------------------

INSERT INTO [dbo].[Customer]
           ([Name]
           ,[PhoneNumber]
           ,[Gender]
           ,[CCCD]
           ,[Address]
           ,[DoB]
           ,[YoB]
           ,[Email]
           ,[Facebook]
           ,[Hobbies]
           ,[Note])
     VALUES
           (
		   N'Chiến'--<Name, nvarchar(50),>
           ,N'1' --<PhoneNumber, nvarchar(50),>
           ,0 --<Gender, bit,>
           ,N'2' --<CCCD, nvarchar(50),>
           ,N'3' --<Address, nvarchar(250),>
           ,'2001-06-07 12:00:00' --<DoB, datetime,>
           ,2001 --<YoB, smallint,>
           ,N'4' --<Email, nvarchar(50),>
           ,N'5' --<Facebook, nvarchar(50),>
           ,N'6' --<Hobbies, nvarchar(50),>
           ,N'7' --<Note, nvarchar(max),>
		   )
GO

------------------------------------------------------------
------------------------------------------------------------
------------------------------------------------------------

-- Insert:
 
 CREATE OR ALTER PROCEDURE Customer_Insert (
 	 @Name nvarchar(50)
 	,@PhoneNumber nvarchar(50)
 	,@Gender bit
 	,@CCCD nvarchar(50)
 	,@Address nvarchar(250)
 	,@DoB datetime
 	,@YoB smallint
 	,@Email nvarchar(50)
 	,@Facebook nvarchar(50)
 	,@Hobbies nvarchar(50)
 	,@Note nvarchar(max)
 )
 AS
 BEGIN
	 INSERT INTO [Customer] (
 		 [Name]
 		,[PhoneNumber]
 		,[Gender]
 		,[CCCD]
 		,[Address]
 		,[DoB]
 		,[YoB]
 		,[Email]
 		,[Facebook]
 		,[Hobbies]
 		,[Note]
	 )
	 VALUES (
 		 @Name
 		,@PhoneNumber
 		,@Gender
 		,@CCCD
 		,@Address
 		,@DoB
 		,@YoB
 		,@Email
 		,@Facebook
 		,@Hobbies
 		,@Note
	 )

	 RETURN @@ROWCOUNT;
 END
 GO
 
------------------------------------------------------------
------------------------------------------------------------
------------------------------------------------------------

-- Update:
 
 CREATE OR ALTER PROCEDURE Customer_Update (
 	 @Id int
 	,@Name nvarchar(50)
 	,@PhoneNumber nvarchar(50)
 	,@Gender bit
 	,@CCCD nvarchar(50)
 	,@Address nvarchar(250)
 	,@DoB datetime
 	,@YoB smallint
 	,@Email nvarchar(50)
 	,@Facebook nvarchar(50)
 	,@Hobbies nvarchar(50)
 	,@Note nvarchar(max)
 )
 AS
 BEGIN
	 UPDATE [Customer]
	 SET [Name] = @Name
 		,[PhoneNumber] = @PhoneNumber
 		,[Gender] = @Gender
 		,[CCCD] = @CCCD
 		,[Address] = @Address
 		,[DoB] = @DoB
 		,[YoB] = @YoB
 		,[Email] = @Email
 		,[Facebook] = @Facebook
 		,[Hobbies] = @Hobbies
 		,[Note] = @Note
	 WHERE [Id] = @Id
 
	 RETURN @@ROWCOUNT;
 END
 GO
 
------------------------------------------------------------
------------------------------------------------------------
------------------------------------------------------------

-- Delete:
 
 CREATE OR ALTER PROCEDURE Customer_Delete (
 	 @Id int
 )
 AS
 BEGIN
	 DELETE
	 FROM [Customer]
	 WHERE [Id] = @Id
 
	 RETURN @@ROWCOUNT;
 END
 GO
 
------------------------------------------------------------
------------------------------------------------------------
------------------------------------------------------------

-- Select:
 
 CREATE OR ALTER PROCEDURE Customer_Select (
 	 @Id int
 )
 AS
 SELECT  [Id]
 		,[Name]
 		,[PhoneNumber]
 		,[Gender]
 		,[CCCD]
 		,[Address]
 		,[DoB]
 		,[YoB]
 		,[Email]
 		,[Facebook]
 		,[Hobbies]
 		,[Note]
 		FROM [Customer]
 WHERE [Id] = @Id
 
 GO

 
------------------------------------------------------------
------------------------------------------------------------
------------------------------------------------------------

-- Select All:
 CREATE OR ALTER PROCEDURE Customer_SelectAll
 AS
 SELECT  [Id]
 		,[Name]
 		,[PhoneNumber]
 		,[Gender]
 		,[CCCD]
 		,[Address]
 		,[DoB]
 		,[YoB]
 		,[Email]
 		,[Facebook]
 		,[Hobbies]
 		,[Note]
 		FROM [Customer]
 
 GO