CREATE TABLE [dbo].[Product] (
  [ProductID] INT IDENTITY (1, 1) NOT NULL,
  [Description] NVARCHAR(128) NOT NULL,
  CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED (
    [ProductID] 
  )
);
