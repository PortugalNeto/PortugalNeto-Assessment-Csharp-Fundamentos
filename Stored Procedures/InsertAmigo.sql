USE [GerenciadorAniversarioDB]
GO
/****** Object:  StoredProcedure [dbo].[InsertAmigo]    Script Date: 28/06/2021 20:28:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[InsertAmigo] 
	@nomeAmigo varchar(30),
	@sobrenomeAmigo varchar (50) = null,
	@dataAniversario date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO
	dbo.amigos
	(Nome, Sobrenome, Aniversario, Active)
	values 
	(@nomeAmigo, @sobrenomeAmigo, @dataAniversario, 1)

END
