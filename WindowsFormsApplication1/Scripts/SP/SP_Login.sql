USE [GD1C2016]
GO

/****** Object:  StoredProcedure [dbo].[SP_Login]    Script Date: 10/05/2016 04:08:02 p.m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [MASTERDBA].[SP_Login] 
	-- Add the parameters for the stored procedure here
	@Usuario nvarchar(50), 
	@Password nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT count(*) FROM [GD1C2016].[MASTERDBA].[Usuarios]
	WHERE [UserNanme] = @Usuario and [PassEncr] = @Password
END

GO

