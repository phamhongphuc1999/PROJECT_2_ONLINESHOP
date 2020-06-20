create database OnlineShop
go
use OnlineShop
go

create table Detail(
   Id int IDENTITY(1,1) primary key,
   IdInvoice int not null,
   IdProduct int,
   Amount int not null,
   Money int
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
   Username nvarchar(200),
   Password nvarchar(200),
   Image nvarchar(200),
   Birthday datetime,
   Sex varchar(10),
   Phone varchar(50),
   Address nvarchar(200),
   Position nvarchar(200),
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
   Id int IDENTITY(1, 1) primary key,
   NameProduct nvarchar(200),
   Image nvarchar(200),
   Amount int not null,
   ImportPrice int not null,
   ExportPrice int not null,
   Profix int not null,
   Guarantee int not null,
   Sale int not null
)

create table Statistic(
   NameProduct nvarchar(200),
   Amount int not null
)
