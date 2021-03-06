USE [GD1C2016]
GO
/****** Object:  View [MASTERDBA].[VW_Compras]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP VIEW [MASTERDBA].[VW_Compras]
GO
/****** Object:  View [MASTERDBA].[VW_Facturas]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP VIEW [MASTERDBA].[VW_Facturas]
GO
/****** Object:  View [MASTERDBA].[VW_Calificaciones]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP VIEW [MASTERDBA].[VW_Calificaciones]
GO
/****** Object:  View [MASTERDBA].[VW_Publicaciones]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP VIEW [MASTERDBA].[VW_Publicaciones]
GO
/****** Object:  View [MASTERDBA].[VW_Ofertas]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP VIEW [MASTERDBA].[VW_Ofertas]
GO
/****** Object:  View [MASTERDBA].[VW_Usuarios]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP VIEW [MASTERDBA].[VW_Usuarios]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_UpdateVisibilidad]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_UpdateVisibilidad]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_UpdateRol]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_UpdateRol]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_UpdatePublicacion]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_UpdatePublicacion]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_UpdateEmpresa]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_UpdateEmpresa]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_UpdateCliente]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_UpdateCliente]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_ResetCountLogin]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_ResetCountLogin]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_PublicacionesACerrar]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_PublicacionesACerrar]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertVisibilidad]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_InsertVisibilidad]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertUsuarioRol]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_InsertUsuarioRol]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertUsuario]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_InsertUsuario]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertRubro]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_InsertRubro]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertRolFuncionalidad]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_InsertRolFuncionalidad]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertRol]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_InsertRol]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertPublicacionVisibilidad]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_InsertPublicacionVisibilidad]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertPublicacion]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_InsertPublicacion]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertOferta]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_InsertOferta]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertNewCalificacion]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_InsertNewCalificacion]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertFacturaItem]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_InsertFacturaItem]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertFactura]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_InsertFactura]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertEmpresa]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_InsertEmpresa]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertCompra]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_InsertCompra]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertCliente]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_InsertCliente]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_IncrementCountLogin]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_IncrementCountLogin]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetVisibilidades]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetVisibilidades]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetVisibilidadByDescripcion]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetVisibilidadByDescripcion]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetUsuarioByUserName]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetUsuarioByUserName]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetUltimasCalificaciones]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetUltimasCalificaciones]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetTiposPublicacion]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetTiposPublicacion]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetRubros]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetRubros]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetRolFuncionalidades]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetRolFuncionalidades]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetRolesUsuario]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetRolesUsuario]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetRoles]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetRoles]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetRolByDescripcion]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetRolByDescripcion]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetReputacion]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetReputacion]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetPublicacionesVisibilidad]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetPublicacionesVisibilidad]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetPublicacion]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetPublicacion]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetListadoVendedoresProductosNoVendidos]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetListadoVendedoresProductosNoVendidos]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetListadoVendedoresMontos]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetListadoVendedoresMontos]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetListadoVendedoresFacturas]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetListadoVendedoresFacturas]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetListadoClientesProductosComprados]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetListadoClientesProductosComprados]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetFuncionalidades]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetFuncionalidades]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetFuncionalidadByDescripcion]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetFuncionalidadByDescripcion]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetFacturas]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetFacturas]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetEstados]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetEstados]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetEmpresaById]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetEmpresaById]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetEmpresaByCUIT]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetEmpresaByCUIT]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetComprasPendientesCalificacion]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetComprasPendientesCalificacion]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetComprasOfertas]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetComprasOfertas]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetClienteByTipoDocNroDoc]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetClienteByTipoDocNroDoc]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetClienteById]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetClienteById]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetCantidadCalificacionesDadas]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetCantidadCalificacionesDadas]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetCalificacionesUsuario]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_GetCalificacionesUsuario]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_FindVisibilidades]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_FindVisibilidades]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_FindRubros]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_FindRubros]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_FindRoles]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_FindRoles]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_FindPublicaciones]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_FindPublicaciones]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_FindFacturas]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_FindFacturas]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_FindEmpresas]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_FindEmpresas]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_FindClientes]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_FindClientes]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_DeleteVisibilidad]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_DeleteVisibilidad]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_DeleteUsuariosRol]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_DeleteUsuariosRol]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_DeleteUsuarioRol]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_DeleteUsuarioRol]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_DeleteUsuario]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_DeleteUsuario]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_DeleteRolFuncionalidad]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_DeleteRolFuncionalidad]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_DeleteRol]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_DeleteRol]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_ConfigurarFechas]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_ConfigurarFechas]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_CerrarPublicacion]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_CerrarPublicacion]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_BloqUser]    Script Date: 04/07/2016 05:41:29 a.m. ******/
DROP PROCEDURE [MASTERDBA].[SP_BloqUser]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_BloqUser]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_BloqUser] 
	@UserName nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [GD1C2016].[MASTERDBA].[Usuarios]
	SET	[Activo] = 0
	WHERE UPPER([UserName]) = UPPER(@UserName)
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_CerrarPublicacion]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_CerrarPublicacion] 
	@IdPublicacion numeric(18,2)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @IdEstadoFinalizada int,
			@IdOferta int,
			@Fecha datetime,
			@Envio bit,
			@IdUsuario int,
			@IdCompra int

	SELECT @IdEstadoFinalizada = E.[IdEstado] FROM [GD1C2016].[MASTERDBA].[Estado_Publicacion] E WHERE E.[Descripcion] = 'Finalizada'

	UPDATE [GD1C2016].[MASTERDBA].[Publicaciones]
	SET [IdEstado] = @IdEstadoFinalizada
	WHERE [IdPublicacion] = @IdPublicacion
	AND [IdEstado] <> @IdEstadoFinalizada

	IF (SELECT P.[TipoDescripcion] FROM [GD1C2016].[MASTERDBA].[VW_Publicaciones] P WHERE P.[IdPublicacion] = @IdPublicacion) = 'Subasta'
	BEGIN
		SELECT TOP(1) @IdOferta = O.[IdOferta], @Fecha = O.[Fecha], @Envio = O.[Envio], @IdUsuario = O.[IdUsuario]
		FROM [GD1C2016].[MASTERDBA].[Ofertas] O
		WHERE O.[IdPublicacion] = @IdPublicacion
		ORDER BY O.[Monto] DESC

		INSERT INTO [GD1C2016].[MASTERDBA].[Compras]
		VALUES (@IdPublicacion, @Fecha, 1, @Envio, @IdUsuario)

		SELECT @IdCompra = C.[IdCompra] FROM [GD1C2016].[MASTERDBA].[Compras] C WHERE C.[IdPublicacion] = @IdPublicacion AND C.[Fecha] = @Fecha AND C.[Cantidad] = 1 AND C.[Envio] = @Envio AND C.[IdUsuario] = @IdUsuario

		UPDATE [GD1C2016].[MASTERDBA].[Ofertas]
		SET [IdCompra] = @IdCompra
		WHERE [IdOferta] = @IdOferta
	END

	SELECT C.[IdCompra] FROM [GD1C2016].[MASTERDBA].[Compras] C WHERE C.[IdCompra] = @IdCompra
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_ConfigurarFechas]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_ConfigurarFechas] 
	@Fecha datetime
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE [GD1C2016].[MASTERDBA].[Clientes]
	SET [FechaCreacion] = @Fecha
	WHERE (SELECT CONVERT(date, [FechaCreacion])) = (SELECT CONVERT(date, GETDATE()))

	UPDATE [GD1C2016].[MASTERDBA].[Empresas]
	SET [FechaCreacion] = @Fecha
	WHERE (SELECT CONVERT(date, [FechaCreacion])) = (SELECT CONVERT(date, GETDATE()))

	UPDATE [GD1C2016].[MASTERDBA].[Publicaciones]
	SET [IdEstado] = (SELECT E.[IdEstado] FROM [GD1C2016].[MASTERDBA].[Estado_Publicacion] E WHERE E.[Descripcion] = 'Activa')
	WHERE ((SELECT CONVERT(date, [FechaVencimiento])) > (SELECT CONVERT(date, @Fecha)))
	AND [Stock] > 0
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_DeleteRol]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_DeleteRol] 
	@IdRol int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [GD1C2016].[MASTERDBA].[Roles]
	SET	[Activo] = 0
	WHERE [IdRol] = @IdRol
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_DeleteRolFuncionalidad]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_DeleteRolFuncionalidad] 
	@IdRol int, 
	@IdFuncionalidad int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [GD1C2016].[MASTERDBA].[Roles_Funcionalidades]
	SET	Activa = 0
	WHERE [IdRol] = @IdRol
	AND [IdFuncionalidad] = @IdFuncionalidad
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_DeleteUsuario]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_DeleteUsuario] 
	@IdUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [GD1C2016].[MASTERDBA].[Usuarios]
	SET	[Activo] = 0
	WHERE [IdUsuario] = @IdUsuario
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_DeleteUsuarioRol]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_DeleteUsuarioRol] 
	@IdUsuario int, 
	@IdRol int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [GD1C2016].[MASTERDBA].[Usuarios_Roles]
	SET	Activa = 0
	WHERE [IdUsuario] = @IdUsuario
	AND [IdRol] = @IdRol
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_DeleteUsuariosRol]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_DeleteUsuariosRol] 
	@IdRol int
