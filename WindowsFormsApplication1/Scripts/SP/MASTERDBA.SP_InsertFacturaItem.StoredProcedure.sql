USE [GD1C2016]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertFacturaItem]    Script Date: 03/07/2016 10:10:48 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_InsertFacturaItem] 
	@IdFactura numeric(18,0), 
	@Concepto nvarchar (255), 
	@Monto numeric(18,2), 
	@Cantidad numeric(18,0)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [GD1C2016].[MASTERDBA].[Facturas_Items]
	VALUES	(@IdFactura, @Concepto, @Monto, @Cantidad)
END

GO