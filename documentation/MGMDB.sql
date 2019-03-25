
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/25/2019 22:45:34
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


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
    [Template_Id] int  NOT NULL,
    [Users_Id] int  NOT NULL
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

-- Creating table 'MemesTag'
CREATE TABLE [dbo].[MemesTag] (
    [Memes_Id] int  NOT NULL,
    [Tag_Id] int  NOT NULL
);
GO

-- Creating table 'TemplateTag'
CREATE TABLE [dbo].[TemplateTag] (
    [Template_Id] int  NOT NULL,
    [Tag_Id] int  NOT NULL
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

-- Creating primary key on [Id] in table 'UsersSet'
ALTER TABLE [dbo].[UsersSet]
ADD CONSTRAINT [PK_UsersSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
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

-- Creating primary key on [Memes_Id], [Tag_Id] in table 'MemesTag'
ALTER TABLE [dbo].[MemesTag]
ADD CONSTRAINT [PK_MemesTag]
    PRIMARY KEY CLUSTERED ([Memes_Id], [Tag_Id] ASC);
GO

-- Creating primary key on [Template_Id], [Tag_Id] in table 'TemplateTag'
ALTER TABLE [dbo].[TemplateTag]
ADD CONSTRAINT [PK_TemplateTag]
    PRIMARY KEY CLUSTERED ([Template_Id], [Tag_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Memes_Id] in table 'MemesTag'
ALTER TABLE [dbo].[MemesTag]
ADD CONSTRAINT [FK_MemesTag_Memes]
    FOREIGN KEY ([Memes_Id])
    REFERENCES [dbo].[MemesSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Tag_Id] in table 'MemesTag'
ALTER TABLE [dbo].[MemesTag]
ADD CONSTRAINT [FK_MemesTag_Tag]
    FOREIGN KEY ([Tag_Id])
    REFERENCES [dbo].[TagSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MemesTag_Tag'
CREATE INDEX [IX_FK_MemesTag_Tag]
ON [dbo].[MemesTag]
    ([Tag_Id]);
GO

-- Creating foreign key on [Template_Id] in table 'TemplateTag'
ALTER TABLE [dbo].[TemplateTag]
ADD CONSTRAINT [FK_TemplateTag_Template]
    FOREIGN KEY ([Template_Id])
    REFERENCES [dbo].[TemplateSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Tag_Id] in table 'TemplateTag'
ALTER TABLE [dbo].[TemplateTag]
ADD CONSTRAINT [FK_TemplateTag_Tag]
    FOREIGN KEY ([Tag_Id])
    REFERENCES [dbo].[TagSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TemplateTag_Tag'
CREATE INDEX [IX_FK_TemplateTag_Tag]
ON [dbo].[TemplateTag]
    ([Tag_Id]);
GO

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

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------