# What?
Speiderapp API back-end


# How to: *develop*

## Prerequisites:
* [.NET 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)
* [Docker](https://docker.com)
* [Powershell](https://docs.microsoft.com/en-us/powershell/scripting/install/installing-powershell)


## Clone and restore project

```bash
# Clone the repo (example uses ssh)
git clone git@github.com:dotClique/SpeiderappAPI.git

# If you are using Powershell on Windows, Mac or Linux, you can use the App.ps1-script:
./App.ps1 Restore

# If you don't use Powershell, you are left to interpretting the script for yourself...
```


## Prepare and start development server (in Docker)

The service is run in Docker, but setup is run outside.

Before initial setup, create the necessary secrets-files:
```bash
# Create secrets directory
mkdir -p .docker/secrets

# Create and edit the necessary password files
nano .docker/secrets/POSTGRES__ROOT_PASS
nano .docker/secrets/SPEIDERAPP__DB_PASS
```

Then perform the necessary database setup
```bash
# Start database-container
./App.ps1 StartDB

# Run migrations to populate the database
./App.ps1 Migrate
```

Then start the API
```bash
# Start the API-container
./App.ps1 StartAPI
```


## Formatting
See [Code formatting](#code-formatting) for details.
```bash
./App.ps1 Format
```

## Routes
| Controller            | HTTP Method | Route                   | Description                      |
| :-------------------- | :---------- | :---------------------- | :------------------------------- |
| BadgeController       | GET         | /api/Badge              | List Badges                      |
| BadgeController       | GET         | /api/Badge/\<id\>       | Retrieve a specific badge        |
| RequirementController | GET         | /api/Requirement        | List all non-badge Requirements  |
| RequirementController | GET         | /api/Requirement/all    | List all Requirements (any type) |
| RequirementController | GET         | /api/Requirement/\<id\> | Retrieve a specific Requirement  |
| ResourceController    | GET         | /api/Resource           | List Resources                   |
| ResourceController    | GET         | /api/Resource/\<id\>    | Retrieve a specific Resource     |
| UserController        | GET         | /api/User               | List Users                       |
| UserController        | GET         | /api/User/\<id\>        | Retrieve a specific User         |


## Local configuration

### Development
To override configuration settings which do not need to be secure locally,
create ```appsettings.Development.local.json```.

To override/set development secrets, use:
```bash
dotnet user-secrets set <key> <value>
```

### Production
Create ```appsettings.Production.local.json```, and
*more instructions to come*.

# Guidelines & conventions

## Branches
As a general rule all branches should be connected to an issue in GitHub. This subsequently defines the branchname as **i\<number\>/\<description\>**. There is no need for long descriptions, but a short 1-2 words description is preferred for easy browsing.

In cases where one does minor changes that don't affect behavior (like a spelling correction in readme.md) one doesn't necessarily need to create an issue, and subsequently the naming changes. In these cases the *hotfix*-keyword is to be used, like **hotfix/\<description\>**.

### Examples
* i04/branch-naming
* hotfix/readme-spelling


# Tips & Tricks

## Creating a controller
Replace **<Badge>** in the following snippet with whatever model/object you're creating a controller for:
```bash
# Enter the project directory
cd SpeiderappAPI

# Create the controller
dotnet aspnet-codegenerator controller -name <Badge>Controller -async -api -m <Badge> -dc ApiContext -outDir Controllers
```

## Creating migrations

Migrations set up and prepare the database for the data models used in Dotnet.
Make sure to run the [database setup](#prepare-and-start-development-server-in-docker) before running migrations.

```bash
# Make sure tools are installed
dotnet tool restore

# Create migrations and apply
dotnet ef migrations add <ShortMigrationDescription> --project SpeiderappAPI

# Update the database
dotnet ef database update --project SpeiderappAPI
```

## Dependencies/Packages
Adding new packages:
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```
To remove simply use
```bash
dotnet remove package <package>
```
