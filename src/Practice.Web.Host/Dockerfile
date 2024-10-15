FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/Practice.Web.Host/Practice.Web.Host.csproj", "src/Practice.Web.Host/"]
COPY ["src/Practice.Web.Core/Practice.Web.Core.csproj", "src/Practice.Web.Core/"]
COPY ["src/Practice.Application/Practice.Application.csproj", "src/Practice.Application/"]
COPY ["src/Practice.Core/Practice.Core.csproj", "src/Practice.Core/"]
COPY ["src/Practice.EntityFrameworkCore/Practice.EntityFrameworkCore.csproj", "src/Practice.EntityFrameworkCore/"]
WORKDIR "/src/src/Practice.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/Practice.Web.Host", "src/Practice.Web.Host"]
COPY ["src/Practice.Web.Core", "src/Practice.Web.Core"]
COPY ["src/Practice.Application", "src/Practice.Application"]
COPY ["src/Practice.Core", "src/Practice.Core"]
COPY ["src/Practice.EntityFrameworkCore", "src/Practice.EntityFrameworkCore"]
WORKDIR "/src/src/Practice.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "Practice.Web.Host.dll"]
