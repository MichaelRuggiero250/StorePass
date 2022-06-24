#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["StorePass.DataServer/PasswordController.csproj", "PasswordController/"]
RUN dotnet restore "StorePass.DataServer/PasswordController.csproj"
COPY . .
WORKDIR "/src/StorePass.DataServer"
RUN dotnet build "PasswordController.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PasswordController.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PasswordController.dll"]