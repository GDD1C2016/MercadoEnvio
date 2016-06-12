USE [GD1C2016]
GO
----- 424266
----- 396685
--DIF  27581

--DROP TABLE #Maestra
--GO
SELECT DISTINCT [Publ_Cli_Dni]
      ,[Publ_Cli_Apeliido]
      ,[Publ_Cli_Nombre]
      ,[Publ_Cli_Fecha_Nac]
      ,[Publ_Cli_Mail]
      ,[Publ_Cli_Dom_Calle]
      ,[Publ_Cli_Nro_Calle]
      ,[Publ_Cli_Piso]
      ,[Publ_Cli_Depto]
      ,[Publ_Cli_Cod_Postal]
      ,[Publ_Empresa_Razon_Social]
      ,[Publ_Empresa_Cuit]
      ,[Publ_Empresa_Fecha_Creacion]
      ,[Publ_Empresa_Mail]
      ,[Publ_Empresa_Dom_Calle]
      ,[Publ_Empresa_Nro_Calle]
      ,[Publ_Empresa_Piso]
      ,[Publ_Empresa_Depto]
      ,[Publ_Empresa_Cod_Postal]
      ,[Publicacion_Cod]
      ,[Publicacion_Descripcion]
      ,[Publicacion_Stock]
      ,[Publicacion_Fecha]
      ,[Publicacion_Fecha_Venc]
      ,[Publicacion_Precio]
      ,[Publicacion_Tipo]
      ,[Publicacion_Visibilidad_Cod]
      ,[Publicacion_Visibilidad_Desc]
      ,[Publicacion_Visibilidad_Precio]
      ,[Publicacion_Visibilidad_Porcentaje]
      ,[Publicacion_Estado]
      ,[Publicacion_Rubro_Descripcion]
      ,[Cli_Dni]
      ,[Cli_Apeliido]
      ,[Cli_Nombre]
      ,[Cli_Fecha_Nac]
      ,[Cli_Mail]
      ,[Cli_Dom_Calle]
      ,[Cli_Nro_Calle]
      ,[Cli_Piso]
      ,[Cli_Depto]
      ,[Cli_Cod_Postal]
      ,[Compra_Fecha]
      ,[Compra_Cantidad]
      ,[Oferta_Fecha]
      ,[Oferta_Monto]
      ,[Calificacion_Codigo]
      ,[Calificacion_Cant_Estrellas]
      ,[Calificacion_Descripcion]
      ,[Item_Factura_Monto]
      ,[Item_Factura_Cantidad]
      ,[Factura_Nro]
      ,[Factura_Fecha]
      ,[Factura_Total]
      ,[Forma_Pago_Desc]
INTO #Maestra
FROM [GD1C2016].[gd_esquema].[Maestra]
GO

--- TABLA MASTERDBA.Estado_Publicacion
INSERT INTO [GD1C2016].[MASTERDBA].[Estado_Publicacion] VALUES ('Borrador')
INSERT INTO [GD1C2016].[MASTERDBA].[Estado_Publicacion] VALUES ('Activa')
INSERT INTO [GD1C2016].[MASTERDBA].[Estado_Publicacion] VALUES ('Pausada')
INSERT INTO [GD1C2016].[MASTERDBA].[Estado_Publicacion] VALUES ('Finalizada')
GO

--- TABLA MASTERDBA.Tipo_Publicacion
INSERT INTO [GD1C2016].[MASTERDBA].[Tipo_Publicacion]
SELECT DISTINCT
	Publicacion_Tipo,
	CASE Publicacion_Tipo
		WHEN 'Subasta'
			THEN 0
		WHEN 'Compra Inmediata'
			THEN 1
	END
FROM #Maestra
WHERE NOT Publicacion_Tipo IS NULL
GO

--- TABLA MASTERDBA.Visibilidad_Publicacion
SET IDENTITY_INSERT [GD1C2016].[MASTERDBA].[Visibilidad_Publicacion] ON;

