USE [upu10905a_db]
GO
SET IDENTITY_INSERT [dbo].[PostCategories] ON 
GO
INSERT [dbo].[PostCategories] ([Id], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id], [RootCategoryIdentifier]) VALUES (1, N'Công nghệ', N'Công nghệ', N'<p>sdas</p>
', N'<p>dasd</p>
', N'sadsa', N'dsa', NULL, NULL, NULL, 1)
GO
INSERT [dbo].[PostCategories] ([Id], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id], [RootCategoryIdentifier]) VALUES (2, N'Hướng dẫn sử dụng', N'User Manual', N'<p>hướng dẫn sử dụng cho người d&ugrave;ng</p>
', N'<p>user manual</p>
', N'Từ khóa cho trang hướng dẫn sử dụng', N'các  thông tin về hướng dẫn sử dụng', NULL, NULL, NULL, 2)
GO
INSERT [dbo].[PostCategories] ([Id], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id], [RootCategoryIdentifier]) VALUES (3, N'Triển lãm sự kiện', N'Event', N'<p>event</p>
', N'<p>&aacute;d</p>
', N'2', N'1', NULL, NULL, NULL, 3)
GO
SET IDENTITY_INSERT [dbo].[PostCategories] OFF
GO
