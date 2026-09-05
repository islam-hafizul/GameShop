# Game Shop

A small game catalog application with a .NET Web API backend and a React frontend. The application supports viewing, creating, editing, and deleting games, with games grouped by genre.

## Features

- List games with their genre, price, and release date
- Create new games
- Edit existing games
- Delete games
- Load genres from the API when creating or editing a game
- Persist data in a local SQLite database

## Technology stack

- **Backend:** ASP.NET Core Minimal API on .NET 10
- **Data:** Entity Framework Core 10 with SQLite
- **Frontend:** React 19, TypeScript, and React Router
- **Build tools:** Vite and Bootstrap 5

## Prerequisites

- .NET 10 SDK
- Node.js 20.19+ (or Node.js 22.12+)
- npm

## Run locally

The backend and frontend run as separate development processes.

### 1. Start the API

From the repository root:

```bash
cd GameShop.Api
dotnet run
```

The API is available at `http://localhost:5276`. On startup it applies pending Entity Framework migrations and creates the default genres if the database is empty. The SQLite database is stored in `GameShop.Api/GameShop.db`.

### 2. Start the frontend

In a second terminal:

```bash
cd GameShop.React
npm install
npm run dev
```

Open the URL printed by Vite, normally `http://localhost:5173`.

The Vite development server proxies requests from `/api` to the backend. Start the API before using the frontend so game and genre requests can be completed.

## API endpoints

The API uses the following routes:

| Method | Route | Description |
| --- | --- | --- |
| `GET` | `/games` | List all games |
| `GET` | `/games/{id}` | Get a game by ID |
| `POST` | `/games` | Create a game |
| `PUT` | `/games/{id}` | Update a game |
| `DELETE` | `/games/{id}` | Delete a game |
| `GET` | `/genres` | List all genres |

Example request body for `POST /games` and `PUT /games/{id}`:

```json
{
	"name": "Minecraft",
	"genreId": 3,
	"price": 29.99,
	"releaseDate": "2011-11-18"
}
```

The ready-to-use requests in [`GameShop.Api/games.http`](GameShop.Api/games.http) can be run with the REST Client extension for Visual Studio Code.

## Frontend commands

Run these commands from `GameShop.React`:

```bash
npm run dev      # Start the Vite development server
npm run build    # Type-check and create a production build
npm run lint     # Run ESLint
npm run preview  # Preview the production build locally
```

## Project structure

```text
GameShop.Api/
	Data/            EF Core context, migrations, and database setup
	Dtos/            Request and response contracts
	Endpoints/       Minimal API route mappings
	Models/          Entity models
	Program.cs       API application startup

GameShop.React/
	src/clients/     API clients used by the frontend
	src/components/  Shared UI components
	src/models/      TypeScript data models
	src/pages/       Application pages
	src/App.tsx      Application shell and routing outlet
```

## Database

The application uses **SQLite** through Entity Framework Core.
The default connection string is:

```text
Data Source=GameShop.db
```

The database file is local development data and is ignored by Git. To recreate it, stop the API and remove `GameShop.Api/GameShop.db`; the next API startup will run the migrations and seed the default genres again.

### Database migrations

Entity Framework Core migrations are applied automatically when the API starts.

If the database needs to be recreated during development:

1. Stop the API.
2. Delete:

```text
GameShop.Api/GameShop.db
```

3. Start the API again:

```bash
cd GameShop.Api
dotnet run
```

The application will recreate the database, apply the migrations, and seed the default genres.

## Development Workflow

A typical development session looks like this:

```text
Terminal 1
──────────
cd GameShop.Api
dotnet run

        ↓

ASP.NET Core API
http://localhost:5276


Terminal 2
──────────
cd GameShop.React
npm run dev

        ↓

React + Vite
http://localhost:5173
```

The React application communicates with the API through HTTP requests.

## API ↔ React Integration

The frontend keeps API communication inside the `src/clients/` directory.

This separates API-related code from UI components and makes the application easier to maintain.

The general flow is:

```text
React Component
      ↓
API Client
      ↓
HTTP Request
      ↓
ASP.NET Core Endpoint
      ↓
Database
      ↓
HTTP Response
      ↓
API Client
      ↓
React Component
```

## Learning Goals

This project is intended to demonstrate and practice:

* ASP.NET Core Minimal APIs
* REST API design
* HTTP methods and status codes
* Entity Framework Core
* Database migrations
* SQLite
* DTOs
* React components
* React Router
* TypeScript
* API integration
* CRUD operations
* Frontend/backend separation
* Vite development workflow

## Future Improvements

Possible improvements for the project include:

* Add user authentication and authorization
* Add game search and filtering
* Add pagination
* Add game cover images
* Add form validation
* Add global API error handling
* Add loading and error states
* Add automated backend tests
* Add React component tests
* Add Swagger/OpenAPI documentation
* Add Docker support
* Deploy the frontend and API

## License

This project is intended for learning and development purposes.
