USE [GerenciadorAniversarioDB]
GO
/****** Object:  StoredProcedure [dbo].[SelectAllAmigos]    Script Date: 28/06/2021 20:29:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SelectAllAmigos] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from dbo.amigos
	where Active = 1
END
