USE [DBsubasta]
GO

DECLARE	@return_value int,
		@IDusuario int

EXEC	@return_value = [dbo].[cambiarRol]
		@DocNumero = 12,
		@IDrol = 1,
		@IDusuario = @IDusuario OUTPUT

SELECT	@IDusuario as N'@IDusuario'

SELECT	'Return Value' = @return_value

GO
