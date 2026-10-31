# Skill 01 — Inspección inicial

> **Estado: COMPLETADO** · Documento 01.

## Objetivo

Conocer el estado **real** del proyecto antes de programar: qué carpetas, proyectos,
formularios, paquetes y configuración existen. En este paso **no se programa nada**
y no se modifica ningún archivo existente.

## Reglas de este skill

- Usar **CMD** (`cmd.exe`). Si se trabaja desde otra terminal: `cmd.exe /c "comando"`.
- Solo lectura: `dir`, `tree`, `type`, `findstr`, `if exist`.
- No borrar ni mover nada. No programar CRUD.
- Anotar en `MEMORY.md` solo lo comprobado.

## Pasos

Los pasos 1, 2, 8, 9 y 10 se ejecutan desde la carpeta raíz del proyecto.
Los pasos 3 a 7 se ejecutan dentro de la solución: `cd src\Pfinal_labanderia`.

### 1. Comprobar que CMD funciona

```bat
ver
echo %COMSPEC%
```

Resultado esperado: versión de Windows y `C:\Windows\system32\cmd.exe`.

### 2. Ruta actual y contenido

```bat
cd
dir /a /b
```

`/a` muestra también las carpetas ocultas, como `.vs`.

### 3. Ver la solución y sus proyectos

```bat
type Pfinal_labanderia.slnx
```

### 4. Listar los archivos de los proyectos (sin `bin` ni `obj`)

```bat
dir /a /s /b Entidad Datos Negocio Pfinal_labanderia | findstr /v /i /l /c:"\bin\" /c:"\obj\"
```

`findstr /v` oculta las líneas que contienen `\bin\` u `\obj\` (archivos compilados).

### 5. Versión de .NET Framework y referencias entre proyectos

```bat
findstr /s /i "TargetFrameworkVersion ProjectReference" *.csproj
```

### 6. Paquetes NuGet

```bat
type Datos\packages.config
type Pfinal_labanderia\packages.config
dir /b packages
```

### 7. Cadena de conexión

```bat
findstr /i "connectionString" Pfinal_labanderia\App.config
```

> Cuidado: la salida puede mostrar la contraseña. No la copies en documentos ni capturas.

### 8. ¿Es repositorio Git?

```bat
if exist .git (echo Es repositorio Git) else (echo No es repositorio Git)
```

### 9. Crear la estructura documental (solo con autorización)

```bat
mkdir skills database docs src
```

Después se crean los archivos `.md`, `.gitignore` y la plantilla SQL.
`skills\`, `database\` y `docs\` quedan **sin subcarpetas**.

Si la solución está en la raíz, se mueve a `src\NombreSistema\` (solo con autorización).
Primero hay que **cerrar Visual Studio** y comprobarlo:

```bat
tasklist | findstr /i devenv
mkdir src\Pfinal_labanderia
move Pfinal_labanderia.slnx src\Pfinal_labanderia\
move packages src\Pfinal_labanderia\
move Entidad src\Pfinal_labanderia\
move Datos src\Pfinal_labanderia\
move Negocio src\Pfinal_labanderia\
move Pfinal_labanderia src\Pfinal_labanderia\
attrib -h .vs
move .vs src\Pfinal_labanderia\
attrib +h src\Pfinal_labanderia\.vs
```

`move` no encuentra carpetas ocultas; por eso se quita el atributo oculto a `.vs`
antes de moverla y se le vuelve a poner después.

### 10. Verificar el árbol creado

```bat
dir /a /b
dir /a /b src\Pfinal_labanderia
tree /f skills
tree /f database
tree /f docs
tree /f src
```

## Lista de verificación

- [x] CMD funciona.
- [x] Se conocen los proyectos y su versión de .NET Framework.
- [x] Se conocen los formularios existentes (no se modifican).
- [x] Se revisó la cadena de conexión (sin mostrar credenciales).
- [x] Existen `README.md`, `AGENTS.md`, `MEMORY.md`, `ESTADO_DOCUMENTOS.md`, `.gitignore`.
- [x] Existen `skills\`, `database\`, `docs\` y `src\`.
- [x] La solución está en `src\Pfinal_labanderia\` y se confirmó que compila en Visual Studio.
- [x] El estudiante confirmó el árbol real.

## Resultado de la inspección (2026-10-15)

Detalle completo en [MEMORY.md](../MEMORY.md). Resumen:

| Aspecto | Encontrado |
|---|---|
| Solución | `Pfinal_labanderia.slnx`, estaba en la raíz; movida a `src\Pfinal_labanderia\` |
| Framework | .NET Framework 4.8 (los 4 proyectos) |
| Entidad / Datos / Negocio | Sin clases (solo `AssemblyInfo.cs`) |
| Formularios | `logoing` (inicial), `precentacion`, `clientes`, `usuarios`, `Tarifas`, `Recepciones` |
| Conexión | `ConexionSQLServer` → base `Db_ParqueoAutosUmg` (revisar en el documento 02) |
| Git | No es repositorio |

## Criterio de cierre

El documento 01 se cierra cuando el estudiante **confirma el árbol real** de carpetas.
Hasta entonces no se avanza a SQL Server (documento 02).
