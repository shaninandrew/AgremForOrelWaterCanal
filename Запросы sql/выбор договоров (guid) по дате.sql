USE [Docs]
GO
/****** Object:  UserDefinedFunction [dbo].[SelectServicesByAgreementID]    Script Date: 06.02.2024 16:46:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Шанин Андрей
-- Create date: 06-02-24
-- Description:	Влозвращает список услуг по договору ID
-- =============================================
ALTER FUNCTION [dbo].[SelectServicesByAgreementID]
(	
	--Guid контракта --
	@GuidAgr nvarchar(100)
	
)
RETURNS TABLE 

AS
RETURN 
(
	
	SELECT price.*, serv.[Count]   FROM [dbo].[ServiceByAgreements] serv 
	inner join [dbo].[PriceList] price on price.[Guid] = serv.[Link_PriceList]
	Where 
	serv.Link_Agreement = @GuidAgr 
)
