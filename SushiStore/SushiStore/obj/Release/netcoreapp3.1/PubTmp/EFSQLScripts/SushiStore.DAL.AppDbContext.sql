IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210910073258_addedTables')
BEGIN
    CREATE TABLE [AppParts] (
        [Id] int NOT NULL IDENTITY,
        [Text] nvarchar(max) NULL,
        [MenuImage] nvarchar(max) NULL,
        [AppImage] nvarchar(max) NULL,
        CONSTRAINT [PK_AppParts] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210910073258_addedTables')
BEGIN
    CREATE TABLE [Bios] (
        [Id] int NOT NULL IDENTITY,
        [Logo] nvarchar(max) NULL,
        [Adress] nvarchar(max) NULL,
        [WorkingHours] nvarchar(max) NULL,
        [FbLink] nvarchar(max) NULL,
        [InstagramLink] nvarchar(max) NULL,
        [WhatsappLink] nvarchar(max) NULL,
        [YoutubeLink] nvarchar(max) NULL,
        CONSTRAINT [PK_Bios] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210910073258_addedTables')
BEGIN
    CREATE TABLE [Categories] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [DeletedAt] datetime2 NULL,
        [LastUpdateDate] datetime2 NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210910073258_addedTables')
BEGIN
    CREATE TABLE [Intros] (
        [Id] int NOT NULL IDENTITY,
        [Text] nvarchar(max) NULL,
        [TextBold] nvarchar(max) NULL,
        CONSTRAINT [PK_Intros] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210910073258_addedTables')
BEGIN
    CREATE TABLE [IntroSliders] (
        [Id] int NOT NULL IDENTITY,
        [Image] nvarchar(max) NULL,
        [SliderText] nvarchar(max) NULL,
        CONSTRAINT [PK_IntroSliders] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210910073258_addedTables')
BEGIN
    CREATE TABLE [PhoneNumbers] (
        [Id] int NOT NULL IDENTITY,
        [Number] nvarchar(max) NULL,
        [BioId] int NOT NULL,
        CONSTRAINT [PK_PhoneNumbers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_PhoneNumbers_Bios_BioId] FOREIGN KEY ([BioId]) REFERENCES [Bios] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210910073258_addedTables')
BEGIN
    CREATE TABLE [Products] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [DeletedAt] datetime2 NULL,
        [LastUpdateDate] datetime2 NULL,
        [ProductCode] nvarchar(max) NULL,
        [Image] nvarchar(max) NULL,
        [Count] int NULL,
        [Description] nvarchar(max) NULL,
        [Ingredients] nvarchar(max) NULL,
        [SaleCount] int NOT NULL,
        [Weight] float NULL,
        [CategoryId] int NOT NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210910073258_addedTables')
BEGIN
    CREATE TABLE [Nutritions] (
        [Id] int NOT NULL IDENTITY,
        [Oils] float NOT NULL,
        [Proteins] float NOT NULL,
        [Carbohydrates] float NOT NULL,
        [Calories] int NOT NULL,
        [ProductId] int NOT NULL,
        CONSTRAINT [PK_Nutritions] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Nutritions_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210910073258_addedTables')
BEGIN
    CREATE TABLE [ProductPrices] (
        [Id] int NOT NULL IDENTITY,
        [OldPrice] float NULL,
        [CurrentPrice] float NOT NULL,
        [ProductId] int NOT NULL,
        CONSTRAINT [PK_ProductPrices] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProductPrices_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210910073258_addedTables')
BEGIN
    CREATE UNIQUE INDEX [IX_Nutritions_ProductId] ON [Nutritions] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210910073258_addedTables')
BEGIN
    CREATE INDEX [IX_PhoneNumbers_BioId] ON [PhoneNumbers] ([BioId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210910073258_addedTables')
BEGIN
    CREATE UNIQUE INDEX [IX_ProductPrices_ProductId] ON [ProductPrices] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210910073258_addedTables')
BEGIN
    CREATE INDEX [IX_Products_CategoryId] ON [Products] ([CategoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210910073258_addedTables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210910073258_addedTables', N'3.1.18');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210911073248_ChangedProductTable')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProductPrices]') AND [c].[name] = N'OldPrice');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [ProductPrices] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [ProductPrices] ALTER COLUMN [OldPrice] decimal(18,2) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210911073248_ChangedProductTable')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProductPrices]') AND [c].[name] = N'CurrentPrice');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [ProductPrices] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [ProductPrices] ALTER COLUMN [CurrentPrice] decimal(18,2) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210911073248_ChangedProductTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210911073248_ChangedProductTable', N'3.1.18');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProductPrices]') AND [c].[name] = N'OldPrice');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [ProductPrices] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [ProductPrices] ALTER COLUMN [OldPrice] decimal(18, 2) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProductPrices]') AND [c].[name] = N'CurrentPrice');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [ProductPrices] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [ProductPrices] ALTER COLUMN [CurrentPrice] decimal(18, 2) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        [Name] nvarchar(max) NULL,
        [SurName] nvarchar(max) NULL,
        [Password] nvarchar(max) NULL,
        [IsEmailConfirmed] bit NOT NULL,
        [Adress] nvarchar(max) NULL,
        [IsDeleted] bit NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [DeletedAt] datetime2 NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables')
BEGIN
    CREATE TABLE [Orders] (
        [Id] int NOT NULL IDENTITY,
        [Date] datetime2 NOT NULL,
        [TotalAmount] decimal(18, 2) NOT NULL,
        [UserId] int NULL,
        [UserId1] nvarchar(450) NULL,
        CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Orders_AspNetUsers_UserId1] FOREIGN KEY ([UserId1]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables')
BEGIN
    CREATE TABLE [Ratings] (
        [Id] int NOT NULL IDENTITY,
        [Value] int NOT NULL,
        [UserId] int NOT NULL,
        [UserId1] nvarchar(450) NULL,
        [ProductId] int NOT NULL,
        CONSTRAINT [PK_Ratings] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Ratings_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Ratings_AspNetUsers_UserId1] FOREIGN KEY ([UserId1]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables')
BEGIN
    CREATE TABLE [OrderProducts] (
        [Id] int NOT NULL IDENTITY,
        [ProductId] int NOT NULL,
        [OrderId] int NOT NULL,
        [Quantity] int NOT NULL,
        [Price] int NOT NULL,
        CONSTRAINT [PK_OrderProducts] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_OrderProducts_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_OrderProducts_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables')
BEGIN
    CREATE TABLE [ShippingDetails] (
        [Id] int NOT NULL IDENTITY,
        [Adress] nvarchar(max) NULL,
        [AdressLine] nvarchar(max) NULL,
        [TakeMyself] bit NOT NULL,
        [OrderId] int NOT NULL,
        CONSTRAINT [PK_ShippingDetails] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ShippingDetails_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables')
BEGIN
    CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables')
BEGIN
    CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables')
BEGIN
    CREATE INDEX [IX_OrderProducts_OrderId] ON [OrderProducts] ([OrderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables')
BEGIN
    CREATE INDEX [IX_OrderProducts_ProductId] ON [OrderProducts] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables')
BEGIN
    CREATE INDEX [IX_Orders_UserId1] ON [Orders] ([UserId1]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables')
BEGIN
    CREATE INDEX [IX_Ratings_ProductId] ON [Ratings] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables')
BEGIN
    CREATE INDEX [IX_Ratings_UserId1] ON [Ratings] ([UserId1]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables')
BEGIN
    CREATE UNIQUE INDEX [IX_ShippingDetails_OrderId] ON [ShippingDetails] ([OrderId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210912180321_AddedOrdersOrderProductsRatingsShippingDetailsTables', N'3.1.18');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912201510_ChangedNameColumnOfUser')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'Name');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [AspNetUsers] DROP COLUMN [Name];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912201510_ChangedNameColumnOfUser')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [FirstName] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210912201510_ChangedNameColumnOfUser')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210912201510_ChangedNameColumnOfUser', N'3.1.18');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913072353_changedFisrtNameToUserName')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'FirstName');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [AspNetUsers] DROP COLUMN [FirstName];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913072353_changedFisrtNameToUserName')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210913072353_changedFisrtNameToUserName', N'3.1.18');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913153554_changedShippingTable')
BEGIN
    ALTER TABLE [Orders] DROP CONSTRAINT [FK_Orders_AspNetUsers_UserId1];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913153554_changedShippingTable')
BEGIN
    ALTER TABLE [Ratings] DROP CONSTRAINT [FK_Ratings_AspNetUsers_UserId1];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913153554_changedShippingTable')
BEGIN
    ALTER TABLE [ShippingDetails] DROP CONSTRAINT [FK_ShippingDetails_Orders_OrderId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913153554_changedShippingTable')
BEGIN
    DROP INDEX [IX_ShippingDetails_OrderId] ON [ShippingDetails];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913153554_changedShippingTable')
BEGIN
    DROP INDEX [IX_Ratings_UserId1] ON [Ratings];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913153554_changedShippingTable')
BEGIN
    DROP INDEX [IX_Orders_UserId1] ON [Orders];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913153554_changedShippingTable')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ShippingDetails]') AND [c].[name] = N'OrderId');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [ShippingDetails] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [ShippingDetails] DROP COLUMN [OrderId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913153554_changedShippingTable')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Ratings]') AND [c].[name] = N'UserId1');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Ratings] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [Ratings] DROP COLUMN [UserId1];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913153554_changedShippingTable')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Orders]') AND [c].[name] = N'UserId1');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Orders] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [Orders] DROP COLUMN [UserId1];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913153554_changedShippingTable')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ShippingDetails]') AND [c].[name] = N'AdressLine');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [ShippingDetails] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [ShippingDetails] ALTER COLUMN [AdressLine] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913153554_changedShippingTable')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ShippingDetails]') AND [c].[name] = N'Adress');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [ShippingDetails] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [ShippingDetails] ALTER COLUMN [Adress] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913153554_changedShippingTable')
