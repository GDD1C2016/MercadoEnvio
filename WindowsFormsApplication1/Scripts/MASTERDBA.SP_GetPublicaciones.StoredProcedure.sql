USE [GD1C2016]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetPublicaciones]    Script Date: 27/06/2016 09:25:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetPublicaciones] 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		P.[IdPublicacion], P.[Descripcion], P.[Stock], P.[FechaInicio], P.[FechaVencimiento], P.[Precio], P.[PrecioReserva], P.[IdRubro], P.[IdUsuario], P.[IdEstado], P.[Envio],
		T.[IdTipo], T.[Descripcion] AS DescripcionTipoPublicacion, T.[Envio],
		V.[IdVisibilidad], V.[Descripcion] AS DescripcionVisibilidad, V.[Precio], V.[Porcentaje], V.[EnvioPorcentaje]
	FROM
		[GD1C2016].[MASTERDBA].[Publicaciones] P,
		[GD1C2016].[MASTERDBA].[Estado_Publicacion] E,
		[GD1C2016].[MASTERDBA].[Tipo_Publicacion] T,
		[GD1C2016].[MASTERDBA].[Publicaciones_Visibilidad] PV,
		[GD1C2016].[MASTERDBA].[Visibilidad_Publicacion] V
	WHERE P.[IdEstado] = E.[IdEstado]
--	AND E.[Descripcion] = 'Activa'
	AND P.[IdTipo] = T.[IdTipo]
	AND P.[IdPublicacion] = PV.[IdPublicacion]
	AND PV.[Activa] = 1
	AND PV.[IdVisibilidad] = V.[IdVisibilidad]
	AND P.[Stock] > 0
END

GO
