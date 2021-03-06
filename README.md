﻿# Tentamen MVC
[![Build status](https://img.shields.io/appveyor/ci/bartlangelaan/tentamen.svg)](https://ci.appveyor.com/project/BartLangelaan/tentamen)
![Aantal punten](https://img.shields.io/badge/punten-95%2F95-green.svg)
![Extra punten](https://img.shields.io/badge/extra_punten-65%2F75-yellow.svg)

Tentamen MVC Hogeschool Rotterdam jaar 2 periode 1.

## Instellingen

Om dit project te maken is Microsoft Visual Studio 2015 Community Edition gebruikt.

Als het project voor het eerst wordt geopend dan wordt de database gereset: er worden categorieën, users, reviews en beoordelingen aangemaakt. Om de database opnieuw te resetten kan gebruik gemaakt worden van de *Reset database* knop onderaan elke pagina. Dit gebeurt ook automatisch als er geen categorieën in de database staan.

Er worden 6 gebruikersaccounts aangemaakt. Dit zijn:
 
- admin
- bob
- chantal
- dieuwertje
- emiel
- stan

Al deze gebruikersnamen hebben als wachtwoord:  `wachtwoord`.



## De opdracht
De complete opdracht is te vinden via volgende link (google docs): https://goo.gl/giwxgN

Hierin vind je:

- Beschrijving van het product
- Wireframes van de verschillende pagina's. Zo zal jouw opdracht ook moeten werken (CSS is niet belangrijk)
- Uitleg per pagina over de eisen en voorwaarden
- Puntenverdeling per pagina

### Punten

- [x] Home, niet ingelogd (10 punten)
- [x] Registreren (10 punten)
- [x] Home, wel ingelogd
  - [x] Lijst met categorieën (5 punten)
  - [x] Laatste 5 reviews (5 punten)
- [x] Reviews
  - [x] Lijst actieve reviews (10 punten)
  - [x] Gemiddelde beoordeling per review (5 punten)
  - [x] Zoeken
    - [x] Filter op categorieën (5 punten)
    - [x] Vrij invoerveld (5 punten)
    - [x] Categorieën + invoerveld (5 punten)
- [x] Review detailpagina
  - [x] Naam, categorie, datum, inhoud, link naar beoordelingen (10 punten)
  - [x] Rekening houden met witruimtes (5 punten)
  - [x] Een beoordeling kunnen geven (5 punten)
  - [x] Niet 2x een beoordeling kunnen geven (5 punten)
- [x] Beoordelingen per review
  - [x] Naam product + lijst waarderingen (10 punten)
  - [x] Naam beoordelaar bij waardering (5 punten)
- [x] Mijn reviews
  - [x] Nieuwe review pas mogelijk na 3 beoordelingen (5 punten)
  - [x] Gemiddelde waardering, totaal aantal waarderingen, naam product, aanmaakdatum, 100 tekens inhoud, link om actief te maken, aanpasknop (10 punten)
  - [x] Link om actief te maken is anders als al actief is (5 putnen)
- [ ] Pas review aan
  - [x] Aanpassen productnaam, categorie, inhoud (5 punten)
  - [ ] Meerdere categorieën mogelijk (5 punten)
- [ ] Nieuwe review
  - [x] Aanpassen productnaam, categorie, inhoud (5 punten)
  - [ ] Meerdere categorieën mogelijk (5 punten)
- [x] Adminpagina
  - [x] Link naar beheer gebruikers, link naar beheer categorieeën, overzicht categorieën + CRUD (15 punten)
  - [x] Gebruiker in andere rol kunnen plaatsen (5 punten)
  - [x] Gebruiker actief/inactief kunnen maken (5 punten)
