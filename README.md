# RestaurantAPI

The **RestaurantAPI** project is a RESTful API built with **.NET 6**, designed to provide backend solutions for restaurant management.  
It includes features such as user authentication, static file handling, and CRUD (Create, Read, Update, Delete) operations, tailored for managing restaurant data.

## Features

### **User Authentication**  
Secure access is ensured using **JWT (JSON Web Tokens)**, allowing users to authenticate and receive a token for subsequent requests.

### **Role-Based Authorization**  
Users are granted access to specific resources and operations based on their assigned roles (e.g., Admin, Manager, Employee).

### **CRUD Operations**  
Supports the full range of operations for managing restaurant data, such as menus, orders, and reservations.

### **Static File Handling**  
The API can manage static files like images, PDFs, etc.

### **Automatic Database Seeder**

The application includes an automatic seeder that populates the database with sample data when the application starts, providing a ready-to-use environment for testing.

## Architecture & Design

### **Dependency Injection (DI)**  
Used extensively to manage dependencies, promoting modularity, maintainability, and testability.

### **DTO Mapping**  
Data Transfer Objects (DTOs) are used for efficient data representation between layers.

### **Fluent Validation**  
Ensures validation rules are applied consistently and declaratively across requests.

## Technologies

The following technologies are used in the project:

- **ASP.NET Core 6**: For building the API.
- **Entity Framework**: ORM for interacting with the database.
- **LINQ**: For querying data.
- **DTO Mapping**: Simplifies data transfer between API layers.
- **Fluent Validation**: For input validation.
- **JWT Authentication**: Secures endpoints with JSON Web Tokens.
- **NLog**: For logging API requests and errors.
- **Swagger**: For interactive API documentation and testing.
- **Bogus**: Used to generate fake data for testing purposes.

## Getting Started

To get started with the project, follow these steps:

### **Clone the repository:**

```bash
git clone https://github.com/albertgmi/RestaurantAPI.git
cd RestaurantAPI
```

### **Install the required dependencies:**

```bash
dotnet restore
```

### **Configure the database connection:**

The application includes an automatic seeder that will populate the database with sample data when the application starts.
Ensure the database connection is correctly configured in the appsettings.Developement.json file

### **Install the dotnet-ef tool**

If the dotnet-ef tool is not installed, use the following command to install it globally:

```bash
dotnet tool install --global dotnet-ef
```

### **Run the migration command to update the SQL server**

```bash
dotnet ef database update
```

### **Run the application:**

```bash
dotnet run
```
### **Access the API via Swagger at your localhost port:**
For instance:
http://localhost:5176/swagger/index.html
