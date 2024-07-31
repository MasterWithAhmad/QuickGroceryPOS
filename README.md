# 🛒 QuickGrocery POS System

A comprehensive Point of Sale (POS) system for managing grocery store operations, including product management, order processing, sales tracking, and detailed reporting.

## 📋 Table of Contents
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Database Setup](#database-setup)
- [Contributing](#contributing)
- [License](#license)

## ✨ Features
- User Authentication and Authorization
- Product Management
- Order Processing
- Sales Tracking
- Detailed Reporting
- Search and Sorting Functionality
- Data Visualization with Charts

## Installation

### Prerequisites
- .NET Framework
- SQL Server

### Steps
1. Clone the repository
    ```bash
    git clone https://github.com/<username>/QuickGroceryPOS.git
    cd QuickGroceryPOS
    ```

2. Open the solution file in Visual Studio.
3. Restore NuGet packages.
4. Update the connection string in `App.config` or `Web.config` file if necessary.
5. Build and run the application.

## Usage

### User Authentication
1. Navigate to the Login screen.
2. Enter your username and password.
3. Click on the "Login" button to access the Dashboard.

### Dashboard
- View overall statistics including total products, monthly sales, year sales, week sales, top selling products, and recent transactions.

### Product Management
1. Navigate to the Products Management screen.
2. Add, update, or delete products.
3. Search for products using the search bar.
4. Double-click on a product to add it to the cart.

### Order Processing
1. Navigate to the Checkout screen.
2. Add products to the cart by double-clicking on them from the product list.
3. Process payment by selecting a payment method and clicking "Process Payment".

### Order History
1. Navigate to the Order History screen.
2. View and search past orders.
3. Sort orders by payment method, order date, or total amount.

## Database Setup

### Create Database and Tables
Run the following SQL script to set up the database and tables:

```sql
CREATE DATABASE GroceryPOS;
USE GroceryPOS;

CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(100) NOT NULL,
    Password NVARCHAR(100) NOT NULL
);

CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    Quantity INT NOT NULL
);

CREATE TABLE Orders (
    OrderId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    TotalAmount DECIMAL(10, 2) NOT NULL,
    PaymentMethod NVARCHAR(50) NOT NULL,
    OrderDate DATETIME NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

CREATE TABLE OrderItems (
    OrderItemId INT PRIMARY KEY IDENTITY(1,1),
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);

CREATE TABLE CartHistory (
    CartHistoryId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    DateAdded DATETIME NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);

-- Insert sample products
INSERT INTO Products (ProductName, Price, Quantity) VALUES 
('Apple', 0.50, 100),
('Banana', 0.30, 150),
('Orange', 0.70, 120),
('Milk', 1.20, 80),
('Bread', 1.00, 50),
('Eggs', 2.00, 60),
('Butter', 1.50, 40),
('Cheese', 2.50, 30),
('Chicken', 5.00, 20),
('Beef', 7.00, 25),
('Rice', 3.00, 100),
('Pasta', 2.00, 80),
('Tomato', 0.90, 200),
('Potato', 0.40, 250),
('Onion', 0.60, 180),
('Carrot', 0.70, 150),
('Broccoli', 1.10, 90),
('Spinach', 1.20, 70),
('Yogurt', 1.50, 60),
('Juice', 1.80, 50);
