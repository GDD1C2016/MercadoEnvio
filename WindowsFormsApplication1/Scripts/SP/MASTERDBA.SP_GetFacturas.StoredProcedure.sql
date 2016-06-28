USE [GD1C2016]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetFacturas]    Script Date: 27/06/2016 09:25:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetFacturas] 
	@IdUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT F.[IdFactura], F.[IdPublicacion], F.[Fecha], F.[Total], F.[IdFormaPago]
	FROM [GD1C2016].[MASTERDBA].[VW_Facturas] F
	WHERE F.[IdUsuario] = @IdUsuario
END

GO
