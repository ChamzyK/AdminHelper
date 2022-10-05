# AdminHelper

The application provides the ability to perform some operations with the database.

![Alt text](AdminHelper_MainWindow.png "Start screen")

## Subject area
Assistance to the theater manager.

## App description
This program allows admin to calculate the wages for all actors of the theater, depending on the number of performances in each month, the role played by each actor and the fullness of each performance.

## Code description
The following technologies were used in the project:
- C# 10
- WPF
- EntityFramework Core 6 (ORM)
- MS SQL (Local DB)
- MSTest

The following approaches were used to build a scalable code structure:
- DI (Dependency Injection)[^1]
- Pattern MVVM
- Pattern Command (for MVVM)
- Pattern Repository (abstraction from ORM)
- Pattern Service Locator

## Examples

## Tables view example
![Alt text](AdminHelper_SpectaclesExample.png "Spectacles")

## Entity creating example
![Alt text](AdminHelper_CreateActorExample.png "Actor creating")

## Entity editing example
![Alt text](AdminHelper_RoleEditExample.png "Role editing")

---

## Class diagrams

For a more detailed representation of the project code, suggest to take a look at the following class diagrams:

### Entities diagram 

![Alt text](Diagrams/Entities.png)

### Repositories diagram 

![Alt text](Diagrams/Repositories.png)

### Commands diagram 

![Alt text](Diagrams/Commands.png)

### ViewModels diagram 

![Alt text](Diagrams/ViewModels.png)

### EntitiesViewModels diagram 

![Alt text](Diagrams/EntitesViewModels.png)

### EntityViewModels diagram 

![Alt text](Diagrams/EntityViewModels.png)

[^1]: DI implemented with using ```Microsoft.Extensions.Hosting (6.0.1)```
