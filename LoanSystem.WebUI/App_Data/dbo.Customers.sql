CREATE TABLE [dbo].[Customers] (
    [CustomerID] INT            NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [FirstName]  NVARCHAR (50)  NOT NULL,
    [LastName]   NVARCHAR (50)  NOT NULL,
    [Address]    NVARCHAR (MAX) NOT NULL,
    [City]       NVARCHAR (50)  NULL,
    [State]      NVARCHAR (50)  NULL,
    [ZIP]        INT            NULL,
);

