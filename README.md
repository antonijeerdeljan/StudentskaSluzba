# StudentskaSluzba
Predmetni projekat iz predmeta OISISI

Dodatne funkcionalnosti

Login referenta i studenta:
Korisnik sistema može da se prijavi na svoj nalog pomoću odgovarajućeg korisničkog imena i lozinke.

Registracija referenta:
Referent se može registrovati na sistem tako što će popuniti formular za registraciju uz proveru dostupnosti email adrese.

Registracija studenta (pri kreiranju studenta default sifra je broj indeksa):
Student se može registrovati na sistem tako što se popuni forma za dodavanje studenta. Lozinka za studenta se automatski generiše kao njegov broj indeksa.

Forget password za studenta i referenta, token za izmenu sifre je poslat na mail adresu unetu prilikom kreiranja entiteta. Ukoliko sistem detektuje da se korisnik loguje sa tokenom automatski trazi unos nove sifre. Ukoliko se entitet loguje sa regularnom sifrom a zatrazio je token za povratak sifre, pri prvom logovanju sa starom sifrom brise se mogucnost za logovanje sa tokenom:

Dodat StudentView:
Prilikom logovanja student moze pregledati svoj profil, svoje polozene i nepolozene ispite 

Dodat Profile tab ReferentView:
Dodat Profile tab gde referent moze videti podatke o svom profilu i izlogovati se sa sistema.

Change password za studenta u referenta:
Korisnici sistema (studenti i referenti) imaju mogućnost da promene svoje lozinke nakon prijave na svoj nalog. Opcija za promenu lozinke će biti dostupna u okviru korisničkog profila. 

Sve sifre su hesirane uz pomoc BCrypt biblioteke.
