CREATE TABLE [dbo].[Recipe] (
    [recipeId]    INT           IDENTITY (1, 1) NOT NULL,
    [userId]      INT           NOT NULL,
    [categoryId]  INT           NOT NULL,
    [name]        VARCHAR (50)  NOT NULL,
    [picture]     VARCHAR (MAX) NOT NULL,
    [calories]    INT           NOT NULL,
    [preparation] VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Recipe] PRIMARY KEY CLUSTERED ([recipeId] ASC),
    CONSTRAINT [FK_Recipe_2_CategoryRecipe] FOREIGN KEY ([categoryId]) REFERENCES [dbo].[CategoryRecipe] ([categoryId]),
    CONSTRAINT [FK_Recipe_2_User] FOREIGN KEY ([userId]) REFERENCES [dbo].[Users] ([userId])
);

