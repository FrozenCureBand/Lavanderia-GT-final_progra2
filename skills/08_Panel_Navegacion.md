# Skill 08 — Panel de navegación

> **Estado: COMPLETADO** por confirmación y autorización definitiva del estudiante (2026-10-30). El estudiante ha referido este trabajo como Documento 07; en la matriz del proyecto corresponde al 08.

## Controles, eventos y destinos confirmados

El formulario principal es `precentacion`; sus controles están declarados en `precentacion.Designer.cs` y su
navegación está en `precentacion.cs`.

| Texto del botón | Control real | Formulario que abre |
|---|---|---|
| Inicio | `bnt_inicio` | `inicio` |
| Clientes | `btn_clientes` | `clientes` |
| Detalle recepciones | `iconButton2` | `Recepciones` |
| Entregas | `iconButton3` | `Entregas` |
| Estados de proceso | `iconButton4` | `Procesos` |
| Procesos | `iconButton5` | `Procesos` |
| Recepciones | `bnt_recepcion` | `Recepciones` |
| Usuarios | `bnt_usuarios` | `usuarios` |
| Tipos de prenda | `iconButton9` | `TiposPrenda` |
| Tarifas | `btn_tarifas` | `Tarifas` |
| Sucursales | `iconButton11` | `inicio` (indicadores y gráfica por sucursal) |
| Servicios | `iconButton12` | `Servicios` |

Detalle de recepciones y Estados de proceso reutilizan módulos existentes, no pantallas independientes. Sucursales
abre el resumen existente y no ofrece mantenimiento de sucursales.

## Comportamiento y arquitectura

- Al cargar `precentacion`, `MenuPrincipal_Load` abre `inicio`.
- `AbrirFormularioEnPanel(Form)` presenta un formulario en el `panelPrincipal` ya existente, con `TopLevel = false`,
  sin borde, `Dock = Fill` y `Show()`. `CerrarFormularioActivo()` retira y libera el formulario al cambiar de módulo.
- Si se pulsa de nuevo la opción actualmente abierta, se conserva la instancia activa y se libera la instancia recién
  creada; no se muestra otra ventana igual.
- Los formularios de Presentación usan la capa Negocio. El proyecto Presentación mantiene referencias a Negocio,
  Entidad y Datos; `precentacion.cs` no accede directamente a SQL Server.
- No se agregaron controles ni formularios y no se modificó el diseño del Panel en esta revisión.

## Verificación

- Nombres y enlaces revisados estáticamente en `precentacion.cs` y `precentacion.Designer.cs`.
- Referencias entre proyectos comprobadas en `Pfinal_labanderia.csproj`.
- `Pfinal_labanderia.slnx` compiló con MSBuild 17.14.40, configuración Debug y salida alternativa `obj\PanelBuild`:
  0 advertencias y 0 errores. La salida normal no se pudo actualizar porque DLL de `bin\Debug` estaban en uso.
- La aplicación no se ejecutó en esta verificación. Las pruebas manuales de los botones quedan pendientes del
  estudiante; el cierre del documento también queda pendiente de su confirmación.

### Pruebas en ejecución registradas previamente

- `Usuarios`: el estudiante confirmó que abre `usuarios` dentro del panel (2026-10-15).
- `Inicio` y `Clientes`: una prueba automática registrada abrió Inicio, cambió a Clientes y volvió a Inicio
  (2026-10-24).
- `Entregas`, `Procesos`, `Tipos de prenda` y `Servicios`: el registro de integración de esos módulos informa
  pruebas que incluyeron menú (2026-10-24); no se volvió a ejecutar esa prueba en esta revisión.
- El estudiante confirmó y autorizó el cierre definitivo. Las pruebas individuales de las rutas listadas no se repitieron en esta actualización.
