
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/26/2023 19:14:53
-- Generated from EDMX file: C:\Users\Administrador\source\repos\practica-mad-mad01\Model\PracticaMaD.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PracticaMaD];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ImagenUserProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ImagenSet] DROP CONSTRAINT [FK_ImagenUserProfile];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoríaImagenSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ImagenSet] DROP CONSTRAINT [FK_CategoríaImagenSet];
GO
IF OBJECT_ID(N'[dbo].[FK_LikeImagenSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LikeSet] DROP CONSTRAINT [FK_LikeImagenSet];
GO
IF OBJECT_ID(N'[dbo].[FK_LikeUserProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LikeSet] DROP CONSTRAINT [FK_LikeUserProfile];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ImagenSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ImagenSet];
GO
IF OBJECT_ID(N'[dbo].[UserProfile]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserProfile];
GO
IF OBJECT_ID(N'[dbo].[CategoríaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategoríaSet];
GO
IF OBJECT_ID(N'[dbo].[LikeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LikeSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ImagenSet'
CREATE TABLE [dbo].[ImagenSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titulo] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [FechaDeSubida] datetime  NOT NULL,
    [Apertura] nvarchar(max)  NOT NULL,
    [TExposicion] nvarchar(max)  NOT NULL,
    [ISO] nvarchar(max)  NOT NULL,
    [WB] nvarchar(max)  NOT NULL,
    [usrId] bigint  NOT NULL,
    [Data] varbinary(max)  NOT NULL,
    [CategoríaId] int  NOT NULL
);
GO

-- Creating table 'UserProfile'
CREATE TABLE [dbo].[UserProfile] (
    [usrId] bigint IDENTITY(1,1) NOT NULL,
    [loginName] varchar(30)  NOT NULL,
    [enPassword] varchar(50)  NOT NULL,
    [firstName] varchar(30)  NOT NULL,
    [lastName] varchar(40)  NOT NULL,
    [email] varchar(60)  NOT NULL,
    [language] varchar(2)  NOT NULL,
    [country] varchar(2)  NOT NULL,
    [AsociadoId] int  NOT NULL
);
GO

-- Creating table 'CategoríaSet'
CREATE TABLE [dbo].[CategoríaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'LikeSet'
CREATE TABLE [dbo].[LikeSet] (
    [likeId] int IDENTITY(1,1) NOT NULL,
    [ImagenSetId] int  NOT NULL,
    [UserProfile_usrId] bigint  NOT NULL
);
GO

-- Creating table 'ComentarioSet'
CREATE TABLE [dbo].[ComentarioSet] (
    [comentarioId] int IDENTITY(1,1) NOT NULL,
    [ImagenSetId] int  NOT NULL,
    [UserProfile_usrId] bigint  NOT NULL
);
GO

-- Creating table 'UserProfileUserProfile'
CREATE TABLE [dbo].[UserProfileUserProfile] (
    [UserProfile2_usrId] bigint  NOT NULL,
    [UserProfile1_usrId] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ImagenSet'
ALTER TABLE [dbo].[ImagenSet]
ADD CONSTRAINT [PK_ImagenSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [usrId] in table 'UserProfile'
ALTER TABLE [dbo].[UserProfile]
ADD CONSTRAINT [PK_UserProfile]
    PRIMARY KEY CLUSTERED ([usrId] ASC);
GO

-- Creating primary key on [Id] in table 'CategoríaSet'
ALTER TABLE [dbo].[CategoríaSet]
ADD CONSTRAINT [PK_CategoríaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [likeId] in table 'LikeSet'
ALTER TABLE [dbo].[LikeSet]
ADD CONSTRAINT [PK_LikeSet]
    PRIMARY KEY CLUSTERED ([likeId] ASC);
GO

-- Creating primary key on [comentarioId] in table 'ComentarioSet'
ALTER TABLE [dbo].[ComentarioSet]
ADD CONSTRAINT [PK_ComentarioSet]
    PRIMARY KEY CLUSTERED ([comentarioId] ASC);
GO

-- Creating primary key on [UserProfile2_usrId], [UserProfile1_usrId] in table 'UserProfileUserProfile'
ALTER TABLE [dbo].[UserProfileUserProfile]
ADD CONSTRAINT [PK_UserProfileUserProfile]
    PRIMARY KEY CLUSTERED ([UserProfile2_usrId], [UserProfile1_usrId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [usrId] in table 'ImagenSet'
ALTER TABLE [dbo].[ImagenSet]
ADD CONSTRAINT [FK_ImagenUserProfile]
    FOREIGN KEY ([usrId])
    REFERENCES [dbo].[UserProfile]
        ([usrId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ImagenUserProfile'
CREATE INDEX [IX_FK_ImagenUserProfile]
ON [dbo].[ImagenSet]
    ([usrId]);
GO

-- Creating foreign key on [CategoríaId] in table 'ImagenSet'
ALTER TABLE [dbo].[ImagenSet]
ADD CONSTRAINT [FK_CategoríaImagenSet]
    FOREIGN KEY ([CategoríaId])
    REFERENCES [dbo].[CategoríaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoríaImagenSet'
CREATE INDEX [IX_FK_CategoríaImagenSet]
ON [dbo].[ImagenSet]
    ([CategoríaId]);
GO

-- Creating foreign key on [ImagenSetId] in table 'LikeSet'
ALTER TABLE [dbo].[LikeSet]
ADD CONSTRAINT [FK_LikeImagenSet]
    FOREIGN KEY ([ImagenSetId])
    REFERENCES [dbo].[ImagenSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LikeImagenSet'
CREATE INDEX [IX_FK_LikeImagenSet]
ON [dbo].[LikeSet]
    ([ImagenSetId]);
GO

-- Creating foreign key on [UserProfile_usrId] in table 'LikeSet'
ALTER TABLE [dbo].[LikeSet]
ADD CONSTRAINT [FK_LikeUserProfile]
    FOREIGN KEY ([UserProfile_usrId])
    REFERENCES [dbo].[UserProfile]
        ([usrId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LikeUserProfile'
CREATE INDEX [IX_FK_LikeUserProfile]
ON [dbo].[LikeSet]
    ([UserProfile_usrId]);
GO

-- Creating foreign key on [ImagenSetId] in table 'ComentarioSet'
ALTER TABLE [dbo].[ComentarioSet]
ADD CONSTRAINT [FK_ComentarioImagenSet]
    FOREIGN KEY ([ImagenSetId])
    REFERENCES [dbo].[ImagenSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComentarioImagenSet'
CREATE INDEX [IX_FK_ComentarioImagenSet]
ON [dbo].[ComentarioSet]
    ([ImagenSetId]);
GO

-- Creating foreign key on [UserProfile_usrId] in table 'ComentarioSet'
ALTER TABLE [dbo].[ComentarioSet]
ADD CONSTRAINT [FK_ComentarioUserProfile]
    FOREIGN KEY ([UserProfile_usrId])
    REFERENCES [dbo].[UserProfile]
        ([usrId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComentarioUserProfile'
CREATE INDEX [IX_FK_ComentarioUserProfile]
ON [dbo].[ComentarioSet]
    ([UserProfile_usrId]);
GO

-- Creating foreign key on [UserProfile2_usrId] in table 'UserProfileUserProfile'
ALTER TABLE [dbo].[UserProfileUserProfile]
ADD CONSTRAINT [FK_UserProfileUserProfile_UserProfile]
    FOREIGN KEY ([UserProfile2_usrId])
    REFERENCES [dbo].[UserProfile]
        ([usrId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserProfile1_usrId] in table 'UserProfileUserProfile'
ALTER TABLE [dbo].[UserProfileUserProfile]
ADD CONSTRAINT [FK_UserProfileUserProfile_UserProfile1]
    FOREIGN KEY ([UserProfile1_usrId])
    REFERENCES [dbo].[UserProfile]
        ([usrId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserProfileUserProfile_UserProfile1'
CREATE INDEX [IX_FK_UserProfileUserProfile_UserProfile1]
ON [dbo].[UserProfileUserProfile]
    ([UserProfile1_usrId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------