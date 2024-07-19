# ASP.NET Core 3.1 project from TH
## Technologies
- ASP.NET Core 3.1
- Entity Framework Core 3.1
## Install Tools
- .NET Core SDK 3.1
- Git client
- Visual Studio 2022
- SQL Server 2019
-  Design function - Idea By TEDU
## How to configure and run
- Clone code from Github: git clone https://github.com/HungPig/ShopHeo.Webapp
- Open solution eShopSolution.sln in Visual Studio 2022
- Set startup project is eShopSolution.Data
- Change connection string in Appsetting.json in HShopSolution.Data project
- Open Tools --> Nuget Package Manager -->  Package Manager Console in Visual Studio
- Run Update-database and Enter.
- After migrate database successful, set Startup Project is ShopHeo.Webapp
- Change database connection in appsettings.Development.json in ShopHeo.Webapp project.
- You need to change 3 projects to self-host profile.
- Set multiple run project: Right click to Solution and choose Properties and set Multiple Project, choose Start for 3 Projects: BackendApi, WebApp and AdminApp.
- Choose profile to run or press F5
## How to contribute
- Fork and create your branch
- Create Pull request to us.

## Admin template: https://startbootstrap.com/templates/sb-admin/
## Portal template: https://www.free-css.com/free-css-templates/page194/bootstrap-shop
## I18N (Internalization)
- References: https://medium.com/swlh/step-by-step-tutorial-to-build-multi-cultural-asp-net-core-web-app-3fac9a960c43
- Source code: https://github.com/LazZiya/ExpressLocalizationSampleCore3

## PROFILE
- https://www.facebook.com/hungmango2
- DUONG THANH HUNG
- I Created At First Year DUY TAN UNIVERSITY
