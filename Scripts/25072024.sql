-- Creacion Base de Datos

CREATE DATABASE IntegracionDB;

-- Usando Base de Datos
USE IntegracionDB;

-- Creando Tabla Categoria

CREATE TABLE Categoria(CategoriaId int NOT NULL IDENTITY,
                                                Nombre NVARCHAR(120) NOT NULL,);

-- Relacionando Clave Primaria

ALTER TABLE Categoria ADD CONSTRAINT PK_Categoria PRIMARY KEY(CategoriaId);

-- Creando Tabla Marca

CREATE TABLE Marca(MarcaId int NOT NULL IDENTITY,
                                        Nombre NVARCHAR(120) NOT NULL,);

-- Relacionando Clave Primaria

ALTER TABLE Marca ADD CONSTRAINT PK_Marca PRIMARY KEY(MarcaId);

-- Creando Tabla Producto

CREATE TABLE Producto(ProductoId int NOT NULL IDENTITY,
                                              NombreProducto NVARCHAR(120) NOT NULL,
                                                                           Precio NUMERIC(7,2) NOT NULL,
                                                                                               Costo NUMERIC(7,2) NOT NULL,
                                                                                                                  CategoriaId INT NOT NULL,
                                                                                                                                  MarcaId INT NOT NULL);

-- Relacionando Clave Primaria

ALTER TABLE Producto ADD CONSTRAINT PK_Producto PRIMARY KEY(ProductoId);

-- Relacionando Clave Foranea con Categoria

ALTER TABLE Producto ADD CONSTRAINT FK_Producto_Categoria_CategoriaId
FOREIGN KEY(CategoriaId) REFERENCES Categoria(CategoriaId) ON
DELETE CASCADE;

-- Relacionando Clave Foranea con Producto

ALTER TABLE Producto ADD CONSTRAINT FK_Producto_Marca_MarcaId
FOREIGN KEY(MarcaId) REFERENCES Marca(MarcaId) ON
DELETE CASCADE;

-- Inserccion de datos en tabla Categoria

INSERT INTO Categoria(Nombre)
VALUES('Computadoras');


INSERT INTO Categoria(Nombre)
VALUES('Impresoras');

-- Inserccion de datos en tabla Marca

INSERT INTO Marca(Nombre)
VALUES('HP');


INSERT INTO Marca(Nombre)
VALUES('Apple');

