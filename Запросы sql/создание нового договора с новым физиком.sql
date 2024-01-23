-- ================================================
-- �������� ������ ��������
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		����� ������
-- Create date: 22-01-2024
-- Description:	������� ����� ������� + ����������� � ���� ������ �����
-- �� ��������� ���� (���� �������) � ��������� �������
-- ��������� � ���������� ������� ������
--- ������� ����� ������� � �������� � ������� ������
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
		Values ('����� ������' ,@NewClient);

INSERT INTO Clients 
	([ClientTypeID] , [AgreementGuid], [LinkGuid] )
	Values (1, @NewDoc ,@NewClient);
	
SELECT *  From Clients ;
)

GO
