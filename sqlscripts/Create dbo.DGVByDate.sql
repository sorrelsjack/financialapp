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
