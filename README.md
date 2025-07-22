## Shoplist Backend
This is a .NET 8 Web API that provides endpoints for managing categories and products for a shopping list application. It uses Entity Framework Core with SQL Server Express to store data.

### Prerequisites

.NET 8 SDK: Install from https://dotnet.microsoft.com/download/dotnet/8.0.
SQL Server Express: Install from https://www.microsoft.com/en-us/sql-server/sql-server-downloads.
Git: Install from https://git-scm.com/download/win.
Visual Studio Code (optional): For editing and running the project.

### Installation

#### Clone the Repository:
```bash
git clone https://github.com/olisak78/shoplistbackend.git
cd shoplistbackend
```
#### Restore Dependencies:
```bash
dotnet restore
```

#### Configure Database Connection:

Open appsettings.json and ensure the connection string is set for SQL Server Express:
```json
{
 "ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=shoppinglist;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```
If using a different SQL Server instance, update the Server value.

#### Apply Database Migrations:

Ensure the Entity Framework Core CLI is installed:
```bash
dotnet tool install --global dotnet-ef
```
Create and apply migrations:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```
This creates the shoppinglist database with seeded categories (e.g., Fruits, Vegetables, Beverages) and products.

### Running the Application

#### Start the API:
```bash
dotnet run
```
The API runs at http://localhost:5000.

#### Test Endpoints:

Get categories:
```bash
curl http://localhost:5000/api/categories
```
Example output: ["Fruits","Vegetables","Beverages"]
Get products for a category (e.g., Fruits, ID 1):
```bash
curl http://localhost:5000/api/products/1
```

Example output: ["Apples","Oranges"]

### Project Structure

- Data/ShopListDbContext.cs: Entity Framework Core context with seed data.
- Controllers/CategoriesController.cs: API endpoints for categories and products.
- Models/: Entity classes (Category, Product).
- Migrations/: EF Core migration files.

### Notes

- The .gitignore file excludes bin/, obj/, and appsettings.Development.json to prevent uploading sensitive data.
- Ensure SQL Server Express is running before starting the API.
- The API supports CORS for the frontend at http://localhost:3000.
