USE CoffeeMachineManager;

DROP TABLE IF EXISTS [dbo].[Users] -- Only for testing.

CREATE TABLE [dbo].[Users]
(
	[Id] INT IDENTITY PRIMARY KEY,
	[Email] NVARCHAR(320) UNIQUE NOT NULL,
	[Password] NCHAR(64) NOT NULL,
	[Role] NVARCHAR(20) NOT NULL
)