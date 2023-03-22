create database ItemsDb 
go
use ItemsDb
go
create table Item
(
	Item_Id int identity (100000,1) primary key,
	Item_Name nvarchar (50) not null,
	Item_Type nvarchar (50) not null,
	Item_Colour nvarchar (50) not null,	
)
go
insert into Item values('Sword',	'Rare',			'Orange')
insert into Item values('Bow',		'Common',		'White')
insert into Item values('Knife',	'Uncommon',		'Green')
insert into Item values('Shield',	'Legendary',	'Yellow')
insert into Item values('Sword',	'Epic',			'White')
insert into Item values('Shield',	'Rare',			'Orange')
insert into Item values('Knife',	'Common',		'White')
insert into Item values('Bow',		'Epic',			'Black')
insert into Item values('Pistol',	'Legendary',	'Yellow')
insert into Item values('Bow',		'Common',		'Yellow')
insert into Item values('Sword',	'Common',		'White')
insert into Item values('Pistol',	'Uncommon',		'Green')
insert into Item values('Bow',		'Common',		'White')
insert into Item values('Pistol',	'Epic',			'Black')
insert into Item values('Shield',	'Common',		'White')
go
select * from Item