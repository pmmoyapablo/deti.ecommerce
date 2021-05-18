FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /src
COPY . .
WORKDIR /src/Deti.Ecommerce.Servicio.WebAPI5
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /src/Deti.Ecommerce.Servicio.WebAPI5/out ./
ENTRYPOINT ["dotnet", "Deti.Ecommerce.Servicio.WebAPI5.dll"]