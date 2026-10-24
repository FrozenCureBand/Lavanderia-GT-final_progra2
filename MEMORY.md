# MEMORY.md — Hechos comprobados

Registro del proyecto **Pfinal_labanderia**. Cada entrada indica la fecha y cómo se comprobó.
Lo que no está comprobado no se anota aquí (va a "Decisiones pendientes").

## 2026-10-15 · Documento 01 — Prueba de CMD

Comprobado ejecutando `cmd.exe /c`:

- CMD disponible: `Microsoft Windows [Versión 10.0.19045.6466]`,
  `COMSPEC=C:\Windows\system32\cmd.exe`.
- Se creó `PruebaCodex.txt` con `PRUEBA`, se leyó con `type` y se eliminó con `del`. Sin errores.
- Al lanzar CMD desde PowerShell, poner el comando completo entre comillas:
  `cmd.exe /c "a && b"`. Sin comillas, PowerShell rechazó el `&&`; ese intento no ejecutó nada.

## 2026-10-15 · Documento 01 — Inspección inicial

Comprobado con `dir`, `type` y `findstr` (CMD) y leyendo los archivos:

- Solución `Pfinal_labanderia.slnx` en la raíz con 4 proyectos: `Datos`, `Entidad`, `Negocio`,
  `Pfinal_labanderia` (Presentación).
- Los 4 proyectos usan `TargetFrameworkVersion v4.8`.
- `Entidad`, `Datos` y `Negocio` solo contienen `Properties\AssemblyInfo.cs` (sin clases).
- Formularios de Presentación: `logoing`, `precentacion`, `clientes`, `usuarios`, `Tarifas`,
  `Recepciones`. `Program.cs` inicia con `logoing`.
- `Form1.resx` existe en la carpeta pero no está incluido en el `.csproj`.
- Referencias: Presentación → Datos, Entidad, Negocio · Negocio → Datos, Entidad · Datos → Entidad.
- Paquetes: Datos → `System.Data.SqlClient 4.9.1`, `System.Configuration.ConfigurationManager 10.0.12`;
  Presentación → `FontAwesome.Sharp 6.6.0`.
- `App.config`: cadena `ConexionSQLServer` → servidor `localhost,1433`, base `Db_ParqueoAutosUmg`,
  usuario `sa`, contraseña en texto plano. **Conexión no probada.**
- No es repositorio Git (no existe `.git`). Hay carpetas `.vs` en la raíz y en `Datos`, `Entidad`, `Negocio`.

## 2026-10-15 · Documento 01 — Paso 1: estructura documental

Comprobado con `dir /a /b`, `tree /f` y `dir /ad` (CMD):

