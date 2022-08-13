#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/CoWin/CoWin.API/CoWin.API.csproj", "Services/CoWin/CoWin.API/"]
COPY ["Services/CoWin/CoWin.Application/CoWin.Application.csproj", "Services/CoWin/CoWin.Application/"]
COPY ["Services/CoWin/CoWin.Domain/CoWin.Domain.csproj", "Services/CoWin/CoWin.Domain/"]
COPY ["Services/CoWin/CoWin.Infrastructure/CoWin.Infrastructure.csproj", "Services/CoWin/CoWin.Infrastructure/"]
RUN dotnet restore "Services/CoWin/CoWin.API/CoWin.API.csproj"
COPY . .
WORKDIR "/src/Services/CoWin/CoWin.API"
RUN dotnet build "CoWin.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CoWin.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoWin.API.dll"]