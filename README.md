# What?
Speiderapp API back-end


# How to use

## Start server
To start the server simply run the following command.
**NB:** You will need to manually restart the server after file-changes. See below for how to automate server restarts.
```bash
dotnet run
```

## Start server with watch
Tired of manually restarting the server? Run the following command to have dotnet automatically restart the server upon file-changes.
```bash
dotnet watch run
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
create
```appsettings.Development.local.json```.
To override/set development secrets,
use:
```bash
dotnet user-secrets set <key> <value>
```


#### Database

By default, the project will run using an InMemory database.
However, for production and debugging, a postgres database is recommended.

You can set up and run a local Postgres database using docker.
First create two password files: `Database/secrets/rootPassword` and `Database/secrets/speiderappPassword`.
These should contain only the set up passwords to be used for the database, and should not be checked in to the Git repo.

To configure the servers database connection, define a connection string in `appsettings.Development.local.json`.
To do this, copy and rename the example file `appsettings.Development.local.json.example`, and update the connection string inside.
Use the `speiderapp` user from the database setup, not the `postgres`/`root` user.

```bash
##
# Set up, build and run docker image
##
# Set up root and user passwords
"RootPasswordHere" > Database/secrets/rootPassword
"UserPasswordHere" > Database/secrets/speiderappPassword

# Build and run docker image (first time setup)
docker build --tag speiderapp/postgres ./Database/
docker run --name speiderapp-postgres -p 5432:5432 speiderapp/postgres

# To later remove the image (if necessary)
docker image rm speiderapp/postgres


###
# Start, stop and remove container
###
# Start docker container
docker start speiderapp-postgres

# Stop docker container
docker stop speiderapp-postgres

# Remove docker container
docker rm speiderapp-postgres

# Connect to container terminal
docker exec -it speiderapp-postgres bash


##
# Set up connection string
##
# Copy and rename `appsettings.Development.local.json.example`
cp appsettings.Development.local.json.example appsettings.Development.local.json

# Edit `appsettings.Development.local.json` (use your editor of choice)
vi appsettings.Development.local.json
```


#### Migrations

Migrations set up and prepare the database for the data models used in Dotnet.
Make sure to run the [database setup](#database) before running migrations.

```bash
# Make sure tools are installed
dotnet tool restore

# Create migrations and apply
dotnet ef migrations add ShortMigrationDescription
dotnet ef database update
```

### Production
Create ```appsettings.Production.local.json```, and

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
