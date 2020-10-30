# MovieRentApp

### Opaske

  - Zadnja 2 mjeseca prolazim kroz ovu knjigu: https://www.amazon.com/Building-Applications-NET-Core-JavaScript/dp/1484253515 pa sam se za razvoj backenda koristio filozofijom i dizajnerskim odlukama iz te knjige te kopirao/prilagodio dobar dio koda koji sam već prije napisao prema knjizi. Repozitorij knjiige: https://github.com/Apress/building-web-apps
  - Radi jednostavnosti i potpuno svjestan da je to karikaturna odluka, pretpostavka je da postoji samo jedna kopija svakog filma u videoteci. Logika posuđivanja je da film bude dostupan samo ako se ne nalazi u DB view-u [MovieRent].[ RentedMoviesView]
  - U normalnim uvjetima bi napisao više komentara u kodu. Radi vremenskog ograničenja sam bio štur na tom području.
  - Potrošio sam najviše vremena na izgradnju backenda u zasebnom class library-u, jer mi je taj dio najbliži pa sam procijenio da ću na taj način u kratkom vremenu uspjeti napraviti nešto opipljivo. Baza podataka je popunjena s nekoliko testnih unosa te je izložena preko djelomično dovršenog REST API-a. API je na brzinu testiran preko Swagger UI i Postman klijenta te se čini da dobro funkcionira. Nisam htio da se u API JSON response-u za filmove i usere dobije i „"rentals": [],“ key-value par, ali nisam stigao to istražiti i popraviti.
  - U frontendu imam najmanje iskustva i za njega bi morao potrošiti dosta vremena na istraživanje pa sam taj dio ostavio za kraj, znajući da ga vjerojatno neću stici dovršiti. 
  - ER dijagram baze podataka: https://lucid.app/invitations/accept/8d654ced-9cad-4e9f-89f7-6a2ab7d8c872
  - Ako je ikome bitno, za razvoj aplikacije sam koristio Visual Studio Code editor.

### TODO:

  - Razviti Exdeption handling i loging kod spremanja promjena u bazu podataka
  - Napisati Unit testove za Web API.
  - Razviti MVC Web aplikaciju prema specifikaciji iz zadatka. Istraziti kako konfigurirati registraciju i autentikaciju Usera.