
Project Overview
This project is based on CQRS and Clean Architecture principles. It utilizes the concepts of Interface Segregation and Dependency Inversion.

Key Features
•  Database Configuration: Table configurations are handled in the Infrastructure layer.

•  Unit of Work: Implemented as a PostProcessor.

•  Swagger: Set up for API documentation.

•  CSV Insert API: An API for inserting data from a CSV file, which works correctly.

•  Flight List API: An API for retrieving a list of flights and exporting the output to a CSV file, which has been tested and works correctly.

Future Enhancements
•  Unit and Integration Tests: Can be added to improve the robustness of the project, but were not included due to time constraints.

•  Value Objects and Specifications: These concepts can be utilized for further optimization of the project.

•  Logging: MediatR behaviors can be used for logging, which I plan to add after completing the frontend part of the project.
