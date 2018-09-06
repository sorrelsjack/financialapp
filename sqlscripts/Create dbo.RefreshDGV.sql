USE [financedata]
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
