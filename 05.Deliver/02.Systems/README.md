## Summary ##




## Dependencies ##

Below is a record of some (it's wildly imcomplete, but still...) of some of the Nuget packages used and why if known.

* App.Host:
  * Microsoft.Azure.Services.AppAuthentication 
    * provides MSI, as needed by Microsoft.Extensions.Configuration.AzureKeyVault 
  * Microsoft.Extensions.Configuration.AzureKeyVault
    * provides a way to read config settings from a keyvault.
* App.Modules.Core.Infrastructuture:
  * Microsoft.Extensions.Configuration.Json
    * backs Service to create Configuration objects.
	* DbContext needs to readd AppSettings for ConnectionStrings.
  * Microsoft.Extensions.Configuration.Binder
    * Backs service to create configuration objects.


## Enable Powershell ##
You may need to setup Powershell first:

    Set-ExecutionPolicy -ExecutionPolicy Bypass


## DotNet EF Commands ##
The following is what is used to add Core MIgrations from the Solution Root folder:

	$moduleName = "core"
    dotnet ef migrations --project "modules\$($moduleName)\app.modules.$($moduleName).infrastructure" --startup-project "host\app.host" list
    dotnet ef migrations --project "modules\$($moduleName)\app.modules.$($moduleName).infrastructure" --startup-project "host\app.host" add "XXX" --output-dir "Data\Db\Migrations\Steps" 
    dotnet ef migrations --project "modules\$($moduleName)\app.modules.$($moduleName).infrastructure" --startup-project "host\app.host" remove

	$moduleName = "design"
    dotnet ef migrations --project "modules\$($moduleName)\app.modules.$($moduleName).infrastructure" --startup-project "host\app.host" list
    dotnet ef migrations --project "modules\$($moduleName)\app.modules.$($moduleName).infrastructure" --startup-project "host\app.host" add "XXX" --output-dir "Data\Db\Migrations\Steps" 
    dotnet ef migrations --project "modules\$($moduleName)\app.modules.$($moduleName).infrastructure" --startup-project "host\app.host" remove


Apply Migrations either from the command line, or by running the app:

dotnet ef database update --project "modules\core\app.modules.core.infrastructure" --startup-project "host\app.host"


### OData

OData in ASP.Core is relatively easy:

* It's no longer done using a base class. 
* Just use any Controller. And decorate the Gets with [EnableQuery]
* https://dotnetthoughts.net/getting-started-with-odata-in-aspnet-core/
* https://devblogs.microsoft.com/odata/asp-net-core-odata-now-available/