INSERT INTO [GD1C2016].[MASTERDBA].[Visibilidad_Publicacion] ([IdVisibilidad], [Descripcion], [Precio], [Porcentaje], [EnvioPorcentaje], [Activa])
SELECT DISTINCT
	Publicacion_Visibilidad_Cod, Publicacion_Visibilidad_Desc, Publicacion_Visibilidad_Precio, Publicacion_Visibilidad_Porcentaje, Publicacion_Visibilidad_Porcentaje / 3, 1
FROM #Maestra
WHERE NOT Publicacion_Visibilidad_Cod IS NULL

SET IDENTITY_INSERT [GD1C2016].[MASTERDBA].[Visibilidad_Publicacion] OFF;
GO

--- TABLA MASTERDBA.Formas_Pago
INSERT INTO [GD1C2016].[MASTERDBA].[Formas_Pago]
SELECT DISTINCT Forma_Pago_Desc
FROM #Maestra
WHERE NOT Forma_Pago_Desc IS NULL
GO

--- TABLA MASTERDBA.Rubros
INSERT INTO [GD1C2016].[MASTERDBA].[Rubros]
SELECT DISTINCT
	CASE
		WHEN LEN(Publicacion_Rubro_Descripcion) > 25
			THEN LEFT(Publicacion_Rubro_Descripcion, 22) + '...'
		ELSE Publicacion_Rubro_Descripcion
	END,
	Publicacion_Rubro_Descripcion
FROM #Maestra
WHERE NOT Publicacion_Rubro_Descripcion IS NULL
GO

--- TABLA MASTERDBA.Roles
INSERT INTO [GD1C2016].[MASTERDBA].[Roles] VALUES ('Administrativo', 1)
INSERT INTO [GD1C2016].[MASTERDBA].[Roles] VALUES ('Cliente', 1)
INSERT INTO [GD1C2016].[MASTERDBA].[Roles] VALUES ('Empresa', 1)
GO

--- TABLA MASTERDBA.Funcionalidades
INSERT INTO [GD1C2016].[MASTERDBA].[Funcionalidades] VALUES ('Login y Seguridad')
INSERT INTO [GD1C2016].[MASTERDBA].[Funcionalidades] VALUES ('ABM de Rol')
INSERT INTO [GD1C2016].[MASTERDBA].[Funcionalidades] VALUES ('ABM de Usuarios (sólo clientes y empresas)')
INSERT INTO [GD1C2016].[MASTERDBA].[Funcionalidades] VALUES ('ABM de Rubro')
INSERT INTO [GD1C2016].[MASTERDBA].[Funcionalidades] VALUES ('ABM de Visibilidad de Publicación')
INSERT INTO [GD1C2016].[MASTERDBA].[Funcionalidades] VALUES ('Generar Publicación')
INSERT INTO [GD1C2016].[MASTERDBA].[Funcionalidades] VALUES ('Comprar/Ofertar')
INSERT INTO [GD1C2016].[MASTERDBA].[Funcionalidades] VALUES ('Historial del Cliente')
INSERT INTO [GD1C2016].[MASTERDBA].[Funcionalidades] VALUES ('Calificar al Vendedor')
INSERT INTO [GD1C2016].[MASTERDBA].[Funcionalidades] VALUES ('Consulta de Facturas Realizadas al Vendedor')
INSERT INTO [GD1C2016].[MASTERDBA].[Funcionalidades] VALUES ('Listado Estadístico')
GO

--- TABLA MASTERDBA.Roles_Funcionalidades (Administrativo)
DECLARE @IdAdministrativo int
SELECT @IdAdministrativo = [IdRol]
FROM [GD1C2016].[MASTERDBA].[Roles]
WHERE [Descripcion] = 'Administrativo'
INSERT INTO [GD1C2016].[MASTERDBA].[Roles_Funcionalidades]
SELECT @IdAdministrativo, [IdFuncionalidad], 1 FROM [GD1C2016].[MASTERDBA].[Funcionalidades]

--- TABLA MASTERDBA.Usuarios (Administrativo)
INSERT INTO [GD1C2016].[MASTERDBA].[Usuarios] VALUES ('admin', CONVERT(nvarchar(MAX), HASHBYTES('SHA2_256','w23e'), 2), 0, 1)

