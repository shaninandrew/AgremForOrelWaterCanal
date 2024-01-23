USE [Docs]
GO
/****** Object:  StoredProcedure [dbo].[InsertNewAgreementWithPrivate]    Script Date: 22.01.2024 16:40:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		����� ������
-- Create date: 22.01.2024
-- Description:	������� ������� ����� (������) � ������� � ���
-- =============================================
CREATE PROCEDURE [dbo].[InsertNewAgreementWithEntity] 
(
	-- ���� ��������, ����� ���������, GUID �������� � GUID �������
	@Date DateTime , @Numdoc nvarchar (100) ='222/2024',	@NewDoc uniqueidentifier ,	@NewClient uniqueidentifier 

)
AS
BEGIN
-- ��������� ������� �����  � �������
EXEC ('INSERT INTO [Agreements] ([Date],NumDoc, [Guid],[Name]) 
		Values (''' +@Date+''', '''+@Numdoc+''' , '''+@NewDoc+''',DEFAULT);

   INSERT INTO [ClientEntity] ([Name], [Guid]) 
		Values (''��� ����� ������'' ,'''+@NewClient+''');

	INSERT INTO Clients ([ClientTypeID] , [AgreementGuid], [LinkGuid] )
	Values (2, '''+@NewDoc+''' ,'''+@NewClient+'''); ');
	
--������� ������ �������
Declare @ID bigint;
SELECT  @ID=Id  From [Clients] where [AgreementGuid]= @NewDoc  and [LinkGuid] =@NewClient;

-- ������� ID
RETURN @ID
END
