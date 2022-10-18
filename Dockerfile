FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./Progame.WebApi/Progame.WebApi.csproj" --disable-parallel
RUN dotnet public "./Progame.WebApi/Progame.WebApi.csproj" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT ["dotnet", "Progame.WebApi.dll"]