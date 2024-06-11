USE [master]
GO
/****** Object:  Database [HotelBerlinDB]    Script Date: 10/06/2024 7:06:56 p. m. ******/
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
/****** Object:  Table [dbo].[clientes]    Script Date: 10/06/2024 7:06:56 p. m. ******/
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
/****** Object:  Table [dbo].[habitaciones]    Script Date: 10/06/2024 7:06:57 p. m. ******/
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
/****** Object:  Table [dbo].[reservas]    Script Date: 10/06/2024 7:06:57 p. m. ******/
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
	[fecha_registro] [datetime] NOT NULL,
	[estado_reserva] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_habitacion]    Script Date: 10/06/2024 7:06:57 p. m. ******/
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
/****** Object:  View [dbo].[VistaTotalPrecio]    Script Date: 10/06/2024 7:06:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VistaTotalPrecio]
AS
SELECT dbo.clientes.cedula, dbo.clientes.nombres, dbo.clientes.apellidos, dbo.reservas.fecha_inicio, dbo.reservas.fecha_fin, dbo.reservas.cantidad_noches, dbo.tipo_habitacion.precio_noche, 
             dbo.tipo_habitacion.precio_noche * dbo.reservas.cantidad_noches AS totalapagar
FROM   dbo.tipo_habitacion INNER JOIN
             dbo.habitaciones ON dbo.tipo_habitacion.id = dbo.habitaciones.id_tipo AND dbo.tipo_habitacion.id = dbo.habitaciones.id_tipo INNER JOIN
             dbo.reservas ON dbo.habitaciones.id = dbo.reservas.id_habitacion AND dbo.habitaciones.id = dbo.reservas.id_habitacion INNER JOIN
             dbo.clientes ON dbo.reservas.id_cliente = dbo.clientes.id AND dbo.reservas.id_cliente = dbo.clientes.id
GO
/****** Object:  Table [dbo].[facturas]    Script Date: 10/06/2024 7:06:57 p. m. ******/
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
	[fecha_emision] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[clientes] ON 

INSERT [dbo].[clientes] ([id], [cedula], [nombres], [apellidos], [correo], [telefono]) VALUES (1, N'1070590000', N'Kevin Andres', N'Grijalba Roa', N'kevingr2508@gmail.com', N'3023527935')
INSERT [dbo].[clientes] ([id], [cedula], [nombres], [apellidos], [correo], [telefono]) VALUES (1002, N'1067596337', N'Juan Fernando', N'Florez Silgado', N'jferxff@gmail.com', N'3045280090')
INSERT [dbo].[clientes] ([id], [cedula], [nombres], [apellidos], [correo], [telefono]) VALUES (1004, N'1067595992', N'Rafael Jose', N'Barriga Mejia', N'rafaeljosebarrigamejia2005@gmail.com', N'3217333258')
INSERT [dbo].[clientes] ([id], [cedula], [nombres], [apellidos], [correo], [telefono]) VALUES (1005, N'1082240892', N'Juan Diego', N'Ochoa Orozco', N'a.juandiego235@gmail.com', N'3246843148')
INSERT [dbo].[clientes] ([id], [cedula], [nombres], [apellidos], [correo], [telefono]) VALUES (1006, N'1074811531', N'Valeri Silena', N'Medrano Escorcia', N'valerimedrano20@gmail.com', N'3127962668')
SET IDENTITY_INSERT [dbo].[clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[facturas] ON 

INSERT [dbo].[facturas] ([id], [id_reserva], [precio_noche], [cantidad_noches], [total], [fecha_emision]) VALUES (9, 14, CAST(150000.00 AS Decimal(18, 2)), 7, CAST(1050000.00 AS Decimal(18, 2)), CAST(N'2024-06-10T18:52:29.140' AS DateTime))
SET IDENTITY_INSERT [dbo].[facturas] OFF
GO
SET IDENTITY_INSERT [dbo].[habitaciones] ON 

INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (1, N'201', N'1', 1)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (2, N'202', N'1', 1)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (3, N'203', N'1', 1)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (4, N'204', N'1', 1)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (5, N'205', N'1', 1)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (6, N'206', N'1', 1)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (7, N'207', N'1', 1)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (8, N'208', N'1', 1)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (9, N'209', N'1', 1)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (10, N'301', N'1', 2)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (11, N'302', N'1', 2)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (12, N'303', N'1', 2)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (13, N'304', N'1', 2)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (14, N'305', N'1', 2)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (15, N'306', N'1', 2)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (16, N'307', N'1', 2)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (17, N'308', N'1', 2)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (18, N'309', N'1', 2)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (19, N'401', N'0', 3)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (20, N'402', N'1', 3)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (21, N'403', N'1', 3)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (22, N'404', N'1', 3)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (23, N'405', N'1', 3)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (24, N'406', N'1', 3)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (25, N'407', N'1', 3)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (26, N'408', N'1', 3)
INSERT [dbo].[habitaciones] ([id], [numero], [estado], [id_tipo]) VALUES (27, N'409', N'1', 3)
SET IDENTITY_INSERT [dbo].[habitaciones] OFF
GO
SET IDENTITY_INSERT [dbo].[reservas] ON 

INSERT [dbo].[reservas] ([id], [id_cliente], [id_habitacion], [fecha_inicio], [fecha_fin], [cantidad_noches], [precio_total], [fecha_registro], [estado_reserva]) VALUES (14, 1, 19, CAST(N'2024-06-14' AS Date), CAST(N'2024-06-21' AS Date), 7, CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-06-10T18:45:12.540' AS DateTime), N'Facturada')
SET IDENTITY_INSERT [dbo].[reservas] OFF
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
ALTER TABLE [dbo].[facturas]  WITH CHECK ADD FOREIGN KEY([id_reserva])
REFERENCES [dbo].[reservas] ([id])
GO
ALTER TABLE [dbo].[habitaciones]  WITH CHECK ADD FOREIGN KEY([id_tipo])
REFERENCES [dbo].[tipo_habitacion] ([id])
GO
ALTER TABLE [dbo].[habitaciones]  WITH CHECK ADD FOREIGN KEY([id_tipo])
REFERENCES [dbo].[tipo_habitacion] ([id])
GO
ALTER TABLE [dbo].[reservas]  WITH CHECK ADD FOREIGN KEY([id_cliente])
REFERENCES [dbo].[clientes] ([id])
GO
ALTER TABLE [dbo].[reservas]  WITH CHECK ADD FOREIGN KEY([id_cliente])
REFERENCES [dbo].[clientes] ([id])
GO
ALTER TABLE [dbo].[reservas]  WITH CHECK ADD FOREIGN KEY([id_habitacion])
REFERENCES [dbo].[habitaciones] ([id])
GO
ALTER TABLE [dbo].[reservas]  WITH CHECK ADD FOREIGN KEY([id_habitacion])
REFERENCES [dbo].[habitaciones] ([id])
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tipo_habitacion"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 185
               Right = 256
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "habitaciones"
            Begin Extent = 
               Top = 7
               Left = 304
               Bottom = 185
               Right = 512
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "reservas"
            Begin Extent = 
               Top = 7
               Left = 560
               Bottom = 185
               Right = 782
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "clientes"
            Begin Extent = 
               Top = 7
               Left = 830
               Bottom = 185
               Right = 1038
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaTotalPrecio'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaTotalPrecio'
GO
USE [master]
GO
ALTER DATABASE [HotelBerlinDB] SET  READ_WRITE 
GO
