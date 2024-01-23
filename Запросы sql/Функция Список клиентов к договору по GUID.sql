USE [Docs]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Шанин Андрей
-- Create date: 23-01-2024
-- Description:	Выбор клиентов для договора как физики, так и юрики
-- =============================================
CREATE FUNCTION [dbo].[SelectClientsForAgreementsByID] 
(
	@GUID_Agr nvarchar(255) --
)
RETURNS 
 TABLE 
AS
RETURN
(
Select link.[LinkGuid], ce.Name as NameEntity, link.ClientTypeID From 
	Agreements  a
	inner join Clients link on AgreementGuid = a.[Guid]
	inner join ClientEntity ce on  ce.[Guid]= link.[LinkGuid]
	where a.[Guid] =  @GUID_Agr

union
Select 	link.[LinkGuid], cp.Name as Name_Personal,  link.ClientTypeID From 
	Agreements  a
	inner join Clients link on AgreementGuid = a.[Guid]
	inner join ClientPersonal cp on  cp.[Guid]= link.[LinkGuid]
	where a.[Guid] =  @GUID_Agr

)
