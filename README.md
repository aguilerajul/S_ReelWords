# S_ReelWords
ReelWords

The solution was created trying to use DDD pattern and allow to play a console game.

The solution projects were divided in:

# ReelWords.Application
Contains a console application created with .NET Core, that can be run to play the game.

In case that it´s not the startup project, we need to set it manually:
1.- Once we cloned the project, we need to find the Application/ReelWords.Application.
2.- Make right click and choose: **Set as Startup Project**
  - ![image](https://user-images.githubusercontent.com/5640678/230117955-ccf6e72e-7edf-4b6c-b925-2056e30ff91d.png)
3.- Execute the project.

# ReelWords.Domain
Contains all the entities that will be use it by the Application, Infrastructure, Tests and handle some business rules.

# ReelWords.Infrastructure
Contains all these implementations that are relate it to: Repositories for DB, File Handling, Logging.

# ReelWords.Tests
Contains the tests for the different projects in this case, right only have the domain tests.

## Pre-Requisistes
:ballot_box_with_check: You need to have **Visual Studio 2019 Community** or superior.

:ballot_box_with_check: You need to have the **.NET Core 3.1** version enabled in your Visual Studio.

