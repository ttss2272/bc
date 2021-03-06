USE [DB_LoanApplication]
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetRemainingMonths]    Script Date: 11/18/2015 13:27:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Kunal>
-- Create date: <21-july-2015>
-- Description:	<For Calculate Remaining Months>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_GetRemainingMonths] --12
@GroupId int
AS
declare @remainingMonths int
declare @startdate date
declare @enddate date
declare @bcdatecount int
DECLARE @Months int
BEGIN
	set @startdate = (select StartDate from Groups where GroupId = @GroupId)
	set @enddate = (select EndDate from Groups where GroupId = @GroupId)
	set @bcdatecount=(select count(bcdate) from Transactions where GroupId=@GroupId)--BcDate between @startdate and @enddate
	if (@bcdatecount<>0)--exists (select bcdate from Transactions where BcDate between @startdate and @enddate and GroupId=@GroupId) 
	begin
		--;WITH Groups AS
		--(
		   --select DateDiff(DD,@startdate, DateAdd(DD, 1,@enddate)) as days                 --'2014-01-01''2015-01-01'
		   SET @Months=(select datediff(MONTH,@startdate,@enddate)) --+ CASE WHEN DATEPART(DD, @startdate) < DATEPART(DD, @enddate) THEN 1 ELSE 0 END)
		--)
		SET @Months=@Months-@bcdatecount
		SET @Months=@Months+1
		select @Months AS Months
		--SELECT (CAST(days as float) / 30)-@bcdatecount  as Months FROM Groups 
	END
	else
	begin
		--;WITH Groups AS
		--(
		SET @Months=(select datediff(MONTH,@startdate,@enddate)) --+ CASE WHEN DATEPART(DD, @startdate) < DATEPART(DD, @enddate) THEN 1 ELSE 0 END)
		
		  -- select DateDiff(MONTH,@startdate, DateAdd(DD, 1,@enddate)) as days                 --'2014-01-01''2015-01-01'
		      
		--)
		--SELECT CAST(days as float) / 30  as Months FROM Groups 
		SET @Months=@Months+1
		select @Months AS Months
	end
End
