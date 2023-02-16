FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src
COPY ["src/Teste.Web.Host/Teste.Web.Host.csproj", "src/Teste.Web.Host/"]
COPY ["src/Teste.Web.Core/Teste.Web.Core.csproj", "src/Teste.Web.Core/"]
COPY ["src/Teste.Application/Teste.Application.csproj", "src/Teste.Application/"]
COPY ["src/Teste.Core/Teste.Core.csproj", "src/Teste.Core/"]
COPY ["src/Teste.EntityFrameworkCore/Teste.EntityFrameworkCore.csproj", "src/Teste.EntityFrameworkCore/"]
WORKDIR "/src/src/Teste.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/Teste.Web.Host", "src/Teste.Web.Host"]
COPY ["src/Teste.Web.Core", "src/Teste.Web.Core"]
COPY ["src/Teste.Application", "src/Teste.Application"]
COPY ["src/Teste.Core", "src/Teste.Core"]
COPY ["src/Teste.EntityFrameworkCore", "src/Teste.EntityFrameworkCore"]
WORKDIR "/src/src/Teste.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "Teste.Web.Host.dll"]
