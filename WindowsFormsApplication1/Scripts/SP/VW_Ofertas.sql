USE [GD1C2016]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE VIEW [MASTERDBA].[VW_Ofertas] 
AS
SELECT
	O.[IdOferta],
	O.[IdPublicacion],
	P.[Descripcion],
	P.[IdRubro],
	R.[DescripcionLarga] AS RubroDescripcion,
	O.[Fecha],
	O.[Monto],
	O.[IdUsuario],
	COALESCE(U.[Nombre] + ' ' + U.[Apellido], U.[RazonSocial]) AS NombreUsuario
FROM
	[GD1C2016].[MASTERDBA].[Ofertas] O,
	[GD1C2016].[MASTERDBA].[Publicaciones] P,
	[GD1C2016].[MASTERDBA].[VW_Usuarios] U,
	[GD1C2016].[MASTERDBA].[Rubros] R
WHERE O.[IdPublicacion] = P.[IdPublicacion]
AND O.[IdUsuario] = U.[IdUsuario]
AND P.[IdRubro] = R.[IdRubro]