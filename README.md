# 🔌 SimuVerse Lab - API REST (ASP.NET Core)

Este backend conecta la plataforma web y la aplicación VR de **SimuVerse Lab**, proveyendo datos seguros y estructurados sobre usuarios, aulas, laboratorios y resultados de experimentos.

## 🔧 Tecnologías

- ASP.NET Core 8
- SQL Server
- Entity Framework Core
- JWT Authentication

## 📚 Endpoints Principales

- `/api/Autenticacion/ValidarAutenticacion` → Autenticación de usuario.
- `/api/Dashboard` → Dashboard.
- `/api/Usuario` → Gestión de usuarios.
- `/api/Aula` → Aulas según institución.
- `/api/Laboratorio` → Laboratorios disponibles.
- `/api/Experimento` → Resultados y registros de simulaciones.

## 🛠️ Configuración

- Cambiar la cadena de conexión en `appsettings.json`.

```bash
dotnet restore
dotnet run
```

## 🔐 Seguridad

- JWT para autenticación segura.
- Políticas por rol.
