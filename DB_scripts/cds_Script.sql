USE [CDS]
GO
/****** Object:  Table [dbo].[usertable]    Script Date: 3/19/2019 9:45:30 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usertable]') AND type in (N'U'))
DROP TABLE [dbo].[usertable]
GO
/****** Object:  Table [dbo].[memberstable]    Script Date: 3/19/2019 9:45:30 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[memberstable]') AND type in (N'U'))
DROP TABLE [dbo].[memberstable]
GO
/****** Object:  Table [dbo].[memberstable]    Script Date: 3/19/2019 9:45:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[memberstable](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[ScreenName] [nvarchar](100) NOT NULL,
	[CardNumber] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
 CONSTRAINT [PK_memberstable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usertable]    Script Date: 3/19/2019 9:45:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usertable](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_usertable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[memberstable] ON 

INSERT [dbo].[memberstable] ([ID], [FirstName], [LastName], [ScreenName], [CardNumber], [StartDate], [EndDate]) VALUES (1, N'Nemanja', N'Nikolić', N'Nemanja Nikolić', 1, CAST(N'2019-05-11T12:00:00.000' AS DateTime), CAST(N'2019-06-11T12:00:00.000' AS DateTime))
INSERT [dbo].[memberstable] ([ID], [FirstName], [LastName], [ScreenName], [CardNumber], [StartDate], [EndDate]) VALUES (5, N'Nemanja', N'Milošević', N'Nemanja Milošević', 2, CAST(N'2020-05-28T12:00:00.000' AS DateTime), CAST(N'2020-06-28T12:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[memberstable] OFF
SET IDENTITY_INSERT [dbo].[usertable] ON 

INSERT [dbo].[usertable] ([ID], [Username], [Password]) VALUES (2, N'markoIvetic', N'12345')
SET IDENTITY_INSERT [dbo].[usertable] OFF
