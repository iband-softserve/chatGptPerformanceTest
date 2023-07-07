# chatGptPerformanceTest

chatGptPerformanceTest is an application that leverages the REST Countries API (https://restcountries.com/v3.1/all) to fetch data and deliver insightful details about all countries globally. Designed with a user-friendly interface, this application makes the exploration of countries a seamless task for geography enthusiasts and international travelers.

Users can search for a specific country by entering the country name in the search bar, whereupon the application filters and displays relevant country-specific data. You can also filter countries based on population and sort the list of countries alphabetically for a more organized browsing experience. We've also incorporated pagination to manage the navigation through the extensive list of countries effectively, providing a manageable and less overwhelming user experience. Feel free to fork, clone, or contribute to this repository to enhance this project further!

# Running the DotNet WebAPI Locally

To run the DotNet WebAPI project locally, follow the instructions below:

## Prerequisites:

* .NET Core SDK: The project is built with .NET Core, so you will need to install the .NET Core SDK. You can download it from here: https://dotnet.microsoft.com/download (.NET 6 SDK).

* A text editor or an Integrated Development Environment (IDE). Visual Studio Code (VS Code) or Visual Studio 2019 (or later) are recommended.

## Steps:

1. Clone the repository: First, you need to clone the repository to your local machine. You can do this by running the following command in your terminal or command prompt:
```
git clone https://github.com/iband-softserve/chatGptPerformanceTest
```

2. Navigate to the project directory: After cloning the repository, navigate to the project directory (the folder containing the .csproj file) using the command:
```
cd chatGptPerformanceTest
```

3. Restore the packages: Run the following command to restore all the NuGet packages used in the project:
```
dotnet restore
```

4. Build the project: Next, build the project using the following command:
```
dotnet build
```

5. Run the project: Finally, run the project with this command:
```
dotnet run
```

After you've run the dotnet run command, the console will output the localhost URL where your WebAPI is being hosted (typically something like http://localhost:5000 or https://localhost:5001). You can now use this URL to access your local WebAPI.

Remember to stop the API from running when you're done by pressing CTRL+C in your terminal or command prompt.


# How to use

Here are ten examples of how you can use the endpoint of the application:

1. Getting All Records: Simply access the endpoint without any filters to get all records:
```
https://localhost:5000/Country/All
```

2. Filtering by Country Name: If you want to search for a specific country, say 'Germany', you can use the 'name' query property:
```
https://localhost:5000/Country/All?name=Germany
```

3. Filtering by Population: To get countries with a population less than 1 million, use the 'population' query:
```
https://localhost:5000/Country/All?population=1
```

4. Sorting in Ascending Order: To sort the countries by name in ascending order, use the 'sortType' query:
```
https://localhost:5000/Country/All?sortType=ascend
```

5. Sorting in Descending Order: To sort the countries by name in descending order, use the 'sortType' query:
```
https://localhost:5000/Country/All?sortType=descend
```

6. Limiting the Number of Records: To limit the number of records returned in response, use the 'numberOfRecords' query. For example, to get only 5 countries, use:
```
https://localhost:5000/Country/All?numberOfRecords=5
```

7. Combining Queries: You can also combine multiple queries. For example, to get 3 countries with a population less than 50 million, sorted in ascending order, use:
```
https://localhost:5000/Country/All?population=50&sortType=ascend&numberOfRecords=3
```

8. Filtering by Country Name and Sorting: To find a country, say 'India', and sort it in descending order, use:
```
https://localhost:5000/Country/All?name=India&sortType=descend
```

9. Filtering by Population and Limiting Records: To get 10 countries with a population less than 1 billion, use:
```
https://localhost:5000/Country/All?population=1000&numberOfRecords=10
```

10. Using all Queries Together: To get 2 countries with names starting with 'A', with a population less than 10 million, sorted in descending order, use:
```
https://localhost:5000/Country/All?name=A&population=10&sortType=descend&numberOfRecords=2
```

Remember to replace 'localhost:5000' with your server's address if you're not running the application locally.
