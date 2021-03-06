USE [GD1C2016]
GO
/****** Object:  View [MASTERDBA].[VW_Facturas]    Script Date: 27/06/2016 09:25:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE VIEW [MASTERDBA].[VW_Facturas] 
AS
SELECT
	F.[IdFactura],
	F.[IdPublicacion],
	P.[IdUsuario],
	COALESCE(U.[Nombre] + ' ' + U.[Apellido], U.[RazonSocial]) AS NombreUsuario,
	F.[Fecha],
	F.[Total],
	F.[IdFormaPago],
	FP.[Descripcion] AS FormaPago
FROM
	[GD1C2016].[MASTERDBA].[Facturas] F,
	[GD1C2016].[MASTERDBA].[Publicaciones] P,
	[GD1C2016].[MASTERDBA].[VW_Usuarios] U,
	[GD1C2016].[MASTERDBA].[Formas_Pago] FP
WHERE F.[IdPublicacion] = P.[IdPublicacion]
AND F.[IdFormaPago] = FP.[IdFormaPago]
AND P.[IdUsuario] = U.[IdUsuario]
GO
