USE [GD1C2016]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetRolesUsuario]    Script Date: 11/06/2016 05:38:33 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetRolesUsuario] 
	@IdUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT U.[IdRol]
	FROM [GD1C2016].[MASTERDBA].[Usuarios_Roles] U
	WHERE U.[IdUsuario] = @IdUsuario
END

GO
