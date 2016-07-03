USE [GD1C2016]
GO
/****** Object:  Trigger [MASTERDBA].[TR_InsertFacturaCompra]    Script Date: 02/07/2016 01:14:37 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE TRIGGER [MASTERDBA].[TR_InsertFacturaCompra] 
ON [MASTERDBA].[Compras] AFTER INSERT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @IdPublicacion numeric(18,0),
			@Fecha datetime,
			@Cantidad numeric(18,0),
			@Envio bit,
			@IdUsuario int,
			@Precio numeric(18,2),
			@IdVisibilidad numeric(18,0),
			@Total numeric(18,2),
			@IdFactura numeric(18,0),
			@EnvioPorcentaje numeric(18,2)

	SELECT @IdPublicacion = IdPublicacion, @Fecha = Fecha, @Cantidad = Cantidad, @Envio = Envio, @IdUsuario = IdUsuario FROM inserted
	SELECT @Precio = P.[Precio], @IdVisibilidad = P.[IdVisibilidad] FROM [GD1C2016].[MASTERDBA].[VW_Publicaciones] P WHERE P.[IdPublicacion] = @IdPublicacion AND P.[VisibilidadActual] = 1

	SET @Total = @Cantidad * @Precio

	EXEC @IdFactura = [GD1C2016].[MASTERDBA].[SP_InsertFactura] @IdPublicacion, @Fecha, @Total
	EXEC [GD1C2016].[MASTERDBA].[SP_InsertFacturaItem] @IdFactura, 'Comisión por Venta', @Total, @Cantidad

	IF @Envio = 1
	BEGIN
		SELECT @EnvioPorcentaje = V.[EnvioPorcentaje] FROM [GD1C2016].[MASTERDBA].[Visibilidad_Publicacion] V WHERE V.[IdVisibilidad] = @IdVisibilidad

		SET @Total = @Total * @EnvioPorcentaje
		EXEC [GD1C2016].[MASTERDBA].[SP_InsertFacturaItem] @IdFactura, 'Comisión por Envío', @Total, 1
	END
END
