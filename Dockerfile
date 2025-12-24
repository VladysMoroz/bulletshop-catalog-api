# Використовуємо образ рантайму для запуску
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Використовуємо SDK для збірки
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# 1. Копіюємо файл рішення
COPY ["BulletShopCatalog.sln", "./"]

# 2. Копіюємо всі .csproj файли проектів (це важливо для кешування шарів)
COPY ["ApplicationServices/ApplicationServices.csproj", "ApplicationServices/"]
COPY ["Core/Core.csproj", "Core/"]
COPY ["DatabaseCatalog/DatabaseCatalog.csproj", "DatabaseCatalog/"]
COPY ["WebAPI/WebAPI.csproj", "WebAPI/"]
COPY ["Host/Host.csproj", "Host/"]
COPY ["WebApiTest/WebApiTest.csproj", "WebApiTest/"]

# 3. Відновлюємо залежності (Restore)
RUN dotnet restore "Host/Host.csproj"

# 4. Копіюємо весь інший вихідний код
COPY . .

# 5. Будуємо та публікуємо проект Host
WORKDIR "/src/Host"
RUN dotnet publish "Host.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Фінальний етап - запуск
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Host.dll"]