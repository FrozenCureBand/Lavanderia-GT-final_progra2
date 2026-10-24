# CONEXION_DATABASE.md — Estado de la conexión a SQL Server

> **Estado: CONEXIÓN COMPROBADA** (2026-10-17) · `App.config` apunta a `BD_LavanderiaGT`.
> `Datos.Conexion.ProbarConexion` conecta a través de Negocio (`NConexion`). Prueba con F5 en Visual Studio: PENDIENTE.
> Guía: [skills/02_Conexion_SQLServer.md](../skills/02_Conexion_SQLServer.md).

## Configuración actual (`App.config`; base cambiada el 2026-10-16)

Ubicación del archivo: `src\Pfinal_labanderia\Pfinal_labanderia\App.config`.

| Dato | Valor |
|---|---|
| Nombre de la cadena | `ConexionSQLServer` |
| Proveedor | `System.Data.SqlClient` |
| Servidor | `localhost,1433` |
| Base de datos | `BD_LavanderiaGT` (antes `Db_ParqueoAutosUmg`) |
| Autenticación | Usuario SQL `sa` (la contraseña **no** se copia aquí) |
| Opciones | `Pooling=False`, `MultipleActiveResultSets=False`, `Encrypt=False`, `TrustServerCertificate=True` |

## Prueba de acceso (2026-10-16, solo lectura)

Datos indicados por el estudiante: servidor `localhost,1433`, base `BD_LavanderiaGT`,
autenticación SQL Server, usuario `sa` (contraseña no se copia aquí).

Comprobado desde CMD con `sqlcmd` (ODBC 18, opción `-C` para confiar en el certificado):

| Dato | Resultado |
|---|---|
| Inicio de sesión | Correcto (`SUSER_SNAME()` = `sa`) |
| Servidor (`@@SERVERNAME`) | `sql_prog2a` |
| Versión | SQL Server `16.0.4255.1`, Developer Edition (64-bit) |
| `BD_LavanderiaGT` | Existe, `ONLINE` |
| `Db_ParqueoAutosUmg` | También existe en el mismo servidor, `ONLINE` |
| Puerto 1433 | Lo atienden `com.docker.backend.exe` (Docker) y `wslrelay.exe` (WSL), no el servicio `MSSQLSERVER` de Windows (que también está `RUNNING`) |

Tablas de `BD_LavanderiaGT` (11, cada una con 5 filas):

| Tabla | Tabla |
|---|---|
| `dbo.Tbl_Clientes` | `dbo.Tbl_Recepciones` |
| `dbo.Tbl_DetalleRecepciones` | `dbo.Tbl_Servicios` |
| `dbo.Tbl_Entregas` | `dbo.Tbl_Sucursales` |
| `dbo.Tbl_EstadosProceso` | `dbo.Tbl_Tarifas` |
| `dbo.Tbl_Procesos` | `dbo.Tbl_TiposPrenda` |
| `dbo.Tbl_Usuarios` | |

## Observaciones

- La conexión se lee en `src\Pfinal_labanderia\Datos\Conexion.cs` (cadena `ConexionSQLServer`).
- Los 5 clientes de ejemplo tienen 1 recepción cada uno: la llave foránea `FK_Recepciones_Clientes`
  (`Tbl_Recepciones.IdCliente`, sin borrado en cascada) impide eliminarlos.
- La contraseña está en texto plano dentro de `App.config`: no debe subirse a GitHub (documento 06).

## Pendientes

- [x] SQL Server responde en `localhost,1433`.
- [x] El usuario `sa` puede iniciar sesión.
- [x] Nombre real de la base de datos: `BD_LavanderiaGT`.
- [x] `Database=` de `App.config` cambiado a `BD_LavanderiaGT` (pedido del estudiante).
- [x] Lectura desde las capas compiladas (programa de prueba que llama a `NCliente.Listar()`): 5 clientes.
- [x] `ProbarConexion` con las DLL compiladas: conecta; y con configuraciones alteradas muestra mensajes claros (2026-10-17).
- [ ] Prueba de conexión al pulsar F5 en Visual Studio (la hace el estudiante).

## Historial

| Fecha | Cambio | Cómo se comprobó |
|---|---|---|
| 2026-10-15 | Registro inicial de la configuración | Lectura de `App.config` |
| 2026-10-15 | `App.config` cambió de carpeta al mover la solución a `src\Pfinal_labanderia\` (contenido sin cambios) | `dir`, `if exist` |
| 2026-10-16 | Acceso de solo lectura a `BD_LavanderiaGT` comprobado; 11 tablas listadas | `sc query`, `netstat`, `tasklist`, `sqlcmd` |
| 2026-10-16 | `App.config` → `BD_LavanderiaGT`; lectura de clientes desde Negocio/Datos correcta | MSBuild + programa de prueba de solo lectura |
| 2026-10-17 | `Conexion.ProbarConexion` + `NConexion`; 5 escenarios de prueba con el resultado esperado | MSBuild + programa de prueba con las DLL compiladas |
