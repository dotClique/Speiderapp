# What?
Speiderapp API back-end


# How to use

## Setup
Prerequisites:
* [.NET 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)
* [Node.js](https://nodejs.org/en/)
* [Docker](https://docker.com)

```bash
# Clone the repo (example uses ssh)
git clone git@github.com:dotClique/SpeiderappAPI.git
cd ./SpeiderappAPI

# Run install script
yarn install
```

## Start development server in Docker

The service is run in Docker.

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
docker-compose up -d database

# Run migrations to populate the database
dotnet tool restore
dotnet ef database update --project SpeiderappAPI
```

Then start the backend
```bash
# Start the backend-container
docker-compose up -d backend
```


## Formatting
See [Code formatting](#code-formatting) for details.
```bash
dotnet format -s info
```

## Routes
| HTTP Method | Route             | Description        |
| :---------- | :---------------- | :----------------- |
| GET         | /api/Badge        | List Badges        |
| GET         | /api/Badge/\<id\> | Retrieve a badge   |
| POST        | /api/Badge        | Create a new Badge |
| PUT         | /api/Badge/\<id\> | Update a Badge     |
| DELETE      | /api/Badge/\<id\> | Delete a Badge     |


## Local configuration

### Development
To override configuration settings which do not need to be secure locally,
create ```appsettings.Development.local.json```.

To override/set development secrets, use:
```bash
dotnet user-secrets set <key> <value>
```


#### Migrations

Migrations set up and prepare the database for the data models used in Dotnet.
Make sure to run the [database setup](#database) before running migrations.

```bash
# Make sure tools are installed
dotnet tool restore

# Create migrations and apply
dotnet ef migrations add <ShortMigrationDescription> --project SpeiderappAPI

# Update the database
dotnet ef database update --project SpeiderappAPI
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

## Code formatting
We're using [dotnet-format](https://www.nuget.org/packages/dotnet-format/) for automatic formatting.
Formatting rules are defined in `.editorconfig`.
```bash
# Make sure tools are installed
dotnet tool restore

# Run dotnet-format and fix all issues
# `--fix-style` may be replaced with `-s` for short
dotnet format --fix-style info

# Run dotnet-format check for pre-commit hooks etcetera
dotnet format --fix-style info --check
```

## Creating a controller
Replace **Badge** in the following snippet with whatever model/object you're creating a controller for:
```bash
# Enter the project directory
cd SpeiderappAPI

# Create the controller
dotnet aspnet-codegenerator controller -name <Badge>Controller -async -api -m <Badge> -dc ApiContext -outDir Controllers
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
