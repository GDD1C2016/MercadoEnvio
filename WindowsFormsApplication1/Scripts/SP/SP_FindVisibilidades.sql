USE [GD1C2016]
GO
/****** Object:  StoredProcedure [dbo].[SP_FindVisibilidades]    Script Date: 05/06/2016 01:54:11 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_FindVisibilidades] 
	@FiltroDescripcion nvarchar(255) = ''
AS
BEGIN
	SET NOCOUNT ON;

	SELECT V.[IdVisibilidad] AS IdVisibilidad, V.[Descripcion] AS Descripcion, V.[EnvioPorcentaje] AS EnvioPorcentaje, V.[Porcentaje] AS Porcentaje, V.[Precio] AS Precio
	FROM [GD1C2016].[MASTERDBA].[Visibilidad_Publicacion] V
	WHERE (@FiltroDescripcion = '' OR  V.[Descripcion] LIKE @FiltroDescripcion + '%')
END

GO
