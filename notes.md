# Notes

## Geschiedenis

ASP.NET Core
- bestaat sinds 2016
- bouwt voor op de open-sourceheid van .NET Core (2016)
- wat er verbeterd is t.o.v. het vroegere ASP.NET:
  - cross-platform
  - performance (modulairder)
  - unified API
  - deploybaarheid 
    - Docker
  - ingebakken dependency injection

.NET Framework (grotendeels open source)
- bestaat sinds 2002
- had ASP.NET voor webdev
  - WebForms (vanaf het begin)
  - MVC (wat nu nog steeds het meest lijkt op wat we nu hebben)
  - IIS - webserver


## Paradigmas der webdevelopment

SPA - Single Page Application
- 1 html-file
- alles wordt op de client gedaan
- waarschijnlijk doe je API-calls naar backend
- nadeel: SEO - Search Engine Optimization
- nadeel: initiele laadtijd - veel JavaScript
- wanneer: hoog niveau aan interactie
- hip
- libs/frameworks: React / Angular / Vue / Svelte / Solid / Qwik

SSR - Server-side rendering
- complementair aan een SPA om alsnog betere SEO te hebben
- snellere initiele laadtijd
- bij het initiele bezoek krijgt de browser alvast wat HTML opgestuurd
- "opsturen van interactieve shizzle op de achtergrond" - hydration  streaming hydration partial hydration
- libs/frameworks: Next.js/Remix (React) / @angular/ssr / Nuxt.js / SvelteKit / SolidStart / QwikCity

SSG - Static site generation
- statische HTML
- productcatalogus   `/product/21718743`   `product-2178384.html`
- Next.js / @angular/ssr / Gatsby / Hugo / 11ty

MPA - Multi Page Application
- elke pagina moet geladen worden vanaf de server
- elke navigatie betekent serverinteractie
- wanneer: minder interactie
- nadeel: dat hierboven
- niet hip
- libs/frameworks: heel PHP / Razor Pages / Spring Boot (thymeleaf)

## GET vs POST?

- POST wordt gebruikt om nieuwe entiteit te maken
- GET wordt gebruikt om entiteiten op te halen
- POST heeft een body
- GET heeft geen body, doet alles met querystring - dat wat je in je adresbalk ziet
  ```text
  google.com/?q=hoe kan ik
  overheid.be/inloggen?user=JP&pass=ksd8sd8D*S(*Dasd
  ```

## Onhandige Visual Studio-dingen:

- TagHelper string die niet werd geautocomplete
- Auto imports
- Conditional classes doet soms stom/markeren dat het ongeldige syntax is
- De aparte console-schermpjes
- Runconfiguraties voor meerdere projecten opstarten binnen solution
- Kleurtjes in template vallen opeens weg?! Random reboot fix
- Cursor niet zichtbaar bij extract interface
- Migrations adden geeft build error maar Visual Studio laat niks zien
- Crasht bij project references
- `.csproj` die opeens gekke remove content files enzo bevat

### EF Core-commando's voor wanneer je geen Package Manager Console hebt

```sh
dotnet ef migrations add Initial
dotnet ef database update
```
Meer: https://learn.microsoft.com/en-us/ef/core/cli/dotnet

## Repositories

- pattern
- gebruikt voor data access
  - ook aan de frontend! wegabstractheren of data over HTTP/REST/gRPC/SOAP/WebSocket wordt opgehaald/verwerkt
- eenduidige data access - `IsInactief` meenemen in je queries
- makkelijk switchen tussen datasources
- maakt mocken makkelijk
- heel vaak gepaard met een database

Zetten we in middels dependency injection
- ook een pattern
- van buitenaf bepaal je de implementatie
- een vorm van Inversion of Control (IoC)
- niet meer zelf `new Bla()` doen

## EF Core

- ORM - Object-Relational Mapper
  - JPA / Hibernate / OpenJPA / EclipseLink
- Dapper
- Connectionstrings: https://www.connectionstrings.com/

Vroeger:
```cs
using (var connection = new SqlConnection())
{
	connection.Open();
	using (var command = new SqlCommand(connection))
	{
		command.CommandText = "SELECT * FROM klant;";
		command.CommandType = CommandType.Text;
		using (var reader = command.ExecuteReader())
		{
			while (reader.Next())
			{
				var naam = reader["naam"];
				var datum = DateTime.Parse(reader["date"]);
			}
		}
	}
}
```
```cs
// EF Core
var klanten = context.Klanten.ToList();
```

