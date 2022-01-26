# Speiderapp

Speiderapp is a mobile-first webapp for (Norwegian) scouts.

## Backend (API)
We use a ASP.NET backend as for the API. Please read separate [README.md](./SpeiderappAPI/README.md).


# Common setup

## Requirements
This project expect the use of a Unix-like, like Mac OS, Linux or WSL.
It can probably run on Windows/others too, but this may need adapting some commands.

## Use of Makefile
This project is using a `makefile` for handling setup and common tasks.

The following commands are supported:
* make help		- Print this information
* make restore		- Restore the project for development
* make format		- Run dotnet format with whitespace, style and analyzers set
