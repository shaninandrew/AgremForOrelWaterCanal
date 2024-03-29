USE [Docs]
GO
/****** Object:  UserDefinedFunction [dbo].[SelectServicesByAgreementID]    Script Date: 07.02.2024 15:34:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Шанин Андрей
-- Create date: 06-02-24
-- Description:	Возвращает список услуг по договору ID
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
	
	SELECT  serv.Id, price.Title,price.Price, serv.[Count] , Round(price.Price*serv.[Count],2) as amount, Round(price.Price*serv.[Count]*price.Vat,2) as Vats  FROM [dbo].[ServiceByAgreements] serv 
	inner join [dbo].[PriceList] price on price.[Guid] = serv.[Link_PriceList]
	Where 
	serv.Link_Agreement = @GuidAgr 
)
