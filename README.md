# DevNetNoord 2023 - Sandboxing .NET assemblies for fun, profit and of course security!

In onze huidige manier om .NET-applicaties te ontwikkelen, vertrouwen we veel op bibliotheken van derden die door anderen zijn ontwikkeld. Dit heeft natuurlijk veel voordelen vanuit het oogpunt van productiviteit, omdat het niet nodig is om de benodigde functionaliteit helemaal opnieuw te schrijven.

Maar door een bibliotheek van derden te gebruiken, haal je ook de problemen en mogelijk beveiligingsproblemen binnen die in de loop van de tijd worden gevonden. Wat doet de bibliotheek? En op welk type andere bibliotheken en/of functionaliteit vertrouwt het? Wat doen de projecten/mensen erachter voor de veiligheid? Als we een .NET-toepassing ontwikkelen met behulp van externe bibliotheken, kunnen we dan onze beveiliging verbeteren?

Andere nieuwe technologieën, zoals WebAssembly, introduceerden een concept van nano-process, waarmee de ontwikkelaar de beschikbare mogelijkheden voor een externe module kan beperken door er een beperkte sandbox voor te maken. Zouden we misschien hetzelfde kunnen doen in .NET?

Vroeger konden we daarvoor AppDomains en Code-Access Security (CAS) gebruiken, maar met de introductie van .NET Core is er nog maar één AppDomain en is CAS afgeschaft. Gelukkig hebben we met .NET Core meer internals zichtbaar gemaakt op AssemblyLoadContext en in deze sessie gaan we daar een sandbox van maken. Een beperkte sandbox die de beschikbare functionaliteit beperkt en de beveiligingshouding van onze applicatie zal verbeteren!