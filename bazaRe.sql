USE [master]
GO
/****** Object:  Database [BazaRe]    Script Date: 01/05/2023 19:02:44 ******/
CREATE DATABASE [BazaRe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BazaRe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BazaRe.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BazaRe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BazaRe_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BazaRe] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BazaRe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BazaRe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BazaRe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BazaRe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BazaRe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BazaRe] SET ARITHABORT OFF 
GO
ALTER DATABASE [BazaRe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BazaRe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BazaRe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BazaRe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BazaRe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BazaRe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BazaRe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BazaRe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BazaRe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BazaRe] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BazaRe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BazaRe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BazaRe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BazaRe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BazaRe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BazaRe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BazaRe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BazaRe] SET RECOVERY FULL 
GO
ALTER DATABASE [BazaRe] SET  MULTI_USER 
GO
ALTER DATABASE [BazaRe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BazaRe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BazaRe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BazaRe] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BazaRe] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BazaRe] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BazaRe', N'ON'
GO
ALTER DATABASE [BazaRe] SET QUERY_STORE = OFF
GO
USE [BazaRe]
GO
/****** Object:  Table [dbo].[Klasa]    Script Date: 01/05/2023 19:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Klasa](
	[Emri] [nvarchar](50) NOT NULL,
	[Kapaciteti] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DataKrijimit] [datetime] NOT NULL,
	[DataNdryshimit] [datetime] NOT NULL,
 CONSTRAINT [PK_Klasa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lendet]    Script Date: 01/05/2023 19:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lendet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Emri] [nvarchar](50) NOT NULL,
	[KlasaIdi] [int] NOT NULL,
	[DataKrijimit] [datetime] NOT NULL,
	[DataNdryshimit] [datetime] NOT NULL,
 CONSTRAINT [PK_Lendet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LendetDheStudentet]    Script Date: 01/05/2023 19:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LendetDheStudentet](
	[IdEStudentit] [int] NOT NULL,
	[IdELendes] [int] NOT NULL,
 CONSTRAINT [PK_LendetEStudentit] PRIMARY KEY CLUSTERED 
(
	[IdEStudentit] ASC,
	[IdELendes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Studenti]    Script Date: 01/05/2023 19:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Studenti](
	[Emri] [nvarchar](50) NOT NULL,
	[Mosha] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IndeksNumer] [nvarchar](50) NOT NULL,
	[DataKrijimit] [datetime] NOT NULL,
	[DataNdryshimit] [datetime] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Fjalkalimi] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_Studenti_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Klasa] ON 

INSERT [dbo].[Klasa] ([Emri], [Kapaciteti], [Id], [DataKrijimit], [DataNdryshimit]) VALUES (N'Dhoma Nji', 30, 1, CAST(N'2022-12-12T00:00:00.000' AS DateTime), CAST(N'2022-12-12T00:00:00.000' AS DateTime))
INSERT [dbo].[Klasa] ([Emri], [Kapaciteti], [Id], [DataKrijimit], [DataNdryshimit]) VALUES (N'Dhoma Dy', 50, 2, CAST(N'2022-12-12T00:00:00.000' AS DateTime), CAST(N'2022-12-12T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Klasa] OFF
GO
SET IDENTITY_INSERT [dbo].[Lendet] ON 

INSERT [dbo].[Lendet] ([Id], [Emri], [KlasaIdi], [DataKrijimit], [DataNdryshimit]) VALUES (2, N'C sharp kursi', 2, CAST(N'2023-02-12T00:00:00.000' AS DateTime), CAST(N'2023-04-07T00:00:00.000' AS DateTime))
INSERT [dbo].[Lendet] ([Id], [Emri], [KlasaIdi], [DataKrijimit], [DataNdryshimit]) VALUES (4, N'Python', 1, CAST(N'2023-03-12T00:00:00.000' AS DateTime), CAST(N'2023-04-05T00:00:00.000' AS DateTime))
INSERT [dbo].[Lendet] ([Id], [Emri], [KlasaIdi], [DataKrijimit], [DataNdryshimit]) VALUES (5, N'PHP', 1, CAST(N'2023-02-12T00:00:00.000' AS DateTime), CAST(N'2023-03-12T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Lendet] OFF
GO
INSERT [dbo].[LendetDheStudentet] ([IdEStudentit], [IdELendes]) VALUES (1, 4)
INSERT [dbo].[LendetDheStudentet] ([IdEStudentit], [IdELendes]) VALUES (1, 5)
INSERT [dbo].[LendetDheStudentet] ([IdEStudentit], [IdELendes]) VALUES (2, 2)
INSERT [dbo].[LendetDheStudentet] ([IdEStudentit], [IdELendes]) VALUES (2, 5)
INSERT [dbo].[LendetDheStudentet] ([IdEStudentit], [IdELendes]) VALUES (3, 4)
INSERT [dbo].[LendetDheStudentet] ([IdEStudentit], [IdELendes]) VALUES (4, 2)
INSERT [dbo].[LendetDheStudentet] ([IdEStudentit], [IdELendes]) VALUES (4, 4)
INSERT [dbo].[LendetDheStudentet] ([IdEStudentit], [IdELendes]) VALUES (4, 5)
GO
SET IDENTITY_INSERT [dbo].[Studenti] ON 

INSERT [dbo].[Studenti] ([Emri], [Mosha], [Id], [IndeksNumer], [DataKrijimit], [DataNdryshimit], [Email], [Fjalkalimi]) VALUES (N'Arjan', 34, 1, N'ad1413', CAST(N'2008-09-05T00:00:00.000' AS DateTime), CAST(N'2011-06-23T00:00:00.000' AS DateTime), N'a.dalipi@live.com', N'$2a$10$vP2Rm6SGQqFWsLxGCnRXjOZD88Yp5Jkmsqx9FLTTMVuEO0lBjJVKO')
INSERT [dbo].[Studenti] ([Emri], [Mosha], [Id], [IndeksNumer], [DataKrijimit], [DataNdryshimit], [Email], [Fjalkalimi]) VALUES (N'Gezim', 23, 2, N'gg2456', CAST(N'2010-04-23T00:00:00.000' AS DateTime), CAST(N'2012-08-25T00:00:00.000' AS DateTime), N'g.xim@live.com', N'$2a$10$vP2Rm6SGQqFWsLxGCnRXjOZD88Yp5Jkmsqx9FLTTMVuEO0lBjJVKO')
INSERT [dbo].[Studenti] ([Emri], [Mosha], [Id], [IndeksNumer], [DataKrijimit], [DataNdryshimit], [Email], [Fjalkalimi]) VALUES (N'Fitim', 25, 3, N'fg2856', CAST(N'2010-04-23T00:00:00.000' AS DateTime), CAST(N'2012-08-25T00:00:00.000' AS DateTime), N'f.tim@gmail.com', N'$2a$10$vP2Rm6SGQqFWsLxGCnRXjOZD88Yp5Jkmsqx9FLTTMVuEO0lBjJVKO')
INSERT [dbo].[Studenti] ([Emri], [Mosha], [Id], [IndeksNumer], [DataKrijimit], [DataNdryshimit], [Email], [Fjalkalimi]) VALUES (N'Artan', 31, 4, N'ag1311', CAST(N'2008-09-05T00:00:00.000' AS DateTime), CAST(N'2011-06-23T00:00:00.000' AS DateTime), N'a.ajr@gmail.com', N'$2a$10$vP2Rm6SGQqFWsLxGCnRXjOZD88Yp5Jkmsqx9FLTTMVuEO0lBjJVKO')
SET IDENTITY_INSERT [dbo].[Studenti] OFF
GO
ALTER TABLE [dbo].[Studenti] ADD  CONSTRAINT [DF_Studenti_Email]  DEFAULT (N'test') FOR [Email]
GO
ALTER TABLE [dbo].[Studenti] ADD  CONSTRAINT [DF_Studenti_Fjalkalimi]  DEFAULT (N'test') FOR [Fjalkalimi]
GO
ALTER TABLE [dbo].[Lendet]  WITH CHECK ADD  CONSTRAINT [FK_Lendet_Klasa] FOREIGN KEY([KlasaIdi])
REFERENCES [dbo].[Klasa] ([Id])
GO
ALTER TABLE [dbo].[Lendet] CHECK CONSTRAINT [FK_Lendet_Klasa]
GO
ALTER TABLE [dbo].[LendetDheStudentet]  WITH CHECK ADD  CONSTRAINT [FK_LendetDheStudentet_Lendet] FOREIGN KEY([IdELendes])
REFERENCES [dbo].[Lendet] ([Id])
GO
ALTER TABLE [dbo].[LendetDheStudentet] CHECK CONSTRAINT [FK_LendetDheStudentet_Lendet]
GO
ALTER TABLE [dbo].[LendetDheStudentet]  WITH CHECK ADD  CONSTRAINT [FK_LendetDheStudentet_Studenti] FOREIGN KEY([IdEStudentit])
REFERENCES [dbo].[Studenti] ([Id])
GO
ALTER TABLE [dbo].[LendetDheStudentet] CHECK CONSTRAINT [FK_LendetDheStudentet_Studenti]
GO
USE [master]
GO
ALTER DATABASE [BazaRe] SET  READ_WRITE 
GO
