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

--- TABLA MASTERDBA.Publicaciones_Estado
Insert Into MASTERDBA.Publicaciones_Estado Values ('Borrador')
Insert Into MASTERDBA.Publicaciones_Estado Values ('Activa')
Insert Into MASTERDBA.Publicaciones_Estado Values ('Pausada')
Insert Into MASTERDBA.Publicaciones_Estado Values ('Finalizada')
--Insert Into MASTERDBA.Publicaciones_Estado Select Distinct Publicacion_Estado From #Maestra
GO

--- TABLA MASTERDBA.Publicaciones_Tipo
Insert Into MASTERDBA.Publicaciones_Tipo 
Select Distinct Publicacion_Tipo From #Maestra
GO

--- TABLA MASTERDBA.FormasPago
Insert Into MASTERDBA.FormasPago
Select Distinct Forma_Pago_Desc From #Maestra
Where Not Forma_Pago_Desc Is NULL
GO

--- TABLA MASTERDBA.Rubros
Insert Into MASTERDBA.Rubros
Select Distinct Publicacion_Rubro_Descripcion From #Maestra
Where Not Publicacion_Rubro_Descripcion Is NULL
GO

--- TABLA MASTERDBA.Visibilidad
Insert Into MASTERDBA.Visibilidad
Select Distinct 
	Publicacion_Visibilidad_Cod, Publicacion_Visibilidad_Desc, Publicacion_Visibilidad_Precio, Publicacion_Visibilidad_Porcentaje, 0
From 
	#Maestra
Where Not Publicacion_Visibilidad_Cod Is NULL
GO

--- TABLA MASTERDBA.Roles
Insert Into MASTERDBA.Roles Values ('Administrativo', 'H')
Insert Into MASTERDBA.Roles Values ('Empresa', 'H')
Insert Into MASTERDBA.Roles Values ('Cliente', 'H')
GO

--- TABLA MASTERDBA.Funcionalidades
Insert Into MASTERDBA.Funcionalidades Values ('Login y seguridad')
Insert Into MASTERDBA.Funcionalidades Values ('ABM de Rol')
Insert Into MASTERDBA.Funcionalidades Values ('ABM de Usuarios (solo cliente y empresas')
Insert Into MASTERDBA.Funcionalidades Values ('ABM de Rubro')
Insert Into MASTERDBA.Funcionalidades Values ('ABM visibilidad de publicación')
Insert Into MASTERDBA.Funcionalidades Values ('Generar publicación')
Insert Into MASTERDBA.Funcionalidades Values ('Comprar/Ofertar')
Insert Into MASTERDBA.Funcionalidades Values ('Historial del cliente')
Insert Into MASTERDBA.Funcionalidades Values ('Calificar al Vendedor')
Insert Into MASTERDBA.Funcionalidades Values ('Consulta de facturas realizadas al vendedor')
Insert Into MASTERDBA.Funcionalidades Values ('Listado Estadístico')
GO

--- TABLA MASTERDBA.Roles_Funcionalidades
Declare @IdAdmin Int
Select @IdAdmin = IdRol From MASTERDBA.Roles Where Descripcion = 'Administrativo'
Insert Into MASTERDBA.Roles_Funcionalidades Select @IdAdmin, IdFuncionalidad From MASTERDBA.Funcionalidades
--- TABLA MASTERDBA.Usuarios (solo admin)
Insert Into MASTERDBA.Usuarios Values ('admin', 'w23e', 0, 'H')
Insert Into MASTERDBA.Usuarios_Roles Values (@@IDENTITY, @IdAdmin)
GO

--- TABLA MASTERDBA.Usuarios (Empresas)
Insert Into MASTERDBA.Usuarios 
Select Distinct 'empresa' + SUBSTRING(Publ_Empresa_Razon_Social,17,2), '123456', 0, 'H' 
From #Maestra 
Where Not Publ_Empresa_Razon_Social Is Null
GO

Insert Into MASTERDBA.Empresas
Select 
	Distinct IdUsuario, Publ_Empresa_Razon_Social, Publ_Empresa_Mail, NULL, Publ_Empresa_Dom_Calle, Publ_Empresa_Nro_Calle, Publ_Empresa_Piso,
	Publ_Empresa_Depto, NULL, Publ_Empresa_Cod_Postal, NULL, Publ_Empresa_Cuit, NULL, NULL, GetDate()
