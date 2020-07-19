USE [LoanSystem]
GO

INSERT INTO [dbo].[Customers]
           ([CustomerID]
           ,[FirstName]
           ,[LastName]
           ,[Address]
           ,[City]
           ,[State]
           ,[ZIP])
     VALUES
           (<CustomerID, int,>
           ,<FirstName, nvarchar(50),>
           ,<LastName, nvarchar(50),>
           ,<Address, nvarchar(max),>
           ,<City, nvarchar(50),>
           ,<State, nvarchar(50),>
           ,<ZIP, int,>)
GO

