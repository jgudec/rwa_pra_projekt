create database Food_DB
COLLATE Croatian_CS_AI_KS_WS
go

use Food_DB
go

create table TipNamirnice
(
	IDTipNamirnice int identity primary key,
	Naziv nvarchar(50),
)
go

create table Namirnica
(
	IDNamirnica int identity primary key,
	Naziv nvarchar(50),
	Kj int,
	Kcal int,
	TipNamirniceID int foreign key references TipNamirnice(IDTipNamirnice)
)
go

create table MjernaJedinica
(
	IDMjernaJedinica int identity primary key,
	Naziv nvarchar(30)
)
go

create table MjernaJedinica_Namirnica
(
	IDMjernaJedinica_Namirnica int identity primary key,
	NamirnicaID int foreign key references Namirnica(IDNamirnica),
	MjJedinicaID int foreign key references MjernaJedinica(IDMjernaJedinica)
)
go

create table Obrok
(
IDObrok int identity primary key,
Naziv nvarchar(50) not null,
Dostupan bit default 1
)
go

create table Obrok_MjernaJedinica_Namirnica
(
IDObrok_MjernaJedinica_Namirnica int identity primary key,
ObrokID int foreign key references Obrok(IDObrok),
MjernaJedinica_NamirnicaID int foreign key references MjernaJedinica_Namirnica(IDMjernaJedinica_Namirnica)
)
go

create table Korisnik
(
IDKorisnik int identity primary key,
KorisnickoIme nvarchar(25),
Pwd nvarchar(25),
Ime nvarchar(50),
Prezime nvarchar(50),
Email nvarchar(25),
DOB date,
Spol nvarchar(25),
TipDijabetesa int,
FizickaAktivnost int,
Visina int,
Tezina int,
BMI decimal,
Registriran bit
)
go

create table Jelovnik
(
IDJelovnik int identity primary key,
KorisnikID int foreign key references Korisnik(IDKorisnik),
DatumOd date,
DatumDo date
)
go

create table Jelovnik_Obrok_MjernaJedinica_Namirnica
(
IDJelovnik_Obrok_MjernaJedinica_Namirnica int identity primary key,
JelovnikID int foreign key references Jelovnik(IDJelovnik),
Obrok_MjernaJedinica int foreign key references Obrok_MjernaJedinica_Namirnica(IDObrok_MjernaJedinica_Namirnica)
)
go

create table Kombinacija
(
	IDKombinacija int primary key identity,
	BrojObroka int,
	Od date,
	Do date,
	)
go

create table Omjer
(
	IDOmjer int primary key identity,
	ObrokID int foreign key references Obrok(IDObrok),
	Masti int,
	Ugljikohidrati int,
	Bjelancevine int,
	PostotakUk int,
	KombinacijaID int foreign key references Kombinacija(IDKombinacija)
)
go

insert into Korisnik(KorisnickoIme,Pwd) values('admin','admin')
go

create proc ValidateAdmin
 @user nvarchar(256), @pass nvarchar(max)
as
begin
	if exists(select * from Korisnik where KorisnickoIme='admin'
				and Pwd = @pass) and @user = 'admin'
		begin
			select 1
		end
	else
		begin
			select 0
		end

end
go

--AdminSite: User screens

insert into Korisnik(KorisnickoIme,Pwd,Ime,Prezime,Email,DOB,Spol,TipDijabetesa,FizickaAktivnost,Visina,Tezina,BMI) values('GlenCoco','qwertz1234','Pero','Periæ','pero.peric@gmail.com','1999-08-15','M',1,2,182,85,25)
go

create proc LoadKorisnici
		as
SELECT * from Korisnik
go

--AdminSite: Meal screens

create proc LoadObroci
as
SELECT * from Obrok
go

create proc InsertObrok
@naz nvarchar(25)
as
insert into Obrok(Naziv) values(@naz)
go

create proc ToggleObrok
@idObrok int,
@stat int
as
update Obrok set Dostupan=@stat where IDObrok=@idObrok
go

create proc UpdateObrok
@naz nvarchar(25),
@idobrok int
as
update Obrok set Naziv=@naz where IDObrok=@idobrok
go

create proc DeleteObrok
@idobrok int
as
delete from Obrok where IDObrok=@idobrok
go

insert into Obrok(Naziv) values('Dorucak')
go

--AdminSite: Ingredient screens

insert into TipNamirnice(Naziv) values('Mast')
insert into TipNamirnice(Naziv) values('Ugljikohidrat')
insert into TipNamirnice(Naziv) values('Protein')
go

insert into Namirnica(Naziv,TipNamirniceID) values('pileca prsa',3)
go

create proc LoadNamirnice
as
select * from Namirnica
go

create proc LoadTipoviNamirnica
as
select * from TipNamirnice
go

create proc InsertNamirnica
@naz nvarchar(25),
@kj nvarchar(25),
@kcal nvarchar(25),
@tipnamirniceid int
as
insert into Namirnica(Naziv,Kj,Kcal,TipNamirniceID) values(@naz,@kj,@kcal,@tipnamirniceid)
go

create proc UpdateNamirnica
@naz nvarchar(25),
@idnamirnica int,
@kj nvarchar(25),
@kcal nvarchar(25),
@tipnamirniceid int
as
update Namirnica set Naziv=@naz,Kj=@kj,Kcal=@kcal,TipNamirniceID=@tipnamirniceid where IDNamirnica=@idnamirnica
go

create proc DeleteNamirnica
@idnamirnica int
as
delete from Namirnica where IDNamirnica=@idnamirnica
go

--AdminSite: Measurement Unit screens

insert into MjernaJedinica(Naziv) values('gram')
go
insert into MjernaJedinica(Naziv) values('dekagram')
go
insert into MjernaJedinica(Naziv) values('kilogram')
go

create proc LoadMjJedinice
as
SELECT * from MjernaJedinica
go

create proc InsertMjJedinicu
@naz nvarchar(25)
as
insert into MjernaJedinica(Naziv) values(@naz)
go

create proc UpdateMjJedinicu
@naz nvarchar(25),
@idmjjed int
as
update MjernaJedinica set Naziv=@naz where IDMjernaJedinica=@idmjjed
go

create proc DeleteMjJedinicu
@idmjjed int
as
delete from MjernaJedinica where IDMjernaJedinica=@idmjjed
go