BEGIN
    ALTER TABLE [ShippingDetails] ADD [Name] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913153554_changedShippingTable')
BEGIN
    ALTER TABLE [ShippingDetails] ADD [PhoneNumber] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913153554_changedShippingTable')
BEGIN
    ALTER TABLE [ShippingDetails] ADD [SurName] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913153554_changedShippingTable')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Ratings]') AND [c].[name] = N'UserId');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Ratings] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [Ratings] ALTER COLUMN [UserId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913153554_changedShippingTable')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Orders]') AND [c].[name] = N'UserId');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Orders] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [Orders] ALTER COLUMN [UserId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913153554_changedShippingTable')
BEGIN
    ALTER TABLE [Orders] ADD [ShippingId] int NOT NULL DEFAULT 0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913153554_changedShippingTable')
BEGIN
    CREATE INDEX [IX_Ratings_UserId] ON [Ratings] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913153554_changedShippingTable')
BEGIN
    CREATE UNIQUE INDEX [IX_Orders_ShippingId] ON [Orders] ([ShippingId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913153554_changedShippingTable')
BEGIN
    CREATE INDEX [IX_Orders_UserId] ON [Orders] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913153554_changedShippingTable')
BEGIN
    ALTER TABLE [Orders] ADD CONSTRAINT [FK_Orders_ShippingDetails_ShippingId] FOREIGN KEY ([ShippingId]) REFERENCES [ShippingDetails] ([Id]) ON DELETE CASCADE;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913153554_changedShippingTable')
BEGIN
    ALTER TABLE [Orders] ADD CONSTRAINT [FK_Orders_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913153554_changedShippingTable')
BEGIN
    ALTER TABLE [Ratings] ADD CONSTRAINT [FK_Ratings_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913153554_changedShippingTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210913153554_changedShippingTable', N'3.1.18');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913180715_ChangedOrderProductTables')
BEGIN
    ALTER TABLE [Orders] DROP CONSTRAINT [FK_Orders_ShippingDetails_ShippingId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913180715_ChangedOrderProductTables')
BEGIN
    DROP TABLE [ShippingDetails];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913180715_ChangedOrderProductTables')
BEGIN
    DROP INDEX [IX_Orders_ShippingId] ON [Orders];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913180715_ChangedOrderProductTables')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Orders]') AND [c].[name] = N'ShippingId');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [Orders] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [Orders] DROP COLUMN [ShippingId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913180715_ChangedOrderProductTables')
BEGIN
    ALTER TABLE [Orders] ADD [ShippingAdress] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913180715_ChangedOrderProductTables')
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OrderProducts]') AND [c].[name] = N'Price');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [OrderProducts] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [OrderProducts] ALTER COLUMN [Price] decimal(18,2) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210913180715_ChangedOrderProductTables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210913180715_ChangedOrderProductTables', N'3.1.18');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914065644_addedCartItemsTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210914065644_addedCartItemsTable', N'3.1.18');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914065852_addedNewTable')
BEGIN
    CREATE TABLE [CartItems] (
        [Id] int NOT NULL IDENTITY,
        [Quantity] int NOT NULL,
        [UserId] nvarchar(max) NULL,
        [ProductId] int NOT NULL,
        CONSTRAINT [PK_CartItems] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_CartItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914065852_addedNewTable')
BEGIN
    CREATE INDEX [IX_CartItems_ProductId] ON [CartItems] ([ProductId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914065852_addedNewTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210914065852_addedNewTable', N'3.1.18');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914083104_addedNewColumnsToCartItem')
BEGIN
    ALTER TABLE [CartItems] DROP CONSTRAINT [FK_CartItems_Products_ProductId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914083104_addedNewColumnsToCartItem')
BEGIN
    DROP INDEX [IX_CartItems_ProductId] ON [CartItems];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914083104_addedNewColumnsToCartItem')
BEGIN
    ALTER TABLE [CartItems] ADD [CurrentPrice] decimal(18,2) NOT NULL DEFAULT 0.0;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914083104_addedNewColumnsToCartItem')
BEGIN
    ALTER TABLE [CartItems] ADD [Image] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914083104_addedNewColumnsToCartItem')
BEGIN
    ALTER TABLE [CartItems] ADD [Name] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914083104_addedNewColumnsToCartItem')
BEGIN
    ALTER TABLE [CartItems] ADD [OldPrice] decimal(18,2) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210914083104_addedNewColumnsToCartItem')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210914083104_addedNewColumnsToCartItem', N'3.1.18');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210916114251_AddedNewColumnsToProductAndPricesTables')
BEGIN
    DECLARE @var15 sysname;
    SELECT @var15 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'Name');
    IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var15 + '];');
    ALTER TABLE [Products] ALTER COLUMN [Name] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210916114251_AddedNewColumnsToProductAndPricesTables')
BEGIN
    ALTER TABLE [ProductPrices] ADD [ShowOldPrice] bit NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210916114251_AddedNewColumnsToProductAndPricesTables')
BEGIN
    DECLARE @var16 sysname;
    SELECT @var16 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Nutritions]') AND [c].[name] = N'Proteins');
    IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [Nutritions] DROP CONSTRAINT [' + @var16 + '];');
    ALTER TABLE [Nutritions] ALTER COLUMN [Proteins] float NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210916114251_AddedNewColumnsToProductAndPricesTables')
