
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/03/2024 16:14:16
-- Generated from EDMX file: C:\Users\dava\source\repos\Práctica final\practica-mad-mad01\Model\PracticaMaD.edmx
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
IF OBJECT_ID(N'[dbo].[FK_ComentarioImagenSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CommentSet] DROP CONSTRAINT [FK_ComentarioImagenSet];
GO
IF OBJECT_ID(N'[dbo].[FK_ComentarioUserProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CommentSet] DROP CONSTRAINT [FK_ComentarioUserProfile];
GO
IF OBJECT_ID(N'[dbo].[FK_UserProfileUserProfile_UserProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserProfileUserProfile] DROP CONSTRAINT [FK_UserProfileUserProfile_UserProfile];
GO
IF OBJECT_ID(N'[dbo].[FK_UserProfileUserProfile_UserProfile1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserProfileUserProfile] DROP CONSTRAINT [FK_UserProfileUserProfile_UserProfile1];
GO
IF OBJECT_ID(N'[dbo].[FK_EXIFImageSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ImagenSet] DROP CONSTRAINT [FK_EXIFImageSet];
GO
IF OBJECT_ID(N'[dbo].[FK_TagImageSet_Tag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TagImageSet] DROP CONSTRAINT [FK_TagImageSet_Tag];
GO
IF OBJECT_ID(N'[dbo].[FK_TagImageSet_ImageSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TagImageSet] DROP CONSTRAINT [FK_TagImageSet_ImageSet];
GO
IF OBJECT_ID(N'[dbo].[FK_UserProfileImageSet_UserProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserProfileImageSet] DROP CONSTRAINT [FK_UserProfileImageSet_UserProfile];
GO
IF OBJECT_ID(N'[dbo].[FK_UserProfileImageSet_ImageSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserProfileImageSet] DROP CONSTRAINT [FK_UserProfileImageSet_ImageSet];
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
IF OBJECT_ID(N'[dbo].[CategorySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CategorySet];
GO
IF OBJECT_ID(N'[dbo].[CommentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CommentSet];
GO
IF OBJECT_ID(N'[dbo].[EXIFSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EXIFSet];
GO
IF OBJECT_ID(N'[dbo].[TagSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TagSet];
GO
IF OBJECT_ID(N'[dbo].[UserProfileUserProfile]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserProfileUserProfile];
GO
IF OBJECT_ID(N'[dbo].[TagImageSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TagImageSet];
GO
IF OBJECT_ID(N'[dbo].[UserProfileImageSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserProfileImageSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ImagenSet'
CREATE TABLE [dbo].[ImagenSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Titulo] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [FechaDeSubida] datetime  NOT NULL,
    [usrId] bigint  NOT NULL,
    [Data] varbinary(max)  NOT NULL,
    [CategoríaId] bigint  NOT NULL,
    [EXIFId] bigint  NOT NULL,
    [numLikes] bigint  NOT NULL,
    [author] nvarchar(max)  NOT NULL
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
    [country] varchar(2)  NOT NULL
);
GO

-- Creating table 'CategorySet'
CREATE TABLE [dbo].[CategorySet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CommentSet'
CREATE TABLE [dbo].[CommentSet] (
    [comentarioId] bigint IDENTITY(1,1) NOT NULL,
    [ImagenSetId] bigint  NOT NULL,
    [UserProfile_usrId] bigint  NOT NULL,
    [Texto] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [author] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EXIFSet'
CREATE TABLE [dbo].[EXIFSet] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Apertura] nvarchar(max)  NOT NULL,
    [TExposicion] nvarchar(max)  NOT NULL,
    [ISO] nvarchar(max)  NOT NULL,
    [WB] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TagSet'
CREATE TABLE [dbo].[TagSet] (
    [TagId] bigint IDENTITY(1,1) NOT NULL,
    [title] nvarchar(max)  NOT NULL,
    [usedTimes] bigint  NOT NULL
);
GO

-- Creating table 'UserProfileUserProfile'
CREATE TABLE [dbo].[UserProfileUserProfile] (
    [Seguido_usrId] bigint  NOT NULL,
    [Seguidor_usrId] bigint  NOT NULL
);
GO

-- Creating table 'TagImageSet'
CREATE TABLE [dbo].[TagImageSet] (
    [Tag_TagId] bigint  NOT NULL,
    [ImageSet_Id] bigint  NOT NULL
);
GO

-- Creating table 'UserProfileImageSet'
CREATE TABLE [dbo].[UserProfileImageSet] (
    [UserProfile1_usrId] bigint  NOT NULL,
    [ImageSet_Id] bigint  NOT NULL
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

-- Creating primary key on [Id] in table 'CategorySet'
ALTER TABLE [dbo].[CategorySet]
ADD CONSTRAINT [PK_CategorySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [comentarioId] in table 'CommentSet'
ALTER TABLE [dbo].[CommentSet]
ADD CONSTRAINT [PK_CommentSet]
    PRIMARY KEY CLUSTERED ([comentarioId] ASC);
GO

-- Creating primary key on [Id] in table 'EXIFSet'
ALTER TABLE [dbo].[EXIFSet]
ADD CONSTRAINT [PK_EXIFSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [TagId] in table 'TagSet'
ALTER TABLE [dbo].[TagSet]
ADD CONSTRAINT [PK_TagSet]
    PRIMARY KEY CLUSTERED ([TagId] ASC);
GO

-- Creating primary key on [Seguido_usrId], [Seguidor_usrId] in table 'UserProfileUserProfile'
ALTER TABLE [dbo].[UserProfileUserProfile]
ADD CONSTRAINT [PK_UserProfileUserProfile]
    PRIMARY KEY CLUSTERED ([Seguido_usrId], [Seguidor_usrId] ASC);
GO

-- Creating primary key on [Tag_TagId], [ImageSet_Id] in table 'TagImageSet'
ALTER TABLE [dbo].[TagImageSet]
ADD CONSTRAINT [PK_TagImageSet]
    PRIMARY KEY CLUSTERED ([Tag_TagId], [ImageSet_Id] ASC);
GO

-- Creating primary key on [UserProfile1_usrId], [ImageSet_Id] in table 'UserProfileImageSet'
ALTER TABLE [dbo].[UserProfileImageSet]
ADD CONSTRAINT [PK_UserProfileImageSet]
    PRIMARY KEY CLUSTERED ([UserProfile1_usrId], [ImageSet_Id] ASC);
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
    REFERENCES [dbo].[CategorySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoríaImagenSet'
CREATE INDEX [IX_FK_CategoríaImagenSet]
ON [dbo].[ImagenSet]
    ([CategoríaId]);
GO

-- Creating foreign key on [ImagenSetId] in table 'CommentSet'
ALTER TABLE [dbo].[CommentSet]
ADD CONSTRAINT [FK_ComentarioImagenSet]
    FOREIGN KEY ([ImagenSetId])
    REFERENCES [dbo].[ImagenSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComentarioImagenSet'
CREATE INDEX [IX_FK_ComentarioImagenSet]
ON [dbo].[CommentSet]
    ([ImagenSetId]);
GO

-- Creating foreign key on [UserProfile_usrId] in table 'CommentSet'
ALTER TABLE [dbo].[CommentSet]
ADD CONSTRAINT [FK_ComentarioUserProfile]
    FOREIGN KEY ([UserProfile_usrId])
    REFERENCES [dbo].[UserProfile]
        ([usrId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComentarioUserProfile'
CREATE INDEX [IX_FK_ComentarioUserProfile]
ON [dbo].[CommentSet]
    ([UserProfile_usrId]);
GO

-- Creating foreign key on [Seguido_usrId] in table 'UserProfileUserProfile'
ALTER TABLE [dbo].[UserProfileUserProfile]
ADD CONSTRAINT [FK_UserProfileUserProfile_UserProfile]
    FOREIGN KEY ([Seguido_usrId])
    REFERENCES [dbo].[UserProfile]
        ([usrId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Seguidor_usrId] in table 'UserProfileUserProfile'
ALTER TABLE [dbo].[UserProfileUserProfile]
ADD CONSTRAINT [FK_UserProfileUserProfile_UserProfile1]
    FOREIGN KEY ([Seguidor_usrId])
    REFERENCES [dbo].[UserProfile]
        ([usrId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserProfileUserProfile_UserProfile1'
CREATE INDEX [IX_FK_UserProfileUserProfile_UserProfile1]
ON [dbo].[UserProfileUserProfile]
    ([Seguidor_usrId]);
GO

-- Creating foreign key on [EXIFId] in table 'ImagenSet'
ALTER TABLE [dbo].[ImagenSet]
ADD CONSTRAINT [FK_EXIFImageSet]
    FOREIGN KEY ([EXIFId])
    REFERENCES [dbo].[EXIFSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EXIFImageSet'
CREATE INDEX [IX_FK_EXIFImageSet]
ON [dbo].[ImagenSet]
    ([EXIFId]);
GO

-- Creating foreign key on [Tag_TagId] in table 'TagImageSet'
ALTER TABLE [dbo].[TagImageSet]
ADD CONSTRAINT [FK_TagImageSet_Tag]
    FOREIGN KEY ([Tag_TagId])
    REFERENCES [dbo].[TagSet]
        ([TagId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ImageSet_Id] in table 'TagImageSet'
ALTER TABLE [dbo].[TagImageSet]
ADD CONSTRAINT [FK_TagImageSet_ImageSet]
    FOREIGN KEY ([ImageSet_Id])
    REFERENCES [dbo].[ImagenSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TagImageSet_ImageSet'
CREATE INDEX [IX_FK_TagImageSet_ImageSet]
ON [dbo].[TagImageSet]
    ([ImageSet_Id]);
GO

-- Creating foreign key on [UserProfile1_usrId] in table 'UserProfileImageSet'
ALTER TABLE [dbo].[UserProfileImageSet]
ADD CONSTRAINT [FK_UserProfileImageSet_UserProfile]
    FOREIGN KEY ([UserProfile1_usrId])
    REFERENCES [dbo].[UserProfile]
        ([usrId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ImageSet_Id] in table 'UserProfileImageSet'
ALTER TABLE [dbo].[UserProfileImageSet]
ADD CONSTRAINT [FK_UserProfileImageSet_ImageSet]
    FOREIGN KEY ([ImageSet_Id])
    REFERENCES [dbo].[ImagenSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserProfileImageSet_ImageSet'
CREATE INDEX [IX_FK_UserProfileImageSet_ImageSet]
ON [dbo].[UserProfileImageSet]
    ([ImageSet_Id]);
GO

INSERT INTO CategorySet(Nombre) VALUES ('Animales');
INSERT INTO CategorySet(Nombre) VALUES ('Música');
INSERT INTO CategorySet(Nombre) VALUES ('Tecnología');
INSERT INTO CategorySet(Nombre) VALUES ('Deportes');






-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------