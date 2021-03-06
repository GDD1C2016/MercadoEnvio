USE [GD1C2016]
GO
/****** Object:  StoredProcedure [MASTERDBA].[SP_InsertEmpresa]    Script Date: 27/06/2016 09:25:45 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_InsertEmpresa] 
	@IdUsuario int, 
	@RazonSocial nvarchar(255), 
	@Mail nvarchar(255), 
	@Telefono nvarchar(50), 
	@Calle nvarchar(255), 
    @Nro numeric(18,0), 
	@Piso numeric(18,0), 
	@Departamento nvarchar(50), 
	@Localidad nvarchar(100), 
	@CodigoPostal nvarchar(50), 
	@Ciudad nvarchar(100), 
	@CUIT nvarchar(50), 
	@Contacto nvarchar(255), 
	@Rubro nvarchar(255), 
	@FechaCreacion datetime
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [GD1C2016].[MASTERDBA].[Empresas]
	VALUES	(
			@IdUsuario,
			@RazonSocial,
			@Mail,
			@Telefono,
			@Calle,
		    @Nro,
			@Piso,
			@Departamento,
			@Localidad,
			@CodigoPostal,
			@Ciudad,
			@CUIT,
			@Contacto,
			@Rubro,
			@FechaCreacion
			)
END

GO
