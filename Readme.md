

## Creating a ASP.NET Core WebApi

[Microsoft docs for web api tutorial](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio)

Create a new project
```sh
dotnet new webapi -o AircraftApi
cd TodoApi
dotnet add package Microsoft.EntityFrameworkCore.InMemory
```


Start the project from https:
```sh
dotnet dev-certs https --trust
dotnet run --launch-profile https
```

`dotnet aspnet-codegenerator controller -name TodoItemsController -async -api -m TodoItem -dc TodoContext -outDir Controllers`

## Authentication Types

### None

I think this is the right selection to manually set up Entity authentication for just user name and password type auth.

### Microsoft identity platform 

Use the [Microsoft identity platform](https://learn.microsoft.com/en-us/entra/identity-platform/) and our open-source authentication libraries to sign in users with Microsoft Entra accounts, Microsoft personal accounts, and social accounts like Facebook and Google. Protect your web APIs and access protected APIs like Microsoft Graph to work with your users' and organization's data. 

### Windows

[Windows Authentication](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/windowsauth?view=aspnetcore-7.0&tabs=visual-studio) (also known as Negotiate, Kerberos, or NTLM authentication) can be configured for ASP.NET Core apps hosted with IIS, Kestrel, or HTTP.sys.

Windows Authentication relies on the operating system to authenticate users of ASP.NET Core apps. Windows Authentication is used for servers that run on a corporate network using Active Directory domain identities or Windows accounts to identify users. Windows Authentication is best suited to intranet environments where users, client apps, and web servers belong to the same Windows domain.