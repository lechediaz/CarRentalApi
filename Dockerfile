FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /src
COPY src/CarRental.Api/CarRental.Api.csproj ./CarRental.Api/CarRental.Api.csproj
COPY src/CarRental.Application/CarRental.Application.csproj ./CarRental.Application/CarRental.Application.csproj
COPY src/CarRental.Domain/CarRental.Domain.csproj ./CarRental.Domain/CarRental.Domain.csproj
COPY src/CarRental.Infraestructure/CarRental.Infraestructure.csproj ./CarRental.Infraestructure/CarRental.Infraestructure.csproj
RUN dotnet restore ./CarRental.Api/CarRental.Api.csproj
COPY src .
RUN dotnet publish ./CarRental.Api/CarRental.Api.csproj -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /publish
COPY --from=build /publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "CarRental.Api.dll"]
