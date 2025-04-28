# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["HR_System/HR_System.csproj", "HR_System/"]
RUN dotnet restore "HR_System/HR_System.csproj"
COPY . .
WORKDIR "/src/HR_System"
RUN dotnet publish "HR_System.csproj" -c Release -o /app/publish

# Use the official ASP.NET runtime image for the final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "HR_System.dll"]
