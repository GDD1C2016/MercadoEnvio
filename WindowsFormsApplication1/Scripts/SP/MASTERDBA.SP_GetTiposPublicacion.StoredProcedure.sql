USE [GD1C2016]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetTiposPublicacion]    Script Date: 01/07/2016 12:12:11 a.m. ******/
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
