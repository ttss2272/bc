
/****** Object:  StoredProcedure [dbo].[Usp_GetInstallmentMonths]    Script Date: 10/13/2015 18:59:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Kunal Shinde>
-- Create date: <09-07-2015>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_GetInstallmentMonths]
--@customerId int,
@GroupId int
AS

declare @remainingMonths int
declare @startdate date
declare @enddate date
declare @date date
declare @tab TABLE(MONTH_NAME varchar(20))
declare @count int
set @count=0 

BEGIN
set @startdate = (select StartDate from Groups where GroupId = @GroupId)
set @enddate = (select EndDate from Groups where GroupId = @GroupId) 
		BEGIN 
			Select  i.InstallmentDate FROM Installment i inner join Groups g on g.GroupId=i.GroupId
			 where StartDate between @startdate and @enddate and i.GroupId=@GroupId 
			AND i.InstallmentDate  IS not null
		END
END

--Select i.InstallmentDate FROM Installment i inner join Groups g on g.GroupId=i.GroupId
--			 where StartDate between '2014-01-01' and '2015-01-01' and i.GroupId=6