AS
BEGIN
	SET NOCOUNT ON;

	IF EXISTS	(
				SELECT 1 FROM [GD1C2016].[MASTERDBA].[Usuarios_Roles] UR1, [GD1C2016].[MASTERDBA].[Usuarios_Roles] UR2
				WHERE UR1.[IdRol] = @IdRol AND UR1.[Activa] = 1 AND UR2.[IdUsuario] = UR1.[IdUsuario] AND UR2.[Activa] = 1
				GROUP BY UR2.[IdUsuario] HAVING COUNT(UR2.[IdRol]) = 1
				)
	BEGIN
		SELECT
			UR2.[IdUsuario],
			(SELECT U.[UserName] FROM [GD1C2016].[MASTERDBA].[Usuarios] U WHERE U.[IdUsuario] = UR2.[IdUsuario]) UserName
		FROM [GD1C2016].[MASTERDBA].[Usuarios_Roles] UR1, [GD1C2016].[MASTERDBA].[Usuarios_Roles] UR2
		WHERE UR1.[IdRol] = @IdRol
		AND UR1.[Activa] = 1
		AND UR2.[IdUsuario] = UR1.[IdUsuario]
		AND UR2.[Activa] = 1
		GROUP BY UR2.[IdUsuario]
		HAVING COUNT(UR2.[IdRol]) = 1
	END
	ELSE
	BEGIN
		UPDATE [GD1C2016].[MASTERDBA].[Usuarios_Roles]
		SET	[Activa] = 0
		WHERE [IdRol] = @IdRol
	END
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_DeleteVisibilidad]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_DeleteVisibilidad] 
	@IdVisibilidad int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [GD1C2016].[MASTERDBA].[Visibilidad_Publicacion]
	SET	[Activa] = 0
	WHERE [IdVisibilidad] = @IdVisibilidad
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_FindClientes]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_FindClientes] 
	@FiltroNombre nvarchar(255) = '', 
	@FiltroApellido nvarchar(255) = '', 
	@FiltroEmail nvarchar(255) = '', 
	@FiltroDni numeric(18,0) = 0
AS
BEGIN
	SET NOCOUNT ON;

	SELECT C.[IdUsuario] AS IdUsuario, C.[Nombre] AS Nombre, C.[Apellido] AS Apellido, C.[Calle] AS Calle, C.[Nro] AS NroCalle, C.[CP] AS CodigoPostal, C.[Departamento] AS Departamento, C.[Mail] AS Email, C.[FechaNacimiento] AS FechaNacimiento, C.[Localidad] AS Localidad, C.[NroDoc] AS NroDoc, C.[Piso] AS Piso, C.[Telefono] AS Telefono, C.[TipoDoc] AS TipoDoc, U.[Activo] AS Activo, U.[UserName] AS UserName, U.[PassEncr] AS PasswordEnc
	FROM [GD1C2016].[MASTERDBA].[Clientes] C, [GD1C2016].[MASTERDBA].[Usuarios] U
	WHERE C.[IdUsuario] = U.[IdUsuario] 
	AND (@FiltroNombre = '' OR UPPER(C.[Nombre]) LIKE UPPER(@FiltroNombre) + '%')
	AND (@FiltroApellido = '' OR UPPER(C.[Apellido]) LIKE UPPER(@FiltroApellido) + '%')
	AND (@FiltroEmail = '' OR UPPER(C.[Mail]) LIKE UPPER(@FiltroEmail) + '%')
	AND (@FiltroDni = 0 OR C.[NroDoc] = @FiltroDni)
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_FindEmpresas]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_FindEmpresas] 
	@FiltroRazonSocial nvarchar(255) = '', 
	@FiltroCuit nvarchar(50) = '', 
	@FiltroEmail nvarchar(255) = ''
AS
BEGIN
	SET NOCOUNT ON;

	SELECT E.[IdUsuario] AS IdUsuario, E.[RazonSocial] AS RazonSocial, E.[Ciudad] AS Ciudad, E.[Calle] AS Calle, E.[Nro] AS NroCalle, E.[CP] AS CodigoPostal, E.[Departamento] AS Departamento, E.[Mail] AS Email, E.[Rubro] AS Rubro, E.[Localidad] AS Localidad, E.[CUIT] AS Cuit, E.[Piso] AS Piso, E.[Telefono] AS Telefono, E.[Contacto] AS Contacto, U.[Activo] AS Activo, U.[UserName] AS UserName, U.[PassEncr] AS PasswordEnc
	FROM [GD1C2016].[MASTERDBA].[Empresas] E, [GD1C2016].[MASTERDBA].[Usuarios] U
	WHERE E.[IdUsuario] = U.[IdUsuario]
	AND (@FiltroRazonSocial = '' OR UPPER(E.[RazonSocial]) LIKE UPPER(@FiltroRazonSocial) + '%')
	AND (@FiltroCuit = '' OR UPPER(E.[CUIT]) LIKE UPPER(@FiltroCuit) + '%')
	AND (@FiltroEmail = '' OR UPPER(E.[Mail]) LIKE UPPER(@FiltroEmail) + '%')
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_FindFacturas]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_FindFacturas] 
	@FiltroFechaDesde datetime, 
	@FiltroFechaHasta  datetime, 
	@FiltroImporteDesde numeric(18,2) = 0, 
	@FiltroImporteHasta numeric(18,2) = 0, 
	@FiltroDetallesFactura nvarchar(255) = '', 
	@FiltroDirigidaA nvarchar(255) = '',
	@IdUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT F.[IdFactura], F.[IdPublicacion], F.[Fecha], F.[Total], F.[IdFormaPago]
	FROM [GD1C2016].[MASTERDBA].[VW_Facturas] F, [GD1C2016].[MASTERDBA].[Facturas_Items] I
	WHERE F.[IdFactura] = I.[IdFactura]
	AND F.[IdUsuario] = @IdUsuario
	AND F.[Fecha] BETWEEN @FiltroFechaDesde AND @FiltroFechaHasta
	AND (@FiltroImporteDesde = 0 OR F.[Total] >= @FiltroImporteDesde)
	AND (@FiltroImporteHasta = 0 OR F.[Total] <= @FiltroImporteHasta)
	AND (@FiltroDetallesFactura = '' OR UPPER(I.[Concepto]) LIKE '%' + UPPER(@FiltroDetallesFactura) + '%')
	AND (@FiltroDirigidaA = '' OR UPPER(F.[NombreUsuario]) LIKE '%' + UPPER(@FiltroDirigidaA) + '%')
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_FindPublicaciones]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_FindPublicaciones] 
	@FiltroDescripcion nvarchar(255) = '',
	@FiltroIdRubro int = 0
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		P.[IdPublicacion], P.[Descripcion], P.[Stock], P.[FechaInicio], P.[FechaVencimiento], P.[Precio], P.[PrecioReserva], P.[IdRubro], P.[DescripcionCorta] AS RubroDescripcionCorta, P.[DescripcionLarga] AS RubroDescripcionLarga, P.[IdUsuario], P.[NombreUsuario], P.[IdEstado], P.[EstadoDescripcion], P.[Envio], P.[IdTipo], P.[TipoDescripcion], P.[TipoEnvio], P.[IdVisibilidad], P.[VisibilidadDescripcion], V.[Precio] As VisibilidadPrecio, V.[Porcentaje], V.[EnvioPorcentaje]
	FROM
		[GD1C2016].[MASTERDBA].[VW_Publicaciones] P,
		[GD1C2016].[MASTERDBA].[Visibilidad_Publicacion] V
	WHERE P.[IdVisibilidad] = V.[IdVisibilidad]
	AND P.[EstadoDescripcion] IN ('Activa', 'Pausada')
	AND P.[VisibilidadActual] = 1
	AND (P.[Stock] > 0 OR P.[PrecioReserva] > 0)
	AND (@FiltroDescripcion = '' OR P.[Descripcion] LIKE '%' + @FiltroDescripcion + '%')
	AND (@FiltroIdRubro = 0 OR P.[IdRubro] = @FiltroIdRubro)
	ORDER BY V.[Precio] DESC, P.[IdPublicacion] ASC
