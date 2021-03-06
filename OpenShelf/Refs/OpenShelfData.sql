USE [OpenShelf]
GO
/****** Object:  Table [dbo].[Borrows]    Script Date: 06/15/2011 11:28:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Borrows](
	[Book] [nvarchar](max) NULL,
	[Employee] [nvarchar](max) NULL,
	[Id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Borrows] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Borrows] ([Book], [Employee], [Id]) VALUES (N'Title: Just Listen –Mark Goulston, Isbn: 0814414036, CopyId: 1', N'Id: 12811, Name: Chandrasekar T', N'c759d916-ea1a-4ba0-baa9-35a9970dc560')
INSERT [dbo].[Borrows] ([Book], [Employee], [Id]) VALUES (N'Title: Just Listen –Mark Goulston, Isbn: 0814414036, CopyId: 1', N'Id: 12811, Name: Chandrasekar T', N'3fee9d67-003e-4ec2-b861-70df4b0707f2')
