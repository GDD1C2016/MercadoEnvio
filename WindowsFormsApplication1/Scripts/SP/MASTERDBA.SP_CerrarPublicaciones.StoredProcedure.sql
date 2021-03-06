USE [GD1C2016]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_BloqUser]    Script Date: 02/07/2016 06:57:09 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_CerrarPublicaciones] 
	@Fecha datetime
AS
BEGIN
	SET NOCOUNT ON;
		
	UPDATE [GD1C2016].[MASTERDBA].[Publicaciones]
	SET [IdEstado] = (SELECT E.[IdEstado] FROM [GD1C2016].[MASTERDBA].[Estado_Publicacion] E WHERE E.[Descripcion] = 'Finalizada')
	WHERE ((SELECT CONVERT(date, [FechaVencimiento])) <= (SELECT CONVERT(date, @Fecha)))
END

GO