BEGIN
    DECLARE @var17 sysname;
    SELECT @var17 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Nutritions]') AND [c].[name] = N'Oils');
    IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [Nutritions] DROP CONSTRAINT [' + @var17 + '];');
    ALTER TABLE [Nutritions] ALTER COLUMN [Oils] float NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210916114251_AddedNewColumnsToProductAndPricesTables')
BEGIN
    DECLARE @var18 sysname;
    SELECT @var18 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Nutritions]') AND [c].[name] = N'Carbohydrates');
    IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [Nutritions] DROP CONSTRAINT [' + @var18 + '];');
    ALTER TABLE [Nutritions] ALTER COLUMN [Carbohydrates] float NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210916114251_AddedNewColumnsToProductAndPricesTables')
BEGIN
    DECLARE @var19 sysname;
    SELECT @var19 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Nutritions]') AND [c].[name] = N'Calories');
    IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [Nutritions] DROP CONSTRAINT [' + @var19 + '];');
    ALTER TABLE [Nutritions] ALTER COLUMN [Calories] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210916114251_AddedNewColumnsToProductAndPricesTables')
BEGIN
    DECLARE @var20 sysname;
    SELECT @var20 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[IntroSliders]') AND [c].[name] = N'SliderText');
    IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [IntroSliders] DROP CONSTRAINT [' + @var20 + '];');
    ALTER TABLE [IntroSliders] ALTER COLUMN [SliderText] nvarchar(50) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210916114251_AddedNewColumnsToProductAndPricesTables')
