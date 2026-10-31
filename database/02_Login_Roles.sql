/* Tablas adicionales autorizadas para los tres roles y sus accesos configurables. */
IF OBJECT_ID('dbo.Tbl_Roles', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Tbl_Roles (
        IdRol int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Tbl_Roles PRIMARY KEY,
        NombreRol varchar(50) NOT NULL CONSTRAINT UQ_Tbl_Roles_Nombre UNIQUE,
        Descripcion varchar(150) NULL,
        Estado bit NOT NULL CONSTRAINT DF_Tbl_Roles_Estado DEFAULT (1)
    );
END;

IF COL_LENGTH('dbo.Tbl_Usuarios', 'IdRol') IS NULL
    ALTER TABLE dbo.Tbl_Usuarios ADD IdRol int NULL;

IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_Tbl_Usuarios_Tbl_Roles')
    ALTER TABLE dbo.Tbl_Usuarios ADD CONSTRAINT FK_Tbl_Usuarios_Tbl_Roles
        FOREIGN KEY (IdRol) REFERENCES dbo.Tbl_Roles(IdRol);
GO

IF OBJECT_ID('dbo.Tbl_Accesos', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Tbl_Accesos (
        IdAcceso int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Tbl_Accesos PRIMARY KEY,
        NombreAcceso varchar(60) NOT NULL,
        CodigoMenu varchar(40) NOT NULL CONSTRAINT UQ_Tbl_Accesos_CodigoMenu UNIQUE,
        Estado bit NOT NULL CONSTRAINT DF_Tbl_Accesos_Estado DEFAULT (1)
    );
END;

IF OBJECT_ID('dbo.Tbl_RolesAccesos', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Tbl_RolesAccesos (
        IdRol int NOT NULL,
        IdAcceso int NOT NULL,
        Permitido bit NOT NULL CONSTRAINT DF_Tbl_RolesAccesos_Permitido DEFAULT (0),
        CONSTRAINT PK_Tbl_RolesAccesos PRIMARY KEY (IdRol, IdAcceso),
        CONSTRAINT FK_Tbl_RolesAccesos_Tbl_Roles FOREIGN KEY (IdRol) REFERENCES dbo.Tbl_Roles(IdRol),
        CONSTRAINT FK_Tbl_RolesAccesos_Tbl_Accesos FOREIGN KEY (IdAcceso) REFERENCES dbo.Tbl_Accesos(IdAcceso)
    );
END;

INSERT dbo.Tbl_Roles (NombreRol, Descripcion, Estado)
SELECT v.NombreRol, v.Descripcion, 1
FROM (VALUES ('Administrador','Administra usuarios, roles y todos los módulos.'),
             ('Recepcionista','Gestiona clientes, recepciones y entregas.'),
             ('Operador','Consulta Inicio y gestiona procesos y entregas.')) v(NombreRol, Descripcion)
WHERE NOT EXISTS (SELECT 1 FROM dbo.Tbl_Roles r WHERE r.NombreRol = v.NombreRol);

INSERT dbo.Tbl_Accesos (NombreAcceso, CodigoMenu, Estado)
SELECT v.NombreAcceso, v.CodigoMenu, 1
FROM (VALUES ('Inicio','inicio'), ('Clientes','clientes'), ('Recepciones','recepciones'),
             ('Tarifas','tarifas'), ('Usuarios','usuarios'), ('Entregas','entregas'),
             ('Procesos','procesos'), ('Tipos de prenda','tiposprenda'), ('Servicios','servicios'),
             ('Detalle de recepciones','detalleRecepciones'), ('Estados de proceso','estadosProceso'),
             ('Sucursales','sucursales'), ('Roles','roles')) v(NombreAcceso, CodigoMenu)
WHERE NOT EXISTS (SELECT 1 FROM dbo.Tbl_Accesos a WHERE a.CodigoMenu = v.CodigoMenu);

/* Accesos iniciales de ejemplo: luego se pueden cambiar desde el CRUD de Roles. */
INSERT dbo.Tbl_RolesAccesos (IdRol, IdAcceso, Permitido)
SELECT r.IdRol, a.IdAcceso,
       CASE WHEN r.NombreRol = 'Administrador' THEN 1
            WHEN r.NombreRol = 'Recepcionista' AND a.CodigoMenu IN ('inicio','clientes','recepciones','entregas') THEN 1
            WHEN r.NombreRol = 'Operador' AND a.CodigoMenu IN ('inicio','procesos','entregas') THEN 1
            ELSE 0 END
FROM dbo.Tbl_Roles r CROSS JOIN dbo.Tbl_Accesos a
WHERE NOT EXISTS (SELECT 1 FROM dbo.Tbl_RolesAccesos ra WHERE ra.IdRol=r.IdRol AND ra.IdAcceso=a.IdAcceso);

/* Se asigna el primer usuario existente al rol administrador para habilitar la configuración inicial. */
UPDATE dbo.Tbl_Usuarios
SET IdRol = (SELECT IdRol FROM dbo.Tbl_Roles WHERE NombreRol='Administrador')
WHERE IdRol IS NULL AND IdUsuario = (SELECT MIN(IdUsuario) FROM dbo.Tbl_Usuarios);
