USE [master]
GO

/****** Object:  Database [Docs]    Script Date: 07.02.2024 17:01:39 ******/
CREATE DATABASE [Docs]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Docs', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Docs.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Docs_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Docs_log.ldf' , SIZE = 139264KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Docs].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Docs] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Docs] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Docs] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Docs] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Docs] SET ARITHABORT OFF 
GO

ALTER DATABASE [Docs] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Docs] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Docs] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Docs] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Docs] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Docs] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Docs] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Docs] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Docs] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Docs] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Docs] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Docs] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Docs] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Docs] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Docs] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Docs] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Docs] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Docs] SET RECOVERY FULL 
GO

ALTER DATABASE [Docs] SET  MULTI_USER 
GO

ALTER DATABASE [Docs] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Docs] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Docs] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Docs] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Docs] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Docs] SET QUERY_STORE = OFF
GO

ALTER DATABASE [Docs] SET  READ_WRITE 
GO

USE [Docs]
GO

/****** Object:  Table [dbo].[Agreements]    Script Date: 07.02.2024 17:02:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Agreements](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](400) NULL,
	[NumDoc] [nvarchar](50) NULL,
	[Date] [date] NULL,
	[Status] [nvarchar](50) NULL,
	[Guid] [uniqueidentifier] NULL,
	[TotalSum] [money] NOT NULL,
 CONSTRAINT [PK_Agreements] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Agreements] ADD  CONSTRAINT [DF_Agreements_Guid]  DEFAULT (newid()) FOR [Guid]
GO

ALTER TABLE [dbo].[Agreements] ADD  CONSTRAINT [DF_Agreements_TotalSum]  DEFAULT ((0)) FOR [TotalSum]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Для связи с другими таблицами' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Agreements', @level2type=N'COLUMN',@level2name=N'Guid'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Итоговая сумма по ServicebyAgreements и PriceList' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Agreements', @level2type=N'COLUMN',@level2name=N'TotalSum'
GO




USE [Docs]
GO

/****** Object:  Table [dbo].[ClientEntity]    Script Date: 07.02.2024 17:02:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ClientEntity](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Address] [nvarchar](250) NULL,
	[Phone] [nvarchar](50) NULL,
	[INN] [nvarchar](20) NULL,
	[OGRN] [nvarchar](50) NULL,
	[Description] [nvarchar](250) NULL,
	[Guid] [uniqueidentifier] NULL,
 CONSTRAINT [PK_ClientFirms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ClientEntity] ADD  CONSTRAINT [DF_ClientEntity_Guid]  DEFAULT (newid()) FOR [Guid]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Описание' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ClientEntity', @level2type=N'COLUMN',@level2name=N'Description'
GO

USE [Docs]
GO

/****** Object:  Table [dbo].[ClientPersonal]    Script Date: 07.02.2024 17:03:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ClientPersonal](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Address] [nvarchar](150) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Guid] [uniqueidentifier] NULL,
	[ident_doc_name] [nvarchar](50) NULL,
	[ident_doc_number] [nvarchar](50) NULL,
	[ident_doc_date] [datetime] NULL,
	[ident_doc_issue] [nvarchar](510) NULL,
 CONSTRAINT [PK_ClientPersonal2] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ClientPersonal] ADD  CONSTRAINT [DF_ClientPersonal_Guid]  DEFAULT (newid()) FOR [Guid]
GO

ALTER TABLE [dbo].[ClientPersonal] ADD  CONSTRAINT [DF_ClientPersonal2_ident_doc_name]  DEFAULT (N'паспорт') FOR [ident_doc_name]
GO

ALTER TABLE [dbo].[ClientPersonal] ADD  CONSTRAINT [DF_ClientPersonal2_ident_doc_number]  DEFAULT (N'0000 12345000') FOR [ident_doc_number]
GO

ALTER TABLE [dbo].[ClientPersonal] ADD  CONSTRAINT [DF_ClientPersonal2_ident_doc_issue]  DEFAULT (N'указать  орган (РОВД г. Орла)') FOR [ident_doc_issue]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Имя' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ClientPersonal', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Адрес' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ClientPersonal', @level2type=N'COLUMN',@level2name=N'Address'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Телефон' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ClientPersonal', @level2type=N'COLUMN',@level2name=N'Phone'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Электронная почта' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ClientPersonal', @level2type=N'COLUMN',@level2name=N'Email'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Название документа' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ClientPersonal', @level2type=N'COLUMN',@level2name=N'ident_doc_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Дата выдачи' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ClientPersonal', @level2type=N'COLUMN',@level2name=N'ident_doc_date'
GO


USE [Docs]
GO

/****** Object:  Table [dbo].[Clients]    Script Date: 07.02.2024 17:03:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clients](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ClientTypeID] [bigint] NOT NULL,
	[LinkGuid] [uniqueidentifier] NOT NULL,
	[AgreementGuid] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Тип клиента 1-физик  2-ю/л:: таблица ClientPersonal / ClientEntiry' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clients', @level2type=N'COLUMN',@level2name=N'ClientTypeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Договор родитель' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clients', @level2type=N'COLUMN',@level2name=N'AgreementGuid'
GO

USE [Docs]
GO

/****** Object:  Table [dbo].[config]    Script Date: 07.02.2024 17:03:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[config](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[storage_path] [varchar](255) NULL,
 CONSTRAINT [PK_config] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[config] ADD  CONSTRAINT [DF_config_storage_path]  DEFAULT ('\\ASU-FURIV\DocGen\storage_docs') FOR [storage_path]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'для теста на своем компе' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'config', @level2type=N'COLUMN',@level2name=N'storage_path'
GO

USE [Docs]
GO

/****** Object:  Table [dbo].[PriceList]    Script Date: 07.02.2024 17:03:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PriceList](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[Service] [nvarchar](250) NOT NULL,
	[Price] [money] NOT NULL,
	[Date_start] [datetime] NOT NULL,
	[Date_end] [datetime] NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[Vat] [float] NOT NULL,
	[ClientTypeID] [int] NOT NULL,
	[Description] [nvarchar](2000) NOT NULL,
	[Title]  AS (([Service]+'.\r\n')+[Description]),
 CONSTRAINT [PK_PriceList] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PriceList] ADD  CONSTRAINT [DF_PriceList_Service]  DEFAULT (N'Услуга') FOR [Service]
GO

ALTER TABLE [dbo].[PriceList] ADD  CONSTRAINT [DF_PriceList_Price]  DEFAULT ((1000)) FOR [Price]
GO

ALTER TABLE [dbo].[PriceList] ADD  CONSTRAINT [DF_PriceList_Date_start]  DEFAULT (getdate()) FOR [Date_start]
GO

ALTER TABLE [dbo].[PriceList] ADD  CONSTRAINT [DF_PriceList_Date_end]  DEFAULT (getdate()+(365)) FOR [Date_end]
GO

ALTER TABLE [dbo].[PriceList] ADD  CONSTRAINT [DF_PriceList_Guid]  DEFAULT (newid()) FOR [Guid]
GO

ALTER TABLE [dbo].[PriceList] ADD  CONSTRAINT [DF_PriceList_Vat]  DEFAULT ((0.2)) FOR [Vat]
GO

ALTER TABLE [dbo].[PriceList] ADD  CONSTRAINT [DF_PriceList_ClientTypeID]  DEFAULT ((0)) FOR [ClientTypeID]
GO

ALTER TABLE [dbo].[PriceList] ADD  CONSTRAINT [DF_PriceList_Description]  DEFAULT (N'описание') FOR [Description]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'дата действия данной цены' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PriceList', @level2type=N'COLUMN',@level2name=N'Date_start'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ставка' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PriceList', @level2type=N'COLUMN',@level2name=N'Vat'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0- для всех 1-физик 2-юрик' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PriceList', @level2type=N'COLUMN',@level2name=N'ClientTypeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Вычисляемое поле' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PriceList', @level2type=N'COLUMN',@level2name=N'Title'
GO



USE [Docs]
GO

/****** Object:  Table [dbo].[ServiceByAgreements]    Script Date: 07.02.2024 17:04:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ServiceByAgreements](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Link_Agreement] [uniqueidentifier] NOT NULL,
	[Link_PriceList] [uniqueidentifier] NOT NULL,
	[Count] [int] NULL,
 CONSTRAINT [PK_ServiceByAgreements] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ServiceByAgreements] ADD  CONSTRAINT [DF_ServiceByAgreements_Count]  DEFAULT ((0)) FOR [Count]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'привязанный договор' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ServiceByAgreements', @level2type=N'COLUMN',@level2name=N'Link_Agreement'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'привязанная услуга из прайс листа' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ServiceByAgreements', @level2type=N'COLUMN',@level2name=N'Link_PriceList'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Кол-во услуг по прайсу' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ServiceByAgreements', @level2type=N'COLUMN',@level2name=N'Count'
GO

