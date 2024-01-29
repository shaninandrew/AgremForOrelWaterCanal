-- ================================================
-- Функция возращающая довоговор с привязками сразу ID клиента, его имя т п.п
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Шанин Андрей
-- Create date: 29-01-2024
-- Description:	Договора со служебными полями
-- =============================================
CREATE FUNCTION SelectAgreementsMainPoint
(	
	-- Add the parameters for the function here
	
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	SELECT a.*, cl.LinkGuid, cl.ClientTypeID, isNUll(entity.Name,isNUll(personal.Name,'')) as _CleintName From Agreements a
	 join Clients cl on cl.AgreementGuid = a.Guid
	 join ClientEntity entity on entity.Guid = cl.LinkGuid and cl.ClientTypeID=2
	 join ClientEntity personal on entity.Guid = cl.LinkGuid and cl.ClientTypeID=1
	
)
GO
