Canteen Management System
Project Overview
The Canteen Management System is a web-based application developed using C# and ASP.NET MVC to manage daily canteen operations efficiently.

The application follows a 2-Tier Architecture, separating the Presentation Layer from the Data Layer. It provides functionality for managing food items, categories, customer orders, billing, and canteen operations.
Architecture – 2-Tier
The application follows a two-layer architecture:
1. Presentation Layer
- ASP.NET MVC
- Controllers
- Models
- Views
- HTML, CSS, JavaScript and Bootstrap
- Handles user interactions and displays application data.
2. Data Layer
- SQL Server
- ADO.NET / Entity Framework (depending on implementation)
- Database operations
- Data retrieval, insertion, updating and deletion.
Architecture Flow
       User
        |
        v
+-----------------------+
|   Presentation Layer  |
|                       |
| ASP.NET MVC           |
| Controllers           |
| Models                |
| Views                 |
+-----------------------+
        |
        v
+-----------------------+
|       Data Layer      |
|                       |
| SQL Server            |
| Database Operations   |
+-----------------------+
        |
        v
      Database
Key Features
- Dashboard Management
- Food Item Management
- Food Category Management
- Customer Management
- Order Management
- Billing Management
- Sales Reports
- User Management
Technology Stack
Technology	Purpose
C#	Backend programming
ASP.NET MVC	Presentation Layer
SQL Server	Database
ADO.NET / Entity Framework	Data access (as implemented)
HTML5, CSS3	UI development
JavaScript	Client-side functionality
Bootstrap	Responsive design (if applicable)
Visual Studio	Development IDEPrerequisites
- Visual Studio
- Compatible .NET Framework / .NET SDK
- SQL Server
- SQL Server Management Studio (SSMS)

Installation and Setup
1. Clone the repository:
   git clone YOUR_GITHUB_REPOSITORY_URL
2. Open the solution file in Visual Studio.
3. Restore NuGet packages.
4. Configure the SQL Server connection string.
5. Create or restore the database.
6. Build the solution.
7. Run the application.
Security
- Keep database credentials secure.
- Validate user inputs.
- Implement authentication and authorization where applicable.
- Never commit sensitive configuration values.
Future Enhancements
- Inventory Management
- Online Food Ordering
- Payment Gateway Integration
- Advanced Sales Reports
- Role-Based Access Control
License
All rights reserved unless a license is explicitly added.
Author
C# / ASP.NET MVC Developer

Architecture
The application follows a 2-Tier Architecture.

Tier 1 – Presentation Layer
-----------------------------
ASP.NET MVC Controllers
Models
Views
Handles user requests and application responses.

Tier 2 – Data Layer
-----------------------------
ADO.NET
SqlConnection
SqlCommand
SqlDataReader
SQL Server
Handles database connectivity and CRUD operations.

Database Operations
-----------------------------
ADO.NET is used to communicate directly with SQL Server.
INSERT – Add new records.
SELECT – Retrieve records.
UPDATE – Modify existing records.
DELETE – Remove records.

Parameterized SQL queries are used to help prevent SQL injection.