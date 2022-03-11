USE [BgPrueba]
GO
/****** Object:  Table [dbo].[tblpersona]    Script Date: 11/03/2022 03:16:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblpersona](
	[id_persona] [int] NOT NULL,
	[nombre] [nvarchar](100) NULL,
	[apellido] [nvarchar](100) NULL,
	[email] [nvarchar](100) NULL,
	[telefono] [nvarchar](100) NULL,
	[direction] [nvarchar](100) NULL,
	[fech_creacion] [nvarchar](100) NULL,
 CONSTRAINT [PK_tblpersona] PRIMARY KEY CLUSTERED 
(
	[id_persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbluser]    Script Date: 11/03/2022 03:16:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbluser](
	[id_user] [int] NOT NULL,
	[id_persona] [int] NOT NULL,
	[username] [nvarchar](100) NULL,
	[password] [nvarchar](100) NULL,
	[cargo] [nvarchar](100) NULL,
	[fech_creacion] [nvarchar](100) NULL,
 CONSTRAINT [PK_tbluser] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbluser]  WITH CHECK ADD  CONSTRAINT [FK_tbluser_tblpersona] FOREIGN KEY([id_persona])
REFERENCES [dbo].[tblpersona] ([id_persona])
GO
ALTER TABLE [dbo].[tbluser] CHECK CONSTRAINT [FK_tbluser_tblpersona]
GO
/****** Object:  StoredProcedure [dbo].[sp_consulta_personas]    Script Date: 11/03/2022 03:16:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_consulta_personas]

	@id_persona int = NULL,
	@name nvarchar(100) = NULL,
	@lastname nvarchar(100) = NULL,
	@email nvarchar(100) = NULL,
	@phonenumber nvarchar(100) = NULL,
	@direction nvarchar(100) = NULL,
	@fech_creacion nvarchar(100) = NULL

AS
BEGIN

	--exec [sp_consulta_personas]

		SELECT 
		   id_persona
		  ,nombre
		  ,apellido
		  ,email
		  ,telefono
		  ,direction
		  ,fech_creacion
		FROM tblpersona
		WHERE
			id_persona = CASE WHEN @id_persona = 0 OR  @id_persona IS NULL THEN  id_persona ELSE @id_persona END
			AND nombre = CASE WHEN @name = '' OR  @name IS NULL THEN  nombre ELSE @name END
			AND apellido = CASE WHEN @lastname = '' OR  @lastname IS NULL THEN  apellido ELSE @lastname END
			AND email = CASE WHEN @email = '' OR  @email IS NULL THEN  email ELSE @email END
			AND telefono = CASE WHEN @phonenumber = '' OR  @phonenumber IS NULL THEN  telefono ELSE @phonenumber END
			AND direction = CASE WHEN @direction = '' OR  @direction IS NULL THEN  direction ELSE @direction END
			AND fech_creacion = CASE WHEN @fech_creacion = '' OR  @fech_creacion IS NULL THEN  fech_creacion ELSE @fech_creacion END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_consulta_user]    Script Date: 11/03/2022 03:16:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_consulta_user] 

	@id_user nvarchar(100) = NULL,
	@id_persona nvarchar(100) = NULL,
	@username nvarchar(100) = NULL,
	@password nvarchar(100) = NULL,
	@cargo nvarchar(100) = NULL,
	@fech_creacion nvarchar(100) = NULL
AS
BEGIN
	SELECT [id_user]
		  ,[id_persona]
		  ,[username]
		  ,[password]
		  ,[cargo]
		  ,[fech_creacion]
    FROM [dbo].[tbluser]
	WHERE
		[id_user] = CASE WHEN @id_user = 0 OR  @id_user IS NULL THEN  [id_user] ELSE @id_user END
	    AND [id_persona] = CASE WHEN @id_persona = 0 OR  @id_persona IS NULL THEN  [id_persona] ELSE @id_persona END
		AND [username] = CASE WHEN @username = '' OR  @username IS NULL THEN  [username] ELSE @username END
		AND [password] = CASE WHEN @password = '' OR  @password IS NULL THEN  [password] ELSE @password END
		AND [cargo] = CASE WHEN @cargo = '' OR  @cargo IS NULL THEN  [cargo] ELSE @cargo END
		AND [fech_creacion] = CASE WHEN @fech_creacion = '' OR  @fech_creacion IS NULL THEN  [fech_creacion] ELSE @fech_creacion END
		
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ingresar_actualizar_usuario]    Script Date: 11/03/2022 03:16:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ingresar_actualizar_usuario]

	@id_user nvarchar(100) = NULL,
	@id_persona nvarchar(100) = NULL,
	@username nvarchar(100) = NULL,
	@password nvarchar(100) = NULL,
	@cargo nvarchar(100) = NULL,
	@fech_creacion nvarchar(100) = NULL

AS
BEGIN
	
	BEGIN TRY
		IF NOT EXISTS (SELECT [id_user] FROM [tbluser] WHERE [id_user] = @id_user)
		BEGIN
			INSERT INTO [dbo].[tbluser]
           ([id_user]
           ,[id_persona]
           ,[username]
           ,[password]
           ,[cargo]
           ,[fech_creacion])
        VALUES
           (@id_user
           ,@id_persona
           ,@username
           ,@password
           ,@cargo
           ,CONVERT(varchar,GETDATE(),103))
		END
		ELSE
		BEGIN
			UPDATE [dbo].[tbluser]
				SET 
				   [id_persona] = CASE WHEN @id_persona = 0 OR  @id_persona IS NULL THEN  [id_persona] ELSE @id_persona END
				   ,[username] = CASE WHEN @username = '' OR  @username IS NULL THEN  [username] ELSE @username END
				   ,[password] = CASE WHEN @password = '' OR  @password IS NULL THEN  [password] ELSE @password END
				   ,[cargo] = CASE WHEN @cargo = '' OR  @cargo IS NULL THEN  [cargo] ELSE @cargo END
		    WHERE 
				  [id_user] = @id_user
		END
		
		SELECT '1' AS CodigoRetorno, 'Inserto o Actualizo con exito' AS MensajeRetorno
	END TRY
	BEGIN CATCH
		SELECT '0' AS CodigoRetorno,  ERROR_MESSAGE() AS MensajeRetorno
	END CATCH
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_insertar_actualizar_persona]    Script Date: 11/03/2022 03:16:03 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_insertar_actualizar_persona]

	@id_persona nvarchar(100) = null,
	@name nvarchar(100) = null,
	@lastname nvarchar(100) = null,
	@email nvarchar(100) = null,
	@phonenumber nvarchar(100) = null,
	@direction nvarchar(100) = null,
	@fech_creacion nvarchar(100) = null

AS
BEGIN
	
	BEGIN TRY
		IF NOT EXISTS (select [id_persona] from [tblpersona] where [id_persona] = @id_persona)
		BEGIN
			INSERT INTO [dbo].[tblpersona]
					([id_persona]
					,[nombre]
					,[apellido]
					,[email]
					,[telefono]
					,[direction]
					,[fech_creacion])
		    VALUES
					(@id_persona
					,@name
					,@lastname
					,@email
					,@phonenumber
					,@direction
					,CONVERT(varchar,GETDATE(),103))
		END
		ELSE
		BEGIN
			UPDATE [dbo].[tblpersona]
				SET 
				   [nombre] = CASE WHEN @name = '' OR  @name IS NULL THEN  [nombre] ELSE @name END
				   ,[apellido] = CASE WHEN @lastname = '' OR  @lastname IS NULL THEN  [apellido] ELSE @lastname END
				   ,[email] = CASE WHEN @email = '' OR  @email IS NULL THEN  [email] ELSE @email END
				   ,[telefono] = CASE WHEN @phonenumber = '' OR  @phonenumber IS NULL THEN  [telefono] ELSE @phonenumber END
				   ,[direction] = CASE WHEN @direction = '' OR  @direction IS NULL THEN  [direction] ELSE @direction END
		    WHERE 
				  [id_persona] = @id_persona
		END

		SELECT '1' AS CodigoRetorno, 'Inserto o Actualizo con exito' AS MensajeRetorno
	END TRY
	BEGIN CATCH
		SELECT '0' AS CodigoRetorno,  ERROR_MESSAGE() AS MensajeRetorno
	END CATCH

	

END
GO
