CREATE TABLE [dbo].[Comment] (
    [recipeId] INT           NOT NULL,
    [userId]   INT           NOT NULL,
    [title]    VARCHAR (MAX) NOT NULL,
    [comment]  VARCHAR (MAX) NOT NULL,
    [mark]     INT           NOT NULL,
    CONSTRAINT [FK_Comment_2_Recipe] FOREIGN KEY ([recipeId]) REFERENCES [dbo].[Recipe] ([recipeId]),
    CONSTRAINT [FK_Comment_2_Users] FOREIGN KEY ([userId]) REFERENCES [dbo].[Users] ([userId])
);

