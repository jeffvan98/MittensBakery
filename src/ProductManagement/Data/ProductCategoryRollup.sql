CREATE TABLE [dbo].[ProductCategoryRollup] (
  [ProductCategoryID] INT NOT NULL,
  [ProductSubcategoryID] INT NOT NULL,
  CONSTRAINT [PK_ProductCategoryRollup] PRIMARY KEY CLUSTERED (
    [ProductCategoryID],
    [ProductSubcategoryID]
  ),
  CONSTRAINT [FK_ProductCategoryRollup_ProductCategory] FOREIGN KEY (
    [ProductCategoryID]
  ) REFERENCES [dbo].[ProductCategory] (
    [ProductCategoryID]
  ),
  CONSTRAINT [FK_ProductCategoryRollup_ProductSubcategory] FOREIGN KEY (
    [ProductSubcategoryID]
  ) REFERENCES [dbo].[ProductCategory] (
    [ProductCategoryID]
  )
);
