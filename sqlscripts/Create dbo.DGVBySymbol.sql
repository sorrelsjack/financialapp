USE [financedata]
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
