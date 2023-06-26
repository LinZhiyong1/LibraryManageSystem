# LibraryManageSystem
##  Create table by SqlServer
### Create table sql
CREATE TABLE tb_admin(
	id varchar(20)not null primary key,
	password varchar(20) not null
);

CREATE TABLE tb_book(
	id varchar(20)not null primary key,
	name varchar(20) not null,
	author varchar(20)not null,
	press varchar(20) not null,
	number int not null
);

CREATE TABLE tb_lend(
	no varchar(20)not null primary key,
	uid varchar(20) not null,
	bid varchar(20)not null,
	datetime datetime not null
);

CREATE TABLE tb_user(
	id varchar(20)not null primary key,
	name varchar(20) not null,
	sex char(2)not null,
	password varchar(20) not null
);
