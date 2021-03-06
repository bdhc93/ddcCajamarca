USE [DB_A38FEF_ddcCajamarca]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[FechaRegistro] [datetime2](7) NOT NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_dbo.Activo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ambiente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Aforo] [int] NULL,
	[Color] [nvarchar](max) NOT NULL,
	[FechaRegistro] [datetime2](7) NOT NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_dbo.Ambiente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleHorasEvento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdEventoEnsayo] [int] NOT NULL,
	[FechaInicio] [datetime2](7) NOT NULL,
	[FechaFin] [datetime2](7) NOT NULL,
	[TodoDia] [bit] NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_dbo.DetalleHorasEvento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleRequerimiento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdEventoEnsayo] [int] NOT NULL,
	[IdActivo] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[FechaRegistro] [datetime2](7) NOT NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_dbo.DetalleRequerimiento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventoEnsayo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreActividad] [nvarchar](max) NOT NULL,
	[InstitucionEncargada] [nvarchar](max) NULL,
	[InformacionAdicional] [nvarchar](max) NULL,
	[TodoDia] [bit] NULL,
	[Evento] [bit] NULL,
	[FechaInicio] [datetime2](7) NOT NULL,
	[FechaFin] [datetime2](7) NOT NULL,
	[FechaRegistro] [datetime2](7) NOT NULL,
	[Lunes] [bit] NULL,
	[Martes] [bit] NULL,
	[Miercoles] [bit] NULL,
	[Jueves] [bit] NULL,
	[Viernes] [bit] NULL,
	[Sabado] [bit] NULL,
	[Domingo] [bit] NULL,
	[IdAmbiente] [int] NOT NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_dbo.EventoEnsayo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OcupacionCultural](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[FechaRegistro] [datetime2](7) NOT NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_dbo.OcupacionCultural] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organizacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Direccion] [nvarchar](max) NULL,
	[FechaRegistro] [datetime2](7) NOT NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_dbo.Organizacion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerfilUsuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [nvarchar](max) NOT NULL,
	[Imagen] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[NombreApellidos] [nvarchar](max) NULL,
	[NombreMostrar] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.PerfilUsuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreArtistico] [nvarchar](max) NULL,
	[NombreApellidos] [nvarchar](max) NOT NULL,
	[Direccion] [nvarchar](max) NULL,
	[Telefono] [nvarchar](max) NOT NULL,
	[FechaRegistro] [datetime2](7) NOT NULL,
	[FechaNacimiento] [datetime2](7) NULL,
	[Email] [nvarchar](max) NULL,
	[Imagen] [nvarchar](max) NULL,
	[RedesSociales] [nvarchar](max) NULL,
	[IdOrganizacion] [int] NOT NULL,
	[IdOcupacionCultural] [int] NOT NULL,
	[IdProfesion] [int] NOT NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_dbo.Persona] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[FechaRegistro] [datetime2](7) NOT NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK_dbo.Profesion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegUsuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [nvarchar](max) NOT NULL,
	[Modulo] [nvarchar](max) NOT NULL,
	[Cambio] [nvarchar](max) NOT NULL,
	[IdModulo] [nvarchar](max) NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.RegUsuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Membership](
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[ConfirmationToken] [nvarchar](128) NULL,
	[IsConfirmed] [bit] NULL,
	[LastPasswordFailureDate] [datetime] NULL,
	[PasswordFailuresSinceLastSuccess] [int] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordChangedDate] [datetime] NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[PasswordVerificationToken] [nvarchar](128) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_OAuthMembership](
	[Provider] [nvarchar](30) NOT NULL,
	[ProviderUserId] [nvarchar](100) NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Provider] ASC,
	[ProviderUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.webpages_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_UsersInRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.webpages_UsersInRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [IsConfirmed]
GO
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [PasswordFailuresSinceLastSuccess]
GO
ALTER TABLE [dbo].[DetalleHorasEvento]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DetalleHorasEvento_dbo.EventoEnsayo_IdEventoEnsayo] FOREIGN KEY([IdEventoEnsayo])
REFERENCES [dbo].[EventoEnsayo] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetalleHorasEvento] CHECK CONSTRAINT [FK_dbo.DetalleHorasEvento_dbo.EventoEnsayo_IdEventoEnsayo]
GO
ALTER TABLE [dbo].[DetalleRequerimiento]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DetalleRequerimiento_dbo.Activo_IdActivo] FOREIGN KEY([IdActivo])
REFERENCES [dbo].[Activo] ([Id])
GO
ALTER TABLE [dbo].[DetalleRequerimiento] CHECK CONSTRAINT [FK_dbo.DetalleRequerimiento_dbo.Activo_IdActivo]
GO
ALTER TABLE [dbo].[DetalleRequerimiento]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DetalleRequerimiento_dbo.EventoEnsayo_IdEventoEnsayo] FOREIGN KEY([IdEventoEnsayo])
REFERENCES [dbo].[EventoEnsayo] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetalleRequerimiento] CHECK CONSTRAINT [FK_dbo.DetalleRequerimiento_dbo.EventoEnsayo_IdEventoEnsayo]
GO
ALTER TABLE [dbo].[EventoEnsayo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EventoEnsayo_dbo.Ambiente_IdAmbiente] FOREIGN KEY([IdAmbiente])
REFERENCES [dbo].[Ambiente] ([Id])
GO
ALTER TABLE [dbo].[EventoEnsayo] CHECK CONSTRAINT [FK_dbo.EventoEnsayo_dbo.Ambiente_IdAmbiente]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Persona_dbo.OcupacionCultural_IdOcupacionCultural] FOREIGN KEY([IdOcupacionCultural])
REFERENCES [dbo].[OcupacionCultural] ([Id])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_dbo.Persona_dbo.OcupacionCultural_IdOcupacionCultural]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Persona_dbo.Organizacion_IdOrganizacion] FOREIGN KEY([IdOrganizacion])
REFERENCES [dbo].[Organizacion] ([Id])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_dbo.Persona_dbo.Organizacion_IdOrganizacion]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Persona_dbo.Profesion_IdProfesion] FOREIGN KEY([IdProfesion])
REFERENCES [dbo].[Profesion] ([Id])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_dbo.Persona_dbo.Profesion_IdProfesion]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.webpages_UsersInRoles_dbo.PerfilUsuario_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[PerfilUsuario] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [FK_dbo.webpages_UsersInRoles_dbo.PerfilUsuario_UserId]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.webpages_UsersInRoles_dbo.webpages_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [FK_dbo.webpages_UsersInRoles_dbo.webpages_Roles_RoleId]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarDetalleRequerimientos]
	@IdEventoEnsayo int,
	@IdActivo int,
	@Cantidad int,
	@Estado bit
AS
INSERT INTO DetalleRequerimiento
                         (IdEventoEnsayo, IdActivo, Cantidad, FechaRegistro, Estado)
VALUES        (@IdEventoEnsayo,@IdActivo,@Cantidad,GETDATE(),@Estado)
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarDetalleRequerimientos]
	@IdEventoEnsay int
AS
BEGIN
	DELETE FROM DetalleRequerimiento
	WHERE IdEventoEnsayo = @IdEventoEnsay
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModificarEventoEnsayo]
	@NombreActividad varchar(100),
	@InstitucionEncargada varchar(100),
	@InformacionAdicional varchar(100),
	@IdEvento int
AS

UPDATE       EventoEnsayo
SET                NombreActividad =@NombreActividad, InstitucionEncargada =@InstitucionEncargada, InformacionAdicional =@InformacionAdicional
WHERE Id = @IdEvento
GO
