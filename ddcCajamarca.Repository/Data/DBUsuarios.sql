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
SET IDENTITY_INSERT [dbo].[PerfilUsuario] ON 
GO
INSERT [dbo].[PerfilUsuario] ([Id], [Usuario], [Imagen], [Email], [NombreApellidos], [NombreMostrar]) VALUES (1, N'admin', N'/PerfilImg/SinImagen.jpg', NULL, NULL, N'SuperAdmin')
GO
SET IDENTITY_INSERT [dbo].[PerfilUsuario] OFF
GO
SET IDENTITY_INSERT [dbo].[webpages_Roles] ON 
GO
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (3, N'AgendaCultural')
GO
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (2, N'Directorio')
GO
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (4, N'Reportes')
GO
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (1, N'SuperAdmin')
GO
SET IDENTITY_INSERT [dbo].[webpages_Roles] OFF
GO
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1, 1)
GO
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (1, CAST(N'2018-01-25T20:02:24.550' AS DateTime), NULL, 1, NULL, 0, N'AEAt7qf1VIp4QMmpPcGF2hZJY4cKsokKzSI1mkR/pAxtGj9wHAKZU8JhfMOZyTZAVA==', CAST(N'2018-01-25T20:02:24.550' AS DateTime), N'', NULL, NULL)
GO
