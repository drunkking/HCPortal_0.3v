USE [hcportal]
GO
SET IDENTITY_INSERT [dbo].[Razred] ON 

INSERT [dbo].[Razred] ([sifra_razreda], [naziv]) VALUES (1, N'Prvi')
INSERT [dbo].[Razred] ([sifra_razreda], [naziv]) VALUES (2, N'Drugi')
INSERT [dbo].[Razred] ([sifra_razreda], [naziv]) VALUES (3, N'Treci')
INSERT [dbo].[Razred] ([sifra_razreda], [naziv]) VALUES (4, N'Cetvrti')
SET IDENTITY_INSERT [dbo].[Razred] OFF
SET IDENTITY_INSERT [dbo].[Odeljenje] ON 

INSERT [dbo].[Odeljenje] ([sifra_odeljenja], [naziv], [sifra_razreda]) VALUES (1, N'I-2', 1)
INSERT [dbo].[Odeljenje] ([sifra_odeljenja], [naziv], [sifra_razreda]) VALUES (2, N'I-55', 1)
INSERT [dbo].[Odeljenje] ([sifra_odeljenja], [naziv], [sifra_razreda]) VALUES (3, N'II-2', 2)
INSERT [dbo].[Odeljenje] ([sifra_odeljenja], [naziv], [sifra_razreda]) VALUES (4, N'III-9', 3)
INSERT [dbo].[Odeljenje] ([sifra_odeljenja], [naziv], [sifra_razreda]) VALUES (5, N'II-265', 2)
SET IDENTITY_INSERT [dbo].[Odeljenje] OFF
SET IDENTITY_INSERT [dbo].[Predmet] ON 

INSERT [dbo].[Predmet] ([sifra_predmeta], [naziv]) VALUES (2, N'Muzicko')
INSERT [dbo].[Predmet] ([sifra_predmeta], [naziv]) VALUES (3, N'Programiranje')
INSERT [dbo].[Predmet] ([sifra_predmeta], [naziv]) VALUES (4, N'OET')
INSERT [dbo].[Predmet] ([sifra_predmeta], [naziv]) VALUES (5, N'Digitalna Elektronika')
INSERT [dbo].[Predmet] ([sifra_predmeta], [naziv]) VALUES (6, N'Engleski jezik')
INSERT [dbo].[Predmet] ([sifra_predmeta], [naziv]) VALUES (7, N'Srpski jezik i knjizevnost')
SET IDENTITY_INSERT [dbo].[Predmet] OFF
SET IDENTITY_INSERT [dbo].[RazredImaPredmet] ON 

INSERT [dbo].[RazredImaPredmet] ([sifra_dodele], [sifra_predmeta], [sifra_razreda]) VALUES (12, 2, 2)
INSERT [dbo].[RazredImaPredmet] ([sifra_dodele], [sifra_predmeta], [sifra_razreda]) VALUES (13, 2, 3)
INSERT [dbo].[RazredImaPredmet] ([sifra_dodele], [sifra_predmeta], [sifra_razreda]) VALUES (14, 2, 4)
INSERT [dbo].[RazredImaPredmet] ([sifra_dodele], [sifra_predmeta], [sifra_razreda]) VALUES (15, 4, 1)
INSERT [dbo].[RazredImaPredmet] ([sifra_dodele], [sifra_predmeta], [sifra_razreda]) VALUES (16, 4, 2)
INSERT [dbo].[RazredImaPredmet] ([sifra_dodele], [sifra_predmeta], [sifra_razreda]) VALUES (17, 5, 3)
INSERT [dbo].[RazredImaPredmet] ([sifra_dodele], [sifra_predmeta], [sifra_razreda]) VALUES (18, 6, 1)
INSERT [dbo].[RazredImaPredmet] ([sifra_dodele], [sifra_predmeta], [sifra_razreda]) VALUES (19, 6, 2)
INSERT [dbo].[RazredImaPredmet] ([sifra_dodele], [sifra_predmeta], [sifra_razreda]) VALUES (20, 6, 3)
INSERT [dbo].[RazredImaPredmet] ([sifra_dodele], [sifra_predmeta], [sifra_razreda]) VALUES (21, 6, 4)
INSERT [dbo].[RazredImaPredmet] ([sifra_dodele], [sifra_predmeta], [sifra_razreda]) VALUES (22, 7, 1)
INSERT [dbo].[RazredImaPredmet] ([sifra_dodele], [sifra_predmeta], [sifra_razreda]) VALUES (23, 7, 2)
INSERT [dbo].[RazredImaPredmet] ([sifra_dodele], [sifra_predmeta], [sifra_razreda]) VALUES (24, 7, 3)
INSERT [dbo].[RazredImaPredmet] ([sifra_dodele], [sifra_predmeta], [sifra_razreda]) VALUES (25, 7, 4)
INSERT [dbo].[RazredImaPredmet] ([sifra_dodele], [sifra_predmeta], [sifra_razreda]) VALUES (26, 3, 2)
INSERT [dbo].[RazredImaPredmet] ([sifra_dodele], [sifra_predmeta], [sifra_razreda]) VALUES (27, 3, 3)
INSERT [dbo].[RazredImaPredmet] ([sifra_dodele], [sifra_predmeta], [sifra_razreda]) VALUES (28, 3, 4)
SET IDENTITY_INSERT [dbo].[RazredImaPredmet] OFF
SET IDENTITY_INSERT [dbo].[Ucenik] ON 

