\set app speiderapp
\set pass `cat secrets/speiderappPassword`
CREATE USER :app WITH PASSWORD :'pass';
CREATE DATABASE :app;
GRANT ALL PRIVILEGES ON DATABASE :app TO :app;
