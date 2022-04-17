#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Reports.Contato.Worker/Reports.Contato.Worker.csproj", "Reports.Contato.Worker/"]
RUN dotnet restore "Reports.Contato.Worker/Reports.Contato.Worker.csproj"
COPY . .
WORKDIR "/src/Reports.Contato.Worker"
RUN dotnet build "Reports.Contato.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Reports.Contato.Worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Reports.Contato.Worker.dll"]