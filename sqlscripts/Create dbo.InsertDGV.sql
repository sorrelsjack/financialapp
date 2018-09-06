USE [financedata]
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