END


GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_FindRoles]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_FindRoles] 
	@FiltroNombre nvarchar(100) = '', 
	@FiltroFuncionalidad int = 0, 
	@FiltroEstado bit = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT R.[IdRol], R.[Descripcion], R.[Activo]
	FROM [GD1C2016].[MASTERDBA].[Roles] R, [GD1C2016].[MASTERDBA].[Roles_Funcionalidades] RF
	WHERE R.[IdRol] = RF.[IdRol]
	AND RF.[Activa] = 1
	AND (@FiltroNombre = '' OR UPPER(R.[Descripcion]) LIKE UPPER(@FiltroNombre) + '%')
	AND (@FiltroFuncionalidad = 0 OR RF.[IdFuncionalidad] = @FiltroFuncionalidad)
	AND (@FiltroEstado IS NULL OR R.[Activo] = @FiltroEstado)
	GROUP BY R.[IdRol], R.[Descripcion], R.[Activo]
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_FindRubros]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_FindRubros] 
	@FiltroDescripcionCorta nvarchar(25) = '', 
	@FiltroDescripcionLarga nvarchar(100) = ''
AS
BEGIN
	SET NOCOUNT ON;

	SELECT R.[IdRubro] as IdRubro, R.[DescripcionCorta] as DescripcionCorta, R.[DescripcionLarga] as DescripcionLarga
	FROM [GD1C2016].[MASTERDBA].[Rubros] R
	WHERE (@FiltroDescripcionCorta = '' OR R.[DescripcionCorta] LIKE @FiltroDescripcionCorta + '%')
	AND (@FiltroDescripcionLarga = '' OR R.[DescripcionLarga] LIKE @FiltroDescripcionLarga + '%')
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_FindVisibilidades]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_FindVisibilidades] 
	@FiltroDescripcion nvarchar(255) = ''
AS
BEGIN
	SET NOCOUNT ON;

	SELECT V.[IdVisibilidad] AS IdVisibilidad, V.[Descripcion] AS Descripcion, V.[EnvioPorcentaje] AS EnvioPorcentaje, V.[Porcentaje] AS Porcentaje, V.[Precio] AS Precio, V.[Activa]
	FROM [GD1C2016].[MASTERDBA].[Visibilidad_Publicacion] V
	WHERE (@FiltroDescripcion = '' OR  V.[Descripcion] LIKE @FiltroDescripcion + '%')
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetCalificacionesUsuario]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetCalificacionesUsuario] 
	@IdUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT CA.[IdCalificacion], CA.[IdCompra], CA.[CantEstrellas], CA.[Descripcion], P.[Descripcion] AS DescripcionPublicacion
	FROM [GD1C2016].[MASTERDBA].[Calificaciones] CA, [GD1C2016].[MASTERDBA].[Compras] CO, [GD1C2016].[MASTERDBA].[Publicaciones] P
	WHERE CA.[IdCompra] = CO.[IdCompra]
	AND CO.[IdPublicacion] = P.[IdPublicacion]
	AND P.IdUsuario = @IdUsuario
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetCantidadCalificacionesDadas]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetCantidadCalificacionesDadas] 
	@CantEstrellas int, 
	@IdUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT COUNT(C.[IdCalificacion])
	FROM [GD1C2016].[MASTERDBA].[VW_Calificaciones] C
	WHERE C.[IdUsuario] = @IdUsuario
	AND C.[CantEstrellas] = @CantEstrellas
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetClienteById]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetClienteById] 
	@IdUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT C.[IdUsuario] AS IdUsuario, C.[Nombre] AS Nombre, C.[Apellido] AS Apellido, C.[Calle] AS Calle, C.[Nro] AS NroCalle, C.[CP] AS CodigoPostal, C.[Departamento] AS Departamento, C.[Mail] AS Email, C.[FechaNacimiento] AS FechaNacimiento, C.[Localidad] AS Localidad, C.[NroDoc] AS NroDoc, C.[Piso] AS Piso, C.[Telefono] AS Telefono, C.[TipoDoc] AS TipoDoc, U.[Activo] AS Activo, U.[UserName] AS UserName, U.[PassEncr] AS PasswordEnc
	FROM [GD1C2016].[MASTERDBA].[Clientes] C, [GD1C2016].[MASTERDBA].[Usuarios] U
	WHERE C.[IdUsuario] = U.[IdUsuario]
	AND C.[IdUsuario] = @IdUsuario
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetClienteByTipoDocNroDoc]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetClienteByTipoDocNroDoc] 
	@TipoDoc nvarchar(50), 
	@NroDoc numeric(18,0)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT C.[IdUsuario] AS IdUsuario, C.[Nombre] AS Nombre, C.[Apellido] AS Apellido, C.[Calle] AS Calle, C.[Nro] AS NroCalle, C.[CP] AS CodigoPostal, C.[Departamento] AS Departamento, C.[Mail] AS Email, C.[FechaNacimiento] AS FechaNacimiento, C.[Localidad] AS Localidad, C.[NroDoc] AS NroDoc, C.[Piso] AS Piso, C.[Telefono] AS Telefono, C.[TipoDoc] AS TipoDoc, U.[Activo] AS Activo, U.[UserName] AS UserName, U.[PassEncr] AS PasswordEnc
	FROM [GD1C2016].[MASTERDBA].[Clientes] C, [GD1C2016].[MASTERDBA].[Usuarios] U
	WHERE C.[IdUsuario] = U.[IdUsuario]
	AND UPPER(C.[TipoDoc]) = UPPER(@TipoDoc)
	AND C.[NroDoc] = @NroDoc
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetComprasOfertas]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetComprasOfertas] 
	@IdUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		C.[IdCompra] AS Id,
		C.[IdPublicacion],
		C.[Fecha],
		C.[Cantidad],
		C.[IdUsuario],
		P.[TipoDescripcion] AS TipoPublicacion,
		C.[Descripcion] AS DescripcionPublicacion,
		P.[NombreUsuario] AS Vendedor,
		NULL AS Adjudicada,
		P.[Precio]
	FROM
		[GD1C2016].[MASTERDBA].[VW_Compras] C,
		[GD1C2016].[MASTERDBA].[VW_Publicaciones] P
	WHERE C.[IdPublicacion] = P.[IdPublicacion]
	AND C.[IdRubro] = P.[IdRubro]
	AND P.[VisibilidadActual] = 1
	AND C.[IdUsuario] = @IdUsuario
	AND C.[IdCompra] NOT IN (SELECT O.[IdCompra] FROM [GD1C2016].[MASTERDBA].[Ofertas] O WHERE O.[IdCompra] IS NOT NULL)
	UNION ALL
	SELECT
		O.[IdOferta] AS Id,
		O.[IdPublicacion],
		O.[Fecha],
		1 AS Cantidad,
		O.[IdUsuario],
		P.[TipoDescripcion] AS TipoPublicacion,
		O.[Descripcion] AS DescripcionPublicacion,
		P.[NombreUsuario] AS Vendedor,
		CASE WHEN O.[IdCompra] IS NOT NULL THEN 'Sí' ELSE 'No' END AS Adjudicada,
		O.[Monto] AS Precio
	FROM
		[GD1C2016].[MASTERDBA].[VW_Ofertas] O,
		[GD1C2016].[MASTERDBA].[VW_Publicaciones] P
	WHERE O.[IdPublicacion] = P.[IdPublicacion]
	AND O.[IdRubro] = P.[IdRubro]
	AND P.[VisibilidadActual] = 1
	AND O.[IdUsuario] = @IdUsuario
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetComprasPendientesCalificacion]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetComprasPendientesCalificacion] 
	@IdUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT CO.[IdCompra], CO.[IdPublicacion], CO.[Fecha], CO.[Cantidad], CO.[IdUsuario], P.[TipoDescripcion] AS TipoPublicacion, P.[Descripcion] AS DescripcionPublicacion, P.[NombreUsuario] AS Vendedor
	FROM [GD1C2016].[MASTERDBA].[Compras] CO, [GD1C2016].[MASTERDBA].[VW_Publicaciones] P
	WHERE CO.[IdPublicacion] = P.[IdPublicacion]
	AND P.[VisibilidadActual] = 1
	AND CO.[IdCompra] NOT IN (SELECT CA.[IdCompra] FROM [GD1C2016].[MASTERDBA].[Calificaciones] CA)
	AND CO.[IdUsuario] = @IdUsuario
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetEmpresaByCUIT]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetEmpresaByCUIT] 
	@CUIT nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT E.[IdUsuario] AS IdUsuario, E.[RazonSocial] AS RazonSocial, E.[Ciudad] AS Ciudad, E.[Calle] AS Calle, E.[Nro] AS NroCalle, E.[CP] AS CodigoPostal, E.[Departamento] AS Departamento, E.[Mail] AS Email, E.[Rubro] AS Rubro, E.[Localidad] AS Localidad, E.[CUIT] AS Cuit, E.[Piso] AS Piso, E.[Telefono] AS Telefono, E.[Contacto] AS Contacto, U.[Activo] AS Activo, U.[UserName] AS UserName, U.[PassEncr] AS PasswordEnc
	FROM [GD1C2016].[MASTERDBA].[Empresas] E, [GD1C2016].[MASTERDBA].[Usuarios] U
	WHERE E.[IdUsuario] = U.[IdUsuario]
	AND UPPER(E.[CUIT]) = UPPER(@CUIT)
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetEmpresaById]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetEmpresaById] 
	@IdUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT E.[IdUsuario] AS IdUsuario, E.[RazonSocial] AS RazonSocial, E.[Ciudad] AS Ciudad, E.[Calle] AS Calle, E.[Nro] AS NroCalle, E.[CP] AS CodigoPostal, E.[Departamento] AS Departamento, E.[Mail] AS Email, E.[Rubro] AS Rubro, E.[Localidad] AS Localidad, E.[CUIT] AS Cuit, E.[Piso] AS Piso, E.[Telefono] AS Telefono, E.[Contacto] AS Contacto, U.[Activo] AS Activo, U.[UserName] AS UserName, U.[PassEncr] AS PasswordEnc
	FROM [GD1C2016].[MASTERDBA].[Empresas] E, [GD1C2016].[MASTERDBA].[Usuarios] U
	WHERE E.[IdUsuario] = U.[IdUsuario]
	AND E.[IdUsuario] = @IdUsuario
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetEstados]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetEstados] 
	@Descripcion nvarchar(100) = ''
