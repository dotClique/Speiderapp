# Database
Create two files, ```secrets/rootPassword``` and ```secrets/speiderappPassword```,
with the desired root and app-specific database passwords. Build the Docker image using  
```bash
docker build -t speiderapp-database
```
in the correct directory, optionally with ```--no-cache``` to force complete rebuild.