USE [GD1C2016]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_GetEmpresaByCUIT]    Script Date: 27/06/2016 09:25:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_GetEmpresaByCUIT] 
	@CUIT nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT E.[IdUsuario] AS IdUsuario, E.[RazonSocial] AS RazonSocial, E.[Ciudad] AS Ciudad, E.[Calle] AS Calle, E.[Nro] AS NroCalle, E.[CP] AS CodigoPostal, E.[Departamento] AS Departamento, E.[Mail] AS Email, E.[Rubro] AS Rubro, E.[Localidad] AS Localidad, E.[CUIT] AS Cuit, E.[Piso] AS Piso, E.[Telefono] AS Telefono, E.[Contacto] AS Contacto, U.[Activo] AS Activo, U.[UserName] AS UserName, U.[PassEncr] AS PasswordEnc
	FROM [GD1C2016].[MASTERDBA].[Empresas] E, [GD1C2016].[MASTERDBA].[Usuarios] U
	WHERE E.[IdUsuario] = U.[IdUsuario]
	AND UPPER(E.[CUIT]) = UPPER(@CUIT)
END

GO
