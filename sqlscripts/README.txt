These are all the SQL scripts needed for this project. Includes stored procedures and scripts to create the DB, sans data.
Stocks and HistoricData are both tables, where HistoricData depends on Stocks (ie: has a foreign key that refers to a column in Stocks)
The rest are stored procedures, all of which are used in the main C# application.
