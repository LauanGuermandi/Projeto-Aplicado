#!/bin/bash

#### PESSOA ####
curl -i -X POST -H "Accept:application/json" -H "Content-Type:application/json" localhost:8084/connectors/ -d '
{
  "name": "connector-sink-PESSOA",
  "config": {
    "connector.class" : "com.mongodb.kafka.connect.MongoSinkConnector",
    "tasks.max" : "1",
    "topics": "dbserver.dbo.PESSOA",
    "connection.uri": "mongodb://mongo:27017/PROJETOAPLICADO",
    "database": "PROJETOAPLICADO",
    "collection": "PESSOA",
    "database.history.kafka.bootstrap.servers" : "kafka:9092",
    "database.history.kafka.topic": "schema-changes.inventory",
    "key.converter": "org.apache.kafka.connect.json.JsonConverter",
    "value.converter": "org.apache.kafka.connect.json.JsonConverter",
    "document.id.strategy": "com.mongodb.kafka.connect.sink.processor.id.strategy.PartialValueStrategy",
    "document.id.strategy.partial.value.projection.list":"IDPESSOA",
    "document.id.strategy.partial.value.projection.type":"AllowList",
    "writemodel.strategy":"com.mongodb.kafka.connect.sink.writemodel.strategy.ReplaceOneBusinessKeyStrategy",
    "transforms": "InsertField,ExtractField",
    "transforms.InsertField.type": "org.apache.kafka.connect.transforms.InsertField$Value",
    "transforms.InsertField.static.field": "MessageSource",
    "transforms.InsertField.static.value": "Kafka Connect framework",
    "transforms.ExtractField.type":"org.apache.kafka.connect.transforms.ExtractField$Value",
    "transforms.ExtractField.field":"after"
  }
}
'


### PESSOAFISICA ###
curl -i -X POST -H "Accept:application/json" -H "Content-Type:application/json" localhost:8084/connectors/ -d '
{
  "name": "connector-sink-PESSOAFISICA",
  "config": {
    "connector.class" : "com.mongodb.kafka.connect.MongoSinkConnector",
    "tasks.max" : "1",
    "topics": "dbserver.dbo.PESSOAFISICA",
    "connection.uri": "mongodb://mongo:27017/PROJETOAPLICADO",
    "database": "PROJETOAPLICADO",
    "collection": "PESSOAFISICA",
    "database.history.kafka.bootstrap.servers" : "kafka:9092",
    "database.history.kafka.topic": "schema-changes.inventory",
    "key.converter": "org.apache.kafka.connect.json.JsonConverter",
    "value.converter": "org.apache.kafka.connect.json.JsonConverter",
    "document.id.strategy": "com.mongodb.kafka.connect.sink.processor.id.strategy.PartialValueStrategy",
    "document.id.strategy.partial.value.projection.list":"IDPESSOA",
    "document.id.strategy.partial.value.projection.type":"AllowList",
    "writemodel.strategy":"com.mongodb.kafka.connect.sink.writemodel.strategy.ReplaceOneBusinessKeyStrategy",
    "transforms": "InsertField,ExtractField",
    "transforms.InsertField.type": "org.apache.kafka.connect.transforms.InsertField$Value",
    "transforms.InsertField.static.field": "MessageSource",
    "transforms.InsertField.static.value": "Kafka Connect framework",
    "transforms.ExtractField.type":"org.apache.kafka.connect.transforms.ExtractField$Value",
    "transforms.ExtractField.field":"after"
  }
}
'

