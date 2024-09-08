# Stage 1: Build the application
# Use the official .NET Core SDK image for building the application
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ["DeliveggieAPI/DeliveggieAPI.csproj", "DeliveggieAPI/"]
RUN dotnet restore "DeliveggieAPI/DeliveggieAPI.csproj"

# Copy everything else and build the project
COPY . .
WORKDIR "/src/DeliveggieAPI"
RUN dotnet build "DeliveggieAPI.csproj" -c Release -o /app/build

# Stage 2: Publish the application
FROM build AS publish
RUN dotnet publish "DeliveggieAPI.csproj" -c Release -o /app/publish

# Stage 3: Run the application
# Use the official .NET Core runtime image for running the app
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
COPY --from=publish /app/publish .

# Expose the port that your app listens on
EXPOSE 5000

# Set the entry point to run the application
ENTRYPOINT ["dotnet", "DeliveggieAPI.dll"]
