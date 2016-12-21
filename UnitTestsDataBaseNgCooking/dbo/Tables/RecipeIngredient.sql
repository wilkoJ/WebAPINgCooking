CREATE TABLE [dbo].[RecipeIngredient] (
    [recipeId]     INT NOT NULL,
    [ingredientId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([recipeId] ASC, [ingredientId] ASC),
    CONSTRAINT [FK_RecipeIngredient_2_Ingredient] FOREIGN KEY ([ingredientId]) REFERENCES [dbo].[Ingredient] ([ingredientId]),
    CONSTRAINT [FK_RecipeIngredient_2_Recipe] FOREIGN KEY ([recipeId]) REFERENCES [dbo].[Recipe] ([recipeId])
);

