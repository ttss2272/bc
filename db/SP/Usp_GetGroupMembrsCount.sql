-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 17 OCT 2015
-- Description:	Get availble no of group members and Max no of Group Members
-- =============================================
Alter PROCEDURE Usp_GetGroupMembrsCount --1
	(
	@GroupId int = 0
	)
AS
BEGIN
IF NOT EXISTS (SELECT CustomerGroupId FROM CustomerGroupDetails WHERE GroupId=@GroupId)
	BEGIN
		SELECT ISNULL(g.NoOfMembers,0) AS 'MaxMembers',0 AS 'AvailableMembers'
		FROM Groups g
		WHERE g.GroupID= @GroupId
	END
ELSE
	BEGIN
		SELECT ISNULL(g.NoOfMembers,0) AS 'MaxMembers',ISNULL(COUNT(cgd.CustomerID),0) AS 'AvailableMembers'
		FROM Groups g 
		INNER JOIN CustomerGroupDetails cgd
		ON g.GroupId=cgd.GroupId
		Where cgd.GroupId LIKE CASE WHEN @GroupId <>0 THEN @GroupID ELSE CONVERT(NVARCHAR(50),cgd.GroupId)END
		Group BY g.NoOfMembers
	END
END
GO
