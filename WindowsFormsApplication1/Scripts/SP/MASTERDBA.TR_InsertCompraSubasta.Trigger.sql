USE [GD1C2016]
GO
/****** Object:  Trigger [MASTERDBA].[TR_InsertCompraSubasta]    Script Date: 04/07/2016 01:33:54 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [MASTERDBA].[TR_InsertCompraSubasta] 
ON [GD1C2016].[MASTERDBA].[Publicaciones] AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @IdPublicacion numeric(18,0),
			@IdEstado int,
			@IdOferta int,
			@Fecha datetime,
			@Envio bit,
			@IdUsuario int,
			@IdCompra int

	SELECT @IdPublicacion = IdPublicacion, @IdEstado = IdEstado FROM inserted

	IF (SELECT E.[Descripcion] FROM [GD1C2016].[MASTERDBA].[Estado_Publicacion] E WHERE E.[IdEstado] = @IdEstado) = 'Finalizada'
	BEGIN
		SELECT TOP(1) @IdOferta = O.[IdOferta], @Fecha = O.[Fecha], @Envio = O.[Envio], @IdUsuario = O.[IdUsuario]
		FROM [GD1C2016].[MASTERDBA].[Ofertas] O
		WHERE O.[IdPublicacion] = @IdPublicacion
		ORDER BY O.[Monto] DESC

		IF @IdOferta IS NOT NULL
		BEGIN
			EXEC @IdCompra = [GD1C2016].[MASTERDBA].[SP_InsertCompra] @IdPublicacion, @Fecha, 1, @Envio, @IdUsuario

			UPDATE [GD1C2016].[MASTERDBA].[Ofertas]
			SET [IdCompra] = @IdCompra
			WHERE [IdOferta] = @IdOferta
		END
	END
END