From 
	#Maestra, MASTERDBA.Usuarios 
Where 
	'empresa' + SUBSTRING(Publ_Empresa_Razon_Social,17,2) = UserName And
	Not Publ_Empresa_Razon_Social Is Null
GO

--- TABLA MASTERDBA.Usuarios (Clientes - Solo los que publican)
Insert Into MASTERDBA.Usuarios 
Select Distinct Lower(Publ_Cli_Apeliido) + '_' + Lower(Publ_Cli_Nombre) , '123456', 0, 'H' 
From #Maestra 
Where Not Publ_Cli_Apeliido Is Null
GO
--
Insert Into MASTERDBA.Clientes 
Select 
	Distinct IdUsuario, Publ_Cli_Apeliido, Publ_Cli_Nombre, 'DNI', Publ_Cli_Dni, Publ_Cli_Mail, NULL, Publ_Cli_Dom_Calle, Publ_Cli_Nro_Calle, 
	Publ_Cli_Piso, Publ_Cli_Depto, NULL, Publ_Cli_Cod_Postal, Publ_Cli_Fecha_Nac, GetDate()
From 
	#Maestra, MASTERDBA.Usuarios 
Where 
	Lower(Publ_Cli_Apeliido) + '_' + Lower(Publ_Cli_Nombre) = UserName And
	Not Publ_Cli_Apeliido Is Null

--- TABLA MASTERDBA.Usuarios (Clientes - Solo los que compran)
Insert Into MASTERDBA.Usuarios 
Select Distinct Lower(Cli_Apeliido) + '_' + Lower(Cli_Nombre) , '123456', 0, 'H' 
From #Maestra 
Where 
	Not Cli_Apeliido Is Null And
	Lower(Cli_Apeliido) + '_' + Lower(Cli_Nombre) Not In (Select UserName From MASTERDBA.Usuarios)
GO
--
Insert Into MASTERDBA.Clientes 
Select 
	Distinct IdUsuario, Cli_Apeliido, Cli_Nombre, 'DNI', Cli_Dni, Cli_Mail, NULL, Cli_Dom_Calle, Cli_Nro_Calle, 
	Cli_Piso, Cli_Depto, NULL, Cli_Cod_Postal, Cli_Fecha_Nac, GetDate()
From 
	#Maestra, MASTERDBA.Usuarios 
Where 
	Not Cli_Apeliido Is Null And
	Not Lower(Cli_Apeliido) + '_' + Lower(Cli_Nombre) IN (Select UserName From MASTERDBA.Usuarios)
GO

--- TABLA MASTERDBA.Publicaciones (Empresas)
Insert Into MASTERDBA.Publicaciones 
Select Distinct 
	Publicacion_Cod, Publicacion_Descripcion, Publicacion_Stock, Publicacion_Fecha, Publicacion_Fecha_Venc, Publicacion_Precio, 0, IdRubro, Idusuario,
	IdEstado, IdTipo, 0
From
	#Maestra, MASTERDBA.Rubros R, MASTERDBA.Usuarios, MASTERDBA.Publicaciones_Estado E, MASTERDBA.Publicaciones_Tipo T
Where
	'empresa' + SUBSTRING(Publ_Empresa_Razon_Social,17,2) = UserName And
	---Publicacion_Estado = E.Descripcion And
	Case Publicacion_Estado When 'Publicada' Then 'Finalizada' End = E.Descripcion And
	Publicacion_Tipo = T.Descripcion And
	Publicacion_Rubro_Descripcion = R.Descripcion -- 55814
GO

--- TABLA MASTERDBA.Publicaciones (Clientes)
Insert Into MASTERDBA.Publicaciones 
Select Distinct 
	Publicacion_Cod, Publicacion_Descripcion, Publicacion_Stock, Publicacion_Fecha, Publicacion_Fecha_Venc, Publicacion_Precio, 0, IdRubro, Idusuario,
	IdEstado, IdTipo, 0
From
	#Maestra, MASTERDBA.Rubros R, MASTERDBA.Usuarios, MASTERDBA.Publicaciones_Estado E, MASTERDBA.Publicaciones_Tipo T
