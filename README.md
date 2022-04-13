# API_JWT_VILLAMAR_LOGIN_REGISTRO
 Api desarrollada en .net mediante el uso de jwt para registro y login de usuarios.
API .net JWT Villamar
En esta ocasión crearemos un api con jwt para validar la seguridad de un login mediante el uso de .net y SQL server.

Utilizaremos el servidor de base de datos SQL Server, y visual studio.

1.- Crearemos el proyecto API con c# 
2.- Escogemos la versión de core en este caso 5.
3.- Le damos un nombre al proyecto en nuestro caso es API_JWT_VILLAMAR
4.- Crearemos 3 carpetas llamadas: Data, IdentityAuth y Models.
5.- Instalar los paquetes de  
Microsoft.EntityFrameworkCore.SqlServer,
Microsoft.AspNetCore.Authentication.JwtBearer,
Microsoft.AspNetCore.Identity.EntityFrameworkCore,
Microsoft.EntityFrameworkCore.Tools
En versiones 5.0.15
Microsoft.AspNetCore.Identity
En version más reciente.
6.- Modificaremos el archivo appsettings.json para la cadena de conexión.
7.- Tomaremos la applicationUrl de la ruta de Properties en launchSettings.json
"applicationUrl": "http://localhost:28361"
8.- Generaremos una clave aleatoria utilizando cualquier generador de internet en este caso recomiendo que la longitud sea de 40 caracteres sin incluir símbolos en este caso.
La clave generada es la siguiente

KYk9z8fSCK7Zh6FSYp85UdHqLzGG8BTuMw4E3Cws

9.- Nuestro archivo de appsettings.json debería verse similar a esto

  "ConnectionStrings": {
    "DefaultConnection": "Server=LAPTOP-M2BTP9V4;Database=JWTAutorizacion;user id=adrian password= villamar;Trusted_Connection=True;"
  },
  "JWT": {
    "SecretKey": "KYk9z8fSCK7Zh6FSYp85UdHqLzGG8BTuMw4E3Cws",
    "ValidIssuer": "http://localhost:28361",
    "ValidAudience": "http://localhost:28361"
  }

10.- En la carpeta IdentityAuth crearemos una nueva clase llamada ApplicationUser.
11.- En la carpeta data crearemos una nueva clase llamada ApplicationDbContext. Quedando de la siguiente manera.

using API_JWT_VILLAMAR.IdentityAuth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API_JWT_VILLAMAR.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}

12.- Ahora modificaremos el archivo startup.cs para incluir un nuevo servicio de conexion.

services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

13.- Agregaremos un build al proyecto para verificar que existe un correcto funcionamiento del proyecto.

14.- Agregaremos una nueva migración en Package Manager Console con el comando add-migration donde AutorizoJWTinicio es solo el nombre de la migración

        add-migration AutorizoJWTinicio

16.- Subimos los cambios a la base de datos con el comando 

      update-database

17.- En la carpeta Models crearemos una nueva clase llamada RegisterModel, quedando de la siguiente manera.

using System.ComponentModel.DataAnnotations;

namespace API_JWT_VILLAMAR.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage="Nombre de usuario requerido")]
        public string UserName { get; set; }
        [EmailAddress]
        public string Password { get; set; }
        [Required(ErrorMessage="Clave requerida")]
        public string Email { get; set; }
    }
}

18.- En la misma ruta crearemos una nueva clase llamada LoginModel quedando de la siguiente forma.

using System.ComponentModel.DataAnnotations;

namespace API_JWT_VILLAMAR.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage="Usuario es requerido")]
        public string Username { get; set; }

        [Required(ErrorMessage="Clave requerida")]

        public string Password { get; set; }
    }
}

19.- En la misma ruta crearemos una clase llamada Response

namespace API_JWT_VILLAMAR.Models
{
    public class Response
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}

20.- En la misma ruta crearemos una nueva clase llamada UserRoles quedando de la siguiente forma.

namespace API_JWT_VILLAMAR.Models
{
    public class UserRoles
    {
        public static string Admin = "Admin";
        public static string User = "Usuario";
    }
}

21.- En la carpeta Controllers crearemos un nuevo controlador de API vacío llamado AuthenticateController

22.- Y modificamos el Startup.cs con lo que necesario de las clases creadas, revisar el código para ver lo realizado.

23.- Una vez hecho y verificado la función de registro y de logueo procederemos a blindar nuestra api con el controller de ejemplo llamado WeatherForecastController
using Microsoft.AspNetCore.Authorization;
[Authorize]

24.- Nos logueamos, copiamos el token y accederemos por el mismo para solicitar dicho recurso previamente mencionado.

