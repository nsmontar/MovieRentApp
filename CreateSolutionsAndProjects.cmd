rem create the solution
dotnet new sln -n MovieRentApp

rem create the class library for the Data Access layer and add it to the solution
dotnet new classlib -n MovieRentApp.Dal -o .\MovieRentApp.Dal -f netcoreapp3.1
dotnet sln MovieRentApp.sln add MovieRentApp.Dal

rem create the class library for the Models and add it to the solution
dotnet new classlib -n MovieRentApp.Models -o .\MovieRentApp.Models -f netcoreapp3.1
dotnet sln MovieRentApp.sln add MovieRentApp.Models

rem create the ASP.NET Core RESTful service project and add it to the solution
dotnet new webapi -n MovieRentApp.Service -au none --no-https -o .\MovieRentApp.Service -f netcoreapp3.1
dotnet sln MovieRentApp.sln add MovieRentApp.Service

rem create teh ASP.NET Core Web Application project and add it to the solution
dotnet new mvc -n MovieRentApp.Mvc -au none --no-https -o .\MovieRentApp.Mvc -f netcoreapp3.1
dotnet sln MovieRentApp.sln add MovieRentApp.Mvc

rem Add references between projects
dotnet add MovieRentApp.Mvc reference MovieRentApp.Models

dotnet add MovieRentApp.Dal reference MovieRentApp.Models

dotnet add MovieRentApp.Service reference MovieRentApp.Dal
dotnet add MovieRentApp.Service reference MovieRentApp.Models
