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


