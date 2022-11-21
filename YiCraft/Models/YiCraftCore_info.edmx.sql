
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/21/2022 15:34:14
-- Generated from EDMX file: D:\MEOW\Progect\YiCraft-main\YiCraft\Models\YiCraftCore_info.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [YiCraftCore];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[discuss_infos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[discuss_infos];
GO
IF OBJECT_ID(N'[dbo].[player_infos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[player_infos];
GO
IF OBJECT_ID(N'[dbo].[reply_infos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[reply_infos];
GO
IF OBJECT_ID(N'[dbo].[whitelistquestion_infos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[whitelistquestion_infos];
GO
IF OBJECT_ID(N'[dbo].[yicraft_infos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[yicraft_infos];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'discuss_infos'
CREATE TABLE [dbo].[discuss_infos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [theme] nvarchar(max)  NOT NULL,
    [AllContent] nvarchar(max)  NOT NULL,
    [time] nvarchar(50)  NOT NULL,
    [author] nvarchar(50)  NOT NULL,
    [solve] nvarchar(5)  NULL
);
GO

-- Creating table 'player_infos'
CREATE TABLE [dbo].[player_infos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [uid] nvarchar(50)  NOT NULL,
    [pwd] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'reply_infos'
CREATE TABLE [dbo].[reply_infos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [theme_id] int  NOT NULL,
    [reply] nvarchar(max)  NOT NULL,
    [ReplyAuthor] nvarchar(50)  NOT NULL,
    [ReplyTime] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'whitelistquestion_infos'
CREATE TABLE [dbo].[whitelistquestion_infos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [question] nvarchar(max)  NOT NULL,
    [A] nvarchar(max)  NOT NULL,
    [B] nvarchar(max)  NOT NULL,
    [C] nvarchar(max)  NOT NULL,
    [D] nvarchar(max)  NOT NULL,
    [answer] nvarchar(5)  NOT NULL
);
GO

-- Creating table 'yicraft_infos'
CREATE TABLE [dbo].[yicraft_infos] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [loginname] nvarchar(50)  NOT NULL,
    [mail] nvarchar(50)  NOT NULL,
    [actualname] nvarchar(10)  NULL,
    [idcard] int  NULL,
    [age] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'discuss_infos'
ALTER TABLE [dbo].[discuss_infos]
ADD CONSTRAINT [PK_discuss_infos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'player_infos'
ALTER TABLE [dbo].[player_infos]
ADD CONSTRAINT [PK_player_infos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'reply_infos'
ALTER TABLE [dbo].[reply_infos]
ADD CONSTRAINT [PK_reply_infos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'whitelistquestion_infos'
ALTER TABLE [dbo].[whitelistquestion_infos]
ADD CONSTRAINT [PK_whitelistquestion_infos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [ID] in table 'yicraft_infos'
ALTER TABLE [dbo].[yicraft_infos]
ADD CONSTRAINT [PK_yicraft_infos]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------