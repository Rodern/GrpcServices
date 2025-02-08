# Weather Service Solution

Welcome to the Weather Service Solution repository! This repository contains a Visual Studio solution with three projects:

1. **WeatherService**: A gRPC weather service that calls a third-party service (Visual Crossing) for weather data.
2. **Models**: A class library containing necessary models.
3. **ConsoleAppgRPC**: A console application that acts as the gRPC client, allowing users to interact with the weather service.

## Table of Contents

- [Overview](#overview)
- [Getting Started](#getting-started)
- [Projects](#projects)
  - [WeatherService](#weatherservice)
  - [Models](#models)
  - [ConsoleAppgRPC](#consoleappgrpc)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Overview

This solution demonstrates the use of gRPC to create a weather service that fetches weather data from a third-party provider, Visual Crossing. The solution includes the following projects:

1. **WeatherService**: A gRPC server that communicates with the Visual Crossing API to retrieve weather data.
2. **Models**: A class library that contains the data models used across the solution.
3. **ConsoleAppgRPC**: A console client application that interacts with the gRPC weather service.

## Getting Started

To get started with the Weather Service Solution, follow these steps:

### Prerequisites

- .NET 6.0 or later
- Visual Studio 2022 or later
- An API key from [Visual Crossing](https://www.visualcrossing.com/)

### Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/Rodern/GrpcServices.git
   cd weather-service-solution
   ```

2. Open the solution in Visual Studio:
   ```sh
   weather-service-solution.sln
   ```

3. Restore the NuGet packages:
   ```sh
   dotnet restore
   ```

## Projects

### WeatherService

The **WeatherService** project is a gRPC server that communicates with the Visual Crossing API to retrieve weather data.

- **Configuration**: Update the `appsettings.json` file with your Visual Crossing API key.
- **Running the Server**: Set `WeatherService` as the startup project and run it.

### Models

The **Models** project is a class library that contains the data models used by both the server and client.

- **Classes**: The project includes classes such as `Hour`, `Day`, `CurrentConditions`, and `Weather`.

### ConsoleAppgRPC

The **ConsoleAppgRPC** project is a console application that acts as a gRPC client, allowing users to interact with the weather service.

- **Configuration**: Ensure that the server is running before starting the client.
- **Running the Client**: Set `ConsoleAppgRPC` as the startup project and run it.

## Usage

1. **Start the Weather Service**:
   - Set `WeatherService` as the startup project.
   - Run the project to start the gRPC server.

2. **Run the Console Client**:
   - Set `ConsoleAppgRPC` as the startup project.
   - Run the project to start the console application.
   - Interact with the weather service through the console application.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any improvements or new features.

1. Fork the repository.
2. Create a new branch for your feature or bugfix.
3. Commit your changes.
4. Push your branch and create a pull request.

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.
