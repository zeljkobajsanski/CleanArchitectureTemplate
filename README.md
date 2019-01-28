# Clean Architecture Template
ASP.NET Core template based on Clean architecture based on https://github.com/JasonGT/NorthwindTraders

## Getting Started
Use these instructions to get the project up and running.

### Prerequisites
You will need the following tools:

* [Visual Studio Code or 2017](https://www.visualstudio.com/downloads/)
* [.NET Core SDK 2.2](https://www.microsoft.com/net/download/dotnet-core/2.2)

### Setup
Follow these steps to get your development environment set up:

  1. Download nuget package BitsEverywhere.CleanArchitectureTemplate.nupkg
  2. Install template by running
  ```
  dotnet new -i BitsEverywhere.CleanArchitectureTemplate.nupkg
  ```
  3. Create new project by running
  ```
  dotnet new onion -n [your project name]
  ```
  4. Uninstall template by running
  ```
  dotnet new -u BitsEverywhere.CleanArchitectureTemplate
  ```
  
  ## Technologies
  * .NET Core 2.2
  * ASP.NET Core 2.2
  * Entity Framework Core 2.2
  
  ## License
  
  This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/zeljkobajsanski/CleanArchitectureTemplate/blob/master/LICENSE.md) file for details.

