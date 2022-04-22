# smsportal-dotnet
Connect, transact and engage with your customers

## Installation

Using the [.NET Core command-line interface (CLI) tools][dotnet-core-cli-tools]:

```sh
dotnet add package SmsPortal.net
```

Using the [NuGet Command Line Interface (CLI)][nuget-cli]:

```sh
nuget install SmsPortal.net
```

Using the [Package Manager Console][package-manager-console]:

```powershell
Install-Package SmsPortal.net
```

From within Visual Studio:

1. Open the Solution Explorer.
2. Right-click on a project within your solution.
3. Click on *Manage NuGet Packages...*
4. Click on the *Browse* tab and search for "SmsPortal.net".
5. Click on the SmsPortal.net package, select the appropriate version in the
   right-tab and click *Install*.

[dotnet-core-cli-tools]: https://docs.microsoft.com/en-us/dotnet/core/tools/
[nuget-cli]: https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference
[package-manager-console]: https://docs.microsoft.com/en-us/nuget/tools/package-manager-console

## Example

```csharp
using SmsPortal.net;

var clientId = "<insert-your-client-id-here>";
var clientSecret = "<insert-your-client-secret-here>";

var smsPortalClient = new SmsPortalClient(clientId, clientSecret);

var mobileNumber = "0766542813";

await smsPortalClient.Send(mobileNumber, "Hello World");
```

## License

See the LICENSE file.