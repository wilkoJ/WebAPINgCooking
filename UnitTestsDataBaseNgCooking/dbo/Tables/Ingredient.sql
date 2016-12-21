CREATE TABLE [dbo].[Ingredient] (
    [ingredientId] INT           IDENTITY (1, 1) NOT NULL,
    [categoryId]   INT           NOT NULL,
    [name]         VARCHAR (50)  NOT NULL,
    [picture]      VARCHAR (MAX) NOT NULL,
    [calories]     INT           NOT NULL,
    CONSTRAINT [PK_Ingredient] PRIMARY KEY CLUSTERED ([ingredientId] ASC),
    CONSTRAINT [FK_Ingredient_2_CategoryIngredient] FOREIGN KEY ([categoryId]) REFERENCES [dbo].[CategoryIngredient] ([categoryId])
);

