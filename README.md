# What?
Speiderapp Progressive Web-App front-end


# How to use

## Start server
```bash
dotnet run
```


# Guidelines & conventions

## Branches
As a general rule all branches should be connected to an issue in GitHub. This subsequently defines the branchname as **issue\<number\>/\<description\>**. There is no need for long descriptions, but a short 1-2 words description is preferred for easy browsing.

In cases where one does minor changes that don't affect behavior (like a spelling correction in readme.md) one doesn't necessarily need to create an issue, and subsequently the naming changes. In these cases the *hotfix*-keyword is to be used, like **hotfix/\<description\>**.

### Examples
* issue04/branch-naming
* hotfix/readme-spelling


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
To remove simply use
```bash
dotnet remove package \<package\>
```
