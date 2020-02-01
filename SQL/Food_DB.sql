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