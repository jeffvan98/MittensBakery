CREATE TABLE [dbo].[Product] (
  [ProductID] INT IDENTITY(1, 1) NOT NULL,
  [Name] NVARCHAR(256) NOT NULL,
  [IntroductionDate] DATE NULL,
  [SalesDiscontinuationDate] DATE NULL,
  [SupportDiscontinuationDate] DATE NULL,
  [Comment] NVARCHAR(2048) NULL,
  CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED (
    [ProductID]
  )
);