Where
	Lower(Publ_Cli_Apeliido) + '_' + Lower(Publ_Cli_Nombre) = UserName And
	---Publicacion_Estado = E.Descripcion And
	Case Publicacion_Estado When 'Publicada' Then 'Finalizada' End = E.Descripcion And
	Publicacion_Tipo = T.Descripcion And
	Publicacion_Rubro_Descripcion = R.Descripcion -- 2912
GO

--- TABLA MASTERDBA.Publicaciones_Visibilidad
Insert Into MASTERDBA.Publicaciones_Visibilidad
Select Distinct 
	Publicacion_Cod, Publicacion_Visibilidad_Cod
From
	#Maestra, MASTERDBA.Usuarios
GO

--- TABLA MASTERDBA.Facturas
Insert Into MASTERDBA.Facturas
Select Distinct
	Factura_Nro, Publicacion_Cod, Factura_Fecha, Factura_Total, IdFormaPago
From
	#Maestra, MASTERDBA.FormasPago
Where
	Forma_Pago_Desc = Descripcion
GO 

--- TABLA MASTERDBA.Facturas_Items
Insert Into MASTERDBA.Facturas_Items
Select Distinct
	Factura_Nro, Item_Factura_Monto, Item_Factura_Cantidad
From
	#Maestra
Where
	Not Factura_Nro Is Null
GO 

--- TABLA MASTERDBA.Ofertas
Insert Into MASTERDBA.Ofertas
Select Distinct
	Publicacion_Cod, Oferta_Fecha, Oferta_Monto, IdUsuario
From
	#Maestra, MASTERDBA.Usuarios
Where
	Lower(Cli_Apeliido) + '_' + Lower(Cli_Nombre) = UserName And
	Not Oferta_Fecha Is Null 
GO

--- TABLA MASTERDBA.Compras y MASTERDBA.Calificaciones
Declare @PCodigo Numeric(18,0)
Declare @PCodigoAnt Numeric(18,0)
Declare @Fecha DateTime
Declare @FechaAnt DateTime
Declare @Cantidad Numeric(18,0)
Declare @CantidadAnt Numeric(18,0)
Declare @IdUsuario Int
Declare @IdUsuarioAnt Int
Declare @CCodigo Numeric(18,0)
Declare @Estrellas Numeric(18,0)
Declare @Descripcion nvarchar(255)
Declare @Id as Int

Declare C_Comp Cursor For
	Select Distinct
		Publicacion_Cod, Compra_Fecha, Compra_Cantidad, IdUsuario, Calificacion_Codigo, Calificacion_Cant_Estrellas, Calificacion_Descripcion
	From
		#Maestra, MASTERDBA.Usuarios
	Where
		-- Publicacion_Cod = 12774 And
		Lower(Cli_Apeliido) + '_' + Lower(Cli_Nombre) = UserName And
		Not Compra_Fecha Is Null And
		Not Calificacion_Codigo Is Null
	Order By
		Publicacion_Cod, Compra_Fecha, Compra_Cantidad, IdUsuario, Calificacion_Codigo

Open C_Comp

-- COMPRAS: 97265
-- CALIFICACION: 97362

Fetch Next From C_Comp Into @PCodigo, @Fecha, @Cantidad, @IdUsuario, @CCodigo, @Estrellas, @Descripcion

While @@FETCH_STATUS = 0
Begin	
	Insert Into MASTERDBA.Compras Select @PCodigo, @Fecha, @Cantidad, @IdUsuario

	Set @Id = @@IDENTITY
	Set @PCodigoAnt = @PCodigo
	Set @FechaAnt = @Fecha
	Set @CantidadAnt = @Cantidad
	Set @IdUsuarioAnt = @IdUsuario

	While (@@FETCH_STATUS = 0) And (@PCodigo = @PCodigoAnt) And (@Fecha = @FechaAnt) And (@Cantidad = @CantidadAnt) And (@IdUsuario = @IdUsuarioAnt)
	Begin
		Insert Into MASTERDBA.Calificaciones Select @CCodigo, @Id, @Estrellas, @Descripcion

		Fetch Next From C_Comp Into @PCodigo, @Fecha, @Cantidad, @IdUsuario, @CCodigo, @Estrellas, @Descripcion
	End
End

Close C_Comp
Deallocate C_Comp

GO
