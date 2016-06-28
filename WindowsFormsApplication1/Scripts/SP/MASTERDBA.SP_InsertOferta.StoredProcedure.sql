USE [GD1C2016]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertOferta]    Script Date: 27/06/2016 09:25:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_InsertOferta] 
	@IdPublicacion int, 
	@Fecha datetime, 
	@Monto numeric(18,2), 
	@IdUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [GD1C2016].[MASTERDBA].[Ofertas]
	VALUES (@IdPublicacion, @Fecha, @Monto, 0, @IdUsuario, NULL)

	SELECT O.[IdOferta], O.[IdPublicacion], O.[Fecha], O.[Monto], O.[Envio], O.[IdUsuario]
	FROM [GD1C2016].[MASTERDBA].[Ofertas] O
	WHERE O.[IdOferta] = @@IDENTITY
END

GO
