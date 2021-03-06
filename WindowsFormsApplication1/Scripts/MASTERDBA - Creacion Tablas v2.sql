USE [GD1C2016]
GO
/****** Object:  Schema [MASTERDBA]    Script Date: 12/06/2016 05:48:10 p.m. ******/
CREATE SCHEMA [MASTERDBA]
GO
/****** Object:  Table [MASTERDBA].[Calificaciones]    Script Date: 12/06/2016 05:48:10 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MASTERDBA].[Calificaciones](
	[IdCalificacion] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[IdCompra] [int] NOT NULL,
	[CantEstrellas] [numeric](18, 0) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Calificaciones] PRIMARY KEY CLUSTERED 
(
	[IdCalificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MASTERDBA].[Clientes]    Script Date: 12/06/2016 05:48:10 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MASTERDBA].[Clientes](
	[IdUsuario] [int] NOT NULL,
	[Apellido] [nvarchar](255) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL,
	[TipoDoc] [nvarchar](50) NOT NULL,
	[NroDoc] [numeric](18, 0) NOT NULL,
	[Mail] [nvarchar](255) NOT NULL,
	[Telefono] [nvarchar](50) NULL,
	[Calle] [nvarchar](255) NOT NULL,
	[Nro] [numeric](18, 0) NOT NULL,
	[Piso] [numeric](18, 0) NULL,
	[Departamento] [nvarchar](50) NULL,
	[Localidad] [nvarchar](100) NULL,
	[CP] [nvarchar](50) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[TipoDoc] ASC,
	[NroDoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MASTERDBA].[Compras]    Script Date: 12/06/2016 05:48:10 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MASTERDBA].[Compras](
	[IdCompra] [int] IDENTITY(1,1) NOT NULL,
	[IdPublicacion] [numeric](18, 0) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Cantidad] [numeric](18, 0) NOT NULL,
	[Envio] [bit] NOT NULL,
	[IdUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Compras] PRIMARY KEY CLUSTERED 
(
	[IdCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MASTERDBA].[Empresas]    Script Date: 12/06/2016 05:48:10 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MASTERDBA].[Empresas](
	[IdUsuario] [int] NOT NULL,
	[RazonSocial] [nvarchar](255) NOT NULL,
	[Mail] [nvarchar](255) NOT NULL,
	[Telefono] [nvarchar](50) NULL,
	[Calle] [nvarchar](255) NOT NULL,
	[Nro] [numeric](18, 0) NOT NULL,
	[Piso] [numeric](18, 0) NULL,
	[Departamento] [nvarchar](50) NULL,
	[Localidad] [nvarchar](100) NULL,
	[CP] [nvarchar](50) NOT NULL,
	[Ciudad] [nvarchar](100) NULL,
	[CUIT] [nvarchar](50) NOT NULL,
	[Contacto] [nvarchar](255) NULL,
	[Rubro] [nvarchar](255) NULL,
	[FechaCreacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Empresas] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RazonSocial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[CUIT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MASTERDBA].[Estado_Publicacion]    Script Date: 12/06/2016 05:48:10 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MASTERDBA].[Estado_Publicacion](
	[IdEstado] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Estado_Publicacion] PRIMARY KEY CLUSTERED 
(
	[IdEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MASTERDBA].[Facturas]    Script Date: 12/06/2016 05:48:10 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MASTERDBA].[Facturas](
	[IdFactura] [numeric](18, 0) NOT NULL,
	[IdPublicacion] [numeric](18, 0) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Total] [numeric](18, 2) NOT NULL,
	[IdFormaPago] [int] NOT NULL,
 CONSTRAINT [PK_Facturas] PRIMARY KEY CLUSTERED 
(
	[IdFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MASTERDBA].[Facturas_Items]    Script Date: 12/06/2016 05:48:10 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MASTERDBA].[Facturas_Items](
	[IdItem] [int] IDENTITY(1,1) NOT NULL,
	[IdFactura] [numeric](18, 0) NOT NULL,
	[Concepto] [nvarchar](255) NOT NULL,
	[Monto] [numeric](18, 2) NOT NULL,
	[Cantidad] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Facturas_Items] PRIMARY KEY CLUSTERED 
(
	[IdItem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MASTERDBA].[Formas_Pago]    Script Date: 12/06/2016 05:48:10 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MASTERDBA].[Formas_Pago](
	[IdFormaPago] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Formas_Pago] PRIMARY KEY CLUSTERED 
(
	[IdFormaPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MASTERDBA].[Funcionalidades]    Script Date: 12/06/2016 05:48:10 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MASTERDBA].[Funcionalidades](
	[IdFuncionalidad] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Funcionalidades] PRIMARY KEY CLUSTERED 
(
	[IdFuncionalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MASTERDBA].[Ofertas]    Script Date: 12/06/2016 05:48:10 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MASTERDBA].[Ofertas](
	[IdOferta] [int] IDENTITY(1,1) NOT NULL,
	[IdPublicacion] [numeric](18, 0) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Monto] [numeric](18, 2) NOT NULL,
	[Envio] [bit] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdCompra] [int] NULL,
 CONSTRAINT [PK_Ofertas] PRIMARY KEY CLUSTERED 
(
	[IdOferta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MASTERDBA].[Publicaciones]    Script Date: 12/06/2016 05:48:10 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MASTERDBA].[Publicaciones](
	[IdPublicacion] [numeric](18, 0) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
	[Stock] [numeric](18, 0) NOT NULL,
	[FechaInicio] [datetime] NOT NULL,
	[FechaVencimiento] [datetime] NOT NULL,
	[Precio] [numeric](18, 2) NOT NULL,
	[PrecioReserva] [numeric](18, 2) NULL,
	[IdRubro] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdEstado] [int] NOT NULL,
	[IdTipo] [int] NOT NULL,
	[Envio] [bit] NOT NULL,
 CONSTRAINT [PK_Publicaciones] PRIMARY KEY CLUSTERED 
(
	[IdPublicacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MASTERDBA].[Publicaciones_Visibilidad]    Script Date: 12/06/2016 05:48:10 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MASTERDBA].[Publicaciones_Visibilidad](
	[IdPublicacion] [numeric](18, 0) NOT NULL,
	[IdVisibilidad] [int] NOT NULL,
	[Activa] [bit] NOT NULL,
 CONSTRAINT [PK_Publicaciones_Visibilidad] PRIMARY KEY CLUSTERED 
(
	[IdPublicacion] ASC,
	[IdVisibilidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MASTERDBA].[Roles]    Script Date: 12/06/2016 05:48:10 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MASTERDBA].[Roles](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MASTERDBA].[Roles_Funcionalidades]    Script Date: 12/06/2016 05:48:10 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MASTERDBA].[Roles_Funcionalidades](
	[IdRol] [int] NOT NULL,
	[IdFuncionalidad] [int] NOT NULL,
	[Activa] [bit] NOT NULL,
 CONSTRAINT [PK_Roles_Funcionalidades] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC,
	[IdFuncionalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MASTERDBA].[Rubros]    Script Date: 12/06/2016 05:48:10 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MASTERDBA].[Rubros](
	[IdRubro] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionCorta] [nvarchar](25) NOT NULL,
	[DescripcionLarga] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Rubros] PRIMARY KEY CLUSTERED 
(
	[IdRubro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MASTERDBA].[Tipo_Publicacion]    Script Date: 12/06/2016 05:48:10 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MASTERDBA].[Tipo_Publicacion](
	[IdTipo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
	[Envio] [bit] NOT NULL,
 CONSTRAINT [PK_Tipo_Publicacion] PRIMARY KEY CLUSTERED 
(
	[IdTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MASTERDBA].[Usuarios]    Script Date: 12/06/2016 05:48:10 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MASTERDBA].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[PassEncr] [nvarchar](255) NOT NULL,
	[CantIntFallidos] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MASTERDBA].[Usuarios_Roles]    Script Date: 12/06/2016 05:48:10 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MASTERDBA].[Usuarios_Roles](
	[IdUsuario] [int] NOT NULL,
	[IdRol] [int] NOT NULL,
	[Activa] [bit] NOT NULL,
 CONSTRAINT [PK_Usuarios_Roles] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC,
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MASTERDBA].[Visibilidad_Publicacion]    Script Date: 12/06/2016 05:48:10 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MASTERDBA].[Visibilidad_Publicacion](
	[IdVisibilidad] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
	[Precio] [numeric](18, 2) NOT NULL,
	[Porcentaje] [numeric](18, 2) NOT NULL,
	[EnvioPorcentaje] [numeric](18, 2) NOT NULL,
	[Activa] [bit] NOT NULL,
 CONSTRAINT [PK_Visibilidad_Publicacion] PRIMARY KEY CLUSTERED 
(
	[IdVisibilidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [MASTERDBA].[Calificaciones]  WITH CHECK ADD  CONSTRAINT [FK_Compras_Calificaciones] FOREIGN KEY([IdCompra])
REFERENCES [MASTERDBA].[Compras] ([IdCompra])
GO
ALTER TABLE [MASTERDBA].[Calificaciones] CHECK CONSTRAINT [FK_Compras_Calificaciones]
GO
ALTER TABLE [MASTERDBA].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Clientes] FOREIGN KEY([IdUsuario])
REFERENCES [MASTERDBA].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [MASTERDBA].[Clientes] CHECK CONSTRAINT [FK_Usuarios_Clientes]
GO
ALTER TABLE [MASTERDBA].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Publicaciones_Compras] FOREIGN KEY([IdPublicacion])
REFERENCES [MASTERDBA].[Publicaciones] ([IdPublicacion])
GO
ALTER TABLE [MASTERDBA].[Compras] CHECK CONSTRAINT [FK_Publicaciones_Compras]
GO
ALTER TABLE [MASTERDBA].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Compras] FOREIGN KEY([IdUsuario])
REFERENCES [MASTERDBA].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [MASTERDBA].[Compras] CHECK CONSTRAINT [FK_Usuarios_Compras]
GO
ALTER TABLE [MASTERDBA].[Empresas]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Empresas] FOREIGN KEY([IdUsuario])
REFERENCES [MASTERDBA].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [MASTERDBA].[Empresas] CHECK CONSTRAINT [FK_Usuarios_Empresas]
GO
ALTER TABLE [MASTERDBA].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Formas_Pago_Facturas] FOREIGN KEY([IdFormaPago])
REFERENCES [MASTERDBA].[Formas_Pago] ([IdFormaPago])
GO
ALTER TABLE [MASTERDBA].[Facturas] CHECK CONSTRAINT [FK_Formas_Pago_Facturas]
GO
ALTER TABLE [MASTERDBA].[Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Publicaciones_Facturas] FOREIGN KEY([IdPublicacion])
REFERENCES [MASTERDBA].[Publicaciones] ([IdPublicacion])
GO
ALTER TABLE [MASTERDBA].[Facturas] CHECK CONSTRAINT [FK_Publicaciones_Facturas]
GO
ALTER TABLE [MASTERDBA].[Facturas_Items]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_Facturas_Items] FOREIGN KEY([IdFactura])
REFERENCES [MASTERDBA].[Facturas] ([IdFactura])
GO
ALTER TABLE [MASTERDBA].[Facturas_Items] CHECK CONSTRAINT [FK_Facturas_Facturas_Items]
GO
ALTER TABLE [MASTERDBA].[Ofertas]  WITH CHECK ADD  CONSTRAINT [FK_Compras_Ofertas] FOREIGN KEY([IdCompra])
REFERENCES [MASTERDBA].[Compras] ([IdCompra])
GO
ALTER TABLE [MASTERDBA].[Ofertas] CHECK CONSTRAINT [FK_Compras_Ofertas]
GO
ALTER TABLE [MASTERDBA].[Ofertas]  WITH CHECK ADD  CONSTRAINT [FK_Publicaciones_Ofertas] FOREIGN KEY([IdPublicacion])
REFERENCES [MASTERDBA].[Publicaciones] ([IdPublicacion])
GO
ALTER TABLE [MASTERDBA].[Ofertas] CHECK CONSTRAINT [FK_Publicaciones_Ofertas]
GO
ALTER TABLE [MASTERDBA].[Ofertas]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Ofertas] FOREIGN KEY([IdUsuario])
REFERENCES [MASTERDBA].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [MASTERDBA].[Ofertas] CHECK CONSTRAINT [FK_Usuarios_Ofertas]
GO
ALTER TABLE [MASTERDBA].[Publicaciones]  WITH CHECK ADD  CONSTRAINT [FK_Estado_Publicacion_Publicaciones] FOREIGN KEY([IdEstado])
REFERENCES [MASTERDBA].[Estado_Publicacion] ([IdEstado])
GO
ALTER TABLE [MASTERDBA].[Publicaciones] CHECK CONSTRAINT [FK_Estado_Publicacion_Publicaciones]
GO
ALTER TABLE [MASTERDBA].[Publicaciones]  WITH CHECK ADD  CONSTRAINT [FK_Rubros_Publicaciones] FOREIGN KEY([IdRubro])
REFERENCES [MASTERDBA].[Rubros] ([IdRubro])
GO
ALTER TABLE [MASTERDBA].[Publicaciones] CHECK CONSTRAINT [FK_Rubros_Publicaciones]
GO
ALTER TABLE [MASTERDBA].[Publicaciones]  WITH CHECK ADD  CONSTRAINT [FK_Tipo_Publicacion_Publicaciones] FOREIGN KEY([IdTipo])
REFERENCES [MASTERDBA].[Tipo_Publicacion] ([IdTipo])
GO
ALTER TABLE [MASTERDBA].[Publicaciones] CHECK CONSTRAINT [FK_Tipo_Publicacion_Publicaciones]
GO
ALTER TABLE [MASTERDBA].[Publicaciones]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Publicaciones] FOREIGN KEY([IdUsuario])
REFERENCES [MASTERDBA].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [MASTERDBA].[Publicaciones] CHECK CONSTRAINT [FK_Usuarios_Publicaciones]
GO
ALTER TABLE [MASTERDBA].[Publicaciones_Visibilidad]  WITH CHECK ADD  CONSTRAINT [FK_Publicaciones_Publicaciones_Visibilidad] FOREIGN KEY([IdPublicacion])
REFERENCES [MASTERDBA].[Publicaciones] ([IdPublicacion])
GO
ALTER TABLE [MASTERDBA].[Publicaciones_Visibilidad] CHECK CONSTRAINT [FK_Publicaciones_Publicaciones_Visibilidad]
GO
ALTER TABLE [MASTERDBA].[Roles_Funcionalidades]  WITH CHECK ADD  CONSTRAINT [FK_Funcionalidades_Roles_Funcionalidades] FOREIGN KEY([IdFuncionalidad])
REFERENCES [MASTERDBA].[Funcionalidades] ([IdFuncionalidad])
GO
ALTER TABLE [MASTERDBA].[Roles_Funcionalidades] CHECK CONSTRAINT [FK_Funcionalidades_Roles_Funcionalidades]
GO
ALTER TABLE [MASTERDBA].[Roles_Funcionalidades]  WITH CHECK ADD  CONSTRAINT [FK_Roles_Roles_Funcionalidades] FOREIGN KEY([IdRol])
REFERENCES [MASTERDBA].[Roles] ([IdRol])
GO
ALTER TABLE [MASTERDBA].[Roles_Funcionalidades] CHECK CONSTRAINT [FK_Roles_Roles_Funcionalidades]
GO
ALTER TABLE [MASTERDBA].[Usuarios_Roles]  WITH CHECK ADD  CONSTRAINT [FK_Roles_Usuarios_Roles] FOREIGN KEY([IdRol])
REFERENCES [MASTERDBA].[Roles] ([IdRol])
GO
ALTER TABLE [MASTERDBA].[Usuarios_Roles] CHECK CONSTRAINT [FK_Roles_Usuarios_Roles]
GO
ALTER TABLE [MASTERDBA].[Usuarios_Roles]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Usuarios_Roles] FOREIGN KEY([IdUsuario])
REFERENCES [MASTERDBA].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [MASTERDBA].[Usuarios_Roles] CHECK CONSTRAINT [FK_Usuarios_Usuarios_Roles]
GO
