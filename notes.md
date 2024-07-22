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
