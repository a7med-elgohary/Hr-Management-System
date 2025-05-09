# HR Management System

> **Note:** _Add your project logo and screenshots in the `images` folder. Update the README accordingly._

![Project Logo](https://github.com/user-attachments/assets/4cbd5dfb-e866-4379-8d77-cf9338f87ae4)

---

## Description
A Human Resources Management System (HRMS) to manage employees, roles, permissions, and more. This project helps HR departments automate and streamline their daily operations and it wll have a Work Room for the employees to work on their tasks.

## Features
- Employee management (add, edit, delete, search)
- Roles & permissions
- User authentication
- Reporting
- Work Room management
- And more...

## Requirements
- .NET Core 9.0
- SQL Server (or specify your DB)

## Installation
```bash
# Clone the repository
git clone https://github.com/your-username/Hr-Management-System.git
cd Hr-Management-System

# Restore dependencies
dotnet restore

# Update DB connection string in appsettings.json

# Run migrations (if applicable)
dotnet ef database update

# Run the application
dotnet run
```

## Usage
- Access the system via `http://localhost:5000` (or your configured port)
- Login with your credentials
- Start managing employees, roles, and permissions

## Screenshots
_Add screenshots to show main features and UI. Replace the image paths below with your actual images._

![Project Dashboard](https://github.com/user-attachments/assets/5b938c8d-e48d-429c-923a-ca2dab696f38)

## Project Structure
```
HR_System/
├── .git/                 # Git version control
├── .github/              # GitHub workflows/settings
├── .vs/                  # Visual Studio settings
├── HR_System/            # Main application code
│   ├── Api/              # API controllers
│   ├── Application/      # Application logic/services
│   ├── Domain/           # Domain models
│   ├── Infrastructure/   # Data access, repositories
│   ├── Migrations/       # EF Core migrations
│   ├── Program.cs        # Application entry point
│   ├── appsettings.json  # App configuration
│   └── ...
├── HR_System.sln         # Solution file
├── README.md             # Project documentation
├── Library.txt           # (custom file)
└── ...
```
