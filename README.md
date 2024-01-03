# Informacijski sistem *eMajskeIgre*
**Avtorja**: *Miha Lazić (63210183), Matija Bajt (63210017)*

**Opis domene**: Z informacijskim sistemom *eMajskeIgre* bomo podprli procese prijav na največjem študentskem dogodku Majskih igrah. V sklopu le-tega se vsako leto prirejajo tekmovanja, ki študentskim domovom prinašajo točke glede na uvrstitve njihovih študentov. Do sedaj so se študenti morali fizično prijaviti na tekmovanja, naš sistem bo pa to digitaliziral. Omogočal bo prijavo kot ‘študent’ ali ‘organizator’, pri čemer bo študentu na voljo pregled vseh razpisanih tekmovanj in prijavo oz. odjavo na le-te, organizator pa bo lahko dogodke dodajal, urejal, brisal in imel evidenco o številu prijavljenih študentov za posamezen študentski dom. S tem bomo študentu olajšali samo prijavo na tekmovanja, organizator pa bo imel informacijo, ali naj tekmovanje sploh izvede. Možnost za izboljšavo je hramba točk, ki jih za neko tekmovanje prinese neki študent za neki študentski dom (s tem imamo npr pregled nad najboljšimi tekmovalci).

**Opis (trenutne) aplikacije**: Informacijski sitem *eMajskeIgre* je aplikacija realizirana v **ASP.NET MVC** ogrodju in omogoča organizatorju *bob@example.com* dodajanje, brisanje in urejanje podatkov 4 sestavnih delov tekmovanja v podatkovno bazo **EntityFramework**. To so:
- *Študentski domovi* (Naziv, Hišnikov telefon)
- *Študenti* (Ime, Primek, Datum rojstva, Število točk, Študentski dom)
- *Prijave* (Čas prijave, Dogodek, Študent)
- *Dogodki* (Naziv, Opis, Čas začetka, Prvo mesto, Drugo mesto, Tretje mesto)
  
Navaden uporabnik (študent) ima začasno vse funkcionalnosti zaklenjene, saj potrebuje personaliziran pogled.
