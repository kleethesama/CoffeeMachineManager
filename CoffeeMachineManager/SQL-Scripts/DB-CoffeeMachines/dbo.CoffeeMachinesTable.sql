USE CoffeeMachineManager;

DROP TABLE IF EXISTS [dbo].[CoffeeMachines] -- Only for testing.

CREATE TABLE [dbo].[CoffeeMachines]
(
    [Id] INT IDENTITY PRIMARY KEY,              -- Primary key with identity increment
    [Location] TINYINT NOT NULL,          -- Location of the coffee machine
    [Type] TINYINT NOT NULL,                  -- Type of coffee machine
    [Status] TINYINT NOT NULL     -- Status of the coffee machine, default to 'Active'
);
