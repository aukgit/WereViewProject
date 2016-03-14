USE [F:\WORK\GIT\WEREVIEWPROJECT\WEREVIEWAPP\APP_DATA\WEREVIEWAPP.MDF]
GO
SET IDENTITY_INSERT [dbo].[UserPointSetting] ON 

INSERT [dbo].[UserPointSetting] ([UserPointSettingID], [TaskName], [Point]) VALUES (1, N'Post App', 5)
INSERT [dbo].[UserPointSetting] ([UserPointSettingID], [TaskName], [Point]) VALUES (2, N'Review App', 6)
INSERT [dbo].[UserPointSetting] ([UserPointSettingID], [TaskName], [Point]) VALUES (3, N'Review Liked', 4)
SET IDENTITY_INSERT [dbo].[UserPointSetting] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Slug]) VALUES (1, N'Games', N'Games')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Slug]) VALUES (2, N'Learning ', N'Learning')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Slug]) VALUES (3, N'System ', N'System')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Slug]) VALUES (4, N'Lifestyle ', N'Lifestyle')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Slug]) VALUES (5, N'Health ', N'Health')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Slug]) VALUES (6, N'Utility ', N'Utility')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Slug]) VALUES (7, N'Agriculture ', N'Agriculture')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Slug]) VALUES (8, N'Cooking ', N'Cooking')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Slug]) VALUES (9, N'Business ', N'Business')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Slug]) VALUES (10, N'Comics ', N'Comics')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Slug]) VALUES (11, N'Finance ', N'Finance')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Slug]) VALUES (12, N'Health & Fitness ', N'Health-Fitness')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Slug]) VALUES (13, N'Medical ', N'Medical')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Slug]) VALUES (14, N'Personalization', N'None')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Slug]) VALUES (15, N'Shopping ', N'Shopping')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Slug]) VALUES (16, N'Communication ', N'Communication')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Slug]) VALUES (17, N'Books & Reference ', N'Books-Reference')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Slug]) VALUES (18, N'Weather', N'None')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Slug]) VALUES (19, N'News & Magazines ', N'News-Magazines')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Slug]) VALUES (20, N'Sports ', N'Sports')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Slug]) VALUES (21, N'Widgets ', N'Widgets')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Slug]) VALUES (22, N'Productivity ', N'Productivity')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Slug]) VALUES (23, N'Media & Video ', N'Media-Video')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Slug]) VALUES (24, N'Live Wallpaper ', N'Live-Wallpaper')
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Slug]) VALUES (25, N'Transportation ', N'Transportation')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[GalleryCategory] ON 

INSERT [dbo].[GalleryCategory] ([GalleryCategoryID], [CategoryName], [Width], [Height], [IsAdvertise]) VALUES (1, N'Home Page Gallery (featured)', 481, 440, 0)
INSERT [dbo].[GalleryCategory] ([GalleryCategoryID], [CategoryName], [Width], [Height], [IsAdvertise]) VALUES (2, N'Suggestion Icon', 192, 119, 0)
INSERT [dbo].[GalleryCategory] ([GalleryCategoryID], [CategoryName], [Width], [Height], [IsAdvertise]) VALUES (3, N'App Gallery Images', 1140, 400, 0)
INSERT [dbo].[GalleryCategory] ([GalleryCategoryID], [CategoryName], [Width], [Height], [IsAdvertise]) VALUES (4, N'Gallery Icons', 80, 60, 0)
INSERT [dbo].[GalleryCategory] ([GalleryCategoryID], [CategoryName], [Width], [Height], [IsAdvertise]) VALUES (5, N'Search Icons', 117, 177, 0)
INSERT [dbo].[GalleryCategory] ([GalleryCategoryID], [CategoryName], [Width], [Height], [IsAdvertise]) VALUES (6, N'*Advertise Image Size*', 243, 246, 1)
INSERT [dbo].[GalleryCategory] ([GalleryCategoryID], [CategoryName], [Width], [Height], [IsAdvertise]) VALUES (7, N'Home Page Icon', 122, 115, 0)
INSERT [dbo].[GalleryCategory] ([GalleryCategoryID], [CategoryName], [Width], [Height], [IsAdvertise]) VALUES (8, N'Youtube Cover Image', 1140, 400, 0)
SET IDENTITY_INSERT [dbo].[GalleryCategory] OFF
SET IDENTITY_INSERT [dbo].[NotificationType] ON 

INSERT [dbo].[NotificationType] ([NotificationTypeID], [TypeName], [IsGood], [DefaultMessage], [MessageIconName]) VALUES (1, N'Message Added', 1, N' ', N'a')
INSERT [dbo].[NotificationType] ([NotificationTypeID], [TypeName], [IsGood], [DefaultMessage], [MessageIconName]) VALUES (2, N'App Added', 1, N'{0} app is added to the store.', N'a')
INSERT [dbo].[NotificationType] ([NotificationTypeID], [TypeName], [IsGood], [DefaultMessage], [MessageIconName]) VALUES (3, N'App Reviewed', 1, N'{0} app has been reviewed.', N'a')
INSERT [dbo].[NotificationType] ([NotificationTypeID], [TypeName], [IsGood], [DefaultMessage], [MessageIconName]) VALUES (4, N'Review Liked', 1, N'{0} review liked by {1}.', N'a')
INSERT [dbo].[NotificationType] ([NotificationTypeID], [TypeName], [IsGood], [DefaultMessage], [MessageIconName]) VALUES (5, N'Review Disliked', 0, N'Your review has been disliked.', N'a')
INSERT [dbo].[NotificationType] ([NotificationTypeID], [TypeName], [IsGood], [DefaultMessage], [MessageIconName]) VALUES (6, N'App Blocked', 0, N'''{0}'' app is blocked.', N'a')
INSERT [dbo].[NotificationType] ([NotificationTypeID], [TypeName], [IsGood], [DefaultMessage], [MessageIconName]) VALUES (7, N'Got Reported', 0, N'{0} has been reported by {1}', N'a')
INSERT [dbo].[NotificationType] ([NotificationTypeID], [TypeName], [IsGood], [DefaultMessage], [MessageIconName]) VALUES (8, N'Gained Points', 1, N'You have gained {0} points.', N'a')
INSERT [dbo].[NotificationType] ([NotificationTypeID], [TypeName], [IsGood], [DefaultMessage], [MessageIconName]) VALUES (9, N'Lose Points', 0, N'You have lost {0} points.', N'a')
SET IDENTITY_INSERT [dbo].[NotificationType] OFF