BEGIN
    DECLARE @var21 sysname;
    SELECT @var21 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Categories]') AND [c].[name] = N'Name');
    IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [Categories] DROP CONSTRAINT [' + @var21 + '];');
    ALTER TABLE [Categories] ALTER COLUMN [Name] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210916114251_AddedNewColumnsToProductAndPricesTables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210916114251_AddedNewColumnsToProductAndPricesTables', N'3.1.18');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210916114706_changedCartItemTable')
BEGIN
    DECLARE @var22 sysname;
    SELECT @var22 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OrderProducts]') AND [c].[name] = N'Price');
    IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [OrderProducts] DROP CONSTRAINT [' + @var22 + '];');
    ALTER TABLE [OrderProducts] ALTER COLUMN [Price] decimal(18, 2) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210916114706_changedCartItemTable')
BEGIN
    DECLARE @var23 sysname;
    SELECT @var23 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CartItems]') AND [c].[name] = N'OldPrice');
    IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [CartItems] DROP CONSTRAINT [' + @var23 + '];');
    ALTER TABLE [CartItems] ALTER COLUMN [OldPrice] decimal(18, 2) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210916114706_changedCartItemTable')
BEGIN
    DECLARE @var24 sysname;
    SELECT @var24 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CartItems]') AND [c].[name] = N'CurrentPrice');
    IF @var24 IS NOT NULL EXEC(N'ALTER TABLE [CartItems] DROP CONSTRAINT [' + @var24 + '];');
    ALTER TABLE [CartItems] ALTER COLUMN [CurrentPrice] decimal(18, 2) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210916114706_changedCartItemTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210916114706_changedCartItemTable', N'3.1.18');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210916181257_AddedKeyToCartItem')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210916181257_AddedKeyToCartItem', N'3.1.18');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210916183814_AddedRelations')