AS
BEGIN
	SET NOCOUNT ON;

	SELECT E.[IdEstado], E.[Descripcion]
	FROM [GD1C2016].[MASTERDBA].[Estado_Publicacion] E
	WHERE (@Descripcion = '' OR (
	(@Descripcion = 'Borrador'
	AND E.[Descripcion] IN ('Activa', @Descripcion)) OR
	(@Descripcion = 'Activa'
	AND E.[Descripcion] IN ('Pausada', 'Finalizada', @Descripcion)) OR
	(@Descripcion = 'Pausada'
	AND E.[Descripcion] IN ('Activa', @Descripcion)) OR
	(@Descripcion = 'Finalizada'
	AND E.[Descripcion] = @Descripcion)))
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetFacturas]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetFacturas] 
	@IdUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT F.[IdFactura], F.[IdPublicacion], F.[Fecha], F.[Total], F.[IdFormaPago]
	FROM [GD1C2016].[MASTERDBA].[VW_Facturas] F
	WHERE F.[IdUsuario] = @IdUsuario
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetFuncionalidadByDescripcion]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetFuncionalidadByDescripcion] 
	@Descripcion nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT F.[IdFuncionalidad], F.[Descripcion]
	FROM [GD1C2016].[MASTERDBA].[Funcionalidades] F
	WHERE UPPER(F.[Descripcion]) = UPPER(@Descripcion)
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetFuncionalidades]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetFuncionalidades] 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT F.[IdFuncionalidad], F.[Descripcion]
	FROM [GD1C2016].[MASTERDBA].[Funcionalidades] F
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetListadoClientesProductosComprados]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetListadoClientesProductosComprados] 
	@NroTrimestre int, 
	@Año int, 
	@IdRubro int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP(5) C1.[IdUsuario], C1.[NombreUsuario], SUM(C1.[CantProductosComprados]) AS CantProductosComprados, C1.[RubroDescripcion]
	FROM
	(
	SELECT C.[IdUsuario], C.[NombreUsuario], SUM(C.[Cantidad]) AS CantProductosComprados, C.[IdRubro], C.[RubroDescripcion]
	FROM [GD1C2016].[MASTERDBA].[VW_Compras] C
	WHERE MONTH(C.[Fecha]) BETWEEN
		(CASE @NroTrimestre WHEN 1 THEN 1 WHEN 2 THEN 4 WHEN 3 THEN 7 WHEN 4 THEN 10 END) AND
		(CASE @NroTrimestre WHEN 1 THEN 3 WHEN 2 THEN 6 WHEN 3 THEN 9 WHEN 4 THEN 12 END)
	AND YEAR(C.[Fecha]) = @Año
	AND (@IdRubro = 0 OR C.[IdRubro] = @IdRubro)
	GROUP BY C.[IdUsuario], C.[NombreUsuario], C.[IdRubro], C.[RubroDescripcion]
	) C1
	GROUP BY C1.[IdUsuario], C1.[NombreUsuario], C1.[IdRubro], C1.[RubroDescripcion]
	ORDER BY SUM(C1.[CantProductosComprados]) DESC
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetListadoVendedoresFacturas]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetListadoVendedoresFacturas] 
	@NroTrimestre int, 
	@Año int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP(5) F1.[IdUsuario], F1.[NombreUsuario], F1.[CantFacturas]
	FROM
	(
	SELECT F.[IdUsuario], F.[NombreUsuario], COUNT(F.[IdFactura]) AS CantFacturas
	FROM [GD1C2016].[MASTERDBA].[VW_Facturas] F
	WHERE MONTH(F.[Fecha]) BETWEEN
		(CASE @NroTrimestre WHEN 1 THEN 1 WHEN 2 THEN 4 WHEN 3 THEN 7 WHEN 4 THEN 10 END) AND
		(CASE @NroTrimestre WHEN 1 THEN 3 WHEN 2 THEN 6 WHEN 3 THEN 9 WHEN 4 THEN 12 END)
	AND YEAR(F.[Fecha]) = @Año
	GROUP BY F.[IdUsuario], F.[NombreUsuario]
	) F1
	ORDER BY F1.[CantFacturas] DESC
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetListadoVendedoresMontos]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetListadoVendedoresMontos] 
	@NroTrimestre int, 
	@Año int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP(5) F1.[IdUsuario], F1.[NombreUsuario], F2.[IdFactura], F1.[Total]
	FROM
	(
	SELECT F.[IdUsuario], F.[NombreUsuario], MAX(F.[Total]) AS Total
	FROM [GD1C2016].[MASTERDBA].[VW_Facturas] F
	WHERE MONTH(F.[Fecha]) BETWEEN
		(CASE @NroTrimestre WHEN 1 THEN 1 WHEN 2 THEN 4 WHEN 3 THEN 7 WHEN 4 THEN 10 END) AND
		(CASE @NroTrimestre WHEN 1 THEN 3 WHEN 2 THEN 6 WHEN 3 THEN 9 WHEN 4 THEN 12 END)
	AND YEAR(F.[Fecha]) = @Año
	GROUP BY F.[IdUsuario], F.[NombreUsuario]
	) F1,
	[GD1C2016].[MASTERDBA].[VW_Facturas] F2
	WHERE F1.[IdUsuario] = F2.[IdUsuario]
	AND F1.[NombreUsuario] = F2.[NombreUsuario]
	AND F1.[Total] = F2.[Total]
	ORDER BY F1.[Total] DESC
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetListadoVendedoresProductosNoVendidos]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetListadoVendedoresProductosNoVendidos] 
	@NroTrimestre int, 
	@Año int, 
	@IdVisibilidad int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP(5) V.[IdUsuario], V.[NombreUsuario], SUM(V.[CantProductosNoVendidos]) AS CantProductosNoVendidos, V.[VisibilidadDescripcion]
	FROM
	(
	SELECT F.[IdUsuario], F.[NombreUsuario], SUM(P.[Stock]) - SUM(I.[Cantidad]) AS CantProductosNoVendidos, P.[IdVisibilidad], P.[VisibilidadDescripcion]
	FROM [GD1C2016].[MASTERDBA].[VW_Facturas] F, [GD1C2016].[MASTERDBA].[Facturas_Items] I, [GD1C2016].[MASTERDBA].[VW_Publicaciones] P
	WHERE F.[IdFactura] = I.[IdFactura]
	AND F.[IdPublicacion] = P.[IdPublicacion]
	AND I.[Concepto] = 'Comisión por Venta'
	AND P.[VisibilidadActual] = 1
	--WHERE MONTH(F.[Fecha]) BETWEEN
	--	(CASE @NroTrimestre WHEN 1 THEN 1 WHEN 2 THEN 4 WHEN 3 THEN 7 WHEN 4 THEN 10 END) AND
	--	(CASE @NroTrimestre WHEN 1 THEN 3 WHEN 2 THEN 6 WHEN 3 THEN 9 WHEN 4 THEN 12 END)
	--AND YEAR(F.[Fecha]) = @Año
	--AND (@IdVisibilidad = 0 OR P.[IdVisibilidad] = @IdVisibilidad)
	GROUP BY F.[IdUsuario], F.[NombreUsuario], P.[IdVisibilidad], P.[VisibilidadDescripcion]
	) V
	GROUP BY V.[IdUsuario], V.[NombreUsuario], V.[IdVisibilidad], V.[VisibilidadDescripcion]
	ORDER BY SUM(V.[CantProductosNoVendidos]) DESC
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetPublicacion]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetPublicacion] 
	@IdPublicacion int, 
	@IdUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		P.[IdPublicacion], P.[Descripcion], P.[Stock], P.[FechaInicio], P.[FechaVencimiento], P.[Precio], P.[PrecioReserva], P.[IdRubro], P.[DescripcionCorta] AS RubroDescripcionCorta, P.[DescripcionLarga] AS RubroDescripcionLarga, P.[IdUsuario], P.[NombreUsuario], P.[IdEstado], P.[EstadoDescripcion], P.[Envio], P.[IdTipo], P.[TipoDescripcion], P.[TipoEnvio], P.[IdVisibilidad], P.[VisibilidadDescripcion], V.[Precio] As VisibilidadPrecio, V.[Porcentaje], V.[EnvioPorcentaje]
	FROM
		[GD1C2016].[MASTERDBA].[VW_Publicaciones] P,
		[GD1C2016].[MASTERDBA].[Visibilidad_Publicacion] V
	WHERE P.[IdVisibilidad] = V.[IdVisibilidad]
	AND P.IdPublicacion = @IdPublicacion
	AND P.[VisibilidadActual] = 1
	AND P.[IdUsuario] = @IdUsuario
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetPublicacionesVisibilidad]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetPublicacionesVisibilidad] 
	@IdVisibilidad numeric(18,0)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT PV.[IdPublicacion], P.[Descripcion]
	FROM [GD1C2016].[MASTERDBA].[Publicaciones_Visibilidad] PV, [GD1C2016].[MASTERDBA].[Publicaciones] P
	WHERE PV.IdPublicacion = P.[IdPublicacion]
	AND PV.[idVisibilidad] = @IdVisibilidad
	AND PV.[Activa] = 1
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetReputacion]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetReputacion] 
	@IdUsuario int
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Reputacion decimal(18,2)

	IF EXISTS	(
				SELECT 1 FROM [GD1C2016].[MASTERDBA].[Calificaciones] CA, [GD1C2016].[MASTERDBA].[Compras] CO, [GD1C2016].[MASTERDBA].[Publicaciones] P
				WHERE CA.[IdCompra] = CO.[IdCompra]	AND CO.[IdPublicacion] = P.[IdPublicacion] AND P.IdUsuario = @IdUsuario
				)
		SELECT CAST(SUM(CA.[CantEstrellas]) / COUNT(CA.[IdCalificacion]) AS decimal(18,2))
		FROM [GD1C2016].[MASTERDBA].[Calificaciones] CA, [GD1C2016].[MASTERDBA].[Compras] CO, [GD1C2016].[MASTERDBA].[Publicaciones] P
		WHERE CA.[IdCompra] = CO.[IdCompra]
		AND CO.[IdPublicacion] = P.[IdPublicacion]
		AND P.IdUsuario = @IdUsuario
	ELSE
		SELECT 0
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetRolByDescripcion]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetRolByDescripcion] 
	@Descripcion nvarchar(100)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT R.[IdRol], R.[Descripcion], R.[Activo]
	FROM [GD1C2016].[MASTERDBA].[Roles] R
	WHERE UPPER(R.[Descripcion]) = UPPER(@Descripcion)
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetRoles]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetRoles] 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT R.[IdRol], R.[Descripcion], R.[Activo]
	FROM [GD1C2016].[MASTERDBA].[Roles] R
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetRolesUsuario]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetRolesUsuario] 
	@IdUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT UR.[IdRol]
	FROM [GD1C2016].[MASTERDBA].[Usuarios_Roles] UR
	WHERE UR.[IdUsuario] = @IdUsuario
	AND UR.[Activa] = 1
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetRolFuncionalidades]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetRolFuncionalidades] 
	@IdRol int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT RF.[IdFuncionalidad]
	FROM [GD1C2016].[MASTERDBA].[Roles_Funcionalidades] RF
	WHERE RF.[IdRol] = @IdRol
	AND RF.[Activa] = 1
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetRubros]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetRubros] 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT R.[IdRubro] as IdRubro, R.[DescripcionCorta] as DescripcionCorta, R.[DescripcionLarga] as DescripcionLarga
	FROM [GD1C2016].[MASTERDBA].[Rubros] R
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetTiposPublicacion]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetTiposPublicacion] 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT DISTINCT T.[IdTipo], T.[Descripcion], T.[Envio]
	FROM [GD1C2016].[MASTERDBA].[Tipo_Publicacion] T
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetUltimasCalificaciones]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetUltimasCalificaciones] 
	@IdUsuario int, 
	@Cantidad int = 5
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP (@Cantidad) CA.[IdCalificacion], CA.[IdCompra], CA.[CantEstrellas], CA.[Descripcion], P.[Descripcion] AS DescripcionPublicacion
	FROM [GD1C2016].[MASTERDBA].[Calificaciones] CA, [GD1C2016].[MASTERDBA].[Compras] CO, [GD1C2016].[MASTERDBA].[Publicaciones] P
	WHERE CA.[IdCompra] = CO.[IdCompra]
	AND CO.[IdPublicacion] = P.[IdPublicacion]
	AND CO.IdUsuario = @IdUsuario
	ORDER BY CA.IdCalificacion DESC
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetUsuarioByUserName]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetUsuarioByUserName] 
	@UserName nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT U.[IdUsuario], U.[UserName], U.[PassEncr], U.[CantIntFallidos], U.[Activo]
	FROM [GD1C2016].[MASTERDBA].[Usuarios] U
	WHERE UPPER(U.[UserName]) = UPPER(@UserName)
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetVisibilidadByDescripcion]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetVisibilidadByDescripcion] 
	@Descripcion nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT V.[IdVisibilidad] AS IdVisibilidad, V.[Descripcion] AS Descripcion, V.[EnvioPorcentaje] AS EnvioPorcentaje, V.[Porcentaje] AS Porcentaje, V.[Precio] AS Precio, V.[Activa]
	FROM [GD1C2016].[MASTERDBA].[Visibilidad_Publicacion] V
	WHERE UPPER(V.[Descripcion]) = UPPER(@Descripcion)
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetVisibilidades]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetVisibilidades] 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT V.[IdVisibilidad] AS IdVisibilidad, V.[Descripcion] AS Descripcion, V.[EnvioPorcentaje] AS EnvioPorcentaje, V.[Porcentaje] AS Porcentaje, V.[Precio] AS Precio, V.[Activa]
	FROM [GD1C2016].[MASTERDBA].[Visibilidad_Publicacion] V
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_IncrementCountLogin]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_IncrementCountLogin] 
	@UserName nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [GD1C2016].[MASTERDBA].[Usuarios]
	SET	[CantIntFallidos] = [CantIntFallidos] + 1
	WHERE UPPER([UserName]) = UPPER(@UserName)

	SELECT U.[CantIntFallidos]
	FROM [GD1C2016].[MASTERDBA].[Usuarios] U
	WHERE UPPER(U.[UserName]) = UPPER(@UserName)
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertCliente]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_InsertCliente] 
	@IdUsuario int, 
	@Apellido nvarchar(255), 
	@Nombre nvarchar(255), 
	@TipoDoc nvarchar(50), 
	@NroDoc numeric(18,0), 
	@Mail nvarchar(255), 
	@Telefono nvarchar(50), 
	@Calle nvarchar(255), 
    @Nro numeric(18,0), 
	@Piso numeric(18,0), 
	@Departamento nvarchar(50), 
	@Localidad nvarchar(100), 
	@CodigoPostal nvarchar(50),  
	@FechaNacimiento datetime, 
	@FechaCreacion datetime
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [GD1C2016].[MASTERDBA].[Clientes]
	VALUES	(
			@IdUsuario,
			@Apellido,
			@Nombre,
			@TipoDoc,
			@NroDoc,
			@Mail,
			@Telefono,
			@Calle,
			@Nro,
			@Piso,
			@Departamento,
			@Localidad,
			@CodigoPostal,
			@FechaNacimiento,
			@FechaCreacion
			)
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertCompra]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_InsertCompra] 
	@IdPublicacion numeric(18,0), 
	@Fecha datetime, 
	@Cantidad numeric(18,0), 
	@Envio bit, 
	@IdUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [GD1C2016].[MASTERDBA].[Compras]
	VALUES (@IdPublicacion, @Fecha, @Cantidad, @Envio, @IdUsuario)

	UPDATE [GD1C2016].[MASTERDBA].[Publicaciones]
	SET [Stock] = [Stock] - @Cantidad
	WHERE [IdPublicacion] = @IdPublicacion

	SELECT C.[IdCompra] FROM [GD1C2016].[MASTERDBA].[Compras] C WHERE C.[IdPublicacion] = @IdPublicacion AND C.[Fecha] = @Fecha AND C.[Cantidad] = @Cantidad AND C.[Envio] = @Envio AND C.[IdUsuario] = @IdUsuario
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertEmpresa]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_InsertEmpresa] 
	@IdUsuario int, 
	@RazonSocial nvarchar(255), 
	@Mail nvarchar(255), 
	@Telefono nvarchar(50), 
	@Calle nvarchar(255), 
    @Nro numeric(18,0), 
	@Piso numeric(18,0), 
	@Departamento nvarchar(50), 
	@Localidad nvarchar(100), 
	@CodigoPostal nvarchar(50), 
	@Ciudad nvarchar(100), 
	@CUIT nvarchar(50), 
	@Contacto nvarchar(255), 
	@Rubro nvarchar(255), 
	@FechaCreacion datetime
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [GD1C2016].[MASTERDBA].[Empresas]
	VALUES	(
			@IdUsuario,
			@RazonSocial,
			@Mail,
			@Telefono,
			@Calle,
		    @Nro,
			@Piso,
			@Departamento,
			@Localidad,
			@CodigoPostal,
			@Ciudad,
			@CUIT,
			@Contacto,
			@Rubro,
			@FechaCreacion
			)
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertFactura]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_InsertFactura] 
	@IdPublicacion numeric(18,0), 
	@Fecha datetime, 
	@Total numeric(18,2)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @IdFactura numeric(18,0)

	SELECT @IdFactura = MAX(F.[IdFactura]) + 1 FROM [GD1C2016].[MASTERDBA].[Facturas] F

	INSERT INTO [GD1C2016].[MASTERDBA].[Facturas]
	VALUES	(
			@IdFactura,
			@IdPublicacion,
			@Fecha,
			@Total,
			(SELECT FP.[IdFormaPago] FROM [GD1C2016].[MASTERDBA].[Formas_Pago] FP WHERE FP.[Descripcion] = 'Efectivo')
			)

	RETURN @IdFactura
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertFacturaItem]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_InsertFacturaItem] 
	@IdFactura numeric(18,0), 
	@Concepto nvarchar (255), 
	@Monto numeric(18,2), 
	@Cantidad numeric(18,0)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [GD1C2016].[MASTERDBA].[Facturas_Items]
	VALUES	(@IdFactura, @Concepto, @Monto, @Cantidad)
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertNewCalificacion]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_InsertNewCalificacion] 
	@IdCompra int, 
	@CantEstrellas int, 
	@Descripcion nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [GD1C2016].[MASTERDBA].[Calificaciones]
	VALUES	(@IdCompra, @CantEstrellas, @Descripcion)
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertOferta]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_InsertOferta] 
	@IdPublicacion numeric(18,0), 
	@Fecha datetime, 
	@Monto numeric(18,2), 
	@IdUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [GD1C2016].[MASTERDBA].[Ofertas]
	VALUES (@IdPublicacion, @Fecha, @Monto, 0, @IdUsuario, NULL)

	SELECT O.[IdOferta] FROM [GD1C2016].[MASTERDBA].[Ofertas] O	WHERE O.[IdPublicacion] = @IdPublicacion AND O.[Fecha] = @Fecha AND O.[Monto] = @Monto AND O.[IdUsuario] = @IdUsuario
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertPublicacion]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_InsertPublicacion] 
	@Descripcion nvarchar(255), 
	@Stock numeric(18,0), 
	@FechaInicio datetime, 
	@FechaVencimiento datetime, 
	@Precio numeric(18,2), 
	@PrecioReserva numeric(18,2), 
	@IdRubro int, 
	@IdUsuario int, 
	@IdEstado int, 
	@IdTipo int, 
	@Envio bit, 
	@IdVisibilidad numeric(18,0), 
	@FechaActual datetime
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @IdPublicacion numeric(18,0),
			@Total numeric(18,2),
			@IdFactura numeric(18,0)

	SELECT @IdPublicacion = MAX(P.[IdPublicacion]) + 1 FROM [GD1C2016].[MASTERDBA].[Publicaciones] P

	INSERT INTO [GD1C2016].[MASTERDBA].[Publicaciones]
	VALUES (@IdPublicacion,	@Descripcion, @Stock, @FechaInicio,	@FechaVencimiento, @Precio, @PrecioReserva, @IdRubro, @IdUsuario, @IdEstado, @IdTipo, @Envio)

	EXEC [GD1C2016].[MASTERDBA].[SP_InsertPublicacionVisibilidad] @IdPublicacion, @IdVisibilidad

	IF (SELECT E.[Descripcion] FROM [GD1C2016].[MASTERDBA].[Estado_Publicacion] E WHERE E.[IdEstado] = @IdEstado) = 'Activa'
	BEGIN
		SELECT @Total = V.[Precio] FROM [GD1C2016].[MASTERDBA].[Visibilidad_Publicacion] V WHERE V.[IdVisibilidad] = @IdVisibilidad

		EXEC @IdFactura = [GD1C2016].[MASTERDBA].[SP_InsertFactura] @IdPublicacion, @FechaActual, @Total
		EXEC [GD1C2016].[MASTERDBA].[SP_InsertFacturaItem] @IdFactura, 'Comisión por Publicación', @Total, 1
	END

	SELECT P.[IdPublicacion] FROM [GD1C2016].[MASTERDBA].[Publicaciones] P WHERE P.[IdPublicacion] = @IdPublicacion
