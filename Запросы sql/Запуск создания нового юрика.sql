USE [Docs]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[InsertNewAgreementWithEntity]
		@Date = N'21.01.2023',
		@Numdoc = N'232-2023',
		@NewDoc = 'a8df3873-15d0-46fb-b601-c09b6bb6a862',
		@NewClient = '9ddfa830-5c4c-4821-93ed-bbcbc7ad7a3d'

SELECT	'Return Value' = @return_value

GO
