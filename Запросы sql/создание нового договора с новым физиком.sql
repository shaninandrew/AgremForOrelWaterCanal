-- ================================================
-- Создание нового договора
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Шанин Андрей
-- Create date: 22-01-2024
-- Description:	Создает новый договор + привязанный к нему клиент физик
-- на указанную дату (либо сегодня) с указанным номером
-- добавляет в клиентскую таблицу записи
--- создает новый договор и привязку к клиенту физику
-- =============================================
CREATE FUNCTION InsertNewAgreementWithPrivate 
(	
	@Date DateTime , @Numdoc nvarchar (100) ='111/111'
)
RETURNS TABLE 
AS
RETURN 
(
Declare @NewDoc uniqueidentifier = NEWID();
Declare @NewClient uniqueidentifier = NEWID();

INSERT INTO [Agreements] ([Date],NumDoc, [Guid],[Name]) 
		Values ('22.01.2024' , @Numdoc ,@NewDoc,DEFAULT)

INSERT INTO [ClientPersonal] ([Name], [Guid]) 
		Values ('новый клиент' ,@NewClient);

INSERT INTO Clients 
	([ClientTypeID] , [AgreementGuid], [LinkGuid] )
	Values (1, @NewDoc ,@NewClient);
	
SELECT *  From Clients ;
)

GO
