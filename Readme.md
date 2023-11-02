# Sillystringz's Factory Management System

## Overview

Sillystringz's Factory Management System is a web application designed to help the factory manager keep track of machine repairs and the engineers responsible for those repairs. This application allows you to manage engineers, machines, and their relationships. Engineers can be licensed to repair multiple machines, and machines can have multiple engineers licensed to repair them.

## Table of Contents
- [Project Name](#project-name)
- [Table of Contents](#table-of-contents)
- [About](#about)
- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Running the Application Locally

To run this application locally, follow these steps:

1. Clone the repository to your local machine.
2. Open the project in your preferred development environment (e.g., Visual Studio, Visual Studio Code).
3. Build and run the application.

dotnet run

## Usage

Visit the homepage to get started.
Explore machinery and the technicians responsible for repairs.
Create new machinery and add technicians as needed.

## Project Structure

The project structure follows standard ASP.NET Core MVC conventions:
Controllers: Contains controller classes for handling HTTP requests.
Models: Contains the Machinery and Technician classes.
Views: Contains Razor views for rendering HTML.
Program.cs: Defines the application entry point.
MachineryController.cs: Manages the machinery-related actions.
TechniciansController.cs: Manages the technician-related actions.
Factory.csproj: Project file.

## Contributing

Contributions to this project are welcome. Feel free to open issues or pull requests to suggest improvements or report bugs.

## License

This project is licensed under the MIT License.

## GitHub Repository

The source code for this project is available on GitHub. You can view the repository at https://github.com/izzy503/DrSillystringzFactory.git