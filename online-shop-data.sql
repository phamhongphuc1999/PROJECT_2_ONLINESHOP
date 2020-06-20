﻿use OnlineShop

insert into Customer(Name, Sex, Birthday, Address, Phone, Type, Node, Status)
values (N'customer_1', 'male', '1988-03-04', N'Thanh Hóa', '0000000001','A', NULL, NULL),
       (N'customer_2', 'female', '1989-12-04', N'Nghệ An', '0000000002', 'B', NULL, NULL),
	   (N'customer_3', 'male', '1978-03-19', N'Hà Tĩnh', '0000000003', 'A', NULL, NULL),
	   (N'customer_4', 'male', '1988-03-04', N'Quảng Bình', '0000000004', 'C', NULL, NULL),
	   (N'customer_5', 'male', '1988-03-04', N'Quảng Trị', '0000000005', 'A', NULL, NULL),
	   (N'customer_6', 'male', '1988-03-04', N'Huế', '0000000006', 'D', NULL, NULL),
       (N'customer_7', 'female', '1988-03-04', N'Đà Nẵng', '0000000007', 'B', NULL, NULL),
	   (N'customer_8', 'male', '1988-03-04', N'Hải Dương', '0000000008', 'C', NULL, NULL),
	   (N'customer_9', 'female', '1988-03-04', N'Hà Nội', '0000000009', 'A', NULL, NULL),
	   (N'customer_10', 'male', '1988-03-04', N'Hà Nam', '0000000010', 'B', NULL, NULL),
	   (N'customer_11', 'male', '1988-03-04', N'Bắc Ninh', '0000000011', 'D', NULL, NULL),
       (N'customer_12', 'male', '1988-03-04', N'Hải Dương', '0000000012', 'A', NULL, NULL),
	   (N'customer_13', 'male', '1988-03-04', N'Ninh Bình', '0000000013', 'B',  NULL, NULL),
	   (N'customer_14', 'male', '1988-03-04', N'Thanh Hóa', '0000000014', 'C', NULL, NULL),
	   (N'customer_15', 'male', '1988-03-04', N'Thái Bình', '0000000015', 'A', NULL, NULL),
	   (N'customer_16', 'female', '1988-03-04', N'Tuyên Quang', '0000000016', 'B', NULL, NULL),
       (N'customer_17', 'female', '1988-03-04', N'Cà Mau', '0000000017', 'A', NULL, NULL),
	   (N'customer_18', 'female', '1988-03-04', N'Hà Giang', '0000000018', 'A', NULL, NULL),
	   (N'customer_19', 'female', '1988-03-04', N'Phú Yên', '0000000019', 'B', NULL, NULL),
	   (N'customer_20', 'male', '1988-03-04', N'Hải Dương', '0000000020', 'C', NULL, NULL),
	   (N'customer_21', 'female', '1988-03-04', N'Nghệ An', '0000000021', 'A', NULL, NULL),
       (N'customer_22', 'male', '1988-03-04', N'Hòa Bình', '0000000022', 'A', NULL, NULL),
	   (N'customer_23', 'male', '1988-03-04', N'Hải Dương', '0000000023', 'A', NULL, NULL),
	   (N'customer_24', 'male', '1988-03-04', N'Thanh Hóa', '0000000024', 'B', NULL, NULL),
	   (N'customer_25', 'male', '1988-03-04', N'Kiên Giang', '0000000025', 'C', NULL, NULL),
	   (N'customer_26', 'male', '1988-03-04', N'Hậu Giang', '0000000026', 'C', NULL, NULL),
       (N'customer_27', 'male', '1988-03-04', N'Hải Dương', '0000000027', 'D', NULL, NULL),
	   (N'customer_28', 'female', '1988-03-04', N'Hưng Yên', '0000000028', 'A', NULL, NULL),
	   (N'customer_29', 'female', '1988-03-04', N'Thái Bình', '0000000029', 'A', NULL, NULL),
	   (N'customer_30', 'male', '1988-03-04', N'Hòa Bình', '0000000030', 'B', NULL, NULL),
	   (N'customer_31', 'male', '1988-03-04', N'Quảng Ninh', '0000000031', 'C', NULL, NULL),
       (N'customer_32', 'male', '1988-03-04', N'Lạng Sơn', '0000000032', 'A', NULL, NULL),
	   (N'customer_33', 'female', '1988-03-04', N'Tuyên Quang', '0000000033', 'A', NULL, NULL),
	   (N'customer_34', 'male', '1988-03-04', N'Ninh Bình', '0000000034', 'A', NULL, NULL),
	   (N'customer_35', 'male', '1988-03-04', N'Hải Dương', '0000000035', 'B', NULL, NULL)

