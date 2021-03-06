USE [GD1C2016]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetComprasOfertas]    Script Date: 02/07/2016 12:41:50 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetComprasOfertas] 
	@IdUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		C.[IdCompra] AS Id,
		C.[IdPublicacion],
		C.[Fecha],
		C.[Cantidad],
		C.[IdUsuario],
		P.[TipoDescripcion] AS TipoPublicacion,
		C.[Descripcion] AS DescripcionPublicacion,
		P.[NombreUsuario] AS Vendedor,
		NULL AS Adjudicada,
		P.[Precio]
	FROM
		[GD1C2016].[MASTERDBA].[VW_Compras] C,
		[GD1C2016].[MASTERDBA].[VW_Publicaciones] P
	WHERE C.[IdPublicacion] = P.[IdPublicacion]
	AND C.[IdRubro] = P.[IdRubro]
	AND P.[VisibilidadActual] = 1
	AND P.[IdUsuario] = @IdUsuario
	AND C.[IdCompra] NOT IN (SELECT O.[IdCompra] FROM [GD1C2016].[MASTERDBA].[Ofertas] O WHERE O.[IdCompra] IS NOT NULL)
	UNION ALL
	SELECT
		O.[IdOferta] AS Id,
		O.[IdPublicacion],
		O.[Fecha],
		1 AS Cantidad,
		O.[IdUsuario],
		P.[TipoDescripcion] AS TipoPublicacion,
		O.[Descripcion] AS DescripcionPublicacion,
		P.[NombreUsuario] AS Vendedor,
		CASE WHEN O.[IdCompra] IS NOT NULL THEN 'S�' ELSE 'No' END AS Adjudicada,
		O.[Monto] AS Precio
	FROM
		[GD1C2016].[MASTERDBA].[VW_Ofertas] O,
		[GD1C2016].[MASTERDBA].[VW_Publicaciones] P
	WHERE O.[IdPublicacion] = P.[IdPublicacion]
	AND O.[IdRubro] = P.[IdRubro]
	AND P.[VisibilidadActual] = 1
	AND P.[IdUsuario] = @IdUsuario
END

GO
