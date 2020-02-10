Create DataBase ParcialDb1
go

use ParcialDb1
go

create table Articulo
(
ProductoId int primary key identity,
Descripcion varchar(100),
Existencia int,
Costo decimal,
ValorInventario decimal,
);