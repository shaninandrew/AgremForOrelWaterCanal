-- ================================================
-- Template generated from Template Explorer using:
-- Create Multi-Statement Function (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE InsertNewAgreementWithPrivate 
(
	-- ���� ��������, ����� ���������, GUID �������� � GUID �������
	@Date DateTime , @Numdoc nvarchar (100) ='111/111',	@NewDoc uniqueidentifier ,	@NewClient uniqueidentifier 

)
AS
BEGIN
-- ��������� ������� �����  � �������
EXEC ('INSERT INTO [Agreements] ([Date],NumDoc, [Guid],[Name]) 
		Values (''' +@Date+''', '''+@Numdoc+''' , '''+@NewDoc+''',DEFAULT);

   INSERT INTO [ClientPersonal] ([Name], [Guid]) 
		Values (''����� ������'' ,'''+@NewClient+''');

	INSERT INTO Clients ([ClientTypeID] , [AgreementGuid], [LinkGuid] )
	Values (1, '''+@NewDoc+''' ,'''+@NewClient+'''); ');
	
--������� ������ �������
Declare @ID bigint;
SELECT  @ID=Id  From [Clients] where [AgreementGuid]= @NewDoc  and [LinkGuid] =@NewClient;

-- ������� ID
RETURN @ID
END
GO