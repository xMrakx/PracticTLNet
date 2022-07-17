use [CD Shop]

create table CD(
	id_cd int identity(1,1) primary key,
	name nvarchar(50),
	artist nvarchar(50),
	release_date date,
	price money
)

drop table CD

create table Worker(
	id_worker int identity(1,1) primary key,
	name nvarchar(50),
	surename nvarchar(50),
	birthday date,
	phone_number nvarchar(50)
)

create table Purchase(
	id_purchase int identity(1,1) primary key,
	id_cd int references CD(id_cd),
	id_worker int references Worker(id_worker),
	date date,
)
drop table CD
drop table Purchase

insert into CD
	(name, artist, release_date, price)
values
	('Kill Em All', 'Metallica', '25.07.1983', 4),
	('Ride the Lighting', 'Metallica', '27.07.1984', 5),
	('Master of Puppets', 'Metallica', '13.08.1986', 8),
	('...And Justice for All', 'Metallica', '25.09.1988', 6),
	('Black Album', 'Metallica', '13.08.1991', 8),
	('Load', 'Metallica', '04.06.1996', 3),
	('Reload', 'Metallica', '18.11.1997', 3),
	('St. Anger', 'Metallica', '05.06.2003', 1),
	('Death Magnetic', 'Metallica', '12.09.2008', 7),
	('Slipknot', 'Slipknot', '29.07.1999', 6),
	('Lowa', 'Slipknot', '28.08.2001', 5),
	('Vol. 3: The Subliminal Verses', 'Slipknot', '25.05.2004', 5),
	('All Hope id Gone', 'Slipknot', '26.08.2008', 5)

insert into [Worker]
	(name, surename, birthday, phone_number)
values
	('Иван', 'Иванов', '15.03.1991', '+79877325621'),
	('Маша', 'Петрова', '12.05.1993', '+79875785621'),
	('Сергей', 'Егоров', '15.06.1995', '+79877325098')

select * from Worker

insert into [Purchase]
	(id_cd, id_worker, date)
values
	(1, 1, '15.05.2022'),
	(6, 1, '15.05.2022'),
	(3, 1, '15.05.2022'),
	(2, 2, '16.05.2022'),
	(3, 2, '16.05.2022'),
	(4, 2, '16.05.2022'),
	(5, 3, '17.05.2022')
