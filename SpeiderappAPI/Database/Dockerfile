FROM postgres:alpine

WORKDIR /db
COPY . .
ENV POSTGRES_PASSWORD_FILE secrets/rootPassword
COPY init.sh /docker-entrypoint-initdb.d/initSpeiderapp.sh
EXPOSE 5432
