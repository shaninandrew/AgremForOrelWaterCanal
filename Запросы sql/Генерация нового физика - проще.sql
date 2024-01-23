



Declare @NewDoc uniqueidentifier = NEWID();
Declare @NewClient uniqueidentifier = NEWID();

INSERT INTO [Agreements] ([Date],NumDoc, [Guid],[Name]) 
		Values ('22.01.2024' , '111/11' ,@NewDoc,DEFAULT)

INSERT INTO [ClientPersonal] ([Name], [Guid]) 
		Values ('новый клиент' ,@NewClient);

INSERT INTO Clients 
	([ClientTypeID] , [AgreementGuid], [LinkGuid] )
	Values (1, @NewDoc ,@NewClient)
	