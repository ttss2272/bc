
-- =============================================
-- Author:		Sameer Shinde
-- Create date: 16/10/2015
-- Description:	Get BC Amount from group table
-- =============================================
alter PROCEDURE Usp_GetBCAmount
	(
	@GroupID int
	)
AS
BEGIN
	
	Select BCAmount from Groups where GroupId=@GroupID
END

