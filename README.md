# University Tracking System API

This project is a backend RESTful API designed to manage a university's internal academic system. Built using ASP.NET Core 6.0 and Entity Framework Core, the system provides features for handling students, teachers, assignments, courses, attendance, grades, and more.

It is structured to separate responsibilities clearly and uses repository patterns to handle data access, with support for dependency injection and service abstraction.

## 🔍 Project Overview

The API allows different operations such as:

- Adding and managing students, teachers, and courses.
- Assigning lectures to teachers and scheduling student classes.
- Tracking assignment submissions and their evaluation.
- Recording student attendance and grades.
- Sending notifications to users (students/teachers).
- Attaching documents to records (assignments, lectures, etc.).

This system is suitable for universities, colleges, and institutions aiming to digitize their administrative and academic workflows.

---

## 🗂️ Project Structure and File Explanation

### `Program.cs`
The entry point of the application. It configures services like the database context, repositories, AutoMapper, Identity, and Swagger. It also sets up middleware and starts the server.

### `appsettings.json`
Contains configuration data such as database connection strings, logging settings, and environment-specific settings.

### `UniversityTrackingSystem.csproj`
The project file that defines dependencies used like Entity Framework Core, AutoMapper, Identity, BCrypt, and Swagger.

---

## 📁 Folders Overview

### `Controllers/`
Contains all the API controllers that handle HTTP requests for various modules:
- `AssignmentController.cs`, `AssignmentSolutionController.cs`: Manage assignments and student submissions.
- `StudentController.cs`, `TeacherController.cs`: Handle student and teacher data.
- `CourseController.cs`, `LectureController.cs`: Manage course content and lectures.
- `AttendanceController.cs`, `GradeController.cs`: Record attendance and grades.

### `Models/`
Defines the core entity classes like `Student`, `Teacher`, `Assignment`, `Lecture`, `Grade`, etc., representing the database tables.

### `Interfaces/`
Declares the repository interfaces used to abstract the data access logic for each module.

### `Repository/`
Implements the repository interfaces. It contains the actual logic to interact with the database for each module.

### `Data/`
Includes the `UAppContext` class which is the main `DbContext` handling EF Core operations.

### `MapperHelper/`
Contains AutoMapper profiles to map between entity models and view models (DTOs).

### `Migrations/`
Stores EF Core migration files used to create and update the database schema.

### `VMs/` (ViewModels)
Contains view models used to shape data sent to/from the API. It’s used for validation and separation between domain and exposed data.

### `Properties/`
Contains metadata for the project, such as launch settings during development.

### `obj/` and `bin/`
Generated automatically by .NET during build. These folders are not usually committed to source control.

---

## 🏁 How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/adnanmoh/UniversityTrackingSystem.git
   ```

2. Update `appsettings.json` with your SQL Server connection string.

3. Apply migrations:
   ```bash
   dotnet ef database update
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

5. Visit Swagger UI: [https://localhost:5001/swagger](https://localhost:5001/swagger)

---

## ✅ Final Notes

This project is a full-featured educational backend system ready to be extended or integrated with a frontend client (e.g., Angular, React). It’s organized for scalability and maintainability using best practices in ASP.NET Core development.

