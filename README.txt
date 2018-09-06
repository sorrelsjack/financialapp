# financialapp
This app, creatively titled "Financal App" is a C# CRUD (sans Delete) application that calls APIs to provide stock quotes, which are stored in a local SQL database.

The "SQL Scripts" folder contains the MSSQL scripts required to reproduce the structure and stored procedures of my local database, without actual data, unfortunately. On my machine, the DB was called "financaldata", so to mitigate issues, it would be best to name your version of the DB following this convention. This is because, in the code, my SQL queries make reference to "financialdata.dbo.X".

The "C Sharp Files" folder contains all relevant files I used to develop the app in Visual Studio, including those that are used in designing the forms.
