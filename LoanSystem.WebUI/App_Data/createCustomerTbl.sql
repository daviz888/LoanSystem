CREATE TABLE [dbo].[Customers] (
    [CustomerID] INT            NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [FirstName]  NVARCHAR (150)  NOT NULL,
    [LastName]   NVARCHAR (150)  NOT NULL,
    [Address]    NVARCHAR (250) NOT NULL,
    [City]       NVARCHAR (100)  NULL,
    [State]      NVARCHAR (100)  NULL,
    [ZIP]        INT            NULL,
);
