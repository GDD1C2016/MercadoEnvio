USE [GD1C2016]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertRolFuncionalidad]    Script Date: 27/06/2016 09:25:45 p.m. ******/
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
