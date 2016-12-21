CREATE TABLE [dbo].[CategoryIngredient] (
    [categoryId] INT          IDENTITY (1, 1) NOT NULL,
    [name]       VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_CategoryIngredient] PRIMARY KEY CLUSTERED ([categoryId] ASC)
);

