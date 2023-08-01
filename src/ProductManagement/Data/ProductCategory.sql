CREATE TABLE [dbo].[ProductCategory] (
  [ProductCategoryID] INT IDENTITY(1, 1) NOT NULL,
  [Description] NVARCHAR(2048) NOT NULL,
  CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED (
    [ProductCategoryID]
  )
);
