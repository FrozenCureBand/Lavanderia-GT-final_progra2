# Skill 02 — Conexión a SQL Server

> **Estado: COMPLETO (guía)** · Documento 02: ejecutado por instrucción del estudiante (2026-10-17).
> Alcance: solo la clase de conexión y su prueba inicial; **sin CRUD**.

## Objetivo

Conectar la capa **Datos** a SQL Server con la cadena de `App.config`, y probar la conexión
pasando por la capa **Negocio**, sin cambiar el diseño de los formularios.

## Requisitos previos

- Documento 01 cerrado: árbol real confirmado por el estudiante.
- SQL Server instalado y en ejecución, y SQL Server Management Studio (SSMS).
- Base de datos de la lavandería creada o identificada (nombre: PENDIENTE).
- Copia de seguridad hecha antes de cambios importantes
  ([database/01_Backup_Base_Datos.sql](../database/01_Backup_Base_Datos.sql)).

## Situación de partida (comprobada el 2026-10-15)

En `src\Pfinal_labanderia\Pfinal_labanderia\App.config` existe:

| Dato | Valor |
|---|---|
| Nombre | `ConexionSQLServer` |
| Proveedor | `System.Data.SqlClient` |
| Servidor | `localhost,1433` |
| Base de datos | `Db_ParqueoAutosUmg` ← parece de otro proyecto; revisar |
| Autenticación | Usuario SQL `sa` (contraseña en texto plano) |

La conexión **no se ha probado**. El estado actualizado está en
[database/CONEXION_DATABASE.md](../database/CONEXION_DATABASE.md).

## Pasos

### 1. Comprobar el servicio de SQL Server (CMD)

```bat
sc query MSSQLSERVER
sc query "MSSQL$SQLEXPRESS"
```

Una de las dos debe mostrar `STATE : 4 RUNNING`. La primera corresponde a la instancia
predeterminada y la segunda a SQL Server Express.

Si SQL Server corre en **Docker**, el servicio de Windows no es quien atiende el puerto.
Para saber qué proceso atiende el 1433 (cambiar `PID` por el número que muestre `netstat`):

```bat
netstat -ano | findstr :1433
tasklist /svc /nh | findstr PID
```

> Comprobado el 2026-10-16: en este equipo el 1433 lo atienden `com.docker.backend.exe` y `wslrelay.exe`.

### 2. Probar el acceso con `sqlcmd` (CMD)

```bat
sqlcmd -S localhost,1433 -U sa -d BD_LavanderiaGT -C -Q "SELECT @@SERVERNAME, DB_NAME();"
```

- Al omitir `-P`, `sqlcmd` pide la contraseña y así no queda escrita en el historial.
- `-d` elige la base de datos y `-C` confía en el certificado del servidor (sqlcmd de ODBC 18).
- Comprobado el 2026-10-16: con estos datos conecta a `BD_LavanderiaGT` (servidor `sql_prog2a`).

### 3. Corregir la cadena en `App.config`

Cambiar solo `Database=...` por el nombre real de la base de la lavandería.
No escribir contraseñas en los `.md`. Antes de Git (documento 06) se decide
cómo retirar la contraseña del repositorio.

### 4. Clase `Conexion` en la capa Datos

Archivo: [src/Pfinal_labanderia/Datos/Conexion.cs](../src/Pfinal_labanderia/Datos/Conexion.cs).
Si se crea a mano: en Visual Studio, clic derecho en **Datos** → *Agregar* → *Clase*, para que el
`.csproj` (estilo clásico) registre el archivo.

| Método | Qué hace |
|---|---|
| `ObtenerCadena()` | Lee `ConexionSQLServer` de `App.config`; si no existe, lanza un error con mensaje claro |
| `ObtenerConexion()` | Devuelve una `SqlConnection` nueva y cerrada (se abre dentro de `using`) |
| `ProbarConexion(out string mensaje)` | Abre y cierra la conexión dentro de `try-catch`; devuelve `true`/`false` y un mensaje comprensible |

`ProbarConexion` captura cada tipo de error por separado:

