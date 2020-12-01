FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY BionicHillbilly.BookShopService.Api/*.csproj ./BionicHillbilly.BookShopService.Api/
COPY BionicHillbilly.BookShopService.Books/*.csproj ./BionicHillbilly.BookShopService.Books/
COPY BionicHillbilly.BookShopService.Database/*.csproj ./BionicHillbilly.BookShopService.Database/
COPY BionicHillbilly.BookShopService.Database.Seed/*.csproj ./BionicHillbilly.BookShopService.Database.Seed/
COPY BionicHillbilly.BookShopService.Domain/*.csproj ./BionicHillbilly.BookShopService.Domain/

RUN dotnet restore

# copy everything else and build app
COPY BionicHillbilly.BookShopService.Api/. ./BionicHillbilly.BookShopService.Api/
COPY BionicHillbilly.BookShopService.Books/. ./BionicHillbilly.BookShopService.Books/
COPY BionicHillbilly.BookShopService.Database/. ./BionicHillbilly.BookShopService.Database/
COPY BionicHillbilly.BookShopService.Database.Seed/. ./BionicHillbilly.BookShopService.Database.Seed/
COPY BionicHillbilly.BookShopService.Domain/. ./BionicHillbilly.BookShopService.Domain/

WORKDIR /app/BionicHillbilly.BookShopService.Api
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app/BionicHillbilly.BookShopService.Api/out .
ENTRYPOINT ["dotnet", "BionicHillbilly.BookShopService.Api.dll"]