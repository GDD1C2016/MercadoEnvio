USE [GD1C2016]
GO
/****** Object:  Trigger [MASTERDBA].[TR_UpdatePublicacionOferta]    Script Date: 03/07/2016 11:07:24 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:  <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE TRIGGER [MASTERDBA].[TR_UpdatePublicacionOferta] 
ON [GD1C2016].[MASTERDBA].[Ofertas] AFTER INSERT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @IdPublicacion numeric(18,0),
			@Monto numeric(18,2)

	SELECT @IdPublicacion = IdPublicacion, @Monto = Monto FROM inserted

	UPDATE [GD1C2016].[MASTERDBA].[Publicaciones]
	SET [Precio] = [Precio] + @Monto
	WHERE [IdPublicacion] = @IdPublicacion
END

GO
