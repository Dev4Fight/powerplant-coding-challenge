# Power Generation API
This API allows you to calculate the power generation plan based on the provided payload. It exposes the /productionplan endpoint.

## Installation and Setup
Clone the repository to your local machine.
Open the solution in your preferred IDE (e.g., Visual Studio).
Build the solution to restore NuGet packages and compile the project.
Launching the Application
Set the API project (PowerGenerationAPI) as the startup project.
Run the application using your preferred method (e.g., pressing F5 or Ctrl+F5).
The API will be hosted on http://localhost:8888.

## Testing the API using Postman
Make sure you have Postman installed on your machine.
Open Postman and create a new request.
Set the request URL to http://localhost:8888/productionplan.
Set the request method to POST.
Set the request body to the payload JSON format.
Click the Send button to send the request.
The API will calculate the power generation plan and return the response.

## Testing the API using Swagger
Launch a web browser.
Visit http://localhost:8888/swagger.
You will be redirected to the Swagger UI page.
Explore the available endpoints and their documentation.
Click on the /productionplan endpoint.
Click the Try it out button.
Enter the payload JSON format in the request body.
Click the Execute button to send the request.
The API will calculate the power generation plan and display the response.

## Unit Testing
The application also includes unit tests to verify the functionality of the API.

Open the test project (PowerGenerationAPI.Tests) in your preferred IDE.
Run the tests using your IDE's test runner or by executing dotnet test command in the test project directory.