INSERT [dbo].[Ucenik] ([sifra_ucenika], [ime], [prezime], [korisnicko_ime], [sifra], [datum_rodjenja], [mesto_stanovanja], [jmbg], [ime_staratelja], [prezime_staratelja], [kontakt_telefon], [sifra_odeljenja]) VALUES (1, N'Pinokio', N'Pinokio', N'mare123', N'mare123', N'4/3/1998', N'Novi Beograd ', N'Novi Beograd ', N'Djepeto', N'Djepeto', N'2158798756', 3)
INSERT [dbo].[Ucenik] ([sifra_ucenika], [ime], [prezime], [korisnicko_ime], [sifra], [datum_rodjenja], [mesto_stanovanja], [jmbg], [ime_staratelja], [prezime_staratelja], [kontakt_telefon], [sifra_odeljenja]) VALUES (2, N'UcenikIme2', N'UcenikPrezime2', N'joca123', N'mZzsqlGoMw13/lZwXGPcW1tPgd1AfcDm6ReshB5g9mdV4s4CdwxL3TPlAf0qpQeyJQxVPIouFdFZPAx1zzegcA==', N'9/8/1997', N'Dubai', N'121156874', N'ImeStaratelja23', N'PrezimeStaratelja1026', N'2323423', 4)
INSERT [dbo].[Ucenik] ([sifra_ucenika], [ime], [prezime], [korisnicko_ime], [sifra], [datum_rodjenja], [mesto_stanovanja], [jmbg], [ime_staratelja], [prezime_staratelja], [kontakt_telefon], [sifra_odeljenja]) VALUES (3, N'Dambo', N'Slon', N'IGOR123', N'FkZJt9AERyl9nicYzPci25EIuLCGhRQs3tP8TEMDXO+pND8KAM7ZdlYeQkao2xKHtUyHDYmf//ZraJvk1dBCMw==', N'9/8/1997', N'Kina', N'6654532643511', N'Limeni1', N'Limeni2', N'3698459879', 1)
INSERT [dbo].[Ucenik] ([sifra_ucenika], [ime], [prezime], [korisnicko_ime], [sifra], [datum_rodjenja], [mesto_stanovanja], [jmbg], [ime_staratelja], [prezime_staratelja], [kontakt_telefon], [sifra_odeljenja]) VALUES (4, N'UcenikIme', N'UcenikPrezime', N'test123', N'r3kVFvktp1TNzd9aG7cNnaMCwSTvHCUIfzErxvBMQV/9jXwWssyZBpdSJWfAiKK6PjqjEEZQQ7CufzXUGuTjkg==', N'8/1/1256', N'Zemlja dembelija 52z', N'1236987502316', N'Tehno', N'Viking', N'2369878532', 2)
SET IDENTITY_INSERT [dbo].[Ucenik] OFF
SET IDENTITY_INSERT [dbo].[Profesor] ON 

INSERT [dbo].[Profesor] ([sifra_profesora], [ime], [prezime], [korisnicko_ime], [sifra], [datum_rodjenja], [mesto_stanovanja], [jmbg]) VALUES (1, N'Petar', N'Ristic', NULL, NULL, N'1/11/1492', N'Zemlja dembelija 23a', N'3214569871250')
INSERT [dbo].[Profesor] ([sifra_profesora], [ime], [prezime], [korisnicko_ime], [sifra], [datum_rodjenja], [mesto_stanovanja], [jmbg]) VALUES (2, N'Skabo', N'Skabo', NULL, NULL, N'23/1/1792', N'Novi Beograd', N'2314598756321')
INSERT [dbo].[Profesor] ([sifra_profesora], [ime], [prezime], [korisnicko_ime], [sifra], [datum_rodjenja], [mesto_stanovanja], [jmbg]) VALUES (3, N'Ajs', N'Nigrutin', NULL, NULL, N'12/6/1603', N'Leva obala', N'3269875459872')
SET IDENTITY_INSERT [dbo].[Profesor] OFF
SET IDENTITY_INSERT [dbo].[UcenikImaOcenu] ON 

