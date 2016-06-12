USE [GD1C2016]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetPublicacionesVisibilidad] 
	@IdVisibilidad int
AS
BEGIN
	SET NOCOUNT ON;

	IF EXISTS(SELECT 1 FROM [GD1C2016].[MASTERDBA].[Publicaciones_Visibilidad] PV WHERE PV.[idVisibilidad] = @IdVisibilidad)
	BEGIN
		SELECT PV.[IdPublicacion], P.[Descripcion]
		FROM [GD1C2016].[MASTERDBA].[Publicaciones_Visibilidad] PV, [GD1C2016].[MASTERDBA].[Publicaciones] P
		WHERE PV.IdPublicacion = P.[IdPublicacion]
		AND PV.[idVisibilidad] = @IdVisibilidad
	END
END
