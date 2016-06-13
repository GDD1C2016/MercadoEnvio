USE [GD1C2016]
GO
/****** Object:  StoredProcedure [dbo].[SP_FindClientes]    Script Date: 7/6/2016 12:52:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_FindClientes] 
	@FiltroNombre nvarchar(255) = '', 
	@FiltroApellido nvarchar(255) = '',
	@FiltroEmail nvarchar(255) = '',
	@FiltroDni numeric(18,0)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT C.[IdUsuario] AS IdUsuario, C.[Nombre] AS Nombre, C.[Apellido] AS Apellido, C.[Calle] AS Calle, C.[Nro] AS NroCalle, C.[CP] AS CodigoPostal, C.[Departamento] AS Departamento,
	C.[Mail] AS Email, C.[FechaNacimiento] AS FechaNacimiento, C.[Localidad] AS Localidad, C.[NroDoc] AS NroDoc, C.[Piso] AS Piso, C.[Telefono] AS Telefono, C.[TipoDoc] AS TipoDoc,
	U.[Activo] AS Activo, U.[UserName] AS UserName, U.[PassEncr] AS PasswordEnc
	FROM [GD1C2016].[MASTERDBA].[Clientes] C, [GD1C2016].[MASTERDBA].[Usuarios] U
	WHERE C.[IdUsuario] = U.[IdUsuario] 
	AND (@FiltroNombre = '' OR C.[Nombre] LIKE @FiltroNombre + '%')
	AND (@FiltroApellido = '' OR C.[Apellido] LIKE @FiltroApellido + '%')
	AND (@FiltroEmail = '' OR C.[Mail] LIKE @FiltroEmail + '%')
	AND (@FiltroDni = 0 OR C.[NroDoc] = @FiltroDni)
END

