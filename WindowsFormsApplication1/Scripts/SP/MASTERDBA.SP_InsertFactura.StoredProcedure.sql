USE [GD1C2016]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertFactura]    Script Date: 03/07/2016 10:09:58 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_InsertFactura] 
	@IdPublicacion numeric(18,0), 
	@Fecha datetime, 
	@Total numeric(18,2)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @IdFactura numeric(18,0)

	SET @IdFactura = (SELECT MAX(F.[IdFactura]) + 1 FROM [GD1C2016].[MASTERDBA].[Facturas] F)

	INSERT INTO [GD1C2016].[MASTERDBA].[Facturas]
	VALUES	(
			@IdFactura,
			@IdPublicacion,
			@Fecha,
			@Total,
			(SELECT FP.[IdFormaPago] FROM [GD1C2016].[MASTERDBA].[Formas_Pago] FP WHERE FP.[Descripcion] = 'Efectivo')
			)
	RETURN @IdFactura
END

GO