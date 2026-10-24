# ESTADO_DOCUMENTOS.md

Control de avance del proyecto **Pfinal_labanderia** · Programación II 2026.
Solo el estudiante autoriza un cambio de estado. El asistente actualiza esta tabla
después de recibir la autorización y de comprobar el resultado.

**Documento activo: 01**

| # | Documento | Skill | Estado | Nota |
|---|---|---|---|---|
| 01 | Inspección inicial | [01_Inspeccion_Inicial.md](skills/01_Inspeccion_Inicial.md) | **ACTIVO** | Árbol confirmado. Solución en `src\Pfinal_labanderia\`; compila. Falta que el estudiante cierre el 01 |
| 02 | Conexión SQL Server | [02_Conexion_SQLServer.md](skills/02_Conexion_SQLServer.md) | BLOQUEADO | Trabajado por instrucción del estudiante: `Conexion.ProbarConexion` + prueba en `Program.cs`; compila y conecta (2026-10-17). Falta F5 y cierre |
| 03 | CRUD simple | [03_CRUD_Simple.md](skills/03_CRUD_Simple.md) | BLOQUEADO | Autorizado solo CONSULTAR de Clientes con paginación de 10 (2026-10-17); compila y pasa la prueba automática. Falta la prueba del estudiante. Skill PENDIENTE |
| 04 | CRUD relacional | [04_CRUD_Relacional.md](skills/04_CRUD_Relacional.md) | BLOQUEADO | Skill PENDIENTE |
| 05 | Maestro-detalle | [05_Maestro_Detalle.md](skills/05_Maestro_Detalle.md) | BLOQUEADO | Skill PENDIENTE |
| 06 | Git colaborativo | [06_Git_Colaborativo.md](skills/06_Git_Colaborativo.md) | BLOQUEADO | Después de los CRUD, antes de Login |
| 07 | Login y roles | [07_Login_Roles.md](skills/07_Login_Roles.md) | BLOQUEADO | Al final de la parte funcional |
| 08 | Panel de navegación | [08_Panel_Navegacion.md](skills/08_Panel_Navegacion.md) | BLOQUEADO | Skill PENDIENTE |
| 09 | Dashboard | [09_Dashboard.md](skills/09_Dashboard.md) | BLOQUEADO | Skill PENDIENTE |
| 10 | Revisión del proyecto | [10_Revision_Proyecto.md](skills/10_Revision_Proyecto.md) | BLOQUEADO | Skill PENDIENTE |
| 11 | Publicación | [11_Publicacion.md](skills/11_Publicacion.md) | PENDIENTE | Skill PENDIENTE |

## Estados

- **ACTIVO**: documento en el que se trabaja ahora (solo uno a la vez).
- **BLOQUEADO**: no se puede trabajar hasta que el estudiante lo autorice.
- **PENDIENTE**: todavía no se ha planificado.
- **COMPLETADO**: terminado y confirmado por el estudiante.

## Historial

| Fecha | Documento | Cambio |
|---|---|---|
| 2026-10-15 | 01 | Documento 01 activado. 02–10 bloqueados. |
| 2026-10-15 | 01 | Paso 1: estructura documental creada y verificada con `tree /f`. |
| 2026-10-15 | 01 | El estudiante confirmó el árbol y el nombre `Pfinal_labanderia`. |
| 2026-10-15 | 01 | Paso 2: solución movida a `src\Pfinal_labanderia\`; rutas verificadas con `if exist`. |
| 2026-10-15 | 08 | Cambio puntual pedido por el estudiante: el botón Usuarios abre `usuarios` en `panelPrincipal`. El 08 sigue BLOQUEADO. |
| 2026-10-15 | 01 | La solución compila con MSBuild desde la nueva ubicación (código de salida 0). |
| 2026-10-15 | 08 | El estudiante probó el botón Usuarios: funciona. |
| 2026-10-15 | 08 | Cambio puntual pedido por el estudiante: Clientes, Recepciones y Tarifas abren su formulario en `panelPrincipal`; compila. El 08 sigue BLOQUEADO. |
| 2026-10-16 | 02 | Prueba de acceso de solo lectura pedida por el estudiante: `BD_LavanderiaGT` accesible con `sa`. El 02 sigue BLOQUEADO. |
| 2026-10-16 | 02–03 | Pedido del estudiante: `App.config` → `BD_LavanderiaGT` y CRUD de Clientes en 4 capas. Compila; lectura comprobada. Estados sin cambiar hasta su autorización. |
| 2026-10-17 | 03 | El estudiante devolvió `clientes.cs` y `clientes.Designer.cs` a su versión original (sin CRUD). |
| 2026-10-17 | 02 | Instrucción del estudiante: clase de conexión con `try-catch` y prueba inicial vía Negocio. Compila; conexión y mensajes de error comprobados. |
| 2026-10-17 | 03 | Autorizado: solo CONSULTAR de Clientes con paginación de 10 en Presentación. Compila; prueba automática correcta. |
| 2026-10-23 | — | Rediseño visual del login autorizado (solo `logoing.Designer.cs`; la lógica no cambia). Compila; captura revisada. |
| 2026-10-23 | 08–09 | Pedido del estudiante: formulario `inicio` (dashboard con datos reales) y `bnt_inicio`. Compila; prueba con la base real correcta. 08 y 09 siguen BLOQUEADOS. |
| 2026-10-23 | 03 | Pedido del estudiante: CONSULTAR con paginación en Recepciones, Tarifas y Usuarios (sin mostrar contraseñas). Compila; prueba automática correcta. |
| 2026-10-23 | 03–04 | Pedido del estudiante: Nuevo/Cancelar/Guardar/Editar/Eliminar en Clientes, Recepciones, Tarifas y Usuarios (selección con casillas, claves SHA-256). Compila; prueba con registros de prueba correcta y base intacta. |
| 2026-10-23 | 03 | Pedido del estudiante: BUSCAR en la base (sin distinguir mayúsculas ni tildes) en los 4 formularios. Compila; prueba de solo lectura correcta. |
| 2026-10-24 | 03–05 | Integración del proyecto del compañero: Entregas, Procesos, TiposPrenda y Servicios rehechos con la estructura del proyecto y conectados al menú. Compila; pruebas correctas y base intacta. |
| 2026-10-24 | — | Pedido del estudiante: rediseño visual de los 11 formularios (Segoe UI, menú azul marino, iconos nuevos) sin cambiar la lógica. Compila; eventos y nombres de controles iguales al respaldo; pruebas de solo lectura correctas; capturas revisadas. Falta la prueba del estudiante. |
