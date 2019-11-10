# Workflow Guide
Når man skal implmentere en ny feature eller løse et issue, starter man med at oprette en branch, det kan gøres ved hjælp af checkout på følgende måde, bemærk `-b` opretter en nye branch:

```
git checkout -b <navn-på-brnach>
```

Herefter vil man have oprettet den nye branch og man er nu også checket ind på branchen. Man kan nu arbejde som man plejer ved at lave commits og bruge pull og put som normalt.
Når man vil merge med masteren gør man følgende:

```
git checkout master
git pull 
git checkout <navn-på-branch>
git merge master
<løs evt. merge conflicter>
git push
```

Man kan nu gå på github.com og ved hjælp af fanen pull request, oprette et pull request, eller gøre som vist nedenfor.

<img style="float: right;" src="https://github.com/firstcontributions/first-contributions/blob/master/assets/compare-and-pull.png" />

Man vil blive sendt ind på en side, hvor man skriver hvad pull requestet er til for, hvorefter man submitter som vist nedenfor.

<img style="float: right;" src="https://raw.githubusercontent.com/firstcontributions/first-contributions/master/assets/submit-pull-request.png" />

Når vi har fået sat en webhook op, vil jenkins hente ens ændringer og køre alle vores test, når jenkins er færdig og alle test er klaret, kan man trykke på merge og pull requestet vil blive merget med master.
Hvis man f.eks. ikke består testene, laver man blot nye commits og pusher dem til branchen, herefter vil pull requestet bliver opdateret med de nye ændrigner.
Man kan også tilføje reviewers i højre side, hvis man gerne vil have nogen til at læse og kommentere på koden.
