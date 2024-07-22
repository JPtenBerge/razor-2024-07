# Labs

We gaan een todo-applicatie maken.

1. Toon een lijstje van todos op de pagina. Een todo bestaat uit:

	- Id
	- Taak (wat er gedaan moet worden - string)
	- Wanneer het gedaan moet zijn
	- Of het gedaan is

   &nbsp;
   - Olivier-challenge: Achter ieder todo-item moet een linkje komen te staan waarmee een todo-item kan worden afgevinkt.

2. Maak een formulier boven je tabel van todos om nieuwe todos mee toe te voegen. Met formuliervalidatie natuurlijk.
   Tijd over? Implementeer wat client-side validatie. Hint: unobtrusive

3. Maak een repository om de data access van je todo's in te vullen. In de nabije toekomst gaan we nog een repo toevoegen die daadwerkelijk naar de database gaat.

4. Sla je todo's op in een database. Ontsluit die database met Entity Framework Core.

5. Associeer je todo's met een categorie, zoals huiselijk onderhoud, werk of relatiemanagement. Dit is een aparte entiteit in je database. Gebruik een `<select>` in je form.
   - Olivier-challenge: Associeer je todo met één OF MEER categorieën.

6. Test één van je methoden op je Razor Page. Voel je vrij om te kiezen welke frameworks/libraries je hierbij inzet.
   - Olivier-challenge: integratietest je Razor Page [middels een in-memory database](https://learn.microsoft.com/en-us/ef/core/testing/choosing-a-testing-strategy) (zie tabel onderin) die de happy path toetst (met een valid model) voor het toevoegen van een nieuw todo-item via de `OnPost()`.

7. Maak een stuk middleware die alle 404-responses logt.
   - Olivier-challenge: schrijf twee [integratietests](https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-8.0) voor het testen van je middleware:
     - voor een URL die een 404 oplevert
     - voor een URL die een 200 oplevert door bijv. een stylesheet op te vragen.

8. Ik wil graag verschillende views voor het tonen van de todo's:
    - Een view die alle todo's van een bepaalde categorie toont
    - Een view die de 3 meest urgente todo's toont
    - Een view die alle afgeronde todo's toont

    Hergebruik zoveel mogelijk HTML. En maak het ook gerust een beetje mooier met een navigatiegebied zodat men makkelijker kan schakelen tussen de verschillende pagina's.
   
9. Maak een REST API voor het ophalen en toevoegen van todo's. Maak ook een endpoint voor het ophalen van de categorieën. En eentje voor het afvinken van todo's.

   Deze APIs worden in de volgende oefening aangesproken door onze Blazorfrontend.

10. Gebruik DTOs binnen je applicatie om over-POSTing te voorkomen en mapping in het algemeen.

11. Cache je todos.

12. Maak een Blazor WebAssembly-project die todo's toont op de pagina.

13. Pas je Blazor-project aan het todo's ophaalt en weergeeft van de server.

14. Als een ander familielid todo's toevoegt, zouden deze instant zichtbaar moeten zijn voor alle andere familieleden. Gebruik SignalR om je app realtime te maken.

    Dit mag je zowel doorvoeren bij je Blazor-app met C# OF bij je Razor Page middels JavaScript.

15. Onze todo-app wordt gebruikt door hele families! Sla bij elke todo op welk familielid de todo heeft toegevoegd. Men mag dus enkel todo's toevoegen als men is ingelogd. In de lijst van todo's, toon de naam van het familielid die de todo heeft toegevoegd.
   - Olivier-challenge: men mag todo's verwijderen als die door hem-/haarzelf is aangemaakt.
   - Olivier-extra-challenge: implementeer die autorisatie (verwijderen van todo) zowel in de Blazor-frontend als de ASP.NET Core-backend. [Hergebruik de autorisatielogica](https://learn.microsoft.com/en-us/aspnet/core/security/authorization/policies?view=aspnetcore-8.0).
