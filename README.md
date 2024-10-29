# Project 1: Candlestick Data Management
![image](https://github.com/user-attachments/assets/5141c9ba-c84f-4812-8591-e7c94e246318)
![image](https://github.com/user-attachments/assets/8a1eeda1-b529-4b42-8c1d-8aeab7551e77)

## Overview
This project is designed to handle and visualize candlestick data from a CSV file. The application allows users to load candlestick data, filter it by date, and visualize the data on a chart for analysis. 

### Features
- **Load Stock Data**: Import candlestick data from a CSV file.
- **Filter by Date**: Filter the data displayed based on user-selected start and end dates.
- **Data Visualization**: Display filtered data in a chart to observe trends and analyze stock behavior.

## Requirements
- **Programming Language**: C#
- **Framework**: .NET Framework (suitable for Windows Forms applications)
- **IDE**: Visual Studio or any other C#-compatible IDE

## File Structure
- **FormEntry.cs**: Contains the main Windows Form, including UI components for loading, filtering, and displaying candlestick data.
- **aCandlestick.cs**: Defines the `aCandlestick` class, representing individual candlestick data points with properties like `date`, `open`, `high`, `low`, `close`, and `volume`.

## aCandlestick Class

### Purpose
The `aCandlestick` class is responsible for representing individual data points in candlestick format, including date, open, high, low, close, and volume. It provides constructors for initializing objects with individual values or parsing a single line of CSV data.

### Properties
- **date** (`DateTime`): Represents the date of the candlestick data point.
- **open** (`Decimal`): The opening price.
- **high** (`Decimal`): The highest price.
- **low** (`Decimal`): The lowest price.
- **close** (`Decimal`): The closing price.
- **volume** (`long`): The volume of stocks traded.

### Constructors
- **Default Constructor**: Initializes properties to default values.
- **Parameterized Constructor**: Allows direct initialization of `date`, `open`, `high`, `low`, `close`, and `volume`.
- **String Parsing Constructor**: Parses a CSV line formatted as `"Date","Open","High","Low","Close","Volume"` and assigns the values to the respective properties.

## CSV File Format
The application expects a CSV file with the following columns:
```plaintext
"Date","Open","High","Low","Close","Volume"



