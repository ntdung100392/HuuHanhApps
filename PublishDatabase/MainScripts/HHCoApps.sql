/****** Object:  Table [dbo].[__MigrationHistory] ******/
GO
CREATE TABLE [dbo].[__MigrationHistory](
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
    [MigrationId] ASC,
    [ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User] ******/
CREATE TABLE [dbo].[User](
    [Id] [int] NOT NULL IDENTITY(1,1),
    [UniqueId] [uniqueidentifier] NOT NULL DEFAULT(newid()),
    [UserName] [nvarchar](18) NULL,
    [PassWord] [nvarchar](20) NULL,
    [Sex] [nvarchar](10) NOT NULL,
    [DOB] [datetime] NOT NULL,
    [IDCard] [nvarchar](50) NULL,
    [Address] [nvarchar](max) NULL,
    [HomeTown] [int] NOT NULL,
    [PhoneNumber] [nvarchar](50) NULL,
    [JoiningDate] [datetime] NOT NULL,
    [LastAccess] [datetime] NULL,
    [UserCode] [nvarchar](10) NULL,
    [FirstName] [nvarchar](50) NULL,
    [MiddleName] [nvarchar](50) NULL,
    [LastName] [nvarchar](50) NULL,
    [IsActive] [bit] NOT NULL DEFAULT(1),
    [IsDeleted] [bit] NOT NULL DEFAULT(0),
    [Created] [datetime] NOT NULL DEFAULT(getdate()),
    [Updated] [datetime] NULL,
 CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
GO
/****** Object:  Table [dbo].[Currency] ******/
CREATE TABLE [dbo].[Currency](
    [Id] [int] NOT NULL IDENTITY(1,1),
    [ForeignCurrency] [nvarchar](20) NOT NULL,
    [Rate] [decimal](18, 4) NOT NULL,
    [IsActive] [bit] NOT NULL DEFAULT(1),
    [IsDeleted] [bit] NOT NULL DEFAULT(0),
    [Created] [datetime] NOT NULL DEFAULT(getdate()),
    [Updated] [datetime] NULL,
 CONSTRAINT [PK_dbo.Currency] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
GO
/****** Object:  Table [dbo].[Category] ******/
CREATE TABLE [dbo].[Category](
    [Id] [int] NOT NULL IDENTITY(1,1),
    [Name] [nvarchar](50) NOT NULL,
    [Code] [nvarchar](10) NOT NULL,
    [Created] [datetime] NOT NULL DEFAULT(getdate()),
    [Updated] [datetime] NULL,
 CONSTRAINT [PK_dbo.Category] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 7/15/2018 2:56:35 PM ******/
CREATE TABLE [dbo].[Customer](
    [Id] [int] NOT NULL IDENTITY(1,1),
    [FullName] [nvarchar](150) NULL,
    [Address] [nvarchar](max) NULL,
    [Phone] [nvarchar](20) NULL,
    [Email] [nvarchar](30) NULL,
    [DOB] [datetime] NULL,
    [HomeTown] [int] NOT NULL,
    [IsOrganization] [bit] NOT NULL,
    [IsActive] [bit] NOT NULL DEFAULT(1),
    [IsDeleted] [bit] NOT NULL DEFAULT(0),
    [Created] [datetime] NOT NULL DEFAULT(getdate()),
    [Updated] [datetime] NULL,
 CONSTRAINT [PK_dbo.Customer] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Log] ******/
CREATE TABLE [dbo].[Log](
    [Id] [int] NOT NULL IDENTITY(1,1),
    [Date] [datetime] NOT NULL,
    [Thread] [nvarchar](max) NULL,
    [Level] [nvarchar](max) NULL,
    [Logger] [nvarchar](max) NULL,
    [Message] [nvarchar](max) NULL,
    [Exception] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Log] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
GO
/****** Object:  Table [dbo].[Suppliers] ******/
CREATE TABLE [dbo].[Supplier](
    [Id] [int] NOT NULL IDENTITY(1,1),
    [CompanyName] [nvarchar](150) NOT NULL,
    [Address] [nvarchar](max) NULL,
    [Email] [nvarchar](30) NULL,
    [Phone] [nvarchar](20) NULL,
    [Fax] [nvarchar](20) NULL,
    [TaxCode] [nvarchar](50) NULL,
    [DirectorName] [nvarchar](150) NULL,
    [Note] [nvarchar](max) NULL,
    [HomeTown] [nvarchar](50) NULL,
    [IsActive] [bit] NOT NULL DEFAULT(1),
    [IsDeleted] [bit] NOT NULL DEFAULT(0),
    [Created] [datetime] NOT NULL DEFAULT(getdate()),
    [Updated] [datetime] NULL,
 CONSTRAINT [PK_dbo.Supplier] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
GO
/****** Object:  Table [dbo].[Products] ******/
CREATE TABLE [dbo].[Product](
    [Id] [int] NOT NULL IDENTITY(1,1),
    [UniqueId] [uniqueidentifier] NOT NULL DEFAULT(newid()),
    [ProductCode] [nvarchar](10) NOT NULL DEFAULT(''),
    [Name] [nvarchar](150) NULL,
    [CategoryId] [int] NOT NULL,
    [SupplierId] [int] NOT NULL,
    [InputCost] [decimal](18, 4) NOT NULL,
    [BaseCost] [decimal](18, 4) NOT NULL,
    [ForeignCurrency] [nvarchar](18) NOT NULL DEFAULT('VND'),
    [IssuedDate] [datetime] NOT NULL,
    [ExpiredDate] [datetime] NOT NULL,
    [Stock] [int] NOT NULL DEFAULT(0),
    [Status] [nvarchar](20) NOT NULL,
    [IsActive] [bit] NOT NULL DEFAULT(1),
    [IsDeleted] [bit] NOT NULL DEFAULT(0),
    [Created] [datetime] NOT NULL DEFAULT(getdate()),
    [Updated] [datetime] NULL,
 CONSTRAINT [PK_dbo.Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
GO

ALTER TABLE [dbo].[Product] ADD CONSTRAINT FK_Product_Category FOREIGN KEY (CategoryId) REFERENCES [dbo].[Category](Id)
GO

ALTER TABLE [dbo].[Product] ADD CONSTRAINT FK_Product_Supplier FOREIGN KEY (SupplierId) REFERENCES [dbo].[Supplier](Id)