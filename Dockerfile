FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /source

# COPY *.csproj .

# RUN dotnet restore

COPY . .

# RUN dotnet publish -c release -o /app --no-restore

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]
RUN .\scripts\build-msi.ps1

FROM mcr.microsoft.com/dotnet/runtime:5.0

WORKDIR /app

COPY --from=build /app .

ENTRYPOINT ["dotnet", "dotnetapp.dll"]

EXPOSE 8080