--- TABLA MASTERDBA.Usuarios_Roles (Administrativo)
INSERT INTO [GD1C2016].[MASTERDBA].[Usuarios_Roles] VALUES (@@IDENTITY, @IdAdministrativo, 1)
GO

--- TABLA MASTERDBA.Roles_Funcionalidades (Cliente)
DECLARE @IdCliente int
SELECT @IdCliente = [IdRol]
FROM [GD1C2016].[MASTERDBA].[Roles]
WHERE [Descripcion] = 'Cliente'
INSERT INTO [GD1C2016].[MASTERDBA].[Roles_Funcionalidades]
SELECT @IdCliente, [IdFuncionalidad], 1
FROM [GD1C2016].[MASTERDBA].[Funcionalidades]
WHERE NOT [Descripcion] IN	(
							'ABM de Rol',
							'ABM de Usuarios (sólo clientes y empresas)',
							'ABM de Rubro',
							'ABM de Visibilidad de Publicación',
							'Listado Estadístico'
							)

--- TABLA MASTERDBA.Usuarios (Cliente)
INSERT INTO [GD1C2016].[MASTERDBA].[Usuarios] -- Usuarios que publicaron
SELECT DISTINCT
	LOWER(Publ_Cli_Apeliido) + '_' + LOWER(Publ_Cli_Nombre), CONVERT(nvarchar(MAX), HASHBYTES('SHA2_256', 'w' + CONVERT(varchar(18), Publ_Cli_Dni)), 2), 0, 1
FROM #Maestra
WHERE NOT Publ_Cli_Dni IS NULL
AND NOT Publ_Cli_Apeliido IS NULL
AND NOT Publ_Cli_Nombre IS NULL

INSERT INTO [GD1C2016].[MASTERDBA].[Usuarios] -- Usuarios que compraron
SELECT DISTINCT
	LOWER(Cli_Apeliido) + '_' + LOWER(Cli_Nombre), CONVERT(nvarchar(MAX), HASHBYTES('SHA2_256', 'w' + CONVERT(varchar(18), Cli_Dni)), 2), 0, 1
FROM #Maestra
WHERE NOT Cli_Dni IS NULL
AND NOT Cli_Apeliido IS NULL
AND NOT Cli_Nombre IS NULL
AND NOT LOWER(Cli_Apeliido) + '_' + LOWER(Cli_Nombre) IN (SELECT UserName FROM MASTERDBA.Usuarios)

--- TABLA MASTERDBA.Usuarios_Roles (Cliente)
INSERT INTO [GD1C2016].[MASTERDBA].[Usuarios_Roles]
SELECT DISTINCT
	U.[IdUsuario], @IdCliente, 1
FROM #Maestra M, [GD1C2016].[MASTERDBA].[Usuarios] U
WHERE LOWER(M.Publ_Cli_Apeliido) + '_' + LOWER(M.Publ_Cli_Nombre) = U.[UserName]
OR LOWER(M.Cli_Apeliido) + '_' + LOWER(M.Cli_Nombre) = U.[UserName]
GO

--- TABLA MASTERDBA.Roles_Funcionalidades (Empresa)
DECLARE @IdEmpresa int
SELECT @IdEmpresa = [IdRol]
FROM [GD1C2016].[MASTERDBA].[Roles]
WHERE [Descripcion] = 'Empresa'
INSERT INTO [GD1C2016].[MASTERDBA].[Roles_Funcionalidades]
SELECT @IdEmpresa, [IdFuncionalidad], 1
FROM [GD1C2016].[MASTERDBA].[Funcionalidades]
WHERE [Descripcion] IN	(
						'Login y Seguridad',
						'Generar Publicación',
						'Consulta de Facturas Realizadas al Vendedor'
						)

