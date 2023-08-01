CREATE TABLE [dbo].[MarketInterest] (
  [ProductCategoryID] INT NOT NULL,
  [PartyTypeID] INT NOT NULL,
  [FromDate] DATE NOT NULL,
  [ThruDate] DATE NULL,
  CONSTRAINT [PK_MarketInterest] PRIMARY KEY CLUSTERED (
    [ProductCategoryID],
    [PartyTypeID],
    [FromDate]
  ),
  CONSTRAINT [FK_MarketInterest_ProductCategory] FOREIGN KEY (
    [ProductCategoryID]
  ) REFERENCES [dbo].[ProductCategory] (
    [ProductCategoryID]
  ),
  CONSTRAINT [FK_MarketInterest_PartyType] FOREIGN KEY (
    [PartyTypeID]
  ) REFERENCES [dbo].[PartyType] (
    [PartyTypeID]
  )
);