END


GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertPublicacionVisibilidad]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_InsertPublicacionVisibilidad] 
	@IdPublicacion numeric(18,0), 
	@IdVisibilidad numeric(18,0)
AS
BEGIN
	SET NOCOUNT ON;

	IF EXISTS	(
				SELECT 1 FROM [GD1C2016].[MASTERDBA].[Publicaciones_Visibilidad] PV
				WHERE PV.[IdPublicacion] = @IdPublicacion AND PV.[IdVisibilidad] = @IdVisibilidad
				)
		UPDATE [GD1C2016].[MASTERDBA].[Publicaciones_Visibilidad]
		SET [Activa] = 1
		WHERE [IdPublicacion] = @IdPublicacion
		AND [IdVisibilidad] = @IdVisibilidad
	ELSE
		INSERT INTO [GD1C2016].[MASTERDBA].[Publicaciones_Visibilidad]
		VALUES (@IdPublicacion, @IdVisibilidad, 1)
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertRol]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_InsertRol] 
	@Descripcion nvarchar(100), 
	@Activo bit
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [GD1C2016].[MASTERDBA].[Roles]
	VALUES (@Descripcion, @Activo)

	SELECT R.[IdRol], R.[Descripcion], R.[Activo]
	FROM [GD1C2016].[MASTERDBA].[Roles] R
	WHERE R.[IdRol] = @@IDENTITY
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertRolFuncionalidad]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_InsertRolFuncionalidad] 
	@IdRol int, 
	@IdFuncionalidad int, 
	@Activa bit
