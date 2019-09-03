USE [DBsubasta]
GO
/****** Object:  StoredProcedure [dbo].[cambiarRol]    Script Date: 9/3/2019 1:42:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[cambiarRol] @DocNumero int = NULL, @IDrol int = NULL, @IDusuario int OUT
AS
BEGIN
	SELECT @IDusuario = u.IDusuario FROM dbo.Usuarios AS u WHERE u.DocNumero = @DocNumero;
	IF EXISTS(SELECT * FROM dbo.RolesXUsuario AS ru WHERE ru.IDusuario = @IDusuario AND ru.IDrol = @IDrol)
	BEGIN
		UPDATE dbo.Usuarios SET RolActual = @IDrol WHERE IDusuario = @IDusuario
	END
END
