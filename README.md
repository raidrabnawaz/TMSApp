# TMS - Transportation Management System

A web-based Transportation Management System (TMS) for managing vehicle fleets and tracking maintenance activities. Built with ASP.NET Core and Microsoft Identity for authentication.

## Features

- **Vehicle Management**: Add, update, and delete vehicle information.
- **Maintenance Tracking**: Record and manage maintenance activities for each vehicle.
- **Overview Dashboard**: Displays total vehicles, recent maintenance, and upcoming activities.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (5.0 or higher)
- SQL Server or SQL Server LocalDB

## Setup

1. **Clone the Repository**  
   ```bash
   git clone https://github.com/yourusername/TMSApp.git
   cd TMSApp
   ```

2. **Configure Database**  
   Update `appsettings.json` with your connection string, then run:
   ```bash
   dotnet ef database update
   ```

3. **Run the Application**  
   ```bash
   dotnet run
   ```
   Access the app at `https://localhost:5001` or `http://localhost:5000`.

## Usage

- **Authentication**: Register and log in to access features.
- **Vehicle Management**: Manage vehicle details like plate number and model.
- **Maintenance Records**: Add, view, or delete maintenance entries.
- **Dashboard**: Overview of fleet metrics, recent maintenance, and upcoming tasks.

## Technologies

- **ASP.NET Core** - Web framework
- **Entity Framework Core** - Database ORM
- **Microsoft Identity** - Authentication
- **Bootstrap** - UI styling
