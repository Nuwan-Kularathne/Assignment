# Vypex Coding Challenge

## Problem Statement

HR require a portal to manage employees and their leave days. The portal should be able to display a list of employees, edit an employee, add leave days, and show the total leave days taken by an employee on the employee list.

## Requirements

The portal requires the following features:

* Displays the list of employees.
* Can add and remove leave days.
* Shows the total leave days taken by an employee on the employee list.
* Leave days can overlap.
* Leave days can be edited.
* Leave days have a start and end date. No need to track leave hours.
* Filter employees by name on the employee list.

## What's provided

You're inheriting a partially completed project. The authors may or may not have been a bit sleepy after Thursday's steak special team lunch at the Carlton Brewhouse.

## What we're evaluating
* Knowledge of .NET and Angular frameworks.
* Solution architecture and project layout.
* Sound abstractions.
* Performance.
* Good practices, patterns and clean code.
* Simplicity.

## Backend

### 🛠️ Provided
* Scaffolded ASP.NET Core 9 Web API with an endpoint that returns a mock list of employees.
* Pre populated SQLite database that is currently NOT connected to the endpoint.
* Basic Employee model class with Id and Name properties registered in EF Core.
* By default the service is available at https://localhost:7189
	* OpenAPI document https://localhost:7189/openapi/v1.json
	* API browser https://localhost:7189/scalar/v1
* `dotnet ef` tool has been installed as part of the project which can be run from the `Vypex.CodingChallenge.Service` folder.

### ✅ Tasks
* Connect the Employees endpoint to the "real" database.
* Add leave days to the employee model and database.
* Implement the leave days API in the backend.

### 💡Tips
If you want to regenerate the SQLite db use the following command. The `--startup-project` and `--project` properties are important because of the project structure.
```bash
dotnet ef database update --startup-project .\Vypex.CodingChallenge.Service\Vypex.CodingChallenge.Service.csproj --project .\Vypex.CodingChallenge.Infrastructure\Vypex.CodingChallenge.Infrastructure.csproj
```

## Frontend

### 🛠️ Provided
* Scaffolded Angular 19 frontend.
* The app zoneless change detection enabled.
* An API service that communicates with the backend.
* Front end with employees dashboard that lists employees.
* A skeleton modal for editing an employee.
* NgZorro/Ant Design for UI components.
  * Feel free to add styles for any components you may use into */src/styles/antd.less* if they're not already included.

### ✅ Tasks
#### Improve employees list component
* Use new Angular 19 resources.
* Add a refresh/reload button to refetch the list of employees.
* Handle potential API errors.
* Implement search by employee name functionality
	* Minimise the number of requests to the API where possible

#### Implement employee leave functionality
* Create employee leave form control as a separate and re-usable component.
    * The user can dynamically add/modify multiple leave entries for an employee.
    * Leave days can overlap (for simplicity)
    * Both start and end date are required.
* Add leave form control component to `EditEmployeeComponent`
* Update `EditEmployeeComponent` to communicate with the API.
* Use Angular forms and Ant Design components for user input.

## 🚫 Out of scope
* Editing employee properties other than leave.
* Business days or holiday considerations.
* State management.
* Custom CSS (use existing Tailwind utilities).
* Additional database table columns beyond basic requirements.
* Validation or any other error handling on the backend.
* Unit tests or any other form of testing.

## Submission
Once you've completed the test, create a zip archive of your submission and send it to the recruiter.

Thank you and good luck!
