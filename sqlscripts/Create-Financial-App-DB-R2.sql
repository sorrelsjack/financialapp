CREATE DATABASE financedata;
GO

USE [financedata]
GO

/****** Object: Table [dbo].[Stocks] Script Date: 8/28/2018 1:23:40 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Stocks] (
    [StockID]     INT           IDENTITY (1, 1) NOT NULL,
    [StockSymbol] VARCHAR (10)  NOT NULL,
    [StockName]   VARCHAR (255) NULL
);

USE [financedata]
GO

/****** Object: Table [dbo].[HistoricData] Script Date: 8/28/2018 1:23:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[HistoricData] (
    [DateID]      INT             IDENTITY (1, 1) NOT NULL,
    [ActualDate]  DATE            NULL,
    [StockID]     INT             NOT NULL,
    [OpenValue]   DECIMAL (18, 4) NULL,
    [HighValue]   DECIMAL (18, 4) NULL,
    [LowValue]    DECIMAL (18, 4) NULL,
    [CloseValue]  DECIMAL (18, 4) NULL,
    [VolumeValue] INT             NULL
);

INSERT INTO financedata.dbo.Stocks(StockSymbol, StockName)
VALUES ('AMZN', 'Amazon.com Inc'),
('TSLA', 'Tesla Inc'),
('MSFT', 'Microsoft Corporation');

INSERT INTO financedata.dbo.HistoricData(ActualDate, StockID, OpenValue, HighValue, LowValue, CloseValue, VolumeValue) 
VALUES ('2018-09-06', (select StockID from Stocks where StockSymbol = 'TSLA'), '284.8', '291.17', '278.88', '280.95', '7480760'),
('2018-09-05', (select StockID from Stocks where StockSymbol = 'TSLA'), '285.05', '286.78', '277.18', '280.74', '7720821'),
('2018-09-05', (select StockID from Stocks where StockSymbol = 'AMZN'), '2038.11', '2030.38', '1989.89', '1994.82', '8220576'),
('2018-09-05', (select StockID from Stocks where StockSymbol = 'MSFT'), '111.01', '111.42', '108.1', '108.49', '32872352');

USE [financedata]
GO

/****** Object: SqlProcedure [dbo].[DGVByDate] Script Date: 8/28/2018 1:24:45 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE DGVByDate
	@ActualDate date

AS
	SELECT StockSymbol, StockName, ActualDate, OpenValue, HighValue, LowValue, CloseValue, VolumeValue FROM financedata.dbo.Stocks INNER JOIN financedata.dbo.HistoricData on financedata.dbo.Stocks.StockID = financedata.dbo.HistoricData.StockID WHERE ActualDate = @ActualDate ORDER BY StockSymbol ASC;


GO

/****** Object: SqlProcedure [dbo].[RefreshDGV] Script Date: 8/28/2018 1:25:02 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE RefreshDGV
	@StockSymbol varchar(10),
	@ActualDate date,
	@OpenValue decimal (18, 4),
	@HighValue decimal (18, 4),
	@LowValue decimal (18, 4),
	@CloseValue decimal (18, 4),
	@VolumeValue int

AS
	IF NOT EXISTS (SELECT ActualDate FROM financedata.dbo.HistoricData WHERE ActualDate = @ActualDate AND StockID = (SELECT StockID FROM financedata.dbo.Stocks WHERE StockSymbol = @StockSymbol))
	BEGIN
	INSERT INTO financedata.dbo.HistoricData (ActualDate, StockID, OpenValue, HighValue, LowValue, CloseValue, VolumeValue) VALUES (@ActualDate, (SELECT StockID FROM financedata.dbo.Stocks WHERE StockSymbol = @StockSymbol), @OpenValue, @HighValue, @LowValue, @CloseValue, @VolumeValue)
	END

	ELSE
	UPDATE financedata.dbo.HistoricData
	SET OpenValue = @OpenValue, HighValue = @HighValue, LowValue = @LowValue, CloseValue = @CloseValue, VolumeValue = @VolumeValue
	WHERE ActualDate = @ActualDate AND StockID = (SELECT StockID FROM financedata.dbo.Stocks WHERE StockSymbol = @StockSymbol);


GO

/****** Object: SqlProcedure [dbo].[InsertDGV] Script Date: 8/28/2018 1:24:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE InsertDGV
	@StockSymbol varchar(10),
	@StockName varchar(255),
	@ActualDate date,
	@OpenValue decimal (18, 4),
	@HighValue decimal (18, 4),
	@LowValue decimal (18, 4),
	@CloseValue decimal (18, 4),
	@VolumeValue int

AS
	INSERT INTO financedata.dbo.Stocks (StockSymbol, StockName) SELECT @StockSymbol, @StockName
	WHERE NOT EXISTS (SELECT StockSymbol FROM financedata.dbo.Stocks WHERE StockSymbol = @StockSymbol);

	IF NOT EXISTS (SELECT ActualDate FROM financedata.dbo.HistoricData WHERE ActualDate = @ActualDate AND StockID = (SELECT StockID FROM financedata.dbo.Stocks WHERE StockSymbol = @StockSymbol))
	BEGIN
	INSERT INTO financedata.dbo.HistoricData (ActualDate, StockID, OpenValue, HighValue, LowValue, CloseValue, VolumeValue) VALUES (@ActualDate, (SELECT StockID FROM financedata.dbo.Stocks WHERE StockSymbol = @StockSymbol), @OpenValue, @HighValue, @LowValue, @CloseValue, @VolumeValue)
	END


GO

/****** Object: SqlProcedure [dbo].[DGVBySymbol] Script Date: 8/28/2018 1:24:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE DGVBySymbol
	@StockSymbol varchar(10)

AS
	SELECT StockSymbol, StockName, ActualDate, OpenValue, HighValue, LowValue, CloseValue, VolumeValue FROM financedata.dbo.Stocks INNER JOIN financedata.dbo.HistoricData on financedata.dbo.Stocks.StockID = financedata.dbo.HistoricData.StockID WHERE StockSymbol = @StockSymbol ORDER BY ActualDate ASC;


