cd /app
/opt/mssql/bin/sqlservr &
echo "Waiting for sql server to come online ..."
sleep 20
echo "/opt/mssql-tools/bin/sqlcmd -S 127.0.0.1 -U sa -P  orion123@ -i /app/mcash-ebl.sql" >> /app/sql.sh
# echo "/opt/mssql-tools/bin/sqlcmd -S 127.0.0.1 -U sa -P orion123@ -i /app/mcash-mtb.sql" >> /app/sql.sh
# echo "/opt/mssql-tools/bin/sqlcmd -S 127.0.0.1 -U sa -P orion123@ -i /app/mcash-wasa.sql" >> /app/sql.sh
echo "Created db ... waiting 10 seconds to start"
sh /app/sql.sh
sleep 10
sleep infinity 