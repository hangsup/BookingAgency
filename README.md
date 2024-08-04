# Booking Agency Application

## Overview
The Booking Agency Application is designed to manage booking appointments without the need for a traditional database. Instead, it utilizes collections such as `List`. The project follows various design patterns to separate models, repositories, and services, ensuring a clear distinction between the business and web layers. Dependency Injection (DI) and Inversion of Control (IoC) are implemented without relying on third-party libraries.

## Features
- **Booking Appointment**: Create a new appointment.
- **Show Booking Appointment By Date**: View appointments for a specific date.
- **Grid All Booking Appointments**: Display all appointments in a grid view.
- **Set Off Days**: Define days when bookings are not allowed.
- **List Off Days**: View all defined off days.

## Technologies Used
### Third-Party Libraries
- **DevExpress ASP.NET MVC**: Used for displaying data in a grid view.

### NuGet Packages
- **Swashbuckle**: For Swagger API documentation.
- **Microsoft.AspNet.WebApi**: Core API functionality.
- **Microsoft.AspNet.WebApi.Client**: API client functionality.
- **Microsoft.AspNet.WebApi.WebHost**: API web hosting.
- **Microsoft.AspNet.WebApi.Cors**: Enabling CORS in API.
- **NUnit**: Unit testing framework.
- **NUnit3TestAdapter**: Adapter for running NUnit tests.
- **Moq**: Mocking framework for unit tests.

## Project Structure
The project is structured to separate concerns and enhance maintainability:
- **Models**: Data structures used in the application.
- **Repositories**: Data access layer.
- **Services**: Business logic layer.
- **Controllers**: Web layer handling HTTP requests.

## Dependency Injection and IoC
The project is set up for IoC and DI but does not use third-party libraries like Autofac or Unity.

## Unit Tests
The project includes unit tests for controllers, repositories, and services.

### Controllers
- **AppointmentsControllerTest**
  - `BookAppointment_Should_Return_Ok_With_Appointment_When_Successful`
  - `BookAppointment_Should_Return_BadRequest_When_Exception_Occurs`
  - `GetAppointments_Should_Return_Ok_With_Appointments`
  - `SetOffDay_Should_Return_Ok_With_OffDay`
  - `GetOffDays_Should_Return_Ok_With_OffDays`

### Repositories
- **AppointmentRepositoryTest**
  - `AddAppointment_Should_Add_Appointment`
  - `GetAppointments_Should_Return_Appointments_For_Given_Date`
  - `AddOffDays_Should_Add_OffDays`

### Services
- **AppointmentServiceTest**
  - `BookAppointment_Should_Add_Appointment_If_Date_Is_Valid`
  - `BookAppointment_Should_Throw_Exception_If_Date_Is_OffDay`
  - `AddOffDay_Should_Add_OffDay_If_Date_Is_Valid`
  - `AddOffDay_Should_Throw_Exception_If_Date_Is_Already_OffDay`

## Swagger UI
The application includes Swagger UI for API documentation, making it easier to test and understand the API endpoints.

![Swagger UI Documentation](swagger-ui-doc.png)

## Getting Started
To get started with the Booking Agency Application, follow these steps:

1. Clone the repository.
   ```bash
   git clone <repository-url>
   ```

## License
This project is licensed under Dion Darmawan.