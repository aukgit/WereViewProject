USE [D:\WORKING\GITHUB\WEREVIEWPROJECT\WEREVIEWAPP\APP_DATA\WEREVIEWAPP.MDF]
GO
/****** Object:  UserDefinedFunction [dbo].[SplitString]    Script Date: 23-Feb-16 2:41:12 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SplitString]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[SplitString]
GO
/****** Object:  StoredProcedure [dbo].[ResetWholeSystem]    Script Date: 23-Feb-16 2:41:12 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ResetWholeSystem]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ResetWholeSystem]
GO
/****** Object:  StoredProcedure [dbo].[ResetReviews]    Script Date: 23-Feb-16 2:41:12 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ResetReviews]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ResetReviews]
GO
/****** Object:  StoredProcedure [dbo].[ResetAppsAndUsers]    Script Date: 23-Feb-16 2:41:12 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ResetAppsAndUsers]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ResetAppsAndUsers]
GO
/****** Object:  StoredProcedure [dbo].[ResetApps]    Script Date: 23-Feb-16 2:41:12 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ResetApps]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ResetApps]
GO
/****** Object:  StoredProcedure [dbo].[ResetAppDrafts]    Script Date: 23-Feb-16 2:41:12 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ResetAppDrafts]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ResetAppDrafts]
GO
/****** Object:  StoredProcedure [dbo].[AppsSearch]    Script Date: 23-Feb-16 2:41:12 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AppsSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AppsSearch]
GO
/****** Object:  StoredProcedure [dbo].[AppsSearch]    Script Date: 23-Feb-16 2:41:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AppsSearch]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Alim Ul Karim
-- Create date: 
-- Description:	Search for apps
-- =============================================
CREATE PROCEDURE [dbo].[AppsSearch] 
	-- Add the parameters for the stored procedure here
      @SearchText VARCHAR(200) = 0
AS 
      BEGIN
	
            SET NOCOUNT ON;
            SELECT  *
            FROM    SplitString(''Querying SQL Server'', '' '');
      END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[ResetAppDrafts]    Script Date: 23-Feb-16 2:41:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ResetAppDrafts]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ResetAppDrafts]
AS 
      DELETE    FROM AppDraft;
      DBCC checkident (''AppDraft'', reseed, 0);
      RETURN 0' 
END
GO
/****** Object:  StoredProcedure [dbo].[ResetApps]    Script Date: 23-Feb-16 2:41:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ResetApps]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ResetApps]
AS 
      DELETE    FROM ReviewLikeDislike;
      DELETE    FROM Review;

      DBCC checkident (''Review'', reseed, 0);
      DBCC checkident (''ReviewLikeDislike'', reseed, 0);

      DELETE    FROM TagAppRelation;
      DELETE    FROM FeaturedImage;
      DELETE    FROM Tag;
      DELETE    FROM TempUpload;
      DELETE    FROM Review;
      DELETE    FROM Gallery;
      DELETE    FROM AppDraft;
      DELETE    FROM App;
      DELETE    FROM [User];
      DBCC checkident (''App'', reseed, 0);
      DBCC checkident (''AppDraft'', reseed, 0);
      DBCC checkident (''Tag'', reseed, 0);
      DBCC checkident (''TagAppRelation'', reseed, 0);
      DBCC checkident (''TempUpload'', reseed, 0);
      DBCC checkident (''Review'', reseed, 0);
      DBCC checkident (''Gallery'', reseed, 0);
      DBCC checkident (''[User]'', reseed, 0);
      DBCC checkident (''FeaturedImage'', reseed, 0);

	
      RETURN 0' 
END
GO
/****** Object:  StoredProcedure [dbo].[ResetAppsAndUsers]    Script Date: 23-Feb-16 2:41:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ResetAppsAndUsers]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ResetAppsAndUsers]
AS 
      DELETE    FROM App;	
      DELETE    FROM [User];	
		
      DBCC checkident(''App'', reseed, 0);
      DBCC checkident(''[User]'', reseed, 0);
      RETURN 0' 
END
GO
/****** Object:  StoredProcedure [dbo].[ResetReviews]    Script Date: 23-Feb-16 2:41:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ResetReviews]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ResetReviews]
AS 
      DELETE    FROM ReviewLikeDislike;
      DELETE    FROM Review;

      DBCC checkident (''Review'', reseed, 0);
      DBCC checkident (''ReviewLikeDislike'', reseed, 0);
      RETURN 0' 
END
GO
/****** Object:  StoredProcedure [dbo].[ResetWholeSystem]    Script Date: 23-Feb-16 2:41:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ResetWholeSystem]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ResetWholeSystem]
AS 
      BEGIN

            TRUNCATE TABLE dbo.MessageSeen;
            TRUNCATE TABLE LatestSeenNotification;
            TRUNCATE TABLE dbo.[Message];
            TRUNCATE TABLE dbo.UserPoint;

            DBCC checkident (''[MessageSeen]'', reseed, 0);
            DBCC checkident (''[LatestSeenNotification]'', reseed, 0);
            DBCC checkident (''[Message]'', reseed, 0);
            DBCC checkident (''[UserPoint]'', reseed, 0);

            EXEC dbo.ResetApps; -- removes reviews, apps, Tag,TagAppRelation,TempUpload,Gallery,User,FeaturedImage

      END' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[SplitString]    Script Date: 23-Feb-16 2:41:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SplitString]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Alim Ul Karim
-- Create date: 20 Sep 2014
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[SplitString]( @stringToSplit VARCHAR(200),@splitChar VARCHAR(1) )
RETURNS
 @returnList TABLE (ID int,[Name] [nvarchar] (500))
AS
BEGIN

 DECLARE @name NVARCHAR(255)
 DECLARE @pos INT
 DECLARE @i INT
 SELECT  @i = 0
 WHILE CHARINDEX(@splitChar, @stringToSplit) > 0
 BEGIN
 
  SELECT @pos  = CHARINDEX(@splitChar, @stringToSplit)  ;
  SELECT @name = SUBSTRING(@stringToSplit, 1, @pos-1);
  
  

  INSERT INTO @returnList 
  SELECT  @i,@name;
  
  SELECT @i =@i + 1;

  SELECT @stringToSplit = SUBSTRING(@stringToSplit, @pos+1, LEN(@stringToSplit)-@pos)
 END

 INSERT INTO @returnList
 SELECT @i,@stringToSplit

 RETURN
END
' 
END

GO
