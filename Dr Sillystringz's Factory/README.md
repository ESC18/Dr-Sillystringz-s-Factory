# Dr Sillystringz's Factory Management System

#### By Elijah Shawn Cartwright

## Technologies Used:

* HTML
* CSS
* JavaScript
* C#
* ASP.NET Core
* Entity Framework Core
* MySQL Database
* Visual Studio Code
* Visual Studio
* Git

## Description:

The Dr Sillystringz's Factory Management System is a web application designed to help manage the factory's engineers and machines effectively. The application allows users to add, view, edit, and delete engineers and machines. Each engineer can have a name and specialty, and each machine can have a name, manufacturer, and installation date. The system provides an organized and efficient way to keep track of the factory's resources, making it easier to assign engineers to machines and manage their information.

## Setup and Installation Guide:

### Prerequisites:
* .NET 6 SDK
* MySQL Server

1. Clone the repository to your local machine:
git clone https://github.com/ESC18/Dr-Sillystringz-s-Factory.git

2. Open the project folder in Visual Studio Code or Visual Studio.

3. Create the `appsettings.json` file in the `DrSillystringzFactory` directory and update it with your MySQL connection string:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=factorydb;Uid=root;Pwd=your_password;"
  }
}

4. Open a terminal in Visual Studio Code or Visual Studio and navigate to the DrSillystringzFactory directory:

cd DrSillystringzFactory

5.Restore the project dependencies by running the following command:

dotnet restore

6. Apply the database migrations:

dotnet ef database update

7. Start the application by running the following command:

dotnet watch run

8. Access the application in your web browser at:
https://localhost:5001

## Known Issues
* no known issues at this time.

## License 
MIT License
Copyright © Elijah Shawn Cartwright 2023
