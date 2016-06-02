USE [GD1C2016]
GO
/****** Object:  StoredProcedure [dbo].[SP_ResetCountLogin]    Script Date: 02/06/2016 01:47:01 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_ResetCountLogin] 
	@Usuario nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [GD1C2016].[MASTERDBA].[Usuarios]
	SET	[CantIntFallidos] = 0
	WHERE [UserName] = @Usuario
END

GO
