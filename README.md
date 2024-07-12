# FalconWallet: E-commerce Digital Wallet Backend Service
<img src="https://github.com/emaadgh/FalconWallet/assets/10380342/91fefa50-b1f6-4a8f-8421-ae09c8ab063e" width="150" height="150">

## Overview
FalconWallet is a backend service built with ASP.NET Core, specifically designed to handle e-commerce digital wallets. It uses Vertical Slice Architecture to keep the code organized and easy to maintain.

## Features

- **Create and Manage Currencies**: Add new currencies and update their conversion rates.
- **Wallet Management**: Create, suspend, and update wallets.
- **Transaction Handling**: Deposit, withdraw, and track wallet transactions.
- **Atomic Transactions**: Ensure transactional integrity with atomic operations.

## Technology Stack
- **Framework**: ASP.NET Core
- **Database**: SQL Server
- **API Design**: Minimal APIs
- **Validation**: Fluent Validation
- **Object Mapping**: AutoMapper
- **Containerization**: Docker
- **Container Orchestration**: Docker Compose

## Diagrams

### Currency Management
<img src="https://github.com/user-attachments/assets/cb3177a6-79d2-49e1-a9a2-0a09eb045c42" width="629" height="413">

### Transaction Handling
<img src="https://github.com/user-attachments/assets/12822460-d74b-4b84-9ab6-1e9f3aee6426" width="929" height="873">

### Wallet Management
<img src="https://github.com/user-attachments/assets/a4ced3a1-d02b-4a95-af2d-7e8f846d2213" width="629" height="483">

## Getting Started

### Prerequisites
- **.NET SDK 8**: Ensure you have the latest .NET SDK installed.

### Installation

1. **Clone the Repository**:
    ```bash
    git clone https://github.com/emaadgh/FalconWallet.git
    ```

2. **Install Dependencies**:
    - Open a terminal and navigate to the project folder:
        ```bash
        cd FalconWallet
        ```
    - Restore dependencies:
        ```bash
        dotnet restore
        ```

### Running the Application

1. **Run the Application**:
    - Start the API by running the following command in your terminal:
        ```bash
        dotnet run
        ```

2. **Database Migration**:
    - After building the project, run the following command to create or update the database based on migration files:
        ```bash
        dotnet ef database update
        ```
        If you don't have the Entity Framework Core tools (`dotnet ef`) installed globally, you can install them by running the following command:
        ```bash
        dotnet tool install --global dotnet-ef
        ```

3. **Access the API**:
    - By default, the API will be hosted on `localhost` with a randomly assigned port. You can access the API using the following URL format:
        ```
        https://localhost:<PORT>/api
        ```
    - Replace `<PORT>` with the port number assigned to the API during startup.

4. **Explore the API**:
    - Once the API is running, you can use tools like **Swagger** or **Postman** to interact with the endpoints.
    - Visit the Swagger UI at `https://localhost:<PORT>/swagger/index.html` to explore the API documentation interactively.

## AppSettings.json Configuration

Please note that `appsettings.json` files are not included in the Git repository. These files typically contain sensitive information such as database connection strings, API keys, and other configuration settings specific to the environment.

For local testing, you can create your own `appsettings.json` file in the root directory of the FalconWallet project and add the necessary configurations.

### Example `appsettings.json`

```json
{
  "ConnectionStrings": {
    "WalletDbContextConnection": "Server=(localdb)\\MSSQLLocalDB;Initial Catalog=FalconWalletDB;Integrated Security=true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```

## Creator

- [Emaad Ghorbani](https://github.com/emaadgh)

## Contributing

Contributions are welcome! If you'd like to enhance FalconWallet, you can submit pull requests or open issues.

## License

This project is licensed under the MIT License.
