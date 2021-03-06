USE [GD1C2016]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetPublicacionesVisibilidad]    Script Date: 27/06/2016 09:25:45 p.m. ******/
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
	@IdVisibilidad int
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
