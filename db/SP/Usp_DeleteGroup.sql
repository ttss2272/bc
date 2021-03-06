USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_DeleteGroup]    Script Date: 10/27/2015 16:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_DeleteGroup] --15
@GroupId int
AS
Declare @Msg nvarchar(MAX)
if not EXISTS(Select GroupId from Transactions where GroupId=@GroupId)
BEGIN
       
		update Groups  set IsDeleted= 1,IsActive=0 where GroupId = @GroupId
		AND  EndDate<convert(date,Getdate())
		if (@@ROWCOUNT =1)
		begin
	    SET @Msg='Group Deleted Sucessfully'
	    select @Msg
	    end
	    else
	    begin
	      set @msg='group transaction is pending you cannot delete this group.'
	      select @Msg
	    end
END
else
begin
SET @Msg='Group Transaction is done'
	    select @Msg
end


