# .NET Core Web API Project
Template for Running a ASP .NET Core MVC

## Prerequisites
- .NET Core SDK 8.0
- A code editor, preferably Visual Studio or Visual Studio Code
- A database engine, such as SQL Server or SQLite, if your project requires a database.
- Git (optional, if cloning the repository)

## Project Setup

1. **Clone the Repository**
   ```bash
   git clone https://github.com/your-username/your-repo-name.git
   cd your-repo-name

2. **Navigate to the main Folder**
   ```bash
   cd mainFolder

3. **Install Dependencies**
   ```bash
   dotnet restore

4. **Change Connection String**
   ```Directory from mainFolder "appsettings.Development.json"
    "ConnectionStrings": 
   {
      //put your connection string 
      "DefaultConnection": "***your Connection String***"
   }

5. **Run**
   ```bash
   dotnet run
