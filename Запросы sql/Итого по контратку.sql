USE [Docs]
GO
/****** Object:  UserDefinedFunction [dbo].[GetTotalServiceByAgreementID]    Script Date: 08.02.2024 10:55:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Шанин Андрей
-- Create date: 07-02
-- Description:	Сумма по договору + НДС
-- =============================================
ALTER FUNCTION [dbo].[GetTotalServiceByAgreementID]
(	
	@Guid NVARCHAR(100)
)
RETURNS TABLE 
AS
RETURN 
(
 -- возврат суммы по контракту и и его ндс
	SELECT  ROunD( SUM(SumAmount),2) as [TotalSum] , Round(SUM(VatSum),2) as TotalVat FROM [dbo].[SelectServicesByAgreementID] 
(   @Guid   )
	
)
