GO
CREATE TABLE [dbo].[_prueba](
	[patente] [varchar](8) NULL,
	[marca] [varchar](20) NULL,
	[modelo] [varchar](20) NULL,
	[cant_puertas] [int] NULL,
	[nombre_titular] [varchar](50) NULL
) ON [PRIMARY]
GO

GO
INSERT INTO _prueba VALUES('154FGE85', 'Fiat', 'Italiano', 4, 'Jose Hernandez')
INSERT INTO _prueba VALUES('854KJL68', 'Audi', 'Ruso', 6, 'Adrian Felix')

GO


GO
CREATE PROCEDURE [dbo].[_AGREGAR_VEHICULO]
(
	@PATENTE VARCHAR(8),
	@MARCA VARCHAR(20),
	@MODELO VARCHAR(20),
	@CANT_PUERTAS INT,
	@TITULAR VARCHAR(50)
)
AS

INSERT INTO _PRUEBA VALUES(@PATENTE, @MARCA, @MODELO, @CANT_PUERTAS, @TITULAR)

SELECT 'OK' AS resultado
GO



GO
CREATE PROCEDURE [dbo].[_CONSULTA_VEHICULOS]
(
	@ID_VEHICULO AS INT
)
AS

SELECT * FROM _prueba
GO