--- TABLA MASTERDBA.Usuarios (Empresa)
INSERT INTO [GD1C2016].[MASTERDBA].[Usuarios]
SELECT DISTINCT
	'empresa' + SUBSTRING(Publ_Empresa_Razon_Social, 17, 2), CONVERT(nvarchar(MAX), HASHBYTES('SHA2_256', 'w' + CONVERT(varchar(12), SUBSTRING(Publ_Empresa_Cuit, 1, 2) + SUBSTRING(Publ_Empresa_Cuit, 4, 8) + SUBSTRING(Publ_Empresa_Cuit, 13, 2))), 2), 0,	1
FROM #Maestra
WHERE NOT Publ_Empresa_Cuit IS NULL
AND NOT Publ_Empresa_Razon_Social IS NULL

--- TABLA MASTERDBA.Usuarios_Roles (Empresa)
INSERT INTO [GD1C2016].[MASTERDBA].[Usuarios_Roles]
SELECT DISTINCT
	U.[IdUsuario], @IdEmpresa, 1
FROM #Maestra M, [GD1C2016].[MASTERDBA].[Usuarios] U
WHERE 'empresa' + SUBSTRING(M.Publ_Empresa_Razon_Social, 17, 2) = U.[UserName]
GO

--- TABLA MASTERDBA.Clientes
INSERT INTO [GD1C2016].[MASTERDBA].[Clientes] -- Clientes que publicaron
SELECT DISTINCT
	U.[IdUsuario], M.Publ_Cli_Apeliido, M.Publ_Cli_Nombre, 'DNI', M.Publ_Cli_Dni, M.Publ_Cli_Mail, NULL, M.Publ_Cli_Dom_Calle, M.Publ_Cli_Nro_Calle, M.Publ_Cli_Piso, M.Publ_Cli_Depto, NULL, M.Publ_Cli_Cod_Postal, M.Publ_Cli_Fecha_Nac, GETDATE()
FROM #Maestra M, [GD1C2016].[MASTERDBA].[Usuarios] U
WHERE LOWER(M.Publ_Cli_Apeliido) + '_' + LOWER(M.Publ_Cli_Nombre) = U.[UserName]
GO

INSERT INTO [GD1C2016].[MASTERDBA].[Clientes] -- Clientes que compraron
SELECT DISTINCT
	U.[IdUsuario], M.Cli_Apeliido, M.Cli_Nombre, 'DNI', M.Cli_Dni, Cli_Mail, NULL, M.Cli_Dom_Calle, M.Cli_Nro_Calle, M.Cli_Piso, M.Cli_Depto, NULL, M.Cli_Cod_Postal, M.Cli_Fecha_Nac, GETDATE()
FROM #Maestra M, [GD1C2016].[MASTERDBA].[Usuarios] U
WHERE LOWER(M.Cli_Apeliido) + '_' + Lower(M.Cli_Nombre) = U.[UserName]
AND NOT U.[IdUsuario] IN (SELECT [IdUsuario] FROM [GD1C2016].[MASTERDBA].[Clientes])
GO

--- TABLA MASTERDBA.Empresas
INSERT INTO [GD1C2016].[MASTERDBA].[Empresas]
SELECT DISTINCT
	U.[IdUsuario], M.Publ_Empresa_Razon_Social, M.Publ_Empresa_Mail, NULL, M.Publ_Empresa_Dom_Calle, M.Publ_Empresa_Nro_Calle, M.Publ_Empresa_Piso, M.Publ_Empresa_Depto, NULL, M.Publ_Empresa_Cod_Postal, NULL, M.Publ_Empresa_Cuit, NULL, NULL, GETDATE()
FROM #Maestra M, [GD1C2016].[MASTERDBA].[Usuarios] U
WHERE 'empresa' + SUBSTRING(M.Publ_Empresa_Razon_Social, 17, 2) = U.[UserName]
AND NOT M.Publ_Empresa_Razon_Social IS NULL
GO

