# Descripción

Este repositorio contiene el código fuente de la prueba técnica realizada como parte del proceso de selección a la vacante de **Desarrollador .NET** de la empresa **Browser Travel Solutions**.

A grandes rasgos, consiste en una API que permite realizar búsqueda y alquiler de vehículos.

## Tecnologías

Durante el desarrollo se utilizaron las siguientes tecnologías:

- .NET 7
- MetiatR
- Fluent Validation
- Entity Framework

La arquitectura en que me basé fue **CLEAN**.

## Ejecutar con Docker

Primero compile la imagen con el siguiente comando.

```
docker build --pull --rm -f "Dockerfile" -t carrentalapi:latest "."
```

Finalmente inicie el contenedor. 

```
docker run -d -p 5012:80 -e 'ASPNETCORE_ENVIRONMENT=Development' -e 'ConnectionStrings__Default=Data Source=HOST;Initial Catalog=DATABASE;TrustServerCertificate=True;User=USER;Password=PASSWORD;' --name CarRentalApi carrentalapi:latest
```
> Cambia _HOST_ por el host donde se encuentra la base de datos, _DATABASE_ por el nombre de la base de datos, _USER_ por el usuario a utilizar para conectarse a la base de datos y _PASSWORD_ por la contraseña del usuario.

Dirígete a http://localhost:5012/swagger

## Demo

He publicado una demo para que puedan probar la API en la siguiente dirección https://apps.lechediaz.com:5012/swagger
