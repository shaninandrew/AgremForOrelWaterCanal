Select  NumDoc,Date,Name,ID,Guid,TotalSum from [Agreements]  
WHERE [id] in ( Select ID FROM SelectAgreementsByString ('об') )