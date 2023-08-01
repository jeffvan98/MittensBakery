CREATE TABLE [dbo].[ProductCategoryClassification] (
  [ProductID] INT NOT NULL,
  [ProductCategoryID] INT NOT NULL,
  [FromDate] DATE NOT NULL,
  [ThruDate] DATE NULL,
  [PrimaryFlag] BIT NOT NULL,
  [Comment] NVARCHAR(2048),
  CONSTRAINT [PK_ProductCategoryClassification] PRIMARY KEY CLUSTERED (
    [ProductID],
    [ProductCategoryID],
    [FromDate]
  ),
  CONSTRAINT [FK_ProductCategoryClassification_Product] FOREIGN KEY (
    [ProductID]
  ) REFERENCES [dbo].[Product] (
    [ProductID]
  ),
  CONSTRAINT [FK_ProductCategoryClassification_ProductCategory] FOREIGN KEY (
    [ProductCategoryID]
  ) REFERENCES [dbo].[ProductCategory] (
    [ProductCategoryID]
  )
);
