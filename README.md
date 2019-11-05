# OrderApp

.NET Core 2.2 Project, using SQL Server database

## To run the application:
Console (on OrderApp.API project):
```
dotnet run
```

Open https://localhost:5001/swagger/index.html


## Entity Framework Commands

### Update database command
Powershel:
```
Update-Database -Context OrderAppDbContext
```

Console (on OrderApp.Infrastructure project):
```
dotnet ef database update --startup-project ..\OrderApp.API\ --context OrderAppDbContext
```