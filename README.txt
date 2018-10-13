# financialapp
This app, creatively titled "Financal App" is a C# CRUD (sans Delete) application that calls APIs to provide stock quotes, which are stored in a local SQL database.

The "SQL Scripts" folder contains the MSSQL scripts required to reproduce the structure and stored procedures of my local database, including a small amount of data. On my machine, the DB was called "financaldata", so to mitigate issues, it would be best to name your version of the DB following this convention. This is because, in the code, my SQL queries make reference to "financialdata.dbo.X".

To successfully build this application, run the script called "Create-Financial-App-DB-R2.sql" in the sqlscripts folder. Then, in Form1.cs, change the connectionString variable to be in accordance with the creation of this database.
