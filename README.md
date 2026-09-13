# angular-20

This repository contains the backend for the project and a coming frontend.

## Backend

- Platform: .NET 10 Web API
- Project: Backend (see Backend/Backend.csproj)
- Exposed endpoints (examples):
  - GET /WeatherForecast — sample weather data
  - GET /api/hello — simple hello endpoint
- CORS is configured to allow requests from the Angular frontend running at http://localhost:4200
- Default dev URLs (see Backend/Properties/launchSettings.json):
  - HTTP: http://localhost:5199
  - HTTPS: https://localhost:7157

How to run (development):
- From Visual Studio: open Backend.slnx and run the Backend project (select appropriate launch profile).
- From terminal: cd Backend && dotnet run --project Backend.csproj

Calling the API from an Angular app:
- Use HttpClient to call the backend endpoints, e.g. GET http://localhost:5199/WeatherForecast
- CORS is already enabled for http://localhost:4200; if using a different origin, update the backend CORS policy or use a proxy.

## Frontend (coming soon)

A frontend project will be added soon using Angular 2.0. It will call the backend APIs above and run by default on http://localhost:4200 during development.

Contributions and issues are welcome.
