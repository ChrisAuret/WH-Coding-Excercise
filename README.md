# WH-Coding-Excercise

## Running the code

You will need
- Git
- Visual Studio 2015

1. Clone the repo from [GitHub](https://github.com/ChrisAuret/WH-Coding-Excercise)
    ```
    git clone git@github.com:ChrisAuret/WH-Coding-Excercise.git
    ```
2. Open the solution in Visual Studio 2015
2. Build the solution (F6) (this will download nuget packages)
3. Paste test data into input.csv

## To Run Tests

Double-click "RunTests.bat" from the file explorer

## To Run Console Application
-   Make sure solution has been built
-   Just hit F5 in Visual Studio and console app will run

## Assumptions
- UTF-8 input file
- File contains up to 50000 records
- Each record in the input file has been validated already
- Database is not needed as will process all recoreds in memory
    
## Decisions
- A user interface is not important for this task. I've focused on the domain layer and unit tests and not on presentaion aspects.
