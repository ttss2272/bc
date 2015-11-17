
/****** Object:  StoredProcedure [dbo].[Usp_GetGroupNames]    Script Date: 10/19/2015 13:15:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_GetGroupNames]
@GroupName nvarchar(100)
AS
BEGIN
select GroupId,GroupName,StartDate,EndDate,BCAmount,NoOfMembers from Groups where GroupName = @GroupName and IsDeleted = 0
END