insert into Employee(Name, Birthday, Sex, Phone, Address, Username, Password, Position, Node, Image)
values (N'employee_1', '1970-12-04', 'male', '1234567899', N'Hải Dương', 'username1', 'e10adc3949ba59abbe56e057f20f883e', 'manager', NULL, N'/dist/img/user2-160x160.jpg'),
       (N'employee_2', '1970-12-04', 'male', '1234567899', N'Hà Nam', 'username2', 'e10adc3949ba59abbe56e057f20f883e', 'director', NULL, N'/dist/img/user1-128x128.jpg'),
	   (N'employee_3', '1970-12-04', 'male', '1234567899', N'Hà Nội', 'username3', 'e10adc3949ba59abbe56e057f20f883e', 'employee', NULL, N'/dist/img/user2-160x160.jpg'),
	   (N'employee_4', '1970-12-04', 'male', '1234567899', N'Nam Định', 'username4', 'e10adc3949ba59abbe56e057f20f883e', 'employee', NULL, N'/dist/img/user5-128x128.jpg'),
	   (N'employee_5', '1970-12-04', 'male', '1234567899', N'Hòa Bình', 'username5', 'e10adc3949ba59abbe56e057f20f883e', 'employee', NULL, N'/dist/img/user8-128x128.jpg'),
	   (N'employee_6', '1970-12-04', 'male', '1234567899', N'Hòa Bình', 'username6', 'e10adc3949ba59abbe56e057f20f883e', 'employee', NULL, N'/dist/img/user8-128x128.jpg'),
	   (N'employee_7', '1970-12-04', 'male', '1234567899', N'Thái Bình', 'username7', 'e10adc3949ba59abbe56e057f20f883e', 'employee', NULL, N'/dist/img/user1-128x128.jpg'),
	   (N'employee_8', '1970-12-04', 'male', '1234567899', N'Thanh Hóa', 'username8', 'e10adc3949ba59abbe56e057f20f883e', 'employee', NULL, N'/dist/img/user1-128x128.jpg'),
	   (N'employee_9', '1970-12-04', 'male', '1234567899', N'Nghệ An', 'username9', 'e10adc3949ba59abbe56e057f20f883e', 'employee', NULL, N'/dist/img/user5-128x128.jpg'),
	   (N'employee_10', '1970-12-04', 'male', '1234567899', N'Nghệ An', 'username10', 'e10adc3949ba59abbe56e057f20f883e', 'employee', NULL, N'/dist/img/user2-160x160.jpg'),
	   (N'employee_11', '1970-12-04', 'male', '1234567899', N'Hưng Yên', 'username11', 'e10adc3949ba59abbe56e057f20f883e', 'employee', NULL, N'/dist/img/user8-128x128.jpg'),
	   (N'employee_12', '1970-12-04', 'male', '1234567899', N'Hà Tĩnh', 'username12', 'e10adc3949ba59abbe56e057f20f883e', 'employee', NULL, N'/dist/img/user5-128x128.jpg'),
	   (N'employee_13', '1970-12-04', 'male', '1234567899', N'Lạng Sơn', 'username13', 'e10adc3949ba59abbe56e057f20f883e', 'employee', NULL, N'/dist/img/user8-128x128.jpg'),
	   (N'employee_14', '1970-12-04', 'male', '1234567899', N'Hải Dương', 'username14', 'e10adc3949ba59abbe56e057f20f883e', 'employee', NULL, N'/dist/img/user1-128x128.jpg'),
	   (N'employee_15', '1970-12-04', 'male', '1234567899', N'Lào Cai', 'username15', 'e10adc3949ba59abbe56e057f20f883e', 'employee', NULL, N'/dist/img/user5-128x128.jpg'),
	   (N'employee_16', '1970-12-04', 'male', '1234567899', N'Hải Dương', 'username16', 'e10adc3949ba59abbe56e057f20f883e', 'employee', NULL, N'/dist/img/user2-160x160.jpg')

