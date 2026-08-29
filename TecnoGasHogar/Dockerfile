# Etapa 1: compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "TecnoGasHogar.csproj"
RUN dotnet publish "TecnoGasHogar.csproj" -c Release -o /app/publish

# Etapa 2: imagen final, más liviana, solo para ejecutar
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "TecnoGasHogar.dll"]