- Creados en la raíz: `README.md`, `AGENTS.md`, `MEMORY.md`, `ESTADO_DOCUMENTOS.md`, `.gitignore`.
- `skills\`: 11 archivos (`01_Inspeccion_Inicial.md` … `11_Publicacion.md`), sin subcarpetas.
  Skills 01 y 02 completos; 03 a 11 marcados PENDIENTE.
- `database\`: `CONEXION_DATABASE.md` y `01_Backup_Base_Datos.sql` (NO EJECUTADO), sin subcarpetas.
- `docs\`: `COMANDOS_RAPIDOS.md`, sin subcarpetas.
- `src\`: vacía.
- La solución y los proyectos existentes no se modificaron.

## 2026-10-15 · Documento 01 — Paso 2: solución movida a `src\Pfinal_labanderia\`

El estudiante confirmó el árbol, el nombre del sistema (`Pfinal_labanderia`) y autorizó mover la solución.
Comprobado con `tasklist`, `move`, `dir` y un script `.cmd` con `if exist` (CMD):

- Antes de mover, Visual Studio estaba abierto; el estudiante lo cerró y `tasklist` lo confirmó.
- Se movieron a `src\Pfinal_labanderia\`: `Pfinal_labanderia.slnx`, `Datos`, `Entidad`, `Negocio`,
  `Pfinal_labanderia`, `packages` y `.vs` (sigue oculta). No se cambió el contenido de ningún archivo.
- `move` de CMD no encuentra carpetas ocultas: para `.vs` se usó `attrib -h`, `move` y `attrib +h`.
- Existen todas las rutas del `.slnx`, las `ProjectReference` y los `HintPath` de NuGet.
- El `HintPath` relativo a `System.dll` de `Pfinal_labanderia.csproj` ya no existe desde la nueva
  ubicación. `System.dll` sí existe en
  `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\`.
- La raíz quedó con: `.gitignore`, `AGENTS.md`, `ESTADO_DOCUMENTOS.md`, `MEMORY.md`, `README.md`,
  `skills\`, `database\`, `docs\`, `src\`.

## 2026-10-15 · Cambio puntual pedido por el estudiante: botón Usuarios

Pedido explícito del estudiante (corresponde al tema del documento 08, que sigue BLOQUEADO):

- En `precentacion` el botón con texto "Usuarios" se llama `iconButton8` (no existe `btn_usuarios`).
  `panelPrincipal` es un `Panel` con `Dock = Fill`.
- Se editó solo `precentacion.cs`: método `AbrirFormularioEnPanel(Form)` y evento `btnUsuarios_Click`,
  conectado en el constructor. El asistente no modificó ningún `Designer.cs`.
- Después, el estudiante renombró `iconButton8` a `bnt_usuarios` en Visual Studio. El diseñador
  actualizó `precentacion.Designer.cs`, pero no `precentacion.cs`. Se corrigió a mano a
  `bnt_usuarios.Click += btnUsuarios_Click;` y la solución volvió a compilar (código de salida 0).
- **El estudiante probó en ejecución que el botón Usuarios abre `usuarios` en `panelPrincipal`: funciona.**

## 2026-10-15 · Botones Clientes, Recepciones y Tarifas

Pedido explícito del estudiante, con los nombres de botón que él indicó:

- En `precentacion.Designer.cs` el asistente renombró `iconButton1` → `btn_clientes`,
  `iconButton6` → `bnt_recepcion` e `iconButton10` → `btn_tarifas`. Solo cambió el nombre:
  ninguna propiedad de diseño. `iconButton11` e `iconButton12` quedaron intactos (comprobado con búsqueda).
- Se conectaron sus `Click` en el diseñador, como lo hace Visual Studio:
  `btn_clientes_Click` → `clientes`, `bnt_recepcion_Click` → `Recepciones`, `btn_tarifas_Click` → `Tarifas`.
- El estudiante había hecho doble clic en Usuarios y Visual Studio creó `bnt_usuarios_Click` vacío,
  conectado en el diseñador. Se pasó ahí la lógica y se eliminaron la conexión del constructor
  y `btnUsuarios_Click`. Ahora los 4 botones siguen el mismo patrón.
- La solución compila (MSBuild, código de salida 0).
- **Prueba en ejecución de Clientes, Recepciones y Tarifas: PENDIENTE** (la hace el estudiante).
- Requisito del estudiante: al pulsar otro botón, el formulario anterior debe desaparecer.
  Se agregó `CerrarFormularioActivo()`: quita el formulario del panel, lo cierra y lo libera (`Dispose`).
  Compila (MSBuild, código de salida 0). **Prueba en ejecución: PENDIENTE.**
- `logoing` valida usuario y contraseña fijos en el código (tema del documento 07).

## 2026-10-15 · Compilación desde la nueva ubicación

Comprobado con MSBuild 18.10.1 (Visual Studio 18 Community), lanzado desde un `.cmd`:

- `Pfinal_labanderia.slnx` en Debug compila los 4 proyectos. Código de salida 0, ya con el cambio
  del botón Usuarios.
- El `HintPath` roto de `System.dll` no impide compilar.
- **Prueba en ejecución del botón Usuarios: PENDIENTE** (debe hacerla el estudiante).

## 2026-10-16 · Prueba de acceso a SQL Server (pedido explícito del estudiante)

Solo lectura; no se modificó la base de datos ni `App.config`. Comprobado con CMD:

- Servicio `MSSQLSERVER` en `RUNNING`, pero el puerto 1433 lo atienden Docker
  (`com.docker.backend.exe`) y WSL (`wslrelay.exe`).
- `sqlcmd` (ODBC 18) conecta a `localhost,1433` con `sa` y la base `BD_LavanderiaGT`.
  Se usó `-C` (confiar en el certificado); no se probó sin esa opción. Servidor `sql_prog2a`,
  SQL Server 16.0.4255.1 Developer.
- `BD_LavanderiaGT` tiene 11 tablas `dbo.Tbl_*` con 5 filas cada una: Clientes, DetalleRecepciones,
  Entregas, EstadosProceso, Procesos, Recepciones, Servicios, Sucursales, Tarifas, TiposPrenda, Usuarios.
  Coinciden con los 11 botones del menú de `precentacion`.
- `App.config` sigue apuntando a `Db_ParqueoAutosUmg`, que también existe en ese servidor.

## 2026-10-16 · CRUD de Clientes (pedido explícito del estudiante)

Corresponde a los documentos 02 y 03, que seguían BLOQUEADOS; se hizo por pedido directo.

- `Tbl_Clientes` (consultado con `sqlcmd`): `IdCliente` int IDENTITY (PK), `NombreCompleto` varchar(150)
  NOT NULL, `Telefono` varchar(20), `Correo` varchar(100), `Direccion` varchar(250),
  `FechaRegistro` datetime DEFAULT getdate(), `Estado` bit DEFAULT 1.
  `Tbl_Recepciones.IdCliente` → FK sin cascada; los 5 clientes de ejemplo tienen 1 recepción cada uno.
- `App.config`: solo se cambió `Database=` a `BD_LavanderiaGT`.
- Archivos nuevos (registrados en sus `.csproj`): `Entidad\Cliente.cs`, `Datos\Conexion.cs`,
  `Datos\DCliente.cs` (SQL parametrizado), `Negocio\NCliente.cs` (validaciones).
- `clientes.cs`: carga la tabla al abrir; doble clic en una fila → pestaña "Gestionar";
  Nuevo, Cancelar, Guardar (INSERT), Editar (UPDATE) y Eliminar (DELETE con confirmación).
- `clientes.Designer.cs`: solo se agregaron líneas de eventos (`Click`, `CellDoubleClick`, `Load`).
- Nombres reales en el formulario: la tabla es `dataGridViewUsuarios`; los botones son `btnNuevo_clientes`,
  `btnCancelar__clientes`, `btnGuardar__clientes`, `btnEditar__clientes` y `btnEliminar__clientes`.
  Los TextBox conservan nombres de otro formulario (por ejemplo, `textServicio` = Nombre completo).
- Comprobado: la solución compila (MSBuild, código de salida 0). Un programa de prueba de solo lectura
  que usa las DLL compiladas leyó los 5 clientes mediante `NCliente.Listar()`.
- **Guardar, Editar y Eliminar dentro de la ventana: PENDIENTE de prueba** (modifican la base; las prueba el estudiante).

## 2026-10-17 · Documento 02: clase de conexión y prueba inicial

Instrucción del estudiante: solo la conexión y su prueba; sin CRUD; la Presentación sin conexión directa.

- Estado encontrado: el estudiante devolvió `clientes.cs` y `clientes.Designer.cs` a su versión original
  (sin CRUD). Siguen en las capas, compilando y sin uso: `Entidad\Cliente.cs`, `Datos\DCliente.cs`,
  `Negocio\NCliente.cs`. No se tocaron.
- `Datos\Conexion.cs`: se agregó `ProbarConexion(out string mensaje)` con `try-catch` por tipo de error
  (`ConfigurationErrorsException`, `ArgumentException`, `SqlException` traducida por número, `Exception`).
- Nuevo `Negocio\NConexion.cs` (registrado en `Negocio.csproj`): llama a `Datos.Conexion.ProbarConexion`.
- `Program.cs`: antes de abrir `logoing` llama a `NConexion.ProbarConexion` y muestra el resultado en un `MessageBox`.
- Búsqueda en los `.cs` de Presentación: no hay `SqlConnection`, `SqlClient`, `ConfigurationManager` ni `Datos.`.
  Nota: `Pfinal_labanderia.csproj` todavía tiene una referencia de proyecto a `Datos`, sin uso en el código.
- Compila (MSBuild, código de salida 0). Programa de prueba con las DLL compiladas: con el `App.config` real conecta
  a `localhost,1433` / `BD_LavanderiaGT`. Con copias alteradas da mensajes claros para 4060, 18456, 1225 y la cadena ausente.
- Falla corregida: el error 1225 (puerto que rechaza la conexión) caía en el mensaje genérico; se agregó a los errores de red
  y se volvió a probar.
- **Prueba con F5 dentro de Visual Studio: PENDIENTE** (la hace el estudiante).

## 2026-10-17 · Clientes: solo CONSULTAR + paginación (autorizado por el estudiante)

- El estudiante renombró la tabla de `clientes` a `dataGridViewclientes` (comprobado en `clientes.Designer.cs`).
  No se modificó ningún `Designer.cs`.
- `Datos\DCliente.cs` y `Negocio\NCliente.cs` quedaron solo con `Consultar()`. Se quitaron Insertar, Actualizar
  y Eliminar, que no tenían uso. `Entidad\Cliente.cs` no cambió.
- `clientes.cs`: el evento `Load` se conecta en el constructor. La paginación (10 por página) se hace solo en
  Presentación con `GetRange`. Los botones Anterior y Siguiente y el indicador "Página X de Y" se crean por código
  en la pestaña Consulta. `labelRegistros` muestra el total de todos los registros y solo cambia al consultar.
- Compila (MSBuild, código de salida 0). Prueba automática con el `.exe` compilado y el formulario invisible:
  con la base real muestra 5 filas, "Registros: 5", "Página 1 de 1" y los dos botones inactivos.
  Con 23 clientes en memoria (sin escribir en la base) pagina 10/10/3, y el total sigue en 23 en todas las páginas.
- **Prueba del estudiante en Visual Studio (F5): PENDIENTE.**

## 2026-10-23 · Rediseño visual del login (autorizado por el estudiante)

Basado en una imagen de referencia. Decisiones del estudiante: omitir los elementos que necesitan código
(Recordarme, ¿Olvidaste…?, ver contraseña, idioma, botones de rol) y conservar la fuente OCR A Extended.

- Solo se modificó `logoing.Designer.cs`; `logoing.cs` no se tocó. Se conservan `textUser`, `textContraseña`,
  `btnIngresar`, `pictureBox1`, `label1`, `label2` y `label8` con sus eventos.
- Diseño: panel de marca a la izquierda (logo en modo Zoom, lema y 3 características con iconos FontAwesome)
  y tarjeta blanca de inicio de sesión a la derecha. Ventana fija de 1100×680, `AcceptButton = btnIngresar`
  y cajas de texto de una sola línea.
- Comprobado: compila (MSBuild, código de salida 0). Una captura generada desde el `.exe` compilado muestra que
  ningún control se sale de su contenedor y que el foco inicial está en `textUser`.
- **Prueba del estudiante en Visual Studio: PENDIENTE.**

## 2026-10-23 · Pantalla de Inicio (dashboard) y botón `bnt_inicio`

Decisiones del estudiante: diseño con datos reales; formulario nuevo `inicio` (excepción a la regla de no
crear formularios); en el menú solo agregar `bnt_inicio`, sin cambiar su estilo.

- Antes de empezar, el contenedor `sql_prog2a` estaba detenido: se había cerrado con código 1 y el registro
  mostraba un volcado de error de SQL Server. El estudiante lo volvió a encender.
- Esquema leído con `sqlcmd` (solo lectura): `Tbl_Recepciones` (IdSucursal, FechaRecepcion, Total, Estado),
  `Tbl_Entregas` (FechaEntrega), `Tbl_Procesos` → `Tbl_EstadosProceso`,
  `Tbl_DetalleRecepciones` → `Tbl_Tarifas` → `Tbl_Servicios`.
- Archivos nuevos: `Entidad\ResumenInicio.cs`, `Entidad\DatoGrafica.cs`, `Datos\DInicio.cs` (COUNT/SUM/GROUP BY,
  fechas como parámetros), `Negocio\NInicio.cs` (mes actual; últimos 6 meses con ceros), `inicio.cs` e
  `inicio.Designer.cs` (5 tarjetas, 4 gráficas Chart, fecha y hora). Se agregó la referencia
  `System.Windows.Forms.DataVisualization`.
- `precentacion.Designer.cs`: se agregó `bnt_inicio` (icono House, mismo estilo) como primer botón y los demás
  bajaron 46 px. `precentacion.cs`: el `Load` abre `inicio`, y `bnt_inicio_Click` lo vuelve a abrir.
- Comprobado: compila (MSBuild, código de salida 0). Prueba con el `.exe` y la base real: al entrar se muestra
  `inicio` con 5 / 5 / 5 / Q 355.00 / 5 y las 4 gráficas con datos; ningún control se sale de su contenedor;
  Clientes → `bnt_inicio` vuelve a mostrar `inicio` con un solo formulario en el panel.
- **Prueba del estudiante en Visual Studio: PENDIENTE.**

## 2026-10-23 · CONSULTAR en Recepciones, Tarifas y Usuarios (pedido del estudiante)

Mismo patrón aprobado para Clientes: solo CONSULTAR, paginación de 10 en Presentación, total en
`labelRegistros` y ningún `Designer.cs` modificado.

- Archivos nuevos: `Entidad\Recepcion.cs`, `Tarifa.cs`, `Usuario.cs`; `Datos\DRecepcion.cs`, `DTarifa.cs`,
  `DUsuario.cs` (SELECT con JOIN para mostrar nombres); `Negocio\NRecepcion.cs`, `NTarifa.cs`, `NUsuario.cs`.
- Modificados: `Recepciones.cs`, `Tarifas.cs` y `usuarios.cs`. En los tres la tabla se llama `dataGridViewUsuarios`,
  y se conservó ese nombre.
- **Usuarios: la columna `Clave` (contraseña) no se consulta ni existe en la entidad `Usuario`.**
- Las columnas de llaves foráneas (IdCliente, IdSucursal, IdTipoPrenda, IdServicio) se ocultan en la tabla.
- Comprobado: compila (MSBuild, código de salida 0). `sqlcmd` cuenta 5 filas en cada tabla. La prueba automática
  con el `.exe` y la base real muestra 5 filas en cada formulario, "Registros: 5", "Página 1 de 1",
  encabezados claros y ninguna columna de contraseña.
- **Prueba del estudiante en Visual Studio: PENDIENTE.**

## 2026-10-23 · Nuevo / Cancelar / Guardar / Editar / Eliminar en Clientes, Recepciones, Tarifas y Usuarios

Decisiones del estudiante:
- `chkSeleccionar` muestra una **columna de casillas**; al marcar una fila, el registro se carga en "Gestionar".
- Las claves se guardan **cifradas con SHA-256**.
- El Estado de Recepciones es **automático**: las nuevas quedan 'Recibido' y al editar no cambia.
- Se autorizaron **pruebas con registros de prueba**.

- Datos: `DCliente`, `DRecepcion`, `DTarifa` y `DUsuario` con INSERT/UPDATE/DELETE parametrizados. El error 547
  (llave foránea) se traduce a mensajes claros. `DUsuario.ExisteNombreUsuario` sirve para no repetir nombres
  (la tabla no tiene UNIQUE).
- Negocio: validaciones en `NCliente`, `NRecepcion`, `NTarifa` y `NUsuario`.
  `NUsuario.CifrarClave` (SHA-256, 64 hex) queda pública para el Login (documento 07).
- Presentación: nuevo `Formato.cs`, que convierte texto a enteros, decimales y fechas `dd/MM/aaaa [HH:mm]`.
  Los 4 formularios tienen eventos conectados por código (ningún `Designer.cs` modificado). En Recepciones,
  Activo/Inactivo están desactivados. En Usuarios, la clave va con `*`, no se carga al seleccionar, y vacía al editar
  significa que se conserva la actual.
- Hechos de la base: SQL Server en Docker usa hora UTC (6 h adelante). Por eso Negocio pone las fechas "de hoy" con la
  hora local. Las 5 claves existentes están en texto plano (8 caracteres) y no se modificaron. Los nuevos códigos
  automáticos saltaron a 1002/1003; la causa probable es la caché de IDENTITY de SQL Server después del cierre
  inesperado del contenedor.
- Comprobado: compila (MSBuild, código de salida 0). Prueba automática: en las 4 tablas se crearon, editaron y
  eliminaron registros de prueba. Las validaciones y los mensajes de llave foránea funcionan (cliente 1 y recepción 1
  protegidos). La clave guardada es igual al SHA-256 de la clave escrita, y si se deja vacía se conserva.
  La selección con casillas funciona en los 4 formularios. Al final la base quedó con 5 registros por tabla y
  0 registros de prueba.
- **Prueba del estudiante en Visual Studio: PENDIENTE.**

## 2026-10-23 · BUSCAR en Clientes, Recepciones, Tarifas y Usuarios (pedido del estudiante)

- La búsqueda se hace en la base de datos con `LIKE @Patron` (parámetro) y `COLLATE Latin1_General_CI_AI`,
  así que no distingue mayúsculas ni tildes. El nuevo `Datos\Busqueda.cs` arma el patrón '%texto%' y escapa `%`, `_` y `[`.
- Campos buscados: Clientes → nombre y teléfono; Recepciones → cliente y sucursal; Tarifas → tipo de prenda y servicio;
  Usuarios → nombre de usuario y nombre completo (sin leer la clave).
- Cada D* tiene `Buscar(texto)`, que reutiliza la consulta (`ConsultarConFiltro`). Cada N* tiene `Buscar`
  (texto vacío = todos).
- Presentación: Buscar y Enter buscan; Limpiar borra la caja y muestra todo. Si no hay resultados aparece un aviso.
  El resultado usa la paginación y "Registros: N" cuenta lo encontrado. Después de guardar, editar o eliminar
  se repite la búsqueda escrita (`RefrescarTabla`). En Clientes, Limpiar usa el `btnLimpiar_Click` que ya estaba
  conectado en el diseño. Ningún `Designer.cs` modificado.
- Comprobado: compila (MSBuild, código de salida 0). Prueba de solo lectura: "mendez" encuentra "Carlos Méndez",
  "ANDREA" encuentra la recepción de Andrea, "lavanderia" sin tilde encuentra las 5; `%` y `a_b` dan 0 sin errores;
  Buscar, Limpiar y Enter funcionan en los 4 formularios.
- **Prueba del estudiante en Visual Studio: PENDIENTE.**

## 2026-10-24 · Integración del proyecto del compañero (`C:\Users\rephot\Documents\LavanderiasMultinegocio`)

Revisado solo leyendo; su proyecto no se modificó. Usa la misma base `BD_LavanderiaGT`, la misma cadena
`ConexionSQLServer`, .NET Framework 4.8 y 4 capas. Tiene 4 módulos: Entregas, Prendas (`Tbl_TiposPrenda`),
Procesos y Servicios. Su menú principal estaba vacío.

Decisiones del estudiante:
- Rehacer los 4 módulos con la estructura de este proyecto.
- Usar listas desplegables y calendarios en los formularios nuevos.
- No cambiar los formularios actuales.
- Probar con registros de prueba.

- Entidad: `Entrega`, `Proceso`, `TipoPrenda`, `Servicio`, `OpcionLista` (opción de ComboBox).
- Datos: `DEntrega`, `DProceso`, `DTipoPrenda`, `DServicio`; además `DRecepcion.ListarOpciones()`.
- Negocio: `NEntrega`, `NProceso`, `NTipoPrenda`, `NServicio` y `NRecepcion.ListarOpciones()`. Llevan las reglas del
  compañero: una sola entrega por recepción, y la fecha de fin no puede ser anterior al inicio.
- Presentación: formularios `Entregas`, `Procesos`, `TiposPrenda` y `Servicios` con el diseño de este proyecto
  (1044×616, OCR A, pestañas Consulta/Gestionar, paginación de 10, búsqueda, `chkSeleccionar`). Los eventos y
  la paginación están en sus `Designer.cs`, que son nuevos. Los botones del menú `iconButton3`, `iconButton5`,
  `iconButton9` e `iconButton12` se conectan en `precentacion.cs`.
- Largos comprobados con `sqlcmd`: NombreRecibe 150; Observaciones 500 (Entregas y Procesos); Nombre 100;
  Descripción 250. Las 5 recepciones ya tienen entrega. Los 5 tipos de prenda y los servicios 1, 2 y 4 se usan en Tarifas.
- Corrección en clientes, Recepciones, Tarifas y usuarios: con la pantalla al 100 % (96 DPI), los botones de paginación
  creados por código quedaban fuera de la vista (coordenadas sin escalar; comprobado midiendo `Bounds`). Ahora se
  ubican en `Load` a partir del botón Exportar y de la tabla (`UbicarControlesPaginacion`).
- A 96 DPI, los textos de algunos botones del diseño original se ven cortados ("Limpia", "Imprim") en TODOS los
  formularios. Es un problema del diseño original con esa escala; no se cambió.
- Comprobado: compila (MSBuild 18.11.1, código de salida 0). La prueba con registros de prueba salió correcta en los
  4 módulos (CRUD, reglas, llaves foráneas protegidas, búsquedas, listas desplegables, selección, menú). Las pruebas de
  búsqueda y paginación de los formularios anteriores siguen correctas. Al final la base quedó con 5 registros por
  tabla y 0 registros de prueba.
- **Prueba del estudiante en Visual Studio: PENDIENTE.**

## 2026-10-24 · Rediseño visual de todos los formularios (autorizado por el estudiante)

El estudiante pidió que todo el proyecto se parezca a la imagen de referencia (menú azul marino, fondo claro, tarjetas
blancas, acentos azules) sin cambiar la lógica. Eligió la fuente Segoe UI, hacerlo todo de una vez y cambiar en el
código solo las líneas de estilo de la paginación.

- Respaldo de los 11 `Designer.cs` y de `clientes.cs`, `Recepciones.cs`, `Tarifas.cs` y `usuarios.cs` antes de
  cambiar nada (carpeta temporal de la sesión, fuera del proyecto).
- `Designer.cs` cambiados: `precentacion`, `clientes`, `Recepciones`, `Tarifas`, `usuarios`, `Entregas`, `Procesos`,
  `TiposPrenda`, `Servicios` (colores, fuentes, iconos y textos con tilde) y `logoing` e `inicio` (solo la fuente
  OCR A → Segoe UI; en `inicio` además se subieron 6 px los textos de las tarjetas).
- Menú: fondo azul marino, botones blancos alineados a la izquierda con iconos nuevos y una etiqueta nueva
  `labelMarca` ("Lavanderías GT") debajo del logo. Es el único control nuevo.
- Formularios CRUD: fondo claro, pestañas blancas, botón principal azul, Eliminar rojo, los demás blancos con borde,
  tabla sin bordes con filas alternas, títulos azul marino de 16 pt subidos para que no los tape la pestaña.
- En `clientes.cs`, `Recepciones.cs`, `Tarifas.cs` y `usuarios.cs` solo cambiaron las líneas de estilo de los
  botones de paginación y de `labelPagina` (9 pt para que "Página 1 de 1" quepa en una línea).
- Comprobado:
  - compila (MSBuild, código de salida 0);
  - las líneas de eventos (`+= new`) de los 11 `Designer.cs` son idénticas al respaldo;
  - los nombres de controles (`.Name`) son idénticos al respaldo, salvo el nuevo `labelMarca`;
  - las pruebas de solo lectura de consulta/paginación y de búsqueda dieron 0 fallas;
  - la prueba del menú dio "TODO CORRECTO" (abre Inicio, cambia a Clientes y vuelve a Inicio);
  - capturas de los 8 formularios CRUD (Consulta y Gestionar), del menú con Inicio y del login: títulos y
    "Página 1 de 1" completos, y "Limpiar"/"Imprimir" ya no se ven cortados.
- **Prueba del estudiante en Visual Studio: PENDIENTE.**

## Decisiones pendientes

- ¿Retirar la prueba de `Program.cs` o dejar solo el aviso cuando falla? — PENDIENTE.
- Convertir a SHA-256 las 5 claves actuales en texto plano (documento 07, Login) — PENDIENTE.
- Retirar la contraseña de `App.config` antes de Git — PENDIENTE (documento 06).
