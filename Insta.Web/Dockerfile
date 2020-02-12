#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Insta.Web/Insta.Web.csproj", "Insta.Web/"]
COPY ["Insta.DataAccess/Insta.DataAccess.csproj", "Insta.DataAccess/"]
COPY ["Insta.Azure/Insta.Azure.csproj", "Insta.Azure/"]
COPY ["Insta.BusinessLogic/Insta.BusinessLogic.csproj", "Insta.BusinessLogic/"]
RUN dotnet restore "Insta.Web/Insta.Web.csproj"
COPY . .
WORKDIR "/src/Insta.Web"
RUN dotnet build "Insta.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Insta.Web.csproj" -c Release -o /app/publish

FROM base AS final
ENV ASPNETCORE_URLS http://*:6890
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Insta.Web.dll"]