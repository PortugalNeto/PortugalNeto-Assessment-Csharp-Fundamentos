USE [GerenciadorAniversarioDB]
GO
/****** Object:  StoredProcedure [dbo].[DeleteAmigo]    Script Date: 28/06/2021 20:27:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[DeleteAmigo]
	@AmigoId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dbo.amigos
	SET Active = 0
	Where Id = @AmigoId
END
