CREATE TABLE [dbo].[SalesOrder] (
  [SalesOrderID] INT IDENTITY(1, 1) NOT NULL,
  [CustomerID] INT NOT NULL,
  CONSTRAINT [PK_SalesOrder] PRIMARY KEY CLUSTERED (
    [SalesOrderID]
  ),
  CONSTRAINT [FK_SalesOrder_Customer] FOREIGN KEY (
    [CustomerID]
  ) REFERENCES [dbo].[Customer] (
    [CustomerID]
  )
);