INSERT [dbo].[UcenikImaOcenu] ([sifra_upisa], [sifra_ucenika], [sifra_predmeta], [ocena], [polugodiste], [opis], [vreme_upisa]) VALUES (1, 1, 3, 4, 2, N'Usmeno odgovaranje', N'3/7/2020 12:26:32 PM')
INSERT [dbo].[UcenikImaOcenu] ([sifra_upisa], [sifra_ucenika], [sifra_predmeta], [ocena], [polugodiste], [opis], [vreme_upisa]) VALUES (2, 1, 3, 5, 1, N'Aktivnost na nastavi', N'3/7/2020 12:26:37 PM')
INSERT [dbo].[UcenikImaOcenu] ([sifra_upisa], [sifra_ucenika], [sifra_predmeta], [ocena], [polugodiste], [opis], [vreme_upisa]) VALUES (3, 1, 3, 5, 1, N'Pismeni zadatak', N'3/7/2020 12:26:47 PM')
INSERT [dbo].[UcenikImaOcenu] ([sifra_upisa], [sifra_ucenika], [sifra_predmeta], [ocena], [polugodiste], [opis], [vreme_upisa]) VALUES (4, 2, 3, 4, 2, N'Usmeno odgovaranje', N'3/8/2020 11:23:55 AM')
INSERT [dbo].[UcenikImaOcenu] ([sifra_upisa], [sifra_ucenika], [sifra_predmeta], [ocena], [polugodiste], [opis], [vreme_upisa]) VALUES (5, 2, 3, 5, 1, N'Usmeno odgovaranje', N'3/8/2020 11:24:02 AM')
INSERT [dbo].[UcenikImaOcenu] ([sifra_upisa], [sifra_ucenika], [sifra_predmeta], [ocena], [polugodiste], [opis], [vreme_upisa]) VALUES (6, 2, 7, 3, 2, N'Usmeno odgovaranje', N'3/12/2020 1:19:03 AM')
INSERT [dbo].[UcenikImaOcenu] ([sifra_upisa], [sifra_ucenika], [sifra_predmeta], [ocena], [polugodiste], [opis], [vreme_upisa]) VALUES (7, 2, 7, 4, 2, N'Pismeni zadatak', N'3/12/2020 1:19:09 AM')
INSERT [dbo].[UcenikImaOcenu] ([sifra_upisa], [sifra_ucenika], [sifra_predmeta], [ocena], [polugodiste], [opis], [vreme_upisa]) VALUES (8, 2, 7, 5, 1, N'Kontrolni zadatak', N'3/12/2020 1:19:14 AM')
INSERT [dbo].[UcenikImaOcenu] ([sifra_upisa], [sifra_ucenika], [sifra_predmeta], [ocena], [polugodiste], [opis], [vreme_upisa]) VALUES (9, 2, 7, 4, 1, N'Usmeno odgovaranje', N'3/12/2020 1:19:30 AM')
INSERT [dbo].[UcenikImaOcenu] ([sifra_upisa], [sifra_ucenika], [sifra_predmeta], [ocena], [polugodiste], [opis], [vreme_upisa]) VALUES (10, 4, 4, 3, 2, N'Usmeno odgovaranje', N'3/12/2020 1:54:10 AM')
INSERT [dbo].[UcenikImaOcenu] ([sifra_upisa], [sifra_ucenika], [sifra_predmeta], [ocena], [polugodiste], [opis], [vreme_upisa]) VALUES (11, 4, 4, 5, 1, N'Kontrolni zadatak', N'3/12/2020 1:54:17 AM')
INSERT [dbo].[UcenikImaOcenu] ([sifra_upisa], [sifra_ucenika], [sifra_predmeta], [ocena], [polugodiste], [opis], [vreme_upisa]) VALUES (12, 4, 4, 5, 1, N'Pismeni zadatak', N'3/12/2020 2:21:59 AM')
INSERT [dbo].[UcenikImaOcenu] ([sifra_upisa], [sifra_ucenika], [sifra_predmeta], [ocena], [polugodiste], [opis], [vreme_upisa]) VALUES (13, 4, 4, 4, 2, N'Kontrolni zadatak', N'3/12/2020 2:25:30 AM')
SET IDENTITY_INSERT [dbo].[UcenikImaOcenu] OFF
SET IDENTITY_INSERT [dbo].[Moderator] ON 

INSERT [dbo].[Moderator] ([sifra_moderatora], [ime], [prezime], [korisnicko_ime], [sifra], [datum_rodjenja]) VALUES (3, N'Dusan', N'Kuburic', N'dusan123', N'HHS0iv6CMYNKMwvaiKxYLLsimy8+69Y0AGCpxJnl2KlI72BQ7pPRnGbfgZwFe5o6RJBhtMlKpYLXUVL9EgOAMg==', N'1/1/1521')
SET IDENTITY_INSERT [dbo].[Moderator] OFF
