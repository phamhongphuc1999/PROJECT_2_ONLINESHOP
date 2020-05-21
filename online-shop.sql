create database OnlineShop
go
use OnlineShop
go

create table Detail(
   Id int IDENTITY(1,1) primary key,
   IdInvoice int not null,
   Amount int not null,
   IdProduct nvarchar(250),
   NameProduct nvarchar(250),
   IdPackage nvarchar(250),
   ImportPrice int,
   ExportPrice int,
   Money int,
   DaySell datetime default getdate()
)

create table Invoice(
   Id int IDENTITY(1, 1) primary key,
   IdEmployee int not null,
   IdCustomer int not null,
   DaySell datetime default getdate(),
   Status bit not null
)

create table Customer(
   Id int IDENTITY(1, 1) primary key,
   Name nvarchar(200) not null,
   Birthday datetime,
   Sex varchar(10) not null,
   Address nvarchar(200),
   Phone varchar(50),
   Type nvarchar(10),
   Node nvarchar(100),
   Status bit
)

create table Employee(
   Id int IDENTITY(1, 1) primary key,
   Name nvarchar(200) not null,
   Birthday datetime,
   Sex varchar(10),
   Phone varchar(50),
   Address nvarchar(200),
   Username nvarchar(200),
   Password nvarchar(200),
   Type nvarchar(200),
   Node nvarchar(100)
)

create table OldEmployee(
   Id int IDENTITY(1, 1) primary key,
   Name nvarchar(200) not null,
   Birthday datetime,
   Sex varchar(10),
   Phone varchar(50),
   Type nvarchar(200),
   DayOff datetime,
   Node nvarchar(100)
)

create table Product(
   Id nvarchar(100) not null,
   IdPackage nvarchar(100) not null,
   NameProduct nvarchar(200),
   ImportPrice int not null,
   Profix int not null,
   Guarantee int not null,
   Amount int not null,
   Sale int not null
   constraint pk_ct primary key(Id, IdPackage)
)

create table Statistic(
   NameProduct nvarchar(200),
   Amount int not null
)
