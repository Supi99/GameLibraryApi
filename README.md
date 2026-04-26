# 🎮 GameLibraryApi

A REST API built with ASP.NET Core 9 inspired by Steam's game library system.
Users can register, log in, and manage their personal game collection.

> Work in progress — actively developed as a portfolio project.

## Tech Stack

- **ASP.NET Core 9** — Web API framework
- **Entity Framework Core 9** — ORM
- **SQLite** — local development database
- **JWT** — authentication (coming soon)
- **Swagger** — API documentation

## Architecture

The project follows a layered architecture pattern:

Controller → Service → Repository → Database

Each layer has a single responsibility and communicates through interfaces,
making the codebase testable and maintainable.

## Features

- [x] Games CRUD (Create, Read, Update, Delete)
- [ ] User registration and login
- [ ] JWT authentication
- [ ] Personal game library management
- [ ] Azure deployment

## Getting Started

### Prerequisites
- .NET 9 SDK
- Any IDE (Visual Studio, Rider, VS Code)

### Run locally

```bash
git clone https://github.com/Supi99/GameLibraryApi.git
cd GameLibraryApi
dotnet ef database update
dotnet run
```

Then open `https://localhost:{port}/swagger` to explore the API.

## Roadmap

- [ ] JWT auth — register and login endpoints
- [ ] LibraryEntry endpoints — add/remove games from personal library
- [ ] Input validation with Data Annotations
- [ ] Azure deployment
- [ ] Vue.js frontend