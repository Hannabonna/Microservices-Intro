FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-product
WORKDIR /source

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out/product

FROM mcr.microsoft.com/dotnet/core/aspnet
WORKDIR /app
COPY --from=build-product /source/out/product ./
ENTRYPOINT ["dotnet", "product-services.dll"]

