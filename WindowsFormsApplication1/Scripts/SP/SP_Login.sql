USE [GD1C2016]
GO
/****** Object:  StoredProcedure [dbo].[SP_Login]    Script Date: 02/06/2016 01:47:01 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_Login] 
	@Usuario nvarchar(50), 
	@Password nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT U.[IdUsuario], U.[UserName], U.[PassEncr], U.[CantIntFallidos], U.[Activo]
	FROM [GD1C2016].[MASTERDBA].[Usuarios] U
	WHERE U.[UserName] = @Usuario
END

GO
