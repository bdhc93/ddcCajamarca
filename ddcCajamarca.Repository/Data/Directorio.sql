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
INSERT [dbo].[Organizacion] ([Id], [Nombre], [Direccion], [FechaRegistro]) VALUES (1, N'DESCONOCIDA', NULL, CAST(N'2017-09-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Organizacion] ([Id], [Nombre], [Direccion], [FechaRegistro]) VALUES (2, N'DIRECCIÓN DESCONCENTRADA DE CULTURA CAJAMARCA', N'', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Organizacion] ([Id], [Nombre], [Direccion], [FechaRegistro]) VALUES (4, N'AGRUPACIÓN DE DANZAS "CUMBI"', N'', CAST(N'2017-10-11T00:00:00.0000000' AS DateTime2))
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
INSERT [dbo].[Profesion] ([Id], [Nombre], [FechaRegistro]) VALUES (27, N'ESCRITOR', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Profesion] ([Id], [Nombre], [FechaRegistro]) VALUES (28, N'DANZANTE', CAST(N'2017-10-11T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Profesion] ([Id], [Nombre], [FechaRegistro]) VALUES (29, N'DANZANTE', CAST(N'2017-10-11T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Profesion] OFF
GO
SET IDENTITY_INSERT [dbo].[Persona] ON 
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (7, NULL, N'CARLOS ERNESTO CABRERA MIRANDA', N'JR.CHABUCAGRANDE 104-SAN CARLOS', N'935447689', CAST(N'2017-10-11T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'CAMINET13@GMAIL.COM', N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (8, NULL, N'MARÍA ANITA JARA YOPLA', N'JR. DIEGO FERRER N. 509', N'982558477', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'ANITJAYO@HOTMAIL.COM', N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (9, NULL, N'MARCO ANTONIO ALVARADO AGUILAR ', N'JR. FRATERNIDAD 258', N'976963315', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'TONALVA@HOTMAIL.COM', N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (10, NULL, N'ANITA DEL CARMEN CARRERA CABRERA', N'JR. ANCON N. 749', N'990177087', CAST(N'2017-10-16T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'ANITA.DC.CORREA@OUTLOOK.ES', N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (11, NULL, N'ANTONIO GOICOCHEA GRUZADO', N'JR. TARCISO BAZÁN 240-HORACIO ZEBALLOS', N'976939495', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'ANTONIOGOICOCHEACRU@GMAIL.COM', N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (12, NULL, N'GUTEMBERG ALIAGA ZEGARRA', N'HORACIO ZEBALLOS ', N'976991785', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'GAZ_MAR@HOTMAIL.COM', N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (13, NULL, N'LUZMAN  SALAS SALAS ', N'JR. LOS FRESNOS 101- EL INGENIO', N'951769216', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'LUGONSACAJ0505@YAHOO.COM', N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (14, NULL, N'JULIO SARMIENTO GUTIERREZ', N'JR. 2 DE MAYO 744', N'076-364053 - 955644165', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SGJULIO@YAHOO.COM', N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (15, NULL, N'SEGUNDO  ROJAS FERNANDEZ', N'PASAJE ATAHUALPA 427', N'943013599', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'SROJASFERNANDEZ@YAHOO.ES', N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (16, NULL, N'GASPAR VIRILO MÉNDEZ CRUZ', N' JR. LEONCIO PRADO 487 LA COLMENA ', N'976492877', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'CIPCAJAMARCA@CIP.ORG.PEGMENDEZCRUZ', N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (17, NULL, N'DAVID SALDAÑA SANGAY', N'JR. HUANUCO 936', N'984111102', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'CATEQUILL@HOTMAIL.COM', N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (18, NULL, N'RUBÍ AMPARO CHUQUILÍN CHÁVARRY ', N'JIRÓN AMAZONAS 1041', N'976596910', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'AMRUBY350@HOTMAIL.COM', N'/PerfilImg/SinImagen.jpg', NULL, 1, 1, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (19, NULL, N'FELIX ALEJANDRO PERALTA PAJARES', N'CRUCE A LLACANORA-BAÑOS DEL INCA', N'976578540', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'FELIXPP_21@HOTMAIL.COM', N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (21, NULL, N'JUAN  OBLITAS CARRERO - CUTERVO', NULL, N'955503567', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (22, NULL, N'VICTOR MEDINA - CUTERVO', NULL, N'945424989', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'CIDEINCUTERVO@HOTMAIL.COM', N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (23, NULL, N'BETTY   ROCHA VIUDA DE  QUIROZ - CELENDÍN', NULL, N'949068014', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (24, NULL, N'TITO ZEGARRA MARÍN - CELENDÍN', NULL, N'947987359', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (25, NULL, N'COSME ROJAS - PIURA', NULL, N'962768221', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (26, NULL, N'YESENIA  MOSTACERO TERRONES - HUALGAYOC', NULL, N'959917435', CAST(N'2017-10-11T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (27, NULL, N'HECTOR  JAVIER  SAAVEDRA TOCTO - SAN IGNACIO', NULL, N'927601944', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (28, NULL, N'CARLOS QUEVEDO - CAJABAMBA', NULL, N'956616541', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (29, NULL, N'TOMAS PAREDES DIAZ - JAEN', NULL, N'979904485 ', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (30, NULL, N'ESTUARDO VILLANUEVA - CHOTA', NULL, N'985791404 ', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (31, NULL, N'WILFREDO  FLORIAN -CONTUMAZA', NULL, N'959917435', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, 1, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (32, NULL, N'RICARDO ROJAS  - SAN PABLO', NULL, N'976432905', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (33, NULL, N'ELMER ALFONSO RODAS CUBAS - SAN MIGUEL', NULL, N'976150292', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (34, NULL, N'COSME ADOLFO ROJAS MARÍN - SAN MARCOS', NULL, N'962768221', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (35, NULL, N'GENARO ROMERO SUAREZ - SANTA CRUZ', NULL, N'976777236 ', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (36, NULL, N'MANUEL GUERRA ', NULL, N'945139293', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'AMARUMANUEL@HOTMAIL.COM', N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (37, NULL, N'CASIMIRO RAMIREZ ', NULL, N'975925380', CAST(N'2017-10-09T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (39, NULL, N'ULISES GAMONAL GUEVARA', N'PSJE. LOS BANCARIOS 50. URB. LAS ALMENDRAS', N'976719590', CAST(N'2017-10-10T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'ULISESGAMONALGUEVARA@GMAIL.COM', N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (42, NULL, N'GLENDY RAMOS TELLO', NULL, N'973790589', CAST(N'2017-10-16T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (43, NULL, N'JOHAN SÁNCHEZ', NULL, N'955865884', CAST(N'2017-10-16T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (44, NULL, N'KATIA CUETO', NULL, N'941809431', CAST(N'2017-10-16T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (45, NULL, N'JULIO CÉSAR BENAVIDES PARRA', NULL, N'993409996', CAST(N'2017-10-16T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'EDICIONESVICIPERPETUO@GMAIL.COM', N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (46, NULL, N'JULIO ZAMORA CASTRO', NULL, N'964595050', CAST(N'2017-10-16T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (47, NULL, N'WILSON IZQUIERDO GONZALES', N'FONAVI II EDIFICIO 13 APART.201', N'982359338', CAST(N'2017-10-16T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (48, NULL, N'NICOLÁS ALVARADO VECCO ', NULL, N'989462185', CAST(N'2017-10-16T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (49, NULL, N'EDWIN FERNÁNDEZ ', N'JR. DEL COMERCIO N 269', N'#976887676', CAST(N'2017-10-16T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (50, NULL, N'DEILU ELIZABETH OLIVEROS', NULL, N'953637848', CAST(N'2017-10-16T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
INSERT [dbo].[Persona] ([Id], [NombreArtistico], [NombreApellidos], [Direccion], [Telefono], [FechaRegistro], [FechaNacimiento], [Email], [Imagen], [RedesSociales], [IdOrganizacion], [IdOcupacionCultural], [IdProfesion]) VALUES (51, NULL, N'ALICIA JULCAMORO CUBAS', N'JR. ATAHUALPA S/N', N'938643101', CAST(N'2017-10-16T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'/PerfilImg/SinImagen.jpg', NULL, 1, 5, 27)
GO
SET IDENTITY_INSERT [dbo].[Persona] OFF
GO
SET IDENTITY_INSERT [dbo].[Activo] ON 
GO
INSERT [dbo].[Activo] ([Id], [Nombre], [Cantidad], [FechaRegistro]) VALUES (2, N'EQUIPO DE SONIDO', 1, CAST(N'2017-10-17T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Activo] ([Id], [Nombre], [Cantidad], [FechaRegistro]) VALUES (3, N'SILLAS', 35, CAST(N'2017-10-17T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Activo] ([Id], [Nombre], [Cantidad], [FechaRegistro]) VALUES (4, N'MESA DE HONOR', 1, CAST(N'2017-10-17T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Activo] ([Id], [Nombre], [Cantidad], [FechaRegistro]) VALUES (5, N'MESA DE BOCADITOS', 1, CAST(N'2017-10-17T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Activo] ([Id], [Nombre], [Cantidad], [FechaRegistro]) VALUES (6, N'PROYECTOR', 1, CAST(N'2017-10-17T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Activo] ([Id], [Nombre], [Cantidad], [FechaRegistro]) VALUES (7, N'EKRAN', 1, CAST(N'2017-10-17T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Activo] OFF
GO
SET IDENTITY_INSERT [dbo].[Ambiente] ON 
GO
INSERT [dbo].[Ambiente] ([Id], [Nombre], [Aforo], [Color], [FechaRegistro]) VALUES (1, N'SALA KAZUO TERADA', 35, N'Trebol', CAST(N'2017-10-30T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Ambiente] ([Id], [Nombre], [Aforo], [Color], [FechaRegistro]) VALUES (2, N'SALA CAPULI', 35, N'Naranja', CAST(N'2017-10-30T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Ambiente] ([Id], [Nombre], [Aforo], [Color], [FechaRegistro]) VALUES (3, N'SALA EX-HOSPITAL DE VARONES', 50, N'Rojo Oscuro', CAST(N'2017-10-30T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Ambiente] ([Id], [Nombre], [Aforo], [Color], [FechaRegistro]) VALUES (4, N'SALA EX-HOSPITAL DE MUJERES', 50, N'Rojo', CAST(N'2017-10-30T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Ambiente] ([Id], [Nombre], [Aforo], [Color], [FechaRegistro]) VALUES (5, N'CAMPO SANTO', 80, N'Celeste', CAST(N'2017-10-30T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Ambiente] ([Id], [Nombre], [Aforo], [Color], [FechaRegistro]) VALUES (6, N'BIBLIOTECA MANUEL IBAÑES ROZZASA', 30, N'Berenjena', CAST(N'2017-10-30T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Ambiente] ([Id], [Nombre], [Aforo], [Color], [FechaRegistro]) VALUES (7, N'PATIO PRINCIPAL', 50, N'Magenta', CAST(N'2017-10-30T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Ambiente] ([Id], [Nombre], [Aforo], [Color], [FechaRegistro]) VALUES (8, N'PATIO CAPULI', 30, N'Orquidea', CAST(N'2017-10-30T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Ambiente] ([Id], [Nombre], [Aforo], [Color], [FechaRegistro]) VALUES (9, N'PATIO PEQUEÑO', 15, N'Musgo', CAST(N'2017-10-30T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Ambiente] ([Id], [Nombre], [Aforo], [Color], [FechaRegistro]) VALUES (10, N'ARQUERIA', 20, N'Azul', CAST(N'2017-10-30T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Ambiente] ([Id], [Nombre], [Aforo], [Color], [FechaRegistro]) VALUES (11, N'HALL DE BIBLIOTECA', 30, N'Ciruela', CAST(N'2017-10-30T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Ambiente] OFF
GO
