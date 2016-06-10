----- 424266
----- 396685
--DIF  27581

DROP TABLE #Maestra
GO
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
INSERT INTO MASTERDBA.Estado_Publicacion VALUES ('Borrador')
INSERT INTO MASTERDBA.Estado_Publicacion VALUES ('Activa')
INSERT INTO MASTERDBA.Estado_Publicacion VALUES ('Pausada')
INSERT INTO MASTERDBA.Estado_Publicacion VALUES ('Finalizada')
GO

--- TABLA MASTERDBA.Tipo_Publicacion
INSERT INTO MASTERDBA.Tipo_Publicacion
SELECT DISTINCT Publicacion_Tipo, 0 FROM #Maestra
WHERE NOT Publicacion_Tipo IS NULL
GO

--- TABLA MASTERDBA.Visibilidad_Publicacion
INSERT INTO MASTERDBA.Visibilidad_Publicacion
SELECT DISTINCT
	Publicacion_Visibilidad_Cod, Publicacion_Visibilidad_Desc, Publicacion_Visibilidad_Precio, Publicacion_Visibilidad_Porcentaje, Publicacion_Visibilidad_Porcentaje / 3
FROM #Maestra
WHERE NOT Publicacion_Visibilidad_Cod IS NULL
GO

--- TABLA MASTERDBA.Formas_Pago
INSERT INTO MASTERDBA.Formas_Pago
SELECT DISTINCT Forma_Pago_Desc FROM #Maestra
WHERE NOT Forma_Pago_Desc IS NULL
GO

--- TABLA MASTERDBA.Rubros
INSERT INTO MASTERDBA.Rubros
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
INSERT INTO MASTERDBA.Roles VALUES ('Administrativo', 1)
INSERT INTO MASTERDBA.Roles VALUES ('Cliente', 1)
INSERT INTO MASTERDBA.Roles VALUES ('Empresa', 1)
GO

--- TABLA MASTERDBA.Funcionalidades
INSERT INTO MASTERDBA.Funcionalidades VALUES ('Login y Seguridad')
INSERT INTO MASTERDBA.Funcionalidades VALUES ('ABM de Rol')
INSERT INTO MASTERDBA.Funcionalidades VALUES ('ABM de Usuarios (sólo clientes y empresas')
INSERT INTO MASTERDBA.Funcionalidades VALUES ('ABM de Rubro')
INSERT INTO MASTERDBA.Funcionalidades VALUES ('ABM de Visibilidad de Publicación')
INSERT INTO MASTERDBA.Funcionalidades VALUES ('Generar Publicación')
INSERT INTO MASTERDBA.Funcionalidades VALUES ('Comprar/Ofertar')
INSERT INTO MASTERDBA.Funcionalidades VALUES ('Historial del Cliente')
INSERT INTO MASTERDBA.Funcionalidades VALUES ('Calificar al Vendedor')
INSERT INTO MASTERDBA.Funcionalidades VALUES ('Consulta de Facturas Realizadas al Vendedor')
INSERT INTO MASTERDBA.Funcionalidades VALUES ('Listado Estadístico')
GO

--- TABLA MASTERDBA.Roles_Funcionalidades (Administrativo)
DECLARE @IdAdministrativo int
SELECT @IdAdministrativo = IdRol FROM MASTERDBA.Roles WHERE Descripcion = 'Administrativo'
INSERT INTO MASTERDBA.Roles_Funcionalidades
SELECT @IdAdministrativo, IdFuncionalidad, 1 FROM MASTERDBA.Funcionalidades

--- TABLA MASTERDBA.Usuarios (Administrativo)
INSERT INTO MASTERDBA.Usuarios VALUES ('admin', CONVERT(nvarchar(MAX), HASHBYTES('SHA2_256','w23e'), 2), 0, 1)

--- TABLA MASTERDBA.Usuarios_Roles (Administrativo)
INSERT INTO MASTERDBA.Usuarios_Roles VALUES (@@IDENTITY, @IdAdministrativo, 1)
GO

--- TABLA MASTERDBA.Roles_Funcionalidades (Cliente)
DECLARE @IdCliente int
SELECT @IdCliente = IdRol FROM MASTERDBA.Roles WHERE Descripcion = 'Cliente'
INSERT INTO MASTERDBA.Roles_Funcionalidades
SELECT @IdCliente, IdFuncionalidad, 1 FROM MASTERDBA.Funcionalidades
WHERE NOT Descripcion = 'ABM de Rol'
AND NOT Descripcion = 'ABM de Usuarios (sólo clientes y empresas'
AND NOT Descripcion = 'ABM de Rubro'
AND NOT Descripcion = 'ABM de Visibilidad de Publicación'
AND NOT Descripcion = 'Listado Estadístico'

