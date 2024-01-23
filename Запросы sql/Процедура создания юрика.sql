USE [Docs]
GO
/****** Object:  StoredProcedure [dbo].[InsertNewAgreementWithPrivate]    Script Date: 22.01.2024 16:40:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Шанин АНдрей
-- Create date: 22.01.2024
-- Description:	Создает клиента юрика (нового) и договор с ним
-- =============================================
CREATE PROCEDURE [dbo].[InsertNewAgreementWithEntity] 
(
	-- Дата создания, номер документа, GUID договора и GUID клиента
	@Date DateTime , @Numdoc nvarchar (100) ='222/2024',	@NewDoc uniqueidentifier ,	@NewClient uniqueidentifier 

)
AS
BEGIN
-- выполняем ввствки строк  в таблицы
EXEC ('INSERT INTO [Agreements] ([Date],NumDoc, [Guid],[Name]) 
		Values (''' +@Date+''', '''+@Numdoc+''' , '''+@NewDoc+''',DEFAULT);

   INSERT INTO [ClientEntity] ([Name], [Guid]) 
		Values (''ООО новый клиент'' ,'''+@NewClient+''');

	INSERT INTO Clients ([ClientTypeID] , [AgreementGuid], [LinkGuid] )
	Values (2, '''+@NewDoc+''' ,'''+@NewClient+'''); ');
	
--возврат нового клиента
Declare @ID bigint;
SELECT  @ID=Id  From [Clients] where [AgreementGuid]= @NewDoc  and [LinkGuid] =@NewClient;

-- возврат ID
RETURN @ID
END