AS
BEGIN
	SET NOCOUNT ON;

	IF EXISTS	(
				SELECT 1 FROM [GD1C2016].[MASTERDBA].[Roles_Funcionalidades] RF
				WHERE RF.[IdRol] = @IdRol AND RF.[IdFuncionalidad] = @IdFuncionalidad
				)
	BEGIN
		UPDATE [GD1C2016].[MASTERDBA].[Roles_Funcionalidades]
		SET	[Activa] = 1
		WHERE [IdRol] = @IdRol
		AND [IdFuncionalidad] = @IdFuncionalidad
	END
	ELSE
	BEGIN
		INSERT INTO [GD1C2016].[MASTERDBA].[Roles_Funcionalidades]
		VALUES (@IdRol, @IdFuncionalidad, @Activa)
	END
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertRubro]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_InsertRubro] 
	@DescripcionCorta nvarchar(25), 
	@DescripcionLarga nvarchar(100)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [GD1C2016].[MASTERDBA].[Rubros]
	VALUES (@DescripcionCorta, @DescripcionLarga)

	SELECT R.[IdRubro], R.[DescripcionCorta], R.[DescripcionLarga]
	FROM [GD1C2016].[MASTERDBA].[Rubros] R
	WHERE R.[IdRubro] = @@IDENTITY
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertUsuario]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_InsertUsuario] 
	@UserName nvarchar(50), 
	@PassEncr nvarchar(255), 
	@CantIntFallidos int, 
	@Activo bit
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [GD1C2016].[MASTERDBA].[Usuarios]
	VALUES (@UserName, @PassEncr, @CantIntFallidos, @Activo)

	SELECT U.[IdUsuario], U.[UserName], U.[PassEncr], U.[CantIntFallidos], U.[Activo]
	FROM [GD1C2016].[MASTERDBA].[Usuarios] U
	WHERE U.[IdUsuario] = @@IDENTITY
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertUsuarioRol]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_InsertUsuarioRol] 
	@IdUsuario int, 
	@IdRol int, 
	@Activa bit