--- TABLA MASTERDBA.Usuarios (Cliente)
INSERT INTO MASTERDBA.Usuarios -- Usuarios que publicaron
SELECT DISTINCT
	LOWER(Publ_Cli_Apeliido) + '_' + LOWER(Publ_Cli_Nombre), CONVERT(nvarchar(MAX), HASHBYTES('SHA2_256', 'w' + CONVERT(varchar(18), Publ_Cli_Dni)), 2), 0, 1
FROM #Maestra
WHERE NOT Publ_Cli_Dni IS NULL
AND NOT Publ_Cli_Apeliido IS NULL
AND NOT Publ_Cli_Nombre IS NULL

INSERT INTO MASTERDBA.Usuarios -- Usuarios que compraron
SELECT DISTINCT
	LOWER(Cli_Apeliido) + '_' + LOWER(Cli_Nombre), CONVERT(nvarchar(MAX), HASHBYTES('SHA2_256', 'w' + CONVERT(varchar(18), Cli_Dni)), 2), 0, 1
FROM #Maestra
WHERE NOT Cli_Dni IS NULL
AND NOT Cli_Apeliido IS NULL
AND NOT Cli_Nombre IS NULL
AND NOT LOWER(Cli_Apeliido) + '_' + LOWER(Cli_Nombre) IN (SELECT UserName FROM MASTERDBA.Usuarios)

--- TABLA MASTERDBA.Usuarios_Roles (Cliente)
INSERT INTO MASTERDBA.Usuarios_Roles
SELECT DISTINCT U.IdUsuario, @IdCliente, 1 FROM #Maestra M, MASTERDBA.Usuarios U
WHERE LOWER(M.Publ_Cli_Apeliido) + '_' + LOWER(M.Publ_Cli_Nombre) = U.UserName
OR LOWER(M.Cli_Apeliido) + '_' + LOWER(M.Cli_Nombre) = U.UserName
GO

--- TABLA MASTERDBA.Roles_Funcionalidades (Empresa)
DECLARE @IdEmpresa int
SELECT @IdEmpresa = IdRol FROM MASTERDBA.Roles WHERE Descripcion = 'Empresa'
INSERT INTO MASTERDBA.Roles_Funcionalidades
SELECT @IdEmpresa, IdFuncionalidad, 1 FROM MASTERDBA.Funcionalidades
WHERE Descripcion = 'Login y Seguridad'
AND Descripcion = 'Generar Publicación'
AND Descripcion = 'Consulta de Facturas Realizadas al Vendedor'

--- TABLA MASTERDBA.Usuarios (Empresa)
INSERT INTO MASTERDBA.Usuarios

SELECT DISTINCT
	'empresa' + SUBSTRING(Publ_Empresa_Razon_Social, 17, 2), CONVERT(nvarchar(MAX), HASHBYTES('SHA2_256', 'w' + CONVERT(varchar(12), SUBSTRING(Publ_Empresa_Cuit, 1, 2) + SUBSTRING(Publ_Empresa_Cuit, 4, 8) + SUBSTRING(Publ_Empresa_Cuit, 13, 2))), 2), 0,	1
FROM #Maestra
WHERE NOT Publ_Empresa_Cuit IS NULL
AND NOT Publ_Empresa_Razon_Social IS NULL

--- TABLA MASTERDBA.Usuarios_Roles (Empresa)
INSERT INTO MASTERDBA.Usuarios_Roles
SELECT DISTINCT U.IdUsuario, @IdEmpresa, 1 FROM #Maestra M, MASTERDBA.Usuarios U
WHERE 'empresa' + SUBSTRING(M.Publ_Empresa_Razon_Social, 17, 2) = U.UserName
GO

--- TABLA MASTERDBA.Clientes
INSERT INTO MASTERDBA.Clientes -- Clientes que publicaron
SELECT DISTINCT
	U.IdUsuario, M.Publ_Cli_Apeliido, M.Publ_Cli_Nombre, 'DNI', M.Publ_Cli_Dni, M.Publ_Cli_Mail, NULL, M.Publ_Cli_Dom_Calle, M.Publ_Cli_Nro_Calle, M.Publ_Cli_Piso, M.Publ_Cli_Depto, NULL, M.Publ_Cli_Cod_Postal, M.Publ_Cli_Fecha_Nac, GETDATE()
