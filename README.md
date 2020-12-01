# A Simple REST API using dotnet and clean architecture

Hi there ! Welcome to this repository which contains a simple REST API made with .NET and [clean architecture](https://www.amazon.com/Clean-Architecture-Craftsmans-Software-Structure/dp/0134494164).

## Pre-requisites

First of all, make sure you have the following pieces of software installed on your machine:

- [.NET 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [PostGres](https://www.postgresql.org/download/)

## How to build

If you want to build the solution directly on your machine, follow these instructions:

```bash
cd to/project/directory
dotnet build
```

## How to run

If you want to run the solution directly on your machine, follow these instructions:

```bash
cd to/project/directory
dotnet run
```

> NB: In order make this work as expected, you will have run a postgres instance
> and make the appsettings file is set up accordingly

## Build and run with docker-compose

In order to ease build and run task, you can proceed as follows:

```bash
cd to/project/directory
docker-compose up
```

## Issues and remarks

This project is a really simple and quick overview of clean architecture with dotnet.

This is not a production-ready, but just an example that may contain flaws.

Nevertheless, it is up to you to create issues [here](https://github.com/bionic-hillbilly/dotnet-simple-clean-arch-rest-api/issues) in order to discuss on how this example could be improved.

Finally, even if this repository may contain flaws and errors, and you want to highlight them via issues,
please keep in mind to be kind and respectful through your remarks and comments.

That's all folks !
