# Informacijski sistem *eMajskeIgre*
**Avtorja**: *Miha Lazić (63210183), Matija Bajt (63210017)*

**Opis domene**: Z informacijskim sistemom *eMajskeIgre* bomo podprli procese prijav na največjem študentskem dogodku Majskih igrah. V sklopu le-tega se vsako leto prirejajo tekmovanja, ki študentskim domovom prinašajo točke glede na uvrstitve njihovih študentov. Do sedaj so se študenti morali fizično prijaviti na tekmovanja, naš sistem bo pa to digitaliziral. Omogočal bo prijavo kot ‘študent’ ali ‘organizator’, pri čemer bo študentu na voljo pregled vseh razpisanih tekmovanj in prijavo oz. odjavo na le-te, organizator pa bo lahko dogodke dodajal, urejal, brisal in imel evidenco o številu prijavljenih študentov za posamezen študentski dom. S tem bomo študentu olajšali samo prijavo na tekmovanja, organizator pa bo imel informacijo, ali naj tekmovanje sploh izvede. Možnost za izboljšavo je hramba točk, ki jih za neko tekmovanje prinese neki študent za neki študentski dom (s tem imamo npr pregled nad najboljšimi tekmovalci).

**Opis aplikacije**: Informacijski sitem *eMajskeIgre* je aplikacija realizirana v **ASP.NET MVC** ogrodju in omogoča organizatorju *bob@example.com* dodajanje, brisanje in urejanje podatkov 4 sestavnih delov tekmovanja v podatkovno bazo **EntityFramework**. To so:
- *Študentski domovi* (Naziv, Hišnikov telefon)
- *Študenti* (Ime, Primek, Datum rojstva, Število točk, Študentski dom)
- *Prijave* (Čas prijave, Dogodek, Študent,Študentski dom)
- *Dogodki* (Naziv, Opis, Čas začetka, Zmagovalna nagrada, Prvo mesto, Drugo mesto, Tretje mesto, Čas ustvaritve, Čas urejanja, Lastnik)
  
Navaden uporabnik **Študent** se lahko registrira s podatki:
-  *Ime*
-  *Priimek*
-  *Mesto*
-  *Študentski dom*
-  *Datum rojstva*
-  *Gmail*
-  *Geslo*
  
