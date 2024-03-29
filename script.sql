USE [master]
GO
/****** Object:  Database [DBsubasta]    Script Date: 17/08/2019 3:51:02 p. m. ******/
CREATE DATABASE [DBsubasta]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBsubasta', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DBsubasta.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBsubasta_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DBsubasta_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DBsubasta] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBsubasta].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBsubasta] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBsubasta] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBsubasta] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBsubasta] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBsubasta] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBsubasta] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBsubasta] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBsubasta] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBsubasta] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBsubasta] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBsubasta] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBsubasta] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBsubasta] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBsubasta] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBsubasta] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBsubasta] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBsubasta] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBsubasta] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBsubasta] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBsubasta] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBsubasta] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBsubasta] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBsubasta] SET RECOVERY FULL 
GO
ALTER DATABASE [DBsubasta] SET  MULTI_USER 
GO
ALTER DATABASE [DBsubasta] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBsubasta] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBsubasta] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBsubasta] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBsubasta] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DBsubasta', N'ON'
GO
ALTER DATABASE [DBsubasta] SET QUERY_STORE = OFF
GO
USE [DBsubasta]
GO
/****** Object:  Table [dbo].[Articulo]    Script Date: 17/08/2019 3:51:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulo](
	[IDarticulo] [int] IDENTITY(1,1) NOT NULL,
	[IDvendedor] [int] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[FechaIngreso] [date] NOT NULL,
	[FechaSalida] [date] NULL,
 CONSTRAINT [PK_Articulo] PRIMARY KEY CLUSTERED 
(
	[IDarticulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comprador]    Script Date: 17/08/2019 3:51:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comprador](
	[IDusuario] [int] NOT NULL,
	[NombreUsuario] [varchar](50) NOT NULL,
	[ContraseñaUsuario] [varchar](50) NOT NULL,
	[IDrol] [int] NOT NULL,
 CONSTRAINT [PK_Comprador] PRIMARY KEY CLUSTERED 
(
	[IDusuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 17/08/2019 3:51:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Descripcion] [varchar](50) NOT NULL,
	[IDrol] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[IDrol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolesXUsuario]    Script Date: 17/08/2019 3:51:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolesXUsuario](
	[IDusuario] [int] NOT NULL,
	[IDrol] [int] NOT NULL,
 CONSTRAINT [PK_RolesXUsuario] PRIMARY KEY CLUSTERED 
(
	[IDusuario] ASC,
	[IDrol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 17/08/2019 3:51:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[DocNumero] [int] NOT NULL,
	[IDusuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[RolActual] [int] NOT NULL,
 CONSTRAINT [PK_Usuarios_1] PRIMARY KEY CLUSTERED 
(
	[IDusuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vendedor]    Script Date: 17/08/2019 3:51:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendedor](
	[IDusuario] [int] NOT NULL,
	[NombreUsuario] [varchar](50) NOT NULL,
	[ContrasenaUsuario] [varchar](50) NOT NULL,
	[IDrol] [int] NULL,
 CONSTRAINT [PK_Vendedor] PRIMARY KEY CLUSTERED 
(
	[IDusuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VentaArticulo]    Script Date: 17/08/2019 3:51:02 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentaArticulo](
	[IDarticulo] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[IDcomprador] [int] NOT NULL,
	[PrecioSalida] [money] NOT NULL,
	[PrecioVenta] [money] NOT NULL,
 CONSTRAINT [PK_VentaArticulo] PRIMARY KEY CLUSTERED 
(
	[IDarticulo] ASC,
	[Fecha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Articulo]  WITH CHECK ADD  CONSTRAINT [FK_Articulo_Vendedor] FOREIGN KEY([IDvendedor])
REFERENCES [dbo].[Vendedor] ([IDusuario])
GO
ALTER TABLE [dbo].[Articulo] CHECK CONSTRAINT [FK_Articulo_Vendedor]
GO
ALTER TABLE [dbo].[Comprador]  WITH CHECK ADD  CONSTRAINT [FK_Comprador_Roles] FOREIGN KEY([IDrol])
REFERENCES [dbo].[Roles] ([IDrol])
GO
ALTER TABLE [dbo].[Comprador] CHECK CONSTRAINT [FK_Comprador_Roles]
GO
ALTER TABLE [dbo].[Comprador]  WITH CHECK ADD  CONSTRAINT [FK_Comprador_Usuarios] FOREIGN KEY([IDusuario])
REFERENCES [dbo].[Usuarios] ([IDusuario])
GO
ALTER TABLE [dbo].[Comprador] CHECK CONSTRAINT [FK_Comprador_Usuarios]
GO
ALTER TABLE [dbo].[RolesXUsuario]  WITH CHECK ADD  CONSTRAINT [FK_RolesXUsuario_Roles] FOREIGN KEY([IDrol])
REFERENCES [dbo].[Roles] ([IDrol])
GO
ALTER TABLE [dbo].[RolesXUsuario] CHECK CONSTRAINT [FK_RolesXUsuario_Roles]
GO
ALTER TABLE [dbo].[RolesXUsuario]  WITH CHECK ADD  CONSTRAINT [FK_RolesXUsuario_Usuarios] FOREIGN KEY([IDusuario])
REFERENCES [dbo].[Usuarios] ([IDusuario])
GO
ALTER TABLE [dbo].[RolesXUsuario] CHECK CONSTRAINT [FK_RolesXUsuario_Usuarios]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY([RolActual])
REFERENCES [dbo].[Roles] ([IDrol])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Roles]
GO
ALTER TABLE [dbo].[Vendedor]  WITH CHECK ADD  CONSTRAINT [FK_Vendedor_Roles] FOREIGN KEY([IDrol])
REFERENCES [dbo].[Roles] ([IDrol])
GO
ALTER TABLE [dbo].[Vendedor] CHECK CONSTRAINT [FK_Vendedor_Roles]
GO
ALTER TABLE [dbo].[Vendedor]  WITH CHECK ADD  CONSTRAINT [FK_Vendedor_Usuarios] FOREIGN KEY([IDusuario])
REFERENCES [dbo].[Usuarios] ([IDusuario])
GO
ALTER TABLE [dbo].[Vendedor] CHECK CONSTRAINT [FK_Vendedor_Usuarios]
GO
ALTER TABLE [dbo].[VentaArticulo]  WITH CHECK ADD  CONSTRAINT [FK_VentaArticulo_Articulo] FOREIGN KEY([IDarticulo])
REFERENCES [dbo].[Articulo] ([IDarticulo])
GO
ALTER TABLE [dbo].[VentaArticulo] CHECK CONSTRAINT [FK_VentaArticulo_Articulo]
GO
ALTER TABLE [dbo].[VentaArticulo]  WITH CHECK ADD  CONSTRAINT [FK_VentaArticulo_Comprador] FOREIGN KEY([IDcomprador])
REFERENCES [dbo].[Comprador] ([IDusuario])
GO
ALTER TABLE [dbo].[VentaArticulo] CHECK CONSTRAINT [FK_VentaArticulo_Comprador]
GO
USE [master]
GO
ALTER DATABASE [DBsubasta] SET  READ_WRITE 
GO
