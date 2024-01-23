-- ================================================
-- ����� �� �������
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		����� ������
-- Create date: 22-01-2024
-- Description:	����� ������ �� �������
-- =============================================
CREATE FUNCTION SelectAgreementsByString 
(
	@search nvarchar(255)
)
RETURNS 
 TABLE 
AS
RETURN
(
Select	[Id], [Guid] From 
	Agreements 
	where   concat (NumDoc,' ', Name) LIKE '%'+@search+'%' 
)
GO