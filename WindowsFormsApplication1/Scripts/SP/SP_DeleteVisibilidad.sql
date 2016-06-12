USE [GD1C2016]
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteVisibilidad]    Script Date: 11/06/2016 05:38:33 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_DeleteVisibilidad] 
	@IdVisibilidad int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [GD1C2016].[MASTERDBA].[Visibilidad_Publicacion]
	SET	[Activa] = 0
	WHERE [IdVisibilidad] = @IdVisibilidad
END

GO
