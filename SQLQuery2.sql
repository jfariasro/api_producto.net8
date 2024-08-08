create database dbproducto
go

use dbproducto
go

create table marca(
idmarca int primary key identity(1,1),
nombre varchar(100),
descripcion nvarchar(500)
)
go

create table categoria(
idcategoria int primary key identity(1,1),
nombre varchar(100),
descripcion nvarchar(500)
)
go

create table producto(
idproducto int primary key identity(1,1),
idmarca int references marca(idmarca),
idcategoria int references categoria(idcategoria),
nombre varchar(100),
descripcion nvarchar(500),
cantidad int,
precio decimal(10,2)
)
go