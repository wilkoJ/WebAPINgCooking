CREATE TABLE [dbo].[CategoryRecipe] (
    [categoryId] INT          IDENTITY (1, 1) NOT NULL,
    [name]       VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_CategoryRecipe] PRIMARY KEY CLUSTERED ([categoryId] ASC)
);

