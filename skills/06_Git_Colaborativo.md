# Skill 06 — Git y GitHub colaborativo

> Documento 06: **COMPLETADO** por confirmación y autorización definitiva del estudiante (2026-10-30).
> Repositorio: https://github.com/cpradoc2/Lavanderia-GT-final_progra2 (público, rama `main`).

Se trabaja **después de los CRUD (03–05) y antes de Login (07)**.
Reglas aplicables: [AGENTS.md](../AGENTS.md). Hechos comprobados: [MEMORY.md](../MEMORY.md).

## 1. La contraseña nunca se sube

Un repositorio público lo puede leer cualquiera, así que la contraseña de SQL Server no puede estar en él.

| Archivo | ¿Se sube? | Contenido |
|---|---|---|
| `App.config` | Sí | Solo `<connectionStrings configSource="Conexion.config" />` |
| `Conexion.config` | **No** (`.gitignore`) | La cadena real, con la contraseña |
| `Conexion.config.ejemplo` | Sí | La misma cadena con `ESCRIBE_AQUI_TU_CONTRASENA` |

Antes de cada commit se comprueba que la contraseña no esté en lo que se va a subir:

```
git add -A
git grep --cached -c "la_contraseña_real"
```

Si el comando no muestra nada, no hay coincidencias.

## 2. Pasos que se siguieron (comandos CMD)

```
cd /d C:\Users\rephot\Desktop\Pfinal_labanderia
git init -b main
git add -A
git status --short                 Revisar la lista: sin bin\, obj\, .vs\, packages\ ni Conexion.config
git commit -m "Primer commit: ..."
gh repo create Lavanderia-GT-final_progra2 --public --source . --remote origin
git push -u origin main
```

GitHub no acepta espacios en el nombre del repositorio: se usan guiones.

## 3. Cómo clona y trabaja el compañero

Los pasos están en el [README](../README.md), sección "Cómo clonar y abrir el proyecto". En resumen:

1. Clonar en una carpeta de ruta corta (por ejemplo `C:\Proyectos`).
2. Copiar `Conexion.config.ejemplo` como `Conexion.config` y escribir su contraseña.
3. Abrir la solución `.slnx` y compilar.

El estudiante confirma el cierre definitivo del documento. El acceso individual del compañero no se verificó de forma independiente en esta actualización.

## 4. Rutina diaria

```
git pull                         Antes de empezar: traer los cambios del otro
git status                       Ver qué cambió
git add .
git commit -m "Mensaje claro"
git push                         Subir los cambios
```

Consejo: no editen el mismo formulario (`.Designer.cs`) al mismo tiempo; los conflictos en esos archivos son
difíciles de resolver.
