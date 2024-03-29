USE [Docs]
GO
/****** Object:  UserDefinedFunction [dbo].[SelectAgreementsMainPoint]    Script Date: 29.01.2024 10:07:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Шанин Андрей
-- Create date: 29-01-2024
-- Description:	Договора со служебными полями
-- =============================================
ALTER FUNCTION [dbo].[SelectAgreementsMainPoint] (@MaxCount int =1000 )
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	SELECT top (@MaxCount) a.*, cl.LinkGuid, cl.ClientTypeID, isNUll(entity.Name,isNUll(personal.Name,'')) as _ClientName From Agreements a
	 join Clients cl on cl.AgreementGuid = a.Guid
	 left join ClientEntity entity on entity.Guid = cl.LinkGuid and cl.ClientTypeID=2
	 left join ClientEntity personal on entity.Guid = cl.LinkGuid and cl.ClientTypeID=1
	order by a.[Date] desc
)
