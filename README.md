# Library Management System

## Functionalitati

- Adauga, sterge si filtreaza carti in functie de titlu si autor
- Imprumuta si returneaza carti pe baza numelui persoanei ce imprumuta
- Adaugare persoanelor ce vor sa imprumute carti
- Vizualizarea istoricului cartilor imprumutate de cate o persoana
- Actualizare automata a datelor cu Observer pattern

## Tehnologii

- .NET (WinForms)
- C#
- Arhitectura pe layere (Domain, Service, UI)

## Utilizare

1. Clone la Repository:
   ```bash
   git clone https://github.com/Razvannnnn/BookApp
   ```
2. Deschide solutia in Visual Studio/JetBrains Rider
3. Schimbarea in App.config a path-ului catre BookDB

   ```bash
   <?xml version="1.0" encoding="utf-8"?>
   <configuration>
       <connectionStrings>
           <add name="Concurs" connectionString="Data Source={Modifica AICI}Data\BookDB;Version=3;Timeout=30;" providerName="System.Data.SQLite" />
       </connectionStrings>
   </configuration>

   <!-- Nu functioneaza decat cu Absolute Path  -->

   ```

4. Build si Run
5. Foloseste interfata pentru a gestiona cartile si imprumuturile
