CREATE TABLE [dbo].[SalesOrderLineItem]
(
  [SalesOrderID] INT NOT NULL,
  [SalesOrderLineItemID] INT IDENTITY(1, 1) NOT NULL,
  [ProductID] INT NOT NULL,
  CONSTRAINT [PK_SalesOrderLineItem] PRIMARY KEY CLUSTERED (
    [SalesOrderID],
    [SalesOrderLineItemID]
  ),
  CONSTRAINT [FK_SalesOrderLineItem_SalesOrder] FOREIGN KEY (
    [SalesOrderID]
  ) REFERENCES [dbo].[SalesOrder] (
    [SalesOrderID]
  ),
  CONSTRAINT [FK_SalesOrderLineItem_Product] FOREIGN KEY (
    [ProductID]
  ) REFERENCES [dbo].[Product] (
    [ProductID]
  )
);
