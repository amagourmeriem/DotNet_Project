

![Capture d’écran 2024-03-01 à 22 00 56](https://github.com/MeriemAMG/ModElle/assets/156188796/87851d20-01f1-488a-a893-ef523079348f)
![Capture d’écran 2024-03-01 à 22 01 53](https://github.com/MeriemAMG/ModElle/assets/156188796/6e236c41-b0ab-4c90-86be-5cd990f6be26)
![Capture d’écran 2024-03-01 à 22 02 32](https://github.com/MeriemAMG/ModElle/assets/156188796/d6e83685-0abd-49b7-8f92-7f2d82f9e22e)
![Capture d’écran 2024-03-01 à 22 02 47](https://github.com/MeriemAMG/ModElle/assets/156188796/9a451e0c-529a-4f7d-b183-e4ff0d8229b9)
![Capture d’écran 2024-03-01 à 22 02 15](https://github.com/MeriemAMG/ModElle/assets/156188796/be1087b6-be06-4205-907a-e6b200d9ec82)


# E-commerce Website Project

A .NET Core project e-commerce website (Mod'Elle).

## Table of Contents

- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [Features](#features)
- [License](#license)
- [Acknowledgments](#acknowledgments)

## Getting Started

To get started with the e-commerce website, follow these steps:

### Prerequisites

Make sure you have the following prerequisites installed:

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Database Server (e.g., SQL Server)](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/ecommerce-website.git```
2.Navigate to the project folder:
   ```cd ecommerce-website```
3.Update the connection string in appsettings.json with your database details:
```
"ConnectionStrings": {
  "DefaultConnection": "Server=YourServer;Database=YourDatabase;User=YourUser;Password=YourPassword;"
}
```
4.Run the database migrations:
``` add migration NewDb
    update database ```

### Features

=>Product catalog with categories
=>User authentication and authorization
=>Order processing and tracking
=>Admin panel for managing products and orders

### License
This project is licensed under the MIT License - see the LICENSE file for details.


### Acknowledgments

  Thanks to ASP.NET Core for providing a powerful framework.
  Icons used in the project are from FontAwesome.

Make sure to replace placeholder URLs, such as repository links and database connection strings, with your actual project details. Additionally, consider adding more sections or details based on the specific features and requirements of your e-commerce website.