BEGIN
    DECLARE @var25 sysname;
    SELECT @var25 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CartItems]') AND [c].[name] = N'UserId');
    IF @var25 IS NOT NULL EXEC(N'ALTER TABLE [CartItems] DROP CONSTRAINT [' + @var25 + '];');
    ALTER TABLE [CartItems] ALTER COLUMN [UserId] nvarchar(450) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210916183814_AddedRelations')
BEGIN
    CREATE INDEX [IX_CartItems_UserId] ON [CartItems] ([UserId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210916183814_AddedRelations')
BEGIN
    ALTER TABLE [CartItems] ADD CONSTRAINT [FK_CartItems_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210916183814_AddedRelations')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210916183814_AddedRelations', N'3.1.18');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210916191404_Test')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210916191404_Test', N'3.1.18');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210917054903_removedCartItemsTableFromDAl')
BEGIN
    DROP TABLE [CartItems];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210917054903_removedCartItemsTableFromDAl')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210917054903_removedCartItemsTableFromDAl', N'3.1.18');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210918074552_addedFirstNameToUser')
BEGIN
    DECLARE @var26 sysname;
    SELECT @var26 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'Password');
    IF @var26 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var26 + '];');
    ALTER TABLE [AspNetUsers] DROP COLUMN [Password];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210918074552_addedFirstNameToUser')
BEGIN
    DECLARE @var27 sysname;
    SELECT @var27 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'SurName');
    IF @var27 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var27 + '];');
    ALTER TABLE [AspNetUsers] ALTER COLUMN [SurName] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210918074552_addedFirstNameToUser')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [AdressLine] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210918074552_addedFirstNameToUser')
BEGIN
    ALTER TABLE [AspNetUsers] ADD [FirstName] nvarchar(max) NOT NULL DEFAULT N'';
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210918074552_addedFirstNameToUser')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210918074552_addedFirstNameToUser', N'3.1.18');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210919152538_AddedRateColToOrderProduct')
BEGIN
    ALTER TABLE [OrderProducts] ADD [Rate] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210919152538_AddedRateColToOrderProduct')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210919152538_AddedRateColToOrderProduct', N'3.1.18');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210920113636_RemovedRatefromOrderProduct')
BEGIN
    DECLARE @var28 sysname;
    SELECT @var28 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OrderProducts]') AND [c].[name] = N'Rate');
    IF @var28 IS NOT NULL EXEC(N'ALTER TABLE [OrderProducts] DROP CONSTRAINT [' + @var28 + '];');
    ALTER TABLE [OrderProducts] DROP COLUMN [Rate];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210920113636_RemovedRatefromOrderProduct')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210920113636_RemovedRatefromOrderProduct', N'3.1.18');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210921043559_AddedDescriptionAndDurationToIntroSlider')
BEGIN
    ALTER TABLE [IntroSliders] ADD [Description] nvarchar(300) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210921043559_AddedDescriptionAndDurationToIntroSlider')
BEGIN
    ALTER TABLE [IntroSliders] ADD [Duration] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210921043559_AddedDescriptionAndDurationToIntroSlider')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210921043559_AddedDescriptionAndDurationToIntroSlider', N'3.1.18');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210922085405_AddedDetailsToInroSlider')
BEGIN
    ALTER TABLE [IntroSliders] ADD [Details] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210922085405_AddedDetailsToInroSlider')
