CREATE TABLE [dbo].[PartyType] (
  [PartyTypeID] INT IDENTITY(1, 1) NOT NULL,
  [Descrption] NVARCHAR(512) NOT NULL,
  CONSTRAINT [PK_PartyType] PRIMARY KEY CLUSTERED(
    [PartyTypeID]
  )
);
