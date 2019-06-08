## About ##

Application Services (App.Modules.XXX.AppFacade.Services.xxx) rely on 
Infrastructure Services, which in turn wrap services provided by the 
Host operating system, the .NET Framework -- as well as remote Services
such as Azure Services, SMTP Services, etc.

The Services in urn use Service Clients/Agents of the remote
Services.

Service Clients are more often then not scoped to Request scope
so that more than one operation can be performed at a time.