Podatkovna baza je postavljena s pomočjo ```dotnet tool install --global dotnet-ef --version 6.0.22```. Nato smo s pomočjo dotnet codegeneratorja(```dotnet tool install --global dotnet-aspnet-codegenerator --version 6.0.16```), ustvarili controlerje, za prej omenjene tabele in migracije(*dotnet ef migrations add Initial*). Na začetku je bila podatkovna baza lokalno v docker desktopu, povezana z connection Stringom *"EMIContext": "Server=localhost;Database=eMajskeIgre;User Id=sa;Password=yourStrong(!)Password;"*. Nadaljno posodabljanje aplikacije se izvede (*dotnet ef database update*). Za avtentikacijo in avtorizacijo smo aplikacijo razširili z *Microsoft.AspNetCore.Identity* in zgenerirali controlerje za registracijo in prijavo. V tabelo *AspNetRoles* smo dodali vloge uprabnikov: Študent, Organizator, Administrator. Organizator in Administrator imata pravice do vseh funkcij aplikacije medtem ko Študent le do dogodkov in svojih prijav. Za nadzorovanje verzije aplikacije smo ustvarili repozitorij na GitHubu in jo *Pushal* nanj. Za dostop aplikacije v spletu smo aplikacijo vključno z podatkovno bazo objavili v Azure oblaku. Tako je dostopna aplikacija na [linku](https://emajskeigre.azurewebsites.net/). Ker smo potrebovali *API endpoints* smo generirali controlerje (*dotnet aspnet-codegenerator controller -name StudentsApiController -async -api -m web.Models.Student -dc web.Data.EMIContext -outDir Controllers/Api*) in nastavili pot (*/api/v1/<imeTabele>*). S pomočjo Swashbuckle.AspNetCore smo generirala dokumentacijo vseh API controlerjev. Za varnost podatkov je poskrbljeno tako, da je potrebna avtorizacija z API ključem.

**Uporaba aplikacije**

Ob prijavi se mu odklenejo *Dogodki* in *Prijave*. V zavihku Dogodki si lahko študent ogleda nabor dogodkov, ki se bodo odvijali. Za več podrobnosti lahko klikne na dogodek ali pa gumb *Details*. Če mu je dogodek všeč, se nanj prijavi s pritiskom na gumb *Join*. Tako se prijava na dogodek vpiše v relacijo *Prijave*. Če si želi uporabnik ogledati svoje prijave si lahko to ogleda v zavihku *Prijave*. Tam dobi izpisane personalizirane prijave. V primeru, da si je premislil in se želi odjaviti od dogodka lahko pritisne na gumb *delete*.

**Dokumentacija API** : [**API**](https://emajskeigre.azurewebsites.net/swagger/index.html) za entitete *Študent*, *Dogodek* in *Prijave*. Za zaščito podatkov uporabljamo API Key = "SecretKey".

**Podatkovna Baza** : Podatkovno bazo smo posatvili v oblaku Azure. Spodnja slika prikazuje logični model realizirane podatkovne baze brez tabel AspNetCore.Identity z izjemo tabele AspNetUsers, ki smo jo povezali s tabelo Students.
<div>
  <img src="./images/PodatkovnaBaza.png" alt="Podatkovna baza" >
</div><br />

**Razdelitev dela**:
##### Miha Lazič 
Naredil naloge potrebne za prvo seminarsko nalogo:
-  Podatkovne baze s pomočjo EntityFramework
-  Generiranje controllerjev in priprava projekta na nadalno razvijanje
-  Razširitev aplikacije z avtentikacijo  in avtorizacijo
-  Pripravil GitHub repository
  

##### Matija Bajt 
Nadgradil aplikacijo in naredil android aplikacijo v Android Studiu:
-  Postavitev spletne aplikacije v oblaku, Azure
-  Generiranje API controllerjev za tabele Student, Event, Enrollment
-  Dokumentacija Swagger
-  Avtentikacija in avtorizacija vmesnika API z ApiKey="SecretKey"
-  Celotna android aplikacija, ki vsebuje zahtevke GET, POST in DELETE



**Zaslonske slike grafičnega vmesnika**



<div>
  <img src="./images/HomeOrganizator.png" alt="HomeOrganizator" >
  <b> Slika 1:</b> Home View Organizator
  <br>
  <br>
  <br>
</div>



<div>
  <img src="./images/HomeStudent.png" alt="HomeStudent" >
  <b> Slika 2:</b> Home View Student
  <br>
  <br>
  <br>
</div>



<div>
  <img src="./images/EventsOrganizator.png" alt="EventsOrganizator" >
  <b> Slika 3:</b> Events View Organizator
  <br>
  <br>
  <br>
</div>



<div>
  <img src="./images/EventsStudent.png" alt="EventsStudent" >
  <b> Slika 4: Events View Student</b>
  <br>
  <br>
  <br>
</div>



<div>
  <img src="./images/EnrollmentsOrganizator.png" alt="EnrollmentsOrganizator" >
  <b> Slika 5:</b> Enrollments View Organizator
  <br>
  <br>
  <br>
</div>



<div>
  <img src="./images/EnrollmentsStudent.png" alt="EnrollmentsStudent" >
  <b> Slika 6:</b> Enrollments View Student
  <br>
  <br>
  <br>
</div>



<div>
  <img src="./images/DormitoryOrganizator.png" alt="DormitoryOrganizator" >
  <b> Slika 7:</b> Dormitory View Organizator
  <br>
  <br>
  <br>
</div>



<div>
  <img src="./images/StudentsOrganizator.png" alt="StudentsOrganizator" >
  <b> Slika 8:</b> Students View Student
  <br>
</div>


# eMajskeIgre App
Mobilna verzija spletne aplikacije [eMajskeIgre](https://emajskeigre.azurewebsites.net/).

**Opis mobilne aplikacije**: Aplikacija predstavlja mobilno verzijo poenostavljene spletne aplikacije [eMajskeIgre](https://emajskeigre.azurewebsites.net/), ki smo jo realizirali v IDE okolju *Android Studio* s pomočjo API vmesnikov. Njena glavna funkcionalnost je prijava Študenta na posamezen dogodek na Majskih igrah.

**Uporaba mobilne aplikacije**: Ko na zaslonu pritisnemo na gumb *Prikazi dogodke*, se nam prikažejo vsi objavljeni dogodki. S klikom nanj lahko pridobimo dodatne informacije o le-tem (potek, čas začetka in število točk). Prijava na dogodek je možna sklikom na gumb *prijavaNaDogodek*. Študent ima tudi možnost pregleda nad svojimi prijavami s klikom na gumb *Ogled Vpisov*.

<div>
  <img src="./images/Main.jpg" alt="Local Image" width="200">
  <p><b>Slika 1</b>: Home Screen</p>
  <br>
</div>

<div>
  <img src="./images/Dogodki.jpg" alt="Local Image" width="200">
  <p><b>Slika 2</b>: Dogodki</p>
  <br>
</div>

<div>
  <img src="./images/Details.jpg" alt="Local Image" width="200">
  <p><b>Slika 3</b>: Podrobnosti dogodka</p>
  <br>
</div>

<div>
  <img src="./images/Izpisane prijave.jpg" alt="Local Image" width="200">
  <p><b>Slika 4</b>: Vse prijave uporabnika</p>
  <br>
</div>