FROM #Maestra M, MASTERDBA.Usuarios U
WHERE LOWER(M.Publ_Cli_Apeliido) + '_' + LOWER(M.Publ_Cli_Nombre) = U.UserName
GO

INSERT INTO MASTERDBA.Clientes -- Clientes que compraron
SELECT DISTINCT
	U.IdUsuario, M.Cli_Apeliido, M.Cli_Nombre, 'DNI', M.Cli_Dni, Cli_Mail, NULL, M.Cli_Dom_Calle, M.Cli_Nro_Calle, M.Cli_Piso, M.Cli_Depto, NULL, M.Cli_Cod_Postal, M.Cli_Fecha_Nac, GETDATE()
FROM #Maestra M, MASTERDBA.Usuarios U
WHERE LOWER(M.Cli_Apeliido) + '_' + Lower(M.Cli_Nombre) = U.UserName
AND NOT U.IdUsuario IN (SELECT IdUsuario FROM MASTERDBA.Clientes)
GO

--- TABLA MASTERDBA.Empresas
INSERT INTO MASTERDBA.Empresas
SELECT DISTINCT
	U.IdUsuario, M.Publ_Empresa_Razon_Social, M.Publ_Empresa_Mail, NULL, M.Publ_Empresa_Dom_Calle, M.Publ_Empresa_Nro_Calle, M.Publ_Empresa_Piso, M.Publ_Empresa_Depto, NULL, M.Publ_Empresa_Cod_Postal, NULL, M.Publ_Empresa_Cuit, NULL, NULL, GETDATE()
FROM #Maestra M, MASTERDBA.Usuarios U
WHERE 'empresa' + SUBSTRING(M.Publ_Empresa_Razon_Social, 17, 2) = U.UserName
AND NOT M.Publ_Empresa_Razon_Social IS NULL
GO

--- TABLA MASTERDBA.Publicaciones
INSERT INTO MASTERDBA.Publicaciones
SELECT DISTINCT
	M.Publicacion_Cod, M.Publicacion_Descripcion, M.Publicacion_Stock, M.Publicacion_Fecha, M.Publicacion_Fecha_Venc, M.Publicacion_Precio, R.IdRubro, U.IdUsuario, E.IdEstado, T.IdTipo
FROM #Maestra M, MASTERDBA.Usuarios U, MASTERDBA.Estado_Publicacion E, MASTERDBA.Tipo_Publicacion T, MASTERDBA.Rubros R
WHERE ('empresa' + SUBSTRING(M.Publ_Empresa_Razon_Social, 17, 2) = U.UserName
OR LOWER(M.Publ_Cli_Apeliido) + '_' + LOWER(M.Publ_Cli_Nombre) = U.UserName)
AND	CASE Publicacion_Estado	WHEN 'Publicada' THEN 'Finalizada' END = E.Descripcion --THEN 'Activa' END = E.Descripcion
AND	M.Publicacion_Tipo = T.Descripcion
AND	M.Publicacion_Rubro_Descripcion = R.DescripcionLarga
GO

--- TABLA MASTERDBA.Publicaciones_Visibilidad
INSERT INTO MASTERDBA.Publicaciones_Visibilidad
SELECT DISTINCT P.IdPublicacion, V.IdVisibilidad
FROM MASTERDBA.Publicaciones P, MASTERDBA.Visibilidad_Publicacion V, #Maestra M
WHERE M.Publicacion_Cod = P.CodPublicacion
AND M.Publicacion_Visibilidad_Cod = V.CodVisibilidad
GO

--- TABLA MASTERDBA.Facturas
INSERT INTO MASTERDBA.Facturas
SELECT DISTINCT	M.Factura_Nro, P.IdPublicacion, M.Factura_Fecha, M.Factura_Total, FP.IdFormaPago
FROM #Maestra M, MASTERDBA.Publicaciones P, MASTERDBA.Formas_Pago FP
WHERE NOT M.Factura_Nro IS NULL
AND M.Publicacion_Cod = P.CodPublicacion
AND M.Forma_Pago_Desc = FP.Descripcion
GO

--- TABLA MASTERDBA.Facturas_Items
INSERT INTO MASTERDBA.Facturas_Items
SELECT DISTINCT
	M.Factura_Nro,
	CASE M.Item_Factura_Monto
		WHEN M.Publicacion_Visibilidad_Precio
			THEN 'Comisión por Publicación'
		WHEN ROUND(M.Publicacion_Precio * M.Publicacion_Visibilidad_Porcentaje * Item_Factura_Cantidad, 2)
			THEN 'Comisión por Venta'
		WHEN ROUND(M.Publicacion_Precio * M.Publicacion_Visibilidad_Porcentaje * Item_Factura_Cantidad, 2) - 0.01
			THEN 'Comisión por Venta'
		WHEN ROUND(M.Publicacion_Precio * M.Publicacion_Visibilidad_Porcentaje * Item_Factura_Cantidad, 2) + 0.01
			THEN 'Comisión por Venta'
		ELSE 'Varios'
		END Texto,
	M.Item_Factura_Monto,
	M.Item_Factura_Cantidad
