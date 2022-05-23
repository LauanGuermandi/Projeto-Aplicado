#!/bin/bash


curl -X DELETE http://localhost:8084/connectors/sqlserver-source


#### PESSOA ####
curl -i -X POST -H "Accept:application/json" -H "Content-Type:application/json" localhost:8084/connectors/ -d '

{
  "name": "sqlserver-source",
  "config": {
    "connector.class": "io.confluent.connect.jdbc.JdbcSourceConnector",
    "tasks.max": "1",
    "topic.prefix": "sqlserver-",
    "connection.url": "jdbc:sqlserver://sqlserver:1433;database=PROJETOAPLICADO;username=sa;password=Secret@1234;",
    "mode": "incrementing",
    "incrementing.column.name": "IDPESSOA",
    "table.whitelist": "PESSOA,PESSOACONTATO",
    "validate.non.null": "false"
  }
}
'

