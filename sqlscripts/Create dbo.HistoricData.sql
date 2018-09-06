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


