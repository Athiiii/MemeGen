
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/30/2019 22:36:30
-- Generated from EDMX file: C:\Users\Athavan\source\repos\MGMDB\MGMDB\MGM.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MGM];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MemesTag_Memes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MemesTag] DROP CONSTRAINT [FK_MemesTag_Memes];
GO
IF OBJECT_ID(N'[dbo].[FK_MemesTag_Tag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MemesTag] DROP CONSTRAINT [FK_MemesTag_Tag];
GO
IF OBJECT_ID(N'[dbo].[FK_TemplateMemes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MemesSet] DROP CONSTRAINT [FK_TemplateMemes];
GO
IF OBJECT_ID(N'[dbo].[FK_TemplateTag_Tag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TemplateTag] DROP CONSTRAINT [FK_TemplateTag_Tag];
GO
IF OBJECT_ID(N'[dbo].[FK_TemplateTag_Template]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TemplateTag] DROP CONSTRAINT [FK_TemplateTag_Template];
GO
IF OBJECT_ID(N'[dbo].[FK_UsersMemes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MemesSet] DROP CONSTRAINT [FK_UsersMemes];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[MemesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MemesSet];
GO
IF OBJECT_ID(N'[dbo].[MemesTag]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MemesTag];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[TagSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TagSet];
GO
IF OBJECT_ID(N'[dbo].[TemplateSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TemplateSet];
GO
IF OBJECT_ID(N'[dbo].[TemplateTag]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TemplateTag];
GO
IF OBJECT_ID(N'[dbo].[UsersSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'MemesSet'
CREATE TABLE [dbo].[MemesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ImagePath] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Top] nvarchar(max)  NOT NULL,
    [Bottom] nvarchar(max)  NOT NULL,
    [FontSize] int  NOT NULL,
    [Watermark] nvarchar(max)  NOT NULL,
    [Created] datetime  NOT NULL,
    [Updated] datetime  NOT NULL,
    [Template_Id] int  NULL,
    [Users_Id] int  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'TagSet'
CREATE TABLE [dbo].[TagSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TemplateSet'
CREATE TABLE [dbo].[TemplateSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [ImagePath] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UsersSet'
CREATE TABLE [dbo].[UsersSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Mail] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MemesTag'
CREATE TABLE [dbo].[MemesTag] (
    [MemesSet_Id] int  NOT NULL,
    [TagSet_Id] int  NOT NULL
);
GO

-- Creating table 'TemplateTag'
CREATE TABLE [dbo].[TemplateTag] (
    [TagSet_Id] int  NOT NULL,
    [TemplateSet_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'MemesSet'
ALTER TABLE [dbo].[MemesSet]
ADD CONSTRAINT [PK_MemesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Id] in table 'TagSet'
ALTER TABLE [dbo].[TagSet]
ADD CONSTRAINT [PK_TagSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TemplateSet'
ALTER TABLE [dbo].[TemplateSet]
ADD CONSTRAINT [PK_TemplateSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersSet'
ALTER TABLE [dbo].[UsersSet]
ADD CONSTRAINT [PK_UsersSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [MemesSet_Id], [TagSet_Id] in table 'MemesTag'
ALTER TABLE [dbo].[MemesTag]
ADD CONSTRAINT [PK_MemesTag]
    PRIMARY KEY CLUSTERED ([MemesSet_Id], [TagSet_Id] ASC);
GO

-- Creating primary key on [TagSet_Id], [TemplateSet_Id] in table 'TemplateTag'
ALTER TABLE [dbo].[TemplateTag]
ADD CONSTRAINT [PK_TemplateTag]
    PRIMARY KEY CLUSTERED ([TagSet_Id], [TemplateSet_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Template_Id] in table 'MemesSet'
ALTER TABLE [dbo].[MemesSet]
ADD CONSTRAINT [FK_TemplateMemes]
    FOREIGN KEY ([Template_Id])
    REFERENCES [dbo].[TemplateSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TemplateMemes'
CREATE INDEX [IX_FK_TemplateMemes]
ON [dbo].[MemesSet]
    ([Template_Id]);
GO

-- Creating foreign key on [Users_Id] in table 'MemesSet'
ALTER TABLE [dbo].[MemesSet]
ADD CONSTRAINT [FK_UsersMemes]
    FOREIGN KEY ([Users_Id])
    REFERENCES [dbo].[UsersSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsersMemes'
CREATE INDEX [IX_FK_UsersMemes]
ON [dbo].[MemesSet]
    ([Users_Id]);
GO

-- Creating foreign key on [MemesSet_Id] in table 'MemesTag'
ALTER TABLE [dbo].[MemesTag]
ADD CONSTRAINT [FK_MemesTag_MemesSet]
    FOREIGN KEY ([MemesSet_Id])
    REFERENCES [dbo].[MemesSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TagSet_Id] in table 'MemesTag'
ALTER TABLE [dbo].[MemesTag]
ADD CONSTRAINT [FK_MemesTag_TagSet]
    FOREIGN KEY ([TagSet_Id])
    REFERENCES [dbo].[TagSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MemesTag_TagSet'
CREATE INDEX [IX_FK_MemesTag_TagSet]
ON [dbo].[MemesTag]
    ([TagSet_Id]);
GO

-- Creating foreign key on [TagSet_Id] in table 'TemplateTag'
ALTER TABLE [dbo].[TemplateTag]
ADD CONSTRAINT [FK_TemplateTag_TagSet]
    FOREIGN KEY ([TagSet_Id])
    REFERENCES [dbo].[TagSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TemplateSet_Id] in table 'TemplateTag'
ALTER TABLE [dbo].[TemplateTag]
ADD CONSTRAINT [FK_TemplateTag_TemplateSet]
    FOREIGN KEY ([TemplateSet_Id])
    REFERENCES [dbo].[TemplateSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TemplateTag_TemplateSet'
CREATE INDEX [IX_FK_TemplateTag_TemplateSet]
ON [dbo].[TemplateTag]
    ([TemplateSet_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------