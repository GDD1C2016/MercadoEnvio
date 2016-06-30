USE [GD1C2016]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetReputacion]    Script Date: 30/06/2016 01:25:24 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetReputacion] 
	@IdUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT CAST(SUM(CA.[CantEstrellas]) / COUNT(CA.[IdCalificacion]) AS decimal(18,2))
	FROM [GD1C2016].[MASTERDBA].[Calificaciones] CA, [GD1C2016].[MASTERDBA].[Compras] CO, [GD1C2016].[MASTERDBA].[Publicaciones] P
	WHERE CA.[IdCompra] = CO.[IdCompra]
	AND CO.[IdPublicacion] = P.[IdPublicacion]
	AND P.IdUsuario = @IdUsuario
END

GO
