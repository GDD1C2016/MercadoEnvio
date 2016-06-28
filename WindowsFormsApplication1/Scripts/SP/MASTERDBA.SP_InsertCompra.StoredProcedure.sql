USE [GD1C2016]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertCompra]    Script Date: 27/06/2016 09:47:44 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_InsertCompra] 
	@IdPublicacion int, 
	@Fecha datetime, 
	@Cantidad numeric(18,0), 
	@Envio bit, 
	@IdUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [GD1C2016].[MASTERDBA].[Compras]
	VALUES (@IdPublicacion, @Fecha, @Cantidad, @Envio, @IdUsuario)

	UPDATE [GD1C2016].[MASTERDBA].[Publicaciones]
	SET [Stock] = [Stock] - @Cantidad
	WHERE [IdPublicacion] = @IdPublicacion

	SELECT C.[IdCompra], C.[IdPublicacion], C.[Fecha], C.[Cantidad], C.[Envio], C.[IdUsuario]
	FROM [GD1C2016].[MASTERDBA].[Compras] C
	WHERE C.[IdCompra] = @@IDENTITY
END

GO
