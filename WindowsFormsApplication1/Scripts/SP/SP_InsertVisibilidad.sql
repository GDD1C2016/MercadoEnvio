USE [GD1C2016]
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertVisibilidad]    Script Date: 11/6/2016 10:27:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_InsertVisibilidad] 
	@Descripcion nvarchar(255), 
	@Activa bit,
	@Porcentaje numeric(18,2),
	@EnvioPorcentaje numeric(18,2),
	@Precio numeric(18,2)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [GD1C2016].[MASTERDBA].[Visibilidad_Publicacion]
	VALUES (@Descripcion, @Precio, @Porcentaje, @EnvioPorcentaje, @Activa)

	SELECT V.[IdVisibilidad]
	FROM [GD1C2016].[MASTERDBA].[Visibilidad_Publicacion] V
	WHERE V.[IdVisibilidad] = @@IDENTITY
END

GO
