USE [master]
GO
/****** Object:  Database [Microting]    Script Date: 17-01-2017 10:25:54 ******/
CREATE DATABASE [Microting]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Microting', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Microting.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 5120KB )
 LOG ON 
( NAME = N'Microting_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\Microting_log.ldf' , SIZE = 4096KB , MAXSIZE = 2048GB , FILEGROWTH = 2048KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Microting].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Microting] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Microting] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Microting] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Microting] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Microting] SET ARITHABORT OFF 
GO
ALTER DATABASE [Microting] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Microting] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Microting] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Microting] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Microting] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Microting] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Microting] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Microting] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Microting] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Microting] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Microting] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Microting] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Microting] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Microting] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Microting] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Microting] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Microting] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Microting] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Microting] SET  MULTI_USER 
GO
ALTER DATABASE [Microting] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Microting] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Microting] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Microting] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
USE [Microting]
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
USE [Microting]
GO
/****** Object:  Schema [microting]    Script Date: 17-01-2017 10:25:54 ******/
CREATE SCHEMA [microting]
GO
/****** Object:  Table [dbo].[cases]    Script Date: 17-01-2017 10:25:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cases](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[workflow_state] [varchar](255) NULL,
	[version] [int] NULL,
	[status] [int] NULL,
	[created_at] [datetime2](0) NULL,
	[updated_at] [datetime2](0) NULL,
	[done_at] [datetime2](0) NULL,
	[site_id] [int] NULL,
	[unit_id] [int] NULL,
	[done_by_user_id] [int] NULL,
	[check_list_id] [int] NULL,
	[type] [varchar](255) NULL,
	[microting_uid] [varchar](255) NULL,
	[microting_check_uid] [varchar](255) NULL,
	[case_uid] [varchar](255) NULL,
	[custom] [varchar](max) NULL,
 CONSTRAINT [PK_dbo.cases] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[check_list_sites]    Script Date: 17-01-2017 10:25:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[check_list_sites](
	[id] [int] IDENTITY(123,1) NOT NULL,
	[workflow_state] [varchar](255) NULL,
	[version] [int] NULL,
	[created_at] [datetime2](0) NULL,
	[updated_at] [datetime2](0) NULL,
	[site_id] [int] NULL,
	[check_list_id] [int] NULL,
	[microting_uid] [varchar](255) NULL,
	[last_check_id] [varchar](255) NULL,
 CONSTRAINT [PK_check_list_sites_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[check_list_values]    Script Date: 17-01-2017 10:25:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[check_list_values](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[workflow_state] [varchar](255) NULL,
	[version] [int] NULL,
	[status] [varchar](255) NULL,
	[created_at] [datetime2](0) NULL,
	[updated_at] [datetime2](0) NULL,
	[user_id] [int] NULL,
	[case_id] [int] NULL,
	[check_list_id] [int] NULL,
	[check_list_duplicate_id] [int] NULL,
 CONSTRAINT [PK_dbo.check_list_values] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[check_lists]    Script Date: 17-01-2017 10:25:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[check_lists](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[workflow_state] [varchar](255) NULL,
	[version] [int] NULL,
	[created_at] [datetime2](0) NULL,
	[updated_at] [datetime2](0) NULL,
	[label] [varchar](255) NULL,
	[description] [varchar](255) NULL,
	[custom] [varchar](max) NULL,
	[parent_id] [int] NULL,
	[repeated] [int] NULL,
	[display_index] [int] NULL,
	[case_type] [varchar](255) NULL,
	[folder_name] [varchar](255) NULL,
	[review_enabled] [smallint] NULL,
	[manual_sync] [smallint] NULL,
	[extra_fields_enabled] [smallint] NULL,
	[done_button_enabled] [smallint] NULL,
	[approval_enabled] [smallint] NULL,
	[multi_approval] [smallint] NULL,
	[fast_navigation] [smallint] NULL,
	[download_entities] [smallint] NULL,
 CONSTRAINT [PK_dbo.check_lists] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[data_uploaded]    Script Date: 17-01-2017 10:25:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[data_uploaded](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[workflow_state] [nvarchar](255) NULL,
	[version] [int] NULL,
	[created_at] [datetime2](0) NULL,
	[updated_at] [datetime2](0) NULL,
	[uploader_id] [int] NULL,
	[checksum] [nvarchar](255) NULL,
	[extension] [nvarchar](255) NULL,
	[current_file] [nvarchar](255) NULL,
	[uploader_type] [nvarchar](255) NULL,
	[file_location] [nvarchar](255) NULL,
	[file_name] [nvarchar](255) NULL,
	[expiration_date] [datetime2](0) NULL,
	[local] [smallint] NULL,
 CONSTRAINT [PK_dbo.uploaded_data] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[entity_groups]    Script Date: 17-01-2017 10:25:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[entity_groups](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[workflow_state] [varchar](255) NULL,
	[version] [int] NULL,
	[created_at] [datetime2](0) NULL,
	[updated_at] [datetime2](0) NULL,
	[microting_uid] [varchar](max) NULL,
	[name] [varchar](max) NULL,
	[type] [varchar](50) NULL,
 CONSTRAINT [PK_entity_groups_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[entity_items]    Script Date: 17-01-2017 10:25:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[entity_items](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[workflow_state] [varchar](255) NULL,
	[version] [int] NULL,
	[created_at] [datetime2](0) NULL,
	[updated_at] [datetime2](0) NULL,
	[entity_group_id] [varchar](max) NULL,
	[entity_item_uid] [varchar](50) NULL,
	[microting_uid] [varchar](max) NULL,
	[name] [varchar](max) NULL,
	[description] [varchar](max) NULL,
	[synced] [smallint] NULL,
 CONSTRAINT [PK_entity_items_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[field_types]    Script Date: 17-01-2017 10:25:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[field_types](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[field_type] [varchar](255) NULL,
	[description] [varchar](255) NULL,
 CONSTRAINT [PK_dbo.field_types] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[field_values]    Script Date: 17-01-2017 10:25:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[field_values](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[workflow_state] [varchar](255) NULL,
	[version] [int] NULL,
	[created_at] [datetime2](0) NULL,
	[updated_at] [datetime2](0) NULL,
	[done_at] [datetime2](0) NULL,
	[date] [datetime2](0) NULL,
	[user_id] [int] NULL,
	[case_id] [int] NULL,
	[field_id] [int] NULL,
	[check_list_id] [int] NULL,
	[check_list_duplicate_id] [int] NULL,
	[uploaded_data_id] [int] NULL,
	[value] [varchar](max) NULL,
	[latitude] [varchar](255) NULL,
	[longitude] [varchar](255) NULL,
	[altitude] [varchar](255) NULL,
	[heading] [varchar](255) NULL,
	[accuracy] [varchar](255) NULL,
 CONSTRAINT [PK_dbo.field_values] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[fields]    Script Date: 17-01-2017 10:25:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fields](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[workflow_state] [varchar](255) NULL,
	[version] [int] NULL,
	[created_at] [datetime2](0) NULL,
	[updated_at] [datetime2](0) NULL,
	[parent_field_id] [int] NULL,
	[check_list_id] [int] NULL,
	[field_type_id] [int] NULL,
	[mandatory] [smallint] NULL,
	[read_only] [smallint] NULL,
	[label] [varchar](255) NULL,
	[description] [varchar](255) NULL,
	[color] [varchar](255) NULL,
	[display_index] [int] NULL,
	[dummy] [smallint] NULL,
	[default_value] [varchar](255) NULL,
	[unit_name] [varchar](255) NULL,
	[min_value] [varchar](255) NULL,
	[max_value] [varchar](255) NULL,
	[max_length] [int] NULL,
	[decimal_count] [int] NULL,
	[multi] [int] NULL,
	[optional] [smallint] NULL,
	[selected] [smallint] NULL,
	[split_screen] [smallint] NULL,
	[geolocation_enabled] [smallint] NULL,
	[geolocation_forced] [smallint] NULL,
	[geolocation_hidden] [smallint] NULL,
	[stop_on_save] [smallint] NULL,
	[is_num] [smallint] NULL,
	[barcode_enabled] [smallint] NULL,
	[barcode_type] [varchar](255) NULL,
	[query_type] [varchar](255) NULL,
	[key_value_pair_list] [varchar](max) NULL,
	[custom] [varchar](max) NULL,
	[entity_group_id] [int] NULL,
 CONSTRAINT [PK_dbo.fields] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[notifications]    Script Date: 17-01-2017 10:25:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[notifications](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[workflow_state] [varchar](255) NULL,
	[created_at] [datetime2](0) NULL,
	[updated_at] [datetime2](0) NULL,
	[microting_uid] [varchar](255) NULL,
	[transmission] [varchar](max) NULL,
 CONSTRAINT [PK_dbo.notifications] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[outlook]    Script Date: 17-01-2017 10:25:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[outlook](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[workflow_state] [varchar](255) NULL,
	[version] [int] NULL,
	[created_at] [datetime2](0) NULL,
	[updated_at] [datetime2](0) NULL,
	[global_id] [varchar](max) NULL,
	[start_at] [datetime2](0) NULL,
	[expire_at] [datetime2](0) NULL,
	[duration] [int] NULL,
	[templat_id] [int] NULL,
	[subject] [varchar](255) NULL,
	[location] [varchar](255) NULL,
	[body] [varchar](max) NULL,
	[site_ids] [varchar](max) NULL,
	[title] [varchar](255) NULL,
	[info] [varchar](max) NULL,
	[custom_fields] [varchar](max) NULL,
	[microting_uid] [varchar](255) NULL,
	[connected] [smallint] NULL,
	[completed] [smallint] NULL,
 CONSTRAINT [PK_dbo.outlook] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sites]    Script Date: 17-01-2017 10:25:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sites](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[workflow_state] [nvarchar](255) NULL,
	[version] [int] NULL,
	[created_at] [datetime2](0) NULL,
	[updated_at] [datetime2](0) NULL,
	[microting_uid] [nvarchar](255) NULL,
	[name] [nvarchar](255) NULL,
 CONSTRAINT [PK_dbo.sites] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[version_cases]    Script Date: 17-01-2017 10:25:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[version_cases](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[case_id] [int] NULL,
	[workflow_state] [varchar](255) NULL,
	[version] [int] NULL,
	[status] [int] NULL,
	[created_at] [datetime2](0) NULL,
	[updated_at] [datetime2](0) NULL,
	[done_at] [datetime2](0) NULL,
	[site_id] [int] NULL,
	[unit_id] [int] NULL,
	[done_by_user_id] [int] NULL,
	[check_list_id] [int] NULL,
	[type] [varchar](255) NULL,
	[microting_uid] [varchar](255) NULL,
	[microting_check_uid] [varchar](255) NULL,
	[case_uid] [varchar](255) NULL,
	[custom] [varchar](max) NULL,
 CONSTRAINT [PK_dbo.version_case] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[version_check_list_sites]    Script Date: 17-01-2017 10:25:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[version_check_list_sites](
	[id] [int] IDENTITY(2801,1) NOT NULL,
	[check_list_site_id] [int] NULL,
	[workflow_state] [varchar](255) NULL,
	[version] [int] NULL,
	[created_at] [datetime2](0) NULL,
	[updated_at] [datetime2](0) NULL,
	[site_id] [int] NULL,
	[check_list_id] [int] NULL,
	[microting_uid] [varchar](255) NULL,
	[last_check_id] [varchar](255) NULL,
 CONSTRAINT [PK_check_list_site_versions_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[version_check_list_values]    Script Date: 17-01-2017 10:25:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[version_check_list_values](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[check_list_value_id] [int] NULL,
	[workflow_state] [varchar](255) NULL,
	[version] [int] NULL,
	[status] [varchar](255) NULL,
	[created_at] [datetime2](0) NULL,
	[updated_at] [datetime2](0) NULL,
	[user_id] [int] NULL,
	[case_id] [int] NULL,
	[check_list_id] [int] NULL,
	[check_list_duplicate_id] [int] NULL,
 CONSTRAINT [PK_dbo.check_list_value_versions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[version_check_lists]    Script Date: 17-01-2017 10:25:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[version_check_lists](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[check_list_id] [int] NULL,
	[workflow_state] [varchar](255) NULL,
	[version] [int] NULL,
	[created_at] [datetime2](0) NULL,
	[updated_at] [datetime2](0) NULL,
	[label] [varchar](255) NULL,
	[description] [varchar](255) NULL,
	[custom] [varchar](max) NULL,
	[parent_id] [int] NULL,
	[repeated] [int] NULL,
	[display_index] [int] NULL,
	[case_type] [varchar](255) NULL,
	[folder_name] [varchar](255) NULL,
	[review_enabled] [smallint] NULL,
	[manual_sync] [smallint] NULL,
	[extra_fields_enabled] [smallint] NULL,
	[done_button_enabled] [smallint] NULL,
	[approval_enabled] [smallint] NULL,
	[multi_approval] [smallint] NULL,
	[fast_navigation] [smallint] NULL,
	[download_entities] [smallint] NULL,
 CONSTRAINT [PK_dbo.check_list_versions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[version_data_uploaded]    Script Date: 17-01-2017 10:25:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[version_data_uploaded](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[data_uploaded_id] [int] NULL,
	[workflow_state] [nvarchar](255) NULL,
	[version] [int] NULL,
	[created_at] [datetime2](0) NULL,
	[updated_at] [datetime2](0) NULL,
	[uploader_id] [int] NULL,
	[checksum] [nvarchar](255) NULL,
	[extension] [nvarchar](255) NULL,
	[current_file] [nvarchar](255) NULL,
	[uploader_type] [nvarchar](255) NULL,
	[file_location] [nvarchar](255) NULL,
	[file_name] [nvarchar](255) NULL,
	[expiration_date] [datetime2](0) NULL,
	[local] [smallint] NULL,
 CONSTRAINT [PK_dbo.uploaded_data_versions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[version_entity_groups]    Script Date: 17-01-2017 10:25:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[version_entity_groups](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[entity_group_id] [int] NOT NULL,
	[workflow_state] [varchar](255) NULL,
	[version] [int] NULL,
	[created_at] [datetime2](0) NULL,
	[updated_at] [datetime2](0) NULL,
	[microting_uid] [varchar](max) NULL,
	[name] [varchar](max) NULL,
	[type] [varchar](50) NULL,
 CONSTRAINT [PK_entity_group_versions_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[version_entity_items]    Script Date: 17-01-2017 10:25:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[version_entity_items](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[entity_items_id] [int] NOT NULL,
	[workflow_state] [varchar](255) NULL,
	[version] [int] NULL,
	[created_at] [datetime2](0) NULL,
	[updated_at] [datetime2](0) NULL,
	[entity_group_id] [varchar](max) NULL,
	[entity_item_uid] [varchar](50) NULL,
	[microting_uid] [varchar](max) NULL,
	[name] [varchar](max) NULL,
	[description] [varchar](max) NULL,
	[synced] [smallint] NULL,
 CONSTRAINT [PK_entity_item_versions_id] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[version_field_values]    Script Date: 17-01-2017 10:25:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[version_field_values](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[field_value_id] [int] NULL,
	[workflow_state] [varchar](255) NULL,
	[version] [int] NULL,
	[created_at] [datetime2](0) NULL,
	[updated_at] [datetime2](0) NULL,
	[done_at] [datetime2](0) NULL,
	[date] [datetime2](0) NULL,
	[user_id] [int] NULL,
	[case_id] [int] NULL,
	[field_id] [int] NULL,
	[check_list_id] [int] NULL,
	[check_list_duplicate_id] [int] NULL,
	[uploaded_data_id] [int] NULL,
	[value] [varchar](max) NULL,
	[latitude] [varchar](255) NULL,
	[longitude] [varchar](255) NULL,
	[altitude] [varchar](255) NULL,
	[heading] [varchar](255) NULL,
	[accuracy] [varchar](255) NULL,
 CONSTRAINT [PK_dbo.field_value_versions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[version_fields]    Script Date: 17-01-2017 10:25:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[version_fields](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[field_id] [int] NULL,
	[workflow_state] [varchar](255) NULL,
	[version] [int] NULL,
	[created_at] [datetime2](0) NULL,
	[updated_at] [datetime2](0) NULL,
	[parent_field_id] [int] NULL,
	[check_list_id] [int] NULL,
	[field_type_id] [int] NULL,
	[mandatory] [smallint] NULL,
	[read_only] [smallint] NULL,
	[label] [varchar](255) NULL,
	[description] [varchar](255) NULL,
	[color] [varchar](255) NULL,
	[display_index] [int] NULL,
	[dummy] [smallint] NULL,
	[default_value] [varchar](255) NULL,
	[unit_name] [varchar](255) NULL,
	[min_value] [varchar](255) NULL,
	[max_value] [varchar](255) NULL,
	[max_length] [int] NULL,
	[decimal_count] [int] NULL,
	[multi] [int] NULL,
	[optional] [smallint] NULL,
	[selected] [smallint] NULL,
	[split_screen] [smallint] NULL,
	[geolocation_enabled] [smallint] NULL,
	[geolocation_forced] [smallint] NULL,
	[geolocation_hidden] [smallint] NULL,
	[stop_on_save] [smallint] NULL,
	[is_num] [smallint] NULL,
	[barcode_enabled] [smallint] NULL,
	[barcode_type] [varchar](255) NULL,
	[query_type] [varchar](255) NULL,
	[key_value_pair_list] [varchar](max) NULL,
	[custom] [varchar](max) NULL,
	[entity_group_id] [int] NULL,
 CONSTRAINT [PK_dbo.version_fields] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[version_sites]    Script Date: 17-01-2017 10:25:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[version_sites](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[site_id] [int] NULL,
	[workflow_state] [nvarchar](255) NULL,
	[version] [int] NULL,
	[created_at] [datetime2](0) NULL,
	[updated_at] [datetime2](0) NULL,
	[microting_uid] [nvarchar](255) NULL,
	[name] [nvarchar](255) NULL,
 CONSTRAINT [PK_dbo.site_versions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[field_types] ON 

INSERT [dbo].[field_types] ([id], [field_type], [description]) VALUES (1, N'Text', N'Simple text field')
INSERT [dbo].[field_types] ([id], [field_type], [description]) VALUES (2, N'Number', N'Simple number field')
INSERT [dbo].[field_types] ([id], [field_type], [description]) VALUES (3, N'None', N'Simple text to be displayed')
INSERT [dbo].[field_types] ([id], [field_type], [description]) VALUES (4, N'CheckBox', N'Simple check box field')
INSERT [dbo].[field_types] ([id], [field_type], [description]) VALUES (5, N'Picture', N'Simple picture field')
INSERT [dbo].[field_types] ([id], [field_type], [description]) VALUES (6, N'Audio', N'Simple audio field')
INSERT [dbo].[field_types] ([id], [field_type], [description]) VALUES (7, N'Movie', N'Simple movie field')
INSERT [dbo].[field_types] ([id], [field_type], [description]) VALUES (8, N'SingleSelect', N'Single selection list')
INSERT [dbo].[field_types] ([id], [field_type], [description]) VALUES (9, N'Comment', N'Simple comment field')
INSERT [dbo].[field_types] ([id], [field_type], [description]) VALUES (10, N'MultiSelect', N'Simple multi select list')
INSERT [dbo].[field_types] ([id], [field_type], [description]) VALUES (11, N'Date', N'Date selection')
INSERT [dbo].[field_types] ([id], [field_type], [description]) VALUES (12, N'Signature', N'Simple signature field')
INSERT [dbo].[field_types] ([id], [field_type], [description]) VALUES (13, N'Timer', N'Simple timer field')
INSERT [dbo].[field_types] ([id], [field_type], [description]) VALUES (14, N'EntitySearch', N'Searchable items field')
INSERT [dbo].[field_types] ([id], [field_type], [description]) VALUES (15, N'EntitySelect', N'Autofilled single selection list')
INSERT [dbo].[field_types] ([id], [field_type], [description]) VALUES (16, N'ShowPdf', N'Show PDF')
INSERT [dbo].[field_types] ([id], [field_type], [description]) VALUES (17, N'FieldGroup', N'Field group')
INSERT [dbo].[field_types] ([id], [field_type], [description]) VALUES (18, N'SaveButton', N'Save eForm')
SET IDENTITY_INSERT [dbo].[field_types] OFF
USE [master]
GO
ALTER DATABASE [Microting] SET  READ_WRITE 
GO
