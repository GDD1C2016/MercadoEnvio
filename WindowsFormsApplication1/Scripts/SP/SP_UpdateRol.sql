USE [GD1C2016]
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateRol]    Script Date: 12/6/2016 1:26:49 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_UpdateRol] 
	@Descripcion nvarchar(255), 
	@Activo bit,
	@IdRol int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [GD1C2016].[MASTERDBA].[Roles]
	SET Descripcion = @Descripcion, Activo = @Activo
	WHERE
	[IdRol] = @IdRol
END