Benodigde packages:
- `Microsoft.EntityFrameworkCore` voor abstracte classes
  - `DbContext<T>`, `DbSet<T>`
- `Microsoft.EntityFrameworkCore.Tools` voor commando's
  - `Add-Migration Initial`
  - `Script-Migration`
  - `Update-Database`
- een adapter richting jouw DBMS
  - `Microsoft.EntityFrameworkCore.SqlServer`

## `async`

Synchrone I/O hoort eigenlijk niet:

```php
// PHP
mysql_query($query);
```
```java
// Java
em.persist(obj);
```
```cs
// .NET
context.SaveChanges();
```

Een Thread is niet gratis, heeft een stack met al je lokale variabelen, is standaard 1MB
- 15M x 15M threads x 15M 1MB stacks = 15.000GB geheugen

## JP's default lijstje van dingen om op te letten bij schrijven van code

1. leesbaarheid
2. onderhoudbaarheid
3. testbaarheid
4. niet-hackbaarheid
5. dat het werkt
6. performance

## Unittesten

unittests
- hier spreek jij je code aan
- een zo klein mogelijk stukje code aanspreken

integratietests
- interactie tussen verschillende componenten/classes/onderdelen
- verschillende systemen
- database betrekt
- gerenderde HTML
- hier spreek jij je code aan
- API-calls

end-to-end-tests / UI testing
- alle lagen
- database KAN hier nog wel gemockt worden
- hier spreek je NIET je code aan
  - browser geautomatiseerd aan het aansturen

En meer: component A/B testing smoke spec manual (menselijke tester)

Minder waardevolle tests:

- getters/setters/constructors testen
  - diehard logica is interessant om te testen, niet hele basale toekenning-shizzle
    - `if` `while` `for` berekeningen `Math.Max()`
- repositories
  - diehard logica is interessant om te testen
- wanneer je niet zelf je tests schrijft
  - je hoort ze niet te laten schrijven door een collega/stagiair
  - gegeneerde tests
- als jouw project < 6 maanden duurt
  - unittests zijn voor de lange termijn
    >niets is zo permanent als een tijdelijke oplossing

.NET testframeworks:
- MSTest    <== happy path Microsoft
- xUnit
- NUnit

