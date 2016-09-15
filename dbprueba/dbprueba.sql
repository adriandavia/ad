create table categoria (
	id bigint primary key auto_increment,
	nombre varchar(50) unique

);

insert into categoria (nombre) values('categoria 1');
insert into categoria (nombre) values('categoria 2');
insert into categoria (nombre) values('categoria 3');
