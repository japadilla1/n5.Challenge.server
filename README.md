# Configuración de `appsettings.json` en la Aplicación

Este archivo `appsettings.json` contiene configuraciones clave para la aplicación, incluyendo la configuración de logging, la cadena de conexión a la base de datos, y la configuración para ElasticSearch.

## Estructura del archivo `appsettings.json`

El archivo `appsettings.json` tiene la siguiente estructura:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=IBA-ONCEDEV27;Database=PermissionsDb;Trusted_Connection=True;Trust Server Certificate=true"
  },
  "ElasticSearch": {
    "EndPoint": "http://localhost:9200/",
    "Index": "permission_registry"
  }
}