insert into Product(NameProduct, ImportPrice, ExportPrice, Profix, Guarantee, Amount, Sale, Image)
values (N'Product1', 100000, 150000, 10, 10, 1000, 50, N'/dist/img/prod-1.jpg'),
       (N'Product2', 1000000, 160000, 20, 10, 1000, 30, N'/dist/img/prod-2.jpg'),
	   (N'Product3', 350000, 400000, 10, 50, 4000, 0, N'/dist/img/prod-3.jpg'),
	   (N'Product4', 1000000, 2000000, 10, 10, 1000, 50, N'/dist/img/prod-5.jpg'),
	   (N'Product5', 100000, 200000, 10, 10, 1000, 50, N'/dist/img/prod-1.jpg'),
	   (N'Product6', 100000, 200000, 5, 10, 1000, 50, N'/dist/img/prod-2.jpg'),
	   (N'Product7', 100000, 300000, 25, 10, 1000, 50, N'/dist/img/prod-3.jpg'),
	   (N'Product8', 100000, 150000, 3, 10, 1000, 50, N'/dist/img/prod-3.jpg'),
	   (N'Product9', 100000, 200000, 5, 10, 1000, 50, N'/dist/img/prod-3.jpg'),
	   (N'Product10', 100000, 1500000, 30, 10, 1000, 50, N'/dist/img/prod-1.jpg'),
	   (N'Product11', 100000, 200000, 1, 10, 1000, 50, N'/dist/img/prod-2.jpg'),
	   (N'Product12', 105000,200000, 40, 10, 1000, 50, N'/dist/img/prod-3.jpg'),
	   (N'Product13', 1023000, 2000000, 4, 10, 1000, 50, N'/dist/img/prod-4.jpg'),
	   (N'Product14', 100000, 200000, 5, 10, 1000, 50, N'/dist/img/prod-3.jpg'),
	   (N'Product15', 25000000, 3000000, 15, 10, 1000, 50, N'/dist/img/prod-4.jpg'),
	   (N'Product16', 100000, 150000, 20, 10, 1000, 50, N'/dist/img/prod-1.jpg'),
	   (N'Product17', 100000, 200000, 25, 10, 1000, 50, N'/dist/img/prod-3.jpg'),
	   (N'Product18', 100000, 200000, 30, 10, 1000, 50, N'/dist/img/prod-3.jpg'),
	   (N'Product19', 100000, 150000, 15, 10, 1000, 50, N'/dist/img/prod-3.jpg'),
	   (N'Product20', 100000, 160000, 10, 10, 1000, 50, N'/dist/img/prod-3.jpg'),
	   (N'Product21', 100000, 170000, 10, 10, 1000, 50, N'/dist/img/prod-3.jpg'),
	   (N'Product22', 100000, 140000, 1, 10, 1000, 50, N'/dist/img/prod-1.jpg'),
	   (N'Product23', 1000000, 2000000, 10, 10, 1000, 50, N'/dist/img/prod-4.jpg'),
       (N'Product24', 3040000, 4000000, 22, 10, 1000, 30, N'/dist/img/prod-2.jpg'),
	   (N'Product25', 350000, 400000, 11, 50, 4000, 0, N'/dist/img/prod-4.jpg'),
	   (N'Product26', 100000, 200000, 16, 10, 1000, 50, N'/dist/img/prod-3.jpg'),
	   (N'Product27', 100000, 200000, 22, 10, 1000, 50, N'/dist/img/prod-4.jpg'),
	   (N'Product28', 100000, 200000, 21, 10, 1000, 50, N'/dist/img/prod-3.jpg'),
	   (N'Product29', 100000, 180000, 1, 10, 1000, 50, N'/dist/img/prod-5.jpg'),
	   (N'Product30', 100000, 200000, 8, 10, 1000, 50, N'/dist/img/prod-2.jpg'),
	   (N'Product31', 100000, 120000, 10, 10, 1000, 50, N'/dist/img/prod-1.jpg'),
	   (N'Product32', 100000, 200000, 20, 10, 1000, 50, N'/dist/img/prod-3.jpg'),
	   (N'Product33', 100000, 300000, 25, 10, 1000, 50, N'/dist/img/prod-5.jpg'),
	   (N'Product34', 100000, 1000000, 30, 10, 1000, 50, N'/dist/img/prod-2.jpg'),
	   (N'Product35', 100000, 250000, 35, 10, 1000, 50, N'/dist/img/prod-5.jpg'),
	   (N'Product36', 100000, 300000, 40, 10, 1000, 50, N'/dist/img/prod-4.jpg'),
	   (N'Product37', 100000, 250000, 1, 10, 1000, 50, N'/dist/img/prod-5.jpg'),
	   (N'Product38', 100000, 120000, 2, 10, 1000, 50, N'/dist/img/prod-3.jpg'),
	   (N'Product39', 100000, 240000, 10, 10, 1000, 50, N'/dist/img/prod-4.jpg'),
	   (N'Product40', 100000, 130000, 13, 10, 1000, 5, N'/dist/img/prod-5.jpg'),
	   (N'Product41', 100000, 300000, 10, 10, 1000, 10, N'/dist/img/prod-2.jpg'),
	   (N'Product42', 100000, 90000, 4, 10, 1000, 60, N'/dist/img/prod-3.jpg'),
	   (N'Product43', 100000, 100000, 10, 10, 1000, 20, N'/dist/img/prod-2.jpg'),
	   (N'Product44', 2500000, 300000, 10, 10, 1000, 40, N'/dist/img/prod-1.jpg')

insert into Invoice(IdEmployee, IdCustomer, DaySell, Status)
values(1, 3, GETDATE(), 1), (1, 7, '2020-03-21', 1),
	   (1, 20, '2020-04-20', 1), (2, 14, '2020-02-10', 1),
	   (4, 19, GETDATE(), 1), (7, 30, GETDATE(), 1),
	   (1, 3, GETDATE(), 1), (1, 7, '2020-03-21', 1),
	   (1, 21, '2020-04-20', 1), (6, 16, '2020-02-10', 1),
	   (8, 31, GETDATE(), 1), (16, 28, '2020-01-18', 1),
	   (3, 4, GETDATE(), 1), (10, 17, '2020-01-21', 1),
	   (1, 20, '2020-04-20', 1), (2, 14, '2020-02-10', 1),
	   (4, 19, GETDATE(), 1), (7, 30, GETDATE(), 1)

insert into Detail(IdInvoice, IdProduct, Amount, Money)
values(1, 1, 1, NULL),
      (1, 2, 1, NULL),
	  (2, 3, 2, NULL),
	  (2, 4, 3, NULL),
	  (2, 5, 1, NULL),
	  (3, 6, 5, NULL),
	  (3, 1, 6, NULL),
	  (3, 4, 10, NULL)
