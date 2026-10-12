# grudUsers

API REST simple en ASP.NET Core (.NET 9) para gestionar usuarios (CRUD) usando Entity Framework Core y SQL Server.

Características principales
- Endpoints REST para la entidad Usuario (IdUser, Nombre, Rol).
- Persistencia con Entity Framework Core (DbContext generado por scaffolding).
- OpenAPI disponible en entorno de desarrollo.

Requisitos
- .NET 9 SDK
- SQL Server accesible (local o remoto)

Configuración
1. Edita el archivo `grudUsers/appsettings.json` o utiliza variables de entorno para la cadena de conexión. La clave usada por la app es `ConnectionStrings:conn`.
   Ejemplo:
   `"Server=TU_SERVIDOR;Database=grudusers;Trusted_Connection=True;TrustServerCertificate=True;"`
2. No incluyas credenciales en el repositorio. Usa secretos de usuario o variables de entorno en producción.

Estructura básica
- grudUsers/Program.cs - configuración de la app y servicios.
- grudUsers/Data/GrudusersContext.cs - DbContext y mapeo de la tabla `usuarios`.
- grudUsers/Models/Usuario.cs - modelo de datos.
- grudUsers/Controllers/UsuariosController.cs - controladores y endpoints.

Endpoints
- GET  /api/Usuarios                -> Lista todos los usuarios
- GET  /api/Usuarios/{id}           -> Obtiene usuario por id
- GET  /api/Usuarios/ByName/{name}  -> Obtiene usuario por nombre
- POST /api/Usuarios                -> Crea usuario
- PUT  /api/Usuarios/{id}           -> Actualiza usuario
- DELETE /api/Usuarios/{id}         -> Elimina usuario

Ejemplos rápidos (curl)
- Obtener todos:
  curl -s http://localhost:5017/api/Usuarios
- Crear usuario:
  curl -X POST http://localhost:5017/api/Usuarios -H "Content-Type: application/json" -d "{\"nombre\":\"Carlos\",\"rol\":\"Admin\"}"

Base de datos y migraciones
- El proyecto incluye un DbContext scaffoldeado. Si quieres usar migraciones de EF Core:
  - Instala las herramientas: `dotnet tool install --global dotnet-ef` (si no las tienes).
  - Crear migración: `dotnet ef migrations add InitialCreate --project grudUsers`
  - Aplicar migración: `dotnet ef database update --project grudUsers`

Ejecución
- Desde Visual Studio: abrir la solución y ejecutar.
- Desde línea de comandos:
  - dotnet restore
  - dotnet run --project grudUsers

Notas
- El fichero `appsettings.json` en este repositorio contiene una cadena de conexión de ejemplo; cámbiala antes de ejecutar en tu entorno.