BEGIN
    DECLARE @var29 sysname;
    SELECT @var29 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bios]') AND [c].[name] = N'YoutubeLink');
    IF @var29 IS NOT NULL EXEC(N'ALTER TABLE [Bios] DROP CONSTRAINT [' + @var29 + '];');
    ALTER TABLE [Bios] ALTER COLUMN [YoutubeLink] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210922085405_AddedDetailsToInroSlider')
BEGIN
    DECLARE @var30 sysname;
    SELECT @var30 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bios]') AND [c].[name] = N'WorkingHours');
    IF @var30 IS NOT NULL EXEC(N'ALTER TABLE [Bios] DROP CONSTRAINT [' + @var30 + '];');
    ALTER TABLE [Bios] ALTER COLUMN [WorkingHours] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210922085405_AddedDetailsToInroSlider')
BEGIN
    DECLARE @var31 sysname;
    SELECT @var31 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bios]') AND [c].[name] = N'WhatsappLink');
    IF @var31 IS NOT NULL EXEC(N'ALTER TABLE [Bios] DROP CONSTRAINT [' + @var31 + '];');
    ALTER TABLE [Bios] ALTER COLUMN [WhatsappLink] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210922085405_AddedDetailsToInroSlider')
BEGIN
    DECLARE @var32 sysname;
    SELECT @var32 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bios]') AND [c].[name] = N'InstagramLink');
    IF @var32 IS NOT NULL EXEC(N'ALTER TABLE [Bios] DROP CONSTRAINT [' + @var32 + '];');
    ALTER TABLE [Bios] ALTER COLUMN [InstagramLink] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210922085405_AddedDetailsToInroSlider')
BEGIN
    DECLARE @var33 sysname;
    SELECT @var33 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bios]') AND [c].[name] = N'FbLink');
    IF @var33 IS NOT NULL EXEC(N'ALTER TABLE [Bios] DROP CONSTRAINT [' + @var33 + '];');
    ALTER TABLE [Bios] ALTER COLUMN [FbLink] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210922085405_AddedDetailsToInroSlider')
BEGIN
    DECLARE @var34 sysname;
    SELECT @var34 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Bios]') AND [c].[name] = N'Adress');
    IF @var34 IS NOT NULL EXEC(N'ALTER TABLE [Bios] DROP CONSTRAINT [' + @var34 + '];');
    ALTER TABLE [Bios] ALTER COLUMN [Adress] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210922085405_AddedDetailsToInroSlider')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210922085405_AddedDetailsToInroSlider', N'3.1.18');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210923070612_AddedAboutTable')
BEGIN
    CREATE TABLE [Abouts] (
        [Id] int NOT NULL IDENTITY,
        [AboutBody] nvarchar(max) NULL,
        [VideoLink] nvarchar(max) NULL,
        CONSTRAINT [PK_Abouts] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210923070612_AddedAboutTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210923070612_AddedAboutTable', N'3.1.18');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210928101747_AddedDeliveryModel')
BEGIN
    DECLARE @var35 sysname;
    SELECT @var35 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[IntroSliders]') AND [c].[name] = N'SliderText');
    IF @var35 IS NOT NULL EXEC(N'ALTER TABLE [IntroSliders] DROP CONSTRAINT [' + @var35 + '];');
    ALTER TABLE [IntroSliders] ALTER COLUMN [SliderText] nvarchar(50) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210928101747_AddedDeliveryModel')
BEGIN
    CREATE TABLE [Deliveries] (
        [Id] int NOT NULL IDENTITY,
        [Info] nvarchar(max) NULL,
        [Details] nvarchar(max) NULL,
        CONSTRAINT [PK_Deliveries] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210928101747_AddedDeliveryModel')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210928101747_AddedDeliveryModel', N'3.1.18');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210928150334_AddedDeliveryAdresses')
BEGIN
    CREATE TABLE [DeliveryAdresses] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Time] nvarchar(max) NULL,
        [MinAmount] decimal(18, 2) NULL,
        [DeliveryId] int NOT NULL,
        CONSTRAINT [PK_DeliveryAdresses] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_DeliveryAdresses_Deliveries_DeliveryId] FOREIGN KEY ([DeliveryId]) REFERENCES [Deliveries] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210928150334_AddedDeliveryAdresses')
BEGIN
    CREATE INDEX [IX_DeliveryAdresses_DeliveryId] ON [DeliveryAdresses] ([DeliveryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210928150334_AddedDeliveryAdresses')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210928150334_AddedDeliveryAdresses', N'3.1.18');
END;

GO

