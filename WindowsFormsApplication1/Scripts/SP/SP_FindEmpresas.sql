USE [GD1C2016]
GO
/****** Object:  StoredProcedure [dbo].[SP_FindEmpresas]    Script Date: 7/6/2016 12:52:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_FindEmpresas] 
	@FiltroRazonSocial nvarchar(255) = '', 
	@FiltroCuit nvarchar(50) = '',
	@FiltroEmail nvarchar(255) = ''
AS
BEGIN
	SET NOCOUNT ON;

	SELECT E.[IdUsuario] AS IdUsuario, E.[RazonSocial] AS RazonSocial, E.[Ciudad] AS Ciudad, E.[Calle] AS Calle, E.[Nro] AS NroCalle, E.[CP] AS CodigoPostal, E.[Departamento] AS Departamento,
	E.[Mail] AS Email, E.[Rubro] AS Rubro, E.[Localidad] AS Localidad, E.[CUIT] AS Cuit, E.[Piso] AS Piso, E.[Telefono] AS Telefono, E.[Contacto] AS Contacto,
	U.[Activo] AS Activo, U.[UserName] AS UserName, U.[PassEncr] AS PasswordEnc
	FROM [GD1C2016].[MASTERDBA].[Empresas] E, [GD1C2016].[MASTERDBA].[Usuarios] U
	WHERE E.[IdUsuario] = U.[IdUsuario] 
	AND (@FiltroRazonSocial = '' OR E.[RazonSocial] LIKE @FiltroRazonSocial + '%')
	AND (@FiltroCuit = '' OR E.[CUIT] LIKE @FiltroCuit + '%')
	AND (@FiltroEmail = '' OR E.[Mail] LIKE @FiltroEmail + '%')
END

