#!/bin/bash


curl -X DELETE http://localhost:8084/connectors/postgres-sink-pessoa
curl -X DELETE http://localhost:8084/connectors/postgres-sink-pessacontato

#### PESSOA ####
curl -i -X POST -H "Accept:application/json" -H "Content-Type:application/json" localhost:8084/connectors/ -d '
{
  "name": "postgres-sink-pessoa",
  "config": {
    "connector.class": "io.confluent.connect.jdbc.JdbcSinkConnector",
    "tasks.max": "1",
    "topics": "sqlserver-PESSOA",
    "connection.url": "jdbc:postgresql://postgres:5432/postgres?options=-c%20search_path=public",
    "connection.user": "postgres",
    "connection.password": "postgres",
    "table.name.format": "PESSOA",
    "insert.mode": "insert",
    "pk.mode": "none",
    "auto.create": "true",
    "database.history.kafka.bootstrap.servers" : "kafka:9092",
    "database.history.kafka.topic": "schema-changes.inventory"
  }
}
'

#### PESSOACONTATO ####
curl -i -X POST -H "Accept:application/json" -H "Content-Type:application/json" localhost:8084/connectors/ -d '
{
  "name": "postgres-sink-pessoacontato",
  "config": {
    "connector.class": "io.confluent.connect.jdbc.JdbcSinkConnector",
    "tasks.max": "1",
    "topics": "sqlserver-PESSOACONTATO",
    "connection.url": "jdbc:postgresql://postgres:5432/postgres?options=-c%20search_path=public",
    "connection.user": "postgres",
    "connection.password": "postgres",
    "table.name.format": "PESSOACONTATO",
    "insert.mode": "insert",
    "pk.mode": "none",
    "auto.create": "true",
    "database.history.kafka.bootstrap.servers" : "kafka:9092",
    "database.history.kafka.topic": "schema-changes.inventory"
  }
}
'
