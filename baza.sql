use hcportal;

CREATE TABLE Razred(
sifra_razreda INT NOT NULL IDENTITY,
naziv NVARCHAR(60),
PRIMARY KEY(sifra_razreda)
);

CREATE TABLE Odeljenje(
sifra_odeljenja INT NOT NULL IDENTITY,
naziv NVARCHAR(60),
sifra_razreda INT NOT NULL,
PRIMARY KEY(sifra_odeljenja),
FOREIGN KEY(sifra_razreda) REFERENCES Razred(sifra_razreda)
);

CREATE TABLE Predmet(
sifra_predmeta INT NOT NULL IDENTITY,
naziv NVARCHAR(60),
PRIMARY KEY(sifra_predmeta)
);

CREATE TABLE Moderator(
sifra_moderatora INT NOT NULL IDENTITY,
ime NVARCHAR(60),
prezime NVARCHAR(60),
korisnicko_ime NVARCHAR(60),
sifra NVARCHAR(250),
datum_rodjenja NVARCHAR(60),
PRIMARY KEY(sifra_moderatora)
);

CREATE TABLE Profesor(
sifra_profesora INT NOT NULL IDENTITY,
ime NVARCHAR(60),
prezime NVARCHAR(60),
korisnicko_ime NVARCHAR(60),
sifra NVARCHAR(250),
datum_rodjenja NVARCHAR(60),
mesto_stanovanja NVARCHAR(60),
jmbg NVARCHAR(60),
PRIMARY KEY(sifra_profesora)
);

CREATE TABLE RazredImaPredmet(
sifra_dodele INT NOT NULL IDENTITY,
sifra_predmeta INT NOT NULL,
sifra_razreda INT NOT NULL,
PRIMARY KEY(sifra_dodele),
FOREIGN KEY(sifra_predmeta) REFERENCES Predmet(sifra_predmeta),
FOREIGN KEY(sifra_razreda) REFERENCES Razred(sifra_razreda)
);

CREATE TABLE Ucenik(
sifra_ucenika INT NOT NULL IDENTITY,
ime NVARCHAR(60),
prezime NVARCHAR(60),
korisnicko_ime NVARCHAR(60),
sifra NVARCHAR(250),
datum_rodjenja NVARCHAR(60),
mesto_stanovanja NVARCHAR(60),
jmbg NVARCHAR(60),
ime_staratelja NVARCHAR(60),
prezime_staratelja NVARCHAR(60),
kontakt_telefon NVARCHAR(50),
sifra_odeljenja INT NOT NULL,
PRIMARY KEY(sifra_ucenika),
FOREIGN KEY(sifra_odeljenja) REFERENCES Odeljenje(sifra_odeljenja)
);

CREATE TABLE UcenikImaOcenu(
sifra_upisa INT NOT NULL IDENTITY,
sifra_ucenika INT NOT NULL,
sifra_predmeta INT NOT NULL,
ocena INT,
polugodiste INT,
opis NVARCHAR(60),
vreme_upisa NVARCHAR(60),
PRIMARY KEY(sifra_upisa),
FOREIGN KEY(sifra_ucenika) REFERENCES Ucenik(sifra_ucenika),
FOREIGN KEY(sifra_predmeta) REFERENCES Predmet(sifra_predmeta)
);

CREATE TABLE ProfesorPredajePredmetOdeljenju(
sifra_profesora INT NOT NULL,
sifra_predmeta INT NOT NULL,
sifra_odeljenja INT NOT NULL,
PRIMARY KEY(sifra_profesora,sifra_predmeta,sifra_odeljenja),
FOREIGN KEY(sifra_profesora) REFERENCES Profesor(sifra_profesora),
FOREIGN KEY(sifra_predmeta) REFERENCES Predmet(sifra_predmeta),
FOREIGN KEY(sifra_odeljenja) REFERENCES Odeljenje(sifra_odeljenja)
);