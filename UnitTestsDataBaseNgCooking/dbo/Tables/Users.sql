CREATE TABLE [dbo].[Users] (
    [userId]    INT           IDENTITY (1, 1) NOT NULL,
    [firstname] VARCHAR (50)  NOT NULL,
    [surname]   VARCHAR (50)  NOT NULL,
    [email]     VARCHAR (100) NOT NULL,
    [password]  VARCHAR (100) NOT NULL,
    [rank]      INT           NOT NULL,
    [city]      VARCHAR (100) NOT NULL,
    [picture]   VARCHAR (100) NOT NULL,
    [birth]     INT           NOT NULL,
    [bio]       VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([userId] ASC)
);