--- TABLA MASTERDBA.Publicaciones
INSERT INTO [GD1C2016].[MASTERDBA].[Publicaciones]
SELECT DISTINCT
	M.Publicacion_Cod,
	M.Publicacion_Descripcion,
	M.Publicacion_Stock,
	M.Publicacion_Fecha,
	M.Publicacion_Fecha_Venc,
	CASE M.Publicacion_Tipo
		WHEN 'Subasta'
			THEN	(
					SELECT MAX(M2.Oferta_Monto)
					FROM #Maestra M1, #Maestra M2
					WHERE M1.Publicacion_Cod = M2.Publicacion_Cod
					AND M1.Calificacion_Codigo IS NOT NULL
					AND M2.Oferta_Fecha IS NOT NULL
					AND M2.Publicacion_Cod = M.Publicacion_Cod
					GROUP BY M2.Publicacion_Cod
					)
		WHEN 'Compra Inmediata'
			THEN M.Publicacion_Precio
	END,
	CASE M.Publicacion_Tipo
		WHEN 'Subasta'
			THEN M.Publicacion_Precio
		WHEN 'Compra Inmediata'
			THEN NULL
	END,
	R.[IdRubro],
	U.[IdUsuario],
	E.[IdEstado],
	T.[IdTipo]
FROM #Maestra M, [GD1C2016].[MASTERDBA].[Usuarios] U, [GD1C2016].[MASTERDBA].[Estado_Publicacion] E, [GD1C2016].[MASTERDBA].[Tipo_Publicacion] T, [GD1C2016].[MASTERDBA].[Rubros] R
WHERE ('empresa' + SUBSTRING(M.Publ_Empresa_Razon_Social, 17, 2) = U.[UserName]
OR LOWER(M.Publ_Cli_Apeliido) + '_' + LOWER(M.Publ_Cli_Nombre) = U.[UserName])
AND	CASE Publicacion_Estado	WHEN 'Publicada' THEN 'Finalizada' END = E.[Descripcion] --THEN 'Activa' END = E.Descripcion
AND	M.Publicacion_Tipo = T.[Descripcion]
AND	M.Publicacion_Rubro_Descripcion = R.[DescripcionLarga]
GO

--- TABLA MASTERDBA.Publicaciones_Visibilidad
INSERT INTO [GD1C2016].[MASTERDBA].[Publicaciones_Visibilidad]
SELECT DISTINCT
	Publicacion_Cod, Publicacion_Visibilidad_Cod, 1
FROM #Maestra
WHERE NOT Publicacion_Visibilidad_Cod IS NULL
GO

--- TABLA MASTERDBA.Facturas
INSERT INTO [GD1C2016].[MASTERDBA].[Facturas]
SELECT DISTINCT
	M.Factura_Nro, M.Publicacion_Cod, M.Factura_Fecha, M.Factura_Total, FP.[IdFormaPago]
FROM #Maestra M, [GD1C2016].[MASTERDBA].[Formas_Pago] FP
WHERE NOT M.Factura_Nro IS NULL
AND M.Forma_Pago_Desc = FP.[Descripcion]
GO

--- TABLA MASTERDBA.Facturas_Items
INSERT INTO [GD1C2016].MASTERDBA.Facturas_Items
SELECT DISTINCT
	Factura_Nro,
	CASE Item_Factura_Monto
		WHEN Publicacion_Visibilidad_Precio
			THEN 'Comisión por Publicación'
		WHEN ROUND(Publicacion_Precio * Publicacion_Visibilidad_Porcentaje * Item_Factura_Cantidad, 2)
			THEN 'Comisión por Venta'
		WHEN ROUND(Publicacion_Precio * Publicacion_Visibilidad_Porcentaje * Item_Factura_Cantidad, 2) - 0.01
			THEN 'Comisión por Venta'
		WHEN ROUND(Publicacion_Precio * Publicacion_Visibilidad_Porcentaje * Item_Factura_Cantidad, 2) + 0.01
			THEN 'Comisión por Venta'
		ELSE 'Varios'
	END Texto,
	Item_Factura_Monto,
	Item_Factura_Cantidad
FROM #Maestra
WHERE NOT Factura_Nro IS NULL
GO

--- TABLA MASTERDBA.Ofertas
INSERT INTO [GD1C2016].[MASTERDBA].[Ofertas]
SELECT DISTINCT
	M.Publicacion_Cod, M.Oferta_Fecha, M.Oferta_Monto, 0, U.[IdUsuario], NULL
