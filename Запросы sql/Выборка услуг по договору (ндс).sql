USE [Docs]
GO
/****** Object:  UserDefinedFunction [dbo].[SelectServicesByAgreementID]    Script Date: 08.02.2024 10:48:54 ******/
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
	SELECT  serv.Id, price.Title,price.Price, serv.[Count] , 
	
	-- если НДС не включен 
	-- Round(price.Price*serv.[Count]*(1+price.Vat),2) as [SumAmount], 
	-- если ндс включен в цену
	Round(price.Price*serv.[Count],2) as [SumAmount], 
	-- если НДС включен в цену - считаем отдельно 
	Round(price.Price*serv.[Count]*(1/(1+price.Vat)),2) as [VatSum] 
	--если прайс без НДС
	--Round(price.Price*serv.[Count]*(price.Vat)),2) as [VatSum] 
	FROM [dbo].[ServiceByAgreements] serv 
	inner join [dbo].[PriceList] price on price.[Guid] = serv.[Link_PriceList]
	Where 
	serv.Link_Agreement = @GuidAgr 
)
