USE [master]
GO
/****** Object:  Database [CarRental]    Script Date: 21/12/2020 19:54:14 ******/
CREATE DATABASE [CarRental]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarRental', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CarRental.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CarRental_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CarRental_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CarRental] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarRental].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarRental] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarRental] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarRental] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarRental] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarRental] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarRental] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarRental] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarRental] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarRental] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarRental] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarRental] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarRental] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarRental] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarRental] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarRental] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarRental] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarRental] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarRental] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarRental] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarRental] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarRental] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarRental] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarRental] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CarRental] SET  MULTI_USER 
GO
ALTER DATABASE [CarRental] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarRental] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarRental] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarRental] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CarRental] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CarRental] SET QUERY_STORE = OFF
GO
USE [CarRental]
GO
/****** Object:  Table [dbo].[Branches]    Script Date: 21/12/2020 19:54:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branches](
	[BranchID] [int] IDENTITY(1,1) NOT NULL,
	[BranchName] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Longitude] [nvarchar](50) NULL,
	[Latitude] [nvarchar](50) NULL,
	[Phone] [nvarchar](20) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Branches] PRIMARY KEY CLUSTERED 
(
	[BranchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarData]    Script Date: 21/12/2020 19:54:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarData](
	[CarDataID] [int] IDENTITY(1,1) NOT NULL,
	[CarTypeID] [int] NOT NULL,
	[Kilometer] [int] NULL,
	[CreateAt] [date] NULL,
	[Gear] [nvarchar](50) NULL,
	[Notes] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[BranchID] [int] NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[CarDataID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarType]    Script Date: 21/12/2020 19:54:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarType](
	[CarTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Manufacturer] [nvarchar](50) NULL,
	[Model] [nvarchar](50) NULL,
	[PricePerDay] [money] NULL,
	[ImageFileName] [nvarchar](200) NULL,
 CONSTRAINT [PK_CarType] PRIMARY KEY CLUSTERED 
(
	[CarTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rentals]    Script Date: 21/12/2020 19:54:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rentals](
	[RentalID] [int] IDENTITY(1,1) NOT NULL,
	[CarDataID] [int] NOT NULL,
	[UserID] [int] NULL,
	[BranchStartID] [int] NULL,
	[BranchEndID] [int] NULL,
	[PickUpTime] [date] NULL,
	[ReturnTime] [date] NULL,
	[FinalReturnTime] [date] NULL,
	[ExpectedPrice] [money] NULL,
	[FinalPrice] [money] NULL,
 CONSTRAINT [PK_Rentals] PRIMARY KEY CLUSTERED 
(
	[RentalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 21/12/2020 19:54:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[IdCard] [nvarchar](50) NULL,
	[LicenseNumber] [nvarchar](50) NULL,
	[LicenseType] [nvarchar](50) NULL,
	[BirthDate] [date] NULL,
	[Gender] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Role] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[RegisterDate] [date] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Branches] ON 

INSERT [dbo].[Branches] ([BranchID], [BranchName], [Country], [City], [Longitude], [Latitude], [Phone], [Email]) VALUES (1, N'Tel Aviv', N'Israel', N'Tel Aviv', N'32.072865', N'34.774576', N'0501235655', N'telaviv@gmail.com')
INSERT [dbo].[Branches] ([BranchID], [BranchName], [Country], [City], [Longitude], [Latitude], [Phone], [Email]) VALUES (2, N'Haifa', N'Israel', N'Haifa', N'34.965454', N'32.782001', N'0501235654', N'haifa@gmail.com')
INSERT [dbo].[Branches] ([BranchID], [BranchName], [Country], [City], [Longitude], [Latitude], [Phone], [Email]) VALUES (3, N'Jerusalem', N'Israel', N'Jerusalem', N'35.234554', N'31.776411', N'123', N'jerusalem@gmail.com')
SET IDENTITY_INSERT [dbo].[Branches] OFF
GO
SET IDENTITY_INSERT [dbo].[CarData] ON 

INSERT [dbo].[CarData] ([CarDataID], [CarTypeID], [Kilometer], [CreateAt], [Gear], [Notes], [Image], [BranchID]) VALUES (12, 6, 1000, CAST(N'2020-01-01' AS Date), N'Automate', N'test', NULL, 2)
INSERT [dbo].[CarData] ([CarDataID], [CarTypeID], [Kilometer], [CreateAt], [Gear], [Notes], [Image], [BranchID]) VALUES (13, 8, 2000, CAST(N'2020-02-02' AS Date), N'Manual', NULL, NULL, 1)
INSERT [dbo].[CarData] ([CarDataID], [CarTypeID], [Kilometer], [CreateAt], [Gear], [Notes], [Image], [BranchID]) VALUES (14, 9, 3000, CAST(N'2020-03-03' AS Date), N'Automate', NULL, NULL, 3)
INSERT [dbo].[CarData] ([CarDataID], [CarTypeID], [Kilometer], [CreateAt], [Gear], [Notes], [Image], [BranchID]) VALUES (15, 10, 4000, CAST(N'2020-04-04' AS Date), N'Manual', NULL, NULL, 1)
INSERT [dbo].[CarData] ([CarDataID], [CarTypeID], [Kilometer], [CreateAt], [Gear], [Notes], [Image], [BranchID]) VALUES (16, 11, 5000, CAST(N'2020-05-05' AS Date), N'Automate', NULL, NULL, 2)
SET IDENTITY_INSERT [dbo].[CarData] OFF
GO
SET IDENTITY_INSERT [dbo].[CarType] ON 

INSERT [dbo].[CarType] ([CarTypeID], [Manufacturer], [Model], [PricePerDay], [ImageFileName]) VALUES (6, N'Ferari', N'812', 950.0000, N'279b3a38-38d6-4198-a7c3-dfb39c93fc78.jpg')
INSERT [dbo].[CarType] ([CarTypeID], [Manufacturer], [Model], [PricePerDay], [ImageFileName]) VALUES (8, N'Skoda', N'Superb', 150.0000, N'fe81ed4e-18ca-4aa0-bfcc-7e8cb63f867f.jpg')
INSERT [dbo].[CarType] ([CarTypeID], [Manufacturer], [Model], [PricePerDay], [ImageFileName]) VALUES (9, N'Kia', N'Pikanto', 70.0000, N'70a29845-488b-4407-8141-3a7ab798cc17.jpg')
INSERT [dbo].[CarType] ([CarTypeID], [Manufacturer], [Model], [PricePerDay], [ImageFileName]) VALUES (10, N'Bmw', N'i8', 800.0000, N'839c65b5-5c3b-4a97-869f-8fd3931c9c6c.jpg')
INSERT [dbo].[CarType] ([CarTypeID], [Manufacturer], [Model], [PricePerDay], [ImageFileName]) VALUES (11, N'Isuzu', N'D-Max', 500.0000, N'cec381b0-a6c0-4d6a-990d-de45b238d7df.png')
SET IDENTITY_INSERT [dbo].[CarType] OFF
GO
SET IDENTITY_INSERT [dbo].[Rentals] ON 

INSERT [dbo].[Rentals] ([RentalID], [CarDataID], [UserID], [BranchStartID], [BranchEndID], [PickUpTime], [ReturnTime], [FinalReturnTime], [ExpectedPrice], [FinalPrice]) VALUES (8, 12, 2, 1, 2, CAST(N'2020-12-10' AS Date), CAST(N'2020-12-18' AS Date), CAST(N'2020-12-18' AS Date), 7200.0000, 7200.0000)
INSERT [dbo].[Rentals] ([RentalID], [CarDataID], [UserID], [BranchStartID], [BranchEndID], [PickUpTime], [ReturnTime], [FinalReturnTime], [ExpectedPrice], [FinalPrice]) VALUES (10, 13, 2, 1, 2, CAST(N'2020-12-23' AS Date), CAST(N'2021-01-08' AS Date), NULL, 2000.0000, NULL)
INSERT [dbo].[Rentals] ([RentalID], [CarDataID], [UserID], [BranchStartID], [BranchEndID], [PickUpTime], [ReturnTime], [FinalReturnTime], [ExpectedPrice], [FinalPrice]) VALUES (11, 14, 1, 2, 3, CAST(N'2020-12-18' AS Date), CAST(N'2020-12-20' AS Date), NULL, 140.0000, NULL)
INSERT [dbo].[Rentals] ([RentalID], [CarDataID], [UserID], [BranchStartID], [BranchEndID], [PickUpTime], [ReturnTime], [FinalReturnTime], [ExpectedPrice], [FinalPrice]) VALUES (12, 15, 13, 1, 3, CAST(N'2020-12-14' AS Date), CAST(N'2020-12-17' AS Date), CAST(N'2020-12-20' AS Date), 2400.0000, 5000.0000)
INSERT [dbo].[Rentals] ([RentalID], [CarDataID], [UserID], [BranchStartID], [BranchEndID], [PickUpTime], [ReturnTime], [FinalReturnTime], [ExpectedPrice], [FinalPrice]) VALUES (13, 16, 15, 3, 2, CAST(N'2020-12-10' AS Date), CAST(N'2020-12-15' AS Date), CAST(N'2020-12-15' AS Date), 2500.0000, 2500.0000)
INSERT [dbo].[Rentals] ([RentalID], [CarDataID], [UserID], [BranchStartID], [BranchEndID], [PickUpTime], [ReturnTime], [FinalReturnTime], [ExpectedPrice], [FinalPrice]) VALUES (14, 12, 16, 2, 3, CAST(N'2020-12-19' AS Date), CAST(N'2021-01-03' AS Date), NULL, 14250.0000, NULL)
INSERT [dbo].[Rentals] ([RentalID], [CarDataID], [UserID], [BranchStartID], [BranchEndID], [PickUpTime], [ReturnTime], [FinalReturnTime], [ExpectedPrice], [FinalPrice]) VALUES (15, 13, 2, 3, 2, CAST(N'2020-11-17' AS Date), CAST(N'2020-11-20' AS Date), CAST(N'2020-11-20' AS Date), 450.0000, 450.0000)
INSERT [dbo].[Rentals] ([RentalID], [CarDataID], [UserID], [BranchStartID], [BranchEndID], [PickUpTime], [ReturnTime], [FinalReturnTime], [ExpectedPrice], [FinalPrice]) VALUES (16, 14, 1, 1, 2, CAST(N'2020-12-05' AS Date), CAST(N'2020-12-10' AS Date), CAST(N'2020-12-10' AS Date), 350.0000, 350.0000)
INSERT [dbo].[Rentals] ([RentalID], [CarDataID], [UserID], [BranchStartID], [BranchEndID], [PickUpTime], [ReturnTime], [FinalReturnTime], [ExpectedPrice], [FinalPrice]) VALUES (17, 15, 15, 2, 3, CAST(N'2020-12-21' AS Date), CAST(N'2020-12-25' AS Date), NULL, 4000.0000, NULL)
SET IDENTITY_INSERT [dbo].[Rentals] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [IdCard], [LicenseNumber], [LicenseType], [BirthDate], [Gender], [Email], [Phone], [Role], [UserName], [Password], [Image], [RegisterDate]) VALUES (1, N'Moishe', N'Ufnik', N'123456789', N'1234567', N'Manual', CAST(N'2000-01-01' AS Date), N'male', N'ufnik@gmail.com', N'050-1234567', N'Employee', N'Ufnik', N'1234', NULL, CAST(N'2020-12-12' AS Date))
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [IdCard], [LicenseNumber], [LicenseType], [BirthDate], [Gender], [Email], [Phone], [Role], [UserName], [Password], [Image], [RegisterDate]) VALUES (2, N'Shani ', N'Melamud', N'205809841', N'21231231', N'Manual', CAST(N'1995-02-13' AS Date), N'male', N'shanimelamud01@gmail.com', N'0508652664', N'Admin', N'Shani', N'1234', NULL, CAST(N'2020-12-11' AS Date))
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [IdCard], [LicenseNumber], [LicenseType], [BirthDate], [Gender], [Email], [Phone], [Role], [UserName], [Password], [Image], [RegisterDate]) VALUES (13, N'Yair', N'Lapid', N'012121212', N'012121212', N'Automate', CAST(N'1960-01-01' AS Date), N'male', N'yair@gmail.com', N'050-1111111', N'Employee', N'Yair', N'1234', NULL, CAST(N'2020-12-14' AS Date))
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [IdCard], [LicenseNumber], [LicenseType], [BirthDate], [Gender], [Email], [Phone], [Role], [UserName], [Password], [Image], [RegisterDate]) VALUES (15, N'Shiri', N'Levi', N'024545454', N'6547894', N'Automate', CAST(N'1998-01-01' AS Date), N'female', N'shiri@gmail.com', N'051-2244556', N'User', N'Shiri', N'1234', NULL, CAST(N'2020-12-15' AS Date))
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [IdCard], [LicenseNumber], [LicenseType], [BirthDate], [Gender], [Email], [Phone], [Role], [UserName], [Password], [Image], [RegisterDate]) VALUES (16, N'Yosi', N'Cohen', N'12121212', N'24242424', N'Manual', CAST(N'1958-12-15' AS Date), N'male', N'yosi@gmail.com', N'056-4545456', N'User', N'Yosi', N'1234', NULL, CAST(N'2020-12-16' AS Date))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[CarData]  WITH CHECK ADD  CONSTRAINT [FK_CarData_CarType] FOREIGN KEY([CarTypeID])
REFERENCES [dbo].[CarType] ([CarTypeID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CarData] CHECK CONSTRAINT [FK_CarData_CarType]
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD  CONSTRAINT [FK_Rentals_Branches] FOREIGN KEY([BranchStartID])
REFERENCES [dbo].[Branches] ([BranchID])
GO
ALTER TABLE [dbo].[Rentals] CHECK CONSTRAINT [FK_Rentals_Branches]
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD  CONSTRAINT [FK_Rentals_Branches1] FOREIGN KEY([BranchEndID])
REFERENCES [dbo].[Branches] ([BranchID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rentals] CHECK CONSTRAINT [FK_Rentals_Branches1]
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD  CONSTRAINT [FK_Rentals_CarData] FOREIGN KEY([CarDataID])
REFERENCES [dbo].[CarData] ([CarDataID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rentals] CHECK CONSTRAINT [FK_Rentals_CarData]
GO
ALTER TABLE [dbo].[Rentals]  WITH CHECK ADD  CONSTRAINT [FK_Rentals_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rentals] CHECK CONSTRAINT [FK_Rentals_Users]
GO
USE [master]
GO
ALTER DATABASE [CarRental] SET  READ_WRITE 
GO
