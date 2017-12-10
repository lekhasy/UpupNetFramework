USE [master]
GO
/****** Object:  Database [upu10905a_db]    Script Date: 12/10/17 2:10:18 PM ******/
CREATE DATABASE [upu10905a_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'upu10905a_db', FILENAME = N'C:\Program Files (x86)\Parallels\Plesk\Databases\MSSQL\MSSQL11.MSSQLSERVER2012\MSSQL\DATA\upu10905a_db.mdf' , SIZE = 5184KB , MAXSIZE = 1048576KB , FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'upu10905a_db_log', FILENAME = N'C:\Program Files (x86)\Parallels\Plesk\Databases\MSSQL\MSSQL11.MSSQLSERVER2012\MSSQL\DATA\upu10905a_db_log.ldf' , SIZE = 3840KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [upu10905a_db] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [upu10905a_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [upu10905a_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [upu10905a_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [upu10905a_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [upu10905a_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [upu10905a_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [upu10905a_db] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [upu10905a_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [upu10905a_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [upu10905a_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [upu10905a_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [upu10905a_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [upu10905a_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [upu10905a_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [upu10905a_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [upu10905a_db] SET  ENABLE_BROKER 
GO
ALTER DATABASE [upu10905a_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [upu10905a_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [upu10905a_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [upu10905a_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [upu10905a_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [upu10905a_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [upu10905a_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [upu10905a_db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [upu10905a_db] SET  MULTI_USER 
GO
ALTER DATABASE [upu10905a_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [upu10905a_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [upu10905a_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [upu10905a_db] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [upu10905a_db]
GO
/****** Object:  User [upu10905a_upup_admin]    Script Date: 12/10/17 2:10:18 PM ******/
CREATE USER [upu10905a_upup_admin] FOR LOGIN [upu10905a_upup_admin] WITH DEFAULT_SCHEMA=[upu10905a_upup_admin]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [upu10905a_upup_admin]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [upu10905a_upup_admin]
GO
ALTER ROLE [db_datareader] ADD MEMBER [upu10905a_upup_admin]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [upu10905a_upup_admin]
GO
/****** Object:  Schema [upu10905a_upup_admin]    Script Date: 12/10/17 2:10:19 PM ******/
CREATE SCHEMA [upu10905a_upup_admin]
GO
/****** Object:  UserDefinedFunction [dbo].[fChuyenCoDauThanhKhongDau]    Script Date: 12/10/17 2:10:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fChuyenCoDauThanhKhongDau](@inputVar NVARCHAR(MAX) )
RETURNS NVARCHAR(MAX)
AS
BEGIN    
    IF (@inputVar IS NULL OR @inputVar = '')  RETURN ''
   
    DECLARE @RT NVARCHAR(MAX)
    DECLARE @SIGN_CHARS NCHAR(256)
    DECLARE @UNSIGN_CHARS NCHAR (256)
 
    SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệếìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵýĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' + NCHAR(272) + NCHAR(208)
    SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeeeiiiiiooooooooooooooouuuuuuuuuuyyyyyAADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD'
 
    DECLARE @COUNTER int
    DECLARE @COUNTER1 int
   
    SET @COUNTER = 1
    WHILE (@COUNTER <= LEN(@inputVar))
    BEGIN  
        SET @COUNTER1 = 1
        WHILE (@COUNTER1 <= LEN(@SIGN_CHARS) + 1)
        BEGIN
            IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@inputVar,@COUNTER ,1))
            BEGIN          
                IF @COUNTER = 1
                    SET @inputVar = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@inputVar, @COUNTER+1,LEN(@inputVar)-1)      
                ELSE
                    SET @inputVar = SUBSTRING(@inputVar, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@inputVar, @COUNTER+1,LEN(@inputVar)- @COUNTER)
                BREAK
            END
            SET @COUNTER1 = @COUNTER1 +1
        END
        SET @COUNTER = @COUNTER +1
    END
    -- SET @inputVar = replace(@inputVar,' ','-')
    RETURN @inputVar
END
GO
/****** Object:  Table [dbo].[AppConfigs]    Script Date: 12/10/17 2:10:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppConfigs](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Key] [int] NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AppConfigs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 12/10/17 2:10:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 12/10/17 2:10:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 12/10/17 2:10:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 12/10/17 2:10:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 12/10/17 2:10:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[AutoIncrementCode] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[TempPoName] [nvarchar](max) NULL,
	[OrgName] [nvarchar](max) NULL,
	[DepartmentName] [nvarchar](max) NULL,
	[Address1] [nvarchar](max) NULL,
	[Address2] [nvarchar](max) NULL,
	[Address3] [nvarchar](max) NULL,
	[Address4] [nvarchar](max) NULL,
	[PostalCode] [nvarchar](max) NULL,
	[Fax] [nvarchar](max) NULL,
	[Webiste] [nvarchar](max) NULL,
	[IndustryId] [int] NULL,
	[ServiceId] [int] NULL,
	[NumberOfDesigner] [int] NULL,
	[NumberOfEmployee] [int] NULL,
	[KnowByid] [int] NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 12/10/17 2:10:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Name_en] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Description_en] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[MetaKeyword] [nvarchar](max) NULL,
	[MetaDescription] [nvarchar](max) NULL,
	[MetaKeyword_en] [nvarchar](max) NULL,
	[MetaDescription_en] [nvarchar](max) NULL,
	[ParentCategory_Id] [bigint] NULL,
 CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostCategories]    Script Date: 12/10/17 2:10:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostCategories](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[RootCategoryIdentifier] [int] NULL,
	[Name] [nvarchar](max) NULL,
	[Name_en] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Description_en] [nvarchar](max) NULL,
	[MetaKeyword] [nvarchar](max) NULL,
	[MetaDescription] [nvarchar](max) NULL,
	[MetaKeyword_en] [nvarchar](max) NULL,
	[MetaDescription_en] [nvarchar](max) NULL,
	[ParentCategory_Id] [bigint] NULL,
 CONSTRAINT [PK_dbo.PostCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 12/10/17 2:10:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Title_en] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[Content_en] [nvarchar](max) NULL,
	[Sumary] [nvarchar](max) NULL,
	[Sumary_en] [nvarchar](max) NULL,
	[IsUserGuide] [bit] NOT NULL,
	[MetaKeyword] [nvarchar](max) NULL,
	[MetaDescription] [nvarchar](max) NULL,
	[MetaKeyword_en] [nvarchar](max) NULL,
	[MetaDescription_en] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[Category_Id] [bigint] NULL,
 CONSTRAINT [PK_dbo.Posts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCarts]    Script Date: 12/10/17 2:10:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCarts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Quantity] [bigint] NOT NULL,
	[Customer_Id] [nvarchar](128) NULL,
	[ProductVariant_Id] [bigint] NULL,
 CONSTRAINT [PK_dbo.ProductCarts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 12/10/17 2:10:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Name_en] [nvarchar](max) NULL,
	[Summary] [nvarchar](max) NULL,
	[Summary_en] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[PdfUrl] [nvarchar](max) NULL,
	[LinkGuide] [nvarchar](max) NULL,
	[Cad2dUrl] [nvarchar](max) NULL,
	[Cad3dUrl] [nvarchar](max) NULL,
	[MetaKeyword] [nvarchar](max) NULL,
	[MetaDescription] [nvarchar](max) NULL,
	[MetaKeyword_en] [nvarchar](max) NULL,
	[MetaDescription_en] [nvarchar](max) NULL,
	[Category_Id] [bigint] NULL,
 CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductVariants]    Script Date: 12/10/17 2:10:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductVariants](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[VariantName] [nvarchar](max) NULL,
	[VariantCode] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[OnHand] [decimal](18, 2) NOT NULL,
	[BrandName] [nvarchar](max) NULL,
	[Origin] [nvarchar](max) NULL,
	[Product_Id] [bigint] NULL,
	[ProductVariantUnit_Id] [bigint] NULL,
 CONSTRAINT [PK_dbo.ProductVariants] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductVariantUnits]    Script Date: 12/10/17 2:10:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductVariantUnits](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ProductVariantUnits] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseOrderDetails]    Script Date: 12/10/17 2:10:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrderDetails](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Quantity] [bigint] NOT NULL,
	[ShipDate] [datetime] NULL,
	[State] [int] NOT NULL,
	[Product_Id] [bigint] NULL,
	[PurchaseOrder_Id] [bigint] NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.PurchaseOrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseOrders]    Script Date: 12/10/17 2:10:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrders](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[State] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Customer_Id] [nvarchar](128) NULL,
	[IsDeleted] [bit] NOT NULL,
	[PaymentMethod] [int] NOT NULL,
	[CustomerAddress] [nvarchar](max) NULL,
	[CustomerPhone] [nvarchar](max) NULL,
	[CustomerEmail] [nvarchar](max) NULL,
	[CustomerWebsite] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.PurchaseOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShipDateSettingProductVariants]    Script Date: 12/10/17 2:10:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShipDateSettingProductVariants](
	[ShipDateSetting_Id] [bigint] NOT NULL,
	[ProductVariant_Id] [bigint] NOT NULL,
 CONSTRAINT [PK_dbo.ShipDateSettingProductVariants] PRIMARY KEY CLUSTERED 
(
	[ShipDateSetting_Id] ASC,
	[ProductVariant_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShipDateSettings]    Script Date: 12/10/17 2:10:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShipDateSettings](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[QuantityOrderMax] [int] NOT NULL,
	[TargetDateNumber] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ShipDateSettings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'624057f6-b451-4c1d-abf9-8f2a4c6282f9', N'Admin')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'cc7aa678-bd3e-4a65-9a96-87a5f7ed92a0', N'Customer')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'548068d2-4fa6-49ee-9a41-3d4c932cc98b', N'Editor')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a136cad6-b954-4db5-a029-4af58450eab9', N'624057f6-b451-4c1d-abf9-8f2a4c6282f9')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'de28dabf-7047-47d2-91e0-5230c2b8b087', N'624057f6-b451-4c1d-abf9-8f2a4c6282f9')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b7b0f4a0-d42b-4081-928f-91b2210a023e', N'cc7aa678-bd3e-4a65-9a96-87a5f7ed92a0')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e2043988-480e-4689-8532-d512b4a45f84', N'cc7aa678-bd3e-4a65-9a96-87a5f7ed92a0')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ec49be79-03e4-42f7-ae53-2c1ab8b4482b', N'cc7aa678-bd3e-4a65-9a96-87a5f7ed92a0')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fa33f0cb-02e0-48a7-a030-7364fdb608fb', N'cc7aa678-bd3e-4a65-9a96-87a5f7ed92a0')
GO
SET IDENTITY_INSERT [dbo].[AspNetUsers] ON 
GO
INSERT [dbo].[AspNetUsers] ([Id], [AutoIncrementCode], [FullName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [TempPoName], [OrgName], [DepartmentName], [Address1], [Address2], [Address3], [Address4], [PostalCode], [Fax], [Webiste], [IndustryId], [ServiceId], [NumberOfDesigner], [NumberOfEmployee], [KnowByid], [Discriminator]) VALUES (N'a136cad6-b954-4db5-a029-4af58450eab9', 1, N'123', N'123@h.com', 1, N'AH9funEg6o7rFxF5fdczt8nBQkYdZv/Mw9uJnU+xvch8iXIq6lm34ZIwtm1wwsQeIA==', N'349e3f3e-710c-447f-9553-e2760ee42f7c', N'123', 0, 0, NULL, 1, 0, N'123@h.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, N'Customer')
GO
INSERT [dbo].[AspNetUsers] ([Id], [AutoIncrementCode], [FullName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [TempPoName], [OrgName], [DepartmentName], [Address1], [Address2], [Address3], [Address4], [PostalCode], [Fax], [Webiste], [IndustryId], [ServiceId], [NumberOfDesigner], [NumberOfEmployee], [KnowByid], [Discriminator]) VALUES (N'b7b0f4a0-d42b-4081-928f-91b2210a023e', 5, N'MR NAM', N'plaza.magazine@gmail.com', 1, N'AAGzdxalWwB2LiDgVS2S+hOT7Yv4Y2sKKJwwaEM1IBfveE5NUrdzAPFgNEa5LwZagg==', N'6de20bc1-6fa9-4aea-8535-f3ef03c35b43', NULL, 0, 0, NULL, 1, 0, N'plaza.magazine@gmail.com', NULL, N'concung', NULL, N'123 Trần Hưng Đạo, P4, Q5', NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, N'Customer')
GO
INSERT [dbo].[AspNetUsers] ([Id], [AutoIncrementCode], [FullName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [TempPoName], [OrgName], [DepartmentName], [Address1], [Address2], [Address3], [Address4], [PostalCode], [Fax], [Webiste], [IndustryId], [ServiceId], [NumberOfDesigner], [NumberOfEmployee], [KnowByid], [Discriminator]) VALUES (N'de28dabf-7047-47d2-91e0-5230c2b8b087', 2, NULL, N'admin@abc.com', 1, N'AI4Y5pxTq2d/NawXmGuQiOIqKR43+fEtvTh32kriapwJTUSxvd/0WWEdkaYCv6/5Vg==', N'703ea8cd-e573-46f4-8fc9-cfe7f06be55c', NULL, 0, 0, NULL, 1, 0, N'admin@abc.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'ApplicationUser')
GO
INSERT [dbo].[AspNetUsers] ([Id], [AutoIncrementCode], [FullName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [TempPoName], [OrgName], [DepartmentName], [Address1], [Address2], [Address3], [Address4], [PostalCode], [Fax], [Webiste], [IndustryId], [ServiceId], [NumberOfDesigner], [NumberOfEmployee], [KnowByid], [Discriminator]) VALUES (N'e2043988-480e-4689-8532-d512b4a45f84', 3, N'Lê Khả Sỹ', N'lekhasy@outlook.com', 1, N'APNaegGt9fikTH1x8+KB3rcpt/VvGCFwXd6I3wdBWvMlqOmfPNhBAiLWfmNut8MlIA==', N'596c3251-59a7-49c6-86a1-11432e6b483a', N'0993142171', 0, 0, NULL, 1, 0, N'lekhasy@outlook.com', NULL, N'Citigo', N'Dev 3', N'Số 7, trần khát chân, quận hai bà trưng, hà nội', N'DC2', N'DC3', N'DC 4', N'81000', N'4321', N'http://google.com', 0, 0, 0, 0, 0, N'Customer')
GO
INSERT [dbo].[AspNetUsers] ([Id], [AutoIncrementCode], [FullName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [TempPoName], [OrgName], [DepartmentName], [Address1], [Address2], [Address3], [Address4], [PostalCode], [Fax], [Webiste], [IndustryId], [ServiceId], [NumberOfDesigner], [NumberOfEmployee], [KnowByid], [Discriminator]) VALUES (N'ec49be79-03e4-42f7-ae53-2c1ab8b4482b', 4, N'Test', NULL, 1, N'ALGpOVKfSyfT0wdhV4cJu32d9QXhQsUqqw6ecSkPbII9YW9DlRlqnE78m6/3v9mZgA==', N'54d54402-39b1-42ac-94bc-cea5bc2db286', NULL, 0, 0, NULL, 1, 0, N'thangphuong88@gmail.com', NULL, N'ABC', NULL, N'123 trinh dinh trong', NULL, NULL, NULL, NULL, NULL, N'fdsfsdfds', 0, 0, 0, 0, 0, N'Customer')
GO
INSERT [dbo].[AspNetUsers] ([Id], [AutoIncrementCode], [FullName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [TempPoName], [OrgName], [DepartmentName], [Address1], [Address2], [Address3], [Address4], [PostalCode], [Fax], [Webiste], [IndustryId], [ServiceId], [NumberOfDesigner], [NumberOfEmployee], [KnowByid], [Discriminator]) VALUES (N'fa33f0cb-02e0-48a7-a030-7364fdb608fb', 6, N'adsf', N'dinhngoc27@gmail.com', 0, N'AAYNS8Wa3fewdcv6nYCTi8uoQGFjIsZZAi4cofVx2+I02OU+zwVq9dwG3UoFWxwWGg==', N'a749de80-2f65-448c-be5a-be761b356471', NULL, 0, 0, NULL, 1, 0, N'dinhngoc27@gmail.com', NULL, N'ádf', NULL, N'sdfá', NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, N'Customer')
GO
SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([Id], [Name], [Name_en], [Description], [Description_en], [ImageUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (1, N'Bộ Truyền Động', N'Rotary Power Transmision ', N'<p>A wide variety of standard and configurable components for factory automation engineers in industries such as automotive, semiconductor, packaging, medical and many more.</p>
', N'<p>A wide variety of standard and configurable components for factory automation engineers in industries such as automotive, semiconductor, packaging, medical and many more.</p>
', N'20171210130036857_90ebc534ab1a4533a70f499024278649.png', N'Bộ Truyền Động', N'Truyền Động Cơ Khí', N'Power Transmission', N'Mechanical Power Transmission', NULL)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Name_en], [Description], [Description_en], [ImageUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (2, N'Truyền Động Đai Răng', N'Timing Belts and Pulleys', N'<p>Bao gồm c&aacute;c sản phẩm d&acirc;y đai răng v&agrave; puly cho d&acirc;y đai răng</p>
', N'<p>Timing belts and timing pulley for automaiton</p>
', N'20171210130742179_5daa01b1711242298dca5ece9b912dff.png', N'đai răng ', N'Bộ truyền đai răng', N'Timing Belts', N'Timing belts and pulley', 1)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Name_en], [Description], [Description_en], [ImageUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (3, N'Dây đai răng', N'Timing Belts', N'<p>D&acirc;y đai răng c&aacute;c loại: S2M, S3M, S5M, S8M, S14M, XL, L, T5, T10</p>
', N'<p>Including timing belts :&nbsp; S2M, S3M, S5M, S8M, S14M, XL, L, T5, T10</p>
', N'20171210131137135_99649751b74e4eb7a58d21e28690e005.png', N'Dây đai răng', N'Dây đai răng', N'Timing belts', N'Timing belts', 2)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Name_en], [Description], [Description_en], [ImageUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (4, N'Dẫn Động Tịnh Tiến', N'Linear Motion', N'<p>Bao gồm c&aacute;c loại dẫn hướng tịnh tiến như: ray trượt, ty trượt tr&ograve;n</p>
', N'<p>Including linear motion such as: line guides, bushing, linear shafts</p>
', N'20171210131937627_b7a304cd00784203ad8cff9532a063b6.png', N'ray trượt, bạc trượt', N'Dẫn hướng cho chuyển động thẳng', N'line guide, ball bushing', N'Linear Motion', NULL)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Name_en], [Description], [Description_en], [ImageUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (5, N'Truyền Động Xích', N'Chain and Sprocket', N'<p>x&iacute;ch v&agrave; b&aacute;nh x&iacute;ch</p>
', N'<p>Sprocket and roller chain</p>
', N'20171210134725027_ead5715a416d4cdb8f19821e0e98ca31.png', N'xích', N'xích', N'Sprocket, roller chain', N'Roller chain and Sprocket', 1)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Name_en], [Description], [Description_en], [ImageUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (6, N'Truyền Động Thanh Răng-Bánh Răng', N'Gears', N'<p>b&aacute;nh răng, thanh răng</p>
', N'<p>gears</p>
', N'20171210135008369_de5d3d73397e4108b99a2986b9d6672e.png', N'Thanh răng, bánh răng', N'Thanh răng, bánh răng', N'gears, rack', N'gears', 1)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Name_en], [Description], [Description_en], [ImageUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (7, N'Khớp Nối', N'Couplings', N'<p>Khớp nối mềm, khớp nối x&iacute;ch, khớp nối servo</p>
', N'<p>Couplings</p>
', N'20171210140505148_796cf9cec5c648bd80540b57bcfe4835.png', N'Khớp nối mềm, khớp nối xích, khớp nối servo', N'Các loại khớp nối', N'couplings', N'Couplings', 1)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Name_en], [Description], [Description_en], [ImageUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (8, N'Motors', N'Motors', N'<p>dsad</p>
', N'<p>dsad</p>
', N'20171125154328101_6ee5fb3a3d7448c9a64b5873b0091b41.jpg', N'asd', N'dsad', N'asd', N'asd', 1)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Name_en], [Description], [Description_en], [ImageUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (9, N'Conveyors & Material Handling', N'Conveyors & Material Handling', N'<p>dsad</p>
', N'<p>dasda</p>
', N'20171125154339933_ea7042ed327044dfafe9c192005a7ab9.jpg', N'dasd', N'dasd', N'dasd', N'dsadsa', 1)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Name_en], [Description], [Description_en], [ImageUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (10, N'Locating, Positioning, Jigs & Fixtures', N'Locating, Positioning, Jigs & Fixtures', N'<p>dasd</p>
', N'<p>dasd</p>
', N'20171125154348841_3c40d365e7d04a9d9f5d0f4a6cf735f0.jpg', N'dasd', N'Dasd', N'dasd', N'dasd', 1)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Name_en], [Description], [Description_en], [ImageUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (11, N'Inspection', N'Inspection', N'<p>sadas</p>
', N'<p>dasd</p>
', N'20171125154400751_17c4e975ec02405ebe47a5ebaf35e3dd.jpg', N'sad', N'dasd', N'sad', N'asd', 1)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Name_en], [Description], [Description_en], [ImageUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (12, N'Chuyển động quay', N'Rotary Motion', N'<p>C&aacute;c sản phẩm như bạc đạn c&aacute;c loại, trục</p>
', N'<p>Providing bearing for aotomation&nbsp;</p>
', N'20171210132349947_ce32bd4558af40929a52904cd661930b.png', N'Bạc đạn', N'Bạc đạn', N'Bạc đạn', N'Rotary Motion', NULL)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Name_en], [Description], [Description_en], [ImageUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (13, N'Linh Kiện Tự Động Hóa', N'Automation Components', N'<p>&nbsp;spare spart, rulo cho tự động h&oacute;a</p>
', N'<p>spare sparts, components for automation</p>
', N'20171210134051777_6fa012ca83a7468cbd0a1af8823e74fb.png', N'khớp xoay, giảm chấn, rulo', N'linh kiện, vật tư cho ngành tự động hóa', N'retaining ring,  roller, shock absorber', N'Automation Components', NULL)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Name_en], [Description], [Description_en], [ImageUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (14, N'Linh Kiện Siết', N'Fassteners', N'<p>Bulong, ốc v&iacute;t</p>
', N'<p>screws, nuts</p>
', N'20171210134445904_5111e1286a5c441eb03016f36952682e.png', N'bulong, ốc vít', N'linh kiện cho mối lắp ghép', N'bulong, ốc vít', N'Fasteners', NULL)
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[PostCategories] ON 
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (1, 1, N'Công nghệ', N'Công nghệ', N'<p>sdas</p>
', N'<p>dasd</p>
', N'sadsa', N'dsa', NULL, NULL, NULL)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (2, 2, N'Hướng dẫn sử dụng', N'User Manual', N'<p>hướng dẫn sử dụng cho người d&ugrave;ng</p>
', N'<p>user manual</p>
', N'Từ khóa cho trang hướng dẫn sử dụng', N'các  thông tin về hướng dẫn sử dụng', NULL, NULL, NULL)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (3, 3, N'Triển lãm sự kiện', N'Event', N'<p>event</p>
', N'<p>&aacute;d</p>
', N'2', N'1', NULL, NULL, NULL)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (5, NULL, N'Chế tạo cơ khí', N'Chế tạo cơ khí', N'<p>das</p>
', N'<p>dasdsad</p>
', N'asdsa', N'Dsad', N'fsd', N'fds', 1)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (6, NULL, N'Máy móc công nghệ cao', N'Máy móc công nghệ cao', N'<p>fds</p>
', N'<p>dsad</p>
', N'dsa', N'dsad', NULL, NULL, 1)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (7, NULL, N'Cách chế tạo ốc vít', N'Cách chế tạo ốc vít', N'<p>dsad</p>
', N'<p>dsa</p>
', N'Dsa', N'dsa', N'fsdf', N'fdsf', 1)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (8, NULL, N'Tấm gương cơ khí thành công', N'Tấm gương cơ khí thành công', N'<p>das</p>
', N'<p>dsa</p>
', N'def', N'Dsa', N'dsa', N'das', 5)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (9, NULL, N'Hướng dẫn đặt hàng cơ khí', N'Hướng dẫn đặt hàng cơ khí', N'<p>dsadsa</p>
', N'<p>dasda</p>
', N'dsad', N'dsad', NULL, NULL, 2)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (10, NULL, N'Hướng dẫn chọn sản phẩm', N'Hướng dẫn chọn sản phẩm', N'<p>dasdsa</p>
', N'<p>dsada</p>
', N'dasds', N'dasd', NULL, NULL, 2)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (11, NULL, N'Hướng dẫn cách thức mua hàng', N'Hướng dẫn cách thức mua hàng', N'<p>dsadsad</p>
', N'<p>dasdas</p>
', N'dsad', N'dsad', NULL, NULL, 2)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (12, NULL, N'Hướng dẫn chọn vật liệu', N'Hướng dẫn chọn vật liệu', N'<p>sadas</p>
', N'<p>dsad</p>
', N'dsad', N'dasd', NULL, NULL, 2)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (13, NULL, N'Triển lãm cơ khí toàn quốc', N'Triển lãm cơ khí toàn quốc', N'<p>dsad</p>
', N'<p>dasdas</p>
', N'dasda', N'dsa', NULL, NULL, 3)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (14, NULL, N'Sự kiện doanh nhân cơ khí 2017', N'Sự kiện doanh nhân cơ khí 2017', N'<p>dasdsa</p>
', N'<p>dsad</p>
', N'dsad', N'dsad', NULL, NULL, 3)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (15, NULL, N'Giảm giá toàn bộ sản phẩm cơ khí', N'Giảm giá toàn bộ sản phẩm cơ khí', N'<p>dsa</p>
', N'<p>dsad</p>
', N'dasd', N'das', NULL, NULL, 3)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (16, NULL, N'Chế tạo máy bay từ phế thải', N'Chế tạo máy bay từ phế thải', N'<p>dsa</p>
', N'<p>dsad</p>
', N'dsad', N'dsad', N'dsa', N'sadsa', 5)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (17, NULL, N'Chế tạo máy bay từ phế thải', N'Chế tạo máy bay từ phế thải', N'<p>dsa</p>
', N'<p>dsad</p>
', N'dsad', N'dsad', N'dsa', N'sadsa', 5)
GO
SET IDENTITY_INSERT [dbo].[PostCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[Posts] ON 
GO
INSERT [dbo].[Posts] ([Id], [Title], [Title_en], [Content], [Content_en], [Sumary], [Sumary_en], [IsUserGuide], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [CreatedDate], [LastModifiedDate], [Category_Id]) VALUES (1, N'Tiềm năng phát triển vật liệu mới ở Việt Nam', N'New material development oppotunity in vietnam', N'<p>Việc ứng dụng vật liệu mới đem lại hiệu quả về kinh tế, m&ocirc;i trường, &yacute; nghĩa thiết thực với đời sống của người d&acirc;n. Một số vật liệu mới ở Việt Nam c&oacute; thể kể đến như: Dập đ&aacute;m ch&aacute;y bằng một loại vật liệu mới dạng dung dịch; c&oacute; thể trộn 100% c&aacute;t nh&acirc;n tạo với b&ecirc; t&ocirc;ng vẫn đảm bảo c&aacute;c ti&ecirc;u ch&iacute; kỹ thuật; c&aacute;t t&aacute;i chế đầu ti&ecirc;n từ xỉ than...</p>

<p>Theo Bộ Khoa học v&agrave; C&ocirc;ng nghệ, c&ocirc;ng nghệ&nbsp;<a href="http://vtv.vn/vat-lieu-moi.html" target="_blank" title="vật liệu mới">vật liệu mới</a>&nbsp;hiện l&agrave; một trong 4 lĩnh vực trọng t&acirc;m được Nh&agrave; nước ưu ti&ecirc;n ph&aacute;t triển. Việt Nam đang tập trung ph&aacute;t triển c&aacute;c loại vật liệu mới như: vật liệu cảm biến, vật liệu chế tạo bộ nhớ thế hệ mới, vật liệu tản nhiệt, vật liệu cho c&aacute;c thiết bị giải tr&iacute;, vật liệu nano, composite&hellip;</p>

<p>Vật liệu mới c&oacute; những t&iacute;nh chất ưu việt so với vật liệu truyền thống về gi&aacute; cả, khả năng th&acirc;n thiện m&ocirc;i trường, độ bền của vật liệu&hellip; Ng&agrave;nh x&acirc;y dựng, đ&oacute;ng t&agrave;u, viễn th&ocirc;ng, y tế&hellip; l&agrave; những ng&agrave;nh đi đầu trong việc ứng dụng vật liệu mới.</p>

<p>Cũng theo Bộ Khoa học v&agrave; C&ocirc;ng nghệ, với c&aacute;c sản phẩm được tạo n&ecirc;n từ c&ocirc;ng nghệ vật liệu mới v&agrave; đ&atilde; chứng minh được hiệu quả, việc ứng dụng sẽ theo lộ tr&igrave;nh, hỗ trợ song song, tiến tới c&oacute; thể thay thế ho&agrave;n to&agrave;n vật liệu truyền thống. V&iacute; dụ, với vật liệu mới trong ng&agrave;nh x&acirc;y dựng, ban đầu sẽ &aacute;p dụng từ 10%, tiến tới 100%, đặc biệt l&agrave; c&aacute;c c&ocirc;ng tr&igrave;nh x&acirc;y dựng vốn ng&acirc;n s&aacute;ch.</p>
', N'<p>En_Việc ứng dụng vật liệu mới đem lại hiệu quả về kinh tế, m&ocirc;i trường, &yacute; nghĩa thiết thực với đời sống của người d&acirc;n. Một số vật liệu mới ở Việt Nam c&oacute; thể kể đến như: Dập đ&aacute;m ch&aacute;y bằng một loại vật liệu mới dạng dung dịch; c&oacute; thể trộn 100% c&aacute;t nh&acirc;n tạo với b&ecirc; t&ocirc;ng vẫn đảm bảo c&aacute;c ti&ecirc;u ch&iacute; kỹ thuật; c&aacute;t t&aacute;i chế đầu ti&ecirc;n từ xỉ than...</p>

<p>Theo Bộ Khoa học v&agrave; C&ocirc;ng nghệ, c&ocirc;ng nghệ&nbsp;<a href="http://vtv.vn/vat-lieu-moi.html" target="_blank" title="vật liệu mới">vật liệu mới</a>&nbsp;hiện l&agrave; một trong 4 lĩnh vực trọng t&acirc;m được Nh&agrave; nước ưu ti&ecirc;n ph&aacute;t triển. Việt Nam đang tập trung ph&aacute;t triển c&aacute;c loại vật liệu mới như: vật liệu cảm biến, vật liệu chế tạo bộ nhớ thế hệ mới, vật liệu tản nhiệt, vật liệu cho c&aacute;c thiết bị giải tr&iacute;, vật liệu nano, composite&hellip;</p>

<p>Vật liệu mới c&oacute; những t&iacute;nh chất ưu việt so với vật liệu truyền thống về gi&aacute; cả, khả năng th&acirc;n thiện m&ocirc;i trường, độ bền của vật liệu&hellip; Ng&agrave;nh x&acirc;y dựng, đ&oacute;ng t&agrave;u, viễn th&ocirc;ng, y tế&hellip; l&agrave; những ng&agrave;nh đi đầu trong việc ứng dụng vật liệu mới.</p>

<p>Cũng theo Bộ Khoa học v&agrave; C&ocirc;ng nghệ, với c&aacute;c sản phẩm được tạo n&ecirc;n từ c&ocirc;ng nghệ vật liệu mới v&agrave; đ&atilde; chứng minh được hiệu quả, việc ứng dụng sẽ theo lộ tr&igrave;nh, hỗ trợ song song, tiến tới c&oacute; thể thay thế ho&agrave;n to&agrave;n vật liệu truyền thống. V&iacute; dụ, với vật liệu mới trong ng&agrave;nh x&acirc;y dựng, ban đầu sẽ &aacute;p dụng từ 10%, tiến tới 100%, đặc biệt l&agrave; c&aacute;c c&ocirc;ng tr&igrave;nh x&acirc;y dựng vốn ng&acirc;n s&aacute;ch.</p>
', N'Việc ứng dụng vật liệu mới đem lại hiệu quả về kinh tế, môi trường, ý nghĩa thiết thực với đời sống của người dân. Một số vật liệu mới ở Việt Nam có thể kể đến như: Dập đám cháy bằng một loại vật liệu mới dạng dung dịch; có thể trộn 100% cát nhân tạo với bê tông vẫn đảm bảo các tiêu chí kỹ thuật; cát tái chế đầu tiên từ xỉ than...', N'en_Việc ứng dụng vật liệu mới đem lại hiệu quả về kinh tế, môi trường, ý nghĩa thiết thực với đời sống của người dân. Một số vật liệu mới ở Việt Nam có thể kể đến như: Dập đám cháy bằng một loại vật liệu mới dạng dung dịch; có thể trộn 100% cát nhân tạo với bê tông vẫn đảm bảo các tiêu chí kỹ thuật; cát tái chế đầu tiên từ xỉ than...', 0, N'tk', N'mt', N'tk_en', N'mt_en', CAST(N'2017-11-16T19:40:00.837' AS DateTime), CAST(N'2017-11-16T21:48:12.800' AS DateTime), 1)
GO
INSERT [dbo].[Posts] ([Id], [Title], [Title_en], [Content], [Content_en], [Sumary], [Sumary_en], [IsUserGuide], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [CreatedDate], [LastModifiedDate], [Category_Id]) VALUES (3, N'Ngày 8/12, iPhone X chính hãng lên kệ tại Việt Nam với giá 30 triệu đồng', N'EN_Ngày 8/12, iPhone X chính hãng lên kệ tại Việt Nam với giá 30 triệu đồng', N'<p>Theo FPT, th&ocirc;ng qua hai hệ thống FPT Shop v&agrave; F.Studio, những chiếc&nbsp;<a href="http://vtv.vn/iphone-x.html" target="_blank">iPhone X</a>với m&atilde; VN/A sẽ ch&iacute;nh thức l&ecirc;n kệ v&agrave;o ng&agrave;y 8/12 tới đ&acirc;y. FPT cho biết kh&aacute;ch h&agrave;ng c&oacute; thể đặt mua trước từ ng&agrave;y 1 - 7/12.</p>

<p>Về gi&aacute; b&aacute;n, iPhone X sẽ được b&aacute;n lần lượt ở mức 29.990.000 đồng v&agrave; 34.790.000 đồng tương ứng với 2 phi&ecirc;n bản dung lượng 64GB v&agrave; 256GB. Đ&aacute;ng ch&uacute; &yacute; trong lần b&aacute;n lần n&agrave;y, gi&aacute; b&aacute;n kh&ocirc;ng thay đổi tại c&aacute;c phi&ecirc;n bản m&agrave;u bạc cũng như x&aacute;m.</p>

<p><img alt="Ngày 8/12, iPhone X chính hãng lên kệ tại Việt Nam với giá 30 triệu đồng - Ảnh 1." src="https://vtv1.mediacdn.vn/thumb_w/640/2017/if-you-ask-me-i-think-the-iphone-x-is-much-better-than-the-iphone-8-1510223473242.jpg" /></p>

<p>iPhone X ch&iacute;nh h&atilde;ng sẽ được b&aacute;n tại Việt Nam v&agrave;o ng&agrave;y 8/12 tới đ&acirc;y</p>

<p>Li&ecirc;n hệ với một đơn vị được nhập khẩu ch&iacute;nh h&atilde;ng iPhone kh&aacute;c l&agrave; Thế giới di động, đại diện của h&atilde;ng n&agrave;y cho biết sẽ b&aacute;n iPhone X ch&iacute;nh h&atilde;ng tại c&aacute;c cửa h&agrave;ng v&agrave;o ng&agrave;y 8/12 tới đ&acirc;y.</p>

<p>Đ&aacute;ng ch&uacute; &yacute;, h&atilde;ng n&agrave;y cũng cho ph&eacute;p người d&ugrave;ng đặt mua trước từ ng&agrave;y 1 - 7/12 tới. Ngo&agrave;i ra, gi&aacute; b&aacute;n cũng tương tự FPT l&agrave; 29.990.000 đồng v&agrave; 34.790.000 đồng tương ứng với 2 phi&ecirc;n bản dung lượng 64GB v&agrave; 256GB cho 2 m&agrave;u Silver (Bạc) v&agrave; Gray (X&aacute;m).</p>

<p>Trước đ&oacute;, một số lượng kh&ocirc;ng nhỏ những chiếc iPhone X đ&atilde; được b&aacute;n tại Việt Nam kể từ ng&agrave;y thiết bị n&agrave;y ch&iacute;nh thức l&ecirc;n kệ v&agrave;o ng&agrave;y 3/11. Tuy nhi&ecirc;n những chiếc iPhone X n&agrave;y đều được nhập về qua h&igrave;nh thức x&aacute;ch tay.</p>

<p>Sự c&oacute; mặt của những chiếc iPhone X ch&iacute;nh h&atilde;ng v&agrave;o đầu th&aacute;ng 12 tới tại Việt Nam được xem l&agrave; th&ocirc;ng tin rất vui cho những người d&ugrave;ng muốn sự &quot;an to&agrave;n&quot; tuyệt đối cho những thiết bị của m&igrave;nh.</p>

<p>Apple c&oacute; ch&iacute;nh s&aacute;ch bảo h&agrave;nh với những chiếc iPhone x&aacute;ch tay. Song kh&ocirc;ng phải thiết bị n&agrave;o cũng sẽ được c&aacute;c trung t&acirc;m bảo h&agrave;nh m&agrave;&nbsp;<a href="http://vtv.vn/cong-nghe/apple-lai-bao-nhieu-voi-moi-chiec-iphone-x-20171107144332591.htm" target="_blank">Apple</a>&nbsp;ủy quyền chấp nhận sửa chữa hoặc thay mới trong c&aacute;c trường hợp gặp sự cố: phải đủ giấy tờ mua b&aacute;n, m&atilde; m&aacute;y phải ph&ugrave; hợp...</p>

<p>&nbsp;</p>

<p><img alt="Ngày 8/12, iPhone X chính hãng lên kệ tại Việt Nam với giá 30 triệu đồng - Ảnh 2." src="https://vtv1.mediacdn.vn/2017/cotd111-1509597984111-1510826076491.png" /></p>

<p>Chi ph&iacute; sửa chữa cho iPhone X ở mức rất cao: chi ph&iacute; thay thế m&agrave;n h&igrave;nh l&ecirc;n đến 279 USD (khoảng 6,4 triệu đồng), đắt hơn bất cứ m&agrave;n h&igrave;nh iPhone n&agrave;o kh&aacute;c; tổng chi ph&iacute; sửa chữa bảo h&agrave;nh kh&aacute;c tr&ecirc;n iPhone X ở mức 549 USD (khoảng 12,5 triệu đồng) - số tiền đ&uacute;ng bằng gi&aacute; b&aacute;n khởi điểm của iPhone 7.</p>
', N'<p>En_Theo FPT, th&ocirc;ng qua hai hệ thống FPT Shop v&agrave; F.Studio, những chiếc&nbsp;<a href="http://vtv.vn/iphone-x.html" target="_blank">iPhone X</a>với m&atilde; VN/A sẽ ch&iacute;nh thức l&ecirc;n kệ v&agrave;o ng&agrave;y 8/12 tới đ&acirc;y. FPT cho biết kh&aacute;ch h&agrave;ng c&oacute; thể đặt mua trước từ ng&agrave;y 1 - 7/12.</p>

<p>Về gi&aacute; b&aacute;n, iPhone X sẽ được b&aacute;n lần lượt ở mức 29.990.000 đồng v&agrave; 34.790.000 đồng tương ứng với 2 phi&ecirc;n bản dung lượng 64GB v&agrave; 256GB. Đ&aacute;ng ch&uacute; &yacute; trong lần b&aacute;n lần n&agrave;y, gi&aacute; b&aacute;n kh&ocirc;ng thay đổi tại c&aacute;c phi&ecirc;n bản m&agrave;u bạc cũng như x&aacute;m.</p>

<p><img alt="Ngày 8/12, iPhone X chính hãng lên kệ tại Việt Nam với giá 30 triệu đồng - Ảnh 1." src="https://vtv1.mediacdn.vn/thumb_w/640/2017/if-you-ask-me-i-think-the-iphone-x-is-much-better-than-the-iphone-8-1510223473242.jpg" /></p>

<p>iPhone X ch&iacute;nh h&atilde;ng sẽ được b&aacute;n tại Việt Nam v&agrave;o ng&agrave;y 8/12 tới đ&acirc;y</p>

<p>Li&ecirc;n hệ với một đơn vị được nhập khẩu ch&iacute;nh h&atilde;ng iPhone kh&aacute;c l&agrave; Thế giới di động, đại diện của h&atilde;ng n&agrave;y cho biết sẽ b&aacute;n iPhone X ch&iacute;nh h&atilde;ng tại c&aacute;c cửa h&agrave;ng v&agrave;o ng&agrave;y 8/12 tới đ&acirc;y.</p>

<p>En_Đ&aacute;ng ch&uacute; &yacute;, h&atilde;ng n&agrave;y cũng cho ph&eacute;p người d&ugrave;ng đặt mua trước từ ng&agrave;y 1 - 7/12 tới. Ngo&agrave;i ra, gi&aacute; b&aacute;n cũng tương tự FPT l&agrave; 29.990.000 đồng v&agrave; 34.790.000 đồng tương ứng với 2 phi&ecirc;n bản dung lượng 64GB v&agrave; 256GB cho 2 m&agrave;u Silver (Bạc) v&agrave; Gray (X&aacute;m).</p>

<p>Trước đ&oacute;, một số lượng kh&ocirc;ng nhỏ những chiếc iPhone X đ&atilde; được b&aacute;n tại Việt Nam kể từ ng&agrave;y thiết bị n&agrave;y ch&iacute;nh thức l&ecirc;n kệ v&agrave;o ng&agrave;y 3/11. Tuy nhi&ecirc;n những chiếc iPhone X n&agrave;y đều được nhập về qua h&igrave;nh thức x&aacute;ch tay.</p>

<p>Sự c&oacute; mặt của những chiếc iPhone X ch&iacute;nh h&atilde;ng v&agrave;o đầu th&aacute;ng 12 tới tại Việt Nam được xem l&agrave; th&ocirc;ng tin rất vui cho những người d&ugrave;ng muốn sự &quot;an to&agrave;n&quot; tuyệt đối cho những thiết bị của m&igrave;nh.</p>

<p>Apple c&oacute; ch&iacute;nh s&aacute;ch bảo h&agrave;nh với những chiếc iPhone x&aacute;ch tay. Song kh&ocirc;ng phải thiết bị n&agrave;o cũng sẽ được c&aacute;c trung t&acirc;m bảo h&agrave;nh m&agrave;&nbsp;<a href="http://vtv.vn/cong-nghe/apple-lai-bao-nhieu-voi-moi-chiec-iphone-x-20171107144332591.htm" target="_blank">Apple</a>&nbsp;ủy quyền chấp nhận sửa chữa hoặc thay mới trong c&aacute;c trường hợp gặp sự cố: phải đủ giấy tờ mua b&aacute;n, m&atilde; m&aacute;y phải ph&ugrave; hợp...</p>

<p>&nbsp;</p>

<p><img alt="Ngày 8/12, iPhone X chính hãng lên kệ tại Việt Nam với giá 30 triệu đồng - Ảnh 2." src="https://vtv1.mediacdn.vn/2017/cotd111-1509597984111-1510826076491.png" />Chi ph&iacute; sửa chữa cho iPhone X ở mức rất cao: chi ph&iacute; thay thế m&agrave;n h&igrave;nh l&ecirc;n đến 279 USD (khoảng 6,4 triệu đồng), đắt hơn bất cứ m&agrave;n h&igrave;nh iPhone n&agrave;o kh&aacute;c; tổng chi ph&iacute; sửa chữa bảo h&agrave;nh kh&aacute;c tr&ecirc;n iPhone X ở mức 549 USD (khoảng 12,5 triệu đồng) - số tiền đ&uacute;ng bằng gi&aacute; b&aacute;n khởi điểm của iPhone 7.</p>
', N'Về giá bán, iPhone X sẽ được bán lần lượt ở mức 29.990.000 đồng và 34.790.000 đồng tương ứng với 2 phiên bản dung lượng 64GB và 256GB. Đáng chú ý trong lần bán lần này, giá bán không thay đổi tại các phiên bản màu bạc cũng như xám.', N'En_Về giá bán, iPhone X sẽ được bán lần lượt ở mức 29.990.000 đồng và 34.790.000 đồng tương ứng với 2 phiên bản dung lượng 64GB và 256GB. Đáng chú ý trong lần bán lần này, giá bán không thay đổi tại các phiên bản màu bạc cũng như xám.', 1, N'tk', N'mt', N'tk_en', N'mt_en', CAST(N'2017-11-16T19:41:28.597' AS DateTime), CAST(N'2017-12-09T13:39:20.367' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Posts] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCarts] ON 
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (58, 2, NULL, 4)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (59, 3, NULL, 2)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (60, 2, NULL, 4)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (61, 4, NULL, 2)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (62, 4, NULL, 4)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (63, 4, NULL, 2)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (64, 3, NULL, 4)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (65, 4, NULL, 2)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (66, 2, NULL, 4)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (67, 2, NULL, 2)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (68, 15, NULL, 4)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (69, 4, NULL, 4)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (70, 6, NULL, 2)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (71, 3, NULL, 3)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (73, 1, NULL, 6)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (74, 4, NULL, 3)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (85, 4, N'b7b0f4a0-d42b-4081-928f-91b2210a023e', 3)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (86, 16, N'b7b0f4a0-d42b-4081-928f-91b2210a023e', 2)
GO
SET IDENTITY_INSERT [dbo].[ProductCarts] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([Id], [Code], [Name], [Name_en], [Summary], [Summary_en], [ImageUrl], [PdfUrl], [LinkGuide], [Cad2dUrl], [Cad3dUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [Category_Id]) VALUES (1, N'CR', N'Máy cơ khí', N'Máy cơ khí', N'<p>dasdsa</p>
', N'<p>dasdsad</p>
', N'20171205212111510_bb6930dc6fa04601b85dc54d6f2861a6.jpg', N'20171125154826260_91ba76993f604ed482b570898f238d01.pdf', N'https://www.google.com', NULL, NULL, N'DDD 1', N'abx', N'xxx', N'cdscs', 3)
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductVariants] ON 
GO
INSERT [dbo].[ProductVariants] ([Id], [VariantName], [VariantCode], [Price], [OnHand], [BrandName], [Origin], [Product_Id], [ProductVariantUnit_Id]) VALUES (2, N'BBB', N'AAA', CAST(3000000.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), N'GHO', N'Japan', 1, 2)
GO
INSERT [dbo].[ProductVariants] ([Id], [VariantName], [VariantCode], [Price], [OnHand], [BrandName], [Origin], [Product_Id], [ProductVariantUnit_Id]) VALUES (3, N'YYY', N'BBB', CAST(34.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'sdasf', N'dasds', 1, 3)
GO
INSERT [dbo].[ProductVariants] ([Id], [VariantName], [VariantCode], [Price], [OnHand], [BrandName], [Origin], [Product_Id], [ProductVariantUnit_Id]) VALUES (4, N'TTT', N'CCC', CAST(25000.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), N'Brazo', N'New York', 1, 2)
GO
INSERT [dbo].[ProductVariants] ([Id], [VariantName], [VariantCode], [Price], [OnHand], [BrandName], [Origin], [Product_Id], [ProductVariantUnit_Id]) VALUES (6, N'UUU', N'DDD', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'ER', N'A', 1, 2)
GO
INSERT [dbo].[ProductVariants] ([Id], [VariantName], [VariantCode], [Price], [OnHand], [BrandName], [Origin], [Product_Id], [ProductVariantUnit_Id]) VALUES (9, N'III', N'FFF', CAST(40000.00 AS Decimal(18, 2)), CAST(4.00 AS Decimal(18, 2)), N'HIHI', N'HUHU', 1, 3)
GO
SET IDENTITY_INSERT [dbo].[ProductVariants] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductVariantUnits] ON 
GO
INSERT [dbo].[ProductVariantUnits] ([Id], [Name]) VALUES (2, N'Cái')
GO
INSERT [dbo].[ProductVariantUnits] ([Id], [Name]) VALUES (3, N'Bộ')
GO
SET IDENTITY_INSERT [dbo].[ProductVariantUnits] OFF
GO
SET IDENTITY_INSERT [dbo].[PurchaseOrderDetails] ON 
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (1, 1, CAST(N'2017-12-04T23:02:07.203' AS DateTime), 2, 3, 1, CAST(10000.00 AS Decimal(18, 2)), CAST(10000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (2, 1, CAST(N'2017-12-04T23:02:07.263' AS DateTime), 2, 6, 1, CAST(10000.00 AS Decimal(18, 2)), CAST(10000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (4, 4, CAST(N'2017-12-04T23:15:29.157' AS DateTime), 2, 4, 3, CAST(10000.00 AS Decimal(18, 2)), CAST(40000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (7, 5, CAST(N'2017-12-06T21:30:21.750' AS DateTime), 1, 4, NULL, CAST(10000.00 AS Decimal(18, 2)), CAST(50000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (8, 4, CAST(N'2017-12-06T21:30:21.757' AS DateTime), 1, 2, NULL, CAST(10000.00 AS Decimal(18, 2)), CAST(40000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (9, 5, CAST(N'2017-12-06T22:06:17.707' AS DateTime), 1, 4, 6, CAST(10000.00 AS Decimal(18, 2)), CAST(50000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (10, 3, CAST(N'2017-12-06T22:06:17.707' AS DateTime), 1, 2, 6, CAST(10000.00 AS Decimal(18, 2)), CAST(30000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (11, 1, CAST(N'2017-12-06T22:33:46.603' AS DateTime), 2, 3, 7, CAST(10000.00 AS Decimal(18, 2)), CAST(10000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (12, 1, CAST(N'2017-12-06T22:33:46.653' AS DateTime), 2, 6, 7, CAST(10000.00 AS Decimal(18, 2)), CAST(10000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (13, 1, CAST(N'2017-12-06T22:35:18.567' AS DateTime), 1, 3, NULL, CAST(10000.00 AS Decimal(18, 2)), CAST(10000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (16, 9, CAST(N'2017-12-08T21:28:12.880' AS DateTime), 2, 2, 10, CAST(3000000.00 AS Decimal(18, 2)), CAST(27000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (17, 5, CAST(N'2017-12-08T21:28:12.900' AS DateTime), 2, 4, 10, CAST(25000.00 AS Decimal(18, 2)), CAST(125000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (18, 147, NULL, 1, 3, 9, CAST(500000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (19, 18, NULL, 1, 6, 9, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (20, 3, CAST(N'2017-12-11T23:44:08.977' AS DateTime), 1, 4, 11, CAST(25000.00 AS Decimal(18, 2)), CAST(75000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (21, 22, CAST(N'2017-12-16T12:51:06.467' AS DateTime), 2, 4, 12, CAST(25000.00 AS Decimal(18, 2)), CAST(550000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (22, 2, CAST(N'2017-12-12T15:03:04.240' AS DateTime), 1, 2, 13, CAST(3000000.00 AS Decimal(18, 2)), CAST(6000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (23, 5, CAST(N'2017-12-12T18:17:36.277' AS DateTime), 1, 4, 14, CAST(25000.00 AS Decimal(18, 2)), CAST(125000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (24, 30, CAST(N'2017-12-16T18:17:36.277' AS DateTime), 1, 2, 14, CAST(3000000.00 AS Decimal(18, 2)), CAST(90000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (25, 4, CAST(N'2017-12-12T18:33:16.150' AS DateTime), 1, 2, 15, CAST(3000000.00 AS Decimal(18, 2)), CAST(12000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (26, 6, CAST(N'2017-12-12T18:33:16.150' AS DateTime), 1, 4, 15, CAST(25000.00 AS Decimal(18, 2)), CAST(150000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (27, 4, CAST(N'2017-12-12T18:42:20.297' AS DateTime), 1, 2, 16, CAST(3000000.00 AS Decimal(18, 2)), CAST(12000000.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[PurchaseOrderDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[PurchaseOrders] ON 
GO
INSERT [dbo].[PurchaseOrders] ([Id], [Code], [Name], [State], [CreatedDate], [Customer_Id], [IsDeleted], [PaymentMethod], [CustomerAddress], [CustomerPhone], [CustomerEmail], [CustomerWebsite]) VALUES (1, N'171201110134', N'PO_Order', 2, CAST(N'2017-12-01T23:02:07.140' AS DateTime), N'e2043988-480e-4689-8532-d512b4a45f84', 0, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [Code], [Name], [State], [CreatedDate], [Customer_Id], [IsDeleted], [PaymentMethod], [CustomerAddress], [CustomerPhone], [CustomerEmail], [CustomerWebsite]) VALUES (3, N'171201111513', N'EEE', 2, CAST(N'2017-12-01T23:15:29.133' AS DateTime), N'b7b0f4a0-d42b-4081-928f-91b2210a023e', 0, 2, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [Code], [Name], [State], [CreatedDate], [Customer_Id], [IsDeleted], [PaymentMethod], [CustomerAddress], [CustomerPhone], [CustomerEmail], [CustomerWebsite]) VALUES (6, N'171203100530', N'RRR', 1, CAST(N'2017-12-03T22:06:17.707' AS DateTime), N'b7b0f4a0-d42b-4081-928f-91b2210a023e', 0, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [Code], [Name], [State], [CreatedDate], [Customer_Id], [IsDeleted], [PaymentMethod], [CustomerAddress], [CustomerPhone], [CustomerEmail], [CustomerWebsite]) VALUES (7, N'171203103011', N'My_Back_PO', 2, CAST(N'2017-12-03T22:33:46.520' AS DateTime), N'e2043988-480e-4689-8532-d512b4a45f84', 0, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [Code], [Name], [State], [CreatedDate], [Customer_Id], [IsDeleted], [PaymentMethod], [CustomerAddress], [CustomerPhone], [CustomerEmail], [CustomerWebsite]) VALUES (9, N'171203103534', N'My_Back_Temp', 1, CAST(N'2017-12-03T22:35:42.290' AS DateTime), N'e2043988-480e-4689-8532-d512b4a45f84', 0, 2, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [Code], [Name], [State], [CreatedDate], [Customer_Id], [IsDeleted], [PaymentMethod], [CustomerAddress], [CustomerPhone], [CustomerEmail], [CustomerWebsite]) VALUES (10, N'171205092753', N'UUU', 5, CAST(N'2017-12-05T21:28:12.853' AS DateTime), N'b7b0f4a0-d42b-4081-928f-91b2210a023e', 0, 0, N'123 Trần Hưng Đạo, P4, Q5', NULL, N'plaza.magazine@gmail.com', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [Code], [Name], [State], [CreatedDate], [Customer_Id], [IsDeleted], [PaymentMethod], [CustomerAddress], [CustomerPhone], [CustomerEmail], [CustomerWebsite]) VALUES (11, N'171208114359', N'TTT', 1, CAST(N'2017-12-08T23:44:08.953' AS DateTime), N'b7b0f4a0-d42b-4081-928f-91b2210a023e', 0, 0, N'123 Trần Hưng Đạo, P4, Q5', NULL, N'plaza.magazine@gmail.com', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [Code], [Name], [State], [CreatedDate], [Customer_Id], [IsDeleted], [PaymentMethod], [CustomerAddress], [CustomerPhone], [CustomerEmail], [CustomerWebsite]) VALUES (12, N'171209124937', N'HOHO', 2, CAST(N'2017-12-09T12:51:06.390' AS DateTime), N'b7b0f4a0-d42b-4081-928f-91b2210a023e', 0, 0, N'123 Trần Hưng Đạo, P4, Q5', NULL, N'plaza.magazine@gmail.com', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [Code], [Name], [State], [CreatedDate], [Customer_Id], [IsDeleted], [PaymentMethod], [CustomerAddress], [CustomerPhone], [CustomerEmail], [CustomerWebsite]) VALUES (13, N'171209030304', N'Temp_171209030304', 1, CAST(N'2017-12-09T15:03:04.213' AS DateTime), N'b7b0f4a0-d42b-4081-928f-91b2210a023e', 0, 0, N'123 Trần Hưng Đạo, P4, Q5', NULL, N'plaza.magazine@gmail.com', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [Code], [Name], [State], [CreatedDate], [Customer_Id], [IsDeleted], [PaymentMethod], [CustomerAddress], [CustomerPhone], [CustomerEmail], [CustomerWebsite]) VALUES (14, N'171209061703', N'TATA', 1, CAST(N'2017-12-09T18:17:36.277' AS DateTime), N'b7b0f4a0-d42b-4081-928f-91b2210a023e', 0, 0, N'123 Trần Hưng Đạo, P4, Q5', NULL, N'plaza.magazine@gmail.com', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [Code], [Name], [State], [CreatedDate], [Customer_Id], [IsDeleted], [PaymentMethod], [CustomerAddress], [CustomerPhone], [CustomerEmail], [CustomerWebsite]) VALUES (15, N'171209063234', N'Hura', 1, CAST(N'2017-12-09T18:33:16.147' AS DateTime), N'b7b0f4a0-d42b-4081-928f-91b2210a023e', 0, 0, N'123 Trần Hưng Đạo, P4, Q5', NULL, N'plaza.magazine@gmail.com', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [Code], [Name], [State], [CreatedDate], [Customer_Id], [IsDeleted], [PaymentMethod], [CustomerAddress], [CustomerPhone], [CustomerEmail], [CustomerWebsite]) VALUES (16, N'171209064005', N'HURA', 1, CAST(N'2017-12-09T18:42:20.297' AS DateTime), N'b7b0f4a0-d42b-4081-928f-91b2210a023e', 0, 0, N'123 Trần Hưng Đạo, P4, Q5', NULL, N'plaza.magazine@gmail.com', NULL)
GO
SET IDENTITY_INSERT [dbo].[PurchaseOrders] OFF
GO
INSERT [dbo].[ShipDateSettingProductVariants] ([ShipDateSetting_Id], [ProductVariant_Id]) VALUES (1, 2)
GO
INSERT [dbo].[ShipDateSettingProductVariants] ([ShipDateSetting_Id], [ProductVariant_Id]) VALUES (2, 2)
GO
INSERT [dbo].[ShipDateSettingProductVariants] ([ShipDateSetting_Id], [ProductVariant_Id]) VALUES (1, 3)
GO
INSERT [dbo].[ShipDateSettingProductVariants] ([ShipDateSetting_Id], [ProductVariant_Id]) VALUES (2, 3)
GO
INSERT [dbo].[ShipDateSettingProductVariants] ([ShipDateSetting_Id], [ProductVariant_Id]) VALUES (1, 4)
GO
INSERT [dbo].[ShipDateSettingProductVariants] ([ShipDateSetting_Id], [ProductVariant_Id]) VALUES (2, 4)
GO
INSERT [dbo].[ShipDateSettingProductVariants] ([ShipDateSetting_Id], [ProductVariant_Id]) VALUES (3, 4)
GO
INSERT [dbo].[ShipDateSettingProductVariants] ([ShipDateSetting_Id], [ProductVariant_Id]) VALUES (1, 6)
GO
INSERT [dbo].[ShipDateSettingProductVariants] ([ShipDateSetting_Id], [ProductVariant_Id]) VALUES (2, 6)
GO
INSERT [dbo].[ShipDateSettingProductVariants] ([ShipDateSetting_Id], [ProductVariant_Id]) VALUES (3, 6)
GO
INSERT [dbo].[ShipDateSettingProductVariants] ([ShipDateSetting_Id], [ProductVariant_Id]) VALUES (1, 9)
GO
INSERT [dbo].[ShipDateSettingProductVariants] ([ShipDateSetting_Id], [ProductVariant_Id]) VALUES (2, 9)
GO
INSERT [dbo].[ShipDateSettingProductVariants] ([ShipDateSetting_Id], [ProductVariant_Id]) VALUES (3, 9)
GO
SET IDENTITY_INSERT [dbo].[ShipDateSettings] ON 
GO
INSERT [dbo].[ShipDateSettings] ([Id], [QuantityOrderMax], [TargetDateNumber]) VALUES (1, 10, 3)
GO
INSERT [dbo].[ShipDateSettings] ([Id], [QuantityOrderMax], [TargetDateNumber]) VALUES (2, 50, 7)
GO
INSERT [dbo].[ShipDateSettings] ([Id], [QuantityOrderMax], [TargetDateNumber]) VALUES (3, 120, 12)
GO
SET IDENTITY_INSERT [dbo].[ShipDateSettings] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 12/10/17 2:10:22 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 12/10/17 2:10:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 12/10/17 2:10:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleId]    Script Date: 12/10/17 2:10:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 12/10/17 2:10:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 12/10/17 2:10:22 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ParentCategory_Id]    Script Date: 12/10/17 2:10:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_ParentCategory_Id] ON [dbo].[Categories]
(
	[ParentCategory_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ParentCategory_Id]    Script Date: 12/10/17 2:10:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_ParentCategory_Id] ON [dbo].[PostCategories]
(
	[ParentCategory_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Category_Id]    Script Date: 12/10/17 2:10:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_Category_Id] ON [dbo].[Posts]
(
	[Category_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Customer_Id]    Script Date: 12/10/17 2:10:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_Customer_Id] ON [dbo].[ProductCarts]
(
	[Customer_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductVariant_Id]    Script Date: 12/10/17 2:10:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductVariant_Id] ON [dbo].[ProductCarts]
(
	[ProductVariant_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Category_Id]    Script Date: 12/10/17 2:10:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_Category_Id] ON [dbo].[Products]
(
	[Category_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_Id]    Script Date: 12/10/17 2:10:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_Product_Id] ON [dbo].[ProductVariants]
(
	[Product_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductVariantUnit_Id]    Script Date: 12/10/17 2:10:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductVariantUnit_Id] ON [dbo].[ProductVariants]
(
	[ProductVariantUnit_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_Id]    Script Date: 12/10/17 2:10:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_Product_Id] ON [dbo].[PurchaseOrderDetails]
(
	[Product_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_PurchaseOrder_Id]    Script Date: 12/10/17 2:10:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_Id] ON [dbo].[PurchaseOrderDetails]
(
	[PurchaseOrder_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Customer_Id]    Script Date: 12/10/17 2:10:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_Customer_Id] ON [dbo].[PurchaseOrders]
(
	[Customer_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductVariant_Id]    Script Date: 12/10/17 2:10:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductVariant_Id] ON [dbo].[ShipDateSettingProductVariants]
(
	[ProductVariant_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ShipDateSetting_Id]    Script Date: 12/10/17 2:10:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_ShipDateSetting_Id] ON [dbo].[ShipDateSettingProductVariants]
(
	[ShipDateSetting_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PurchaseOrderDetails] ADD  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[PurchaseOrderDetails] ADD  DEFAULT ((0)) FOR [TotalAmount]
GO
ALTER TABLE [dbo].[PurchaseOrders] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[PurchaseOrders] ADD  DEFAULT ((0)) FOR [PaymentMethod]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Categories_dbo.Categories_ParentCategory_Id] FOREIGN KEY([ParentCategory_Id])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_dbo.Categories_dbo.Categories_ParentCategory_Id]
GO
ALTER TABLE [dbo].[PostCategories]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PostCategories_dbo.PostCategories_ParentCategory_Id] FOREIGN KEY([ParentCategory_Id])
REFERENCES [dbo].[PostCategories] ([Id])
GO
ALTER TABLE [dbo].[PostCategories] CHECK CONSTRAINT [FK_dbo.PostCategories_dbo.PostCategories_ParentCategory_Id]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Posts_dbo.PostCategories_Category_Id] FOREIGN KEY([Category_Id])
REFERENCES [dbo].[PostCategories] ([Id])
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_dbo.Posts_dbo.PostCategories_Category_Id]
GO
ALTER TABLE [dbo].[ProductCarts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProductCarts_dbo.AspNetUsers_Customer_Id] FOREIGN KEY([Customer_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[ProductCarts] CHECK CONSTRAINT [FK_dbo.ProductCarts_dbo.AspNetUsers_Customer_Id]
GO
ALTER TABLE [dbo].[ProductCarts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProductCarts_dbo.ProductVariants_ProductVariant_Id] FOREIGN KEY([ProductVariant_Id])
REFERENCES [dbo].[ProductVariants] ([Id])
GO
ALTER TABLE [dbo].[ProductCarts] CHECK CONSTRAINT [FK_dbo.ProductCarts_dbo.ProductVariants_ProductVariant_Id]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Products_dbo.Categories_Category_Id] FOREIGN KEY([Category_Id])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_dbo.Products_dbo.Categories_Category_Id]
GO
ALTER TABLE [dbo].[ProductVariants]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProductVariants_dbo.Products_Product_Id] FOREIGN KEY([Product_Id])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ProductVariants] CHECK CONSTRAINT [FK_dbo.ProductVariants_dbo.Products_Product_Id]
GO
ALTER TABLE [dbo].[ProductVariants]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ProductVariants_dbo.ProductVariantUnits_ProductVariantUnit_Id] FOREIGN KEY([ProductVariantUnit_Id])
REFERENCES [dbo].[ProductVariantUnits] ([Id])
GO
ALTER TABLE [dbo].[ProductVariants] CHECK CONSTRAINT [FK_dbo.ProductVariants_dbo.ProductVariantUnits_ProductVariantUnit_Id]
GO
ALTER TABLE [dbo].[PurchaseOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PurchaseOrderDetails_dbo.ProductVariants_Product_Id] FOREIGN KEY([Product_Id])
REFERENCES [dbo].[ProductVariants] ([Id])
GO
ALTER TABLE [dbo].[PurchaseOrderDetails] CHECK CONSTRAINT [FK_dbo.PurchaseOrderDetails_dbo.ProductVariants_Product_Id]
GO
ALTER TABLE [dbo].[PurchaseOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PurchaseOrderDetails_dbo.PurchaseOrders_PurchaseOrder_Id] FOREIGN KEY([PurchaseOrder_Id])
REFERENCES [dbo].[PurchaseOrders] ([Id])
GO
ALTER TABLE [dbo].[PurchaseOrderDetails] CHECK CONSTRAINT [FK_dbo.PurchaseOrderDetails_dbo.PurchaseOrders_PurchaseOrder_Id]
GO
ALTER TABLE [dbo].[PurchaseOrders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PurchaseOrders_dbo.AspNetUsers_Customer_Id] FOREIGN KEY([Customer_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[PurchaseOrders] CHECK CONSTRAINT [FK_dbo.PurchaseOrders_dbo.AspNetUsers_Customer_Id]
GO
ALTER TABLE [dbo].[ShipDateSettingProductVariants]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ShipDateSettingProductVariants_dbo.ProductVariants_ProductVariant_Id] FOREIGN KEY([ProductVariant_Id])
REFERENCES [dbo].[ProductVariants] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShipDateSettingProductVariants] CHECK CONSTRAINT [FK_dbo.ShipDateSettingProductVariants_dbo.ProductVariants_ProductVariant_Id]
GO
ALTER TABLE [dbo].[ShipDateSettingProductVariants]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ShipDateSettingProductVariants_dbo.ShipDateSettings_ShipDateSetting_Id] FOREIGN KEY([ShipDateSetting_Id])
REFERENCES [dbo].[ShipDateSettings] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ShipDateSettingProductVariants] CHECK CONSTRAINT [FK_dbo.ShipDateSettingProductVariants_dbo.ShipDateSettings_ShipDateSetting_Id]
GO
/****** Object:  StoredProcedure [upu10905a_upup_admin].[SearchForPostByTitle]    Script Date: 12/10/17 2:10:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [upu10905a_upup_admin].[SearchForPostByTitle]
	@term NVARCHAR(MAX)
AS
BEGIN

	DECLARE @term_ko_dau NVARCHAR(MAX) = LOWER(LTRIM(RTRIM( dbo.fChuyenCoDauThanhKhongDau(@term) )));
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Posts
	WHERE 
	LOWER(LTRIM(RTRIM( dbo.fChuyenCoDauThanhKhongDau(Posts.Title)))) LIKE '%' + @term_ko_dau +'%'
	OR LOWER(LTRIM(RTRIM( dbo.fChuyenCoDauThanhKhongDau(Posts.Title_en)))) LIKE '%' + @term_ko_dau +'%'	
	OR LOWER(LTRIM(RTRIM( dbo.fChuyenCoDauThanhKhongDau(Posts.MetaDescription)))) LIKE '%' + @term_ko_dau +'%'	
	OR LOWER(LTRIM(RTRIM( dbo.fChuyenCoDauThanhKhongDau(Posts.MetaDescription_en)))) LIKE '%' + @term_ko_dau +'%'	

END
GO
/****** Object:  StoredProcedure [upu10905a_upup_admin].[SearchForPostContent]    Script Date: 12/10/17 2:10:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [upu10905a_upup_admin].[SearchForPostContent]
	@term NVARCHAR(MAX)
AS
BEGIN

	DECLARE @term_ko_dau NVARCHAR(MAX) = LOWER(LTRIM(RTRIM( dbo.fChuyenCoDauThanhKhongDau(@term) )));
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Posts
	WHERE 
	LOWER(LTRIM(RTRIM( dbo.fChuyenCoDauThanhKhongDau(Posts.Content)))) LIKE '%' + @term_ko_dau +'%'
	OR LOWER(LTRIM(RTRIM( dbo.fChuyenCoDauThanhKhongDau(Posts.Content_en)))) LIKE '%' + @term_ko_dau +'%'	

END
GO
/****** Object:  StoredProcedure [upu10905a_upup_admin].[SearchForProduct]    Script Date: 12/10/17 2:10:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [upu10905a_upup_admin].[SearchForProduct]
	@term NVARCHAR(MAX)
AS
BEGIN

	DECLARE @term_ko_dau NVARCHAR(MAX) = LOWER(LTRIM(RTRIM( dbo.fChuyenCoDauThanhKhongDau(@term) )));
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Products
	WHERE 
	LOWER(LTRIM(RTRIM( dbo.fChuyenCoDauThanhKhongDau(Products.[Name])))) LIKE '%' + @term_ko_dau +'%'
	OR LOWER(LTRIM(RTRIM( dbo.fChuyenCoDauThanhKhongDau(Products.[Name_en])))) LIKE '%' + @term_ko_dau +'%'
	OR LOWER(LTRIM(RTRIM( dbo.fChuyenCoDauThanhKhongDau(Products.Code)))) LIKE '%' + @term_ko_dau +'%'
	OR LOWER(LTRIM(RTRIM( dbo.fChuyenCoDauThanhKhongDau(Products.MetaDescription)))) LIKE '%' + @term_ko_dau +'%'
	OR LOWER(LTRIM(RTRIM( dbo.fChuyenCoDauThanhKhongDau(Products.MetaDescription_en)))) LIKE '%' + @term_ko_dau +'%'

END
GO
USE [master]
GO
ALTER DATABASE [upu10905a_db] SET  READ_WRITE 
GO
