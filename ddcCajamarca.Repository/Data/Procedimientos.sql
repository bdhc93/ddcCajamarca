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
/****** Object:  StoredProcedure [dbo].[AgregarDetalleRequerimientos]    Script Date: 12/03/2018 11:13:34 ******/
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
/****** Object:  StoredProcedure [dbo].[EliminarDetalleRequerimientos]    Script Date: 12/03/2018 11:13:34 ******/
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
/****** Object:  StoredProcedure [dbo].[ModificarEventoEnsayo]    Script Date: 12/03/2018 11:13:34 ******/
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
