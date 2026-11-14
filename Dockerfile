
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY ["wt-lab8-8razor-postgresql-talashkevich.csproj", "./"]

RUN dotnet restore "wt-lab8-8razor-postgresql-talashkevich.csproj"

COPY . .

RUN dotnet publish "wt-lab8-8razor-postgresql-talashkevich.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:10000

EXPOSE 10000

ENTRYPOINT ["dotnet", "wt-lab8-8razor-postgresql-talashkevich.dll"]
