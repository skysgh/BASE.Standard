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