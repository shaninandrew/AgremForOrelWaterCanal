USE [Docs]
GO
/****** Object:  StoredProcedure [dbo].[InsertNewServiceForAgreement]    Script Date: 07.02.2024 9:12:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Шанин Андрей
-- Create date: <Create Date,,>
-- Description:	Добавляет для контракта усулги из прайса
-- =============================================
ALTER PROCEDURE [dbo].[InsertNewServiceForAgreement] 
	-- Add the parameters for the stored procedure here
	@GuidAgr nvarchar (100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- вставка услуги только для клиентов с нулями (услуги для всех) или конкретно под юрика, если услуга для юрика--- 
	 INSERT INTO [dbo].[ServiceByAgreements] ([Link_Agreement], [Link_PriceList], price.[Count])
		SELECT @GuidAgr, price.[Guid], 0  From  [dbo].[PriceList] price
		inner join  [Agreements] agr on agr.Guid = @GuidAgr
		inner join  [dbo].[Clients] client on agr.Guid = client.[AgreementGuid]
		where 
			agr.Date between price.Date_start and price.Date_end
			-- договор по дате входит в условия прайса (цена действует с start -> end )
			and (price.ClientTypeID=0 or price.ClientTypeID = client.ClientTypeID)
			-- по типу лиц или для всех
		
END
