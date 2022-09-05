#Business Functionality

This API is designed to provide functionalities about the customers of a product stores.

Functionalities

1. Get all users
2. Create a user
3. Get a single user
4. Delete a user
5. Create an order
6. Get all the customers who purchased a product
7. Get all the products a user has purchased


#Requirements

Visual Studio 2022
SQL Server Management Studio 2018

#Configuration

1.Create a database named ProductStoreDb in the management studio
2. Go to visual studio View -> Server Explorer -> Connect to a database -> Put SQL server name and select the created database.
3. Copy the connection string
4. Go to appsettings.json and paste the connection string to the DefaultConnectionString property.
5. Open Nuget Package Manager Console and run the command: Update-Database
6. Start the program.


