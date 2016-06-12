USE [GD1C2016]
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteRolFuncionalidad]    Script Date: 12/06/2016 07:27:01 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_DeleteRolFuncionalidad] 
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
