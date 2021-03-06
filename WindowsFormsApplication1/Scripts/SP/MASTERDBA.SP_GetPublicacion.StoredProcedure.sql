USE [GD1C2016]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetPublicacion]    Script Date: 01/07/2016 12:42:44 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetPublicacion] 
	@IdPublicacion int, 
	@IdUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		P.[IdPublicacion], P.[Descripcion], P.[Stock], P.[FechaInicio], P.[FechaVencimiento], P.[Precio], P.[PrecioReserva], P.[IdRubro], P.[DescripcionCorta] AS RubroDescripcionCorta, P.[DescripcionLarga] AS RubroDescripcionLarga, P.[IdUsuario], P.[NombreUsuario], P.[IdEstado], P.[EstadoDescripcion], P.[Envio], P.[IdTipo], P.[TipoDescripcion], P.[TipoEnvio], P.[IdVisibilidad], P.[VisibilidadDescripcion], V.[Precio] As VisibilidadPrecio, V.[Porcentaje], V.[EnvioPorcentaje]
	FROM
		[GD1C2016].[MASTERDBA].[VW_Publicaciones] P,
		[GD1C2016].[MASTERDBA].[Visibilidad_Publicacion] V
	WHERE P.[IdVisibilidad] = V.[IdVisibilidad]
	AND P.IdPublicacion = @IdPublicacion
	AND P.[VisibilidadActual] = 1
	AND P.[IdUsuario] = @IdUsuario
END

GO
