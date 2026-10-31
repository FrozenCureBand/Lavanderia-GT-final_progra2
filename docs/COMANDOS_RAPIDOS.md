# COMANDOS_RAPIDOS.md — Comandos CMD

## Regla del proyecto

> En Windows se usa **CMD (`cmd.exe`)**. **No usar PowerShell si CMD está disponible.**
> Si CMD no funciona, detenerse e informar. No decir que se usó CMD si no fue así.

## Abrir CMD

- Teclas `Win + R` → escribir `cmd` → Enter.
- En VS Code: menú de la terminal (`+` ▾) → **Command Prompt**.
- Desde otra terminal:

| Terminal | Cómo ejecutar en CMD |
|---|---|
| PowerShell | `cmd.exe /c "comando1 && comando2"` (todo entre comillas) |
| Git Bash | `cmd.exe //c "comando"` |

> Comprobado en este proyecto: desde PowerShell, si los `&&` quedan **fuera** de las comillas,
> PowerShell da error y no se ejecuta nada. Si el comando necesita comillas internas
> (rutas con espacios), conviene guardarlo en un archivo `.cmd` y ejecutarlo con
> `cmd.exe /c archivo.cmd`.

## Navegar y ver

| Comando | Qué hace |
|---|---|
| `cd` | Muestra la carpeta actual |
| `cd carpeta` · `cd ..` | Entra a una carpeta · sube un nivel |
| `cd /d D:\ruta` | Cambia de carpeta y de unidad |
| `dir` · `dir /a /b` | Lista el contenido · incluye ocultos, solo nombres |
| `dir /s /b *.cs` | Busca archivos `.cs` en subcarpetas |
| `tree /f carpeta` | Árbol de una carpeta con sus archivos |
| `type archivo.txt` | Muestra el contenido de un archivo |
| `cls` | Limpia la pantalla |

## Crear, copiar y borrar

| Comando | Qué hace |
|---|---|
| `mkdir carpeta` | Crea una carpeta |
| `echo texto> archivo.txt` | Crea o reemplaza un archivo con una línea |
| `echo texto>> archivo.txt` | Agrega una línea al final |
| `copy origen destino` | Copia un archivo |
| `move origen destino` | Mueve o renombra |
| `del archivo.txt` | Borra un archivo |
| `rmdir /s /q carpeta` | Borra una carpeta y su contenido (**cuidado: no se puede deshacer**) |
| `attrib -h carpeta` · `attrib +h carpeta` | Quita · pone el atributo oculto (`move` no encuentra carpetas ocultas como `.vs`) |

## Buscar y comprobar

| Comando | Qué hace |
|---|---|
| `findstr /i "texto" archivo` | Busca texto (sin distinguir mayúsculas) |
| `findstr /s /i "texto" *.csproj` | Busca en todos los `.csproj` de las subcarpetas |
| `if exist archivo (echo Sí) else (echo No)` | Comprueba si existe |
| `where git` | Muestra dónde está instalado un programa |
| `tasklist \| findstr /i devenv` | ¿Visual Studio está abierto? (cerrarlo antes de mover carpetas) |
| `ver` · `echo %COMSPEC%` | Versión de Windows · ruta de CMD |

## Del proyecto

```bat
:: Desde la raíz, entrar a la carpeta de la solución
cd src\Pfinal_labanderia

:: Archivos de los proyectos sin bin ni obj
dir /a /s /b Entidad Datos Negocio Pfinal_labanderia | findstr /v /i /l /c:"\bin\" /c:"\obj\"

:: Versión de .NET Framework de cada proyecto
findstr /s /i "TargetFrameworkVersion" *.csproj

:: Volver a la raíz y ver el árbol de las carpetas documentales
cd ..\..
tree /f skills
tree /f database
tree /f docs
```

## Documento 08 — Panel de navegación

Desde CMD, compilar la solución en Debug. La salida alternativa evita intentar reemplazar DLL que Visual Studio o
una instancia abierta del programa mantenga bloqueadas:

```bat
cd /d C:\2026_ProgramacionII\ProyectoFinal_LavanderiasMultinegocio\src\Lavanderia-GT-final_progra2\src\Pfinal_labanderia
"C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" Pfinal_labanderia.slnx /t:Build /p:Configuration=Debug /p:OutputPath=obj\PanelBuild\ /p:IntermediateOutputPath=obj\PanelBuild\ /m
```

Para revisar el cableado de Click y los destinos del Panel desde la carpeta `src\Pfinal_labanderia`:

```bat
findstr /n /i /c:"Click" /c:"AbrirFormularioEnPanel" Pfinal_labanderia\precentacion.cs Pfinal_labanderia\precentacion.Designer.cs
```

La navegación visual se prueba ejecutando el proyecto en Visual Studio (F5) y pulsando cada opción del menú.

## SQL Server (documento 02, BLOQUEADO)

```bat
sc query MSSQLSERVER
sqlcmd -S localhost,1433 -U sa -Q "SELECT @@VERSION"
```

## Git (documento 06, BLOQUEADO)

Pendiente: se completará al activar el documento 06.

## Equivalencias PowerShell → CMD

| PowerShell (evitar) | CMD (usar) |
|---|---|
| `Get-Location` | `cd` |
| `Get-ChildItem` | `dir` |
| `Get-Content` | `type` |
| `New-Item -ItemType Directory` | `mkdir` |
| `Set-Content` / `Out-File` | `echo texto> archivo` |
| `Copy-Item` · `Move-Item` | `copy` · `move` |
| `Remove-Item` | `del` · `rmdir /s /q` |
| `Select-String` | `findstr` |
| `Test-Path` | `if exist` |
