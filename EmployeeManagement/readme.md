# Employee Management API

## Overview
The **Employee Management API** is a RESTful API built using **ASP.NET Core Web API** and **Entity Framework Core**. It provides CRUD operations for managing employee records along with JWT authentication for security.

## Features
- **User Authentication** using JWT tokens.
- **CRUD Operations** for Employee management.
- **Entity Framework Core** for database interactions.
- **SQL Server** as the database.
- **Exception Handling** for proper error responses.
- **Swagger UI** for API documentation and testing.

## Technologies Used
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server**
- **JWT Authentication**
- **Swagger UI**
- **Postman** (for testing)

## Installation & Setup
### Prerequisites
- .NET SDK 6.0 or later
- SQL Server installed and running
- Postman (optional, for testing API)

### Steps to Run the Project Locally
#### 1. Clone the Repository
```sh
git clone <repository_url>
cd EmployeeManagementAPI
```

#### 2. Set Up the Database
- Open **SQL Server Management Studio (SSMS)**.
- Create a new database named **EmployeeDB**.

#### 3. Configure Connection String
- Open **appsettings.json** and update the connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=EmployeeDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

#### 4. Apply Migrations & Seed Database
Run the following commands in the terminal:
```sh
dotnet ef migrations add InitialCreate
dotnet ef database update
```

#### 5. Run the Application
```sh
dotnet run
```
The API will start running at `https://localhost:5001`.

## API Endpoints
### Authentication
| Method | Endpoint | Description |
|--------|------------|-------------|
| POST   | `/api/auth/login` | Authenticate user and get JWT token |

### Employee Management
| Method | Endpoint | Description |
|--------|------------|-------------|
| GET    | `/api/employees` | Get all employees |
| GET    | `/api/employees/{id}` | Get employee by ID |
| POST   | `/api/employees` | Add new employee |
| PUT    | `/api/employees/{id}` | Update employee details |
| DELETE | `/api/employees/{id}` | Delete an employee |

## Authentication & Authorization
- **JWT Token Authentication** is implemented.
- To access protected routes, include the JWT token in the request header:
```sh
Authorization: Bearer <your_token>
```

## Testing the API
- Open `https://localhost:5001/swagger` in your browser to test endpoints using Swagger.
- Use **Postman** to send requests and verify responses.

## Error Handling
- **401 Unauthorized**: When an unauthenticated user tries to access a protected endpoint.
- **400 Bad Request**: When input validation fails.
- **404 Not Found**: When an employee record is not found.



