FROM microsoft/mssql-server-linux
MAINTAINER Ehasanul Hoque

RUN apt update && apt-get install mssql-tools unixodbc-dev git nano -y

ADD mcash-ebl.sql /app/mcash-ebl.sql
# ADD mcash-mtb.sql /app/mcash-mtb.sql
# ADD mcash-wasa.sql /app/mcash-wasa.sql


ADD runfreshdb.sh /app/runfreshdb.sh

ENTRYPOINT /app/runfreshdb.sh