- `ConfigurationErrorsException` → problema en `App.config` (por ejemplo, falta la cadena).
- `ArgumentException` → la cadena de conexión está mal escrita.
- `SqlException` → se traduce según `ex.Number` (ver *Errores comunes*) y se agrega el detalle técnico.
- `Exception` → cualquier otro error inesperado.

### 5. Exponer la prueba en la capa Negocio

Archivo: [src/Pfinal_labanderia/Negocio/NConexion.cs](../src/Pfinal_labanderia/Negocio/NConexion.cs).
La Presentación llama a Negocio y Negocio llama a Datos: la Presentación nunca usa `SqlConnection`.

```csharp
public static bool ProbarConexion(out string mensaje)
{
    return Datos.Conexion.ProbarConexion(out mensaje);
}
```

### 6. Probar desde la Presentación (sin cambiar el diseño)

En `Program.cs`, antes de abrir `logoing`. No se agregan ni mueven controles:

```csharp
string mensaje;
bool conectado = NConexion.ProbarConexion(out mensaje);
MessageBox.Show(mensaje,
    conectado ? "Prueba de conexión" : "Error de conexión",
    MessageBoxButtons.OK,
    conectado ? MessageBoxIcon.Information : MessageBoxIcon.Error);
```

Es una prueba inicial: al cerrar el documento 02 se decide con el estudiante si se retira
o si se deja solo el aviso cuando la conexión falla.

### 7. Compilar y ejecutar

En Visual Studio: *Compilar* → *Recompilar solución*, luego `F5`.

## Errores comunes

| Número | Mensaje (resumen) | Causa probable | Qué revisar |
|---|---|---|---|
| -1 / 2 / 26 / 40 / 53 / 1225 / 10060 / 10061 / 11001 | No se pudo llegar al servidor | SQL Server apagado (Docker cerrado), servidor o puerto incorrectos | Docker Desktop, `netstat -ano \| findstr :1433`, `Data Source=` en `App.config` |
| 18456 | Error de inicio de sesión | Usuario o contraseña incorrectos | Autenticación mixta activa, usuario `sa` habilitado |
| 4060 | No se puede abrir la base de datos | La base indicada no existe | Valor `Database=` en `App.config` |
| — | Error de certificado | Cifrado SSL | La cadena ya tiene `TrustServerCertificate=True` |

## Resultado de la prueba (2026-10-17)

Se compiló con MSBuild de Visual Studio (código de salida 0). Después, un programa de prueba fuera del
proyecto ejecutó `NConexion.ProbarConexion` con las DLL compiladas. Los escenarios 2 a 5 usan copias
temporales de la configuración; el proyecto no se modificó para probarlos.

| Escenario | Resultado | Mensaje mostrado |
|---|---|---|
| 1. `App.config` real | Conectado | Conexión exitosa · `localhost,1433` · `BD_LavanderiaGT` |
| 2. Base inexistente | Falla (4060) | La base de datos indicada en App.config no existe… |
| 3. Contraseña incorrecta | Falla (18456) | SQL Server rechazó el inicio de sesión… |
| 4. Puerto sin SQL Server | Falla (1225) | No se pudo llegar al servidor SQL Server… |
| 5. Falta la cadena | Falla | Problema en App.config: No existe la cadena… |

En la primera ejecución el error 1225 mostraba el mensaje genérico; se agregó a la lista de errores de red
y se repitió la prueba con el resultado de la tabla.

## Lista de verificación

- [x] SQL Server responde en `localhost,1433` (en este equipo, mediante Docker).
- [x] `sqlcmd` conecta y muestra la base de la lavandería.
- [x] `App.config` apunta a `BD_LavanderiaGT`.
- [x] `Datos\Conexion.cs` y `Negocio\NConexion.cs` existen y están registrados en sus `.csproj`.
- [x] La solución compila sin errores.
- [x] La prueba muestra "Conexión exitosa" (con las DLL compiladas).
- [ ] La prueba muestra "Conexión exitosa" al pulsar F5 en Visual Studio (la hace el estudiante).
- [ ] Decidir si se retira la prueba de `Program.cs` o se deja solo el aviso de error.
- [ ] `CONEXION_DATABASE.md` y `MEMORY.md` actualizados con lo comprobado.

## Criterio de cierre

Conexión comprobada desde la aplicación, documentada y confirmada por el estudiante.
