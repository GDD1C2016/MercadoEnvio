USE [GD1C2016]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetRolesFuncionalidades]    Script Date: 02/06/2016 01:08:32 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetRolesFuncionalidades] 
@IdRol int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT F.[IdFuncionalidad]
	FROM [GD1C2016].[MASTERDBA].[Roles_Funcionalidades] F
	WHERE F.IdRol = @IdRol
END