AS
BEGIN
	SET NOCOUNT ON;

	IF EXISTS	(
				SELECT 1 FROM [GD1C2016].[MASTERDBA].[Usuarios_Roles] UR
				WHERE UR.[IdUsuario] = @IdUsuario AND UR.[IdRol] = @IdRol
				)
	BEGIN
		UPDATE [GD1C2016].[MASTERDBA].[Usuarios_Roles]
		SET	[Activa] = 1
		WHERE [IdUsuario] = @IdUsuario
		AND [IdRol] = @IdRol
	END
	ELSE
	BEGIN
		INSERT INTO [GD1C2016].[MASTERDBA].[Usuarios_Roles]
		VALUES (@IdUsuario, @IdRol, @Activa)
	END
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertVisibilidad]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_InsertVisibilidad] 
	@Descripcion nvarchar(255), 
	@Activa bit,
	@Porcentaje numeric(18,2),
	@EnvioPorcentaje numeric(18,2),
	@Precio numeric(18,2)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [GD1C2016].[MASTERDBA].[Visibilidad_Publicacion]
	VALUES (@Descripcion, @Precio, @Porcentaje, @EnvioPorcentaje, @Activa)

	SELECT V.[IdVisibilidad]
	FROM [GD1C2016].[MASTERDBA].[Visibilidad_Publicacion] V
	WHERE V.[IdVisibilidad] = @@IDENTITY
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_PublicacionesACerrar]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_PublicacionesACerrar] 
	@Fecha datetime
AS
BEGIN
	SET NOCOUNT ON;

	SELECT P.[IdPublicacion]
	FROM [GD1C2016].[MASTERDBA].[VW_Publicaciones] P
	WHERE CONVERT(date, [FechaVencimiento]) <= CONVERT(date, @Fecha)
	AND P.[EstadoDescripcion] <> 'Finalizada'
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_ResetCountLogin]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_ResetCountLogin] 
	@UserName nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [GD1C2016].[MASTERDBA].[Usuarios]
	SET	[CantIntFallidos] = 0
	WHERE UPPER([UserName]) = UPPER(@UserName)
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_UpdateCliente]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_UpdateCliente] 
	@IdUsuario int, 
	@Apellido nvarchar(255), 
	@Nombre nvarchar(255), 
	@TipoDoc nvarchar(50), 
	@NroDoc numeric(18,0), 
	@Mail nvarchar(255), 
	@Telefono nvarchar(50), 
	@Calle nvarchar(255), 
    @Nro numeric(18,0), 
	@Piso numeric(18,0), 
	@Departamento nvarchar(50), 
	@Localidad nvarchar(100), 
	@CodigoPostal nvarchar(50), 
	@FechaNacimiento datetime, 
	@PassEncr nvarchar(255), 
	@Activo bit
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [GD1C2016].[MASTERDBA].[Clientes]
	SET
	[Apellido] = @Apellido,
	[Nombre] = @Nombre,
	[TipoDoc] = @TipoDoc,
	[NroDoc] = @NroDoc,
	[Mail] = @Mail,
	[Telefono] = @Telefono,
	[Calle] = @Calle,
	[Nro] = @Nro,
	[Piso] = @Piso,
	[Departamento] = @Departamento,
	[Localidad] = @Localidad,
	[CP] = @CodigoPostal,
	[FechaNacimiento] = @FechaNacimiento
	WHERE [IdUsuario] = @IdUsuario

	UPDATE [GD1C2016].[MASTERDBA].[Usuarios]
	SET
	[PassEncr] = @PassEncr,
	[Activo] = @Activo
	WHERE [IdUsuario] = @IdUsuario
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_UpdateEmpresa]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_UpdateEmpresa] 
	@IdUsuario int,
	@RazonSocial nvarchar(255), 
	@Mail nvarchar(255), 
	@Telefono nvarchar(50), 
	@Calle nvarchar(255), 
    @Nro numeric(18,0), 
	@Piso numeric(18,0), 
	@Departamento nvarchar(50), 
	@Localidad nvarchar(100), 
	@CodigoPostal nvarchar(50), 
	@Ciudad nvarchar(100), 
	@CUIT nvarchar(50), 
	@Contacto nvarchar(255), 
	@Rubro nvarchar(255), 
	@PassEncr nvarchar(255), 
	@Activo bit
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [GD1C2016].[MASTERDBA].[Empresas]
	SET
	[RazonSocial] = @RazonSocial,
	[Mail] = @Mail,
	[Telefono] = @Telefono,
	[Calle] = @Calle,
	[Nro] = @Nro,
	[Piso] = @Piso,
	[Departamento] = @Departamento,
	[Localidad] = @Localidad,
	[CP] = @CodigoPostal,
	[Ciudad] = @Ciudad,
	[CUIT] = @CUIT,
	[Contacto] = @Contacto,
	[Rubro] = @Rubro
	WHERE [IdUsuario] = @IdUsuario

	UPDATE [GD1C2016].[MASTERDBA].[Usuarios]
	SET
	[PassEncr] = @PassEncr,
	[Activo] = @Activo
	WHERE [IdUsuario] = @IdUsuario
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_UpdatePublicacion]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_UpdatePublicacion] 
	@IdPublicacion numeric(18,0), 
	@Descripcion nvarchar(255), 
	@Stock numeric(18,0), 
	@FechaInicio datetime, 
	@FechaVencimiento datetime, 
	@Precio numeric(18,2), 
	@PrecioReserva numeric(18,2), 
	@IdRubro int, 
	@IdEstado int, 
	@IdTipo int, 
	@Envio bit, 
	@IdVisibilidad numeric(18,0), 
	@FechaActual datetime
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Total numeric(18,2),
			@IdFactura numeric(18,0),
			@IdVisibilidadAnterior numeric(18,0)

	SELECT @IdVisibilidadAnterior = PV.[IdVisibilidad] FROM [GD1C2016].[MASTERDBA].[Publicaciones_Visibilidad] PV WHERE PV.[IdPublicacion] = @IdPublicacion AND PV.[Activa] = 1

	UPDATE [GD1C2016].[MASTERDBA].[Publicaciones_Visibilidad]
	SET [Activa] = 0
	WHERE [IdPublicacion] = @IdPublicacion
	AND [IdVisibilidad] = @IdVisibilidadAnterior

	UPDATE [GD1C2016].[MASTERDBA].[Publicaciones]
	SET
	[Descripcion] = @Descripcion,
	[Stock] = @Stock,
	[FechaInicio] = @FechaInicio,
	[FechaVencimiento] = @FechaVencimiento,
	[Precio] = @Precio,
	[PrecioReserva] = @PrecioReserva,
	[IdRubro] = @IdRubro,
	[IdEstado] = @IdEstado,
	[IdTipo] = @IdTipo,
	[Envio] = @Envio
	WHERE [IdPublicacion] = @IdPublicacion

	EXEC [GD1C2016].[MASTERDBA].[SP_InsertPublicacionVisibilidad] @IdPublicacion, @IdVisibilidad

	IF (SELECT E.[Descripcion] FROM [GD1C2016].[MASTERDBA].[Estado_Publicacion] E WHERE E.[IdEstado] = @IdEstado) = 'Activa'
	BEGIN
		IF NOT EXISTS	(
						SELECT 1 FROM [GD1C2016].[MASTERDBA].[Facturas] F, [GD1C2016].[MASTERDBA].[Facturas_Items] I
						WHERE F.[IdFactura] = I.[IdFactura] AND F.[IdPublicacion] = @IdPublicacion AND I.[Concepto] = 'Comisión por Publicación'
						)
		BEGIN
			SELECT @Total = V.[Precio] FROM [GD1C2016].[MASTERDBA].[Visibilidad_Publicacion] V WHERE V.[IdVisibilidad] = @IdVisibilidad

			EXEC @IdFactura = [GD1C2016].[MASTERDBA].[SP_InsertFactura] @IdPublicacion, @FechaActual, @Total
			EXEC [GD1C2016].[MASTERDBA].[SP_InsertFacturaItem] @IdFactura, 'Comisión por Publicación', @Total, 1
		END
	END
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_UpdateRol]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_UpdateRol] 
	@IdRol int, 
	@Descripcion nvarchar(100), 
	@Activo bit
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [GD1C2016].[MASTERDBA].[Roles]
	SET
	Descripcion = @Descripcion,
	Activo = @Activo
	WHERE [IdRol] = @IdRol
