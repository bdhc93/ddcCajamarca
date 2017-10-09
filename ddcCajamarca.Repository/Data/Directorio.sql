/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4001)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/

USE [DBDDC]
GO
SET IDENTITY_INSERT [dbo].[OcupacionCultural] ON 
GO
INSERT [dbo].[OcupacionCultural] ([Id], [Nombre], [FechaRegistro]) VALUES (1, N'DESCONOCIDA', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[OcupacionCultural] ([Id], [Nombre], [FechaRegistro]) VALUES (2, N'ACTOR / ACTRIZ', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[OcupacionCultural] ([Id], [Nombre], [FechaRegistro]) VALUES (3, N'ARTESANO (A)', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[OcupacionCultural] ([Id], [Nombre], [FechaRegistro]) VALUES (4, N'DANZANTE', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[OcupacionCultural] ([Id], [Nombre], [FechaRegistro]) VALUES (5, N'ESCRITOR (A)', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[OcupacionCultural] ([Id], [Nombre], [FechaRegistro]) VALUES (6, N'GESTOR (A), PROMOTOR (A) CULTURAL', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[OcupacionCultural] ([Id], [Nombre], [FechaRegistro]) VALUES (8, N'RESTAURADOR (A)', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[OcupacionCultural] ([Id], [Nombre], [FechaRegistro]) VALUES (10, N'TITIRITERO (A)', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[OcupacionCultural] ([Id], [Nombre], [FechaRegistro]) VALUES (11, N'ARTISTA PLASTICO', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[OcupacionCultural] ([Id], [Nombre], [FechaRegistro]) VALUES (12, N'ARQUEÓLOGO', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[OcupacionCultural] ([Id], [Nombre], [FechaRegistro]) VALUES (13, N'MÚSICO', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[OcupacionCultural] OFF
GO
SET IDENTITY_INSERT [dbo].[Organizacion] ON 
GO
INSERT [dbo].[Organizacion] ([Id], [Nombre], [FechaRegistro]) VALUES (1, N'DESCONOCIDA', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Organizacion] ([Id], [Nombre], [FechaRegistro]) VALUES (2, N'Dirección Desconcentrada de Cultura Cajamarca', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Organizacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Profesion] ON 
GO
INSERT [dbo].[Profesion] ([Id], [Nombre], [FechaRegistro]) VALUES (1, N'DESCONOCIDA', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Profesion] ([Id], [Nombre], [FechaRegistro]) VALUES (5, N'ABOGADO(A)', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Profesion] ([Id], [Nombre], [FechaRegistro]) VALUES (6, N'ADMINISTRATIVO DE VENTAS', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Profesion] ([Id], [Nombre], [FechaRegistro]) VALUES (7, N'CARPINTERO(A)', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Profesion] ([Id], [Nombre], [FechaRegistro]) VALUES (8, N'CONTADOR(A)', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Profesion] ([Id], [Nombre], [FechaRegistro]) VALUES (9, N'ENFERMERO(A)', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Profesion] ([Id], [Nombre], [FechaRegistro]) VALUES (10, N'COMUNICADOR SOCIAL', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Profesion] ([Id], [Nombre], [FechaRegistro]) VALUES (11, N'PSICÓLOGO(A)', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Profesion] ([Id], [Nombre], [FechaRegistro]) VALUES (12, N'INGENIERO(A)', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Profesion] ([Id], [Nombre], [FechaRegistro]) VALUES (14, N'DOCENTE', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Profesion] ([Id], [Nombre], [FechaRegistro]) VALUES (15, N'ARQUITECTO(A)', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Profesion] ([Id], [Nombre], [FechaRegistro]) VALUES (16, N'DIRECTOR(A)', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Profesion] ([Id], [Nombre], [FechaRegistro]) VALUES (18, N'GEÓLOGO(A)', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Profesion] ([Id], [Nombre], [FechaRegistro]) VALUES (21, N'GUARDIA DE SEGURIDAD', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Profesion] ([Id], [Nombre], [FechaRegistro]) VALUES (22, N'DISEÑADOR(A) GRÁFICO', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Profesion] ([Id], [Nombre], [FechaRegistro]) VALUES (23, N'TRADUCTOR(A)', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Profesion] ([Id], [Nombre], [FechaRegistro]) VALUES (24, N'ASESOR(A) DE IMAGEN', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Profesion] ([Id], [Nombre], [FechaRegistro]) VALUES (25, N'PRODUCTOR(A) DE RADIOTELEVISION', CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Profesion] OFF
GO
SET IDENTITY_INSERT [dbo].[Persona] ON 
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [Cargo], [IdOcupacionCultural], [IdProfesion]) VALUES (1, N'ROCHESTER', N'EDULFO HOYOS', NULL, N'976683800', CAST(N'2017-10-05T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, NULL, 1, 1)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [Cargo], [IdOcupacionCultural], [IdProfesion]) VALUES (2, N'KUYKU SUKCHA', N'JULIO ZAMORA CASTRO', N'AV. LUIS REBAZA NEYRA N°487', N'976787846', CAST(N'2017-10-05T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, NULL, 1, 1)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [Cargo], [IdOcupacionCultural], [IdProfesion]) VALUES (3, NULL, N'MARÍA DE LOS ÁNGELES ZALDIVAR', N'JR. ILLIMANI 164- SEGUNDO PISO', N'076361878', CAST(N'2017-10-05T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, NULL, 1, 1)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [Cargo], [IdOcupacionCultural], [IdProfesion]) VALUES (4, NULL, N'WILDER QUILICHE QUIROZ', N'JR. MIGUEL GRAU N 120', N'076 632011', CAST(N'2017-10-05T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, NULL, 1, 1)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [Cargo], [IdOcupacionCultural], [IdProfesion]) VALUES (5, NULL, N'HERMEREJILDO ESCOBAL CERQUIN', N'JR. LA LIBERTAD N 105', N'363100', CAST(N'2017-10-05T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, NULL, 1, 1)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [Cargo], [IdOcupacionCultural], [IdProfesion]) VALUES (6, NULL, N'FERNANDO ASUNCION ARBILDO QUIROZ', NULL, N'Jr. Leoncio Prado N 360', CAST(N'2017-10-05T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, NULL, 1, 1)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [Cargo], [IdOcupacionCultural], [IdProfesion]) VALUES (7, NULL, N'JUAN HUAMÁN ALCÁNTARA', N'PSJ. CHEPÉN 122', N'955883232', CAST(N'2017-10-05T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, NULL, 1, 1)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [Cargo], [IdOcupacionCultural], [IdProfesion]) VALUES (8, NULL, N'OSCAR BECERRA CIEZA', N'JR. UCAYALI 149', N'362731', CAST(N'2017-10-05T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, NULL, 1, 1)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [Cargo], [IdOcupacionCultural], [IdProfesion]) VALUES (9, NULL, N'JULIO CÉSAR NURENACRUZ', N'JR. HUANUCO 1239', N'361358', CAST(N'2017-10-05T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, NULL, 1, 1)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [Cargo], [IdOcupacionCultural], [IdProfesion]) VALUES (10, NULL, N'GERMAN CHAVEZ IZQUIERDO', N'JR. TARAPACA N 855', N'990453144', CAST(N'2017-10-05T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, NULL, 1, 1)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [Cargo], [IdOcupacionCultural], [IdProfesion]) VALUES (11, NULL, N'CONSULEO LEZCANO', NULL, N'976429950', CAST(N'2017-10-05T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, NULL, 1, 1)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [Cargo], [IdOcupacionCultural], [IdProfesion]) VALUES (12, NULL, N'MARÍA DEL CARMEN PONCE DE LEÓN VELASCO', N'CALLE MANUEL OLAECHEA ° 540 ', N'4457364', CAST(N'2017-10-05T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, NULL, 1, 1)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [Cargo], [IdOcupacionCultural], [IdProfesion]) VALUES (13, NULL, N'VÍCTOR ALBERTO MARÍN TELLO', NULL, N'#953987999', CAST(N'2017-10-05T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, NULL, 1, 1)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [Cargo], [IdOcupacionCultural], [IdProfesion]) VALUES (14, NULL, N'AMPARITO LUCILA CASTAÑEDA ABANTO', NULL, N'#941991849', CAST(N'2017-10-05T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, NULL, 1, 1)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [Cargo], [IdOcupacionCultural], [IdProfesion]) VALUES (15, NULL, N'ÁLVARO CERQUÍN FERNÁNDEZ', NULL, N'#976031495', CAST(N'2017-10-05T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, NULL, 1, 1)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [Cargo], [IdOcupacionCultural], [IdProfesion]) VALUES (16, NULL, N'LORENZO CABRERA', N'JR. JOSE OLAYA N °660', N'996885072', CAST(N'2017-10-05T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, NULL, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Persona] OFF
GO
