USE [GerenciadorAniversarioDB]
GO
/****** Object:  StoredProcedure [dbo].[UpdateAmigo]    Script Date: 28/06/2021 20:30:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[UpdateAmigo] 
	@nomeAmigo varchar(30),
	@sobrenomeAmigo varchar (50) = null,
	@dataAniversario date,
	@IdAmigo int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE DBO.amigos
		SET Nome = @nomeAmigo,
			Sobrenome = @sobrenomeAmigo,
			Aniversario = @dataAniversario
				where Id = @IdAmigo
				and Active = 1
END