### PESSOAJURIDICA ###
curl -i -X POST -H "Accept:application/json" -H "Content-Type:application/json" localhost:8084/connectors/ -d '
{
  "name": "connector-sink-PESSOAJURIDICA",
  "config": {
    "connector.class" : "com.mongodb.kafka.connect.MongoSinkConnector",
    "tasks.max" : "1",
    "topics": "dbserver.dbo.PESSOAJURIDICA",
    "connection.uri": "mongodb://mongo:27017/PROJETOAPLICADO",
    "database": "PROJETOAPLICADO",
    "collection": "PESSOAJURIDICA",
    "database.history.kafka.bootstrap.servers" : "kafka:9092",
    "database.history.kafka.topic": "schema-changes.inventory",
    "key.converter": "org.apache.kafka.connect.json.JsonConverter",
    "value.converter": "org.apache.kafka.connect.json.JsonConverter",
    "document.id.strategy": "com.mongodb.kafka.connect.sink.processor.id.strategy.PartialValueStrategy",
    "document.id.strategy.partial.value.projection.list":"IDPESSOA",
    "document.id.strategy.partial.value.projection.type":"AllowList",
    "writemodel.strategy":"com.mongodb.kafka.connect.sink.writemodel.strategy.ReplaceOneBusinessKeyStrategy",
    "transforms": "InsertField,ExtractField",
    "transforms.InsertField.type": "org.apache.kafka.connect.transforms.InsertField$Value",
    "transforms.InsertField.static.field": "MessageSource",
    "transforms.InsertField.static.value": "Kafka Connect framework",
    "transforms.ExtractField.type":"org.apache.kafka.connect.transforms.ExtractField$Value",
    "transforms.ExtractField.field":"after"
  }
}
'



### PESSOATELEFONE ###
curl -i -X POST -H "Accept:application/json" -H "Content-Type:application/json" localhost:8084/connectors/ -d '
{
  "name": "connector-sink-PESSOATELEFONE",
  "config": {
    "connector.class" : "com.mongodb.kafka.connect.MongoSinkConnector",
    "tasks.max" : "1",
    "topics": "dbserver.dbo.PESSOATELEFONE",
    "connection.uri": "mongodb://mongo:27017/PROJETOAPLICADO",
    "database": "PROJETOAPLICADO",
    "collection": "PESSOATELEFONE",
    "database.history.kafka.bootstrap.servers" : "kafka:9092",
    "database.history.kafka.topic": "schema-changes.inventory",
    "key.converter": "org.apache.kafka.connect.json.JsonConverter",
    "value.converter": "org.apache.kafka.connect.json.JsonConverter",
    "document.id.strategy": "com.mongodb.kafka.connect.sink.processor.id.strategy.PartialValueStrategy",
    "document.id.strategy.partial.value.projection.list":"IDPESSOA",
    "document.id.strategy.partial.value.projection.type":"AllowList",
    "writemodel.strategy":"com.mongodb.kafka.connect.sink.writemodel.strategy.ReplaceOneBusinessKeyStrategy",
    "transforms": "InsertField,ExtractField",
    "transforms.InsertField.type": "org.apache.kafka.connect.transforms.InsertField$Value",
    "transforms.InsertField.static.field": "MessageSource",
    "transforms.InsertField.static.value": "Kafka Connect framework",
    "transforms.ExtractField.type":"org.apache.kafka.connect.transforms.ExtractField$Value",
    "transforms.ExtractField.field":"after"
  }
}
'


### PESSOAEMAIL ###
curl -i -X POST -H "Accept:application/json" -H "Content-Type:application/json" localhost:8084/connectors/ -d '
{
  "name": "connector-sink-PESSOAEMAIL",
  "config": {
    "connector.class" : "com.mongodb.kafka.connect.MongoSinkConnector",
    "tasks.max" : "1",
    "topics": "dbserver.dbo.PESSOAEMAIL",
    "connection.uri": "mongodb://mongo:27017/PROJETOAPLICADO",
    "database": "PROJETOAPLICADO",
    "collection": "PESSOAEMAIL",
    "database.history.kafka.bootstrap.servers" : "kafka:9092",
    "database.history.kafka.topic": "schema-changes.inventory",
    "key.converter": "org.apache.kafka.connect.json.JsonConverter",
    "value.converter": "org.apache.kafka.connect.json.JsonConverter",
    "document.id.strategy": "com.mongodb.kafka.connect.sink.processor.id.strategy.PartialValueStrategy",
    "document.id.strategy.partial.value.projection.list":"IDPESSOA",
    "document.id.strategy.partial.value.projection.type":"AllowList",
    "writemodel.strategy":"com.mongodb.kafka.connect.sink.writemodel.strategy.ReplaceOneBusinessKeyStrategy",
    "transforms": "InsertField,ExtractField",
    "transforms.InsertField.type": "org.apache.kafka.connect.transforms.InsertField$Value",
    "transforms.InsertField.static.field": "MessageSource",
    "transforms.InsertField.static.value": "Kafka Connect framework",
    "transforms.ExtractField.type":"org.apache.kafka.connect.transforms.ExtractField$Value",
    "transforms.ExtractField.field":"after"
  }
}
'

