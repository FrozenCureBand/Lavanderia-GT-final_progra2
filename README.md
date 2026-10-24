# Pfinal_labanderia — Sistema de Lavandería

Proyecto final del curso **Programación II 2026**.
Aplicación de escritorio para gestionar una lavandería: clientes, recepciones, tarifas, usuarios,
entregas, procesos, tipos de prenda y servicios, con una pantalla de Inicio (dashboard).

> Estado actual: los 8 módulos consultan, buscan, agregan, editan y eliminan en SQL Server.
> Documento 06 (Git/GitHub) en curso. Login y roles (documento 07): PENDIENTE.
> Ver [ESTADO_DOCUMENTOS.md](ESTADO_DOCUMENTOS.md).

## Tecnologías (comprobadas en los archivos `.csproj`)

| Elemento | Valor |
|---|---|
| Lenguaje | C# |
| Plataforma | .NET Framework 4.8 |
| Interfaz | Windows Forms |
| Base de datos | SQL Server (proveedor `System.Data.SqlClient`) |
| Solución | `Pfinal_labanderia.slnx` (formato XML de solución) |
| Paquetes NuGet | `System.Data.SqlClient 4.9.1`, `System.Configuration.ConfigurationManager 10.0.12` (Datos) · `FontAwesome.Sharp 6.6.0` (Presentación) |

## Arquitectura por capas

| Capa | Proyecto | Contenido actual |
|---|---|---|
| Entidad | `Entidad` | Una clase por tabla (`Cliente`, `Recepcion`, `Tarifa`, `Usuario`, `Entrega`, `Proceso`, `TipoPrenda`, `Servicio`) y apoyo (`OpcionLista`, `ResumenInicio`, `DatoGrafica`) |
| Datos | `Datos` | `Conexion` y una clase `D...` por módulo, con consultas parametrizadas |
| Negocio | `Negocio` | Una clase `N...` por módulo con las validaciones y reglas |
| Presentación | `Pfinal_labanderia` | Formularios: `logoing`, `precentacion`, `inicio`, `clientes`, `usuarios`, `Tarifas`, `Recepciones`, `Entregas`, `Procesos`, `TiposPrenda`, `Servicios` |

Referencias entre proyectos (tal como están hoy):

```
Presentación (Pfinal_labanderia) ──► Negocio, Datos, Entidad
Negocio ──► Datos, Entidad
Datos   ──► Entidad
```

## Estructura de carpetas

```
Pfinal_labanderia\
├─ README.md               Este archivo
├─ AGENTS.md               Reglas de trabajo para asistentes de IA
├─ MEMORY.md               Hechos comprobados del proyecto
├─ ESTADO_DOCUMENTOS.md    Estado de los documentos 01 a 11
├─ .gitignore
├─ skills\                 Guías paso a paso (carpeta plana, 11 archivos .md)
├─ database\               Conexión y scripts SQL (carpeta plana)
├─ docs\                   Documentación de apoyo (carpeta plana)
└─ src\
   └─ Pfinal_labanderia\         Solución del sistema (NombreSistema)
      ├─ Pfinal_labanderia.slnx
      ├─ Entidad\  Datos\  Negocio\
      ├─ Pfinal_labanderia\      Presentación (formularios, App.config y Conexion.config.ejemplo)
      └─ packages\               Paquetes NuGet (no se suben; Visual Studio los restaura)
```

## Cómo clonar y abrir el proyecto

Requisitos: Git, Visual Studio con soporte para .NET Framework 4.8 y archivos `.slnx`, y SQL Server con la base
`BD_LavanderiaGT`.

1. Clonar (en CMD):
   ```
   git clone https://github.com/cpradoc2/Lavanderia-GT-final_progra2.git
   ```
2. Crear el archivo de conexión. **No viene en el repositorio** porque lleva la contraseña de SQL Server:
   ```
   cd Lavanderia-GT-final_progra2\src\Pfinal_labanderia\Pfinal_labanderia
   copy Conexion.config.ejemplo Conexion.config
   notepad Conexion.config
   ```
   Cambiar el servidor, el usuario y `ESCRIBE_AQUI_TU_CONTRASENA` por los datos de tu SQL Server y guardar.
   `Conexion.config` está en `.gitignore`: nunca se sube a GitHub.
3. Abrir `src\Pfinal_labanderia\Pfinal_labanderia.slnx` con Visual Studio y compilar. Visual Studio descarga
   los paquetes NuGet la primera vez.

Si al iniciar el programa aparece "Problema con la configuración de la conexión", falta `Conexion.config` (paso 2).

## Trabajo en equipo con Git

```
git pull                         Traer los cambios del compañero antes de empezar
git status                       Ver qué archivos cambiaron
git add .                        Preparar los cambios
git commit -m "Qué se hizo"      Guardar los cambios con un mensaje claro
git push                         Subir los cambios a GitHub
```

Para poder hacer `git push`, el dueño del repositorio debe agregar al compañero como colaborador
(GitHub → Settings → Collaborators → Add people).

## Orden de trabajo

1. 01 Inspección inicial
2. 02 Conexión a SQL Server
3. 03 a 05 CRUD (simple, relacional, maestro-detalle)
4. 06 Git y GitHub colaborativo (después de los CRUD)
5. 07 Login y roles (al final)
6. 08 Panel de navegación · 09 Dashboard · 10 Revisión · 11 Publicación

## Documentación

- [AGENTS.md](AGENTS.md) — reglas obligatorias
- [ESTADO_DOCUMENTOS.md](ESTADO_DOCUMENTOS.md) — qué está activo o bloqueado
- [MEMORY.md](MEMORY.md) — hechos comprobados
- [docs/COMANDOS_RAPIDOS.md](docs/COMANDOS_RAPIDOS.md) — comandos CMD
- [database/CONEXION_DATABASE.md](database/CONEXION_DATABASE.md) — estado de la conexión
