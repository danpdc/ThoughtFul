# ThoughtFul
A basic API for a blogging platform, built with .NET 6 minimal API

## Architecture
One of the main benefits I see in the .NET 6 minimal API is that it less opinionated on how you should organize your code then the regular controller-based approach.
That's why we have implemented a minimal API using the following principles:
1. Vertical slices architecture (feature-based organization)
2. CQRS using MediatR
3. Auto-registered modules for each feature
4. AutoMapper
5. Record types for DTOs
6. (Kind of) rich domain model
7. No repository and services layer. Everything is handled by the `IRequestHandlers`
8. Splitting read and write endpoints into different files

## Run the API
Running the API is very easy:
1. Provide a connection string in the `appsettings.json` file
2. Run `update-database` in the Package Manager Console or with the .NET Core CLI (make sure you target the Thoightful.Dal project, as all migrations are there)
3. Run the API and play with it

## Further resources
This project was built during 4 different live coding sessions on Youtube.
YouTube channel: [Codewrinkles](https://www.youtube.com/channel/UCyTPru-1gZ7-4qblcKM0TiQ)
1. [Creating a .NET 6 minimal API from scratch (Part 1)](https://youtu.be/U06SgUkIdEU)
2. [Creating a .NET 6 minimal API from scratch (Part 2)](https://youtu.be/58dc7u-YVIw)
3. [Creating a .NET 6 minimal API from scratch (Part 3)](https://youtu.be/YSr8MW9b7yI)
4. [Creating a .NET 6 minimal API from scratch (Part 4)](https://youtu.be/rUn7cSmCLmk)
