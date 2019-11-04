
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/29/2019 16:00:23
-- Generated from EDMX file: C:\Users\billf.PROTOLINK\source\repos\Friends\Friends\FriendsModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FriendsDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_FriendAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Addresses] DROP CONSTRAINT [FK_FriendAddress];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Friends]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Friends];
GO
IF OBJECT_ID(N'[dbo].[Addresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Addresses];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Friends'
CREATE TABLE [dbo].[Friends] (
    [FriendId] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [MiddleName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [AdressId] int IDENTITY(1,1) NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL,
    [ZipCode] nvarchar(max)  NOT NULL,
    [Address1] nvarchar(max)  NOT NULL,
    [Address2] nvarchar(max)  NOT NULL,
    [Friend_FriendId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [FriendId] in table 'Friends'
ALTER TABLE [dbo].[Friends]
ADD CONSTRAINT [PK_Friends]
    PRIMARY KEY CLUSTERED ([FriendId] ASC);
GO

-- Creating primary key on [AdressId] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([AdressId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Friend_FriendId] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [FK_FriendAddress]
    FOREIGN KEY ([Friend_FriendId])
    REFERENCES [dbo].[Friends]
        ([FriendId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FriendAddress'
CREATE INDEX [IX_FK_FriendAddress]
ON [dbo].[Addresses]
    ([Friend_FriendId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------