FROM #Maestra M, [GD1C2016].[MASTERDBA].[Usuarios] U
WHERE LOWER(M.Cli_Apeliido) + '_' + LOWER(M.Cli_Nombre) = U.[UserName]
AND NOT M.Oferta_Fecha IS NULL
GO

--- TABLA MASTERDBA.Compras y TABLA MASTERDBA.Calificaciones
DECLARE @IdPublicacion int
DECLARE @IdPublicacionAnt int
DECLARE @Fecha datetime
DECLARE @FechaAnt datetime
DECLARE @Cantidad numeric(18,0)
DECLARE @CantidadAnt numeric(18,0)
DECLARE @IdUsuario int
DECLARE @IdUsuarioAnt int
DECLARE @CodCalificacion numeric(18,0)
DECLARE @CantEstrellas numeric(18,0)
DECLARE @Descripcion nvarchar(255)
DECLARE @IdCompra as int

DECLARE C_Compras CURSOR FOR
	SELECT DISTINCT
		M.Publicacion_Cod, M.Compra_Fecha, M.Compra_Cantidad, U.[IdUsuario], M.Calificacion_Codigo, M.Calificacion_Cant_Estrellas, M.Calificacion_Descripcion
	FROM #Maestra M, [GD1C2016].[MASTERDBA].[Usuarios] U
	WHERE LOWER(M.Cli_Apeliido) + '_' + LOWER(M.Cli_Nombre) = U.[UserName]
	AND NOT M.Compra_Fecha IS NULL
	AND	NOT M.Calificacion_Codigo IS NULL
	ORDER BY M.Publicacion_Cod, M.Compra_Fecha, M.Compra_Cantidad, U.[IdUsuario], M.Calificacion_Codigo

OPEN C_Compras

FETCH NEXT FROM C_Compras
INTO @IdPublicacion, @Fecha, @Cantidad, @IdUsuario, @CodCalificacion, @CantEstrellas, @Descripcion

-- COMPRAS: 97265
-- CALIFICACIONES: 97362

SET IDENTITY_INSERT [GD1C2016].[MASTERDBA].[Calificaciones] ON;

WHILE @@FETCH_STATUS = 0
BEGIN
	INSERT INTO [GD1C2016].[MASTERDBA].[Compras]
	SELECT @IdPublicacion, @Fecha, @Cantidad, 0, @IdUsuario

	SET @IdCompra = @@IDENTITY
	SET @IdPublicacionAnt = @IdPublicacion
	SET @FechaAnt = @Fecha
	SET @CantidadAnt = @Cantidad
	SET @IdUsuarioAnt = @IdUsuario

	UPDATE [GD1C2016].[MASTERDBA].[Ofertas]
	SET [IdCompra] = @IdCompra
	WHERE [IdPublicacion] = @IdPublicacion
	AND [IdUsuario] = @IdUsuario
	AND [Monto] = (SELECT MAX(Monto) FROM [GD1C2016].[MASTERDBA].[Ofertas] WHERE [IdPublicacion] = @IdPublicacion GROUP BY IdPublicacion)

	WHILE (@@FETCH_STATUS = 0) AND (@IdPublicacion = @IdPublicacionAnt)	AND (@Fecha = @FechaAnt) AND (@Cantidad = @CantidadAnt) AND (@IdUsuario = @IdUsuarioAnt)
	BEGIN
		INSERT INTO [GD1C2016].[MASTERDBA].[Calificaciones] ([IdCalificacion], [IdCompra], [CantEstrellas], [Descripcion])
		SELECT @CodCalificacion, @IdCompra, @CantEstrellas, @Descripcion

		FETCH NEXT FROM C_Compras
		INTO @IdPublicacion, @Fecha, @Cantidad, @IdUsuario, @CodCalificacion, @CantEstrellas, @Descripcion
	END
END

SET IDENTITY_INSERT [GD1C2016].[MASTERDBA].[Calificaciones] OFF;

CLOSE C_Compras
DEALLOCATE C_Compras
GO