waarom MSTest vroeger wat minder was:
- bij .NET Core 1.0 werkte het niet
- data-driven tests / parameterized tests waren niet tof om op te zetten (zie [`[DataSource(...)]`](https://learn.microsoft.com/en-us/visualstudio/test/how-to-create-a-data-driven-unit-test?view=vs-2022))

Mocking libraries:
- NSubstitute
- Moq
- FakeItEasy

Verschil zit grotendeels in syntax:

```cs
new Mock<I...>();
A.Fake<I...>();
```

Microsoft Fakes: handig voor testen van `static` zaken:
- `File.AppendAllText()`
- `DateTime.Now`

Maar is enkel beschikbaar voor VS Enterprise (ook niet voor Rider)

Verder:
- [FluentAssertions](https://fluentassertions.com/) zijn tof voor leesbaarheid bij de wat complexere assertions (collections, objects).
- Naamgevingsconventies: [interessante discussie op StackOverflow](https://stackoverflow.com/questions/155436/unit-test-naming-best-practices) en [wat Microsoft vindt](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices)

## Routes en querystrings

Dingen verwijderen: GET of POST

```sh
GET index.php?action=delete_customer&id=14
```
```sh
/details/14?sort=make&page=5   <=== zoekmachines vinden deze fijner
/details?id=14
```
```sh
google.be?q=Hoe kan ik...
```
```sh
/index.php?page=contact   <== dit vinden zoekmachines helemaal niks
/index.php?pageId=475874
```

AJAX - Asynchronous JavaScript And JSON

## REST

- REpresentational State Transfer (2000/1)
- representational: het formaat
  - JSON
  - XML
  - ...
  - wordt bepaald met een HTTP-header 
    - wat jij terug wil krijgen: `Accept: text/html; application/json; application/xml; ...`
    - wat jij opstuurt: `Content-Type: ...`

REST is gebaseerd op conventions met:
- HTTP methods/verbs
- statuscodes 

HTTP methods/verbs
- GET    ophalen
- POST   aanmaken                                /vervangen
- PUT    vervangen (de gehele entiteit)          /aanmaken
- PATCH  deel updaten
- DELETE verwijderen

```sh
POST  /api/car  { make: '...', model: '...', ... }
POST  /api/car  { make: '...', model: '...', ... }
POST  /api/car  { make: '...', model: '...', ... }
```
```sh
PUT  /api/car/161  { make: '...', model: '...', ... }
PUT  /api/car/161  { make: '...', model: '...', ... }
PUT  /api/car/161  { make: '...', model: '...', ... }
```

Het resultaat van deze requests, of er 1 of meerdere cars zijn toegevoegd, wordt ook wel de idempotency van een request genoemd.


alternatieven op REST:
- GraphQL <== opzetten. uitdrukkingsvrijheid.
- gRPC <== opzetten. uitdrukkingsvrijheid.
- SOAP <== XML. tooling. uitdrukkingsvrijheid.

API testing tools:
- Postman  <== UI druk. het duurde heel lang voordat ze dark mode hadden. paywall.
- Insomnia  <== dark mode out of the box. sinds vorig jaar KONG   paywall.
- Bruno
- HoppScotch
- VS Code-extensies
  - REST client  .http/.rest
  - Thunder Client

Wat vindt JP nou echt LASTIG met REST APIs? => versionering.

Niet zozeer de endpoints technisch versionen:
```sh
api/v1/todo
api/todo?v=1
api/todo  X-API-VERSION: 1  custom HTTP header
```

Maar alles achter die endpoints, al je entiteiten, services, repositories, database, om van daaruit rekening houden met de verschillende vormen van de data die je terug gaat geven.

### HTTP-statuscodes

- 2xx - SUCCESS
  - 200 OK
  - 201 Created
  - 204 No Content   DELETE
- 3xx - REDIRECT
  - 301/302 Permanent/temporary  POST/Redirect/GET
  - 307/308 Permanent/temporary met behoud van de verb
- 4xx - CLIENT ERROR
  - 400 Bad Request  syntax error  jij als client moet eerst je request aanpassen en daarna mag je het weer proberen
  - 401 Unauthorized
  - 403 Forbidden
  - 404 Not Found
  - 405 Method Not Allowed   POST => endpoint die geen POST kan verwerken
  - 415 MediaType not supported   XML => endpoint die geen XML kan parsen
  - 418 I'm a teapot
  - 409 Conflict
  - 422 Unprocessable entity
- 5xx - SERVER ERROR
  - 500 Internal Server Error
  - 502 Bad Gateway

### REST maturity levels

- Zie ook https://martinfowler.com/articles/richardsonMaturityModel.html
- HATEOAS: Hypermedia As The Engine Of Application State
- level 3 hypermedia
- wanneer gebruiken? vooral bij openbare APIs die veel gebruikers heeft/groot zijn

Voorbeeldresponse van `api/car/16`:

```json
{
	"make": ...
	"model": ...
	"links": [
		{ "description": "history", "rel": "api/car/16/maintenance-history" },
		{ "description": "...", "rel": "..." },
		{ "description": "...", "rel": "..." },
		{ "description": "...", "rel": "..." },
	]
}
```

### Circulaire referenties

- `[JsonIgnore]` - kan niet per API worden ingesteld
- alles handmatig op null in te stellen - heel lelijk
- configuratie
- configuratie
- DTOs

DTOs bieden iets meer flexibiliteit doordat je wel velden kan toevoegen:

```json
{
	"done": true
}
```
=>
```json
{
	"done": true,
	"date": "2024-04-95"
}
```


## Blazor

- SPA
- Microsoft
  - Long-term support
- Mensen:
  - Steve Sanderson (OG programmer)
    - heeft vroeger Knockout.js gemaakt
  - Daniel Roth (programmamanager)
- Gereleased in 2020 met .NET Core 3.1
- Waarom?
  - C# voor alles  <== het overtuigende argument
  - 1 codebase


Blazor komt in twee smaken:

Blazor WebAssembly
- alles wordt op de client gedaan
  - al jouw code draait op de client
  - Browser API: WebAssembly - low-level taaltje
- runtime wordt OOK meegecompileerd
- wil nog wel eens vrij groot zijn in data
  - "Hello world" ~~7MB~~ 9.5MB
- 👍👍👍👍👍 performance

Blazor Server
- alles wordt op de server gedaan
  - al jouw code draait op de server
    - je hebt toegang tot het filesystem/database/microservices
- er wordt een continue openstaande WebSocket-verbinding opengehouden met de server
  voor alles wat er met de UI gebeurt
  - SignalR <== lib die MS maakt voor WebSocket-dingen
- stabiliteit: bij geen/heel slecht internet is je UI zo goed als dood
  - intranet app
- het laadt een stuk sneller.

Projecttemplate Blazor Web App komt met SSR en ondersteunt rendermodes per component

## Realtime

Typische realtime apps:

- Messaging
- Multiplayer games
- Social media
  - facebook
  - Twitter
  - Reddit
- Beurs
- Sport
- Bezorgdiensten
- (Fake)Nieuwswebsites
- DevOps pipeline
- StackOverflow
- Google Docs/Sheets
- Chatroom

Realtime technieken:
- Polling / long polling / no polling - veel HTTP-requests sturen, verbruiken veel data, latency
- WebSockets - werkt met TCP. De huidige default, wat de meeste WebSocket-libs (socket.io, SignalR) wrappen
- WebTransport - werkt met UDP
- gRPC - een communicatieframework die ook streaming ondersteunt. Werkt nog niet lekker native in de browser, maar wellicht binnenkort/ooit wel.

### HTTP-versies

HTTP/1.1
- TCP-kanaal opent
- request sturen
- response ontvangen
- TCP-kanaal sluiten

HTTP/2 sneller SPDY
- TCP-kanaal hergebruik

HTTP/3 sneller QUIC  Quality UDP Internet Connections

## Auth

- identificatie - wie je bent
- authenticatie - bewijs dat je dat bent
- autorisatie   - wat je mag op basis van wie je bent

bewijs:
- user/pass
- email
- biometriek
  - iris-scan
  - gezichtsherkenning
    - foto
  - vingerafdruk
  - gewicht

Soorten tokens:
- JWT - JSON Web Token
- SAML - Security Assertion Markup Language

3 soorten JWT's
- id token - wie jij bent
- access token - iets mogen doen
- refresh token - voor wanneer een access tokens vervalt, een verse nieuwe ophalen
  - te gebruiken in offline situaties zonder interactie met een gebruiker

Wanneer OAuth, wanneer eigen db met users/passes?

- Zonder BFF ben ik minder fan van OAuth
- MPA gaat traditioneel hand-in-hand met eigen db met users/passes
- OAuth wanneer:
  - je met third-party apps te maken hebt
  - als je gebruikers niet wil verplichten om een account aan te maken bij jouw app
  - gaat hand-in-hand met SPA
  - je geen verantwoordelijkheid wil hebben over die securitykeuzes

### OAuth

Waar slaan we dat token op in onze browser?

- cookie
  - XSRF
    - same-site origin?
- local storage
  - ieder JS kan erbij - XSS
- session storage
  - ieder JS kan erbij - XSS
- in-memory
  - als je met als closures werkt, dan kun je het token behoorlijk verbergen
  - druk op F5 en je bent uitgelogd
- indexed database/websql
  - ieder JS kan erbij - XSS



## Deployment

- File system
  => dotnet publish -c Release
- Azure
  => Publish...
- IIS
  => webserver met managementinterfaces
  => ASP.NET Core 1.0/2.0  Kestrel

  IIS <==> Kestrel <==> jouw code

- Docker
  - containerization of software

orchestration
- CI/CD
- Kubernetes - k8s i18n l10n a11y accessibility
- docker-compose
- swarm

### Docker-commando's

SQL Server runnen:
```sh
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Test1234!!Mummmwj@" -p 1533:1433 -d mcr.microsoft.com/mssql/server:2022-latest
```

App builden en runnen:
```sh
docker build -t demoproject  -f .\DemoProject\Dockerfile .

docker run -e "connstring=Server=localhost,1533; Initial Catalog=demooooo; User Id=sa; Password=Test1234!!Mummmwj@; TrustServerCertificate=true" -p 8080:8080 -p 8081:8081 demoproject
```


## Overig

- [Async Guidance](https://github.com/davidfowl/AspNetCoreDiagnosticScenarios/blob/master/AsyncGuidance.md#prefer-asyncawait-over-directly-returning-task) - waarom niet gewoon de `Task` returnen zonder `await`?

