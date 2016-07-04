USE [GD1C2016]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertPublicacionVisibilidad]    Script Date: 03/07/2016 10:07:32 p.m. ******/
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