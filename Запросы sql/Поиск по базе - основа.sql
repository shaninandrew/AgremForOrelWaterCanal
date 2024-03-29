USE [Docs]
GO
/****** Object:  UserDefinedFunction [dbo].[SelectAgreementsByString]    Script Date: 29.01.2024 11:32:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Шанин Андрей
-- Create date: 22-01-2024
-- Description:	Поиск данных по таблице
-- =============================================
ALTER FUNCTION [dbo].[SelectAgreementsByString] 
(
	@search nvarchar(255)
)
RETURNS 
 TABLE 
AS
RETURN
(
Select	a.[Id], a.[Guid], cl.LinkGuid , cl.ClientTypeID From 
	Agreements a
	join [dbo].[Clients] cl on cl.AgreementGuid = a.Guid
	left join [dbo].[ClientPersonal] cl_pers on cl.LinkGuid = cl_pers.Guid and cl.ClientTypeID=1
	left join [dbo].[ClientEntity] cl_ent on cl.LinkGuid = cl_ent.Guid and cl.ClientTypeID=2

	where   concat (a.NumDoc,' ', a.Name,' ',  FORMAT( a.[Date], 'd', 'de-de' ) ,  
					ISNULL (cl_pers.Name,''),' ',ISNULL (cl_pers.Phone,''), ' ', ISNULL (cl_ent.Name,''), ' ', ISNULL (cl_ent.INN,''),
	' ', ISNULL (cl_ent.Phone,'')  )  LIKE '%'+@search+'%' 
)
