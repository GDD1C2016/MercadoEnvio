USE [GD1C2016]
GO
/****** Object:  StoredProcedure [dbo].[SP_FindRoles]    Script Date: 12/06/2016 07:27:01 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_FindRoles] 
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
	AND (@FiltroEstado IS NULL OR R.[Activo] = @FiltroEstado)
	AND (@FiltroFuncionalidad = 0 OR RF.[IdFuncionalidad] = @FiltroFuncionalidad)
	GROUP BY R.[IdRol], R.[Descripcion], R.[Activo]
END

GO
