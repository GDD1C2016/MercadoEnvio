USE [GD1C2016]
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertRubro]    Script Date: 05/06/2016 01:54:11 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_InsertRubro] 
	@DescripcionCorta nvarchar(25), 
	@DescripcionLarga nvarchar(100)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [GD1C2016].[MASTERDBA].[Rubros]
	VALUES (@DescripcionCorta, @DescripcionLarga)

	SELECT R.[IdRubro], R.[DescripcionCorta], R.[DescripcionLarga]
	FROM [GD1C2016].[MASTERDBA].[Rubros] R
	WHERE R.[IdRubro] = @@IDENTITY
END

GO
