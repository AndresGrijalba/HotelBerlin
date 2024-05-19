USE [master]
GO
/****** Object:  Database [HotelBerlinDB]    Script Date: 19/05/2024 3:07:48 a. m. ******/
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
/****** Object:  Table [dbo].[clientes]    Script Date: 19/05/2024 3:07:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cedula] [varchar](50) NOT NULL,
	[nombres] [varchar](50) NOT NULL,
	[apellidos] [varchar](50) NOT NULL,
	[correo] [varchar](50) NOT NULL,
	[telefono] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[facturas]    Script Date: 19/05/2024 3:07:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[facturas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_reserva] [int] NOT NULL,
	[precio_noche] [decimal](18, 2) NOT NULL,
	[cantidad_noches] [int] NOT NULL,
	[total] [decimal](18, 2) NOT NULL,
	[fecha_emision] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[habitaciones]    Script Date: 19/05/2024 3:07:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[habitaciones](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[numero] [varchar](50) NOT NULL,
	[estado] [varchar](50) NOT NULL,
	[id_tipo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reservas]    Script Date: 19/05/2024 3:07:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reservas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_cliente] [int] NOT NULL,
	[id_habitacion] [int] NOT NULL,
	[fecha_inicio] [date] NOT NULL,
	[fecha_fin] [date] NOT NULL,
	[cantidad_noches] [int] NOT NULL,
	[precio_total] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_habitacion]    Script Date: 19/05/2024 3:07:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_habitacion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[precio_noche] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[clientes] ON 

INSERT [dbo].[clientes] ([id], [cedula], [nombres], [apellidos], [correo], [telefono]) VALUES (2, N'1070590000', N'Kevin', N'Grijalba', N'kevingr2508@gmail.com', N'3023527935')
INSERT [dbo].[clientes] ([id], [cedula], [nombres], [apellidos], [correo], [telefono]) VALUES (3, N'12345678', N'Juan', N'Tafuer', N'juandavidtafurrangel@gmail.com', N'3456789')
SET IDENTITY_INSERT [dbo].[clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[habitaciones] ON 

INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (2, N'201', N'1', 1)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (3, N'204', N'1', 1)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (4, N'205', N'0', 3)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (5, N'207', N'1', 2)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (6, N'208', N'0', 2)
SET IDENTITY_INSERT [dbo].[habitaciones] OFF
GO
SET IDENTITY_INSERT [dbo].[tipo_habitacion] ON 

INSERT [dbo].[tipo_habitacion] ([id], [nombre], [descripcion], [precio_noche]) VALUES (1, N'Individual', N'Habitación individual estándar', CAST(50000.00 AS Decimal(18, 2)))
INSERT [dbo].[tipo_habitacion] ([id], [nombre], [descripcion], [precio_noche]) VALUES (2, N'Doble', N'Habitación doble estándar', CAST(80000.00 AS Decimal(18, 2)))
INSERT [dbo].[tipo_habitacion] ([id], [nombre], [descripcion], [precio_noche]) VALUES (3, N'Suite', N'Suite de lujo con vista al mar', CAST(150000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[tipo_habitacion] OFF
GO
ALTER TABLE [dbo].[facturas]  WITH CHECK ADD FOREIGN KEY([id_reserva])
REFERENCES [dbo].[reservas] ([id])
GO
ALTER TABLE [dbo].[habitaciones]  WITH CHECK ADD FOREIGN KEY([id_tipo])
REFERENCES [dbo].[tipo_habitacion] ([id])
GO
ALTER TABLE [dbo].[reservas]  WITH CHECK ADD FOREIGN KEY([id_cliente])
REFERENCES [dbo].[clientes] ([id])
GO
ALTER TABLE [dbo].[reservas]  WITH CHECK ADD FOREIGN KEY([id_habitacion])
REFERENCES [dbo].[habitaciones] ([id])
GO
USE [master]
GO
ALTER DATABASE [HotelBerlinDB] SET  READ_WRITE 
GO
