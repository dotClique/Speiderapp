# Docker setup
This folder contains Docker setup-files.

## Database
In order to set up the Postgres-container root- and app-passwords must be provided.
Create two files, `secrets/rootPassword` and `secrets/speiderappPassword`,
nothing but the desired passwords inside. To build the Docker, run
```bash
docker build -t speiderapp-database
```
in the correct directory, optionally with `--no-cache` to force complete rebuild.
