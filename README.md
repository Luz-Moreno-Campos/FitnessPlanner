# Fitness Planner API

## Overview

Fitness Planner API is a RESTful ASP.NET Core Web API designed to help users create personalized workout plans based on specific muscle groups and exercise selections.

Users can build workout plans by selecting exercises that target desired muscle groups and customize each exercise according to individual fitness level and training goals. Workout plans support exercise-specific settings such as sets, repetitions, weight, and rest periods through the WorkoutExercise relationship.

The project follows N-Tier Architecture principles and uses Entity Framework Core with SQL Server for data persistence. DTOs, repositories, services, mapping extensions, pagination, and global exception handling are implemented to ensure clean separation of concerns and maintainable code.

---

## Problem Statement

Many people struggle to build workout routines that match their fitness goals, experience level, and physical capabilities. Selecting appropriate exercises for specific muscle groups and organizing them into effective workout plans often requires significant knowledge and planning.
Fitness Planner API provides a structured solution that allows users to create personalized workout plans by selecting exercises that target specific muscle groups and customizing training variables such as sets, repetitions, weight, and rest periods. Through the WorkoutExercise relationship, each exercise can be configured to meet the individual needs and fitness level of the user, making workout plans more adaptable and effective.


---

## Scope

### Implemented Features

- User management
- Workout plan management
- Exercise management
- Muscle group management
- Complex exercise search endpoint
- Pagination support
- DTO-based communication
- Repository pattern
- Service layer business logic
- Global exception handling
- Input validation using Data Annotations
- Swagger/OpenAPI documentation

### Future Enhancements

- Authentication and authorization
- Workout tracking history
- Progress reporting and analytics
- Exercise media support
- User favorites and custom workout categories

---

## Technologies Used

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server
- LINQ
- Swagger / OpenAPI
- Git & GitHub

---

## Architecture

The application follows an N-Tier Architecture:

```text
Controllers
    ↓
Services
    ↓
Repositories
    ↓
DbContext
    ↓
SQL Server Database
```

DTOs and Mapping Extensions are used to isolate API contracts from database entities.

---

## Database Schema

```text
User
│
└── WorkoutPlan (1:N)

WorkoutPlan
│
└── WorkoutExercise (1:N)

Exercise
│
└── WorkoutExercise (1:N)

Exercise
│
└── MuscleGroup (M:N)
```

---

## API Endpoints

### Users

```http
GET     /api/users
POST    /api/users
DELETE  /api/users/{id}
```

### Muscle Groups

```http
GET     /api/musclegroups
```

### Exercises

```http
GET     /api/exercises
GET     /api/exercises/{id}
POST    /api/exercises
PUT     /api/exercises/{id}
DELETE  /api/exercises/{id}
GET     /api/exercises/search
```

### Workout Plans

```http
GET     /api/workoutplans
GET     /api/workoutplans/{id}
POST    /api/workoutplans
PUT     /api/workoutplans/{id}
DELETE  /api/workoutplans/{id}
```

---

## Complex Query Endpoint

The API includes a complex query endpoint that supports dynamic multi-field filtering and pagination.

### Example

```http
GET /api/exercises/search?
muscleGroup=Chest&
equipment=Barbell&
pageNumber=1&
pageSize=10
```

### Features

- Dynamic multi-field filtering
- Many-to-many relationship queries
- LINQ-based filtering
- Pagination support

---

## Validation

The API uses Data Annotations to validate incoming DTOs.

Examples include:

- Required fields
- String length restrictions
- Email validation
- Numeric range validation

Invalid requests automatically return:

```http
400 Bad Request
```

---

## Error Handling

Global error handling is implemented using ASP.NET Core `IExceptionHandler`.

The API returns RFC 7807 compliant `ProblemDetails` responses.

Supported status codes:

```text
200 OK
201 Created
204 No Content
400 Bad Request
404 Not Found
409 Conflict
500 Internal Server Error
```

---

## Pagination

Pagination is implemented on collection endpoints using:

```http
?pageNumber=1&pageSize=10
```

Supported endpoints:

```http
GET /api/users
GET /api/exercises
GET /api/workoutplans
GET /api/exercises/search
```
---

## Running the Project

1. Clone the repository.
2. Open the solution in Visual Studio.
3. Verify the SQL Server connection string.
4. Build and run the application.
5. Open Swagger:

```text
https://localhost:<port>/swagger
```

The database is automatically created and seeded during application startup.

---

## Author

Luz Moreno Campos

Software Development Program

Final ASP.NET Core Web API Project