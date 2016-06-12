USE [GD1C2016]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetVisibilidades]    Script Date: 05/06/2016 01:54:11 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetVisibilidades] 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT V.[IdVisibilidad] AS IdVisibilidad, V.[Descripcion] AS Descripcion, V.[EnvioPorcentaje] AS EnvioPorcentaje, V.[Porcentaje] AS Porcentaje, V.[Precio] AS Precio, V.[Activa]
	FROM [GD1C2016].[MASTERDBA].[Visibilidad_Publicacion] V
END

GO
