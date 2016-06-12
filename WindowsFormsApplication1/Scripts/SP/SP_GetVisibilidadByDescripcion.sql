USE [GD1C2016]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetVisibilidadByDescripcion]    Script Date: 11/06/2016 05:38:33 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetVisibilidadByDescripcion] 
	@Descripcion nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT V.[IdVisibilidad] AS IdVisibilidad, V.[Descripcion] AS Descripcion, V.[EnvioPorcentaje] AS EnvioPorcentaje, V.[Porcentaje] AS Porcentaje, V.[Precio] AS Precio, V.[Activa]
	FROM [GD1C2016].[MASTERDBA].[Visibilidad_Publicacion] V
	WHERE UPPER(V.[Descripcion]) = UPPER(@Descripcion)
END

GO
