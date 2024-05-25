# README

## VLensePOC: ASP.NET Core Project Setup with PostgreSQL Database

This guide will help you set up and run the VLensePOC ASP.NET Core project with a PostgreSQL database. It includes steps for creating the database, configuring the project, and generating database migrations.

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)

### Step-by-Step Guide

#### 1. Set Up PostgreSQL Database

1. **Install PostgreSQL:**
   Download and install PostgreSQL from the [official website](https://www.postgresql.org/download/).

2. **Database Migration:**
   Once your PostgreSQL database is set up, it's time to run the migration for Entity Framework Core. Replace the username and the password in VlensePOC/appsettings.Development.json "NpgSql" Connection string, then Open your terminal and run the following commands:

   ```bash
   cd VlensePOC

   dotnet ef database update
   ```

3. **Run Project:**
    After migration run successfully run the following commands or use Visual Studio or Rider or your favorite Ide

    ```bash
    dotnet run
    ```

4. **Open .http file:**
    now open file VlensePOC/VlensePOC.http and follow instructions to add and retrieve data