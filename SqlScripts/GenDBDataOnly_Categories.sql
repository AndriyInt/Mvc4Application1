USE [TestC]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [ParentCategoryId]) VALUES (2, N'Home', N'', NULL)
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [ParentCategoryId]) VALUES (3, N'Office', N'Office stuff', NULL)
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [ParentCategoryId]) VALUES (5, N'Computers and Peropherals', N'', NULL)
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [ParentCategoryId]) VALUES (6, N'Desktop PC', N'', 5)
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [ParentCategoryId]) VALUES (7, N'Laptops', N'', 5)
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [ParentCategoryId]) VALUES (8, N'Computer mice', N'', 5)
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [ParentCategoryId]) VALUES (9, N'Keyboards', N'', 5)
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [ParentCategoryId]) VALUES (10, N'qwe1', N'qq', NULL)
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [ParentCategoryId]) VALUES (12, N'qwe2', N'qq', NULL)
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [ParentCategoryId]) VALUES (13, N'qwe3', N'qq', NULL)
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [ParentCategoryId]) VALUES (14, N'qwe4', N'qq', NULL)
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [ParentCategoryId]) VALUES (15, N'qwe6', N'qq', NULL)
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [ParentCategoryId]) VALUES (16, N'qwe7', N'qq', NULL)
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [ParentCategoryId]) VALUES (17, N'qwe8', N'qq', NULL)
INSERT [dbo].[Categories] ([CategoryId], [Name], [Description], [ParentCategoryId]) VALUES (18, N'qwe9', N'qq', NULL)
SET IDENTITY_INSERT [dbo].[Categories] OFF
