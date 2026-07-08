# SecureAuthSystem API 🔐

SecureAuthSystem API is a secure authentication and authorization system built using **ASP.NET Core Web API**.  
The project demonstrates JWT based authentication, role-based authorization, secure API access, and clean backend architecture.

This project is designed to showcase real-world authentication flow used in enterprise applications.

---

## 🚀 Features

- User Registration
- User Login
- JWT Token Generation
- JWT Bearer Authentication
- Role-Based Authorization (Admin/User)
- Protected API Endpoints
- Password Hashing
- Token Validation
- Swagger JWT Authentication Support
- Entity Framework Core Integration
- SQL Server Database Integration
- Clean Layered Architecture

---

## 🛠️ Technologies Used

### Backend

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server
- LINQ
- JWT Bearer Authentication
- Swagger / OpenAPI

---

## 📂 Project Structure

```text
SecureAuthSystem

│
├── Controllers
│   ├── AuthController.cs
│   └── DashboardController.cs
│
├── Models
│   └── User.cs
│
├── DTO's
│   ├── LoginDto.cs
│   └── RegisterDto.cs
│
├── Services
│   └── Authentication Services
│
├── Helpers
│   └── JWT Helper
│
├── Middleware
│   └── Custom Middleware
│
├── Data
│   └── ApplicationDbContext.cs
│
├── Migrations
│
├── Program.cs
│
└── appsettings.json
```

---

# Authentication Flow

```text

User
 |
 |
Register/Login Request
 |
 |
Auth Controller
 |
 |
Validate Credentials
 |
 |
Generate JWT Token
 |
 |
Return Token
 |
 |
Angular / Client Stores Token
 |
 |
Authorization Header

Bearer <token>

 |
 |
JWT Middleware Validation
 |
 |
Protected API Access

```

---

## JWT Token Contains

Example Claims:

```json
{
  "name": "User",
  "role": "Admin",
  "exp": "Token Expiry"
}
```

---

## API Endpoints

### Authentication

### Register User

```http
POST /api/auth/register
```

Request:

```json
{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john@gmail.com",
  "password": "Password123",
  "role": "User"
}
```

---

### Login User

```http
POST /api/auth/login
```

Request:

```json
{
  "email": "john@gmail.com",
  "password": "Password123"
}
```

Response:

```json
{
  "token": "JWT_TOKEN_HERE"
}
```

---

## Authorization

User Protected API:

```csharp
[Authorize]
```

Admin Protected API:

```csharp
[Authorize(Roles="Admin")]
```

---

## Security Implementation

- JWT Token Authentication
- Secure Password Storage
- Role Based Access Control
- Protected Routes
- Token Expiration Validation

---

## Database

Database: SQL Server

Tables:

```text
Users

Id
FirstName
LastName
Email
PasswordHash
Role
```

---

## Running the Project

Clone Repository

```bash
git clone repository-url
```

Open project:

```bash
cd SecureAuthSystem
```

Restore packages:

```bash
dotnet restore
```

Apply migrations:

```bash
dotnet ef database update
```

Run API:

```bash
dotnet run
```

Swagger:

```text
https://localhost:xxxx/swagger
```

---

## Future Enhancement

Angular Frontend Integration:

- Login UI
- Register UI
- JWT Interceptor
- Auth Guard
- Role Based Dashboard
- Logout Functionality

---

## Author

**Praneeth Bogam**

---

⭐ This project demonstrates secure authentication implementation using ASP.NET Core Web API and JWT.
