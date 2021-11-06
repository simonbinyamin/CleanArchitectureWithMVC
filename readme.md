## Clean Architecture With MVC

This Architecture is based on Jason solution, the difference is that this solution uses MVC in the presentation layer instead of Angular

the application is divided into:
* DomainLayer - the core of the application
* DataAccess - the database layer
* Business - the application business layer
* Presentation - the MVC application

The application uses MediatR and CQRS to manage data. since the angular application is removed, asp .net core identity is used in the MVC application and for that the Area folder was shuffled. The Startup needs also to be modified, the ConfigureServices includes:

```
services.ConfigureApplicationCookie(options =>
{
options.Cookie.Name = "CookieName";
options.ExpireTimeSpan = TimeSpan.FromMinutes(11);
options.SlidingExpiration = true;
});

services.AddMemoryCache();

services.AddApplication();
services.AddDataAccess(Configuration);
services.AddDatabaseDeveloperPageExceptionFilter();
services.AddSingleton<ICurrentUserService, Services.CurrentUserService>();


services.AddControllersWithViews();
```

And the Configure method includes

```
app.UseHttpsRedirection();

app.UseRouting();

app.UseStaticFiles();
app.UseCookiePolicy();


app.UseSession();
app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
endpoints.MapControllerRoute(
name: "default",
pattern: "{controller}/{action}/{id?}");
endpoints.MapRazorPages();
});
```
ApplicationUser is used in cshtml

```
@using Microsoft.AspNetCore.Identity
@using mediatR.Infrastructure.Identity;
@inject SignInManager<ApplicationUser> SignInManager
@inject UserManager<ApplicationUser> UserManager 
```

The ApiBaseController inherits from Controller

```
ApiBaseController: Controller 
```

And your own controller inherits from the ApiBaseController

```
 public class CompanyController : ApiControllerBase 
```

## Install the project for Windows

### Clone the the project 

```
git clone https://github.com/simonbinyamin/CleanArchitectureWithMVC.git
```

#### Compiles and reloads for development

```
open mediatR.sln and select MVC as startup project in Visual studio
```

#### other things you might need

```
sql server management studio
```

## Install the project for Linux
### Clone the the project 

```
git clone https://github.com/simonbinyamin/CleanArchitectureWithMVC.git
```

### Install .NET5 
### Install SQL Server Express

```
wget -qO- https://packages.microsoft.com/keys/microsoft.asc | sudo apt-key add -
sudo add-apt-repository "$(wget -qO- https://packages.microsoft.com/config/ubuntu/20.04/mssql-server-2019.list)"

sudo apt-get update
sudo apt-get install -y mssql-server

sudo /opt/mssql/bin/mssql-conf setup

systemctl status mssql-server --no-pager
```
