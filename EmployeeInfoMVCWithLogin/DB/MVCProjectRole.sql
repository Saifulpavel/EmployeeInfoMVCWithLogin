USE [MVCProjectRole]
--CREATE DATABASE [MVCProjectRole]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 10/28/2020 3:05:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Position] [varchar](50) NULL,
	[Office] [varchar](50) NULL,
	[Age] [int] NULL,
	[Salary] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role]    Script Date: 10/28/2020 3:05:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 10/28/2020 3:05:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](250) NOT NULL,
	[LastName] [nvarchar](250) NOT NULL,
	[EmailID] [varchar](250) NOT NULL,
	[DateOfBirth] [date] NULL,
	[Password] [nvarchar](max) NOT NULL,
	[ConfirmPassword] [nvarchar](max) NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeID], [Name], [Position], [Office], [Age], [Salary]) VALUES (1, N'Saiful Islam', N'Programmer', N'Dhaka', 24, 25000)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Position], [Office], [Age], [Salary]) VALUES (2, N'Imam Hossain Shajid', N'Programmer', N'Dhaka', 24, 20000)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Position], [Office], [Age], [Salary]) VALUES (3, N'Lokman Hosan', N'Marketing Officer', N'Dhaka', 24, 30000)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Position], [Office], [Age], [Salary]) VALUES (4, N'Ashraful Alam Kabbo', N'Motion Graphic Designer', N'Dhaka', 25, 25000)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Position], [Office], [Age], [Salary]) VALUES (5, N'Md. Sirajul Islam', N'IT Officer', N'Uttara', 22, 15000)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Position], [Office], [Age], [Salary]) VALUES (6, N'Jafrul Hasan', N'Programmer', N'Dhanmondi', 24, 20000)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Position], [Office], [Age], [Salary]) VALUES (7, N'Mushrif Haque', N'Programmer', N'Dhanmondi', 22, 25000)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Position], [Office], [Age], [Salary]) VALUES (9, N'Rahat Khan', N'Designer', N'Uttara', 23, 20000)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Position], [Office], [Age], [Salary]) VALUES (10, N'Rakibul Ahsan', N'Audit Officer', N'Dhaka', 23, 30000)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Position], [Office], [Age], [Salary]) VALUES (11, N'Maswood Mahmood', N'Medical Officer', N'Gazipur', 24, 35000)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Position], [Office], [Age], [Salary]) VALUES (12, N'Mukhter Hossain', N'Software Support Engineer', N'Pubali Bank Ltd.', 24, 35000)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Position], [Office], [Age], [Salary]) VALUES (13, N'Nahid Hossain', N'Programmer', N'PPL', 24, 50000)
INSERT [dbo].[Employee] ([EmployeeID], [Name], [Position], [Office], [Age], [Salary]) VALUES (14, N'Debashis Roy', N'Programmer', N'Panjeree Publications Ltd.', 22, 30000)
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleID], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([RoleID], [Name]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [EmailID], [DateOfBirth], [Password], [ConfirmPassword], [RoleID]) VALUES (12, N'Abser', N'Rupok', N'rupok.diu@gmail.com', NULL, N'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', N'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', NULL)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [EmailID], [DateOfBirth], [Password], [ConfirmPassword], [RoleID]) VALUES (13, N'Saiful', N'Islam', N'saiful0980@gmail.com', NULL, N'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', N'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', NULL)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [EmailID], [DateOfBirth], [Password], [ConfirmPassword], [RoleID]) VALUES (14, N'Kabbo', N'Kabbo', N'kabbo@gmail.com', NULL, N'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', N'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
