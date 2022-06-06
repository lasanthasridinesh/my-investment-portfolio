# My Investment Portfolio

## Prerequisites to run the application
01. Visual Studio 2022
02. Microsoft.NETCore.App 6.0.5
03. Microsoft.AspNetCore.App 6.0.5

Simply download and run the MyPortfolio.UserInterface project.

There is a DataGenerator Console App added inside the (Solution)/05-Tests/Data folder. You can run it and provide a start date so that you can generate mock trade data from the given date. Existing mock data is from 1st Jan 2021.

Please note that AlphaVantage has limited the API requests to 5 per minute and 500 requests per day. Therefore mock data is limited to 5 types of equities.

## Objective of the application
Application should have the following features:
1.	Read portfolio information from persistent storage
2.	Retrieve market prices (stock quotes) from one of the market data providers
3.	Display portfolio performance related information

## Suggested implementation details
The following list of suggestions is to help understanding the scope of the project but is not a list of the requirements. The applicant is encouraged to use his/her best judgment to modify or use different techniques/data structures, etc. as he/she sees fit.
1.	An XML file (or multiple XML files) can be used as a persistent storage for portfolio related information.
2.	See PortfolioSample.xlsx for an idea of the data to be captured and the report to generate (we would appreciate if you can think beyond what’s in this spreadsheet).
3.	Market Prices (stock quotes) can be retrieved with publicly available APIs from Alpha Vantage or others (google is your friend here).
4.	Applicant is encouraged to build a .net based application (check with the interviewer if you decided to use other languages/technologies).