CREATE DATABASE Sem3;
GO
Use Sem3;
GO
CREATE TABLE [Role] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(20) NOT NULL
)
GO

CREATE TABLE [Category] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [Name] varchar(100) NOT NULL
)
GO

CREATE TABLE [Product] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [CategoryID] int,
  [Name] varchar(250),
  [Description] nvarchar(255),
  [CreatedDate] datetime,
  [UpdatedDate] datetime,
  [Deleted] bit
)
GO

CREATE TABLE [ProductImage] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [ProductID] int,
  [Image] nvarchar(255)
)
GO

CREATE TABLE [Specification] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255),
  [Unit] nvarchar(255)
)
GO

CREATE TABLE [ProductSpecification] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [ProductID] int,
  [SpecID] int,
  [SpecName] nvarchar(255),
  [SpecValue] nvarchar(255),
  [SpecUnit] nvarchar(255)
)
GO

CREATE TABLE [User] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [UserName] varchar(25) NOT NULL,
  [Email] varchar(150) NOT NULL,
  [PhoneNumber] varchar(13) NOT NULL,
  [Address] varchar(200) NOT NULL,
  [Password] varchar(32) NOT NULL,
  [RoleID] int,
  [CreateDate] datetime NOT NULL,
  [UpdateDate] datetime
)
GO

CREATE TABLE [FeedBack] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [FullName] varchar(50) NOT NULL,
  [CompanyName] varchar(50) NOT NULL,
  [Email] varchar(150) NOT NULL,
  [PhoneNumber] varchar(13) NOT NULL,
  [Subject] varchar(200) NOT NULL,
  [Comment] varchar(500) NOT NULL,
  [CreateDate] datetime NOT NULL
)
GO

CREATE TABLE [Education] (
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [UserID] int,
  [SchoolName] varchar(50) NOT NULL,
  [SchoolType] nvarchar(255),
  [Degree] varchar(50),
  [From] nvarchar(255),
  [To] nvarchar(255)
)
GO

CREATE TABLE [Career] (
  [UserID] int,
  [ID] int PRIMARY KEY IDENTITY(1, 1),
  [File] nvarchar(255),
  [Status] int,
  [CreateDate] datetime NOT NULL
)
GO

ALTER TABLE [Product] ADD FOREIGN KEY ([CategoryID]) REFERENCES [Category] ([ID])
GO

ALTER TABLE [User] ADD FOREIGN KEY ([RoleID]) REFERENCES [Role] ([ID])
GO

ALTER TABLE [Career] ADD FOREIGN KEY ([UserID]) REFERENCES [User] ([ID])
GO

ALTER TABLE [ProductImage] ADD FOREIGN KEY ([ProductID]) REFERENCES [Product] ([ID])
GO

ALTER TABLE [ProductSpecification] ADD FOREIGN KEY ([ProductID]) REFERENCES [Product] ([ID])
GO

ALTER TABLE [ProductSpecification] ADD FOREIGN KEY ([SpecID]) REFERENCES [Specification] ([ID])
GO

ALTER TABLE [Education] ADD FOREIGN KEY ([UserID]) REFERENCES [User] ([ID])
GO

ALTER TABLE [USER]
ADD FileName varchar(100)

ALTER TABLE Education
ALTER COLUMN SchoolName nvarchar(100)

ALTER TABLE Education
ALTER COLUMN SchoolType nvarchar(100)

DROP TABLE Career

CREATE TABLE [dbo].[Career](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[ShortDescription] [nvarchar](500) NULL,
	[Description] [nvarchar](max) NULL,
	[TimeStart] [date] NULL,
	[TimeEnd] [date] NULL,
	[Position] [nvarchar](100) NULL,
	[Price] [int] NULL,
	[Skill] [nvarchar](300) NULL,
	[Status] [int] NULL,
	[CreatedDate] [date] NULL,
	[UpdateDate] [date] NULL,
 CONSTRAINT [PK__Career__3214EC2710072CD7] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


CREATE TABLE [dbo].[CareerJob](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[JobID] [int] NULL,
	[UserID] [int] NULL,
	[Status] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_CareerJob] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
