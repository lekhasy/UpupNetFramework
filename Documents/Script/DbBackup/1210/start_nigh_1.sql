USE [upu10905a_db]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([Id], [Name], [Name_en], [Description], [Description_en], [ImageUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (1, N'Bộ Truyền Động', N'Rotary Power Transmision ', N'<p>A wide variety of standard and configurable components for factory automation engineers in industries such as automotive, semiconductor, packaging, medical and many more.</p>
', N'<p>A wide variety of standard and configurable components for factory automation engineers in industries such as automotive, semiconductor, packaging, medical and many more.</p>
', N'20171210130036857_90ebc534ab1a4533a70f499024278649.png', N'Bộ Truyền Động', N'Truyền Động Cơ Khí', N'Power Transmission', N'Mechanical Power Transmission', NULL)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Name_en], [Description], [Description_en], [ImageUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (2, N'Puly Đai Răng', N'Timing  Pulleys', N'<p>Puly cho d&acirc;y đai răng c&aacute;c loại</p>
', N'<p>&nbsp;Timing pulley for automaiton</p>
', N'20171210160558577_64fbe08b04984e01b54e17257105834a.png', N'uly đai răng ', N'Puly đai răng', N'Timing Belts', N'Timing belts and pulley', 1)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Name_en], [Description], [Description_en], [ImageUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (3, N'Puly -Then', N'Pulleys-Key', N'<p>D&acirc;y puly đai răng&nbsp;c&aacute;c loại: S2M, S3M, S5M, S8M, S14M, XL, L, T5, T10</p>
', N'<p>Including timing pulleys&nbsp;:&nbsp; S2M, S3M, S5M, S8M, S14M, XL, L, T5, T10</p>
', N'20171210154737305_8207bc66b69144e594db01b48b9f0ad9.png', N'Puly đai răng', N'Puly đai răng', N'Timing Pulleys', N'Timing Pulley', 2)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Name_en], [Description], [Description_en], [ImageUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (4, N'Chuyển Động Tịnh Tiến', N'Linear Motion', N'<p>Bao gồm c&aacute;c loại dẫn hướng tịnh tiến như: ray trượt, ty trượt tr&ograve;n</p>
', N'<p>Including linear motion such as: line guides, bushing, linear shafts</p>
', N'20171210131937627_b7a304cd00784203ad8cff9532a063b6.png', N'ray trượt, bạc trượt', N'Dẫn hướng cho chuyển động thẳng', N'line guide, ball bushing', N'Linear Motion', NULL)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Name_en], [Description], [Description_en], [ImageUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (5, N'Dây đai răng', N'Timing Belts', N'<p>D&acirc;y đai răng</p>
', N'<p>Timing belts</p>
', N'20171210155254126_f874af6c26384a2c84492586a1598cc5.png', N'Dây đai răng', N'Dây đai răng', N'Timing Belts', N'Timing belts', 1)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Name_en], [Description], [Description_en], [ImageUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (6, N'Truyền Động Bánh Răng', N'Gears', N'<p>b&aacute;nh răng</p>
', N'<p>gears</p>
', N'20171210160312938_3b14dc5915cc497a9266a8558eed2815.png', N'bánh răng', N' bánh răng', N'gears', N'gears', 1)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Name_en], [Description], [Description_en], [ImageUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (7, N'Bánh Xích', N'Sprocket Chain', N'<p>B&aacute;nh x&iacute;ch bị động, chủ động c&aacute;c loại</p>
', N'<p>Sprocket chain</p>
', N'20171210155749520_6170c3a983f348638e4e155c6897761e.png', N'Bánh Xích', N'Bánh xích', N'Sprocket chain', N'Sprocket chain', 1)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Name_en], [Description], [Description_en], [ImageUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (12, N'Chuyển động quay', N'Rotary Motion', N'<p>C&aacute;c sản phẩm như bạc đạn c&aacute;c loại, trục</p>
', N'<p>Providing bearing for aotomation&nbsp;</p>
', N'20171210132349947_ce32bd4558af40929a52904cd661930b.png', N'Bạc đạn', N'Bạc đạn', N'Bạc đạn', N'Rotary Motion', NULL)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Name_en], [Description], [Description_en], [ImageUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (13, N'Linh Kiện Tự Động Hóa', N'Automation Components', N'<p>&nbsp;spare spart, rulo cho tự động h&oacute;a</p>
', N'<p>spare sparts, components for automation</p>
', N'20171210134051777_6fa012ca83a7468cbd0a1af8823e74fb.png', N'khớp xoay, giảm chấn, rulo', N'linh kiện, vật tư cho ngành tự động hóa', N'retaining ring,  roller, shock absorber', N'Automation Components', NULL)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Name_en], [Description], [Description_en], [ImageUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (14, N'Linh Kiện Siết', N'Fassteners', N'<p>Bulong, ốc v&iacute;t</p>
', N'<p>screws, nuts</p>
', N'20171210134445904_5111e1286a5c441eb03016f36952682e.png', N'bulong, ốc vít', N'linh kiện cho mối lắp ghép', N'bulong, ốc vít', N'Fasteners', NULL)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Name_en], [Description], [Description_en], [ImageUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (15, N'Bạc Đạn', N'Bearings', N'<p>Bao gồm c&aacute;c loại bạc đạn NKS ch&iacute;nh h&atilde;ng</p>
', N'<p>NSK bearings</p>
', N'20171210142310340_13639f69a925447b9423b45b6442d90a.png', N'Bạc đạn NSK', N'Bạc đạn', N'Bạc đạn NSK', N'NSK bearing', 12)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Name_en], [Description], [Description_en], [ImageUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (17, N'Gối đỡ', N'Mounted Bearings', N'<p>Gối đỡ Timken</p>
', N'<p>Timken ball bearings</p>
', N'20171210142842292_ec736888deab47c081a907d0b0689107.png', N'gối đỡ timken', N'Gối đỡ timken', N'gối đỡ timken', N'Timken bearings ', 12)
GO
INSERT [dbo].[Categories] ([Id], [Name], [Name_en], [Description], [Description_en], [ImageUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (20, N'Xích', N'Roller Chain', N'<p>C&aacute;c loại x&iacute;ch: RS25, RS35, RS40, RS50, RS60, RS80</p>
', N'<p>Roller chain:&nbsp;RS25, RS35, RS40, RS50, RS60, RS80</p>
', N'20171210155533045_12a572ab478d437c964183f262dac931.png', N'Xích', N'Xích', N'Roller chain', N'Roller chain', 1)
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([Id], [Code], [Name], [Name_en], [Summary], [Summary_en], [ImageUrl], [PdfUrl], [LinkGuide], [Cad2dUrl], [Cad3dUrl], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [Category_Id]) VALUES (1, N'CR', N'S2M', N'S2M', N'<p>D&acirc;y đai răng S2M</p>
', N'<p>Timing Belts S2M</p>
', N'20171210145416280_25f461972ffa4c9f9f5f8957e0505e55.png', N'20171125154826260_91ba76993f604ed482b570898f238d01.pdf', N'https://www.google.com', NULL, NULL, N'Dây đai răng', N'Dây đai răng S2M', N'Timing belts S2M', N'Timing belts S2M', 3)
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductVariantUnits] ON 
GO
INSERT [dbo].[ProductVariantUnits] ([Id], [Name]) VALUES (2, N'Cái')
GO
INSERT [dbo].[ProductVariantUnits] ([Id], [Name]) VALUES (3, N'Bộ')
GO
SET IDENTITY_INSERT [dbo].[ProductVariantUnits] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductVariants] ON 
GO
INSERT [dbo].[ProductVariants] ([Id], [VariantName], [VariantCode], [Price], [OnHand], [Reserved], [BrandName], [Origin], [Product_Id], [ProductVariantUnit_Id]) VALUES (2, N'ttt', N'AAA', CAST(3000000.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), N'GHO', N'Japan', 1, 2)
GO
INSERT [dbo].[ProductVariants] ([Id], [VariantName], [VariantCode], [Price], [OnHand], [Reserved], [BrandName], [Origin], [Product_Id], [ProductVariantUnit_Id]) VALUES (3, N'YYY', N'BBB', CAST(34.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), N'sdasf', N'dasds', 1, 3)
GO
INSERT [dbo].[ProductVariants] ([Id], [VariantName], [VariantCode], [Price], [OnHand], [Reserved], [BrandName], [Origin], [Product_Id], [ProductVariantUnit_Id]) VALUES (4, N'TTT', N'CCC', CAST(25000.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), N'Brazo', N'New York', 1, 2)
GO
INSERT [dbo].[ProductVariants] ([Id], [VariantName], [VariantCode], [Price], [OnHand], [Reserved], [BrandName], [Origin], [Product_Id], [ProductVariantUnit_Id]) VALUES (6, N'UUU', N'DDD', CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), N'ER', N'A', 1, 2)
GO
SET IDENTITY_INSERT [dbo].[ProductVariants] OFF
GO
SET IDENTITY_INSERT [dbo].[AspNetUsers] ON 
GO
INSERT [dbo].[AspNetUsers] ([Id], [AutoIncrementCode], [FullName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [TempPoName], [OrgName], [DepartmentName], [Address1], [Address2], [Address3], [Address4], [PostalCode], [Fax], [Webiste], [IndustryId], [ServiceId], [NumberOfDesigner], [NumberOfEmployee], [KnowByid], [Discriminator]) VALUES (N'a136cad6-b954-4db5-a029-4af58450eab9', 1, N'123', N'123@h.com', 1, N'AH9funEg6o7rFxF5fdczt8nBQkYdZv/Mw9uJnU+xvch8iXIq6lm34ZIwtm1wwsQeIA==', N'349e3f3e-710c-447f-9553-e2760ee42f7c', N'123', 0, 0, NULL, 1, 0, N'123@h.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, N'Customer')
GO
INSERT [dbo].[AspNetUsers] ([Id], [AutoIncrementCode], [FullName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [TempPoName], [OrgName], [DepartmentName], [Address1], [Address2], [Address3], [Address4], [PostalCode], [Fax], [Webiste], [IndustryId], [ServiceId], [NumberOfDesigner], [NumberOfEmployee], [KnowByid], [Discriminator]) VALUES (N'b6413b96-186e-4c5e-9b7d-bd55440939ae', 7, N'Tri Nguyen Thanh', N'tribk08@gmail.com', 1, N'ANjyWd5LCMK+kFKUHwyQktD7CjDu7nuTHOZQBVB74hYJjm64a2b62VJ2y+aqoXZBuQ==', N'5a9e8e95-1287-4996-841e-a207f2a90259', NULL, 0, 0, NULL, 1, 0, N'tribk08@gmail.com', NULL, N'upup', NULL, N'123 Ta La Ai', NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, N'Customer')
GO
INSERT [dbo].[AspNetUsers] ([Id], [AutoIncrementCode], [FullName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [TempPoName], [OrgName], [DepartmentName], [Address1], [Address2], [Address3], [Address4], [PostalCode], [Fax], [Webiste], [IndustryId], [ServiceId], [NumberOfDesigner], [NumberOfEmployee], [KnowByid], [Discriminator]) VALUES (N'b7b0f4a0-d42b-4081-928f-91b2210a023e', 5, N'MR NAM', N'plaza.magazine@gmail.com', 1, N'AAGzdxalWwB2LiDgVS2S+hOT7Yv4Y2sKKJwwaEM1IBfveE5NUrdzAPFgNEa5LwZagg==', N'6de20bc1-6fa9-4aea-8535-f3ef03c35b43', NULL, 0, 0, NULL, 1, 0, N'plaza.magazine@gmail.com', NULL, N'concung', NULL, N'123 Trần Hưng Đạo, P4, Q5', NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, N'Customer')
GO
INSERT [dbo].[AspNetUsers] ([Id], [AutoIncrementCode], [FullName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [TempPoName], [OrgName], [DepartmentName], [Address1], [Address2], [Address3], [Address4], [PostalCode], [Fax], [Webiste], [IndustryId], [ServiceId], [NumberOfDesigner], [NumberOfEmployee], [KnowByid], [Discriminator]) VALUES (N'de28dabf-7047-47d2-91e0-5230c2b8b087', 2, NULL, N'admin@abc.com', 1, N'AI4Y5pxTq2d/NawXmGuQiOIqKR43+fEtvTh32kriapwJTUSxvd/0WWEdkaYCv6/5Vg==', N'703ea8cd-e573-46f4-8fc9-cfe7f06be55c', NULL, 0, 0, NULL, 1, 0, N'admin@abc.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'ApplicationUser')
GO
INSERT [dbo].[AspNetUsers] ([Id], [AutoIncrementCode], [FullName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [TempPoName], [OrgName], [DepartmentName], [Address1], [Address2], [Address3], [Address4], [PostalCode], [Fax], [Webiste], [IndustryId], [ServiceId], [NumberOfDesigner], [NumberOfEmployee], [KnowByid], [Discriminator]) VALUES (N'e2043988-480e-4689-8532-d512b4a45f84', 3, N'Lê Khả Sỹ', N'lekhasy@outlook.com', 1, N'APNaegGt9fikTH1x8+KB3rcpt/VvGCFwXd6I3wdBWvMlqOmfPNhBAiLWfmNut8MlIA==', N'596c3251-59a7-49c6-86a1-11432e6b483a', N'0993142171', 0, 0, NULL, 1, 0, N'lekhasy@outlook.com', NULL, N'Citigo', N'Dev 3', N'Số 7, trần khát chân, quận hai bà trưng, hà nội', N'DC2', N'DC3', N'DC 4', N'81000', N'4321', N'http://google.com', 0, 0, 0, 0, 0, N'Customer')
GO
INSERT [dbo].[AspNetUsers] ([Id], [AutoIncrementCode], [FullName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [TempPoName], [OrgName], [DepartmentName], [Address1], [Address2], [Address3], [Address4], [PostalCode], [Fax], [Webiste], [IndustryId], [ServiceId], [NumberOfDesigner], [NumberOfEmployee], [KnowByid], [Discriminator]) VALUES (N'ec49be79-03e4-42f7-ae53-2c1ab8b4482b', 4, N'Test', NULL, 1, N'ALGpOVKfSyfT0wdhV4cJu32d9QXhQsUqqw6ecSkPbII9YW9DlRlqnE78m6/3v9mZgA==', N'54d54402-39b1-42ac-94bc-cea5bc2db286', NULL, 0, 0, NULL, 1, 0, N'thangphuong88@gmail.com', NULL, N'ABC', NULL, N'123 trinh dinh trong', NULL, NULL, NULL, NULL, NULL, N'fdsfsdfds', 0, 0, 0, 0, 0, N'Customer')
GO
INSERT [dbo].[AspNetUsers] ([Id], [AutoIncrementCode], [FullName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [TempPoName], [OrgName], [DepartmentName], [Address1], [Address2], [Address3], [Address4], [PostalCode], [Fax], [Webiste], [IndustryId], [ServiceId], [NumberOfDesigner], [NumberOfEmployee], [KnowByid], [Discriminator]) VALUES (N'fa33f0cb-02e0-48a7-a030-7364fdb608fb', 6, N'adsf', N'dinhngoc27@gmail.com', 0, N'AAYNS8Wa3fewdcv6nYCTi8uoQGFjIsZZAi4cofVx2+I02OU+zwVq9dwG3UoFWxwWGg==', N'a749de80-2f65-448c-be5a-be761b356471', NULL, 0, 0, NULL, 1, 0, N'dinhngoc27@gmail.com', NULL, N'ádf', NULL, N'sdfá', NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, 0, 0, N'Customer')
GO
SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCarts] ON 
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (58, 2, NULL, 4)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (59, 3, NULL, 2)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (60, 2, NULL, 4)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (61, 4, NULL, 2)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (62, 4, NULL, 4)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (63, 4, NULL, 2)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (64, 3, NULL, 4)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (65, 4, NULL, 2)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (66, 2, NULL, 4)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (67, 2, NULL, 2)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (68, 15, NULL, 4)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (69, 4, NULL, 4)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (70, 6, NULL, 2)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (71, 3, NULL, 3)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (73, 1, NULL, 6)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (74, 4, NULL, 3)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (85, 4, N'b7b0f4a0-d42b-4081-928f-91b2210a023e', 3)
GO
INSERT [dbo].[ProductCarts] ([Id], [Quantity], [Customer_Id], [ProductVariant_Id]) VALUES (86, 16, N'b7b0f4a0-d42b-4081-928f-91b2210a023e', 2)
GO
SET IDENTITY_INSERT [dbo].[ProductCarts] OFF
GO
SET IDENTITY_INSERT [dbo].[PurchaseOrders] ON 
GO
INSERT [dbo].[PurchaseOrders] ([Id], [Code], [Name], [State], [CreatedDate], [Customer_Id], [IsDeleted], [PaymentMethod], [CustomerAddress], [CustomerPhone], [CustomerEmail], [CustomerWebsite]) VALUES (1, N'171201110134', N'PO_Order', 5, CAST(N'2017-12-01T23:02:07.140' AS DateTime), N'e2043988-480e-4689-8532-d512b4a45f84', 0, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [Code], [Name], [State], [CreatedDate], [Customer_Id], [IsDeleted], [PaymentMethod], [CustomerAddress], [CustomerPhone], [CustomerEmail], [CustomerWebsite]) VALUES (3, N'171201111513', N'EEE', 2, CAST(N'2017-12-01T23:15:29.133' AS DateTime), N'b7b0f4a0-d42b-4081-928f-91b2210a023e', 0, 2, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [Code], [Name], [State], [CreatedDate], [Customer_Id], [IsDeleted], [PaymentMethod], [CustomerAddress], [CustomerPhone], [CustomerEmail], [CustomerWebsite]) VALUES (6, N'171203100530', N'RRR', 1, CAST(N'2017-12-03T22:06:17.707' AS DateTime), N'b7b0f4a0-d42b-4081-928f-91b2210a023e', 0, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [Code], [Name], [State], [CreatedDate], [Customer_Id], [IsDeleted], [PaymentMethod], [CustomerAddress], [CustomerPhone], [CustomerEmail], [CustomerWebsite]) VALUES (7, N'171203103011', N'My_Back_PO', 2, CAST(N'2017-12-03T22:33:46.520' AS DateTime), N'e2043988-480e-4689-8532-d512b4a45f84', 0, 0, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [Code], [Name], [State], [CreatedDate], [Customer_Id], [IsDeleted], [PaymentMethod], [CustomerAddress], [CustomerPhone], [CustomerEmail], [CustomerWebsite]) VALUES (9, N'171203103534', N'My_Back_Temp_123', 2, CAST(N'2017-12-03T22:35:42.290' AS DateTime), N'e2043988-480e-4689-8532-d512b4a45f84', 0, 1, N'Số 7, trần khát chân, quận hai bà trưng, hà nội', N'0993142171', N'lekhasy@outlook.com', N'http://google.com')
GO
INSERT [dbo].[PurchaseOrders] ([Id], [Code], [Name], [State], [CreatedDate], [Customer_Id], [IsDeleted], [PaymentMethod], [CustomerAddress], [CustomerPhone], [CustomerEmail], [CustomerWebsite]) VALUES (10, N'171205092753', N'UUU', 5, CAST(N'2017-12-05T21:28:12.853' AS DateTime), N'b7b0f4a0-d42b-4081-928f-91b2210a023e', 0, 0, N'123 Trần Hưng Đạo, P4, Q5', NULL, N'plaza.magazine@gmail.com', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [Code], [Name], [State], [CreatedDate], [Customer_Id], [IsDeleted], [PaymentMethod], [CustomerAddress], [CustomerPhone], [CustomerEmail], [CustomerWebsite]) VALUES (11, N'171208114359', N'TTT', 4, CAST(N'2017-12-08T23:44:08.953' AS DateTime), N'b7b0f4a0-d42b-4081-928f-91b2210a023e', 0, 0, N'123 Trần Hưng Đạo, P4, Q5', NULL, N'plaza.magazine@gmail.com', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [Code], [Name], [State], [CreatedDate], [Customer_Id], [IsDeleted], [PaymentMethod], [CustomerAddress], [CustomerPhone], [CustomerEmail], [CustomerWebsite]) VALUES (12, N'171209124937', N'HOHO', 2, CAST(N'2017-12-09T12:51:06.390' AS DateTime), N'b7b0f4a0-d42b-4081-928f-91b2210a023e', 0, 0, N'123 Trần Hưng Đạo, P4, Q5', NULL, N'plaza.magazine@gmail.com', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [Code], [Name], [State], [CreatedDate], [Customer_Id], [IsDeleted], [PaymentMethod], [CustomerAddress], [CustomerPhone], [CustomerEmail], [CustomerWebsite]) VALUES (13, N'171209030304', N'Temp_171209030304', 1, CAST(N'2017-12-09T15:03:04.213' AS DateTime), N'b7b0f4a0-d42b-4081-928f-91b2210a023e', 0, 0, N'123 Trần Hưng Đạo, P4, Q5', NULL, N'plaza.magazine@gmail.com', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [Code], [Name], [State], [CreatedDate], [Customer_Id], [IsDeleted], [PaymentMethod], [CustomerAddress], [CustomerPhone], [CustomerEmail], [CustomerWebsite]) VALUES (14, N'171209061703', N'TATA', 1, CAST(N'2017-12-09T18:17:36.277' AS DateTime), N'b7b0f4a0-d42b-4081-928f-91b2210a023e', 0, 0, N'123 Trần Hưng Đạo, P4, Q5', NULL, N'plaza.magazine@gmail.com', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [Code], [Name], [State], [CreatedDate], [Customer_Id], [IsDeleted], [PaymentMethod], [CustomerAddress], [CustomerPhone], [CustomerEmail], [CustomerWebsite]) VALUES (15, N'171209063234', N'Hura', 4, CAST(N'2017-12-09T18:33:16.147' AS DateTime), N'b7b0f4a0-d42b-4081-928f-91b2210a023e', 0, 0, N'123 Trần Hưng Đạo, P4, Q5', NULL, N'plaza.magazine@gmail.com', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [Code], [Name], [State], [CreatedDate], [Customer_Id], [IsDeleted], [PaymentMethod], [CustomerAddress], [CustomerPhone], [CustomerEmail], [CustomerWebsite]) VALUES (16, N'171209064005', N'HURA', 1, CAST(N'2017-12-09T18:42:20.297' AS DateTime), N'b7b0f4a0-d42b-4081-928f-91b2210a023e', 0, 0, N'123 Trần Hưng Đạo, P4, Q5', NULL, N'plaza.magazine@gmail.com', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [Code], [Name], [State], [CreatedDate], [Customer_Id], [IsDeleted], [PaymentMethod], [CustomerAddress], [CustomerPhone], [CustomerEmail], [CustomerWebsite]) VALUES (17, N'171210051100', N'PO_la', 1, CAST(N'2017-12-10T17:14:55.107' AS DateTime), N'b6413b96-186e-4c5e-9b7d-bd55440939ae', 0, 0, N'123 Ta La Ai', NULL, N'tribk08@gmail.com', NULL)
GO
INSERT [dbo].[PurchaseOrders] ([Id], [Code], [Name], [State], [CreatedDate], [Customer_Id], [IsDeleted], [PaymentMethod], [CustomerAddress], [CustomerPhone], [CustomerEmail], [CustomerWebsite]) VALUES (18, N'171210053628', N'PO Temp', 1, CAST(N'2017-12-10T17:37:06.330' AS DateTime), N'e2043988-480e-4689-8532-d512b4a45f84', 0, 0, N'Số 7, trần khát chân, quận hai bà trưng, hà nội', N'0993142171', N'lekhasy@outlook.com', N'http://google.com')
GO
SET IDENTITY_INSERT [dbo].[PurchaseOrders] OFF
GO
SET IDENTITY_INSERT [dbo].[PurchaseOrderDetails] ON 
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (1, 1, CAST(N'2017-12-04T23:02:07.203' AS DateTime), 2, 3, 1, CAST(10000.00 AS Decimal(18, 2)), CAST(10000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (2, 1, CAST(N'2017-12-04T23:02:07.263' AS DateTime), 2, 6, 1, CAST(10000.00 AS Decimal(18, 2)), CAST(10000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (4, 4, CAST(N'2017-12-04T23:15:29.157' AS DateTime), 2, 4, 3, CAST(10000.00 AS Decimal(18, 2)), CAST(40000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (7, 5, CAST(N'2017-12-06T21:30:21.750' AS DateTime), 1, 4, NULL, CAST(10000.00 AS Decimal(18, 2)), CAST(50000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (8, 4, CAST(N'2017-12-06T21:30:21.757' AS DateTime), 1, 2, NULL, CAST(10000.00 AS Decimal(18, 2)), CAST(40000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (9, 5, CAST(N'2017-12-06T22:06:17.707' AS DateTime), 1, 4, 6, CAST(10000.00 AS Decimal(18, 2)), CAST(50000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (10, 3, CAST(N'2017-12-06T22:06:17.707' AS DateTime), 1, 2, 6, CAST(10000.00 AS Decimal(18, 2)), CAST(30000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (11, 1, CAST(N'2017-12-06T22:33:46.603' AS DateTime), 2, 3, 7, CAST(10000.00 AS Decimal(18, 2)), CAST(10000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (12, 1, CAST(N'2017-12-06T22:33:46.653' AS DateTime), 2, 6, 7, CAST(10000.00 AS Decimal(18, 2)), CAST(10000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (13, 1, CAST(N'2017-12-06T22:35:18.567' AS DateTime), 1, 3, NULL, CAST(10000.00 AS Decimal(18, 2)), CAST(10000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (16, 9, CAST(N'2017-12-08T21:28:12.880' AS DateTime), 2, 2, 10, CAST(3000000.00 AS Decimal(18, 2)), CAST(27000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (17, 5, CAST(N'2017-12-08T21:28:12.900' AS DateTime), 2, 4, 10, CAST(25000.00 AS Decimal(18, 2)), CAST(125000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (18, 147, NULL, 2, 3, 9, CAST(34.00 AS Decimal(18, 2)), CAST(4998.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (19, 18, CAST(N'2017-12-17T14:30:11.347' AS DateTime), 2, 6, 9, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (20, 3, CAST(N'2017-12-11T23:44:08.977' AS DateTime), 2, 4, 11, CAST(25000.00 AS Decimal(18, 2)), CAST(75000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (21, 22, CAST(N'2017-12-16T12:51:06.467' AS DateTime), 2, 4, 12, CAST(25000.00 AS Decimal(18, 2)), CAST(550000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (22, 2, CAST(N'2017-12-12T15:03:04.240' AS DateTime), 1, 2, 13, CAST(3000000.00 AS Decimal(18, 2)), CAST(6000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (23, 5, CAST(N'2017-12-12T18:17:36.277' AS DateTime), 1, 4, 14, CAST(25000.00 AS Decimal(18, 2)), CAST(125000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (24, 30, CAST(N'2017-12-16T18:17:36.277' AS DateTime), 1, 2, 14, CAST(3000000.00 AS Decimal(18, 2)), CAST(90000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (25, 4, CAST(N'2017-12-12T18:33:16.150' AS DateTime), 1, 2, 15, CAST(3000000.00 AS Decimal(18, 2)), CAST(12000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (26, 6, CAST(N'2017-12-12T18:33:16.150' AS DateTime), 1, 4, 15, CAST(25000.00 AS Decimal(18, 2)), CAST(150000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (27, 4, CAST(N'2017-12-12T18:42:20.297' AS DateTime), 1, 2, 16, CAST(3000000.00 AS Decimal(18, 2)), CAST(12000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (28, 1, CAST(N'2017-12-13T17:14:55.107' AS DateTime), 1, 4, 17, CAST(25000.00 AS Decimal(18, 2)), CAST(25000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (29, 1, CAST(N'2017-12-13T17:14:55.107' AS DateTime), 1, 6, 17, CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[PurchaseOrderDetails] ([Id], [Quantity], [ShipDate], [State], [Product_Id], [PurchaseOrder_Id], [Price], [TotalAmount]) VALUES (30, 3, CAST(N'2017-12-13T17:37:06.330' AS DateTime), 1, 3, 18, CAST(34.00 AS Decimal(18, 2)), CAST(102.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[PurchaseOrderDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[ShipDateSettings] ON 
GO
INSERT [dbo].[ShipDateSettings] ([Id], [QuantityOrderMax], [TargetDateNumber]) VALUES (1, 10, 3)
GO
INSERT [dbo].[ShipDateSettings] ([Id], [QuantityOrderMax], [TargetDateNumber]) VALUES (2, 50, 7)
GO
INSERT [dbo].[ShipDateSettings] ([Id], [QuantityOrderMax], [TargetDateNumber]) VALUES (3, 120, 12)
GO
SET IDENTITY_INSERT [dbo].[ShipDateSettings] OFF
GO
INSERT [dbo].[ShipDateSettingProductVariants] ([ShipDateSetting_Id], [ProductVariant_Id]) VALUES (1, 2)
GO
INSERT [dbo].[ShipDateSettingProductVariants] ([ShipDateSetting_Id], [ProductVariant_Id]) VALUES (2, 2)
GO
INSERT [dbo].[ShipDateSettingProductVariants] ([ShipDateSetting_Id], [ProductVariant_Id]) VALUES (1, 3)
GO
INSERT [dbo].[ShipDateSettingProductVariants] ([ShipDateSetting_Id], [ProductVariant_Id]) VALUES (2, 3)
GO
INSERT [dbo].[ShipDateSettingProductVariants] ([ShipDateSetting_Id], [ProductVariant_Id]) VALUES (1, 4)
GO
INSERT [dbo].[ShipDateSettingProductVariants] ([ShipDateSetting_Id], [ProductVariant_Id]) VALUES (2, 4)
GO
INSERT [dbo].[ShipDateSettingProductVariants] ([ShipDateSetting_Id], [ProductVariant_Id]) VALUES (3, 4)
GO
INSERT [dbo].[ShipDateSettingProductVariants] ([ShipDateSetting_Id], [ProductVariant_Id]) VALUES (1, 6)
GO
INSERT [dbo].[ShipDateSettingProductVariants] ([ShipDateSetting_Id], [ProductVariant_Id]) VALUES (2, 6)
GO
INSERT [dbo].[ShipDateSettingProductVariants] ([ShipDateSetting_Id], [ProductVariant_Id]) VALUES (3, 6)
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'624057f6-b451-4c1d-abf9-8f2a4c6282f9', N'Admin')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'cc7aa678-bd3e-4a65-9a96-87a5f7ed92a0', N'Customer')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'548068d2-4fa6-49ee-9a41-3d4c932cc98b', N'Editor')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a136cad6-b954-4db5-a029-4af58450eab9', N'624057f6-b451-4c1d-abf9-8f2a4c6282f9')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'de28dabf-7047-47d2-91e0-5230c2b8b087', N'624057f6-b451-4c1d-abf9-8f2a4c6282f9')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b6413b96-186e-4c5e-9b7d-bd55440939ae', N'cc7aa678-bd3e-4a65-9a96-87a5f7ed92a0')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b7b0f4a0-d42b-4081-928f-91b2210a023e', N'cc7aa678-bd3e-4a65-9a96-87a5f7ed92a0')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e2043988-480e-4689-8532-d512b4a45f84', N'cc7aa678-bd3e-4a65-9a96-87a5f7ed92a0')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ec49be79-03e4-42f7-ae53-2c1ab8b4482b', N'cc7aa678-bd3e-4a65-9a96-87a5f7ed92a0')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fa33f0cb-02e0-48a7-a030-7364fdb608fb', N'cc7aa678-bd3e-4a65-9a96-87a5f7ed92a0')
GO
SET IDENTITY_INSERT [dbo].[PostCategories] ON 
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (1, 1, N'Công nghệ', N'Công nghệ', N'<p>sdas</p>
', N'<p>dasd</p>
', N'sadsa', N'dsa', NULL, NULL, NULL)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (2, 2, N'Hướng dẫn sử dụng', N'User Manual', N'<p>hướng dẫn sử dụng cho người d&ugrave;ng</p>
', N'<p>user manual</p>
', N'Từ khóa cho trang hướng dẫn sử dụng', N'các  thông tin về hướng dẫn sử dụng', NULL, NULL, NULL)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (3, 3, N'Triển lãm sự kiện', N'Event', N'<p>event</p>
', N'<p>&aacute;d</p>
', N'2', N'1', NULL, NULL, NULL)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (5, NULL, N'Chế tạo cơ khí', N'Chế tạo cơ khí', N'<p>das</p>
', N'<p>dasdsad</p>
', N'asdsa', N'Dsad', N'fsd', N'fds', 1)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (6, NULL, N'Máy móc công nghệ cao', N'Máy móc công nghệ cao', N'<p>fds</p>
', N'<p>dsad</p>
', N'dsa', N'dsad', NULL, NULL, 1)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (7, NULL, N'Cách chế tạo ốc vít', N'Cách chế tạo ốc vít', N'<p>dsad</p>
', N'<p>dsa</p>
', N'Dsa', N'dsa', N'fsdf', N'fdsf', 1)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (8, NULL, N'Tấm gương cơ khí thành công', N'Tấm gương cơ khí thành công', N'<p>das</p>
', N'<p>dsa</p>
', N'def', N'Dsa', N'dsa', N'das', 5)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (9, NULL, N'Hướng dẫn đặt hàng cơ khí', N'Hướng dẫn đặt hàng cơ khí', N'<p>dsadsa</p>
', N'<p>dasda</p>
', N'dsad', N'dsad', NULL, NULL, 2)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (10, NULL, N'Hướng dẫn chọn sản phẩm', N'Hướng dẫn chọn sản phẩm', N'<p>dasdsa</p>
', N'<p>dsada</p>
', N'dasds', N'dasd', NULL, NULL, 2)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (11, NULL, N'Hướng dẫn cách thức mua hàng', N'Hướng dẫn cách thức mua hàng', N'<p>dsadsad</p>
', N'<p>dasdas</p>
', N'dsad', N'dsad', NULL, NULL, 2)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (12, NULL, N'Hướng dẫn chọn vật liệu', N'Hướng dẫn chọn vật liệu', N'<p>sadas</p>
', N'<p>dsad</p>
', N'dsad', N'dasd', NULL, NULL, 2)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (13, NULL, N'Triển lãm cơ khí toàn quốc', N'Triển lãm cơ khí toàn quốc', N'<p>dsad</p>
', N'<p>dasdas</p>
', N'dasda', N'dsa', NULL, NULL, 3)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (14, NULL, N'Sự kiện doanh nhân cơ khí 2017', N'Sự kiện doanh nhân cơ khí 2017', N'<p>dasdsa</p>
', N'<p>dsad</p>
', N'dsad', N'dsad', NULL, NULL, 3)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (15, NULL, N'Giảm giá toàn bộ sản phẩm cơ khí', N'Giảm giá toàn bộ sản phẩm cơ khí', N'<p>dsa</p>
', N'<p>dsad</p>
', N'dasd', N'das', NULL, NULL, 3)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (16, NULL, N'Chế tạo máy bay từ phế thải', N'Chế tạo máy bay từ phế thải', N'<p>dsa</p>
', N'<p>dsad</p>
', N'dsad', N'dsad', N'dsa', N'sadsa', 5)
GO
INSERT [dbo].[PostCategories] ([Id], [RootCategoryIdentifier], [Name], [Name_en], [Description], [Description_en], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [ParentCategory_Id]) VALUES (17, NULL, N'Chế tạo máy bay từ phế thải', N'Chế tạo máy bay từ phế thải', N'<p>dsa</p>
', N'<p>dsad</p>
', N'dsad', N'dsad', N'dsa', N'sadsa', 5)
GO
SET IDENTITY_INSERT [dbo].[PostCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[Posts] ON 
GO
INSERT [dbo].[Posts] ([Id], [Title], [Title_en], [Content], [Content_en], [Sumary], [Sumary_en], [IsUserGuide], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [CreatedDate], [LastModifiedDate], [Category_Id]) VALUES (1, N'Tiềm năng phát triển vật liệu mới ở Việt Nam', N'New material development oppotunity in vietnam', N'<p>Việc ứng dụng vật liệu mới đem lại hiệu quả về kinh tế, m&ocirc;i trường, &yacute; nghĩa thiết thực với đời sống của người d&acirc;n. Một số vật liệu mới ở Việt Nam c&oacute; thể kể đến như: Dập đ&aacute;m ch&aacute;y bằng một loại vật liệu mới dạng dung dịch; c&oacute; thể trộn 100% c&aacute;t nh&acirc;n tạo với b&ecirc; t&ocirc;ng vẫn đảm bảo c&aacute;c ti&ecirc;u ch&iacute; kỹ thuật; c&aacute;t t&aacute;i chế đầu ti&ecirc;n từ xỉ than...</p>

<p>Theo Bộ Khoa học v&agrave; C&ocirc;ng nghệ, c&ocirc;ng nghệ&nbsp;<a href="http://vtv.vn/vat-lieu-moi.html" target="_blank" title="vật liệu mới">vật liệu mới</a>&nbsp;hiện l&agrave; một trong 4 lĩnh vực trọng t&acirc;m được Nh&agrave; nước ưu ti&ecirc;n ph&aacute;t triển. Việt Nam đang tập trung ph&aacute;t triển c&aacute;c loại vật liệu mới như: vật liệu cảm biến, vật liệu chế tạo bộ nhớ thế hệ mới, vật liệu tản nhiệt, vật liệu cho c&aacute;c thiết bị giải tr&iacute;, vật liệu nano, composite&hellip;</p>

<p>Vật liệu mới c&oacute; những t&iacute;nh chất ưu việt so với vật liệu truyền thống về gi&aacute; cả, khả năng th&acirc;n thiện m&ocirc;i trường, độ bền của vật liệu&hellip; Ng&agrave;nh x&acirc;y dựng, đ&oacute;ng t&agrave;u, viễn th&ocirc;ng, y tế&hellip; l&agrave; những ng&agrave;nh đi đầu trong việc ứng dụng vật liệu mới.</p>

<p>Cũng theo Bộ Khoa học v&agrave; C&ocirc;ng nghệ, với c&aacute;c sản phẩm được tạo n&ecirc;n từ c&ocirc;ng nghệ vật liệu mới v&agrave; đ&atilde; chứng minh được hiệu quả, việc ứng dụng sẽ theo lộ tr&igrave;nh, hỗ trợ song song, tiến tới c&oacute; thể thay thế ho&agrave;n to&agrave;n vật liệu truyền thống. V&iacute; dụ, với vật liệu mới trong ng&agrave;nh x&acirc;y dựng, ban đầu sẽ &aacute;p dụng từ 10%, tiến tới 100%, đặc biệt l&agrave; c&aacute;c c&ocirc;ng tr&igrave;nh x&acirc;y dựng vốn ng&acirc;n s&aacute;ch.</p>
', N'<p>En_Việc ứng dụng vật liệu mới đem lại hiệu quả về kinh tế, m&ocirc;i trường, &yacute; nghĩa thiết thực với đời sống của người d&acirc;n. Một số vật liệu mới ở Việt Nam c&oacute; thể kể đến như: Dập đ&aacute;m ch&aacute;y bằng một loại vật liệu mới dạng dung dịch; c&oacute; thể trộn 100% c&aacute;t nh&acirc;n tạo với b&ecirc; t&ocirc;ng vẫn đảm bảo c&aacute;c ti&ecirc;u ch&iacute; kỹ thuật; c&aacute;t t&aacute;i chế đầu ti&ecirc;n từ xỉ than...</p>

<p>Theo Bộ Khoa học v&agrave; C&ocirc;ng nghệ, c&ocirc;ng nghệ&nbsp;<a href="http://vtv.vn/vat-lieu-moi.html" target="_blank" title="vật liệu mới">vật liệu mới</a>&nbsp;hiện l&agrave; một trong 4 lĩnh vực trọng t&acirc;m được Nh&agrave; nước ưu ti&ecirc;n ph&aacute;t triển. Việt Nam đang tập trung ph&aacute;t triển c&aacute;c loại vật liệu mới như: vật liệu cảm biến, vật liệu chế tạo bộ nhớ thế hệ mới, vật liệu tản nhiệt, vật liệu cho c&aacute;c thiết bị giải tr&iacute;, vật liệu nano, composite&hellip;</p>

<p>Vật liệu mới c&oacute; những t&iacute;nh chất ưu việt so với vật liệu truyền thống về gi&aacute; cả, khả năng th&acirc;n thiện m&ocirc;i trường, độ bền của vật liệu&hellip; Ng&agrave;nh x&acirc;y dựng, đ&oacute;ng t&agrave;u, viễn th&ocirc;ng, y tế&hellip; l&agrave; những ng&agrave;nh đi đầu trong việc ứng dụng vật liệu mới.</p>

<p>Cũng theo Bộ Khoa học v&agrave; C&ocirc;ng nghệ, với c&aacute;c sản phẩm được tạo n&ecirc;n từ c&ocirc;ng nghệ vật liệu mới v&agrave; đ&atilde; chứng minh được hiệu quả, việc ứng dụng sẽ theo lộ tr&igrave;nh, hỗ trợ song song, tiến tới c&oacute; thể thay thế ho&agrave;n to&agrave;n vật liệu truyền thống. V&iacute; dụ, với vật liệu mới trong ng&agrave;nh x&acirc;y dựng, ban đầu sẽ &aacute;p dụng từ 10%, tiến tới 100%, đặc biệt l&agrave; c&aacute;c c&ocirc;ng tr&igrave;nh x&acirc;y dựng vốn ng&acirc;n s&aacute;ch.</p>
', N'Việc ứng dụng vật liệu mới đem lại hiệu quả về kinh tế, môi trường, ý nghĩa thiết thực với đời sống của người dân. Một số vật liệu mới ở Việt Nam có thể kể đến như: Dập đám cháy bằng một loại vật liệu mới dạng dung dịch; có thể trộn 100% cát nhân tạo với bê tông vẫn đảm bảo các tiêu chí kỹ thuật; cát tái chế đầu tiên từ xỉ than...', N'en_Việc ứng dụng vật liệu mới đem lại hiệu quả về kinh tế, môi trường, ý nghĩa thiết thực với đời sống của người dân. Một số vật liệu mới ở Việt Nam có thể kể đến như: Dập đám cháy bằng một loại vật liệu mới dạng dung dịch; có thể trộn 100% cát nhân tạo với bê tông vẫn đảm bảo các tiêu chí kỹ thuật; cát tái chế đầu tiên từ xỉ than...', 0, N'tk', N'mt', N'tk_en', N'mt_en', CAST(N'2017-11-16T19:40:00.837' AS DateTime), CAST(N'2017-11-16T21:48:12.800' AS DateTime), 1)
GO
INSERT [dbo].[Posts] ([Id], [Title], [Title_en], [Content], [Content_en], [Sumary], [Sumary_en], [IsUserGuide], [MetaKeyword], [MetaDescription], [MetaKeyword_en], [MetaDescription_en], [CreatedDate], [LastModifiedDate], [Category_Id]) VALUES (3, N'Ngày 8/12, iPhone X chính hãng lên kệ tại Việt Nam với giá 30 triệu đồng', N'EN_Ngày 8/12, iPhone X chính hãng lên kệ tại Việt Nam với giá 30 triệu đồng', N'<p>Theo FPT, th&ocirc;ng qua hai hệ thống FPT Shop v&agrave; F.Studio, những chiếc&nbsp;<a href="http://vtv.vn/iphone-x.html" target="_blank">iPhone X</a>với m&atilde; VN/A sẽ ch&iacute;nh thức l&ecirc;n kệ v&agrave;o ng&agrave;y 8/12 tới đ&acirc;y. FPT cho biết kh&aacute;ch h&agrave;ng c&oacute; thể đặt mua trước từ ng&agrave;y 1 - 7/12.</p>

<p>Về gi&aacute; b&aacute;n, iPhone X sẽ được b&aacute;n lần lượt ở mức 29.990.000 đồng v&agrave; 34.790.000 đồng tương ứng với 2 phi&ecirc;n bản dung lượng 64GB v&agrave; 256GB. Đ&aacute;ng ch&uacute; &yacute; trong lần b&aacute;n lần n&agrave;y, gi&aacute; b&aacute;n kh&ocirc;ng thay đổi tại c&aacute;c phi&ecirc;n bản m&agrave;u bạc cũng như x&aacute;m.</p>

<p><img alt="Ngày 8/12, iPhone X chính hãng lên kệ tại Việt Nam với giá 30 triệu đồng - Ảnh 1." src="https://vtv1.mediacdn.vn/thumb_w/640/2017/if-you-ask-me-i-think-the-iphone-x-is-much-better-than-the-iphone-8-1510223473242.jpg" /></p>

<p>iPhone X ch&iacute;nh h&atilde;ng sẽ được b&aacute;n tại Việt Nam v&agrave;o ng&agrave;y 8/12 tới đ&acirc;y</p>

<p>Li&ecirc;n hệ với một đơn vị được nhập khẩu ch&iacute;nh h&atilde;ng iPhone kh&aacute;c l&agrave; Thế giới di động, đại diện của h&atilde;ng n&agrave;y cho biết sẽ b&aacute;n iPhone X ch&iacute;nh h&atilde;ng tại c&aacute;c cửa h&agrave;ng v&agrave;o ng&agrave;y 8/12 tới đ&acirc;y.</p>

<p>Đ&aacute;ng ch&uacute; &yacute;, h&atilde;ng n&agrave;y cũng cho ph&eacute;p người d&ugrave;ng đặt mua trước từ ng&agrave;y 1 - 7/12 tới. Ngo&agrave;i ra, gi&aacute; b&aacute;n cũng tương tự FPT l&agrave; 29.990.000 đồng v&agrave; 34.790.000 đồng tương ứng với 2 phi&ecirc;n bản dung lượng 64GB v&agrave; 256GB cho 2 m&agrave;u Silver (Bạc) v&agrave; Gray (X&aacute;m).</p>

<p>Trước đ&oacute;, một số lượng kh&ocirc;ng nhỏ những chiếc iPhone X đ&atilde; được b&aacute;n tại Việt Nam kể từ ng&agrave;y thiết bị n&agrave;y ch&iacute;nh thức l&ecirc;n kệ v&agrave;o ng&agrave;y 3/11. Tuy nhi&ecirc;n những chiếc iPhone X n&agrave;y đều được nhập về qua h&igrave;nh thức x&aacute;ch tay.</p>

<p>Sự c&oacute; mặt của những chiếc iPhone X ch&iacute;nh h&atilde;ng v&agrave;o đầu th&aacute;ng 12 tới tại Việt Nam được xem l&agrave; th&ocirc;ng tin rất vui cho những người d&ugrave;ng muốn sự &quot;an to&agrave;n&quot; tuyệt đối cho những thiết bị của m&igrave;nh.</p>

<p>Apple c&oacute; ch&iacute;nh s&aacute;ch bảo h&agrave;nh với những chiếc iPhone x&aacute;ch tay. Song kh&ocirc;ng phải thiết bị n&agrave;o cũng sẽ được c&aacute;c trung t&acirc;m bảo h&agrave;nh m&agrave;&nbsp;<a href="http://vtv.vn/cong-nghe/apple-lai-bao-nhieu-voi-moi-chiec-iphone-x-20171107144332591.htm" target="_blank">Apple</a>&nbsp;ủy quyền chấp nhận sửa chữa hoặc thay mới trong c&aacute;c trường hợp gặp sự cố: phải đủ giấy tờ mua b&aacute;n, m&atilde; m&aacute;y phải ph&ugrave; hợp...</p>

<p>&nbsp;</p>

<p><img alt="Ngày 8/12, iPhone X chính hãng lên kệ tại Việt Nam với giá 30 triệu đồng - Ảnh 2." src="https://vtv1.mediacdn.vn/2017/cotd111-1509597984111-1510826076491.png" /></p>

<p>Chi ph&iacute; sửa chữa cho iPhone X ở mức rất cao: chi ph&iacute; thay thế m&agrave;n h&igrave;nh l&ecirc;n đến 279 USD (khoảng 6,4 triệu đồng), đắt hơn bất cứ m&agrave;n h&igrave;nh iPhone n&agrave;o kh&aacute;c; tổng chi ph&iacute; sửa chữa bảo h&agrave;nh kh&aacute;c tr&ecirc;n iPhone X ở mức 549 USD (khoảng 12,5 triệu đồng) - số tiền đ&uacute;ng bằng gi&aacute; b&aacute;n khởi điểm của iPhone 7.</p>
', N'<p>En_Theo FPT, th&ocirc;ng qua hai hệ thống FPT Shop v&agrave; F.Studio, những chiếc&nbsp;<a href="http://vtv.vn/iphone-x.html" target="_blank">iPhone X</a>với m&atilde; VN/A sẽ ch&iacute;nh thức l&ecirc;n kệ v&agrave;o ng&agrave;y 8/12 tới đ&acirc;y. FPT cho biết kh&aacute;ch h&agrave;ng c&oacute; thể đặt mua trước từ ng&agrave;y 1 - 7/12.</p>

<p>Về gi&aacute; b&aacute;n, iPhone X sẽ được b&aacute;n lần lượt ở mức 29.990.000 đồng v&agrave; 34.790.000 đồng tương ứng với 2 phi&ecirc;n bản dung lượng 64GB v&agrave; 256GB. Đ&aacute;ng ch&uacute; &yacute; trong lần b&aacute;n lần n&agrave;y, gi&aacute; b&aacute;n kh&ocirc;ng thay đổi tại c&aacute;c phi&ecirc;n bản m&agrave;u bạc cũng như x&aacute;m.</p>

<p><img alt="Ngày 8/12, iPhone X chính hãng lên kệ tại Việt Nam với giá 30 triệu đồng - Ảnh 1." src="https://vtv1.mediacdn.vn/thumb_w/640/2017/if-you-ask-me-i-think-the-iphone-x-is-much-better-than-the-iphone-8-1510223473242.jpg" /></p>

<p>iPhone X ch&iacute;nh h&atilde;ng sẽ được b&aacute;n tại Việt Nam v&agrave;o ng&agrave;y 8/12 tới đ&acirc;y</p>

<p>Li&ecirc;n hệ với một đơn vị được nhập khẩu ch&iacute;nh h&atilde;ng iPhone kh&aacute;c l&agrave; Thế giới di động, đại diện của h&atilde;ng n&agrave;y cho biết sẽ b&aacute;n iPhone X ch&iacute;nh h&atilde;ng tại c&aacute;c cửa h&agrave;ng v&agrave;o ng&agrave;y 8/12 tới đ&acirc;y.</p>

<p>En_Đ&aacute;ng ch&uacute; &yacute;, h&atilde;ng n&agrave;y cũng cho ph&eacute;p người d&ugrave;ng đặt mua trước từ ng&agrave;y 1 - 7/12 tới. Ngo&agrave;i ra, gi&aacute; b&aacute;n cũng tương tự FPT l&agrave; 29.990.000 đồng v&agrave; 34.790.000 đồng tương ứng với 2 phi&ecirc;n bản dung lượng 64GB v&agrave; 256GB cho 2 m&agrave;u Silver (Bạc) v&agrave; Gray (X&aacute;m).</p>

<p>Trước đ&oacute;, một số lượng kh&ocirc;ng nhỏ những chiếc iPhone X đ&atilde; được b&aacute;n tại Việt Nam kể từ ng&agrave;y thiết bị n&agrave;y ch&iacute;nh thức l&ecirc;n kệ v&agrave;o ng&agrave;y 3/11. Tuy nhi&ecirc;n những chiếc iPhone X n&agrave;y đều được nhập về qua h&igrave;nh thức x&aacute;ch tay.</p>

<p>Sự c&oacute; mặt của những chiếc iPhone X ch&iacute;nh h&atilde;ng v&agrave;o đầu th&aacute;ng 12 tới tại Việt Nam được xem l&agrave; th&ocirc;ng tin rất vui cho những người d&ugrave;ng muốn sự &quot;an to&agrave;n&quot; tuyệt đối cho những thiết bị của m&igrave;nh.</p>

<p>Apple c&oacute; ch&iacute;nh s&aacute;ch bảo h&agrave;nh với những chiếc iPhone x&aacute;ch tay. Song kh&ocirc;ng phải thiết bị n&agrave;o cũng sẽ được c&aacute;c trung t&acirc;m bảo h&agrave;nh m&agrave;&nbsp;<a href="http://vtv.vn/cong-nghe/apple-lai-bao-nhieu-voi-moi-chiec-iphone-x-20171107144332591.htm" target="_blank">Apple</a>&nbsp;ủy quyền chấp nhận sửa chữa hoặc thay mới trong c&aacute;c trường hợp gặp sự cố: phải đủ giấy tờ mua b&aacute;n, m&atilde; m&aacute;y phải ph&ugrave; hợp...</p>

<p>&nbsp;</p>

<p><img alt="Ngày 8/12, iPhone X chính hãng lên kệ tại Việt Nam với giá 30 triệu đồng - Ảnh 2." src="https://vtv1.mediacdn.vn/2017/cotd111-1509597984111-1510826076491.png" />Chi ph&iacute; sửa chữa cho iPhone X ở mức rất cao: chi ph&iacute; thay thế m&agrave;n h&igrave;nh l&ecirc;n đến 279 USD (khoảng 6,4 triệu đồng), đắt hơn bất cứ m&agrave;n h&igrave;nh iPhone n&agrave;o kh&aacute;c; tổng chi ph&iacute; sửa chữa bảo h&agrave;nh kh&aacute;c tr&ecirc;n iPhone X ở mức 549 USD (khoảng 12,5 triệu đồng) - số tiền đ&uacute;ng bằng gi&aacute; b&aacute;n khởi điểm của iPhone 7.</p>
', N'Về giá bán, iPhone X sẽ được bán lần lượt ở mức 29.990.000 đồng và 34.790.000 đồng tương ứng với 2 phiên bản dung lượng 64GB và 256GB. Đáng chú ý trong lần bán lần này, giá bán không thay đổi tại các phiên bản màu bạc cũng như xám.', N'En_Về giá bán, iPhone X sẽ được bán lần lượt ở mức 29.990.000 đồng và 34.790.000 đồng tương ứng với 2 phiên bản dung lượng 64GB và 256GB. Đáng chú ý trong lần bán lần này, giá bán không thay đổi tại các phiên bản màu bạc cũng như xám.', 1, N'tk', N'mt', N'tk_en', N'mt_en', CAST(N'2017-11-16T19:41:28.597' AS DateTime), CAST(N'2017-12-09T13:39:20.367' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Posts] OFF
GO
