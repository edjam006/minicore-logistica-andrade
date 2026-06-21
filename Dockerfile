# Etapa 1: Compilación (Build Stage)
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copiar archivo de proyecto y restaurar dependencias
COPY MinicoreLogisticaAndrade.csproj .
RUN dotnet restore

# Copiar todo el código fuente y compilar en modo Release
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Ejecución (Runtime Stage)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

# Copiar los archivos publicados desde la etapa de compilación
COPY --from=build /app/publish .

# Configurar el puerto dinámico para Render (lee variable de entorno PORT)
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Punto de entrada de la aplicación
ENTRYPOINT ["dotnet", "MinicoreLogisticaAndrade.dll"]
