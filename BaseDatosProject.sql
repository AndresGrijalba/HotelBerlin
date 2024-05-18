USE [master]
GO
/****** Object:  Database [HotelBerlinDB]    Script Date: 17/05/2024 11:12:17 p. m. ******/
CREATE DATABASE [HotelBerlinDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HotelBerlinDB', FILENAME = N'C:\SQLData\HotelBerlinDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HotelBerlinDB_log', FILENAME = N'C:\SQLData\HotelBerlinDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [HotelBerlinDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HotelBerlinDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HotelBerlinDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HotelBerlinDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HotelBerlinDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HotelBerlinDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HotelBerlinDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [HotelBerlinDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HotelBerlinDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HotelBerlinDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HotelBerlinDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HotelBerlinDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HotelBerlinDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HotelBerlinDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HotelBerlinDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HotelBerlinDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HotelBerlinDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HotelBerlinDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HotelBerlinDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HotelBerlinDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HotelBerlinDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HotelBerlinDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HotelBerlinDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HotelBerlinDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HotelBerlinDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HotelBerlinDB] SET  MULTI_USER 
GO
ALTER DATABASE [HotelBerlinDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HotelBerlinDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HotelBerlinDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HotelBerlinDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HotelBerlinDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HotelBerlinDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HotelBerlinDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [HotelBerlinDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [HotelBerlinDB]
GO
/****** Object:  Table [dbo].[Table_Clientes]    Script Date: 17/05/2024 11:12:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_Clientes](
	[Cedula] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Telefono] [varchar](50) NOT NULL,
	[Correo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Table_Usuarios_Cedula] PRIMARY KEY CLUSTERED 
(
	[Cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_Reservas]    Script Date: 17/05/2024 11:12:18 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_Reservas](
	[id] [int] NOT NULL,
	[cedula_Cliente] [varchar](50) NULL,
	[id_Habitacion] [int] NULL,
	[fecha_Inicio] [date] NULL,
	[fecha_Fin] [date] NULL,
	[precio_Total] [decimal](18, 0) NULL,
	[cantidad_Noches] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Table_Clientes] ([Cedula], [Nombre], [Apellido], [Telefono], [Correo]) VALUES (N'1070590000', N'Kevin', N'Grijalba', N'302527935', N'kevingr2508@gmail.com')
INSERT [dbo].[Table_Clientes] ([Cedula], [Nombre], [Apellido], [Telefono], [Correo]) VALUES (N'23456754', N'Juan', N'Florez', N'12345678765', N'jflorez@gmail.com')
GO
ALTER TABLE [dbo].[Table_Reservas]  WITH CHECK ADD FOREIGN KEY([cedula_Cliente])
REFERENCES [dbo].[Table_Clientes] ([Cedula])
GO
USE [master]
GO
ALTER DATABASE [HotelBerlinDB] SET  READ_WRITE 
GO
