Select link.[LinkGuid], ce.Name as NameEntity, link.ClientTypeID From 
	Agreements  a
	inner join Clients link on AgreementGuid = a.[Guid]
	inner join ClientEntity ce on  ce.[Guid]= link.[LinkGuid]
	where a.[Guid] =  'B655F69E-606A-42CB-ABBB-9E18891178F2'

union
Select 	link.[LinkGuid], cp.Name as Name_Personal,  link.ClientTypeID From 
	Agreements  a
	inner join Clients link on AgreementGuid = a.[Guid]
	inner join ClientPersonal cp on  cp.[Guid]= link.[LinkGuid]
	where a.[Guid] =  'B655F69E-606A-42CB-ABBB-9E18891178F2'