FROM #Maestra M, MASTERDBA.Facturas F
WHERE M.Factura_Nro = F.IdFactura
GO

--- TABLA MASTERDBA.Ofertas
INSERT INTO MASTERDBA.Ofertas
SELECT DISTINCT P.IdPublicacion, M.Oferta_Fecha, M.Oferta_Monto, 0, U.IdUsuario, NULL
FROM #Maestra M, MASTERDBA.Publicaciones P, MASTERDBA.Usuarios U
WHERE LOWER(M.Cli_Apeliido) + '_' + LOWER(M.Cli_Nombre) = U.UserName
AND M.Publicacion_Cod = P.CodPublicacion
AND NOT M.Oferta_Fecha IS NULL
GO

--- TABLA MASTERDBA.Compras y TABLA MASTERDBA.Calificaciones
DECLARE @IdPublicacion int
DECLARE @IdPublicacionAnt int
DECLARE @Compra_Fecha datetime
DECLARE @Compra_FechaAnt datetime
DECLARE @Compra_Cantidad numeric(18,0)
DECLARE @Compra_CantidadAnt numeric(18,0)
DECLARE @IdUsuario int
DECLARE @IdUsuarioAnt int
DECLARE @Calificacion_Codigo numeric(18,0)
DECLARE @Calificacion_Cant_Estrellas numeric(18,0)
DECLARE @Calificacion_Descripcion nvarchar(255)
DECLARE @IdCompra as int

DECLARE C_Compras CURSOR FOR
	SELECT DISTINCT
		P.IdPublicacion, M.Compra_Fecha, M.Compra_Cantidad, U.IdUsuario, M.Calificacion_Codigo, M.Calificacion_Cant_Estrellas, M.Calificacion_Descripcion
	FROM #Maestra M, MASTERDBA.Publicaciones P, MASTERDBA.Usuarios U
	WHERE M.Publicacion_Cod = P.CodPublicacion
	AND LOWER(M.Cli_Apeliido) + '_' + LOWER(M.Cli_Nombre) = U.UserName
	AND NOT M.Compra_Fecha IS NULL
	AND	NOT M.Calificacion_Codigo IS NULL
	ORDER BY P.IdPublicacion, M.Compra_Fecha, M.Compra_Cantidad, U.IdUsuario, M.Calificacion_Codigo

OPEN C_Compras

FETCH NEXT FROM C_Compras
INTO @IdPublicacion, @Compra_Fecha, @Compra_Cantidad, @IdUsuario, @Calificacion_Codigo, @Calificacion_Cant_Estrellas, @Calificacion_Descripcion

-- COMPRAS: 97265
-- CALIFICACIONES: 97362

WHILE @@FETCH_STATUS = 0
BEGIN
	INSERT INTO MASTERDBA.Compras
	SELECT @IdPublicacion, @Compra_Fecha, @Compra_Cantidad, 0, @IdUsuario

	SET @IdCompra = @@IDENTITY
	SET @IdPublicacionAnt = @IdPublicacion
	SET @Compra_FechaAnt = @Compra_Fecha
	SET @Compra_CantidadAnt = @Compra_Cantidad
	SET @IdUsuarioAnt = @IdUsuario

	WHILE (@@FETCH_STATUS = 0) AND (@IdPublicacion = @IdPublicacionAnt)	AND (@Compra_Fecha = @Compra_FechaAnt) AND (@Compra_Cantidad = @Compra_CantidadAnt) AND (@IdUsuario = @IdUsuarioAnt)
	BEGIN
		INSERT INTO MASTERDBA.Calificaciones
		SELECT @Calificacion_Codigo, @IdCompra, @Calificacion_Cant_Estrellas, @Calificacion_Descripcion

		FETCH NEXT FROM C_Compras
		INTO @IdPublicacion, @Compra_Fecha, @Compra_Cantidad, @IdUsuario, @Calificacion_Codigo, @Calificacion_Cant_Estrellas, @Calificacion_Descripcion
	END
END

CLOSE C_Compras
DEALLOCATE C_Compras

GO