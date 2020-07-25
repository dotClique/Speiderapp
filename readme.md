# What?
Speiderapp API back-end


# Tips & Tricks

## Creating a controller
Replace **Badge** in the following snipet with whatever model/object you're creating a controller for:
```bash
dotnet aspnet-codegenerator controller -name BadgeController -async -api -m Badge -dc BadgeContext -outDir Controllers
```

## Dependencies/Packages
Adding new packages:
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```
To remove simply use dotnet remove package \<package\>