END

GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_UpdateVisibilidad]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_UpdateVisibilidad] 
	@Descripcion nvarchar(255), 
	@Activa bit,
	@Porcentaje numeric(18,2),
	@EnvioPorcentaje numeric(18,2),
	@Precio numeric(18,2),
	@IdVisibilidad int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [GD1C2016].[MASTERDBA].[Visibilidad_Publicacion]
	SET [Descripcion] = @Descripcion, Activa = @Activa, Porcentaje = @Porcentaje, EnvioPorcentaje = @EnvioPorcentaje, Precio = @Precio
	WHERE
	[IdVisibilidad] = @IdVisibilidad
END

GO
/****** Object:  View [MASTERDBA].[VW_Usuarios]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE VIEW [MASTERDBA].[VW_Usuarios] 
AS
SELECT
	U.[IdUsuario],
	U.[UserName],
	U.[PassEncr],
	U.[CantIntFallidos],
	U.[Activo],
	C.[Apellido],
	C.[Nombre],
	E.[RazonSocial],
	C.[TipoDoc],
	C.[NroDoc],
	COALESCE (C.[Mail], E.[Mail]) AS Mail,
	COALESCE (C.[Telefono], E.[Telefono]) AS Telefono,
	COALESCE (C.[Calle], E.[Calle]) AS Calle,
	COALESCE (C.[Nro], E.[Nro]) AS Nro,
	COALESCE (C.[Piso], E.[Piso]) AS Piso,
	COALESCE (C.[Departamento], E.[Departamento]) AS Departamento,
	COALESCE (C.[Localidad], E.[Localidad]) AS Localidad,
	COALESCE (C.[CP], E.[CP]) AS CP,
	E.[Ciudad],
	E.[CUIT],
	E.[Contacto],
	E.[Rubro],
	C.[FechaNacimiento],
	COALESCE (C.[FechaCreacion], E.[FechaCreacion]) FechaCreacion
FROM [GD1C2016].[MASTERDBA].[Usuarios] U
LEFT OUTER JOIN [GD1C2016].[MASTERDBA].[Clientes] C
ON U.[IdUsuario] = C.[IdUsuario]
LEFT OUTER JOIN [GD1C2016].[MASTERDBA].[Empresas] E
ON U.[IdUsuario] = E.[IdUsuario]
GO
/****** Object:  View [MASTERDBA].[VW_Ofertas]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE VIEW [MASTERDBA].[VW_Ofertas] 
AS
SELECT
	O.[IdOferta],
	O.[IdPublicacion],
	P.[Descripcion],
	P.[IdRubro],
	R.[DescripcionLarga] AS RubroDescripcion,
	O.[Fecha],
	O.[Monto],
	O.[IdUsuario],
	COALESCE(U.[Nombre] + ' ' + U.[Apellido], U.[RazonSocial]) AS NombreUsuario,
	O.[IdCompra]
FROM
	[GD1C2016].[MASTERDBA].[Ofertas] O,
	[GD1C2016].[MASTERDBA].[Publicaciones] P,
	[GD1C2016].[MASTERDBA].[VW_Usuarios] U,
	[GD1C2016].[MASTERDBA].[Rubros] R
WHERE O.[IdPublicacion] = P.[IdPublicacion]
AND O.[IdUsuario] = U.[IdUsuario]
AND P.[IdRubro] = R.[IdRubro]
GO
/****** Object:  View [MASTERDBA].[VW_Publicaciones]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE VIEW [MASTERDBA].[VW_Publicaciones] 
AS
SELECT
	P.[IdPublicacion],
	P.[Descripcion],
	P.[Stock],
	P.[FechaInicio],
	P.[FechaVencimiento],
	P.[Precio],
	P.[PrecioReserva],
	P.[IdRubro],
	R.[DescripcionCorta],
	R.[DescripcionLarga],
	P.[IdUsuario],
	COALESCE(U.[Nombre] + ' ' + U.[Apellido], U.[RazonSocial]) AS NombreUsuario,
	P.[IdEstado],
	E.[Descripcion] AS EstadoDescripcion,
	P.[IdTipo],
	T.[Descripcion] AS TipoDescripcion,
	T.[Envio] AS TipoEnvio,
	V.[IdVisibilidad],
	V.[Descripcion] AS VisibilidadDescripcion,
	PV.[Activa] AS VisibilidadActual,
	P.[Envio]
FROM
	[GD1C2016].[MASTERDBA].[Publicaciones] P,
	[GD1C2016].[MASTERDBA].[Rubros] R,
	[GD1C2016].[MASTERDBA].[VW_Usuarios] U,
	[GD1C2016].[MASTERDBA].[Estado_Publicacion] E,
	[GD1C2016].[MASTERDBA].[Tipo_Publicacion] T,
	[GD1C2016].[MASTERDBA].[Publicaciones_Visibilidad] PV,
	[GD1C2016].[MASTERDBA].[Visibilidad_Publicacion] V
WHERE P.[IdRubro] = R.[IdRubro]
AND P.[IdUsuario] = U.[IdUsuario]
AND P.[IdEstado] = E.[IdEstado]
AND P.[IdTipo] = T.[IdTipo]
AND P.[IdPublicacion] = PV.[IdPublicacion]
AND PV.[IdVisibilidad] = V.[IdVisibilidad]
GO
/****** Object:  View [MASTERDBA].[VW_Calificaciones]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE VIEW [MASTERDBA].[VW_Calificaciones] 
AS
SELECT
	CA.[IdCalificacion],
	CA.[IdCompra],
	CO.[IdUsuario],
	COALESCE(U.[Nombre] + ' ' + U.[Apellido], U.[RazonSocial]) AS NombreUsuario,
	CA.[CantEstrellas],
	CA.[Descripcion]
FROM [GD1C2016].[MASTERDBA].[Calificaciones] CA, [GD1C2016].[MASTERDBA].[Compras] CO, [GD1C2016].[MASTERDBA].[VW_Usuarios] U
WHERE CA.[IdCompra] = CO.[IdCompra]
AND CO.[IdUsuario] = U.[IdUsuario]
GO
/****** Object:  View [MASTERDBA].[VW_Facturas]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE VIEW [MASTERDBA].[VW_Facturas] 
AS
SELECT
	F.[IdFactura],
	F.[IdPublicacion],
	P.[IdUsuario],
	COALESCE(U.[Nombre] + ' ' + U.[Apellido], U.[RazonSocial]) AS NombreUsuario,
	F.[Fecha],
	F.[Total],
	F.[IdFormaPago],
	FP.[Descripcion] AS FormaPago
FROM
	[GD1C2016].[MASTERDBA].[Facturas] F,
	[GD1C2016].[MASTERDBA].[Publicaciones] P,
	[GD1C2016].[MASTERDBA].[VW_Usuarios] U,
	[GD1C2016].[MASTERDBA].[Formas_Pago] FP
WHERE F.[IdPublicacion] = P.[IdPublicacion]
AND F.[IdFormaPago] = FP.[IdFormaPago]
AND P.[IdUsuario] = U.[IdUsuario]
GO
/****** Object:  View [MASTERDBA].[VW_Compras]    Script Date: 04/07/2016 05:41:29 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE VIEW [MASTERDBA].[VW_Compras] 
AS
SELECT
	C.[IdCompra],
	C.[IdPublicacion],
	P.[Descripcion],
	P.[IdRubro],
	R.[DescripcionLarga] AS RubroDescripcion,
	C.[Fecha],
	C.[Cantidad],
	C.[Envio],
	C.[IdUsuario],
	COALESCE(U.[Nombre] + ' ' + U.[Apellido], U.[RazonSocial]) AS NombreUsuario
FROM
	[GD1C2016].[MASTERDBA].[Compras] C,
	[GD1C2016].[MASTERDBA].[Publicaciones] P,
	[GD1C2016].[MASTERDBA].[VW_Usuarios] U,
	[GD1C2016].[MASTERDBA].[Rubros] R
WHERE C.[IdPublicacion] = P.[IdPublicacion]
AND C.[IdUsuario] = U.[IdUsuario]
AND P.[IdRubro] = R.[IdRubro]
GO
