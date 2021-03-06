USE [GD1C2016]
GO
/****** Object:  View [MASTERDBA].[VW_Usuarios]    Script Date: 27/06/2016 09:25:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE VIEW [MASTERDBA].[VW_Usuarios] 
AS
SELECT
	U.[IdUsuario],
	U.[UserName],
	U.[PassEncr],
	U.[CantIntFallidos],
	U.[Activo],
	C.[Apellido],
	C.[Nombre],
	E.[RazonSocial],
	C.[TipoDoc],
	C.[NroDoc],
	COALESCE (C.[Mail], E.[Mail]) AS Mail,
	COALESCE (C.[Telefono], E.[Telefono]) AS Telefono,
	COALESCE (C.[Calle], E.[Calle]) AS Calle,
	COALESCE (C.[Nro], E.[Nro]) AS Nro,
	COALESCE (C.[Piso], E.[Piso]) AS Piso,
	COALESCE (C.[Departamento], E.[Departamento]) AS Departamento,
	COALESCE (C.[Localidad], E.[Localidad]) AS Localidad,
	COALESCE (C.[CP], E.[CP]) AS CP,
	E.[Ciudad],
	E.[CUIT],
	E.[Contacto],
	E.[Rubro],
	C.[FechaNacimiento],
	COALESCE (C.[FechaCreacion], E.[FechaCreacion]) FechaCreacion
FROM [GD1C2016].[MASTERDBA].[Usuarios] U
LEFT OUTER JOIN [GD1C2016].[MASTERDBA].[Clientes] C
ON U.[IdUsuario] = C.[IdUsuario]
LEFT OUTER JOIN [GD1C2016].[MASTERDBA].[Empresas] E
ON U.[IdUsuario] = E.[IdUsuario]
GO
