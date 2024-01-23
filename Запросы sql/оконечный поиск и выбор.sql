USE [Docs]
GO

Select * from Agreements where ID in
(
	SELECT ID FROM [dbo].[SelectAgreementsByString] (
	   'договор')
)
GO


