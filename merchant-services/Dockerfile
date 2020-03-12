FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-merchant
WORKDIR /source

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out/merchant

FROM mcr.microsoft.com/dotnet/core/aspnet
WORKDIR /app
COPY --from=build-merchant /source/out/merchant ./
ENTRYPOINT ["dotnet", "merchant-services.dll"]
