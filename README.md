# Employee Sollution


## Description
This project is a demonstration of CRUD operations using a .NET Core API for managing employee data and attendance. It includes the following features:

- API01: Update an employee's employee code (PUT request)
- API02: Get all employees based on maximum to minimum salary (GET request)
- API03: Find all employees who are absent at least one day (GET request)
- API04: Get monthly attendance report of all employees (GET request)

## Deployed APIs
The APIs have been deployed and can be accessed using the following URLs:

- API01: Update an employee's employee code
  - URL: [http://trifov1-001-site1.btempurl.com/api/Employe/{id}](http://trifov1-001-site1.btempurl.com/api/Employe/{id})
  - Method: PUT

- API02: Get all employees based on maximum to minimum salary
  - URL: [http://trifov1-001-site1.btempurl.com/api/Employe/salary](http://trifov1-001-site1.btempurl.com/api/Employe/salary)
  - Method: GET

- API03: Find all employees who are absent at least one day
  - URL: [http://trifov1-001-site1.btempurl.com/api/Employe/absent](http://trifov1-001-site1.btempurl.com/api/Employe/absent)
  - Method: GET

- API04: Get monthly attendance report of all employees
  - URL: [http://trifov1-001-site1.btempurl.com/api/Employe/attendance-report](http://trifov1-001-site1.btempurl.com/api/Employe/attendance-report)
  - Method: GET

## Postman Example
You can use Postman to test the APIs. Here's an example for API01:

- API01: Update an employee's employee code
  - URL: [http://trifov1-001-site1.btempurl.com/api/Employe/2](http://trifov1-001-site1.btempurl.com/api/Employe/2)
  - Method: PUT
  - Request body:
    ```
    {
      "employeeCode": "changed"
    }
    ```

## Installation and Setup
1. Clone the repository.
2. Open the project in your preferred IDE.
3. Build the project to restore the NuGet packages.
4. Update the database connection string in the `appsettings.json` file.
5. Run the project.

## License
This project is licensed under the [MIT License](LICENSE).

