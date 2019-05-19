
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/19/2019 21:23:21
-- Generated from EDMX file: C:\Users\alexeyshpavda\Desktop\GardenerKlondike\GardenerKlondike.Entity\GardenerKlondike.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Articles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Articles];
GO
IF OBJECT_ID(N'[dbo].[Goals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Goals];
GO
IF OBJECT_ID(N'[dbo].[CalendarEvents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CalendarEvents];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Articles'
CREATE TABLE [dbo].[Articles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Body] nvarchar(max)  NOT NULL,
    [Author] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Goals'
CREATE TABLE [dbo].[Goals] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Note] nvarchar(max)  NOT NULL,
    [IsCompleted] bit  NOT NULL,
    [User] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CalendarEvents'
CREATE TABLE [dbo].[CalendarEvents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Subject] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Start] datetime  NOT NULL,
    [End] datetime  NULL,
    [ThemeColor] nvarchar(max)  NULL,
    [IsFullDay] bit  NOT NULL,
    [User] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Articles'
ALTER TABLE [dbo].[Articles]
ADD CONSTRAINT [PK_Articles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Goals'
ALTER TABLE [dbo].[Goals]
ADD CONSTRAINT [PK_Goals]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CalendarEvents'
ALTER TABLE [dbo].[CalendarEvents]
ADD CONSTRAINT [PK_CalendarEvents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------