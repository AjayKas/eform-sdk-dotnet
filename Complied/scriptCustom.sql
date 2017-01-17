USE [master]
GO
/****** Object:  Database [MicrotingCustom]    Script Date: 17-01-2017 10:25:09 ******/
CREATE DATABASE [MicrotingCustom]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MicrotingCustom', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\MicrotingCustom.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 4096KB )
 LOG ON 
( NAME = N'MicrotingCustom_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\MicrotingCustom_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 2048KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MicrotingCustom].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MicrotingCustom] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MicrotingCustom] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MicrotingCustom] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MicrotingCustom] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MicrotingCustom] SET ARITHABORT OFF 
GO
ALTER DATABASE [MicrotingCustom] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MicrotingCustom] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MicrotingCustom] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MicrotingCustom] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MicrotingCustom] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MicrotingCustom] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MicrotingCustom] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MicrotingCustom] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MicrotingCustom] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MicrotingCustom] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MicrotingCustom] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MicrotingCustom] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MicrotingCustom] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MicrotingCustom] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MicrotingCustom] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MicrotingCustom] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MicrotingCustom] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MicrotingCustom] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MicrotingCustom] SET  MULTI_USER 
GO
ALTER DATABASE [MicrotingCustom] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MicrotingCustom] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MicrotingCustom] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MicrotingCustom] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
USE [MicrotingCustom]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [MicrotingCustom]
GO
/****** Object:  Table [dbo].[input_containers]    Script Date: 17-01-2017 10:25:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[input_containers](
	[id] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](max) NULL,
 CONSTRAINT [PK_input_containers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[input_factions]    Script Date: 17-01-2017 10:25:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[input_factions](
	[id] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](max) NULL,
 CONSTRAINT [PK_input_factions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[input_locations]    Script Date: 17-01-2017 10:25:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[input_locations](
	[id] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](max) NULL,
 CONSTRAINT [PK_input_locations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sites]    Script Date: 17-01-2017 10:25:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sites](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[area] [varchar](50) NOT NULL,
	[type] [varchar](50) NOT NULL,
	[site_id] [int] NOT NULL,
 CONSTRAINT [PK_sites] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[variable]    Script Date: 17-01-2017 10:25:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[variable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[value] [varchar](max) NULL,
 CONSTRAINT [PK_reference_table] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[workers]    Script Date: 17-01-2017 10:25:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[workers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[site_id] [int] NOT NULL,
	[location] [varchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[phone] [varchar](50) NOT NULL,
 CONSTRAINT [PK_workers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[input_containers] ([id], [name], [description]) VALUES (42, N'Container A', N'')
INSERT [dbo].[input_containers] ([id], [name], [description]) VALUES (43, N'Container B', N'')
INSERT [dbo].[input_containers] ([id], [name], [description]) VALUES (44, N'Container C', N'')
INSERT [dbo].[input_containers] ([id], [name], [description]) VALUES (45, N'Container D', N'')
INSERT [dbo].[input_containers] ([id], [name], [description]) VALUES (46, N'Container E', N'')
INSERT [dbo].[input_factions] ([id], [name], [description]) VALUES (41, N'Faction A', N'd')
INSERT [dbo].[input_factions] ([id], [name], [description]) VALUES (42, N'Faction B', N'd')
INSERT [dbo].[input_factions] ([id], [name], [description]) VALUES (44, N'Faction C', N'd')
INSERT [dbo].[input_locations] ([id], [name], [description]) VALUES (61, N'Nyborg', N'desc')
INSERT [dbo].[input_locations] ([id], [name], [description]) VALUES (62, N'Odense', N'desc')
INSERT [dbo].[input_locations] ([id], [name], [description]) VALUES (63, N'Svendborg', N'desc')
SET IDENTITY_INSERT [dbo].[sites] ON 

INSERT [dbo].[sites] ([id], [area], [type], [site_id]) VALUES (2, N'test', N'ShippingAgents', 1311)
INSERT [dbo].[sites] ([id], [area], [type], [site_id]) VALUES (4, N'test', N'Workers', 1312)
INSERT [dbo].[sites] ([id], [area], [type], [site_id]) VALUES (9, N'test', N'ShippingAgents', 1313)
INSERT [dbo].[sites] ([id], [area], [type], [site_id]) VALUES (10, N'test', N'Workers', 1314)
SET IDENTITY_INSERT [dbo].[sites] OFF
SET IDENTITY_INSERT [dbo].[variable] ON 

INSERT [dbo].[variable] ([id], [name], [value]) VALUES (2, N'step1', N'1')
INSERT [dbo].[variable] ([id], [name], [value]) VALUES (3, N'step2', N'3')
INSERT [dbo].[variable] ([id], [name], [value]) VALUES (4, N'step3', N'5')
INSERT [dbo].[variable] ([id], [name], [value]) VALUES (5, N'step3b', N'7')
INSERT [dbo].[variable] ([id], [name], [value]) VALUES (6, N'step4', N'9')
INSERT [dbo].[variable] ([id], [name], [value]) VALUES (8, N'container', N'13099')
INSERT [dbo].[variable] ([id], [name], [value]) VALUES (9, N'faction', N'234')
INSERT [dbo].[variable] ([id], [name], [value]) VALUES (10, N'location', N'235')
INSERT [dbo].[variable] ([id], [name], [value]) VALUES (11, N'synced', N'true')
INSERT [dbo].[variable] ([id], [name], [value]) VALUES (12, N'setup_done', N'true')
SET IDENTITY_INSERT [dbo].[variable] OFF
SET IDENTITY_INSERT [dbo].[workers] ON 

INSERT [dbo].[workers] ([id], [site_id], [location], [name], [phone]) VALUES (1, 830, N'Nyborg', N'Henrik', N'12345678')
INSERT [dbo].[workers] ([id], [site_id], [location], [name], [phone]) VALUES (2, 0, N'NA', N'NA', N'NA')
INSERT [dbo].[workers] ([id], [site_id], [location], [name], [phone]) VALUES (3, 744, N'Nyborg', N'Daniel', N'87654321')
INSERT [dbo].[workers] ([id], [site_id], [location], [name], [phone]) VALUES (4, 139, N'Nyborg', N'Daniel', N'87658765')
SET IDENTITY_INSERT [dbo].[workers] OFF
USE [master]
GO
ALTER DATABASE [MicrotingCustom] SET  READ_WRITE 
GO
