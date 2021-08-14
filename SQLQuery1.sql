
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/06/2021 12:02:17
-- Generated from EDMX file: D:\Project\FIT5032_MyJs\Models\User.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderSet] DROP CONSTRAINT [FK_UserOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_HeritageOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderSet] DROP CONSTRAINT [FK_HeritageOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_AdminOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderSet] DROP CONSTRAINT [FK_AdminOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_AdminHeritage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HeritageSet] DROP CONSTRAINT [FK_AdminHeritage];
GO
IF OBJECT_ID(N'[dbo].[FK_AdminUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet] DROP CONSTRAINT [FK_AdminUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[AdminSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdminSet];
GO
IF OBJECT_ID(N'[dbo].[OrderSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderSet];
GO
IF OBJECT_ID(N'[dbo].[HeritageSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HeritageSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AdminSet'
CREATE TABLE [dbo].[AdminSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [password] nvarchar(max)  NOT NULL,
    [aname] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'OrderSet'
CREATE TABLE [dbo].[OrderSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [user_id] int  NOT NULL,
    [heritage_id] int  NOT NULL,
    [create_time] datetime  NOT NULL,
    [detail] nvarchar(max)  NOT NULL,
    [UserId] int  NOT NULL,
    [HeritageId] int  NOT NULL,
    [AdminId] int  NOT NULL
);
GO

-- Creating table 'HeritageSet'
CREATE TABLE [dbo].[HeritageSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [hname] nvarchar(max)  NOT NULL,
    [address] nvarchar(max)  NOT NULL,
    [pic] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AdminSet'
ALTER TABLE [dbo].[AdminSet]
ADD CONSTRAINT [PK_AdminSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [PK_OrderSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HeritageSet'
ALTER TABLE [dbo].[HeritageSet]
ADD CONSTRAINT [PK_HeritageSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [FK_UserOrder]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserOrder'
CREATE INDEX [IX_FK_UserOrder]
ON [dbo].[OrderSet]
    ([UserId]);
GO

-- Creating foreign key on [HeritageId] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [FK_HeritageOrder]
    FOREIGN KEY ([HeritageId])
    REFERENCES [dbo].[HeritageSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HeritageOrder'
CREATE INDEX [IX_FK_HeritageOrder]
ON [dbo].[OrderSet]
    ([HeritageId]);
GO

-- Creating foreign key on [AdminId] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [FK_AdminOrder]
    FOREIGN KEY ([AdminId])
    REFERENCES [dbo].[AdminSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdminOrder'
CREATE INDEX [IX_FK_AdminOrder]
ON [dbo].[OrderSet]
    ([AdminId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------