# AGENTS.md — Reglas para asistentes de IA

Proyecto **Pfinal_labanderia** · Programación II 2026.
Estas reglas son obligatorias para cualquier asistente que trabaje en esta carpeta.

## 1. Terminal: preferir CMD

- En Windows se usa **CMD (`cmd.exe`)**. **No usar PowerShell si CMD está disponible.**
- Si el asistente solo tiene una herramienta de PowerShell o Bash, debe lanzar CMD así:
  `cmd.exe /c "comando1 && comando2"` y decirlo con transparencia.
- Si CMD no se puede ejecutar, **detenerse e informar**. Nunca afirmar que se usó CMD
  ni que una prueba fue exitosa si no lo fue.
- No usar cmdlets de PowerShell (`Get-ChildItem`, `Set-Content`, etc.) cuando exista
  un comando CMD equivalente. Ver [docs/COMANDOS_RAPIDOS.md](docs/COMANDOS_RAPIDOS.md).

## 2. Tecnologías y arquitectura

- C# · .NET Framework (el proyecto usa 4.8) · Windows Forms · SQL Server.
- Cuatro capas, cada una en su proyecto:
  - **Entidad**: clases simples que representan las tablas (propiedades).
  - **Datos**: acceso a SQL Server (conexión, consultas).
  - **Negocio**: validaciones y reglas; une Presentación con Datos.
  - **Presentación** (`Pfinal_labanderia`): formularios Windows Forms.
- La Presentación debe llamar a Negocio, no a Datos directamente.
- POO básica: clases, propiedades, constructores, encapsulación y métodos con responsabilidad clara.

## 3. Reglas de código

- **Consultas parametrizadas siempre** (`SqlParameter` / `Parameters.AddWithValue`).
  Prohibido concatenar valores del usuario en el texto SQL.
- **`try-catch`** en el acceso a datos y en los eventos de los formularios, con mensajes claros.
- Usar `using` para `SqlConnection`, `SqlCommand` y `SqlDataReader`.
- La cadena de conexión se lee de `App.config` (nombre `ConexionSQLServer`), nunca escrita en el código.
- **Comentarios didácticos**: explicar el *porqué* de cada bloque, pensando en un estudiante.
- Los proyectos son de estilo clásico (no SDK): los archivos `.cs` nuevos se agregan desde
  Visual Studio (*Agregar → Clase*) para que queden incluidos en el `.csproj`.

## 4. Conservar los diseños existentes

- No renombrar, borrar ni rediseñar formularios ni controles existentes
  (`logoing`, `precentacion`, `clientes`, `usuarios`, `Tarifas`, `Recepciones`).
- No editar a mano los archivos `*.Designer.cs` salvo autorización.
- No borrar archivos existentes (por ejemplo `Form1.resx`) sin autorización.

## 5. Orden de trabajo y bloqueo de documentos

1. 01 Inspección → 02 Conexión SQL Server → 03–05 CRUD.
2. **06 Git/GitHub después de los CRUD y antes de Login.**
3. **07 Login y roles al final** de la parte funcional.
4. 08 Panel · 09 Dashboard · 10 Revisión · 11 Publicación.

- Solo se trabaja en el documento **ACTIVO** de [ESTADO_DOCUMENTOS.md](ESTADO_DOCUMENTOS.md).
- **Los documentos 02 al 10 están BLOQUEADOS** hasta que el estudiante los autorice.
- No programar CRUD durante el documento 01.
- No avanzar a SQL Server hasta que el estudiante confirme el árbol real de carpetas.

## 6. Estructura de carpetas

- `skills\`, `database\` y `docs\` son **carpetas planas: sin subcarpetas**.
- `src\` contiene solo `NombreSistema\` = `src\Pfinal_labanderia\` (la solución y sus 4 proyectos).
- No crear soluciones ni formularios nuevos dentro de `src\`.
  Excepción autorizada por el estudiante (2026-10-23): el formulario `inicio` (pantalla de Inicio / dashboard).
  Excepción autorizada por el estudiante (2026-10-24): `Entregas`, `Procesos`, `TiposPrenda` y `Servicios`,
  módulos integrados desde el proyecto del compañero (`LavanderiasMultinegocio`) con la estructura de este proyecto.
- Para mover o renombrar carpetas del proyecto, Visual Studio debe estar cerrado
  (comprobar con `tasklist | findstr /i devenv`).
- `database\01_Backup_Base_Datos.sql` es una plantilla: no se ejecuta sin autorización.

## 7. Forma de trabajar

- Mostrar primero el plan y esperar autorización.
- **Preguntar al estudiante al terminar cada paso.**
- Actualizar los archivos `.md` **solo con hechos comprobados** (indicar cómo se comprobó).
  Lo no comprobado se marca como `PENDIENTE`.
- Informar con honestidad qué se ejecutó y qué falló.

## 8. Seguridad

- No copiar contraseñas en los `.md`.
- La contraseña de SQL Server está solo en `Conexion.config` (en `.gitignore`, nunca se sube).
  `App.config` la lee con `configSource`. En el repositorio va `Conexion.config.ejemplo` sin contraseña.
- Antes de cada commit, comprobar que la contraseña no esté en lo que se sube (`git grep --cached`).
